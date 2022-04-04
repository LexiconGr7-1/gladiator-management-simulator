using AutoMapper;
using Gladiator.Application.Commands;
using Gladiator.Application.Responses;

namespace Gladiator.Application.Mappers
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
