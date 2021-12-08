namespace Zack.TuyaNet.Devices;
public class AirConditioner
{
    private TuyaApiClient apiClient;
    public AirConditioner(TuyaApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<bool> PowerOnAsync(string deviceId)
    {
        return await apiClient.SendCommandAsync(deviceId, "PowerOn");
    }
    public Task<bool> PowerOffAsync(string deviceId)
    {
        return apiClient.SendCommandAsync(deviceId, "PowerOff");
    }

    /// <summary>
    /// 风速
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Task<bool> ChangeFanSpeedAsync(string deviceId,byte value)
    {
        if(value>3)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        return apiClient.SendCommandAsync(deviceId, "F", value);
    }

    /// <summary>
    /// 模式
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Task<bool> ChangeModeAsync(string deviceId, byte value)
    {
        if (value > 4)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        return apiClient.SendCommandAsync(deviceId, "M", value);
    }
    public async Task<bool> ChangeTemperatureAsync(string deviceId, byte value)
    {
        if (value <16||value>30)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        return await apiClient.SendCommandAsync(deviceId, "T", value);
    }
}
