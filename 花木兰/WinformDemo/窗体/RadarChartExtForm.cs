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
    public partial class RadarChartExtForm : Form
    {
        long count = 1;
        public RadarChartExtForm()
        {
            InitializeComponent();
        }

        private void RadarChartForm_Load(object sender, EventArgs e)
        {

            this.radarChartExt1.ChartItemItems.Add(new RadarChartExt.ChartItem()
            {
                Text = "2020年",
                BackColor = Color.Tomato,
                DataCurrent = new float[] { 60, 26, 40, 35, 70, 28, 46 }
            });
            this.radarChartExt1.DataBind();

            this.radarChartExt2.ChartItemItems.Add(new RadarChartExt.ChartItem()
            {
                Text = "一月",
                BackColor = Color.Tomato,
                DataCurrent = new float[] { 34, 26, 40, 35, 70, 28, 46 }
            });
            this.radarChartExt2.ChartItemItems.Add(new RadarChartExt.ChartItem()
            {
                Text = "二月",
                BackColor = Color.BlueViolet,
                DataCurrent = new float[] { 65, 35, 19, 35, 80, 56, 56 }
            });
            this.radarChartExt2.ChartItemItems.Add(new RadarChartExt.ChartItem()
            {
                Text = "三月",
                BackColor = Color.YellowGreen,
                DataCurrent = new float[] { 74, 26, 70, 90, 70, 68, 36 }
            });
            this.radarChartExt2.DataBind();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<RadarChartExt.ChartItemAnimationData> AnimationItem = new List<RadarChartExt.ChartItemAnimationData>();

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
    }
}
