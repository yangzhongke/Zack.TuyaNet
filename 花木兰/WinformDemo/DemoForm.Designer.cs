namespace WinformDemo
{
    partial class DemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuExt1 = new WinformControlLibraryExtension.SlideMenuExt();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel1.Location = new System.Drawing.Point(200, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 509);
            this.panel1.TabIndex = 1;
            // 
            // menuExt1
            // 
            this.menuExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.menuExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(175)))));
            this.menuExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuExt1.CausesValidation = false;
            this.menuExt1.Location = new System.Drawing.Point(1, 24);
            this.menuExt1.MenuHeight = 509;
            // 
            // 
            // 
            this.menuExt1.MenuPanel.BackColor = System.Drawing.Color.White;
            this.menuExt1.MenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuExt1.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuExt1.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuExt1.MenuPanel.Menu.ContentOrientation = WinformControlLibraryExtension.SlideMenuPanelExt.NodeContentOrientations.Right;
            this.menuExt1.MenuPanel.Menu.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.Menu.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.Menu.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.Menu.FoldImageCollapse = global::WinformDemo.Properties.Resources.menu_collapse_left;
            this.menuExt1.MenuPanel.Menu.FoldImageExpand = global::WinformDemo.Properties.Resources.menu_expand;
            this.menuExt1.MenuPanel.Menu.FoldImageOrientation = WinformControlLibraryExtension.SlideMenuPanelExt.NodeImageOrientations.Left;
            this.menuExt1.MenuPanel.Menu.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.ContentOrientation = WinformControlLibraryExtension.SlideMenuPanelExt.NodeContentOrientations.Right;
            this.menuExt1.MenuPanel.MenuTab.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.MenuTab.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.MenuTab.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(175)))));
            this.menuExt1.MenuPanel.MenuTab.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(208)))), ((int)(((byte)(188)))));
            this.menuExt1.MenuPanel.MenuTab.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(175)))));
            this.menuExt1.MenuPanel.MenuTab.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.Name = "";
            this.menuExt1.MenuPanel.NodeBorderStyle = WinformControlLibraryExtension.SlideMenuPanelExt.NodeBorderStyles.BottomBorder;
            this.menuExt1.MenuPanel.NodeImagePaddingRight = 18;
            this.menuExt1.MenuPanel.Scroll.SlideDisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuExt1.MenuPanel.Size = new System.Drawing.Size(200, 509);
            this.menuExt1.MenuPanel.TabIndex = 0;
            this.menuExt1.MenuPanel.TabStop = false;
            this.menuExt1.MenuPanel.Tool.Search = false;
            this.menuExt1.MinimumSize = new System.Drawing.Size(5, 0);
            this.menuExt1.Name = "menuExt1";
            this.menuExt1.Size = new System.Drawing.Size(200, 509);
            this.menuExt1.TabIndex = 0;
            this.menuExt1.TabStop = false;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(175)))));
            this.CaptionBox.BackColor = System.Drawing.Color.Empty;
            this.CaptionBox.CloseBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.CloseBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.CloseBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.CloseBtn.TipText1 = "关闭";
            this.CaptionBox.CloseBtn.TipText2 = "关闭";
            this.CaptionBox.MaxBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MaxBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.MaxBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MaxBtn.TipText1 = "最大化";
            this.CaptionBox.MaxBtn.TipText2 = "向下还原";
            this.CaptionBox.MinBtn.EnterForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MinBtn.NormalBackColor = System.Drawing.Color.Empty;
            this.CaptionBox.MinBtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CaptionBox.MinBtn.TipText1 = "最小化";
            this.CaptionBox.MinBtn.TipText2 = "最小化";
            this.ClientSize = new System.Drawing.Size(1272, 534);
            this.Controls.Add(this.menuExt1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DemoForm";
            this.Load += new System.EventHandler(this.DemoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private WinformControlLibraryExtension.SlideMenuExt menuExt1;
    }
}