using SmartHomeUI.Properties;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zack.TuyaNet;
using Zack.TuyaNet.Devices;
using Zack.TuyaNet.Services;

namespace SmartHomeUI
{
    public partial class FormMain : Form
    {
        private readonly UIMain uiMain = new UIMain();
        private readonly UIBedRoom uiBedRoom = new UIBedRoom();
        private readonly UIGirlBedRoom uiGirl = new UIGirlBedRoom();
        private readonly UIKitchen uiKitchen = new UIKitchen();
        private readonly UIBathRoom uiBathRoom = new UIBathRoom();
        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            LoadUI(uiMain);
            uiMain.OnMemuItemClick += UiMain_OnMemuItemClick;
            await RefreshApiTokenAsync();
            await TimerUpdateAsync();//立即触发一次
        }

        private void UiMain_OnMemuItemClick(string text)
        {
            if(text=="主卧")
            {
                LoadUI(uiBedRoom);
            }
            else if (text == "女儿卧室")
            {
                LoadUI(uiGirl);
            }
            else if (text == "厨房")
            {
                LoadUI(uiKitchen);
            }
            else if (text == "浴室")
            {
                LoadUI(uiBathRoom);
            }
        }

        void LoadUI(UserControl ui)
        {
            ui.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(ui);
        }

        public void GoHome()
        {
            LoadUI(uiMain);
            
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            BringToFront();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason== CloseReason.UserClosing
                &&!Debugger.IsAttached)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void miShowForm_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            await TimerUpdateAsync();
        }

        private async Task TimerUpdateAsync()
        {
            await uiBedRoom.TimerUpdateAsync();
            var settings = Settings.Default;
            var holidayService = ServiceLocator.GetRequiredService<HolidayService>();
            bool isOffDay = holidayService.IsTodayOffDay();
            var tempHumidSensor = ServiceLocator.GetRequiredService<TempHumidSensor>();
            var airConditioner = ServiceLocator.GetRequiredService<AirConditioner>();
            var ledLight = ServiceLocator.GetRequiredService<LedLightDevice>();
            var switchDevice = ServiceLocator.GetRequiredService<SwitchDevice>();
            //根据节假日来设定不同时间在早晨自动开启锅做饭
            await ProcessCooker(settings, isOffDay, switchDevice);

            //根据节假日来设定不同时间在晚上自动开启热水器
            await ProcessWaterHeater(settings, isOffDay, switchDevice);

            //早晨灯光开灯，然后慢慢变亮，叫醒女儿
            //无论是否工作日，都同样时间开灯关灯。养成规律的作息规律
            await ProcessGirlWakeUp(settings, ledLight);

            //晚上灯光关灯
            await ProcessGirlSleep(settings, ledLight);

            //根据天气预报自动给父母发提醒短信。
            await ProcessWeather(settings);
        }

        private async Task ProcessWeather(Settings settings)
        {
            if (!settings.给父母发短信时间.IsNow())
            {
                return;
            }
            string phoneNum = settings.父母手机号;
            var weatherService = ServiceLocator.GetRequiredService<WeatherService>();
            var locService = ServiceLocator.GetRequiredService<LocationService>();

            var smsService = ServiceLocator.GetRequiredService<SMSService>();
            var geo = await locService.AddressToGeoAsync("BeiJing");
            var items = await weatherService.ForecastDailyAsync(geo);
            var forecast = items[0];
            string feel = $"{forecast.ApparentTemperatureMin}-{forecast.ApparentTemperatureMax}度";
            object tempParam = new { condition = forecast.Condition, 
                tmin = forecast.TemperatureMin, tmax = forecast.TemperatureMax, feel};
            await smsService.PushMessageAsync("86", phoneNum, "SMS_2775845509", tempParam);
        }

        private static async Task ProcessGirlWakeUp(Settings settings, LedLightDevice ledLight)
        {
            string deviceId = DeviceIds.LedLightId;
            if (settings.女儿起床时间.IsNow())
            {
                await ledLight.SwitchOnAsync(deviceId);
                await ledLight.ChangeWorkModeAsync(deviceId, "colour");
                await ledLight.ChangeColorAsync(deviceId, new HSV(30, 100, 100));
            }
            if (settings.女儿起床时间.Add(TimeSpan.FromMinutes(1)).IsNow())
            {
                await ledLight.ChangeColorAsync(deviceId, new HSV(60, 255, 255));
            }
            if (settings.女儿起床时间.Add(TimeSpan.FromMinutes(2)).IsNow())
            {
                await ledLight.ChangeColorAsync(deviceId, new HSV(100, 255, 255));
            }
            if (settings.女儿起床时间.Add(TimeSpan.FromMinutes(3)).IsNow())
            {
                await ledLight.ChangeWorkModeAsync(deviceId, "white");
                await ledLight.ChangeBrightnessAsync(deviceId, 255);
            }
        }

        private static async Task ProcessGirlSleep(Settings settings, LedLightDevice ledLight)
        {
            byte C(int v)
            {
                return (byte)(v * 255.0 / 100);
            }
            string deviceId = DeviceIds.LedLightId;
            if (settings.女儿睡觉时间.IsNow())
            {
                await ledLight.SwitchOnAsync(deviceId);
                await ledLight.ChangeWorkModeAsync(deviceId, "colour");
            }
            if (settings.女儿睡觉时间.Add(TimeSpan.FromMinutes(1)).IsNow())
            {
                await ledLight.ChangeColorAsync(deviceId, new HSV(60, C(70), C(100)));

            }
            if (settings.女儿睡觉时间.Add(TimeSpan.FromMinutes(2)).IsNow())
            {
                await ledLight.ChangeColorAsync(deviceId, new HSV(130, C(86), C(60)));
            }
            if (settings.女儿睡觉时间.Add(TimeSpan.FromMinutes(3)).IsNow())
            {
                await ledLight.SwitchOffAsync(deviceId);
            }
        }

        private static async Task ProcessWaterHeater(Settings settings, bool isOffDay, SwitchDevice switchDevice)
        {
            string deviceId = DeviceIds.SwitchWaterHeaterId;
            if (isOffDay)
            {
                if (settings.节假日开热水器时间.IsNow())
                {
                    await switchDevice.SwitchOnAsync(deviceId);
                }
                TimeSpan 节假日关热水器时间 = settings.节假日开热水器时间.Add(TimeSpan.FromMinutes(settings.热水器工作分钟数));
                if (节假日关热水器时间.IsNow())
                {
                    await switchDevice.SwitchOffAsync(deviceId);
                }
            }
            else
            {
                if (settings.工作日开热水器时间.IsNow())
                {
                    await switchDevice.SwitchOnAsync(deviceId);
                }
                TimeSpan 工作日关热水器时间 = settings.工作日开热水器时间.Add(TimeSpan.FromMinutes(settings.热水器工作分钟数));
                if (工作日关热水器时间.IsNow())
                {
                    await switchDevice.SwitchOffAsync(deviceId);
                }
            }
        }

        private static async Task ProcessCooker(Settings settings, bool isOffDay, SwitchDevice switchDevice)
        {
            string deviceId = DeviceIds.SwitchCookerId;
            if (isOffDay)
            {
                if (settings.节假日开锅时间.IsNow())
                {
                    await switchDevice.SwitchOnAsync(deviceId);
                }
                TimeSpan 节假日关锅时间 = settings.节假日开锅时间.Add(TimeSpan.FromMinutes(settings.锅工作分钟数));
                if (节假日关锅时间.IsNow())
                {
                    await switchDevice.SwitchOffAsync(deviceId);
                }
            }
            else
            {
                if (settings.工作日开锅时间.IsNow())
                {
                    await switchDevice.SwitchOnAsync(deviceId);
                }
                TimeSpan 工作日关锅时间 = settings.工作日开锅时间.Add(TimeSpan.FromMinutes(settings.锅工作分钟数));
                if (工作日关锅时间.IsNow())
                {
                    await switchDevice.SwitchOffAsync(deviceId);
                }
            }
        }

        private Task RefreshApiTokenAsync()
        {
            TuyaApiClient apiClient = ServiceLocator.GetRequiredService<TuyaApiClient>();
            return apiClient.RefreshAccessTokenAsync();
        }

        private async void timerTokenRefresh_Tick(object sender, EventArgs e)
        {
            await RefreshApiTokenAsync();
        }
    }
}
