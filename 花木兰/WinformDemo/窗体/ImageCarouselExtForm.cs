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
    public partial class ImageCarouselExtForm : Form
    {
        public ImageCarouselExtForm()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.imageCarouselExt1.Play();
            this.imageCarouselExt2.Play();
            this.imageCarouselExt3.Play();
            this.imageCarouselExt4.Play();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
