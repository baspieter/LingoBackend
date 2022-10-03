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
            String finalWordProgress = updateFinalWordProgress(finalWord.Name, new string(""));
            if (word == null || finalWord == null)
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

        public Dictionary<string, object> GetGameData(int gameId)
        {
            var gameDictionary = new Dictionary<string, object>();
            var game = FindGame(gameId);
            var gameDto = _mapper.Map<GameReadDto>(game);
            gameDictionary.Add("Game", gameDto);

            var gameWord = FindGameWord(game);
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
    
        public Dictionary<string, object> CheckGameWord(int gameId, string wordGuess)
        {
            var game = _context.Game.Where(game => game.Id == gameId).Include(game => game.GameWords).FirstOrDefault();
            var gameWord = _gameWordRepo.GetGameWordsByGame(game).First();
            _gameWordRepo.AddSubmittedWord(gameWord, wordGuess);
            _gameWordRepo.SaveChanges();

            if (_gameWordRepo.FinishedGameWord(gameWord))
            {
                _gameWordRepo.FinishGameWord(gameWord);
                _gameWordRepo.SaveChanges();
            }
            return GetGameData(game.Id);
        }

        public Dictionary<string, object> CheckFinalWord(int gameId, string finalWordGuess)
        {
            var game = _context.Game.Where(game => game.Id == gameId).Include(game => game.FinalWord).FirstOrDefault();
            var originalFinalWord = game.FinalWord.Name;
            if (originalFinalWord == null) throw new ArgumentNullException();

            if (originalFinalWord == finalWordGuess)
            {
                FinishGame(game);
            }

            return GetGameData(gameId);
        }

        public Word? NewGameWord(int gameId)
        {
            var gameWords = FindGame(gameId)?.GameWords;
            var usedWordIds = gameWords?.Select(gameWord => gameWord.Word.Id).ToArray();
            return usedWordIds == null ? throw new ArgumentNullException() : _wordService.SetGameWord(usedWordIds);
        }

        private Game FindGame(int gameId)
        {
            return _gameRepo.GetGameById(gameId);
        }

        private GameWord FindGameWord(Game game)
        {
            var gameWords = _gameWordRepo.GetGameWordsByGame(game);
            var currentGameWord = gameWords.Include(a => a.Word).OrderBy(p => p.Finished == true).Last();
            return currentGameWord;
        }

        private void FinishGame(Game game)
        {
            game.Status = Status.Finished;
            game.FinalWordProgress = game.FinalWord.Name;
            _gameRepo.SaveChanges();
        }

        private String updateFinalWordProgress(String finalWord, String guessedWord)
        {
            var guessedWordChars = new List<char>(guessedWord);
            if (guessedWord == finalWord)
            {
                return new string(guessedWordChars.ToArray());
            }
        
            var finalWordChars = new List<char>(finalWord);
            var newFinalWordProgress = new List<char>();
            for(var i = 0; i < finalWordChars.Count; i++)
            {
                if (guessedWordChars.Count != finalWordChars.Count || finalWordChars[i] != guessedWordChars[i])
                {
                    newFinalWordProgress.Add('.');
                }
                else
                {
                    newFinalWordProgress.Add(finalWordChars[i]);
                }
            }
            return new string(newFinalWordProgress.ToArray());
        }
    }
}
