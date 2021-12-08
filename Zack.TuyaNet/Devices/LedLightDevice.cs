namespace Zack.TuyaNet.Devices;
public class LedLightDevice
{
    private TuyaApiClient apiClient;
    public LedLightDevice(TuyaApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<LedLightStatus> GetStatusAsync(string deviceId)
    {
        var items = await apiClient.ListDeviceStatusAsync(deviceId);
        bool switch_led = items.Single(s => s.Code == "switch_led").GetValue<bool>();
        string work_mode = items.Single(s => s.Code == "work_mode").GetValue<string>();
        short bright_value = items.Single(s => s.Code == "bright_value").GetValue<short>();
        short temp_value = items.Single(s => s.Code == "temp_value").GetValue<short>();
        var colour_data = items.Single(s => s.Code == "colour_data").GetValue<HSV>();
        return new LedLightStatus { 
            Brightness=bright_value,Temperature=temp_value,
            Color=colour_data,
            SwitchLed=switch_led,WorkMode=work_mode};
    }

    public Task<bool> SwitchOnAsync(string deviceId)
    {
        return apiClient.SendCommandAsync(deviceId, "switch_led", true);
    }

    public Task<bool> SwitchOffAsync(string deviceId)
    {
        return apiClient.SendCommandAsync(deviceId, "switch_led", false);
    }
    public Task<bool> ChangeBrightnessAsync(string deviceId,byte value)
    {
        return apiClient.SendCommandAsync(deviceId, "bright_value", value);
    }
    public Task<bool> ChangeWorkModeAsync(string deviceId, string value)
    {
        if(value!= "white"&&value!= "colour")
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        return apiClient.SendCommandAsync(deviceId, "work_mode", value);
    }
    public Task<bool> ChangeTemperatureAsync(string deviceId, byte value)
    {
        return apiClient.SendCommandAsync(deviceId, "temp_value", value);
    }
    public Task<bool> ChangeColorAsync(string deviceId, HSV value)
    {
        return apiClient.SendCommandAsync(deviceId, "colour_data", value);
    }
}