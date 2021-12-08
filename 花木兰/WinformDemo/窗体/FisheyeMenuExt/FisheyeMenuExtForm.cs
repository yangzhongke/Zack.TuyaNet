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
    public partial class FisheyeMenuExtForm : Form
    {
        public FisheyeMenuExtForm()
        {
            InitializeComponent();
        }

        private void fisheyeBarExt2_ItemClick(object sender, FisheyeMenuExt.ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    this.fisheyeBarExt2.ShowView(this);
        }

    }
}
