using Microsoft.Extensions.DependencyInjection;
using Zack.TuyaNet;
using Zack.TuyaNet.Devices;
using Zack.TuyaNet.Services;

ServiceCollection services = new ServiceCollection();
services.AddHttpClient();
services.AddOptions().Configure<TuyaConfig>(opt => {
    opt.Region = Region.China;
    opt.AccessId = "xxxxxxxxxxxxxxxxxxxxxxxx";
    opt.ApiSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxx";
});
services.AddScoped<TuyaApiClient>();
services.AddScoped<SwitchDevice>();
services.AddScoped<TempHumidSensor>();
services.AddScoped<LedLightDevice>();
services.AddScoped<LocationService>();
services.AddScoped<WeatherService>();
services.AddScoped<SMSService>();

var sp = services.BuildServiceProvider();
TuyaApiClient apiClient = sp.GetRequiredService<TuyaApiClient>();
await apiClient.RefreshAccessTokenAsync();//必不可少
/*
SwitchDevice switchDevice = sp.GetRequiredService<SwitchDevice>();
await switchDevice.SwitchOffAsync("08517034bcddc22963b7");*/
/*
TempHumidSensor thSensor = sp.GetRequiredService<TempHumidSensor>();
(double temp,double humid) = await thSensor.GetStatusAsync("6c79c6212ecfcb9ef5rp6a");
Console.WriteLine($"{temp}   {humid}");

LedLightDevice light = sp.GetRequiredService<LedLightDevice>();*/
LocationService locService = sp.GetRequiredService<LocationService>();
WeatherService wService = sp.GetRequiredService<WeatherService>();
SMSService smsService = sp.GetRequiredService<SMSService>();
Geo geo = await locService.AddressToGeoAsync("HangZhou");
Console.WriteLine($"{geo.Latitude}  {geo.Longitude}");
WeatherForecastInfo[] items = await wService.ForecastDailyAsync(geo);
foreach(var item in items)
{
    Console.WriteLine(item);
}

await smsService.PushMessageAsync("86", "18918918189", "SMS_2682863019", new { Username = "杨中科", code="8848"});