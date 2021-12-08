using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class SlideMenuPanelExtForm : Form
    {
        public SlideMenuPanelExtForm()
        {
            InitializeComponent();
        }

        private void MenuExtForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox1.SelectedItem = "MenuPanelExt1";

            this.Bind(this.menuPanelExt1);

            this.menuPanelExt2.DrawNode += MenuPanelExt2_DrawNode;
            this.menuPanelExt2.NodeClick += MenuPanelExt2_NodeClick;
            this.Bind(this.menuPanelExt2);

            this.menuPanelExt3.Drag.Draging += Drag_Draging;
            this.Bind(this.menuPanelExt3);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedItem.ToString())
            {
                case "MenuPanelExt1":
                    {
                        this.propertyGrid1.SelectedObject = menuPanelExt1;
                        break;
                    }
                case "MenuPanelExt2":
                    {
                        this.propertyGrid1.SelectedObject = menuPanelExt2;
                        break;
                    }
                case "MenuPanelExt3":
                    {
                        this.propertyGrid1.SelectedObject = menuPanelExt3;
                        break;
                    }
            }
        }

        private void MenuPanelExt2_NodeClick(object sender, SlideMenuPanelExt.NodeClickEventArgs e)
        {
            if (e.Node.Data != null)
            {
                e.Node.Data = null;
                menuPanelExt1.Invalidate();
            }
        }

        private void MenuPanelExt2_DrawNode(object sender, SlideMenuPanelExt.DrawNodeEventArgs e)
        {
            if (e.Node.Data != null)
            {
                SolidBrush back_sb = new SolidBrush(Color.LightCoral);
                SolidBrush text_sb = new SolidBrush(Color.White);
                SizeF size = e.g.MeasureString(e.Node.Data.ToString(), this.Font);
                SmoothingMode sm = e.g.SmoothingMode;
                e.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.g.FillEllipse(back_sb, new RectangleF(e.TextRect.Right, e.Node.Rect.Y + (e.Node.Rect.Height - size.Height) / 2, size.Height, size.Height));
                e.g.DrawString(e.Node.Data.ToString(), this.Font, text_sb, new RectangleF(e.TextRect.Right + (size.Height - size.Width) / 2, e.TextRect.Y, size.Width, size.Height));
                e.g.SmoothingMode = sm;
            }
        }

        private void Drag_Draging(object sender, SlideMenuPanelExt.DragingEventArgs e)
        {
            this.menuPanelExt3.Width += e.X;
        }

        private void Bind(SlideMenuPanelExt menuPanel)
        {
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem1 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "UI Elements" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem11 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Typography" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem12 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Buttons" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem13 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Carousel" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem14 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Notifications" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem15 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Progressbars" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem16 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Media" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem17 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem1) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Tooltips" };
            menuItem1.Children.Add(menuItem11);
            menuItem1.Children.Add(menuItem12);
            menuItem1.Children.Add(menuItem13);
            menuItem1.Children.Add(menuItem14);
            menuItem1.Children.Add(menuItem15);
            menuItem1.Children.Add(menuItem16);
            menuItem1.Children.Add(menuItem17);
            menuPanel.Nodes.Add(menuItem1);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Forms", Data = "9" };

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem21 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Form Control" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem211 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem21) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Form Elements" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem212 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem21) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Form Validation" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem213 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem21) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Form Switch" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem214 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem21) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Form Checkbox" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem215 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem21) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Form Radio" };
            menuItem21.Children.Add(menuItem211);
            menuItem21.Children.Add(menuItem212);
            menuItem21.Children.Add(menuItem213);
            menuItem21.Children.Add(menuItem214);
            menuItem21.Children.Add(menuItem215);
            menuItem2.Children.Add(menuItem21);




            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem22 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem2) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Forms Wizard" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem221 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem22) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Simple Wizard" };
            {
                WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2211 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem221) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Forms Edit" };
                WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2212 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem221) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Forms Add" };
                WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem2213 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem221) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Forms List" };
                menuItem221.Children.Add(menuItem2211);
                menuItem221.Children.Add(menuItem2212);
                menuItem221.Children.Add(menuItem2213);
            }
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem222 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem22) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Validate Wizard" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem223 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem22) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Vertical Wizard" };
            menuItem22.Children.Add(menuItem221);
            menuItem22.Children.Add(menuItem222);
            menuItem22.Children.Add(menuItem223);
            menuItem2.Children.Add(menuItem22);





            menuPanel.Nodes.Add(menuItem2);



            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem3 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Charts" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem31 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Morris Chart" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem32 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "High Charts" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem33 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Am Charts" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem34 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem3) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Apex Chart" };
            menuItem3.Children.Add(menuItem31);
            menuItem3.Children.Add(menuItem32);
            menuItem3.Children.Add(menuItem33);
            menuItem3.Children.Add(menuItem34);
            menuPanel.Nodes.Add(menuItem3);

            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem4 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(null) { ItemType = SlideMenuPanelExt.NodeTypes.Menu, Text = "Table" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem41 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem4) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Basic Tables" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem42 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem4) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Data Table" };
            WinformControlLibraryExtension.SlideMenuPanelExt.Node menuItem43 = new WinformControlLibraryExtension.SlideMenuPanelExt.Node(menuItem4) { ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "Editable Table" };
            menuItem4.Children.Add(menuItem41);
            menuItem4.Children.Add(menuItem42);
            menuItem4.Children.Add(menuItem43);
            menuPanel.Nodes.Add(menuItem4);

            menuPanel.RestMenuNodes();
        }

    }
}
