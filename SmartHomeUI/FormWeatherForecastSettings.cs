using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class FormWeatherForecastSettings : Form
    {
        public string PhoneNumber
        {
            get
            {
                return txtPhoneNumber.Text;
            }
            set
            {
                txtPhoneNumber.Text = value;
            }
        }

        public TimeSpan SendTime
        {
            get
            {
                return timerPickerSendTime.Value.TimeOfDay;
            }
            set
            {
                timerPickerSendTime.Value = DateTime.Today.Add(value);
            }
        }

        public FormWeatherForecastSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; 
        }
    }
}
