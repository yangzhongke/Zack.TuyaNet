using SmartHomeUI.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zack.TuyaNet.Devices;

namespace SmartHomeUI
{
    public partial class UIBedRoom : UserControl
    {
        public UIBedRoom()
        {
            InitializeComponent();
        }

        private void pictureGoHome_Click(object sender, EventArgs e)
        {
            ((FormMain)this.ParentForm).GoHome();
        }

        private void picAirConditioner_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            using FormACSettings form = new FormACSettings();
            form.OnTemperature = settings.开启空调的温度;
            form.OffTemperature = settings.关闭空调的温度;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            if(settings.开启空调的温度<=settings.关闭空调的温度)
            {
                MessageBox.Show("开启空调的温度 必须 大于 关闭空调的温度");
                return;
            }
            settings.开启空调的温度 = form.OnTemperature;
            settings.关闭空调的温度=form.OffTemperature;
            settings.Save();
        }

        public async Task TimerUpdateAsync()
        {
            var thSensor = ServiceLocator.GetRequiredService<TempHumidSensor>();
            (double temp, double humid) = await thSensor.GetStatusAsync(DeviceIds.TempHumidId);
            thermometer.Value = (float)temp;
            hygrometer.Value = (float)(humid / 100.0);

            //根据节假日和温度传感器自动启停家里的空调以及设定温度
            var ac = ServiceLocator.GetRequiredService<AirConditioner>();
            var settings = Settings.Default;
            if(temp>= settings.开启空调的温度)
            {
                await ac.PowerOnAsync(DeviceIds.ACId);
                
                await ac.ChangeTemperatureAsync(DeviceIds.ACId, 26);
            }
            if(temp<=settings.关闭空调的温度)
            {
                await ac.PowerOffAsync(DeviceIds.ACId);
            }
        }

        private void picParent_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            using var form = new FormWeatherForecastSettings();
            form.PhoneNumber = settings.父母手机号;
            form.SendTime = settings.给父母发短信时间;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            settings.父母手机号=form.PhoneNumber;
            settings.给父母发短信时间=form.SendTime;
            settings.Save();
        }
    }
}
