using Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ServiceBookingPlatformApi.ServiceExtensions
{
    public static class ServiceExtensions
    {
        // Налаштування JWT аутентифікації
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtOptions jwtOpts)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                    {
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOpts.Issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
                            ClockSkew = TimeSpan.Zero
                        };
                    });

            return services;
        }

        // Реєстрація налаштувань JwtOptions
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(_ =>
                configuration
                    .GetSection(nameof(JwtOptions))
                    .Get<JwtOptions>()!);

            return services;
        }

        // Налаштування авторизаційних політик
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ServiceProviderOnly", policy => policy.RequireRole("ServiceProvider"));
                options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
            });

            return services;
        }
    }
}
