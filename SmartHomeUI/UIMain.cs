using System;
using System.Windows.Forms;

namespace SmartHomeUI
{
    public partial class UIMain : UserControl
    {
        public event Action<string> OnMemuItemClick;

        public UIMain()
        {
            InitializeComponent();
        }

        private void fisheyeMenu_ItemClick(object sender, WinformControlLibraryExtension.FisheyeMenuExt.ItemClickEventArgs e)
        {
            if(OnMemuItemClick != null)
            {
                OnMemuItemClick(e.Item.Text);
            }
        }
    }
}
