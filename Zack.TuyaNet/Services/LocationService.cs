using System.Text.Json;

namespace Zack.TuyaNet.Services
{
    public class LocationService
    {
        private TuyaApiClient apiClient;

        public LocationService(TuyaApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<Geo?> AddressToGeoAsync(string address)
        {
            var uri = $"v1.0/iot-03/geocode-cities/address?address={Uri.EscapeDataString(address)}";
            var response = await apiClient.RequestAsync(uri, HttpMethod.Get,isTokenApi:false);
            return JsonSerializer.Deserialize<Geo>(response);
        }
    }
}
