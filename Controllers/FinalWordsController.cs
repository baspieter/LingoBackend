using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
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
    public ActionResult <IEnumerable<WordReadDto>> GetAllFinalWords()
    {
      var finalWordItems = _repository.GetAllFinalWords();
      return Ok(_mapper.Map<IEnumerable<WordReadDto>>(finalWordItems));
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
  }
}