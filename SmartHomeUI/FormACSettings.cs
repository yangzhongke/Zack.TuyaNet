using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class FormACSettings : Form
    {
        public uint OnTemperature 
        {
            get 
            {
                return (uint)this.numOnTemp.Value;
            }
            set
            {
                this.numOnTemp.Value = value;
            }
        }

        public uint OffTemperature
        {
            get
            {
                return (uint)this.numOffTemp.Value;
            }
            set
            {
                this.numOffTemp.Value = value;
            }
        }

        public FormACSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(numOffTemp.Value>=numOnTemp.Value)
            {
                MessageBox.Show(this,"关闭温度要低于开启温度");
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
