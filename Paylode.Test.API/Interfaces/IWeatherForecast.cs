namespace Paylode.Test.API.Interfaces;

public interface IWeatherForecast
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}