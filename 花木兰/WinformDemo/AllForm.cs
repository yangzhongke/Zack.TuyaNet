
/**版权******************************************************************

            版权：  唧唧复唧唧木兰当户织
            作者：  唧唧复唧唧木兰当户织
            博客：  https://www.cnblogs.com/tlmbem/
     源码地址：  https://www.cnblogs.com/tlmbem/
            描述：  授权使用在 https://www.cnblogs.com/tlmbem/ 上有介绍，禁止删除下面的木兰诗。
            日期：  2020-10-28
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension;

namespace WinformDemo
{
    public partial class AllForm : Form
    {
        PerformanceCounter pcCpuLoad = null;
        long count = 1;
        List<int> intlist5 = new List<int>() { 30, 35, 60, 45, 30, 80, 85, 70 };
        List<int> intlist6 = new List<int>() { 60, 30, 35, 80, 45, 30, 70, 85 };
        List<int> intlist3 = new List<int>() { 50, 40, 35, 70, 65, 30, 90, 75 };
        List<int> intlist4 = new List<int>() { 20, 50, 45, 60, 45, 80, 90, 65 };

        List<int> intlist1 = new List<int>() { 20, 50, 45, 60, 45, 80, 90, 65 };
        List<int> intlist2 = new List<int>() { 50, 40, 35, 70, 65, 30, 90, 75 };
        List<int> intlist7 = new List<int>() { 60, 30, 35, 80, 45, 30, 70, 85 };
        List<int> intlist8 = new List<int>() { 30, 35, 60, 45, 30, 80, 85, 70 };
        int index = 0;

        public AllForm()
        {
            InitializeComponent();
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();
            timer1.Tick += this.timer1_Tick;
            this.timer1.Enabled = true;


            #region ThermometerExt
            this.textCarouselExt6.Play();
            this.textCarouselExt7.Play();
            #endregion

            #region RadarScanExt
            RadarScanExt.DataPointItem dataPointItem9 = new RadarScanExt.DataPointItem() { X = 10F, Y = 10F };
            RadarScanExt.DataPointItem dataPointItem10 = new RadarScanExt.DataPointItem() { X = 20F, Y = 20F };
            RadarScanExt.DataPointItem dataPointItem11 = new RadarScanExt.DataPointItem() { X = 30F, Y = 20F };
            RadarScanExt.DataPointItem dataPointItem12 = new RadarScanExt.DataPointItem() { X = -18F, Y = 40F };
            RadarScanExt.DataPointItem dataPointItem13 = new RadarScanExt.DataPointItem() { X = 50F, Y = -30F };
            RadarScanExt.DataPointItem dataPointItem14 = new RadarScanExt.DataPointItem() { X = -20F, Y = -30F };
            RadarScanExt.DataPointItem dataPointItem15 = new RadarScanExt.DataPointItem() { X = -25F, Y = -33F };
            RadarScanExt.DataPointItem dataPointItem16 = new RadarScanExt.DataPointItem() { X = -20F, Y = 5F };
            this.radarExt2.DataPointItems.Add(dataPointItem9);
            this.radarExt2.DataPointItems.Add(dataPointItem10);
            this.radarExt2.DataPointItems.Add(dataPointItem11);
            this.radarExt2.DataPointItems.Add(dataPointItem12);
            this.radarExt2.DataPointItems.Add(dataPointItem13);
            this.radarExt2.DataPointItems.Add(dataPointItem14);
            this.radarExt2.DataPointItems.Add(dataPointItem15);
            this.radarExt2.DataPointItems.Add(dataPointItem16);
            #endregion

            #region ImageCarouselExt
            this.imageCarouselExt3.Play();
            #endregion

            #region RadarChartExt
            this.radarChartExt1.ChartItemItems.Add(new RadarChartExt.ChartItem()
            {
                Text = "2020年",
                BackColor = Color.Tomato,
                DataCurrent = new float[] { 60, 26, 40, 35, 70, 28, 46 }
            });
            this.radarChartExt1.DataBind();
            #endregion

            #region  DateExt
            this.datePickerExt1.DateValue = DateTime.Now;
            #endregion

            #region ImageExt
            animationImageExt1.Image = global::WinformDemo.Properties.Resources.动态图片;

            #endregion

            #region SlideMenuExt
            this.Bind(this.menuPanelExt1);
            #endregion

            #region ImageWhirligigExt
            this.imageWhirligigExt1.Play(0);
            #endregion

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region GradualProgressExt
            {
                float value = (float)Math.Round(pcCpuLoad.NextValue());
                progressExt3.Value = value / 100 + 0.56f;
            }
            #endregion

            #region ThermometerExt
            {
                Random rd = new Random();
                this.thermometerExt3.Value = rd.Next(-20, 100);
            }
            #endregion


            #region NumberTimeExt
            this.timeExt1.Value = DateTime.Now;
            #endregion

            #region PercentageProgressExt
            {
                Random rd = new Random();
                this.percentageBarExt1.Value = (float)(32 + rd.Next(1, 9)) / 100;
                this.percentageBarExt2.Value = (float)(35 + rd.Next(1, 9)) / 100;
                this.percentageBarExt3.Value = (float)(35 + rd.Next(1, 9)) / 100;
                this.percentageBarExt7.Value = (float)(74 + rd.Next(1, 9)) / 100;
            }
            #endregion

            #region RadarChartExt
            { List<RadarChartExt.ChartItemAnimationData> AnimationItem = new List<RadarChartExt.ChartItemAnimationData>();

                switch (count % 7)
                {
                    case 0:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 90, 86, 40, 35, 70, 28, 46 } });
                            break;
                        }
                    case 1:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 20, 90, 40, 35, 50, 28, 46 } });
                            break;
                        }
                    case 2:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 34, 26, 90, 55, 70, 48, 96 } });
                            break;
                        }
                    case 3:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 74, 26, 70, 90, 70, 68, 36 } });
                            break;
                        }
                    case 4:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 74, 26, 70, 20, 90, 48, 36 } });
                            break;
                        }
                    case 5:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 74, 26, 94, 30, 60, 90, 36 } });
                            break;
                        }
                    case 6:
                        {
                            AnimationItem.Add(new RadarChartExt.ChartItemAnimationData() { Data = new float[] { 74, 26, 88, 50, 70, 78, 40 } });
                            break;
                        }
                }
                count++;
                this.radarChartExt1.AnimationChangeData(AnimationItem);
            }
            #endregion

            #region MeterExt
            {
                index++;
                if (index >= intlist5.Count)
                {
                    index = 0;
                }
                this.meterBarExt6.Value = intlist6[index];
                this.meterBarExt4.Value = intlist4[index];
                this.meterBarExt3.Value = intlist3[index];
            }
            #endregion

            #region ChartExt
            {
                Random rd = new Random();
                float i = (float)rd.Next(0, 6);
                float value = (float)Math.Round(pcCpuLoad.NextValue());
                this.chartExt1.AddPathPoint(value / 100 + i / 10);
            }
            #endregion

        }

        private void thermometerExt_ValueChanged(object sender, ThermometerExt.ValueChangedEventArgs e)
        {
            ((ThermometerExt)sender).Text = "当前温度" + e.Value + "C";
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
