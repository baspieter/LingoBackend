using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using Lingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GamesController : ControllerBase
  {
    private readonly IGameRepo _repository;
    private readonly IGameService _gameService;

    public IMapper _mapper { get; }

    public GamesController(IGameRepo repository, IMapper mapper, IGameService gameService)
    {
      _repository = repository;
      _mapper = mapper;
      _gameService = gameService;
    }

    // GET games
    [HttpGet]
    public ActionResult <IEnumerable<GameReadDto>> GetAllGames()
    {
      var gameItems = _repository.GetAllGames();
      return Ok(_mapper.Map<IEnumerable<GameReadDto>>(gameItems));
    }

    // GET games/{id}
    [HttpGet("{id}", Name="GetGameById")]
    public Dictionary<string, object> GetGameById(int id)
    {
      return _gameService.GetGameData(id);
    }

    // CREATE games
    [HttpPost]
    public Dictionary<string, object> CreateGame()
    {

      var game = _gameService.StartNewGame();
      _repository.SaveChanges();

      return _gameService.GetGameData(game.Id);
    }

    // EDIT games/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateGame(int id, GameUpdateDto gameUpdateDto)
    {
      var gameModelFromRepo = _repository.GetGameById(id);

      _mapper.Map(gameUpdateDto, gameModelFromRepo);

      _repository.UpdateGame(gameModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }
    
    // SUBMIT FINAL WORD
    [Route("{gameId:int}/submitFinalWord/{finalWordGuess}/{timer}")]
    [HttpGet]
    public Dictionary<string, object> SubmitFinalword(int gameId, string finalWordGuess, int timer)
    {
      return _gameService.CheckFinalWord(gameId, finalWordGuess, timer);
    }
    
    // SUBMIT WORD
    [Route("{gameWordId:int}/submitWord/{wordGuess}/{timer}")]
    [HttpGet]
    public Dictionary<string, object> SubmitWord(int gameWordId, string wordGuess, int timer)
    {
      return _gameService.CheckGameWord(gameWordId, wordGuess, timer);
    }
    
    // NEXT ROUND
    [Route("{gameId:int}/nextRound/{timer}")]
    [HttpGet]
    public Dictionary<string, object> NextRound(int gameId, int timer)
    {
      return _gameService.NextRound(gameId, timer);
    }
    
    // UPDATE TIMER
    [Route("{gameId:int}/updateTimer/{timer}")]
    [HttpGet]
    public Dictionary<string, object> UpdateTimer(int gameId, int timer)
    {
      return _gameService.UpdateTimer(gameId, timer);
    }
  }
}