using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;
using System.Diagnostics;

namespace WinformDemo
{
    public partial class TimerExtForm : Form
    {
        int color = 0;
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush blue = new SolidBrush(Color.Blue);

        private int count = 0;
        private Stopwatch sw = new Stopwatch();

        public TimerExtForm()
        {
            InitializeComponent();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            color = (color == 0) ? 1 : 0;
            e.Graphics.FillRectangle(color == 0 ? red : blue, e.ClipRectangle);
        }

        private void timerExt1_Tick(object sender, EventArgs e)
        {
            uint countsum = (uint)this.numericUpDown1.Value;
            this.count++;
          
            if (count == countsum)
            {
                sw.Stop();
                this.timerExt1.Enabled = false;
                this.Invoke(
                    new Action(delegate { this.label3.Text = String.Format("预计耗时：{0}毫秒/实际耗时：{1}毫秒", (this.numericUpDown1.Value * this.numericUpDown2.Value).ToString("N0"), sw.ElapsedMilliseconds.ToString("N0")); })
                    );
            }
            this.label1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint interval = (uint)this.numericUpDown2.Value;
            if (interval < this.timerExt1.Timecaps.wPeriodMin || interval > this.timerExt1.Timecaps.wPeriodMax)
                return;

            this.count = 0;
            this.label3.Text = "---";
            this.timerExt1.Interval = interval;
            sw.Restart();
            this.timerExt1.Enabled = true;
        }

    }
}
