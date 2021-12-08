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
    public partial class RadianMenuExtComponentForm : Form
    {
        public RadianMenuExtComponentForm()
        {
            InitializeComponent();
        }

        private void radianMenuExtComponent2_ItemClick(object sender, RadianMenuComponentExt.ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.radianMenuExtComponent2.ShowLayerView();
        }

        private void radianMenuExtComponent1_ItemClick(object sender, RadianMenuComponentExt.ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }

    }
}
