
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// SlideMenuExt菜单控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("SlideMenuExt菜单控件")]
    [DefaultProperty("MenuWidth")]
    [DefaultEvent("PatternChanged")]
    [Designer(typeof(MenuExtEditor))]
    public class SlideMenuExt : Control
    {
        #region 新增事件

        public delegate void StatusChangedEventHandler(object sender, PatternChangedEventArgs e);
        private event StatusChangedEventHandler patternChanged;
        /// <summary>
        /// 控件模式更改事件
        /// </summary>
        [Description("控件模式更改事件")]
        public event StatusChangedEventHandler PatternChanged
        {
            add { this.patternChanged += value; }
            remove { this.patternChanged -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add { base.MarginChanged += value; }
            remove { base.MarginChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add { base.TabIndexChanged += value; }
            remove { base.TabIndexChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { base.TabStopChanged += value; }
            remove { base.TabStopChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { base.FontChanged += value; }
            remove { base.FontChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { base.ForeColorChanged += value; }
            remove { base.ForeColorChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private SlideMenuPanelExt menuPanel;
        /// <summary>
        /// 菜单面板
        /// </summary>
        [Description("菜单面板")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SlideMenuPanelExt MenuPanel
        {
            get { return this.menuPanel; }
        }

        private int menuWidth = 200;
        /// <summary>
        /// 控件隐藏状态控件宽度
        /// </summary>
        [Description("控件隐藏状态控件宽度")]
        [DefaultValue(200)]
        public int MenuWidth
        {
            get
            {
                return this.menuWidth;
            }
            set
            {
                if (this.menuWidth == value)
                    return;

                this.menuWidth = value;
                if (this.patternType == PatternTypes.Normal)
                {
                    this.Width = this.menuWidth;
                }
            }
        }

        /// <summary>
        /// 控件隐藏隐藏后的宽度
        /// </summary>
        [Description("控件隐藏状态控件宽度")]
        [DefaultValue(300)]
        public int MenuHeight
        {
            get
            {
                return this.Height;
            }
            set
            {
                if (this.Height == value)
                    return;

                this.Height = value;
            }
        }

        private int menuMinWidth = 10;
        /// <summary>
        /// 控件最小化模式下的宽度
        /// </summary>
        [Description("控件最小化模式下的宽度")]
        [DefaultValue(10)]
        public int MenuMinWidth
        {
            get
            {
                return this.menuMinWidth;
            }
            set
            {
                if (this.menuMinWidth == value)
                    return;

                this.menuMinWidth = value;
                if (this.patternType == PatternTypes.Min)
                {
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(0);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Padding DefaultMargin
        {
            get
            {
                return new Padding(0);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 300);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return 0; }
            set { base.TabIndex = 0; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }
            set
            {
                base.Cursor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("MenuWidth和MenuHeight代替")]
        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
            }
        }

        #endregion

        #region 字段
        /// <summary>
        /// 菜单面板是否启用拖载功能
        /// </summary>
        private bool drawEnabled = false;
        /// <summary>
        /// 控件模式
        /// </summary>
        private PatternTypes patternType = PatternTypes.Normal;
        /// <summary>
        /// 浮层
        /// </summary>
        private ToolStripDropDown tsdd = null;
        #endregion

        public SlideMenuExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);
            this.MinimumSize = new Size(5, 0);

            this.menuPanel = new SlideMenuPanelExt();
            this.menuPanel.Dock = DockStyle.Fill;
            this.menuPanel.Tool.MinBtn.Click += this.HideBtn_Click;
            this.menuPanel.Tool.FixedBtn.Click += this.FixedBtn_Click;
            this.Controls.Add(this.menuPanel);

            this.drawEnabled = this.menuPanel.Drag.Enabled;
            this.tsdd = new ToolStripDropDown() { Padding = Padding.Empty };
            this.Click += this.MinPattern_Click;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            #region 用绘制菜单面板背景色绘制背景
            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.ClientRectangle);
            back_sb.Dispose();
            #endregion
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.Height != height)
            {
                this.MenuPanel.Height = height;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnPatternChanged(PatternChangedEventArgs e)
        {
            if (this.patternChanged != null)
            {
                this.patternChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 迷你模式下单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinPattern_Click(object sender, EventArgs e)
        {
            if (this.MenuPanel.Tool.FixedBtn.ButtonChecked == true)//固定状态
            {
                this.patternType = PatternTypes.Normal;
                this.MenuPanel.Parent = this;
                this.Width = this.MenuWidth;
                this.OnPatternChanged(new PatternChangedEventArgs() { PatternType = this.patternType });
            }
            else//取消固定状态
            {
                if (this.drawEnabled)
                {
                    this.menuPanel.Drag.Enabled = false;//禁用拖载功能
                }

                tsdd.Items.Clear();
                tsdd.Items.Add(new ToolStripControlHost(this.MenuPanel) { Margin = Padding.Empty, Padding = Padding.Empty });
                tsdd.Show(this, new Point(0, 0));
            }
        }

        /// <summary>
        /// 菜单面板的固定、取消固定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixedBtn_Click(object sender, EventArgs e)
        {
            if (this.MenuPanel.Parent == this)//默认排版
            {
                if (this.MenuPanel.Tool.FixedBtn.ButtonChecked == false)//取消固定状态
                {
                    if (this.MenuPanel.Parent == this)
                    {
                        this.patternType = PatternTypes.Min;
                        this.MenuPanel.Parent = null;
                    }
                    this.Width = this.MenuMinWidth;
                    this.OnPatternChanged(new PatternChangedEventArgs() { PatternType = this.patternType });
                }
            }
            else//浮层排版
            {
                if (this.MenuPanel.Tool.FixedBtn.ButtonChecked == true)//固定状态
                {
                    this.patternType = PatternTypes.Normal;
                    this.MenuPanel.Parent = this;
                    this.Width = this.MenuWidth;
                    if (this.tsdd != null)
                    {
                        tsdd.Close();
                    }
                    if (this.drawEnabled)
                    {
                        this.MenuPanel.Drag.Enabled = true;
                    }
                    this.OnPatternChanged(new PatternChangedEventArgs() { PatternType = this.patternType });
                }
            }
        }

        /// <summary>
        /// 菜单面板的最小化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideBtn_Click(object sender, EventArgs e)
        {
            if (this.MenuPanel.Parent == this)//默认排版
            {
                if (this.MenuPanel.Parent == this)
                {
                    this.patternType = PatternTypes.Min;
                    this.MenuPanel.Parent = null;
                }
                this.Width = this.MenuMinWidth;
                this.OnPatternChanged(new PatternChangedEventArgs() { PatternType = this.patternType });
            }
            else
            {
                if (this.tsdd != null)
                {
                    this.tsdd.Close();
                }
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 控件模式更改事件参数
        /// </summary>
        [Description("控件模式更改事件参数")]
        public class PatternChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 控件模式
            /// </summary>
            [Description("控件模式")]
            public PatternTypes PatternType { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 控件模式
        /// </summary>
        [Description("控件模式")]
        public enum PatternTypes
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 最小化
            /// </summary>
            Min
        }

        #endregion
    }

}
