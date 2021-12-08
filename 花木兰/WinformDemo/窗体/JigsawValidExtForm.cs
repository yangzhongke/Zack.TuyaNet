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
    public partial class JigsawValidExtForm : Form
    {
        public JigsawValidExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "---";
            this.slideValidExt1.SlideType = WinformControlLibraryExtension.JigsawValidExt.SlideTypes.One;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.label1.Text = "---";
            this.slideValidExt1.SlideType = WinformControlLibraryExtension.JigsawValidExt.SlideTypes.Two;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.label1.Text = "---";
            this.slideValidExt1.SlideType = WinformControlLibraryExtension.JigsawValidExt.SlideTypes.Three;
        }

        private void slideValidExt1_ValidChanged(object sender, WinformControlLibraryExtension.JigsawValidExt.ValidedEventArgs e)
        {
            this.label1.Text = e.Pass.ToString();

            this.label1.Text = e.Pass ? "通过" : "错误";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.label1.Text = "---";
            this.slideValidExt1.ResetJigsaw();
        }
    }
}
