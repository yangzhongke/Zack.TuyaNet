using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WinformDemo
{
  public partial class PercentageProgressExtForm : Form
  {
    public PercentageProgressExtForm()
    {
      InitializeComponent();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Random rd = new Random();
      this.percentageBarExt1.Value = (float)(32 + rd.Next(1, 9)) / 100;
      this.percentageBarExt4.Value = (float)(30 + rd.Next(1, 9)) / 100;
      this.percentageBarExt10.Value = (float)(37 + rd.Next(1, 9)) / 100;
      this.percentageBarExt2.Value = (float)(35 + rd.Next(1, 9)) / 100;
      this.percentageBarExt5.Value = (float)(40 + rd.Next(1, 9)) / 100;
      this.percentageBarExt6.Value = (float)(34 + rd.Next(1, 9)) / 100;
      this.percentageBarExt3.Value = (float)(38 + rd.Next(1, 9)) / 100;
      this.percentageBarExt9.Value = (float)(36 + rd.Next(1, 9)) / 100;
      this.percentageBarExt7.Value = (float)(74 + rd.Next(1, 9)) / 100;
      this.percentageBarExt8.Value = (float)(34 + rd.Next(1, 9)) / 100;
    }

  }
}
