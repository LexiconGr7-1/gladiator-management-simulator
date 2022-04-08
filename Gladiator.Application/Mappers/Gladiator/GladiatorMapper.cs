using AutoMapper;

namespace Gladiator.Application.Mappers.Gladiator
{
    public class GladiatorMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<GladiatorMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
