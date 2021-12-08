using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Zack.TuyaNet;
using Zack.TuyaNet.Devices;
using Zack.TuyaNet.Services;

namespace SmartHomeUI
{
    static class ServiceLocator
    {
        private static IServiceProvider serviceProvider;
        public static async Task LoadAsync()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddHttpClient();
            services.AddOptions().Configure<TuyaConfig>(opt => {
                opt.Region = Region.China;
                opt.AccessId = Environment.GetEnvironmentVariable("Tuya:AccessId");
                opt.ApiSecret = Environment.GetEnvironmentVariable("Tuya:ApiSecret");
            });
            services.AddSingleton<HolidayService>();
            services.AddScoped<WeatherService>();
            services.AddScoped<LocationService>();
            services.AddScoped<TuyaApiClient>();
            services.AddScoped<TempHumidSensor>();
            services.AddScoped<AirConditioner>();
            services.AddScoped<LedLightDevice>();
            services.AddScoped<SwitchDevice>();
            serviceProvider = services.BuildServiceProvider();
            
            var holidayService = GetRequiredService<HolidayService>();
            await holidayService.LoadAsync(2021);
            await holidayService.LoadAsync(2022);
        }
        public static T GetRequiredService<T>()
        {
            return serviceProvider.GetRequiredService<T>();
        }
    }
}
