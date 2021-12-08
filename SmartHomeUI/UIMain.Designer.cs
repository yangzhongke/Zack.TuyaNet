namespace SmartHomeUI
{
    partial class UIMain
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
            WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem fisheyeMenuItem1 = new WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIMain));
            WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem fisheyeMenuItem2 = new WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem();
            WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem fisheyeMenuItem3 = new WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem();
            WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem fisheyeMenuItem4 = new WinformControlLibraryExtension.FisheyeMenuExt.FisheyeMenuItem();
            this.fisheyeMenu = new WinformControlLibraryExtension.FisheyeMenuExt();
            this.SuspendLayout();
            // 
            // fisheyeMenu
            // 
            this.fisheyeMenu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fisheyeMenu.BackColor = System.Drawing.Color.Ivory;
            fisheyeMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("fisheyeMenuItem1.Image")));
            fisheyeMenuItem1.now_centerpointf = ((System.Drawing.PointF)(resources.GetObject("fisheyeMenuItem1.now_centerpointf")));
            fisheyeMenuItem1.now_proportion = 0.5F;
            fisheyeMenuItem1.now_rectf = ((System.Drawing.RectangleF)(resources.GetObject("fisheyeMenuItem1.now_rectf")));
            fisheyeMenuItem1.Text = "主卧";
            fisheyeMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("fisheyeMenuItem2.Image")));
            fisheyeMenuItem2.now_centerpointf = ((System.Drawing.PointF)(resources.GetObject("fisheyeMenuItem2.now_centerpointf")));
            fisheyeMenuItem2.now_proportion = 0.5F;
            fisheyeMenuItem2.now_rectf = ((System.Drawing.RectangleF)(resources.GetObject("fisheyeMenuItem2.now_rectf")));
            fisheyeMenuItem2.Text = "女儿卧室";
            fisheyeMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("fisheyeMenuItem3.Image")));
            fisheyeMenuItem3.now_centerpointf = ((System.Drawing.PointF)(resources.GetObject("fisheyeMenuItem3.now_centerpointf")));
            fisheyeMenuItem3.now_proportion = 0.5F;
            fisheyeMenuItem3.now_rectf = ((System.Drawing.RectangleF)(resources.GetObject("fisheyeMenuItem3.now_rectf")));
            fisheyeMenuItem3.Text = "厨房";
            fisheyeMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("fisheyeMenuItem4.Image")));
            fisheyeMenuItem4.now_centerpointf = ((System.Drawing.PointF)(resources.GetObject("fisheyeMenuItem4.now_centerpointf")));
            fisheyeMenuItem4.now_proportion = 0.5F;
            fisheyeMenuItem4.now_rectf = ((System.Drawing.RectangleF)(resources.GetObject("fisheyeMenuItem4.now_rectf")));
            fisheyeMenuItem4.Text = "浴室";
            this.fisheyeMenu.Items.Add(fisheyeMenuItem1);
            this.fisheyeMenu.Items.Add(fisheyeMenuItem2);
            this.fisheyeMenu.Items.Add(fisheyeMenuItem3);
            this.fisheyeMenu.Items.Add(fisheyeMenuItem4);
            this.fisheyeMenu.ItemWidth = 200;
            this.fisheyeMenu.Location = new System.Drawing.Point(31, 384);
            this.fisheyeMenu.Name = "fisheyeMenu";
            this.fisheyeMenu.Size = new System.Drawing.Size(825, 189);
            this.fisheyeMenu.TabIndex = 1;
            this.fisheyeMenu.TextDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fisheyeMenu.TextShow = true;
            this.fisheyeMenu.ItemClick += new WinformControlLibraryExtension.FisheyeMenuExt.ItemClickEventHandler(this.fisheyeMenu_ItemClick);
            // 
            // UIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.fisheyeMenu);
            this.Name = "UIMain";
            this.Size = new System.Drawing.Size(918, 573);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformControlLibraryExtension.FisheyeMenuExt fisheyeMenu;
    }
}
