using AutoMapper;
using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Profiles
{
  public class GamesProfile : Profile
  {
    public GamesProfile()
    {
      // Source -> Target
      CreateMap<Game, GameReadDto>();
      CreateMap<GameCreateDto, Game>();
    }
  }
}
