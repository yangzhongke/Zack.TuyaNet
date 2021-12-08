using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class StatusStripExtForm : FormExt
    {
        public StatusStripExtForm()
        {
            InitializeComponent();
        }

        private void StatusStripExtForm_Load(object sender, EventArgs e)
        {
            Assembly[] assembly2 = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly item in assembly2)
            {
                if (item.ManifestModule.Name == "WcleAnimationLibrary.dll")
                {
                    this.toolStripStatusLabel1.Text = "动画版本："+ item.GetName().Version.ToString();
                }
                else if (item.ManifestModule.Name == "WinformControlLibraryExtension.dll")
                {
                    this.toolStripStatusLabel2.Text = "控件版本：" + item.GetName().Version.ToString();
                }
                else if (item.ManifestModule.Name == "WinformDemo.exe")
                {
                    this.toolStripStatusLabel3.Text = "Demo版本：" + item.GetName().Version.ToString();
                }
            }
        }

    }
}
