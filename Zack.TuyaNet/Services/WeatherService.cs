using System.Text.Json;

namespace Zack.TuyaNet.Services
{
    public class WeatherService
    {
        private TuyaApiClient apiClient;

        public WeatherService(TuyaApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<WeatherInfo?> GetWeatherAsync(Geo geo)
        {
            (double lat, double lon) = geo;
            var uri = $"v2.0/iot-03/weather/current?lat={lat}&lon={lon}";
            var response = await apiClient.RequestAsync(uri, HttpMethod.Get,isTokenApi:false);            
            var rootElment = JsonSerializer.Deserialize<JsonElement>(response);
            WeatherInfo weather = rootElment.GetProperty("current_weather").Deserialize<WeatherInfo>();
            return weather;
        }

        public async Task<WeatherForecastInfo[]> ForecastDailyAsync(Geo geo)
        {
            (double lat, double lon) = geo;
            var uri = $"v2.0/iot-03/weather/forecast/daily?lat={lat}&lon={lon}";
            var response = await apiClient.RequestAsync(uri, HttpMethod.Get, isTokenApi: false);
            var rootElment = JsonSerializer.Deserialize<JsonElement>(response);
            var items = rootElment.GetProperty("data").Deserialize<WeatherForecastInfo[]>();
            return items;
        }
    }
}
