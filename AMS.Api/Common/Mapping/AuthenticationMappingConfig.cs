namespace AMS.Api.Common.Mapping;
public class AuthenticationMappingConfig :IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticateResult, AuthenticateResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}