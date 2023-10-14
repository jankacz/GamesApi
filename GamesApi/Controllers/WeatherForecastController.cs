using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public class AuthModel
        {
            public string Auth { get; set; }
        }

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }

        [HttpGet("data")]
        public string Get2([FromQuery] string name)
        {
            if (name == null)
            {
                return "Type in name query parameter";
            }

            return $"Hello {name}";
        }

        [HttpGet("data/{id}")]
        public string Get2([FromQuery]string name, [FromRoute]int id)
        {
            if (name==null)
            {
                return "Type in name query parameter";
            }
            if (id == 0)
            {
                return "You are zero!";
            }

            return $"Hello {name}";
        }

        [HttpPost]
        public ActionResult<string> GenerateToken([FromBody] AuthModel authModel, [FromQuery] string name)
        {
            if (authModel?.Auth == null || authModel.Auth != "qwe123!@#")
            {
                HttpContext.Response.StatusCode = 401;
                return "Do not authorized!";
            }
            if (name == "Wąski")
            {
                return NotFound("Niby autoryzacja jest, ale... Kim ty w ogole jestes?!");
            }
            return StatusCode(200, "Secret code: leavemealone");

        }
    }
}
