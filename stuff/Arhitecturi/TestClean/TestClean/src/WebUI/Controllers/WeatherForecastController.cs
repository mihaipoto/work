using Microsoft.AspNetCore.Mvc;
using TestClean.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace TestClean.WebUI.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
