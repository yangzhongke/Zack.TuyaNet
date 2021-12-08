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
    public partial class FisheyeMenuExtComponentForm : Form
    {
        public FisheyeMenuExtComponentForm()
        {
            InitializeComponent();
        }

        private void 桌面_ItemClick(object sender, FisheyeMenuHandleExt.ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Text);
        }

        private void 窗体_ItemClick(object sender, FisheyeMenuHandleExt.ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Char);
        }

        private void 窗体_IndexChanged(object sender, FisheyeMenuHandleExt.IndexChangedEventArgs e)
        {
            this.label1.Text = e.Item.Char;
        }

        private void 窗体_Selected(object sender, FisheyeMenuHandleExt.SelectedEventArgs e)
        {
            this.label2.Text = e.Item.Char;
        }


    }
}
