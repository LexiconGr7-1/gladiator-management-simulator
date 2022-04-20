using AutoMapper;
using Gladiator.Application.Arena.Responses;
using Gladiator.Application.Gear.Responses;
using Gladiator.Application.Gladiator.Responses;
using Gladiator.Application.Player.Responses;
using Gladiator.Application.School.Responses;
using Gladiator.Application.Stats.Responses;

namespace Gladiator.Application.Gladiator.Mappers
{
    public class GladiatorMappingProfile : Profile
    {
        public GladiatorMappingProfile()
        {
            //CreateMap<Core.Entities.Gladiator, GladiatorResponseRelatives>().ReverseMap();
            //CreateMap<Core.Entities.Gladiator, CreateGladiatorCommand>().ReverseMap();

            CreateMap<Core.Entities.Gladiator, GladiatorResponseRelational>();

            CreateMap<Core.Entities.Stats, StatsResponse>();
            CreateMap<Core.Entities.Arena, ArenaResponse>();
            CreateMap<Core.Entities.School, SchoolResponse>();
            CreateMap<Core.Entities.Gladiator, GladiatorResponse>();
            CreateMap<Core.Entities.Player, PlayerResponse>();
            CreateMap<Core.Entities.Gear, GearResponse>();

        }
    }
}
