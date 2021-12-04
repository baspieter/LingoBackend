using AutoMapper;
using Lingo.Data;
using Lingo.Dtos;
using Lingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WordsController : ControllerBase
  {
    private readonly IWordRepo _repository;

    public IMapper _mapper { get; }

    public WordsController(IWordRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET words
    [HttpGet]
    public ActionResult <IEnumerable<WordReadDto>> GetAllWords()
    {
      var wordItems = _repository.GetAllWords();
      return Ok(_mapper.Map<IEnumerable<WordReadDto>>(wordItems));
    }

    // GET words/{id}
    [HttpGet("{id}", Name="GetWordById")]
    public ActionResult <WordReadDto> GetWordById(int id)
    {
      var wordItem = _repository.GetWordById(id);
      if(wordItem != null)
      {
      return Ok(_mapper.Map<WordReadDto>(wordItem));
      }

      return NotFound();

    }

    // POST words
    [HttpPost]
    public ActionResult <WordReadDto> CreateWord(WordCreateDto wordCreateDto)
    {
      var wordModel = _mapper.Map<Word>(wordCreateDto);
      _repository.CreateWord(wordModel);
      _repository.SaveChanges();

      var wordReadDto = _mapper.Map<WordReadDto>(wordModel);

      return CreatedAtRoute(nameof(GetWordById), new {Id = wordReadDto.Id}, wordReadDto);
    }
  }
}