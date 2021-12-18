using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FinalWordsController : ControllerBase
  {
    private readonly IFinalWordRepo _repository;

    public IMapper _mapper { get; }

    public FinalWordsController(IFinalWordRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET finalwords
    [HttpGet]
    public ActionResult <IEnumerable<FinalWordReadDto>> GetAllFinalWords()
    {
      var finalWordItems = _repository.GetAllFinalWords();
      return Ok(_mapper.Map<IEnumerable<FinalWordReadDto>>(finalWordItems));
    }


    // GET finalwords/{id}
    [HttpGet("{id}", Name="GetFinalWordById")]
    public ActionResult <FinalWordReadDto> GetFinalWordById(int id)
    {
      var finalWordItem = _repository.GetFinalWordById(id);
      if(finalWordItem != null)
      {
      return Ok(_mapper.Map<FinalWordReadDto>(finalWordItem));
      }

      return NotFound();
    }

    // POST finalwords
    [HttpPost]
    public ActionResult <FinalWordReadDto> CreateFinalWord(FinalWordCreateDto finalWordCreateDto)
    {
      var finalWordModel = _mapper.Map<FinalWord>(finalWordCreateDto);
      _repository.CreateFinalWord(finalWordModel);
      _repository.SaveChanges();

      var finalWordReadDto = _mapper.Map<FinalWordReadDto>(finalWordModel);

      return CreatedAtRoute(nameof(GetFinalWordById), new {Id = finalWordReadDto.Id}, finalWordReadDto);
    }

    // PUT finalWords/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateFinalWord(int id, FinalWordUpdateDto finalWordUpdateDto)
    {
      var finalWordModelFromRepo = _repository.GetFinalWordById(id);
      if(finalWordModelFromRepo == null)
      {
        return NotFound();
      }

      _mapper.Map(finalWordUpdateDto, finalWordModelFromRepo);

      _repository.UpdateFinalWord(finalWordModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    //DELETE finalwords/{id}
    //Finalword should not be connected to a existing game
    //TODO validateion for finalwords with games.
    [HttpDelete("{id}")]
    public ActionResult DeleteFinalWord(int id)
    {
      var finalWordModelFromRepo = _repository.GetFinalWordById(id);
      if(finalWordModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteFinalWord(finalWordModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}