using SmartHomeUI.Properties;
using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class UIKitchen : UserControl
    {
        public UIKitchen()
        {
            InitializeComponent();
        }

        private void pictureGoHome_Click(object sender, EventArgs e)
        {
            ((FormMain)this.ParentForm).GoHome();
        }

        private void picCooker_Click(object sender, EventArgs e)
        {
            var settings = Settings.Default;
            using FormSwitchSettings form = new FormSwitchSettings();
            form.WorkingDayOnTime = settings.工作日开锅时间;
            form.OffDayOnTime = settings.节假日开锅时间;
            form.Duration = settings.锅工作分钟数;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            settings.工作日开锅时间=form.WorkingDayOnTime;
            settings.节假日开锅时间=form.OffDayOnTime;
            settings.锅工作分钟数=form.Duration;
            settings.Save();
        }
    }
}
