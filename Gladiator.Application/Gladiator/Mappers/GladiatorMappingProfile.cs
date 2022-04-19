using AutoMapper;
using Gladiator.Application.Gladiator.Commands;
using Gladiator.Application.Gladiator.Responses;

namespace Gladiator.Application.Gladiator.Mappers
{
    public class GladiatorMappingProfile : Profile
    {
        public GladiatorMappingProfile()
        {
            //CreateMap<Core.Entities.Gladiator, GladiatorResponse>().ReverseMap();
            //CreateMap<Core.Entities.Gladiator, CreateGladiatorCommand>().ReverseMap();
        }
    }
}
