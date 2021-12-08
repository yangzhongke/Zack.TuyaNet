using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class FormLedLightSettings : Form
    {
        public TimeSpan WakeUpTime
        {
            get
            {
                return timePickerWakeUp.Value.TimeOfDay;
            }
            set
            {
                timePickerWakeUp.Value = DateTime.Today.Add(value);
            }
        }

        public TimeSpan SleepTime
        {
            get
            {
                return timePickerSleep.Value.TimeOfDay;
            }
            set
            {
                timePickerSleep.Value = DateTime.Today.Add(value);
            }
        }

        public FormLedLightSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
