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
  public partial class GradualProgressExtForm : Form
  {
    PerformanceCounter pcCpuLoad = null;
    public GradualProgressExtForm()
    {
      InitializeComponent();
    }

    private void Form3_Load(object sender, EventArgs e)
    {
      pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
      pcCpuLoad.MachineName = ".";
      pcCpuLoad.NextValue();
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      float value = (float)Math.Round(pcCpuLoad.NextValue());
      progressExt1.Value = value / 100 + 0.56f;
      progressExt2.Value = value / 100 + 0.56f;
      progressExt3.Value = value / 100 + 0.56f;
      progressExt4.Value = value / 100 + 0.56f;
      progressExt5.Value = value / 100 + 0.36f;
      progressExt6.Value = value / 100 + 0.36f;
      this.Text = value.ToString() + "%";
    }
  }
}
