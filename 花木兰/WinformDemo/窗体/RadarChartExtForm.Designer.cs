namespace WinformDemo
{
    partial class RadarChartExtForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine15 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadarChartExtForm));
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine16 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine17 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine18 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine19 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine20 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine21 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine22 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine23 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine24 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine25 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine26 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine27 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            WinformControlLibraryExtension.RadarChartExt.ChartLine chartLine28 = new WinformControlLibraryExtension.RadarChartExt.ChartLine();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radarChartExt2 = new WinformControlLibraryExtension.RadarChartExt();
            this.radarChartExt1 = new WinformControlLibraryExtension.RadarChartExt();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radarChartExt2
            // 
            this.radarChartExt2.AnimationTime = 500;
            this.radarChartExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarChartExt2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.CausesValidation = false;
            chartLine15.LineAngle = 270F;
            chartLine15.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine15.LineEndPoint")));
            chartLine15.LineText = "星期一";
            chartLine15.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine15.LoopCenter")));
            chartLine15.LoopRadius = 100F;
            chartLine16.LineAngle = 321.4286F;
            chartLine16.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine16.LineEndPoint")));
            chartLine16.LineText = "星期二";
            chartLine16.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine16.LoopCenter")));
            chartLine16.LoopRadius = 100F;
            chartLine17.LineAngle = 12.85715F;
            chartLine17.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine17.LineEndPoint")));
            chartLine17.LineText = "星期三";
            chartLine17.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine17.LoopCenter")));
            chartLine17.LoopRadius = 100F;
            chartLine18.LineAngle = 64.28571F;
            chartLine18.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine18.LineEndPoint")));
            chartLine18.LineText = "星期四";
            chartLine18.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine18.LoopCenter")));
            chartLine18.LoopRadius = 100F;
            chartLine19.LineAngle = 115.7143F;
            chartLine19.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine19.LineEndPoint")));
            chartLine19.LineText = "星期五";
            chartLine19.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine19.LoopCenter")));
            chartLine19.LoopRadius = 100F;
            chartLine20.LineAngle = 167.1429F;
            chartLine20.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine20.LineEndPoint")));
            chartLine20.LineText = "星期六";
            chartLine20.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine20.LoopCenter")));
            chartLine20.LoopRadius = 100F;
            chartLine21.LineAngle = 218.5714F;
            chartLine21.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine21.LineEndPoint")));
            chartLine21.LineText = "星期日";
            chartLine21.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine21.LoopCenter")));
            chartLine21.LoopRadius = 100F;
            this.radarChartExt2.ChartLineItems.Add(chartLine15);
            this.radarChartExt2.ChartLineItems.Add(chartLine16);
            this.radarChartExt2.ChartLineItems.Add(chartLine17);
            this.radarChartExt2.ChartLineItems.Add(chartLine18);
            this.radarChartExt2.ChartLineItems.Add(chartLine19);
            this.radarChartExt2.ChartLineItems.Add(chartLine20);
            this.radarChartExt2.ChartLineItems.Add(chartLine21);
            this.radarChartExt2.ChartType = WinformControlLibraryExtension.RadarChartExt.ChartTypes.Rhombus;
            this.radarChartExt2.Location = new System.Drawing.Point(379, 351);
            this.radarChartExt2.LoopBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.LoopEvenBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt2.LoopLineMinValueTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.radarChartExt2.LoopOddBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt2.LoopScaleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt2.Name = "radarChartExt2";
            this.radarChartExt2.OptionAreaWidth = 100;
            this.radarChartExt2.OptionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt2.OptionTipTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radarChartExt2.Size = new System.Drawing.Size(401, 318);
            this.radarChartExt2.TabIndex = 0;
            this.radarChartExt2.TabStop = false;
            this.radarChartExt2.Text = "分析图";
            this.radarChartExt2.Title = "静态分析图";
            this.radarChartExt2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            // 
            // radarChartExt1
            // 
            this.radarChartExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radarChartExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.BorderShow = true;
            this.radarChartExt1.CausesValidation = false;
            chartLine22.LineAngle = 270F;
            chartLine22.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine22.LineEndPoint")));
            chartLine22.LineText = "星期一";
            chartLine22.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine22.LoopCenter")));
            chartLine22.LoopRadius = 100F;
            chartLine23.LineAngle = 321.4286F;
            chartLine23.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine23.LineEndPoint")));
            chartLine23.LineText = "星期二";
            chartLine23.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine23.LoopCenter")));
            chartLine23.LoopRadius = 100F;
            chartLine24.LineAngle = 12.85715F;
            chartLine24.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine24.LineEndPoint")));
            chartLine24.LineText = "星期三";
            chartLine24.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine24.LoopCenter")));
            chartLine24.LoopRadius = 100F;
            chartLine25.LineAngle = 64.28571F;
            chartLine25.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine25.LineEndPoint")));
            chartLine25.LineText = "星期四";
            chartLine25.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine25.LoopCenter")));
            chartLine25.LoopRadius = 100F;
            chartLine26.LineAngle = 115.7143F;
            chartLine26.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine26.LineEndPoint")));
            chartLine26.LineText = "星期五";
            chartLine26.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine26.LoopCenter")));
            chartLine26.LoopRadius = 100F;
            chartLine27.LineAngle = 167.1429F;
            chartLine27.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine27.LineEndPoint")));
            chartLine27.LineText = "星期六";
            chartLine27.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine27.LoopCenter")));
            chartLine27.LoopRadius = 100F;
            chartLine28.LineAngle = 218.5714F;
            chartLine28.LineEndPoint = ((System.Drawing.PointF)(resources.GetObject("chartLine28.LineEndPoint")));
            chartLine28.LineText = "星期日";
            chartLine28.LoopCenter = ((System.Drawing.PointF)(resources.GetObject("chartLine28.LoopCenter")));
            chartLine28.LoopRadius = 100F;
            this.radarChartExt1.ChartLineItems.Add(chartLine22);
            this.radarChartExt1.ChartLineItems.Add(chartLine23);
            this.radarChartExt1.ChartLineItems.Add(chartLine24);
            this.radarChartExt1.ChartLineItems.Add(chartLine25);
            this.radarChartExt1.ChartLineItems.Add(chartLine26);
            this.radarChartExt1.ChartLineItems.Add(chartLine27);
            this.radarChartExt1.ChartLineItems.Add(chartLine28);
            this.radarChartExt1.Location = new System.Drawing.Point(379, 27);
            this.radarChartExt1.LoopBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.LoopEvenBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.radarChartExt1.LoopLineMaxValueShow = true;
            this.radarChartExt1.LoopLineMinValueShow = true;
            this.radarChartExt1.LoopLineMinValueTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.radarChartExt1.LoopOddBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radarChartExt1.LoopScaleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt1.Name = "radarChartExt1";
            this.radarChartExt1.OptionAreaWidth = 100;
            this.radarChartExt1.OptionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radarChartExt1.OptionTipTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radarChartExt1.Size = new System.Drawing.Size(401, 318);
            this.radarChartExt1.TabIndex = 0;
            this.radarChartExt1.TabStop = false;
            this.radarChartExt1.Title = "实时分析图";
            this.radarChartExt1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(112)))), ((int)(((byte)(147)))));
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.radarChartExt1;
            this.propertyGrid1.Size = new System.Drawing.Size(350, 700);
            this.propertyGrid1.TabIndex = 14;
            // 
            // RadarChartExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(801, 700);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.radarChartExt2);
            this.Controls.Add(this.radarChartExt1);
            this.Name = "RadarChartExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雷达分析图控件";
            this.Load += new System.EventHandler(this.RadarChartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.RadarChartExt radarChartExt1;
        private WinformControlLibraryExtension.RadarChartExt radarChartExt2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}