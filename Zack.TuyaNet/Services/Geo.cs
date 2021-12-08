using System.Text.Json.Serialization;
using Zack.TuyaNet.Json;

namespace Zack.TuyaNet.Services
{
    public record Geo
    {
        [JsonPropertyName("latitude")]
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Longitude { get; set; }

        public void Deconstruct(out double latitude,out double longitude)
        {
            latitude = this.Latitude;
            longitude = this.Longitude;
        }
    }
}
