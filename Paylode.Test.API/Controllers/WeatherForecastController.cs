using Microsoft.AspNetCore.Mvc;
using Paylode.Test.API.Filters;
using Paylode.Test.API.Interfaces;

namespace Paylode.Test.API.Controllers;

public class WeatherForecastController : BaseController
{
    private readonly IWeatherForecast _weatherForecast;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherForecast weatherForecast, ILogger<WeatherForecastController> logger)
    {
        _weatherForecast = weatherForecast;
        _logger = logger;
    }

    [HttpGet, Authorize]
    public IActionResult GetAll()
    {
        return Ok(_weatherForecast.GetWeatherForecast());
    }
}