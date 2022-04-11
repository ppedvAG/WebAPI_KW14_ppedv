using DefaultWebAPI_NET6.Services;
using Microsoft.AspNetCore.Mvc;

namespace DefaultWebAPI_NET6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICar car;

        //Konstruktor Injection -> ILogger wird via AddController intern auch dem IOC Container hinzugefügt. 

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICar myCar)
        {
            _logger = logger;
            car = myCar;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromServices] ICar mockCar, string plz)
        { 
            //IServiceScope scope = this.HttpContext.RequestServices.CreateScope();
            //scope.ServiceProvider.
           
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //[HttpGet(Name = "/GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get1([FromServices] ICar mockCar)
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}