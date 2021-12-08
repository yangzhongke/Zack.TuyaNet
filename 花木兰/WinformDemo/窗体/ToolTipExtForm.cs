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
    public partial class ToolTipExtForm : Form
    {
        public ToolTipExtForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.上下左右.Show("ToolTip提示美化扩展", this.button1, Rectangle.Empty, ToolTipExt.ToolTipAnchor.TopCenter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.上下左右.Show("ToolTip提示美化扩展", this.button2, Rectangle.Empty, ToolTipExt.ToolTipAnchor.BottomCenter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.上下左右.Show("ToolTip提示美化扩展", this.button3, Rectangle.Empty, ToolTipExt.ToolTipAnchor.LeftCenter);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.上下左右.Show("ToolTip提示美化扩展", this.button4, Rectangle.Empty, ToolTipExt.ToolTipAnchor.RightCenter);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.上下左右.Hide(this);
        }
    }
}
