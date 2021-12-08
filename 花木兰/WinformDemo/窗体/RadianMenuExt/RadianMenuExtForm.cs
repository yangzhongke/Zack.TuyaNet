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
    public partial class RadianMenuExtForm : Form
    {
        public RadianMenuExtForm()
        {
            InitializeComponent();

        }

        private void radianMenuExt1_RadianMenuItemClick(object sender, RadianMenuExt.ItemClickEventArgs e)
        {

            MessageBox.Show(e.Item.Text);
        }

        private void RadianMenuExtForm_Load(object sender, EventArgs e)
        {
            this.radianMenuExt2.RadianIsRotate = true;
        }

    }
}
