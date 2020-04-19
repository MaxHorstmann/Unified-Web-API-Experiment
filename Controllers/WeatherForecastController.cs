using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace crud_experiment.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [Route("/api/[controller]")]        
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly Random _rng = new Random();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/[controller]")]        
        public IEnumerable<WeatherForecast> Get() => GetWeatherForecasts();
 
        [HttpGet]
        [Route("/[controller]")]        
        public IActionResult Index() => View(GetWeatherForecasts());

        private IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = _rng.Next(-20, 55),
                            Summary = Summaries[_rng.Next(Summaries.Length)]
                        }).ToArray();            
        }
    }
}
