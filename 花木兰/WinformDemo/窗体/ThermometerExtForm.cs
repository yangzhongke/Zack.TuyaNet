using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class ThermometerExtForm : Form
    {
        public ThermometerExtForm()
        {
            InitializeComponent();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            this.thermometerExt1.Value = rd.Next(-20, 100);
            this.thermometerExt2.Value = rd.Next(-20, 100);
            this.thermometerExt3.Value = rd.Next(-20, 100);
            this.thermometerExt4.Value = rd.Next(-20, 100);
            this.thermometerExt5.Value = rd.Next(-20, 100);
        }

        private void thermometerExt_ValueChanged(object sender, ThermometerExt.ValueChangedEventArgs e)
        {
            ((ThermometerExt)sender).Text = "当前温度" + e.Value + "C";
        }

    }
}
