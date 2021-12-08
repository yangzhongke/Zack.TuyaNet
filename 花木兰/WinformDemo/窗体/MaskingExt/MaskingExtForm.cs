using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class MaskingExtForm : Form
    {
        int num = 0;

        public MaskingExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaskingExt.Show(this, new MaskingExt.MaskingSettings() { TextOrientation = MaskingExt.MaskingTextOrientations.Right });

            num = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num += timer1.Interval;
            if (num > 5000)
            {
                MaskingExt.Hide(this);

                timer1.Enabled = false;
            }
        }
    }
}
