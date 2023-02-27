using AMS.Domain.LocationAggregate;

namespace AMS.Api.Common.Mapping
{
    public class LocationsMappingConfig:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateLocationRequest, CreateLocationCommand>()
                // .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest, src => src);
            
            config.NewConfig<Location,CreateLocationRequest>()
                // .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest, src => src);


        }
    }
}
