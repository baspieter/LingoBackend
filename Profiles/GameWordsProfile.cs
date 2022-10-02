using AutoMapper;
using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Profiles;

public class GameWordsProfile : Profile
{
    public GameWordsProfile()
    {
        // Source -> Target
        CreateMap<GameWord, GameWordReadDto>();
    }
}