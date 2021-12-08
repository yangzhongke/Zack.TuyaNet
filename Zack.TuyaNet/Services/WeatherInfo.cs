using System.Text.Json.Serialization;
using Zack.TuyaNet.Json;

namespace Zack.TuyaNet.Services
{
    public record WeatherInfo
    {
        [JsonPropertyName("condition")]
        public string Condition { get; set; }

        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(Int32JsonConverter))]
        public int Humidity { get; set; }

        [JsonPropertyName("pressure")]
        [JsonConverter(typeof(Int32JsonConverter))]
        public int Pressure { get; set; }

        [JsonPropertyName("real_feel")]
        [JsonConverter(typeof(Int32JsonConverter))]
        public int RealFeel { get; set; }

        [JsonPropertyName("temp")]
        [JsonConverter(typeof(Int32JsonConverter))]
        public int Temperature { get; set; }

        [JsonPropertyName("wind_speed")]
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double WindSpeed { get; set; }
    }
}
