using Refit;

namespace RefitVoorbeelden.Core;

public interface IOpenWeatherApi
{
    [Get("/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric")]
    Task<WeatherData> WeatherForLocation(string lat, string lon, string apiKey);
}