using Paylode.Test.API.Interfaces;
using Paylode.Test.API.Services;

namespace Paylode.Test.API.Extensions;

public static class ServiceInjectionExtension
{
    public static void AddServiceInjection(this IServiceCollection service)
    {
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IWeatherForecast, WeatherForecastService>();
    }
}