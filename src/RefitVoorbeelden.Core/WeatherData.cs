using System.Text.Json.Serialization;

namespace RefitVoorbeelden.Core;

public class WeatherData
{
    [JsonPropertyName("coord")]
    public Coordinates Coordinates { get; set; }
    
    [JsonPropertyName("main")]
    public Temperatures Temperatures { get; set; }
    
    [JsonPropertyName("name")]
    public string Location { get; set; }
}