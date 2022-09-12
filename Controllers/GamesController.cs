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
    
    // SUBMIT WORD
    [HttpGet("[action]/{gameId:int}/{word}")]
    public GameWord Submitword(int gameId, string word)
    {
      return _gameService.CheckWord(gameId, word);
    }
    
    // SUBMIT FINAL WORD
    [Route("{gameId:int}/submitFinalWord/{finalWordGuess}")]
    [HttpGet]
    public Dictionary<string, object> SubmitFinalword(int gameId, string finalWordGuess)
    {
      return _gameService.CheckFinalWord(gameId, finalWordGuess);
    }
  }
}