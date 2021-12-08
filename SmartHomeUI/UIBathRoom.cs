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
    public partial class UIBathRoom : UserControl
    {
        public UIBathRoom()
        {
            InitializeComponent();
        }

        private void pictureGoHome_Click(object sender, EventArgs e)
        {
            ((FormMain)this.ParentForm).GoHome();
        }

        private void picHeater_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            using FormSwitchSettings form = new FormSwitchSettings();
            form.WorkingDayOnTime = settings.工作日开热水器时间;
            form.OffDayOnTime = settings.节假日开热水器时间;
            form.Duration = settings.热水器工作分钟数;
            if (form.ShowDialog(this)!=DialogResult.OK)
            {
                return;
            }            
            settings.工作日开热水器时间 = form.WorkingDayOnTime;
            settings.节假日开热水器时间 = form.OffDayOnTime;
            settings.热水器工作分钟数 = form.Duration;
            settings.Save();
        }
    }
}
