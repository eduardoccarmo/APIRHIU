using AutoMapper;

namespace APIRHUI.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new DtoToDomain());
            });
        }
    }
}
