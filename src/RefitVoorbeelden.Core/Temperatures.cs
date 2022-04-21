using System.Text.Json.Serialization;

namespace RefitVoorbeelden.Core;

public class Temperatures
{
    [JsonPropertyName("temp")]
    public double Current { get; set; }
    
    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }
    
    [JsonPropertyName("temp_min")]
    public double Minimum { get; set; }
    
    [JsonPropertyName("temp_max")]
    public double Maximum { get; set; }
}