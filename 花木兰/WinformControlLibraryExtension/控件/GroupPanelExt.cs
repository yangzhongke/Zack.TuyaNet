
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    ///  GroupPanel扩展
    /// </summary>
    [ToolboxItem(true)]
    [Description("GroupPanel扩展")]
    public class GroupPanelExt : ScrollableControl
    {
        #region 停用事件

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

        #region 边框

        private Color borderColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        #endregion

        #region 标题

        private string title = "标题";
        /// <summary>
        /// 标题
        /// </summary>
        [DefaultValue("标题")]
        [Description("标题")]
        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title == value)
                    return;
                this.title = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        private TitleAligns titleAlign = TitleAligns.Left;
        /// <summary>
        /// 标题方向
        /// </summary>
        [DefaultValue(TitleAligns.Left)]
        [Description("标题方向")]
        public TitleAligns TitleAlign
        {
            get { return this.titleAlign; }
            set
            {
                if (this.titleAlign == value)
                    return;
                this.titleAlign = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        private Font titleFont = new Font("宋体", 10);
        /// <summary>
        /// 标题字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("标题字体")]
        public Font TitleFont
        {
            get { return this.titleFont; }
            set
            {
                if (this.titleFont == value)
                    return;
                this.titleFont = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        private Color titleBackColor = Color.FromArgb(153, 204, 153);
        /// <summary>
        /// 标题背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "153, 204, 153")]
        [Description("标题背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TitleBackColor
        {
            get { return this.titleBackColor; }
            set
            {
                if (this.titleBackColor == value)
                    return;
                this.titleBackColor = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        private Color titleTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 标题文本颜色
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("标题文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TitleTextColor
        {
            get { return this.titleTextColor; }
            set
            {
                if (this.titleTextColor == value)
                    return;
                this.titleTextColor = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        private Image titleImage = null;
        /// <summary>
        /// 标题图片
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("标题图片")]
        public Image TitleImage
        {
            get { return this.titleImage; }
            set
            {
                if (this.titleImage == value)
                    return;
                this.titleImage = value;
                this.Send_WM_NCPAINT_Message();
            }
        }

        #endregion

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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 100);
            }
        }

        protected override Padding DefaultMargin
        {
            get
            {
                return new Padding(0);
            }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(0);
            }
        }

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

        #endregion

        #region 字段

        /// <summary>
        ///边框
        /// </summary>
        public int border = 2;

        /// <summary>
        /// 标题高度
        /// </summary>
        private int titleHeight = 26;

        #endregion

        #region 扩展

        /// <summary>
        /// 当某个窗口的客户区域必须被核算时发送此消息   
        /// </summary>
        private const int WM_NCCALCSIZE = 0x0083;
        /// <summary>
        /// 程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时   
        /// </summary>
        private const int WM_NCPAINT = 0x85;
        /// <summary>
        /// 此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态 
        /// </summary>
        private const int WM_NCACTIVATE = 0x86;

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public struct NCCALCSIZE_PARAMS
        {
            /// <summary>
            /// 在移动或改变大小后的新坐标
            /// </summary>
            public RECT ncNewRectangle;
            /// <summary>
            /// 在移动或改变大小前的坐标
            /// </summary>
            public RECT ncOldRectangle;
            /// <summary>
            /// 移动或改变大小前的客户区坐标
            /// </summary>
            public RECT ncOldClientRectangle;
            public IntPtr lppos;
        }

        #endregion

        public GroupPanelExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);
        }

        #region 重写

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCCALCSIZE:
                    {
                        if (m.WParam != IntPtr.Zero)
                        {
                            NCCALCSIZE_PARAMS ncsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                            ncsize.ncOldClientRectangle.Top = ncsize.ncNewRectangle.Top += this.titleHeight;
                            ncsize.ncOldClientRectangle.Left = ncsize.ncNewRectangle.Left += this.border;
                            ncsize.ncOldClientRectangle.Right = ncsize.ncNewRectangle.Right -= this.border;
                            ncsize.ncOldClientRectangle.Bottom = ncsize.ncNewRectangle.Bottom -= this.border;
                            Marshal.StructureToPtr(ncsize, m.LParam, false);
                        }
                        else
                        {
                            RECT ncsize = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                            ncsize.Top += this.titleHeight;
                            ncsize.Left += this.border;
                            ncsize.Right -= this.border;
                            ncsize.Bottom -= this.border;
                            Marshal.StructureToPtr(ncsize, m.LParam, false);
                        }

                        this.Send_WM_NCPAINT_Message();
                        return;
                    }
                case WM_NCPAINT:
                case WM_NCACTIVATE:
                    {
                        this.NCInvalidate();
                        return;
                    }
            }
            base.WndProc(ref m);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Math.Max(width, this.border * 2), Math.Max(height, this.titleHeight + this.border), specified);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(x + this.border * 2, y + this.titleHeight + this.border);
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 绘制非工作区域
        /// </summary>
        protected virtual void OnNCPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            #region 边框
            if (this.border > 0)
            {
                Pen border_pen = new Pen(this.BorderColor, this.border);
                g.DrawLine(border_pen, new PointF(g.VisibleClipBounds.X, g.VisibleClipBounds.Bottom - this.border / 2), new PointF(g.VisibleClipBounds.Right, g.VisibleClipBounds.Bottom - this.border / 2));
                g.DrawLine(border_pen, new PointF(g.VisibleClipBounds.X + this.border / 2, g.VisibleClipBounds.Y + this.titleHeight), new PointF(g.VisibleClipBounds.X + this.border / 2, g.VisibleClipBounds.Bottom));
                g.DrawLine(border_pen, new PointF(g.VisibleClipBounds.Right - this.border / 2, g.VisibleClipBounds.Y + this.titleHeight), new PointF(g.VisibleClipBounds.Right - this.border / 2, g.VisibleClipBounds.Bottom));
                border_pen.Dispose();
            }
            #endregion

            #region 标题
            SolidBrush title_back_sb = new SolidBrush(this.TitleBackColor);
            RectangleF title_rect = new RectangleF(g.VisibleClipBounds.X, g.VisibleClipBounds.Y, g.VisibleClipBounds.Width, this.titleHeight);
            g.FillRectangle(title_back_sb, title_rect);
            title_back_sb.Dispose();

            #region 标题图标
            if (this.TitleImage != null)
            {
                int image_w = this.TitleImage.Width;
                int image_h = this.TitleImage.Height;
                g.DrawImage(this.TitleImage, new RectangleF(g.VisibleClipBounds.X + this.border, g.VisibleClipBounds.Y + (this.titleHeight - image_h) / 2, image_w, image_h));
            }
            #endregion

            #region 标题文本
            if (!String.IsNullOrWhiteSpace(Title))
            {
                SolidBrush title_text_sb = new SolidBrush(this.TitleTextColor);
                SizeF text_size = g.MeasureString(this.Title, this.TitleFont);
                RectangleF text_rect = RectangleF.Empty;
                if (this.TitleAlign == TitleAligns.Left)
                {
                    int image_w = this.TitleImage == null ? 0 : this.TitleImage.Width;
                    text_rect = new RectangleF(g.VisibleClipBounds.X + this.border + image_w + 5, g.VisibleClipBounds.Y + (this.titleHeight - text_size.Height) / 2f, text_size.Width, text_size.Height);
                }
                else if (this.TitleAlign == TitleAligns.Center)
                {
                    text_rect = new RectangleF(g.VisibleClipBounds.X + (g.VisibleClipBounds.Width - text_size.Width) / 2f, g.VisibleClipBounds.Y + (this.titleHeight - text_size.Height) / 2f, text_size.Width, text_size.Height);
                }
                else
                {
                    text_rect = new RectangleF(g.VisibleClipBounds.Right - text_size.Width - this.border, g.VisibleClipBounds.Y + (this.titleHeight - text_size.Height) / 2f, text_size.Width, text_size.Height);
                }
                g.DrawString(this.Title, this.TitleFont, title_text_sb, text_rect);
                title_text_sb.Dispose();
            }
            #endregion

            #endregion

        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 重新绘制非工作区
        /// </summary>
        private void NCInvalidate()
        {
            IntPtr hDC = WindowNavigate.GetWindowDC(this.Handle);
            Graphics g = Graphics.FromHdc(hDC);
            this.OnNCPaint(new PaintEventArgs(g, new Rectangle(0, 0, this.Width, this.Height)));
            g.Dispose();
            WindowNavigate.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// 发送非工作区绘制信息
        /// </summary>
        private void Send_WM_NCPAINT_Message()
        {
            WindowNavigate.SendMessage(this.Handle, WM_NCPAINT, (IntPtr)1, (IntPtr)0);
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 标题方向
        /// </summary>
        [Description("标题方向")]
        public enum TitleAligns
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right,
            /// <summary>
            /// 居中
            /// </summary>
            Center
        }

        #endregion

    }
}
