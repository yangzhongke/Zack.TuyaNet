using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class FormSwitchSettings : Form
    {
        public FormSwitchSettings()
        {
            InitializeComponent();
        }

        public TimeSpan WorkingDayOnTime
        {
            get
            {
                return timePickerWorkingDayBegin.Value.TimeOfDay;
            }
            set
            {
                timePickerWorkingDayBegin.Value = DateTime.Today.Add(value);
            }
        }

        public TimeSpan OffDayOnTime
        {
            get
            {
                return timePickerOffDayBegin.Value.TimeOfDay;
            }
            set
            {
                timePickerOffDayBegin.Value = DateTime.Today.Add(value);
            }
        }

        public uint Duration
        {
            get
            {
                return (uint)numDuration.Value;
            }
            set
            {
                numDuration.Value = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult =DialogResult.Cancel;
        }
    }
}
