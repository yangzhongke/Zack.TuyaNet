using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformDemo
{
    public partial class RadarScanExtForm : Form
    {
        public RadarScanExtForm()
        {
            InitializeComponent();


        }

        private void RadarExtForm_Load(object sender, EventArgs e)
        {

            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem1 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 10F, Y = 10F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem2 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 20F, Y = 20F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem3 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 30F, Y = 20F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem4 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -18F, Y = 40F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem5 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 50F, Y = -30F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem6 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -20F, Y = -30F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem7 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -25F, Y = -33F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem8 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -20F, Y = 5F };
            this.radarExt1.DataPointItems.Add(dataPointItem1);
            this.radarExt1.DataPointItems.Add(dataPointItem2);
            this.radarExt1.DataPointItems.Add(dataPointItem3);
            this.radarExt1.DataPointItems.Add(dataPointItem4);
            this.radarExt1.DataPointItems.Add(dataPointItem5);
            this.radarExt1.DataPointItems.Add(dataPointItem6);
            this.radarExt1.DataPointItems.Add(dataPointItem7);
            this.radarExt1.DataPointItems.Add(dataPointItem8);

            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem9 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 10F, Y = 10F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem10 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 20F, Y = 20F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem11 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 30F, Y = 20F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem12 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -18F, Y = 40F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem13 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = 50F, Y = -30F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem14 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -20F, Y = -30F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem15 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -25F, Y = -33F };
            WinformControlLibraryExtension.RadarScanExt.DataPointItem dataPointItem16 = new WinformControlLibraryExtension.RadarScanExt.DataPointItem() { X = -20F, Y = 5F };
            this.radarExt2.DataPointItems.Add(dataPointItem9);
            this.radarExt2.DataPointItems.Add(dataPointItem10);
            this.radarExt2.DataPointItems.Add(dataPointItem11);
            this.radarExt2.DataPointItems.Add(dataPointItem12);
            this.radarExt2.DataPointItems.Add(dataPointItem13);
            this.radarExt2.DataPointItems.Add(dataPointItem14);
            this.radarExt2.DataPointItems.Add(dataPointItem15);
            this.radarExt2.DataPointItems.Add(dataPointItem16);

        }

    }
}
