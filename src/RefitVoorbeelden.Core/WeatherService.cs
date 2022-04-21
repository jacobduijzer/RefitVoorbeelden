namespace RefitVoorbeelden.Core;

public class WeatherService
{
    private readonly IOpenWeatherApi _openWeatherApi;

    public WeatherService(IOpenWeatherApi openWeatherApi)
    {
        _openWeatherApi = openWeatherApi;
    }

    public async Task<WeatherData> GetWeatherForLocation(string latitude, string longitude, string apiKey) =>
        await _openWeatherApi.WeatherForLocation(latitude, longitude, apiKey)
            .ConfigureAwait(false);
}