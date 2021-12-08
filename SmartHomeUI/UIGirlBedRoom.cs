using SmartHomeUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class UIGirlBedRoom : UserControl
    {
        public UIGirlBedRoom()
        {
            InitializeComponent();
        }

        private void pictureGoHome_Click(object sender, EventArgs e)
        {
            ((FormMain)this.ParentForm).GoHome();
        }

        private void picLight_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            using var form = new FormLedLightSettings();
            form.WakeUpTime = settings.女儿起床时间;
            form.SleepTime = settings.女儿睡觉时间;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            settings.女儿起床时间=form.WakeUpTime;
            settings.女儿睡觉时间=form.SleepTime;
            settings.Save();
        }
    }
}
