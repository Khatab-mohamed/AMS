﻿namespace AMS.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, AmsProblemDetailsFactory>();

        services.AddMappings();
        return services;
    }

}