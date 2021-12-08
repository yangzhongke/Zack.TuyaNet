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
    public partial class MessageBoxExtForm : FormExt
    {
        public MessageBoxExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"OK", "提示", MessageBoxExtButtons.OK);
            this.label2.Text = da.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"OKCancel", "提示", MessageBoxExtButtons.OKCancel, MessageBoxExtIcon.Error);
            this.label2.Text = da.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"YesNo", "提示", MessageBoxExtButtons.YesNo, MessageBoxExtIcon.Question);
            this.label2.Text = da.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"YesNoCancel", "提示", MessageBoxExtButtons.YesNoCancel, MessageBoxExtIcon.Warning, MessageBoxExtDefaultButton.Button3);
            this.label2.Text = da.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBoxExt.Show(this, @"RetryCancel", "提示", MessageBoxExtButtons.RetryCancel, MessageBoxExtIcon.Custom, MessageBoxExtDefaultButton.Button2, null, global::WinformDemo.Properties.Resources.message_custom);
            this.label2.Text = da.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxExtStyles style = new MessageBoxExtStyles()
            {
                BorderColor = Color.SteelBlue,
                ButtonBackColor = Color.LightSkyBlue,
                ButtonBackEnterColor = Color.SteelBlue,
                CaptionBackColor = Color.LightSkyBlue
            };
            DialogResult da = MessageBoxExt.Show(this, @"AbortRetryIgnore", "提示", MessageBoxExtButtons.AbortRetryIgnore, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, style);
            this.label2.Text = da.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBoxExtStyles style = new MessageBoxExtStyles()
            {
                BorderColor = Color.SteelBlue,
                ButtonBackColor = Color.LightSkyBlue,
                ButtonBackEnterColor = Color.SteelBlue,
                CaptionBackColor = Color.LightSkyBlue,
                Button1Text = "同意",
                Button2Text = "不同意"
            };
            DialogResult da = MessageBoxExt.Show(this, @"同意不同意", "提示", MessageBoxExtButtons.YesNo, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, style);
            this.label2.Text = da.ToString();
        }
    }
}
