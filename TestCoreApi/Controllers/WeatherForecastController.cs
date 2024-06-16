using Microsoft.AspNetCore.Mvc;

namespace TestCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastByHttpGetRoute")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetByDirectRoute")]
        public async Task<IActionResult> GetDataByRote()
        {
            IEnumerable<string> data = await Task.FromResult(Summaries);
            return Ok(data);
        }

        [HttpGet("GetHttpGet")]
        public async Task<IActionResult> GetHttpGet()
        {
            IEnumerable<string> data = await Task.FromResult(Summaries);
            return Ok(data);
        }
    }
}
