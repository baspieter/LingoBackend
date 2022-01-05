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
    public ActionResult <GameReadDto> GetGameById(int id)
    {
      var gameItem = _repository.GetGameById(id);

      return Ok(_mapper.Map<GameReadDto>(gameItem));
    }

    // CREATE games
    [HttpPost]
    public GameReadDto CreateGame()
    {

      var game = _gameService.StartNewGame();
      _repository.SaveChanges();

      return _mapper.Map<GameReadDto>(game);
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
    
    [HttpGet("[action]/{gameId:int}")]
    public GameWord Submitword(int gameId, string word)
    {
      return _gameService.CheckWord(gameId, word);
    }
  }
}