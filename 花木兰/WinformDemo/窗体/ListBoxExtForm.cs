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
    public partial class ListBoxExtForm : Form
    {
        public ListBoxExtForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBoxExt2.Height = 177;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBoxExt2.Height = 330;
        }
    }
}
