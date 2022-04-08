using AutoMapper;
using Gladiator.Application.Commands.Gladiator;
using Gladiator.Application.Responses.Gladiator;

namespace Gladiator.Application.Mappers.Gladiator
{
    public class GladiatorMappingProfile : Profile
    {
        public GladiatorMappingProfile()
        {
            CreateMap<Core.Entities.Gladiator, GladiatorResponse>().ReverseMap();
            CreateMap<Core.Entities.Gladiator, CreateGladiatorCommand>().ReverseMap();
        }
    }
}
