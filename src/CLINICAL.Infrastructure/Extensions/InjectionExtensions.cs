﻿using CLINICAL.Application.Interface.Authentication;
using CLINICAL.Application.Interface.Services;
using CLINICAL.Infrastructure.Authentication;
using CLINICAL.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IFileStorage, FileStorage>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}