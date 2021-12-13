using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GamesController : ControllerBase
  {
    private readonly IGameRepo _repository;

    public IMapper _mapper { get; }

    public GamesController(IGameRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
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
    public ActionResult <GameReadDto> CreateGame(GameCreateDto gameCreateDto)
    {
      var gameModel = _mapper.Map<Game>(gameCreateDto);
      _repository.CreateGame(gameModel);
      _repository.SaveChanges();

      var gameReadDto = _mapper.Map<GameReadDto>(gameModel);

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