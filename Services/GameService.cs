using System.Text.Json;
using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;

using Lingo.Models;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using Lingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IGameWordRepo _gameWordRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IWordService _wordService;
        private readonly IGameWordService _gameWordService;
        private readonly LingoContext _context;
        public IMapper _mapper { get; }

        public GameService(IGameRepo gameRepo, IGameWordRepo gameWordRepo, IFinalWordService finalWordService, IWordService wordService, IGameWordService gameWordService, IMapper mapper, LingoContext context)
        {
            _gameRepo = gameRepo;
            _gameWordRepo = gameWordRepo;
            _finalWordService = finalWordService;
            _wordService = wordService;
            _gameWordService = gameWordService;
            _mapper = mapper;
            _context = context;
        }

        public Game StartNewGame()
        {
            var word = _wordService.SetWord();
            var finalWord = _finalWordService.SetFinalWord();
            String finalWordProgress = _finalWordService.finalWordProgress(finalWord.Name, new string(""));
            if (word == null || finalWord?.Name == null)
            {
                throw new ArgumentNullException();
            }

            var game = new Game
            {
                FinalWord = finalWord,
                FinalWordProgress = finalWordProgress
            };

            var gameWord = new GameWord
            {
                Game = game,
                Word = word
            };

            _gameRepo.Add(game);
            _gameRepo.SaveChanges();
            _gameWordRepo.CreateGameWord(gameWord);
            _gameWordRepo.SaveChanges();
            
            return game;
        }

        public Dictionary<string, object> GetGameData(int gameId, int gameWordId=0)
        {
            var gameDictionary = new Dictionary<string, object>();
            var game = FindGame(gameId);
            var gameDto = _mapper.Map<GameReadDto>(game);
            gameDictionary.Add("Game", gameDto);

            var gameWord = gameWordId != 0 ? _gameWordRepo.GetGameWordById(gameWordId) : FindGameWord(game);
            
            var gameWordDto = _mapper.Map<GameWordReadDto>(gameWord);
            gameDictionary.Add("Gameword", gameWordDto);

                var word = gameWord?.Word;
            if (word != null)
            {
                var wordDto = _mapper.Map<WordReadDto>(word);
                gameDictionary.Add("Word", wordDto);
            }
            
            var finalWordDto = _mapper.Map<FinalWordReadDto>(game.FinalWord);
            gameDictionary.Add("Finalword", finalWordDto);

            return gameDictionary;
        }
    
        public Dictionary<string, object> CheckGameWord(int gameWordId, string wordGuess, int timer)
        {
            var gameWord = _gameWordRepo.GetGameWordById(gameWordId);
            var game = _context.Game.Where(game => game.Id == gameWord.Game.Id).Include(a => a.FinalWord).FirstOrDefault();
            _gameWordRepo.AddSubmittedWord(gameWord, wordGuess);
            _gameWordRepo.SaveChanges();

            if (_gameWordRepo.FinishedGameWord(gameWord))
            {
                _gameWordRepo.FinishGameWord(gameWord);
                if (wordGuess == gameWord.Word.Name)
                {
                    game.FinalWordProgress = _finalWordService.addFinalWordHint(game.FinalWord.Name, game.FinalWordProgress);
                }

                var number = game.Round;
                if (game.Round == 10)
                {
                    FinishGame(game, false);
                }
                else
                {
                    game.Round = number + 1;
                }
            }

            UpdateTimer(game, timer);
            _gameWordRepo.SaveChanges();
            _gameRepo.SaveChanges();
            return GetGameData(game.Id, gameWord.Id);
        }
        public Dictionary<string, object> CheckFinalWord(int gameId, string finalWordGuess, int timer)
        {
            var game = _context.Game.Where(game => game.Id == gameId).Include(game => game.FinalWord).FirstOrDefault();
            var originalFinalWord = game.FinalWord.Name;
            if (originalFinalWord == null) throw new ArgumentNullException();

            if (originalFinalWord == finalWordGuess)
            {
                game.Timer = timer;
                FinishGame(game, true);
            }
            else
            {
                UpdateTimer(game, timer);
                _gameRepo.SaveChanges();
            }

            
            return GetGameData(gameId);
        }

        public Word? NewGameWord(int gameId)
        {
            var game = _context.Game.Where(game => game.Id == gameId).Include(game => game.GameWords).FirstOrDefault();
            var gameWords = game?.GameWords;
            IEnumerable<int> usedWordIds = new List<int>();

            if (gameWords?.Count > 0)
            {
                usedWordIds = gameWords?.Select(gameWord => gameWord.Word.Id);
            }
    
            return _wordService.SetGameWord(usedWordIds);
        }

        public Dictionary<string, object> NextRound(int gameId, int timer)
        {
            var game = _context.Game.Where(game => game.Id == gameId).FirstOrDefault();
            var word = NewGameWord(gameId);
            var gameWord = new GameWord
            {
                Game = game,
                Word = word
            };

            UpdateTimer(game, timer);
            
            _gameWordRepo.CreateGameWord(gameWord);
            _gameWordRepo.SaveChanges();
            
            return GetGameData(gameId);
        }
        
        public Dictionary<string, object> UpdateTimer(int gameId, int timer)
        {
            var game = _context.Game.Where(game => game.Id == gameId).FirstOrDefault();
            UpdateTimer(game, timer);

            _gameWordRepo.SaveChanges();
            
            return GetGameData(gameId);
        }

        private void UpdateTimer(Game game, int timer)
        {
            if (game.Status == Status.Finished) return;
            
            game.Timer = timer;
            if (timer == 0)
            {
                FinishGame(game, false);
            }
        }

        private Game FindGame(int gameId)
        {
            return _gameRepo.GetGameById(gameId);
        }

        private GameWord FindGameWord(Game game)
        {
            var gameWords = _gameWordRepo.GetGameWordsByGame(game);
            var currentGameWord = gameWords.Include(a => a.Word).OrderBy(p => p.Finished == false).Last();
            
            return currentGameWord;
        }

        private void FinishGame(Game game, Boolean success)
        {
            game.Status = Status.Finished;
            if (success)
            {
                game.FinalWordProgress = game.FinalWord.Name;
            }
            _gameRepo.SaveChanges();
        }
    }
}
