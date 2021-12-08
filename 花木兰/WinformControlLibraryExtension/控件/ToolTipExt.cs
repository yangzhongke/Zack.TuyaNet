
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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// ToolTip美化扩展
    /// </summary>
    [ToolboxItem(true)]
    [Description("ToolTip美化扩展")]
    [DefaultProperty("TitleShow")]
    [DefaultEvent("Popup")]
    public class ToolTipExt : ToolTip
    {
        #region 新增属性

        #region

        private ToolTipAnchor toolAnchor = ToolTipAnchor.TopCenter;
        /// <summary>
        /// 提示框位置
        /// </summary>
        [Browsable(false)]
        [DefaultValue(ToolTipAnchor.TopCenter)]
        [Description("提示框位置")]
        public ToolTipAnchor ToolAnchor
        {
            get { return this.toolAnchor; }
            set
            {
                if (this.toolAnchor == value)
                    return;
                this.toolAnchor = value;
            }
        }

        private int anchorDistance = 20;
        /// <summary>
        /// 提示框位置距离
        /// </summary>
        [DefaultValue(20)]
        [Description("提示框位置距离")]
        public int AnchorDistance
        {
            get { return this.anchorDistance; }
            set
            {
                if (this.anchorDistance == value || value < 0)
                    return;
                this.anchorDistance = value;
            }
        }

        private int padding = 3;
        /// <summary>
        /// 内边距
        /// </summary>
        [DefaultValue(3)]
        [Description("内边距")]
        public int Padding
        {
            get { return this.padding; }
            set
            {
                if (this.padding == value || value < 0)
                    return;
                this.padding = value;
            }
        }

        private Size minSize = new Size(20, 10);
        /// <summary>
        /// 内容最小大小
        /// </summary>
        [DefaultValue(typeof(Size), "20,10")]
        [Description("内容最小大小")]
        public Size MinSize
        {
            get { return this.minSize; }
            set
            {
                if (this.minSize == value || value.Width < 0 || value.Height < 0)
                    return;
                this.minSize = value;
            }
        }

        private Size maxSize = new Size(0, 0);
        /// <summary>
        /// 内容最大大小
        /// </summary>
        [DefaultValue(typeof(Size), "0,0")]
        [Description("内容最大大小")]
        public Size MaxSize
        {
            get { return this.maxSize; }
            set
            {
                if (this.maxSize == value || value.Width < 0 || value.Height < 0)
                    return;
                this.maxSize = value;
            }
        }

        #endregion

        #region 标题

        private bool titleShow = false;
        /// <summary>
        /// 是否显示标题
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示标题")]
        public bool TitleShow
        {
            get { return this.titleShow; }
            set
            {
                if (this.titleShow == value)
                    return;
                this.titleShow = value;
            }
        }

        private int titleHeight = 26;
        /// <summary>
        /// 标题高度
        /// </summary>
        [DefaultValue(26)]
        [Description("标题高度")]
        public int TitleHeight
        {
            get { return this.titleHeight; }
            set
            {
                if (this.titleHeight == value)
                    return;
                this.titleHeight = value;
            }
        }

        private TitleAnchor titleStation = TitleAnchor.Top;
        /// <summary>
        /// 提示框标题位置
        /// </summary>
        [DefaultValue(TitleAnchor.Top)]
        [Description("提示框标题位置")]
        public TitleAnchor TitleStation
        {
            get { return this.titleStation; }
            set
            {
                if (this.titleStation == value)
                    return;
                this.titleStation = value;
            }
        }

        private Font titleFont = new Font("宋体", 11);
        /// <summary>
        /// 标题字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 11pt")]
        [Description("标题字体")]
        public Font TitleFont
        {
            get { return this.titleFont; }
            set
            {
                if (this.titleFont == value)
                    return;
                this.titleFont = value;
            }
        }

        private Color titleBackColor = Color.FromArgb(192, 206, 55);
        /// <summary>
        /// 标题背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 206, 55")]
        [Description("标题背景颜色")]
        public Color TitleBackColor
        {
            get { return this.titleBackColor; }
            set
            {
                if (this.titleBackColor == value)
                    return;
                this.titleBackColor = value;
            }
        }

        private Color titleColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 标题文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("标题文本颜色")]
        public Color TitleColor
        {
            get { return this.titleColor; }
            set
            {
                if (this.titleColor == value)
                    return;
                this.titleColor = value;
            }
        }

        #endregion

        #region 文本

        private Font font = new Font("宋体", 10);
        /// <summary>
        /// 文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("文本字体")]
        public Font Font
        {
            get { return this.font; }
            set
            {
                if (this.font == value)
                    return;
                this.font = value;
            }
        }

        #endregion

        #endregion

        public ToolTipExt()
        {
            this.OwnerDraw = true;
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.ForeColor = Color.FromArgb(245, 168, 154);
            this.Popup += new PopupEventHandler(this.ToolTipExt_Popup);
            this.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTipExt_Draw);
        }

        #region 公开方法

        /// <summary>
        /// 设置与指定控件关联的工具提示文本，然后在指定的相对位置以模式方式显示该工具提示。
        /// </summary>
        /// <param name="text">包含新工具提示文本的 System.String。</param>
        /// <param name="window">要为其显示工具提示的 System.Windows.Forms.Control。</param>
        /// <param name="rect">重新定义关联控件窗口的rect信息</param>
        /// <param name="anchor">工具提示的位置</param>
        /// <param name="duration">包含工具提示持续显示时间（以毫秒为单位）的 System.Int32。</param>
        public void Show(string text, IWin32Window window, Rectangle rect, ToolTipAnchor anchor, int duration)
        {
            this.toolAnchor = anchor;
            Control control = (Control)window;
            if (rect == Rectangle.Empty)
            {
                rect.X = control.Location.X;
                rect.Y = control.Location.Y;
                rect.Width = control.Width;
                rect.Height = control.Height;
            }

            Size size = this.GetToolTipSize(control, text);
            Point point = new Point(0, 0);
            if (this.ToolAnchor == ToolTipAnchor.TopCenter)
            {
                point = new Point(rect.X + (rect.Width - size.Width) / 2, rect.Y - this.AnchorDistance - size.Height);
            }
            else if (this.ToolAnchor == ToolTipAnchor.BottomCenter)
            {
                point = new Point(rect.X + (rect.Width - size.Width) / 2, rect.Bottom + this.AnchorDistance);
            }
            else if (this.ToolAnchor == ToolTipAnchor.LeftCenter)
            {
                point = new Point(rect.X - (size.Width + this.AnchorDistance), rect.Y + (rect.Height - size.Height) / 2);
            }
            else if (this.ToolAnchor == ToolTipAnchor.RightCenter)
            {
                point = new Point(rect.Right + this.AnchorDistance, rect.Y + (rect.Height - size.Height) / 2);
            }
            this.Show(text, window, point, duration);
        }

        /// <summary>
        /// 设置与指定控件关联的工具提示文本，然后在指定的相对位置以模式方式显示该工具提示。
        /// </summary>
        /// <param name="text">包含新工具提示文本的 System.String。</param>
        /// <param name="window">要为其显示工具提示的 System.Windows.Forms.Control。</param>
        /// <param name="rect">重新定义关联控件窗口的rect信息( Rectangle.Empty 值时不会重新定义)</param>
        /// <param name="anchor">工具提示的位置</param>
        public void Show(string text, IWin32Window window, Rectangle rect, ToolTipAnchor anchor)
        {
            this.toolAnchor = anchor;
            Control control = (Control)window;
            if (rect == Rectangle.Empty)
            {
                rect.Width = control.Width;
                rect.Height = control.Height;
            }

            Size size = this.GetToolTipSize(control, text);
            Point point = new Point(0, 0);
            if (this.ToolAnchor == ToolTipAnchor.TopCenter)
            {
                point = new Point(rect.X + (rect.Width - size.Width) / 2, rect.Y - this.AnchorDistance - size.Height);
            }
            else if (this.ToolAnchor == ToolTipAnchor.BottomCenter)
            {
                point = new Point(rect.X + (rect.Width - size.Width) / 2, rect.Bottom + this.AnchorDistance);
            }
            else if (this.ToolAnchor == ToolTipAnchor.LeftCenter)
            {
                point = new Point(rect.X - (size.Width + this.AnchorDistance), rect.Y + (rect.Height - size.Height) / 2);
            }
            else if (this.ToolAnchor == ToolTipAnchor.RightCenter)
            {
                point = new Point(rect.Right + this.AnchorDistance, rect.Y + (rect.Height - size.Height) / 2);
            }
            this.Show(text, window, point);
        }

        #endregion

        #region 私有方法

        private void ToolTipExt_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = this.GetToolTipSize(e.AssociatedControl);
        }

        private void ToolTipExt_Draw(object sender, DrawToolTipEventArgs e)
        {
            #region 背景

            SolidBrush back_sb = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(back_sb, e.Bounds);
            back_sb.Dispose();

            #endregion

            #region 标题

            Rectangle titleback_rect = new Rectangle();
            if (this.TitleShow)
            {
                StringFormat title_sf = new StringFormat();
                if (this.TitleStation == TitleAnchor.Left || this.TitleStation == TitleAnchor.Right)
                    title_sf.FormatFlags = StringFormatFlags.DirectionVertical;
                Size title_size = e.Graphics.MeasureString(this.ToolTipTitle, this.TitleFont, 0, title_sf).ToSize();


                Rectangle title_rect = new Rectangle();
                if (this.TitleStation == TitleAnchor.Top)
                {
                    titleback_rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, this.TitleHeight);
                    title_rect = new Rectangle(titleback_rect.X + this.Padding, titleback_rect.Y + (titleback_rect.Height - title_size.Height) / 2, titleback_rect.Width - this.Padding * 2, titleback_rect.Height - this.Padding * 2);
                }
                else if (this.TitleStation == TitleAnchor.Bottom)
                {
                    titleback_rect = new Rectangle(e.Bounds.X, e.Bounds.Bottom - this.TitleHeight, e.Bounds.Width, this.TitleHeight);
                    title_rect = new Rectangle(titleback_rect.X + this.Padding, e.Bounds.Bottom - titleback_rect.Height + (titleback_rect.Height - title_size.Height) / 2, titleback_rect.Width - this.Padding * 2, titleback_rect.Height - this.Padding * 2);
                }
                else if (this.TitleStation == TitleAnchor.Left)
                {
                    titleback_rect = new Rectangle(e.Bounds.X, e.Bounds.Y, this.TitleHeight, e.Bounds.Height);
                    title_rect = new Rectangle(titleback_rect.X + (titleback_rect.Width - title_size.Width) / 2, titleback_rect.Y + this.Padding, titleback_rect.Width - this.Padding * 2, titleback_rect.Height - this.Padding * 2);
                }
                else if (this.TitleStation == TitleAnchor.Right)
                {
                    titleback_rect = new Rectangle(e.Bounds.Right - this.TitleHeight, e.Bounds.Y, this.TitleHeight, e.Bounds.Height);
                    title_rect = new Rectangle(titleback_rect.Right - titleback_rect.Width + (titleback_rect.Width - title_size.Width) / 2, titleback_rect.Y + this.Padding, titleback_rect.Width - this.Padding * 2, titleback_rect.Height - this.Padding * 2);
                }

                if (this.TitleBackColor != Color.Empty)
                {
                    SolidBrush titleback_sb = new SolidBrush(this.TitleBackColor);
                    e.Graphics.FillRectangle(titleback_sb, titleback_rect);
                    titleback_sb.Dispose();
                }

                SolidBrush title_sb = new SolidBrush(this.TitleColor);
                e.Graphics.DrawString(this.ToolTipTitle, this.TitleFont, title_sb, title_rect, title_sf);
                title_sb.Dispose();
                title_sf.Dispose();
            }

            #endregion

            #region 内容

            Size text_size = e.Graphics.MeasureString(e.ToolTipText, this.Font, new Size()).ToSize();
            Rectangle text_rect = new Rectangle();
            if (this.TitleStation == TitleAnchor.Top)
            {
                text_rect = new Rectangle(e.Bounds.X + this.Padding, titleback_rect.Bottom + this.Padding, e.Bounds.Width, e.Bounds.Height - titleback_rect.Height);
            }
            else if (this.TitleStation == TitleAnchor.Bottom)
            {
                text_rect = new Rectangle(e.Bounds.X + this.Padding, e.Bounds.Y + this.Padding, e.Bounds.Width, e.Bounds.Height - titleback_rect.Height);
            }
            else if (this.TitleStation == TitleAnchor.Left)
            {
                text_rect = new Rectangle(e.Bounds.X + titleback_rect.Width + this.Padding, e.Bounds.Y + this.Padding, e.Bounds.Width, e.Bounds.Height - titleback_rect.Height);
            }
            else if (this.TitleStation == TitleAnchor.Right)
            {
                text_rect = new Rectangle(e.Bounds.X + this.Padding, e.Bounds.Y + this.Padding, e.Bounds.Width, e.Bounds.Height - titleback_rect.Height);
            }

            SolidBrush text_sb = new SolidBrush(this.ForeColor);
            e.Graphics.DrawString(e.ToolTipText, this.Font, text_sb, text_rect);
            text_sb.Dispose();

            #endregion

        }

        /// <summary>
        /// 通过文本计算工具提示大小(text为null时根据control的文本计算)
        /// </summary>
        /// <param name="control">要为其检索 System.Windows.Forms.ToolTip 文本的 System.Windows.Forms.Control。</param>
        /// <param name="text">要计算的文本</param>
        /// <returns></returns>
        private Size GetToolTipSize(Control control, string text = null)
        {
            IntPtr hDC = WindowNavigate.GetWindowDC(control.Handle);
            Graphics g = Graphics.FromHdc(hDC);

            string text_str = text == null ? this.GetToolTip(control) : text;
            Size text_size = g.MeasureString(text_str, this.Font, new Size()).ToSize();
            text_size.Width += this.Padding * 2;
            text_size.Height += this.Padding * 2;

            if (this.MinSize.Width > 0 && this.MinSize.Width > text_size.Width)
                text_size.Width = this.MinSize.Width;
            if (this.MinSize.Height > 0 && this.MinSize.Height > text_size.Height)
                text_size.Height = this.MinSize.Height;

            if (this.MaxSize.Width > 0 && text_size.Width > this.MaxSize.Width)
                text_size.Width = this.MaxSize.Width;
            if (this.MaxSize.Height > 0 && text_size.Height > this.MaxSize.Height)
                text_size.Height = this.MaxSize.Height;

            if (this.TitleShow)
            {
                if (this.TitleStation == TitleAnchor.Top || this.TitleStation == TitleAnchor.Bottom)
                {
                    text_size.Height += this.TitleHeight;
                }
                else
                {
                    text_size.Width += this.TitleHeight;
                }
            }

            g.Dispose();
            WindowNavigate.ReleaseDC(control.Handle, hDC);

            return text_size;
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 提示框标题位置
        /// </summary>
        [Description("提示框标题位置")]
        public enum TitleAnchor
        {
            /// <summary>
            /// 顶部
            /// </summary>
            Top,
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right,
            /// <summary>
            /// 下边
            /// </summary>
            Bottom
        }

        /// <summary>
        /// 提示框位置
        /// </summary>
        [Description("提示框位置")]
        public enum ToolTipAnchor
        {
            /// <summary>
            /// 顶部居中
            /// </summary>
            TopCenter,
            /// <summary>
            /// 左边居中
            /// </summary>
            LeftCenter,
            /// <summary>
            /// 右边居中
            /// </summary>
            RightCenter,
            /// <summary>
            /// 下边居中
            /// </summary>
            BottomCenter
        }

        #endregion
    }

}
