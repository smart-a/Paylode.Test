using Paylode.Test.API.Config;

namespace Paylode.Test.API.Extensions;

public static class EnvironmentExtension
{
    public static void AddEnvironmentVariable(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<JwtCredentials>(config.GetSection("Jwt"));
    }
}