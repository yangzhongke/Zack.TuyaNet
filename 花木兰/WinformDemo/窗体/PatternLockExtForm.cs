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
    public partial class PatternLockExtForm : Form
    {
        public PatternLockExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "---";
            this.patternLockExt1.UnLockReset();
        }

        private void patternLockExt1_UnLock(object sender, PatternLockExt.UnLockEventArgs e)
        {
            this.label1.Text = e.Value.ToString();
            this.patternLockExt2.Value = e.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label2.Text = "---";
            this.patternLockExt2.UnLockReset();
        }

        private void patternLockExt2_UnLock(object sender, PatternLockExt.UnLockEventArgs e)
        {
            this.label2.Text = e.Result.ToString();
        }


    }
}
