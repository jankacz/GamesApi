using System.Collections.Generic;

namespace GamesApi
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}