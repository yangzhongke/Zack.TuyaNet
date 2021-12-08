using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zack.TuyaNet
{
    public record DeviceStatus
    {
        /// <summary>
        /// DPS number
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// DPS value.
        /// </summary>
        [JsonPropertyName("value")]
        public JsonElement Value { get; set; }
        public T? GetValue<T>()
        {
            return Value.Deserialize<T>();
        }
    }
}
