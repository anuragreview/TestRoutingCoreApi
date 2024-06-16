using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestCoreApi.Controllers
{
    [ApiController]
    [Route("")]
    public class ValuesController : ControllerBase
    {
        private static readonly string[] Summaries =
       [
           "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       ];
        [HttpGet(Name = "WeatherForecastByHttpGetRoute")]
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

        [HttpGet("GetDirectHttpGet")]
        public async Task<IActionResult> TestGetHttpGet()
        {
            IEnumerable<string> data = await Task.FromResult(Summaries.Append(nameof(TestGetHttpGet)));
            return Ok(data);
        }

        [HttpGet("GetShortAnonymous")]
        public async Task<IActionResult> TestTheAnonymous() => Ok(await Task.FromResult(nameof(TestTheAnonymous)));

    }
}
