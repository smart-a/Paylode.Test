using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Paylode.Test.API.Extensions;

public static class SwaggerServiceExtension
{
    public static void AddSwaggerConfig(this IServiceCollection services) =>
        services.AddSwaggerGen(c =>
        {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Title = "Paylode",
                    Version = "V1",
                    Description = "Paylode API Documentation",
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme.",
                        BearerFormat = "JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                    });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
            });
}