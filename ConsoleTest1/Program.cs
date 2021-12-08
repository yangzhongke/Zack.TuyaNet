using Microsoft.Extensions.DependencyInjection;
using Zack.TuyaNet;
using Zack.TuyaNet.Devices;
using Zack.TuyaNet.Services;

ServiceCollection services =new ServiceCollection();
services.AddHttpClient();
services.AddOptions().Configure<TuyaConfig>(opt => {
    opt.Region = Region.China;
    opt.AccessId = Environment.GetEnvironmentVariable("Tuya:AccessId");
    opt.ApiSecret = Environment.GetEnvironmentVariable("Tuya:ApiSecret");
});
services.AddScoped<TuyaApiClient>();
services.AddScoped<SMSService>();
services.AddScoped<WeatherService>();
services.AddScoped<LocationService>();
services.AddScoped<AirConditioner>();
services.AddScoped<LedLightDevice>();
services.AddScoped<SwitchDevice>();
services.AddScoped<TempHumidSensor>();

var sp = services.BuildServiceProvider();
var api = sp.GetRequiredService<TuyaApiClient>();
await api.RefreshAccessTokenAsync();
LedLightDevice light = sp.GetRequiredService<LedLightDevice>();
LocationService locService = sp.GetRequiredService<LocationService>();
WeatherService weatherService = sp.GetRequiredService<WeatherService>();
SMSService smsService = sp.GetRequiredService<SMSService>();

string ledLightId = "36040531bcddc297f7ae";
var ledLight = sp.GetRequiredService<LedLightDevice>();
/*
await ledLight.SwitchOnAsync(ledLightId);
await ledLight.ChangeWorkModeAsync(ledLightId, "colour");
await ledLight.ChangeColorAsync(ledLightId, new HSV(30,100, 100));
await Task.Delay(5_000);
await ledLight.ChangeColorAsync(ledLightId, new HSV(60, 255, 255));
await Task.Delay(5_000);
await ledLight.ChangeColorAsync(ledLightId, new HSV(100, 255, 255));
await Task.Delay(5_000);
await ledLight.ChangeWorkModeAsync(ledLightId, "white");
await ledLight.ChangeBrightnessAsync(ledLightId, 255);*/
byte C(int v)
{
    return (byte)(v * 255.0 / 100);
}
await ledLight.SwitchOnAsync(ledLightId);
await ledLight.ChangeWorkModeAsync(ledLightId, "colour");
//https://www.baishitou.cn/webcolor/colorlist.html

await ledLight.ChangeColorAsync(ledLightId, new HSV(130, C(86), C(60)));
await Task.Delay(1_000);
await ledLight.ChangeColorAsync(ledLightId, new HSV(197, C(43), C(92)));
await Task.Delay(1_000);
await ledLight.ChangeColorAsync(ledLightId, new HSV(60, C(70), C(100)));
await Task.Delay(1_000);
await ledLight.SwitchOffAsync(ledLightId);

return;

/*
object tempParam = new { condition = "晴", tmin = 1, tmax = 10, feel = 5 };
Console.WriteLine("输入目标手机号");
string phoneNum = Console.ReadLine();
await smsService.PushMessageAsync("86", phoneNum, "SMS_2775845509", tempParam);*/
//await light.SwitchOffAsync("36040531bcddc297f7ae");
/*
var geo=await locService.AddressToGeoAsync("BeiJing");
Console.WriteLine(geo);
//var w = await weatherService.GetWeatherAsync(geo);
//Console.WriteLine(w);
var fItems = await weatherService.ForecastDailyAsync(geo);
Console.WriteLine(fItems[0]);*/
return;

string userId = "ay1638152967511vWhMa";//先硬编码吧 https://support.tuya.com/zh/help/_detail/K9g77z0z2lvf1
/*
var d = await api.GetDeviceAsync("6c79c6212ecfcb9ef5rp6a");
Console.WriteLine(d);*/
var devices = await api.ListDevicesAsync(userId);
foreach(var device in devices)
{
    Console.WriteLine(device);
    foreach(var status in device.Status)
    {
        Console.WriteLine($"状态：{status.Code}={status.Value}");
    }
    var functions = await api.ListDeviceFunctionsAsync(device.Id);
    Console.WriteLine("功能："+functions);
    Console.WriteLine("*******************");
}
string switchId= "08517034bcddc22963b7";

await api.SendCommandAsync(switchId, "switch",true);
await Task.Delay(10000);
await api.SendCommandAsync(switchId, "switch", false);



/*
string cameraId = "vdevo163825726602430";
var functions = await api.ListDeviceFunctionsAsync(cameraId);
Console.WriteLine(functions);*/
/*
string ledLightId = "36040531bcddc297f7ae";
await api.SendCommandAsync(ledLightId, "switch_led", true);
for(int i=0;i<235;i+=10)
{
    await api.SendCommandAsync(ledLightId, "temp_value", i);
    await Task.Delay(2000);
}
await api.SendCommandAsync(ledLightId, "switch_led", false);
*/
/*
string wsdcgId = "6c79c6212ecfcb9ef5rp6a";
var statusItems = await api.ListDeviceStatusAsync(wsdcgId);
while(true)
{
    foreach(var status in statusItems)
    {
        Console.WriteLine(status);    
    }
    Console.WriteLine("------------------------");
    await Task.Delay(5000);
}
*/
/*
string url = await api.GetHLSStreamUrl(userId, "vdevo163825747351421");
Console.WriteLine(url);*/