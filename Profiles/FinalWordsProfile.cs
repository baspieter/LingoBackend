using AutoMapper;
using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Profiles
{
  public class FinalWordsProfile : Profile
  {
    public FinalWordsProfile()
    {
      // Source -> Target
      CreateMap<FinalWord, FinalWordReadDto>();
      CreateMap<FinalWordCreateDto, FinalWord>();
      CreateMap<FinalWordUpdateDto, FinalWord>();
      CreateMap<FinalWord, FinalWordUpdateDto>();
    }
  }
}
