using System.Text.Json;

namespace Zack.TuyaNet.Services
{
    public class SMSService
    {
        private TuyaApiClient apiClient;

        public SMSService(TuyaApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<bool> PushMessageAsync(string country_code,string phone,string template_id,object template_param)
        {
            object body = new { country_code ,phone,template_id, template_param=JsonSerializer.Serialize(template_param)};
            var uri = $"v1.0/iot-03/messages/sms/actions/push";
            var response = await apiClient.RequestAsync(uri,
                HttpMethod.Post, body: body, isTokenApi: false);
            var rootElment = JsonSerializer.Deserialize<JsonElement>(response);
            return rootElment.GetProperty("send_status").GetBoolean();
        }
    }
}
