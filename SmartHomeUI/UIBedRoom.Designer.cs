namespace SmartHomeUI
{
    partial class UIBedRoom
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIBedRoom));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureGoHome = new System.Windows.Forms.PictureBox();
            this.picAirConditioner = new System.Windows.Forms.PictureBox();
            this.picParent = new System.Windows.Forms.PictureBox();
            this.thermometer = new WinformControlLibraryExtension.ThermometerExt();
            this.hygrometer = new WinformControlLibraryExtension.WaveProgressExt();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGoHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAirConditioner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.pictureGoHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picAirConditioner, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.picParent, 9, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(874, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureGoHome
            // 
            this.pictureGoHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureGoHome.Image = ((System.Drawing.Image)(resources.GetObject("pictureGoHome.Image")));
            this.pictureGoHome.Location = new System.Drawing.Point(3, 3);
            this.pictureGoHome.Name = "pictureGoHome";
            this.pictureGoHome.Size = new System.Drawing.Size(81, 50);
            this.pictureGoHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureGoHome.TabIndex = 1;
            this.pictureGoHome.TabStop = false;
            this.pictureGoHome.Click += new System.EventHandler(this.pictureGoHome_Click);
            // 
            // picAirConditioner
            // 
            this.picAirConditioner.BackColor = System.Drawing.Color.Transparent;
            this.picAirConditioner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAirConditioner.Image = ((System.Drawing.Image)(resources.GetObject("picAirConditioner.Image")));
            this.picAirConditioner.Location = new System.Drawing.Point(351, 125);
            this.picAirConditioner.Name = "picAirConditioner";
            this.picAirConditioner.Size = new System.Drawing.Size(49, 50);
            this.picAirConditioner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAirConditioner.TabIndex = 3;
            this.picAirConditioner.TabStop = false;
            this.picAirConditioner.Click += new System.EventHandler(this.picAirConditioner_Click);
            // 
            // picParent
            // 
            this.picParent.BackColor = System.Drawing.Color.Transparent;
            this.picParent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picParent.Image = ((System.Drawing.Image)(resources.GetObject("picParent.Image")));
            this.picParent.Location = new System.Drawing.Point(786, 491);
            this.picParent.Name = "picParent";
            this.picParent.Size = new System.Drawing.Size(49, 50);
            this.picParent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picParent.TabIndex = 4;
            this.picParent.TabStop = false;
            this.picParent.Click += new System.EventHandler(this.picParent_Click);
            // 
            // thermometer
            // 
            this.thermometer.ForeColor = System.Drawing.Color.White;
            this.thermometer.Location = new System.Drawing.Point(20, 100);
            this.thermometer.Name = "thermometer";
            this.thermometer.Size = new System.Drawing.Size(80, 250);
            this.thermometer.TabIndex = 0;
            this.thermometer.TabStop = false;
            // 
            // hygrometer
            // 
            this.hygrometer.AnimationActive = true;
            this.hygrometer.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.hygrometer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(238)))));
            this.hygrometer.Location = new System.Drawing.Point(100, 180);
            this.hygrometer.Name = "hygrometer";
            this.hygrometer.Size = new System.Drawing.Size(100, 100);
            this.hygrometer.Style = WinformControlLibraryExtension.WaveProgressExt.WaveProgressStyles.Quadrangle;
            this.hygrometer.TabIndex = 0;
            this.hygrometer.TabStop = false;
            this.hygrometer.WaveBackColor = System.Drawing.Color.Empty;
            // 
            // UIBedRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hygrometer);
            this.Controls.Add(this.thermometer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UIBedRoom";
            this.Size = new System.Drawing.Size(874, 611);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureGoHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAirConditioner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picParent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureGoHome;
        private WinformControlLibraryExtension.ThermometerExt thermometer;
        private WinformControlLibraryExtension.WaveProgressExt hygrometer;
        private System.Windows.Forms.PictureBox picAirConditioner;
        private System.Windows.Forms.PictureBox picParent;
        private System.Windows.Forms.Timer timer1;
    }
}
