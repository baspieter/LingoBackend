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
    private readonly IUnitOfWork _unitOfWork;

    public IMapper _mapper { get; }

    public GamesController(IGameRepo repository, IMapper mapper, IGameService gameService, IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
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
      if(gameItem != null)
      {
      return Ok(_mapper.Map<GameReadDto>(gameItem));
      }

      return NotFound();
    }

    // CREATE games
    [HttpPost]
    public async Task<ActionResult<GameReadDto>> CreateGameAsync(GameCreateDto gameCreateDto)
    {

      var game = await _gameService.StartNewGame();

      await _unitOfWork.SaveChangesAsync();

      var gameReadDto = _mapper.Map<GameReadDto>(game);

      return CreatedAtRoute(nameof(GetGameById), new {Id = gameReadDto.Id}, gameReadDto);
    }

    // EDIT games/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateGame(int id, GameUpdateDto gameUpdateDto)
    {
      var gameModelFromRepo = _repository.GetGameById(id);
      if(gameModelFromRepo == null)
      {
        return NotFound();
      }

      _mapper.Map(gameUpdateDto, gameModelFromRepo);

      _repository.UpdateGame(gameModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }
  }
}