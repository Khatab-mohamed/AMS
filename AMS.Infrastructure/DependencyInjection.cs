using AMS.Application.Common.Interfaces;
using AMS.Application.Common.Interfaces.Authentication;
using AMS.Infrastructure.Authentication;
using AMS.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace AMS.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                       ConfigurationManager configuration)
    {
        services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));

        services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;


    }

}
