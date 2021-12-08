
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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 扁平化窗体基类
    /// </summary>
    [Description("扁平化窗体基类")]
    public partial class FormExt : Form, IFormExt
    {
        #region 新增属性

        private ResizeTypes resizeType = ResizeTypes.CaptionDrag;
        /// <summary>
        /// 放大缩小模式
        /// </summary>
        [Description("放大缩小模式")]
        [DefaultValue(ResizeTypes.CaptionDrag)]
        [Browsable(true)]
        public ResizeTypes ResizeType
        {
            get
            {
                return this.resizeType;
            }
            set
            {
                if (this.resizeType == value)
                    return;

                this.resizeType = value;
            }
        }

        private bool moveEnabled = false;
        /// <summary>
        /// 是否启用界面移动功能
        /// </summary>
        [Description("是否启用界面移动功能")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool MoveEnabled
        {
            get
            {
                return this.moveEnabled;
            }
            set
            {
                if (this.moveEnabled == value)
                    return;

                this.moveEnabled = value;
            }
        }

        private bool captionEnabled = true;
        /// <summary>
        /// 是否启用标题栏和工具
        /// </summary>
        [Description("是否启用标题栏和工具")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool CaptionEnabled
        {
            get
            {
                return this.captionEnabled;
            }
            set
            {
                if (this.captionEnabled == value)
                    return;

                this.captionEnabled = value;
                this.CaptionBox.InitializeControlBox();
                this.UpdateChildrenControls();
            }
        }

        private bool backgroundImageCaption = true;
        /// <summary>
        /// 标题栏是否包含背景图片
        /// </summary>
        [Description("标题栏是否包含背景图片")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool BackgroundImageCaption
        {
            get
            {
                return this.backgroundImageCaption;
            }
            set
            {
                if (this.backgroundImageCaption == value)
                    return;

                this.backgroundImageCaption = value;
                this.Invalidate();
            }
        }

        private bool borderEnabled = true;
        /// <summary>
        /// 是否启用边框宽度
        /// </summary>
        [Description("是否启用边框宽度")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool BorderEnabled
        {
            get
            {
                return this.borderEnabled;
            }
            set
            {
                if (this.borderEnabled == value)
                    return;

                this.borderEnabled = value;
                this.CaptionBox.InitializeControlBox();
                this.UpdateChildrenControls();
            }
        }

        private int borderWidth = 1;
        /// <summary>
        /// 边框宽度
        /// </summary>
        [Description("边框宽度")]
        [DefaultValue(1)]
        [Browsable(true)]
        public int BorderWidth
        {
            get
            {
                return this.BorderEnabled ? this.borderWidth : 0;
            }
            set
            {
                if (this.borderWidth == value || value < 0)
                    return;

                this.borderWidth = value;
                this.CaptionBox.InitializeControlBox();
            }
        }

        private Color borderColor = Color.FromArgb(137, 158, 136);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "137 ,158, 136")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;

                this.borderColor = value;
                this.Invalidate();
            }
        }

        private Color sizeGripColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 手柄颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("手柄颜色")]
        public Color SizeGripColor
        {
            get { return this.sizeGripColor; }
            set
            {
                if (this.sizeGripColor == value)
                    return;

                this.sizeGripColor = value;
                this.Invalidate();
            }
        }

        private TextOrientations textOrientation = TextOrientations.Center;
        /// <summary>
        /// 标题文本方位
        /// </summary>
        [Description("标题文本方位")]
        [DefaultValue(TextOrientations.Center)]
        [Browsable(true)]
        public TextOrientations TextOrientation
        {
            get
            {
                return this.textOrientation;
            }
            set
            {
                if (this.textOrientation == value)
                    return;

                this.textOrientation = value;
                this.Invalidate();
            }
        }

        public CaptionBoxClass captionBox;
        /// <summary>
        /// 标题栏
        /// </summary>
        [Description("标题栏")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CaptionBoxClass CaptionBox
        {
            get
            {
                if (this.captionBox == null)
                    this.captionBox = new CaptionBoxClass(this);
                return this.captionBox;
            }
        }

        #endregion

        #region 重写属性

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

        public new SizeGripStyle SizeGripStyle
        {
            get
            {
                return base.SizeGripStyle;
            }
            set
            {
                if (base.SizeGripStyle == value)
                    return;

                base.SizeGripStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = FormBorderStyle.None; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MaximizeBox
        {
            get
            {
                return base.MaximizeBox;
            }
            set
            {
                base.MaximizeBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool MinimizeBox
        {
            get
            {
                return base.MinimizeBox;
            }
            set
            {
                base.MinimizeBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool HelpButton
        {
            get
            {
                return base.HelpButton;
            }
            set
            {
                base.HelpButton = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool ControlBox
        {
            get
            {
                return base.ControlBox;
            }
            set
            {
                base.ControlBox = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMargin
        {
            get
            {
                return base.AutoScrollMargin;
            }
            set
            {
                base.AutoScrollMargin = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size AutoScrollMinSize
        {
            get
            {
                return base.AutoScrollMinSize;
            }
            set
            {
                base.AutoScrollMinSize = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 窗体是否激活
        /// </summary>
        private bool _active;
        /// <summary>
        /// 客户区是否按下
        /// </summary>
        private bool isdown = false;
        /// <summary>
        /// 客户区按下坐标
        /// </summary>
        private Point downpoint = Point.Empty;

        /// <summary>
        /// 提示信息
        /// </summary>
        protected static ToolTipExt tte;

        #endregion

        #region 扩展

        /// <summary>
        /// 允许最小化操作
        /// </summary>
        private const int WS_MINIMIZEBOX = 0x00020000;

        /// <summary>
        /// 移动鼠标，按住或释放鼠标时发生
        /// </summary>
        private const int WM_NCHITTEST = 0x84;
        /// <summary>
        /// 此消息发送给窗口当它将要改变大小或位置
        /// </summary>
        private const int WM_GETMINMAXINFO = 0x24;

        /// <summary>
        ///光标的位置
        /// </summary>
        protected internal abstract class NCHITTEST
        {
            /// <summary>
            /// 左边界
            /// </summary>
            public const int HTLEFT = 10;
            /// <summary>
            /// 右边界
            /// </summary>
            public const int HTRIGHT = 11;
            /// <summary>
            /// 上边界
            /// </summary>
            public const int HTTOP = 12;
            /// <summary>
            /// 左上角
            /// </summary>
            public const int HTTOPLEFT = 13;
            /// <summary>
            /// 右上角
            /// </summary>
            public const int HTTOPRIGHT = 14;
            /// <summary>
            /// 下边界
            /// </summary>
            public const int HTBOTTOM = 15;
            /// <summary>
            /// 左下角
            /// </summary>
            public const int HTBOTTOMLEFT = 16;
            /// <summary>
            /// 右下角
            /// </summary>
            public const int HTBOTTOMRIGHT = 17;
        }

        /// <summary>
        /// 窗口状态
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            /// <summary>
            /// 窗口正常状态的坐标
            /// </summary>
            public Point reserved;
            /// <summary>
            /// 设置窗口最大化时的宽度、高度
            /// </summary>
            public Size maxSize;
            /// <summary>
            /// 设置窗口最大化时x坐标、y坐标
            /// </summary>
            public Point maxPosition;
            /// <summary>
            /// 设置窗口最小宽度、高度
            /// </summary>
            public Size minTrackSize;
            /// <summary>
            /// 设置窗口最大宽度、高度
            /// </summary>
            public Size maxTrackSize;
        }

        #endregion

        static FormExt()
        {
            tte = new ToolTipExt();
            tte.BackColor = Color.FromArgb(240, 240, 240);
            tte.ForeColor = Color.FromArgb(109, 109, 109);
        }

        public FormExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(176, 197, 175);
            this.ForeColor = Color.FromArgb(255, 255, 255);

            this.CaptionBox.InitializeControlBox();
        }

        #region 重写

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            this.DrawBackground(g);
            this.DrawBorder(g);
            this.DrawCaption(g);
            this.DrawSizeGrip(g);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this._active = true;
            this.Invalidate();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            this._active = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.CaptionEnabled && this.CaptionBox.Rect.Contains(e.Location))
                {
                    if (this.CaptionBox.ControlBoxRect.Contains(e.Location))
                    {
                        if (this.CaptionBox.CloseBtn.Enabled)
                        {
                            if (this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        if (this.CaptionBox.MaxBtn.Enabled)
                        {
                            if (this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        if (this.CaptionBox.MinBtn.Enabled)
                        {
                            if (this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                            {
                                this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Down;
                            }
                            else
                            {
                                this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                            }
                        }

                        this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                    }
                    else
                    {
                        this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Down;
                        this.isdown = true;
                        this.downpoint = Control.MousePosition;
                    }
                }
                else
                {
                    this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                }

                if (this.MoveEnabled)
                {
                    if (new Rectangle(this.ClientRectangle.X + this.BorderWidth, this.ClientRectangle.Y + this.BorderWidth + this.CaptionBox.Height, this.ClientRectangle.Width - this.BorderWidth * 2, this.ClientRectangle.Height - this.BorderWidth * 2 - this.CaptionBox.Height).Contains(e.Location))
                    {
                        this.isdown = true;
                        this.downpoint = Control.MousePosition;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.CaptionEnabled)
                {
                    if (this.CaptionBox.CloseBtn.Enabled && this.CaptionBox.CloseBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                    {
                        this.HideTip();
                        this.Close();
                        this.CaptionBox.CloseBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                        return;
                    }

                    if (this.CaptionBox.MaxBtn.Enabled && this.CaptionBox.MaxBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                    {
                        if (this.WindowState != FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                        this.CaptionBox.MaxBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                    }

                    if (this.CaptionBox.MinBtn.Enabled && this.CaptionBox.MinBtn.OperateStatus == ControlBoxOperateStatus.Down && this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                    {
                        if (this.WindowState != FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                        this.CaptionBox.MinBtn.OperateStatus = ControlBoxOperateStatus.Normal;
                    }
                }

                this.CaptionBox.OperateStatus = ControlBoxOperateStatus.Normal;
                if (this.MoveEnabled)
                {
                    this.isdown = false;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            bool reset = false;
            string text = "";
            Point tip_point = Point.Empty;

            if (this.CaptionEnabled)
            {
                if (this.CaptionBox.CloseBtn.Enabled)
                {
                    if (this.CaptionBox.CloseBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.CloseBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            text = this.CaptionBox.CloseBtn.TipText1;
                            tip_point = new Point(this.CaptionBox.CloseBtn.Rect.X, this.CaptionBox.CloseBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.CloseBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (this.CaptionBox.MaxBtn.Enabled)
                {
                    if (this.CaptionBox.MaxBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.MaxBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            if (this.WindowState != FormWindowState.Maximized)
                            {
                                text = this.CaptionBox.MaxBtn.TipText1;
                            }
                            else
                            {
                                text = this.CaptionBox.MaxBtn.TipText2;
                            }
                            tip_point = new Point(this.CaptionBox.MaxBtn.Rect.X, this.CaptionBox.MaxBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.MaxBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (this.CaptionBox.MinBtn.Enabled)
                {
                    if (this.CaptionBox.MinBtn.Rect.Contains(e.Location))
                    {
                        if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Normal)
                        {
                            this.CaptionBox.MinBtn.MouseStatus = ControlBoxMouseStatus.Enter;
                            reset = true;
                            text = this.CaptionBox.MinBtn.TipText1;
                            tip_point = new Point(this.CaptionBox.MinBtn.Rect.X, this.CaptionBox.MinBtn.Rect.Bottom + 12);

                        }
                    }
                    else
                    {
                        if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                        {
                            this.CaptionBox.MinBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                            reset = true;
                            tte.Hide(this);
                        }
                    }
                }

                if (reset)
                {
                    this.ShowTip(text, tip_point);
                    this.Invalidate();
                }
            }

            if (this.WindowState != FormWindowState.Maximized && (this.MoveEnabled || this.CaptionBox.OperateStatus == ControlBoxOperateStatus.Down) && this.isdown)
            {
                Point point = new Point(Control.MousePosition.X - this.downpoint.X, Control.MousePosition.Y - this.downpoint.Y);
                this.downpoint = Control.MousePosition;
                this.Location = this.PointToScreen(point);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.CaptionBox.RecoverControlBoxStatus();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left && (this.ResizeType == ResizeTypes.Caption || this.ResizeType == ResizeTypes.CaptionDrag) && this.CaptionBox.Rect.Contains(e.Location) && !this.CaptionBox.ControlBoxRect.Contains(e.Location))
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.CaptionBox.InitializeControlBox();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    this.SetNCHITTEST(ref m);
                    break;
                case WM_GETMINMAXINFO:
                    this.SetMinMaxInfo(ref m);
                    break;
            }

        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 隐藏提示信息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HideTip()
        {
            if (tte.Active)
            {
                tte.Hide(this);
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ShowTip(string text, Point point)
        {
            if (!String.IsNullOrEmpty(text))
            {
                tte.Show(text, this, point);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBackground(Graphics g)
        {
            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.ClientRectangle);
            back_sb.Dispose();

            if (this.BackgroundImage != null)
            {
                int border = this.CaptionEnabled ? this.BorderWidth : 0;
                int caption = this.CaptionEnabled ? this.CaptionBox.Height : 0;
                Rectangle rect = new Rectangle(this.ClientRectangle.X + border, this.ClientRectangle.Y + border, this.ClientRectangle.Width - border * 2, this.ClientRectangle.Height - border * 2);
                if (this.BackgroundImageCaption == false)
                {
                    rect = new Rectangle(this.ClientRectangle.X + border, this.ClientRectangle.Y + border + caption, this.ClientRectangle.Width - border * 2, this.ClientRectangle.Height - border * 2 - caption);
                }

                if (this.BackgroundImageLayout == ImageLayout.Zoom)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    int new_width = image_rect.Width;
                    int new_height = image_rect.Height;

                    if (image_rect.Width < rect.Width && image_rect.Height < rect.Height)
                    {
                        new_width = rect.Width;
                        new_height = (int)(new_width * ((float)image_rect.Height) / (float)image_rect.Width);
                    }
                    if (new_height > rect.Height)
                    {
                        new_height = rect.Height;
                        new_width = (int)(new_height * ((float)image_rect.Width) / (float)image_rect.Height);
                    }
                    if (new_width > rect.Width)
                    {
                        new_width = rect.Width;
                        new_height = (int)(new_width * ((float)image_rect.Height) / (float)image_rect.Width);
                    }
                    if (new_height > rect.Height)
                    {
                        new_height = rect.Height;
                        new_width = (int)(new_height * ((float)image_rect.Width) / (float)image_rect.Height);
                    }
                    image_rect = new Rectangle(0, 0, new_width, new_height);
                    Rectangle rect_tmp = new Rectangle(rect.X + (rect.Width - image_rect.Width) / 2, rect.Y + (rect.Height - image_rect.Height) / 2, image_rect.Width, image_rect.Height);
                    g.DrawImage(this.BackgroundImage, rect_tmp);
                }
                else if (this.BackgroundImageLayout == ImageLayout.Center)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    Rectangle rect_tmp = new Rectangle(rect.X + (rect.Width - image_rect.Width) / 2, rect.Y + (rect.Height - image_rect.Height) / 2, image_rect.Width, image_rect.Height);
                    g.DrawImage(this.BackgroundImage, rect_tmp);
                }
                else if (this.BackgroundImageLayout == ImageLayout.Tile)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    TextureBrush back_tb = new TextureBrush(this.BackgroundImage, image_rect);
                    g.FillRectangle(back_tb, rect);
                    back_tb.Dispose();
                }
                else if (this.BackgroundImageLayout == ImageLayout.Stretch)
                {
                    Rectangle image_rect = new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    g.DrawImage(this.BackgroundImage, rect, image_rect, GraphicsUnit.Pixel);
                }
                else if (this.BackgroundImageLayout == ImageLayout.None)
                {
                    g.DrawImage(this.BackgroundImage, rect.Location);
                }

            }

        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="g"></param>
        private void DrawBorder(Graphics g)
        {
            if (this.CaptionEnabled)
            {
                Pen border_pen = new Pen(this.BorderColor);
                Rectangle rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                g.DrawRectangle(border_pen, rect);
                border_pen.Dispose();
            }
        }

        /// <summary>
        /// 绘制标题栏
        /// </summary>
        /// <param name="g"></param>
        private void DrawCaption(Graphics g)
        {
            if (this.CaptionEnabled)
            {
                if (this.CaptionBox.BackColor != Color.Empty)
                {
                    SolidBrush border_sb = new SolidBrush(this._active || this.DesignMode ? this.CaptionBox.BackColor : Color.FromArgb(100, this.CaptionBox.BackColor));
                    Rectangle rect = new Rectangle(this.ClientRectangle.X + this.BorderWidth, this.ClientRectangle.Y + this.BorderWidth, this.ClientRectangle.Width - this.BorderWidth * 2, this.CaptionBox.Height);
                    g.FillRectangle(border_sb, rect);
                    border_sb.Dispose();
                }

                DrawControlBox(g);

                if (this.ShowIcon && this.Icon != null)
                {
                    InterpolationMode interpolationMode = g.InterpolationMode;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawIcon(this.Icon, this.CaptionBox.IconRect);
                    g.InterpolationMode = interpolationMode;
                }

                if (!String.IsNullOrEmpty(this.Text))
                {
                    StringFormat text_sf = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
                    SolidBrush text_sb = new SolidBrush(this.ForeColor);
                    SizeF text_size = g.MeasureString(this.Text, this.Font, 1000, text_sf);

                    int w = (int)text_size.Width + 2;
                    if (w > (int)(this.ClientRectangle.Width - (this.ShowIcon ? this.CaptionBox.IconRect.Right : 2) - this.CaptionBox.ControlBoxRect.Width - 2))
                    {
                        w = (int)(this.ClientRectangle.Width - (this.ShowIcon ? this.CaptionBox.IconRect.Right : 2) - this.CaptionBox.ControlBoxRect.Width - 2);
                    }

                    int x = 0;
                    int y = (int)(this.ClientRectangle.Y + this.BorderWidth + (this.CaptionBox.Height - text_size.Height) / 2);
                    Rectangle text_rect = Rectangle.Empty;
                    if (this.TextOrientation == TextOrientations.Left)
                    {
                        x = (int)(this.ShowIcon ? this.CaptionBox.IconRect.Right : this.ClientRectangle.X + 2);
                    }
                    else if (this.TextOrientation == TextOrientations.Center)
                    {
                        x = (int)(this.ClientRectangle.Width - text_size.Width) / 2;
                        if (x + text_size.Width > this.CaptionBox.ControlBoxRect.Left)
                        {
                            x = (int)(this.CaptionBox.ControlBoxRect.Left - text_size.Width);
                        }
                    }
                    else if (this.TextOrientation == TextOrientations.Right)
                    {
                        x = (int)(this.CaptionBox.ControlBoxRect.Left - text_size.Width);
                    }
                    text_rect = new Rectangle(x, y, w, (int)text_size.Width);

                    g.DrawString(this.Text, this.Font, text_sb, text_rect, text_sf);

                    text_sb.Dispose();
                    text_sf.Dispose();
                }
            }
        }

        /// <summary>
        /// 绘制标题栏按钮
        /// </summary>
        /// <param name="g"></param>
        private void DrawControlBox(Graphics g)
        {

            if (this.CaptionBox.CloseBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.CloseBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.CloseBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.CloseBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.CloseBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.CloseBtn.NormalForeColor);
                }
                else if (this.CaptionBox.CloseBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.CloseBtn.EnterBackColor;
                    textcolor = this.CaptionBox.CloseBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, 1);
                g.FillRectangle(back_sb, this.CaptionBox.CloseBtn.Rect);

                int width = this.CaptionBox.CloseBtn.Rect.Width / 10 * 8;
                int x1 = this.CaptionBox.CloseBtn.Rect.X + (this.CaptionBox.CloseBtn.Rect.Width - width) / 2;
                int y1 = this.CaptionBox.CloseBtn.Rect.Y + (this.CaptionBox.CloseBtn.Rect.Height - width) / 2;
                int x2 = this.CaptionBox.CloseBtn.Rect.X + width + (this.CaptionBox.CloseBtn.Rect.Width - width) / 2;
                int y2 = this.CaptionBox.CloseBtn.Rect.Y + width + (this.CaptionBox.CloseBtn.Rect.Height - width) / 2;

                g.DrawLine(text_pen, new Point(x1, y1), new Point(x2, y2));
                g.DrawLine(text_pen, new Point(x1 + width, y1), new Point(x2 - width, y2));

                back_sb.Dispose();
                text_pen.Dispose();
            }

            if (this.CaptionBox.MaxBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.MaxBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.MaxBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.MaxBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.MaxBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.MaxBtn.NormalForeColor);
                }
                else if (this.CaptionBox.MaxBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.MaxBtn.EnterBackColor;
                    textcolor = this.CaptionBox.MaxBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, 1);
                g.FillRectangle(back_sb, this.CaptionBox.MaxBtn.Rect);

                int width = this.CaptionBox.MaxBtn.Rect.Width / 10 * 8;
                int height = this.CaptionBox.MaxBtn.Rect.Width / 10 * 8;

                if (this.WindowState != FormWindowState.Maximized)
                {
                    int x1 = this.CaptionBox.MaxBtn.Rect.X + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;
                    int y1 = this.CaptionBox.MaxBtn.Rect.Y + (this.CaptionBox.MaxBtn.Rect.Height - height) / 2;
                    int x2 = this.CaptionBox.MaxBtn.Rect.X + width + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;

                    g.DrawRectangle(text_pen, new Rectangle(x1, y1, width, height));
                    g.DrawLine(text_pen, new Point(x1 + 1, y1 + 1), new Point(x2 - 1, y1 + 1));
                    g.DrawLine(text_pen, new Point(x1 + 1, y1 + 2), new Point(x2 - 1, y1 + 2));
                }
                else
                {
                    int len = 2;
                    width -= len;
                    height -= len;
                    int x1 = this.CaptionBox.MaxBtn.Rect.X + (this.CaptionBox.MaxBtn.Rect.Width - width) / 2;
                    int y1 = this.CaptionBox.MaxBtn.Rect.Y + (this.CaptionBox.MaxBtn.Rect.Height - height) / 2;
                    g.DrawRectangle(text_pen, new Rectangle(x1, y1, width, height));
                    g.DrawLine(text_pen, new Point(x1 + len, y1 - 1), new Point(x1 + len, y1 - len));
                    g.DrawLine(text_pen, new Point(x1 + len + 1, y1 - len), new Point(x1 + len + width, y1 - len));
                    g.DrawLine(text_pen, new Point(x1 + len + width, y1 - len + 1), new Point(x1 + len + width, y1 - len + height - 1));
                    g.DrawLine(text_pen, new Point(x1 + len + width, y1 - len + height), new Point(x1 + width + 1, y1 - len + height));
                }

                back_sb.Dispose();
                text_pen.Dispose();
            }

            if (this.CaptionBox.MinBtn.Enabled)
            {
                Color backcolor = this.CaptionBox.MinBtn.NormalBackColor;
                Color textcolor = this.CaptionBox.MinBtn.NormalForeColor;

                if (this._active == false && this.DesignMode == false)
                {
                    backcolor = this.CaptionBox.MinBtn.NormalBackColor == Color.Empty ? Color.Empty : Color.FromArgb(100, this.CaptionBox.MinBtn.NormalBackColor);
                    textcolor = Color.FromArgb(100, this.CaptionBox.MinBtn.NormalForeColor);
                }
                else if (this.CaptionBox.MinBtn.MouseStatus == ControlBoxMouseStatus.Enter)
                {
                    backcolor = this.CaptionBox.MinBtn.EnterBackColor;
                    textcolor = this.CaptionBox.MinBtn.EnterForeColor;
                }

                SolidBrush back_sb = new SolidBrush(backcolor);
                Pen text_pen = new Pen(textcolor, 1);
                g.FillRectangle(back_sb, this.CaptionBox.MinBtn.Rect);

                int width = this.CaptionBox.MaxBtn.Rect.Width / 10 * 8;
                int x1 = this.CaptionBox.MinBtn.Rect.X + (this.CaptionBox.MinBtn.Rect.Width - width) / 2;
                int x2 = this.CaptionBox.MinBtn.Rect.X + width + (this.CaptionBox.MinBtn.Rect.Width - width) / 2;

                g.DrawLine(text_pen, new Point(x1, this.CaptionBox.MinBtn.Rect.Height / 5 * 3), new Point(x2, this.CaptionBox.MinBtn.Rect.Height / 5 * 3));

                back_sb.Dispose();
                text_pen.Dispose();
            }

        }

        /// <summary>
        /// 绘制标手柄
        /// </summary>
        /// <param name="g"></param>
        private void DrawSizeGrip(Graphics g)
        {
            if (this.SizeGripStyle == SizeGripStyle.Show && this.WindowState != FormWindowState.Maximized)
            {
                int rect_size = 12;
                int size = 2;
                int pd = 2;
                Rectangle rect = new Rectangle(this.ClientRectangle.Right - this.BorderWidth - rect_size, this.ClientRectangle.Bottom - this.BorderWidth - rect_size, rect_size, rect_size);
                Pen grip_pen = new Pen(this.SizeGripColor, 2);

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size), new Point(rect.Right - pd, rect.Bottom - pd - size));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 3, rect.Bottom - pd - size), new Point(rect.Right - pd - size * 2, rect.Bottom - pd - size));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 5, rect.Bottom - pd - size), new Point(rect.Right - pd - size * 4, rect.Bottom - pd - size));

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size * 3), new Point(rect.Right - pd, rect.Bottom - pd - size * 3));
                g.DrawLine(grip_pen, new Point(rect.Right - pd - size * 3, rect.Bottom - pd - size * 3), new Point(rect.Right - pd - size * 2, rect.Bottom - pd - size * 3));

                g.DrawLine(grip_pen, new Point(rect.Right - pd - size, rect.Bottom - pd - size * 5), new Point(rect.Right - pd, rect.Bottom - pd - size * 5));
            }
        }

        /// <summary>
        /// 更新所有子控件坐标
        /// </summary>
        private void UpdateChildrenControls()
        {
            int x = this.CaptionEnabled ? this.BorderWidth : this.BorderWidth;
            int y = this.CaptionEnabled ? this.BorderWidth + this.CaptionBox.Height : -(this.BorderWidth + this.CaptionBox.Height);
            foreach (Control control in this.Controls)
            {
                control.Location = new Point(control.Location.X + x, control.Location.Y + y);
            }
        }

        /// <summary>
        /// 设置窗体鼠标NCHITTEST状态
        /// </summary>
        /// <param name="m"></param>
        private void SetNCHITTEST(ref Message m)
        {
            Point point = new Point(WindowNavigate.LOWORD(m.LParam), WindowNavigate.HIWORD(m.LParam));
            point = PointToClient(point);

            if (this.WindowState != FormWindowState.Maximized)
            {
                if (this.ResizeType == ResizeTypes.Drag || this.ResizeType == ResizeTypes.CaptionDrag)
                {
                    if (point.X < 5 && point.Y < 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTTOPLEFT);
                    }
                    else if (point.X > this.ClientSize.Width - 5 && point.Y < 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTTOPRIGHT);
                    }
                    else if (point.X < 5 && point.Y > this.ClientSize.Height - 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTBOTTOMLEFT);
                    }
                    else if (point.X > this.ClientSize.Width - 5 && point.Y > this.ClientSize.Height - 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTBOTTOMRIGHT);
                    }
                    else if (point.Y < 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTTOP);
                    }
                    else if (point.Y > this.ClientSize.Height - 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTBOTTOM);
                    }
                    else if (point.X < 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTLEFT);
                    }
                    else if (point.X > this.ClientSize.Width - 5)
                    {
                        m.Result = new IntPtr(NCHITTEST.HTRIGHT);
                    }
                    else if (point.X >= this.ClientSize.Width - this.BorderWidth - 12 && point.Y >= this.ClientSize.Height - this.BorderWidth - 12)
                    {
                        if (this.SizeGripStyle == SizeGripStyle.Show && this.WindowState != FormWindowState.Maximized)
                        {
                            m.Result = new IntPtr(NCHITTEST.HTBOTTOMRIGHT);
                            return;
                        }
                    }

                }
            }

        }

        /// <summary>
        /// 设置窗体MINMAXINFO
        /// </summary>
        /// <param name="m"></param>
        private void SetMinMaxInfo(ref Message m)
        {
            MINMAXINFO minmax = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));

            if (MaximumSize != Size.Empty)
            {
                minmax.maxTrackSize = MaximumSize;
            }
            else
            {
                if (this.CaptionEnabled)
                {
                    if (this.Parent == null)
                    {
                        Rectangle rect = Screen.GetWorkingArea(this);
                        minmax.maxTrackSize = new Size(rect.Width + this.BorderWidth * 2, rect.Height + this.BorderWidth * 2);
                        minmax.maxPosition = new Point(rect.X - this.BorderWidth, rect.Y - this.BorderWidth);
                        minmax.maxSize = new Size(rect.Width + this.BorderWidth * 2, rect.Height + this.BorderWidth * 2);
                    }
                    else
                    {
                        Rectangle rect = this.Parent.ClientRectangle;
                        minmax.maxTrackSize = new Size(rect.Width + this.BorderWidth * 2, rect.Height + this.BorderWidth * 2);
                        minmax.maxPosition = new Point(rect.X - this.BorderWidth, rect.Y - this.BorderWidth);
                        minmax.maxSize = new Size(rect.Width + this.BorderWidth * 2, rect.Height + this.BorderWidth * 2);
                    }
                }
                else
                {
                    if (this.Parent == null)
                    {
                        Rectangle rect = Screen.GetWorkingArea(this);
                        minmax.maxTrackSize = new Size(rect.Width, rect.Height);
                        minmax.maxPosition = new Point(rect.X, rect.Y);
                        minmax.maxSize = new Size(rect.Width, rect.Height);
                    }
                    else if (this.Parent != null)
                    {
                        Rectangle rect = this.Parent.ClientRectangle;
                        minmax.maxTrackSize = new Size(rect.Width, rect.Height);
                        minmax.maxPosition = new Point(rect.X, rect.Y);
                        minmax.maxSize = new Size(rect.Width, rect.Height);
                    }
                }
            }

            if (MinimumSize != Size.Empty)
            {
                minmax.minTrackSize = MinimumSize;
            }
            else
            {
                int x = this.ClientRectangle.Right - 2 - this.CaptionBox.CloseBtn.Rect.Width;
                if (this.CaptionBox.CloseBtn.Enabled)
                {
                    x -= this.CaptionBox.CloseBtn.Rect.Width;
                }
                if (this.CaptionBox.MaxBtn.Enabled)
                {
                    x -= this.CaptionBox.MaxBtn.Rect.Width;
                }
                if (this.CaptionBox.MinBtn.Enabled)
                {
                    x -= this.CaptionBox.MinBtn.Rect.Width;
                }
                minmax.minTrackSize = new Size((this.ClientRectangle.Right - 2) - x + this.BorderWidth * 2, this.CaptionBox.Height + this.BorderWidth * 2);
            }

            Marshal.StructureToPtr(minmax, m.LParam, false);
        }

        #endregion

        #region 类

        /// <summary>
        /// 标题栏
        /// </summary>
        [Description("标题栏")]
        [TypeConverter(typeof(EmptyConverter))]
        public class CaptionBoxClass
        {
            #region 字段
            private FormExt owner = null;
            #endregion

            #region 属性

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// Rect
            /// </summary>
            [Description("Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle Rect
            {
                get
                {
                    return this.rect;
                }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private ControlBoxOperateStatus operateStatus = ControlBoxOperateStatus.Normal;
            /// <summary>
            /// 操作状态
            /// </summary>
            [Description("操作状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxOperateStatus OperateStatus
            {
                get { return this.operateStatus; }
                set
                {
                    if (this.operateStatus == value)
                        return;

                    this.operateStatus = value;
                }
            }

            private ControlBoxButton closeBtn = null;
            /// <summary>
            /// 关闭按钮
            /// </summary>
            [Description("关闭按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton CloseBtn
            {
                get { return this.closeBtn; }
            }

            private ControlBoxButton maxBtn = null;
            /// <summary>
            /// 最大化按钮
            /// </summary>
            [Description("最大化按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton MaxBtn
            {
                get { return this.maxBtn; }
            }

            private ControlBoxButton minBtn = null;
            /// <summary>
            /// 最小化按钮
            /// </summary>
            [Description("最小化按钮")]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ControlBoxButton MinBtn
            {
                get { return this.minBtn; }
            }

            private int height = 24;
            /// <summary>
            /// 标题栏高度
            /// </summary>
            [Description("标题栏高度")]
            [DefaultValue(24)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public int Height
            {
                get
                {
                    return this.height;
                }
                set
                {
                    if (this.height == value || value < this.owner.BorderWidth)
                        return;

                    this.height = value;
                    this.InitializeControlBox();
                }
            }

            private Color backColor = Color.Empty;
            /// <summary>
            /// 标题栏颜色
            /// </summary>
            [Description("标题栏颜色")]
            [DefaultValue(typeof(Color), "Empty")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public Color BackColor
            {
                get
                {
                    return this.backColor;
                }
                set
                {
                    if (this.backColor == value)
                        return;

                    this.backColor = value;
                    this.owner.Invalidate();
                }
            }

            private int buttonSize = 18;
            /// <summary>
            /// 按钮Size
            /// </summary>
            [Description("按钮Size")]
            [DefaultValue(18)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public int ButtonSize
            {
                get { return this.buttonSize; }
                set
                {
                    if (this.buttonSize == value)
                        return;

                    this.buttonSize = value;
                    this.InitializeControlBox();
                }
            }

            private Rectangle iconRect = Rectangle.Empty;
            /// <summary>
            /// 图标Rect
            /// </summary>
            [Description("图标Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle IconRect
            {
                get { return this.iconRect; }
                set
                {
                    if (this.iconRect == value)
                        return;

                    this.iconRect = value;
                }
            }

            private Rectangle controlBoxRect = Rectangle.Empty;
            /// <summary>
            /// 按钮组Rect
            /// </summary>
            [Description("按钮组Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle ControlBoxRect
            {
                get { return this.controlBoxRect; }
                set
                {
                    if (this.controlBoxRect == value)
                        return;

                    this.controlBoxRect = value;
                }
            }

            #endregion

            public CaptionBoxClass(FormExt owner)
            {
                this.owner = owner;
                this.closeBtn = new ControlBoxButton(this) { TipText1 = "关闭", TipText2 = "关闭" };
                this.maxBtn = new ControlBoxButton(this) { TipText1 = "最大化", TipText2 = "向下还原" };
                this.minBtn = new ControlBoxButton(this) { TipText1 = "最小化", TipText2 = "最小化" };
            }

            #region 公开方法

            /// <summary>
            /// 初始化按钮信息
            /// </summary>
            public void InitializeControlBox()
            {
                if (this.owner.CaptionEnabled == false)
                    return;


                int right = 2;
                Rectangle rect = this.owner.ClientRectangle;
                this.Rect = new Rectangle(rect.X + this.owner.BorderWidth, rect.Y + this.owner.BorderWidth, rect.Width - this.owner.BorderWidth * 2, this.Height);
                Rectangle controlBox_rect = new Rectangle(rect.X + this.owner.BorderWidth, rect.Y + this.owner.BorderWidth, rect.Width - this.owner.BorderWidth * 2, this.Height);
                int t = controlBox_rect.Y + this.owner.BorderWidth;
                int r = controlBox_rect.Right - right;

                int size = this.ButtonSize;
                int with_sum = 0;
                if (size > (this.Height - this.owner.BorderWidth))
                {
                    size = (this.Height - this.owner.BorderWidth);
                }

                if (this.CloseBtn.Enabled)
                {
                    this.CloseBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.CloseBtn.Rect.Left;
                    with_sum += size;
                }
                if (this.MaxBtn.Enabled)
                {
                    this.MaxBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.MaxBtn.Rect.Left;
                    with_sum += size;
                }
                if (this.MinBtn.Enabled)
                {
                    this.MinBtn.Rect = new Rectangle(r - size, t, size, size);
                    r = this.MinBtn.Rect.Left;
                    with_sum += size;
                }
                this.ControlBoxRect = new Rectangle(r, t, with_sum, size);

                if (this.owner.ShowIcon)
                {
                    this.IconRect = new Rectangle(2, rect.Y + this.owner.BorderWidth + (this.Height - size) / 2, size, size);
                }

                this.owner.Invalidate();
            }

            /// <summary>
            /// 还原按钮默认鼠标状态
            /// </summary>
            public void RecoverControlBoxStatus()
            {
                bool reset = false;
                if (this.CloseBtn.Enabled && this.CloseBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.CloseBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                if (this.MaxBtn.Enabled && this.MaxBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.MaxBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                if (this.MinBtn.Enabled && this.MinBtn.MouseStatus != ControlBoxMouseStatus.Normal)
                {
                    this.MinBtn.MouseStatus = ControlBoxMouseStatus.Normal;
                    reset = true;
                }
                this.OperateStatus = ControlBoxOperateStatus.Normal;
                if (reset)
                {
                    this.owner.Invalidate();
                    this.owner.HideTip();
                }
            }

            #endregion

        }

        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ControlBoxButton
        {
            #region 字段

            private CaptionBoxClass owner = null;

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用按钮
            /// </summary>
            [Description("是否启用按钮")]
            [DefaultValue(true)]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.owner.InitializeControlBox();
                }
            }

            private string tipText1 = "";
            /// <summary>
            /// 按钮提示文本1
            /// </summary>
            [Description("按钮提示文本1")]
            [DefaultValue("")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public string TipText1
            {
                get { return this.tipText1; }
                set
                {
                    if (this.tipText1 == value)
                        return;

                    this.tipText1 = value;
                }
            }

            private string tipText2 = "";
            /// <summary>
            /// 按钮提示文本2
            /// </summary>
            [Description("按钮提示文本2")]
            [DefaultValue("")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            public string TipText2
            {
                get { return this.tipText2; }
                set
                {
                    if (this.tipText2 == value)
                        return;

                    this.tipText2 = value;
                }
            }

            private ControlBoxMouseStatus mouseStatus = ControlBoxMouseStatus.Normal;
            /// <summary>
            /// 按钮鼠标状态
            /// </summary>
            [Description("按钮鼠标状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxMouseStatus MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            private ControlBoxOperateStatus operateStatus = ControlBoxOperateStatus.Normal;
            /// <summary>
            /// 按钮操作状态
            /// </summary>
            [Description("按钮操作状态")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ControlBoxOperateStatus OperateStatus
            {
                get { return this.operateStatus; }
                set
                {
                    if (this.operateStatus == value)
                        return;

                    this.operateStatus = value;
                }
            }

            private Rectangle rect = Rectangle.Empty;
            /// <summary>
            /// 按钮Rect
            /// </summary>
            [Description("按钮Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Rectangle Rect
            {
                get
                {
                    return this.rect;
                }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private Color normalBackColor = Color.Empty;
            /// <summary>
            /// 按钮背景颜色（默认）
            /// </summary>
            [Description("按钮背景颜色（默认）")]
            [DefaultValue(typeof(Color), "Empty")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalBackColor
            {
                get
                {
                    return this.normalBackColor;
                }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                }
            }

            private Color normalForeColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 按钮前景颜色（默认）
            /// </summary>
            [Description("按钮前景颜色（默认）")]
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalForeColor
            {
                get
                {
                    return this.normalForeColor;
                }
                set
                {
                    if (this.normalForeColor == value)
                        return;

                    this.normalForeColor = value;
                }
            }

            private Color enterBackColor = Color.FromArgb(100, 255, 255, 255);
            /// <summary>
            /// 按钮背景颜色（鼠标进入）
            /// </summary>
            [Description("按钮背景颜色（鼠标进入）")]
            [DefaultValue(typeof(Color), "100, 255,255,255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterBackColor
            {
                get
                {
                    return this.enterBackColor;
                }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                }
            }

            private Color enterForeColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 按钮前景颜色（鼠标进入）
            /// </summary>
            [Description("按钮前景颜色（鼠标进入）")]
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterForeColor
            {
                get
                {
                    return this.enterForeColor;
                }
                set
                {
                    if (this.enterForeColor == value)
                        return;

                    this.enterForeColor = value;
                }
            }

            #endregion

            public ControlBoxButton(CaptionBoxClass owner)
            {
                this.owner = owner;
            }

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 标题栏按钮鼠标状态
        /// </summary>
        [Description("标题栏按钮鼠标状态")]
        public enum ControlBoxMouseStatus
        {
            /// <summary>
            /// 默认
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter
        }

        /// <summary>
        /// 标题栏按钮操作状态
        /// </summary>
        [Description("标题栏按钮操作状态")]
        public enum ControlBoxOperateStatus
        {
            /// <summary>
            /// 默认
            /// </summary>
            Normal,
            /// <summary>
            /// 按下
            /// </summary>
            Down
        }

        /// <summary>
        /// 标题文本方位
        /// </summary>
        [Description("标题文本方位")]
        public enum TextOrientations
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 居中
            /// </summary>
            Center,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 放大缩小模式
        /// </summary>
        [Description("放大缩小模式")]
        public enum ResizeTypes
        {
            /// <summary>
            /// 无缩放
            /// </summary>
            NoResize,
            /// <summary>
            /// 鼠标拖动
            /// </summary>
            Drag,
            /// <summary>
            /// 标题栏双击
            /// </summary>
            Caption,
            /// <summary>
            /// 鼠标拖动、标题栏双击
            /// </summary>
            CaptionDrag
        }

        #endregion
    }

    /// <summary>
    /// 扁平化窗体基类接口
    /// </summary>
    [Description("扁平化窗体基类接口")]
    public interface IFormExt
    {

    }

}
