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
  public partial class NavigationBarExtForm : Form
  {
    public NavigationBarExtForm()
    {
      InitializeComponent();
    }

    private void navigationBarExt2_NavigationItemClick(object sender, NavigationBarExt.ItemClickEventArgs e)
    {
      MessageBox.Show(e.Item.Text);
    }

  }
}
