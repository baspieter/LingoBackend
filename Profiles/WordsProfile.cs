using AutoMapper;
using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Profiles
{
  public class WordsProfile : Profile
  {
    public WordsProfile()
    {
      // Source -> Target
      CreateMap<Word, WordReadDto>();
      CreateMap<WordCreateDto, Word>();
      CreateMap<WordUpdateDto, Word>();
      CreateMap<Word, WordUpdateDto>();
    }
  }
}
