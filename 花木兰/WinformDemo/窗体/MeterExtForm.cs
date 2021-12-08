using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class MeterExtForm : Form
    {
        List<int> intlist5 = new List<int>() { 30, 35, 60, 45, 30, 80, 85, 70 };
        List<int> intlist6 = new List<int>() { 60, 30, 35, 80, 45, 30, 70, 85 };
        List<int> intlist3 = new List<int>() { 50, 40, 35, 70, 65, 30, 90, 75 };
        List<int> intlist4 = new List<int>() { 20, 50, 45, 60, 45, 80, 90, 65 };

        List<int> intlist1 = new List<int>() { 20, 50, 45, 60, 45, 80, 90, 65 };
        List<int> intlist2 = new List<int>() { 50, 40, 35, 70, 65, 30, 90, 75 };
        List<int> intlist7 = new List<int>() { 60, 30, 35, 80, 45, 30, 70, 85 };
        List<int> intlist8 = new List<int>() { 30, 35, 60, 45, 30, 80, 85, 70 };
        int index = 0;

        public MeterExtForm()
        {
            InitializeComponent();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;
            if (index >= intlist5.Count)
            {
                index = 0;
            }
            this.meterBarExt5.Value = intlist5[index];
            this.meterBarExt6.Value = intlist6[index];
            this.meterBarExt4.Value = intlist4[index];
            this.meterBarExt3.Value = intlist3[index];

            this.meterBarExt1.Value = intlist1[index];
            this.meterBarExt2.Value = intlist2[index];
            this.meterBarExt7.Value = intlist7[index];
            this.meterBarExt8.Value = intlist8[index];
        }

    }
}
