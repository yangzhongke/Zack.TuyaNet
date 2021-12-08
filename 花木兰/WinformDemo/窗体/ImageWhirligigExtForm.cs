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
    public partial class ImageWhirligigExtForm : Form
    {
        public ImageWhirligigExtForm()
        {
            InitializeComponent();
        }

        private void ImageWhirligigExtForm_Load(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.Play(0);
        }

        private void ImageWhirligigExtForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.ReflectionShow = !this.imageWhirligigExt1.ReflectionShow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.ImageFrameCount = (this.imageWhirligigExt1.ImageFrameCount == 5) ? 3 : 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.imageWhirligigExt1.Orientation = (this.imageWhirligigExt1.Orientation == ImageWhirligigExt.Orientations.RightToLeft) ? ImageWhirligigExt.Orientations.LeftToRight : ImageWhirligigExt.Orientations.RightToLeft;
        }

    }
}
