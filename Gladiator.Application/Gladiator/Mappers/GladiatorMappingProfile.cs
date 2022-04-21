using AutoMapper;
using Gladiator.Application.Gladiator.Responses;

namespace Gladiator.Application.Gladiator.Mappers
{
    public class GladiatorMappingProfile : Profile
    {
        public GladiatorMappingProfile()
        {
            CreateMap<Core.Entities.Gladiator, GladiatorFullResponse>();
            CreateMap<Core.Entities.Stats, GladiatorStatsResponse>();
            CreateMap<Core.Entities.Arena, GladiatorArenaResponse>();
            CreateMap<Core.Entities.School, GladiatorSchoolResponse>();
            CreateMap<Core.Entities.Player, GladiatorPlayerResponse>();
            CreateMap<Core.Entities.Gear, GladiatorGearResponse>();
        }
    }
}
