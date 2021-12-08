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
    public partial class TextCarouselExtForm : Form
    {
        public TextCarouselExtForm()
        {
            InitializeComponent();
        }

        private void TextCarouselExtForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.textCarouselExt1.Play();
                this.textCarouselExt2.Play();
                this.textCarouselExt3.Play();
                this.textCarouselExt4.Play(0);
                this.textCarouselExt5.Play();
                this.textCarouselExt6.Play();
                this.textCarouselExt7.Play();
                this.textCarouselExt8.Play();
                this.textCarouselExt9.Play();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
