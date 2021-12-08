using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinformDemo
{
  public partial class ChartExtForm : Form
  {
    PerformanceCounter pcCpuLoad = null;

    public ChartExtForm()
    {
      InitializeComponent();
      pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
      pcCpuLoad.MachineName = ".";
      pcCpuLoad.NextValue();

      this.timer1.Interval = 500;
      this.timer1.Tick += new EventHandler(time_Tick);
      this.timer1.Enabled = true;
    }

    private void time_Tick(object sender, EventArgs e)
    {
      Random rd = new Random();
      float i = (float)rd.Next(0, 6);
      float value = (float)Math.Round(pcCpuLoad.NextValue());
      this.chartExt1.AddPathPoint(value / 100 + i / 10);
      this.chartExt2.AddPathPoint(value / 100 + i / 10);
    }

  }
}
