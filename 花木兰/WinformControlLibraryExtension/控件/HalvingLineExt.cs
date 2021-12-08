
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
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 分割线控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("分割线控件")]
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    public class HalvingLineExt : Control
    {
        #region 停用事件

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

        #region 线条

        private LineOrientations lineOrientation = LineOrientations.Horizontal;
        /// <summary>
        ///线条方向
        /// </summary>
        [DefaultValue(LineOrientations.Horizontal)]
        [Description("线条方向")]
        public LineOrientations LineOrientation
        {
            get { return this.lineOrientation; }
            set
            {
                if (this.lineOrientation == value)
                    return;

                this.lineOrientation = value;
                if (this.DesignMode)
                {
                    this.SetBounds(this.Location.X, this.Location.Y, this.Height, this.Width, BoundsSpecified.Size);
                }
                this.Invalidate();
            }
        }

        private int lineThickness = 2;
        /// <summary>
        ///线条厚度
        /// </summary>
        [DefaultValue(2)]
        [Description("线条厚度")]
        public int LineThickness
        {
            get { return this.lineThickness; }
            set
            {
                if (this.lineThickness == value || value < 1)
                    return;

                this.lineThickness = value;
                this.Invalidate();
            }
        }

        private bool lineCircular = false;
        /// <summary>
        ///线条圆角
        /// </summary>
        [DefaultValue(false)]
        [Description("线条圆角")]
        public bool LineCircular
        {
            get { return this.lineCircular; }
            set
            {
                if (this.lineCircular == value)
                    return;

                this.lineCircular = value;
                this.Invalidate();
            }
        }

        private Color lineColor = Color.YellowGreen;
        /// <summary>
        /// 线条颜色
        /// </summary>
        [DefaultValue(typeof(Color), "YellowGreen")]
        [Description("线条颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LineColor
        {
            get { return this.lineColor; }
            set
            {
                if (this.lineColor == value)
                    return;
                this.lineColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 文本

        private TextOrientations textOrientation = TextOrientations.Left;
        /// <summary>
        ///文本方向
        /// </summary>
        [DefaultValue(TextOrientations.Left)]
        [Description("文本方向")]
        public TextOrientations TextOrientation
        {
            get { return this.textOrientation; }
            set
            {
                if (this.textOrientation == value)
                    return;

                this.textOrientation = value;
                this.Invalidate();
            }
        }

        private TextAligns textAlign = TextAligns.Center;
        /// <summary>
        ///文本对齐方式
        /// </summary>
        [DefaultValue(TextAligns.Center)]
        [Description("文本对齐方式")]
        public TextAligns TextAlign
        {
            get { return this.textAlign; }
            set
            {
                if (this.textAlign == value)
                    return;

                this.textAlign = value;
                this.Invalidate();
            }
        }

        private int textDistance = 40;
        /// <summary>
        ///文本间距
        /// </summary>
        [DefaultValue(40)]
        [Description("文本间距")]
        public int TextDistance
        {
            get { return this.textDistance; }
            set
            {
                if (this.textDistance == value || value < 0)
                    return;
                this.textDistance = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region 重写属性

        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 23); ;
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {

                if (base.Text == value)
                    return;

                base.Text = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [DefaultValue(typeof(Color), "109, 109, 109")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        #endregion

        #region 停用属性

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

        public HalvingLineExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
            this.ForeColor = Color.FromArgb(109, 109, 109);
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int text_padding = 2;
            SizeF text_size = SizeF.Empty;
            RectangleF text_rect = RectangleF.Empty;

            Pen line_pen = new Pen(this.LineColor, this.LineThickness);
            int circular = this.lineCircular ? this.LineThickness : 0;
            PointF line_left_s = PointF.Empty;
            PointF line_left_e = PointF.Empty;
            PointF line_right_s = PointF.Empty;
            PointF line_right_e = PointF.Empty;

            #region 文字
            if (!String.IsNullOrEmpty(this.Text))
            {
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                StringFormat text_sf = null;

                #region
                if (this.LineOrientation == LineOrientations.Horizontal)
                {
                    text_size = g.MeasureString(this.Text, this.Font, 1000, text_sf);
                    #region
                    float y = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        y = (this.ClientRectangle.Height - (this.lineThickness + text_size.Height)) / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        y = (this.ClientRectangle.Height - text_size.Height) / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        y = (this.ClientRectangle.Height - (this.lineThickness + text_padding + text_size.Height)) / 2f + this.lineThickness+ text_padding;
                    }
                    #endregion
                    if (this.TextOrientation == TextOrientations.Left)
                    {
                        text_rect = new RectangleF(this.ClientRectangle.X + this.textDistance, y, text_size.Width, text_size.Height);
                    }
                    else
                    {
                        text_rect = new RectangleF(this.ClientRectangle.Right - this.textDistance - text_size.Width, y, text_size.Width, text_size.Height);
                    }
                }
                #endregion
                #region
                else
                {
                    text_sf = new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical };
                    text_size = g.MeasureString(this.Text, this.Font, 1000, text_sf);
                    #region
                    float x = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        x = (this.ClientRectangle.Width - (this.lineThickness + text_size.Width)) / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        x = (this.ClientRectangle.Width - text_size.Width) / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        x = (this.ClientRectangle.Width - (this.lineThickness + text_padding + text_size.Width)) / 2f + this.lineThickness + text_padding;
                    }
                    #endregion
                    if (this.TextOrientation == TextOrientations.Left)
                    {
                        text_rect = new RectangleF(x, this.ClientRectangle.Y + this.textDistance, text_size.Width, text_size.Height);
                    }
                    else
                    {
                        text_rect = new RectangleF(x, this.ClientRectangle.Bottom - this.textDistance - text_size.Height, text_size.Width, text_size.Height);
                    }
                }
                #endregion

                g.DrawString(this.Text, this.Font, text_sb, text_rect, text_sf);
                text_sb.Dispose();
                if (text_sf != null)
                {
                    text_sf.Dispose();
                }
            }
            #endregion

            #region 线条
            #region 两条线
            if (!String.IsNullOrEmpty(this.Text) && this.textAlign == TextAligns.Center)
            {
                if (this.LineOrientation == LineOrientations.Horizontal)
                {
                    #region
                    float y = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        y = text_rect.Bottom + this.LineThickness / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        y = this.ClientRectangle.Height / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        y = text_rect.Y - this.LineThickness / 2f;
                    }
                    #endregion
                    line_left_s = new PointF(this.ClientRectangle.X + circular, y);
                    line_left_e = new PointF(text_rect.X - text_padding, y);
                    line_right_s = new PointF(text_rect.Right + text_padding, y);
                    line_right_e = new PointF(this.ClientRectangle.Right - circular, y);
                }
                else
                {
                    #region
                    float x = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        x = text_rect.Right + this.LineThickness / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        x = this.ClientRectangle.Width / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        x = text_rect.X - this.LineThickness / 2f;
                    }
                    #endregion
                    line_left_s = new PointF(x, this.ClientRectangle.Y + circular);
                    line_left_e = new PointF(x, text_rect.Y - text_padding);
                    line_right_s = new PointF(x, text_rect.Bottom + text_padding);
                    line_right_e = new PointF(x, this.ClientRectangle.Bottom - circular);
                }
                if (this.lineCircular)
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    line_pen.StartCap = LineCap.Round;
                    g.DrawLine(line_pen, line_left_s, line_left_e);
                    line_pen.StartCap = LineCap.Flat;
                    line_pen.EndCap = LineCap.Round;
                    g.DrawLine(line_pen, line_right_s, line_right_e);
                }
                else
                {
                    g.DrawLine(line_pen, line_left_s, line_left_e);
                    g.DrawLine(line_pen, line_right_s, line_right_e);
                }
            }
            #endregion
            #region 一条线
            else
            {
                if (this.LineOrientation == LineOrientations.Horizontal)
                {
                    #region
                    float y = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        y = text_rect.Bottom + this.LineThickness / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        y = this.ClientRectangle.Height / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        y = text_rect.Y- text_padding - this.LineThickness / 2f;
                    }
                    #endregion
                    line_left_s = new PointF(this.ClientRectangle.X + circular, y);
                    line_left_e = new PointF(this.ClientRectangle.Right - circular, y);
                }
                else
                {
                    #region
                    float x = 0;
                    if (this.textAlign == TextAligns.Top)
                    {
                        x = text_rect.Right + this.LineThickness / 2f;
                    }
                    else if (this.textAlign == TextAligns.Center)
                    {
                        x = this.ClientRectangle.Width / 2f;
                    }
                    else if (this.textAlign == TextAligns.Bottom)
                    {
                        x = text_rect.X - text_padding - this.LineThickness / 2f;
                    }
                    #endregion
                    line_left_s = new PointF(x, this.ClientRectangle.Y + circular);
                    line_left_e = new PointF(x, this.ClientRectangle.Bottom - circular);
                }
                if (this.lineCircular)
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    line_pen.StartCap = LineCap.Round;
                    line_pen.EndCap = LineCap.Round;
                }
                g.DrawLine(line_pen, line_left_s, line_left_e);
            }
            #endregion

            line_pen.Dispose();
            #endregion

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 线条方向
        /// </summary>
        [Description("线条方向")]
        public enum LineOrientations
        {
            /// <summary>
            /// 水平
            /// </summary>
            Horizontal,
            /// <summary>
            /// 竖直
            /// </summary>
            Vertical
        }

        /// <summary>
        /// 文本方向
        /// </summary>
        [Description("文本方向")]
        public enum TextOrientations
        {
            /// <summary>
            /// 左边
            /// </summary>
            Left,
            /// <summary>
            /// 右边
            /// </summary>
            Right
        }

        /// <summary>
        /// 文本对齐方式
        /// </summary>
        [Description("文本对齐方式")]
        public enum TextAligns
        {
            /// <summary>
            /// 顶部
            /// </summary>
            Top,
            /// <summary>
            /// 居中
            /// </summary>
            Center,
            /// <summary>
            /// 底部
            /// </summary>
            Bottom
        }

        #endregion
    }

}
