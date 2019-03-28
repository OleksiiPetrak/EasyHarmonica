using AutoMapper;

namespace EasyHarmonica.BLL.Infrastructure.AutoMapper
{
    public class MapperProfilesBllInitializator
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile(new DTOToEntityProfile());
            cfg.AddProfile(new EntityToDTOProfile());
        }
    }
}
