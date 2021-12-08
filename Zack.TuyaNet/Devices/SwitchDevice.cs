namespace Zack.TuyaNet.Devices;
public class SwitchDevice
{
    private TuyaApiClient apiClient;
    public SwitchDevice(TuyaApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<bool> GetStatusAsync(string deviceId)
    {
        var items = await apiClient.ListDeviceStatusAsync(deviceId);
        bool switchValue = items.Single(s => s.Code == "switch").GetValue<bool>();
        return switchValue;
    }

    public Task<bool> SwitchOnAsync(string deviceId)
    {
        return apiClient.SendCommandAsync(deviceId, "switch", true);
    }

    public Task<bool> SwitchOffAsync(string deviceId)
    {
        return apiClient.SendCommandAsync(deviceId, "switch", false);
    }
}