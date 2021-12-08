using System.Text.Json.Serialization;
using Zack.TuyaNet.Json;

namespace Zack.TuyaNet.Services
{
    public record WeatherForecastInfo
    {
        /// <summary>
        /// 当日最高体感温度
        /// </summary>
        [JsonPropertyName("apparent_temperature_max")]
        [JsonConverter(typeof(BigDecimalJsonConverter))]
        public double ApparentTemperatureMax { get; set; }

        /// <summary>
        /// 当日最低体感温度
        /// </summary>
        [JsonPropertyName("apparent_temperature_min")]
        [JsonConverter(typeof(BigDecimalJsonConverter))]
        public double ApparentTemperatureMin { get; set; }
        
        [JsonPropertyName("condition")]
        public string Condition { get; set; }
        
        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(Int32JsonConverter))]
        public int Humidity { get; set; }
        
       /// <summary>
       /// 当日最低气温
       /// </summary>
       [JsonPropertyName("temperature_max")]
       [JsonConverter(typeof(BigDecimalJsonConverter))]
       public double TemperatureMax { get; set; }

       /// <summary>
       /// 当日最高气温
       /// </summary>
       [JsonPropertyName("temperature_min")]
       [JsonConverter(typeof(BigDecimalJsonConverter))]
       public double TemperatureMin { get; set; }

       /// <summary>
       /// 紫外线强度
       /// </summary>
       [JsonPropertyName("uvi")]
       [JsonConverter(typeof(Int32JsonConverter))]
       public int UVI { get; set; }

       /// <summary>
       /// 风向
       /// </summary>
       [JsonPropertyName("wind_dir")]
       public string WindDir { get; set; }

       /// <summary>
       /// 风速
       /// </summary>
       [JsonPropertyName("wind_speed")]
       [JsonConverter(typeof(DoubleJsonConverter))]
       public double WindSpeed { get; set; }
    }
}
