namespace Zack.TuyaNet.Devices;
/// <summary>
/// 温湿度传感器
/// </summary>
public class TempHumidSensor
{
    private TuyaApiClient apiClient;

    public TempHumidSensor(TuyaApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<(double Temperature, double Humidity)> GetStatusAsync(string deviceId)
    {
        var items = await apiClient.ListDeviceStatusAsync(deviceId);
        double temp = items.Single(s => s.Code == "va_temperature").GetValue<double>();
        double humid = items.Single(s => s.Code == "va_humidity").GetValue<double>();
        return (temp / 100.0, humid / 100.0);
    }
}