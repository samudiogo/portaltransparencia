using AutoMapper;

namespace Transparencia.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
        }
    }
}