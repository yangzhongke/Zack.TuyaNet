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
    public partial class ValidCodeExtForm : Form
    {
        public ValidCodeExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validCodeExt1.ResetCode();
            validCodeExt2.ResetCode();
            validCodeExt3.ResetCode();
        }

        private void ValidCodeExtForm_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == validCodeExt2.ValidCode)
            {
                label1.Text = "成功";
            }
            else
            {
                label1.Text = "失败";
            }
        }
    }
}
