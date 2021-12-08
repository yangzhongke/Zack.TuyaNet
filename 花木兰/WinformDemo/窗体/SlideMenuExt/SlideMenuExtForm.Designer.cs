namespace WinformDemo
{
    partial class SlideMenuExtForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuExt1 = new WinformControlLibraryExtension.SlideMenuExt();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(203, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 490);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(214, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "设置选中节点为 Buttons";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(261, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // menuExt1
            // 
            this.menuExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.menuExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(208)))), ((int)(((byte)(188)))));
            this.menuExt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuExt1.CausesValidation = false;
            this.menuExt1.Location = new System.Drawing.Point(0, 0);
            this.menuExt1.MenuHeight = 490;
            // 
            // 
            // 
            this.menuExt1.MenuPanel.BackColor = System.Drawing.Color.White;
            this.menuExt1.MenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuExt1.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuExt1.MenuPanel.Drag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuExt1.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuExt1.MenuPanel.Menu.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.Menu.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.Menu.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.Menu.FoldImageCollapse = global::WinformDemo.Properties.Resources.menu_collapse_right;
            this.menuExt1.MenuPanel.Menu.FoldImageExpand = global::WinformDemo.Properties.Resources.menu_expand;
            this.menuExt1.MenuPanel.Menu.Image = global::WinformDemo.Properties.Resources.menu;
            this.menuExt1.MenuPanel.Menu.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.DisableBackColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.MenuTab.DisableTextColor = System.Drawing.Color.Empty;
            this.menuExt1.MenuPanel.MenuTab.EnterTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.Image = global::WinformDemo.Properties.Resources.menutab;
            this.menuExt1.MenuPanel.MenuTab.NormalTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.MenuTab.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuExt1.MenuPanel.Name = "";
            this.menuExt1.MenuPanel.NodeIndent = 10;
            this.menuExt1.MenuPanel.Scroll.SlideDisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuExt1.MenuPanel.Size = new System.Drawing.Size(200, 490);
            this.menuExt1.MenuPanel.TabIndex = 0;
            this.menuExt1.MenuPanel.TabStop = false;
            this.menuExt1.MinimumSize = new System.Drawing.Size(10, 0);
            this.menuExt1.Name = "menuExt1";
            this.menuExt1.Size = new System.Drawing.Size(200, 490);
            this.menuExt1.TabIndex = 0;
            this.menuExt1.TabStop = false;
            this.menuExt1.PatternChanged += new WinformControlLibraryExtension.SlideMenuExt.StatusChangedEventHandler(this.menuExt1_PatternChanged);
            // 
            // SlideMenuExtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(826, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuExt1);
            this.Name = "SlideMenuExtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuExt控件";
            this.Load += new System.EventHandler(this.MenuExtForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }





        #endregion

        private WinformControlLibraryExtension.SlideMenuExt menuExt1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}