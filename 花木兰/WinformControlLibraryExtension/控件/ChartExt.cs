
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// Chart分析图控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("Chart分析图控件")]
    [DefaultProperty("ColorItems")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class ChartExt : Control
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

        private bool borderShow = false;
        /// <summary>
        ///是否显示边框
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示边框")]
        public bool BorderShow
        {
            get { return this.borderShow; }
            set
            {
                if (this.borderShow == value)
                    return;
                this.borderShow = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
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
                this.Invalidate();
            }
        }

        private ChartColorType colorType = ChartColorType.Normal;
        /// <summary>
        /// 线区域背景颜色类型
        /// </summary>
        [DefaultValue(ChartColorType.Normal)]
        [Description("线区域背景颜色类型")]
        public ChartColorType ColorType
        {
            get { return this.colorType; }
            set
            {
                if (this.colorType == value)
                    return;
                this.colorType = value;
                this.Invalidate();
            }
        }

        private int colorItemsOpacity = 200;
        /// <summary>
        /// 线区域背景颜色级别透明度
        /// </summary>
        [DefaultValue(200)]
        [Description("线区域背景颜色级别透明度")]
        public int ColorItemsOpacity
        {
            get { return this.colorItemsOpacity; }
            set
            {
                if (this.colorItemsOpacity == value || value < 0 || value > 255)
                    return;
                this.colorItemsOpacity = value;
                this.Invalidate();
            }
        }

        private ColorItemCollection colorItemCollection;
        /// <summary>
        /// 线区域背景颜色级别配置集合
        /// </summary>
        [Description("线区域背景颜色级别配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorItemCollection ColorItems
        {
            get
            {
                if (this.colorItemCollection == null)
                    this.colorItemCollection = new ColorItemCollection(this);
                return this.colorItemCollection;
            }
        }

        #region 网格

        private int gridsWidthIntervalPixel = 15;
        /// <summary>
        /// 网格宽度间隔像素
        /// </summary>
        [DefaultValue(15)]
        [Description("网格宽度间隔像素")]
        public int GridsWidthIntervalPixel
        {
            get { return this.gridsWidthIntervalPixel; }
            set
            {
                if (this.gridsWidthIntervalPixel == value)
                    return;
                this.gridsWidthIntervalPixel = value;
                this.Invalidate();
            }
        }

        private int gridsHeightIntervalPixel = 15;
        /// <summary>
        /// 网格高度间隔像素
        /// </summary>
        [DefaultValue(15)]
        [Description("网格高度间隔像素")]
        public int GridsHeightIntervalPixel
        {
            get { return this.gridsHeightIntervalPixel; }
            set
            {
                if (this.gridsHeightIntervalPixel == value)
                    return;
                this.gridsHeightIntervalPixel = value;
                this.Invalidate();
            }
        }

        private Color gridsColor = Color.Gainsboro;
        /// <summary>
        /// 网格颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gainsboro")]
        [Description("网格颜色")]
        public Color GridsColor
        {
            get { return this.gridsColor; }
            set
            {
                if (this.gridsColor == value)
                    return;
                this.gridsColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 鼠标线

        private bool hLineShow = true;
        /// <summary>
        /// 是否显示横向鼠标线
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示横向鼠标线")]
        public bool HLineShow
        {
            get { return this.hLineShow; }
            set
            {
                if (this.hLineShow == value)
                    return;
                this.hLineShow = value;
                this.Invalidate();
            }
        }

        private Color hLineColor = Color.FromArgb(200, 147, 112, 219);
        /// <summary>
        /// 横向鼠标线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 147, 112, 219")]
        [Description("横向鼠标线颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color HLineColor
        {
            get { return this.hLineColor; }
            set
            {
                if (this.hLineColor == value)
                    return;
                this.hLineColor = value;
                this.Invalidate();
            }
        }

        private bool vLineShow = true;
        /// <summary>
        /// 是否显示纵向鼠标线
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示纵向鼠标线")]
        public bool VLineShow
        {
            get { return this.vLineShow; }
            set
            {
                if (this.vLineShow == value)
                    return;
                this.vLineShow = value;
                this.Invalidate();
            }
        }

        private Color vLineColor = Color.FromArgb(200, 147, 112, 219);
        /// <summary>
        /// 横鼠标向线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "200, 147, 112, 219")]
        [Description("渐变结束颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color VLineColor
        {
            get { return this.vLineColor; }
            set
            {
                if (this.vLineColor == value)
                    return;
                this.vLineColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 线区

        /// <summary>
        /// 线区边界厚度
        /// </summary>
        [DefaultValue(2)]
        [Description("线区边界厚度")]
        public int LineThickness
        {
            get { return this.lineThickness; }
            set
            {
                if (this.lineThickness == value)
                    return;
                this.lineThickness = value;
                this.Invalidate();
            }
        }

        private Color lineBackColor = Color.FromArgb(151, 147, 112, 219);
        /// <summary>
        /// 线区域背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "151, 147, 112, 219")]
        [Description("线区域背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LineBackColor
        {
            get { return this.lineBackColor; }
            set
            {
                if (this.lineBackColor == value)
                    return;
                this.lineBackColor = value;
                this.Invalidate();
            }
        }
        private int lineThickness = 2;

        private Color lineColor = Color.FromArgb(147, 112, 219);
        /// <summary>
        /// 线区边界颜色
        /// </summary>
        [DefaultValue(typeof(Color), "147, 112, 219")]
        [Description("线区边界颜色")]
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

        #region 圆点

        private bool lineDotShow = false;
        /// <summary>
        /// 是否显示线上圆点
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示线上圆点")]
        public bool LineDotShow
        {
            get { return this.lineDotShow; }
            set
            {
                if (this.lineDotShow == value)
                    return;
                this.lineDotShow = value;
                this.Invalidate();
            }
        }

        private int lineDotRadius = 3;
        /// <summary>
        /// 线上圆点半径
        /// </summary>
        [DefaultValue(3)]
        [Description("线上圆点半径")]
        public int LineDotRadius
        {
            get { return this.lineDotRadius; }
            set
            {
                if (this.lineDotRadius == value)
                    return;
                this.lineDotRadius = value;
                this.Invalidate();
            }
        }

        private Color lineDotColor = Color.FromArgb(147, 112, 219);
        /// <summary>
        /// 线上圆点颜色
        /// </summary>
        [DefaultValue(typeof(Color), "147, 112, 219")]
        [Description("线上圆点颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LineDotColor
        {
            get { return this.lineDotColor; }
            set
            {
                if (this.lineDotColor == value)
                    return;
                this.lineDotColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 提示

        private bool tipShow = false;
        /// <summary>
        /// 是否显示提示
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示提示")]
        public bool TipShow
        {
            get { return this.tipShow; }
            set
            {
                if (this.tipShow == value)
                    return;
                this.tipShow = value;
                this.Invalidate();
            }
        }

        private Color tipBackColor = Color.FromArgb(151, 147, 112, 219);
        /// <summary>
        /// 提示背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "151, 147, 112, 219")]
        [Description("提示背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipBackColor
        {
            get { return this.tipBackColor; }
            set
            {
                if (this.tipBackColor == value)
                    return;
                this.tipBackColor = value;
                this.Invalidate();
            }
        }

        private Font tipFont = new Font("宋体", 11);
        /// <summary>
        /// 提示字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 11pt")]
        [Description("提示字体")]
        public Font TipFont
        {
            get { return this.tipFont; }
            set
            {
                if (this.tipFont == value)
                    return;
                this.tipFont = value;
                this.Invalidate();
            }
        }

        private Color tipColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 提示字体颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("提示字体颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TipColor
        {
            get { return this.tipColor; }
            set
            {
                if (this.tipColor == value)
                    return;
                this.tipColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region 重写属性

        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 150); ;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private ArrayList pathpoints = new ArrayList();

        private Point movepoint = new Point(0, 0);//鼠标坐标

        private bool enterLeave = false;//鼠标状态

        #endregion

        public ChartExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region 重写

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectf = new RectangleF(0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

            #region 网格

            Pen grids_pen = new Pen(this.GridsColor);
            g.DrawRectangle(grids_pen, rectf.X, rectf.Y, rectf.Width, rectf.Height);//外边框

            int r_count = (int)Math.Ceiling(rectf.Height / (float)this.GridsHeightIntervalPixel);//行线
            for (int i = r_count - 1; i > -1; i--)
            {
                float y = rectf.Height - this.GridsHeightIntervalPixel * i;
                g.DrawLine(grids_pen, 0, y, rectf.Width, y);
            }

            int c_count = (int)Math.Ceiling(rectf.Width / (float)this.GridsWidthIntervalPixel);//列线
            c_count++;
            for (int i = 0; i < c_count; i++)
            {
                float x = this.GridsWidthIntervalPixel * i;
                g.DrawLine(grids_pen, x, 0, x, rectf.Height);
            }
            grids_pen.Dispose();

            #endregion

            #region 线

            if (this.pathpoints.Count < 2)
            {
                goto border;
            }

            #region 线区坐标
            float max = -1;
            float sum = 0;
            Point[] points = new Point[this.pathpoints.Count];
            for (int i = 0; i < this.pathpoints.Count; i++)
            {
                if ((float)this.pathpoints[i] > max)
                    max = (float)this.pathpoints[i];
                sum += (float)this.pathpoints[i];
                points[i] = new Point((int)(rectf.Width - i * this.GridsWidthIntervalPixel), (int)(rectf.Height - rectf.Height * (float)this.pathpoints[i]));
            }
            #endregion

            #region 线区
            GraphicsPath line_gp = new GraphicsPath();
            GraphicsPath lineback_gp = new GraphicsPath();
            line_gp.AddCurve(points, 0.5f);
            lineback_gp.AddCurve(points, 0.5f);
            lineback_gp.AddLine(points[this.pathpoints.Count - 1].X, this.ClientRectangle.Height, points[0].X, this.ClientRectangle.Height);

            Pen line_pen = new Pen(this.LineColor, this.LineThickness);
            Brush lineback_sb = null;
            LinearGradientBrush lineback_lgb = null;
            if (this.ColorType == ChartColorType.Normal)
            {
                lineback_sb = new SolidBrush(this.LineBackColor);
            }
            else
            {
                Color[] colors = new Color[this.ColorItems.Count];
                float[] interval = new float[this.ColorItems.Count];
                for (int i = 0; i < this.ColorItems.Count; i++)
                {
                    colors[i] = Color.FromArgb(this.ColorItemsOpacity, this.ColorItems[i].Color);
                    interval[i] = this.ColorItems[i].Position;
                }
                //Positions开始值必须为0,结束值必须为1
                interval[0] = 0.0f;
                interval[this.ColorItems.Count - 1] = 1.0f;
                lineback_lgb = new LinearGradientBrush(this.ClientRectangle, Color.Transparent, Color.Transparent, 270);
                lineback_lgb.InterpolationColors = new ColorBlend() { Colors = colors, Positions = interval };
            }

            g.FillPath(this.ColorType == ChartColorType.Normal ? lineback_sb : lineback_lgb, lineback_gp);
            g.DrawPath(line_pen, line_gp);
            line_gp.Dispose();
            lineback_gp.Dispose();
            line_pen.Dispose();
            if (lineback_sb != null)
                lineback_sb.Dispose();
            if (lineback_lgb != null)
                lineback_lgb.Dispose();
            #endregion

            #region 点
            if (this.LineDotShow)
            {
                SolidBrush linedot_sb = new SolidBrush(this.LineDotColor);
                for (int i = 0; i < points.Count(); i++)
                {
                    g.FillEllipse(linedot_sb, new Rectangle(points[i].X - this.LineDotRadius, points[i].Y - this.LineDotRadius, this.LineDotRadius * 2, this.LineDotRadius * 2));
                }
            }
            #endregion

            #region 提示
            if (this.TipShow)
            {
                SizeF max_size = g.MeasureString("当前最大峰值:100%", this.TipFont);
                string max_str = String.Format("当前最大峰值:{0}%", (int)(max * rectf.Height));
                Rectangle max_rect = new Rectangle(10, 10, (int)max_size.Width + 1, (int)max_size.Height);
                SolidBrush max_sb = new SolidBrush(this.TipColor);
                SolidBrush maxback_sb = new SolidBrush(this.TipBackColor);
                g.FillRectangle(maxback_sb, max_rect);
                g.DrawString(max_str, this.tipFont, max_sb, max_rect);


                string avg_str = String.Format("当前平均峰值:{0}%", (int)((sum / this.pathpoints.Count) * 100));
                Rectangle avg_rect = new Rectangle(10, 10 + (int)max_size.Height + 10, (int)max_size.Width + 1, (int)max_size.Height);
                g.FillRectangle(maxback_sb, avg_rect);
                g.DrawString(avg_str, this.tipFont, max_sb, avg_rect);
                max_sb.Dispose();
                maxback_sb.Dispose();
            }
            #endregion

            #endregion

            #region 鼠标线、鼠标值

            if (this.enterLeave && this.movepoint != null)
            {
                #region 鼠标线

                if (this.HLineShow)
                {
                    Pen h_pen = new Pen(this.HLineColor);
                    g.DrawLine(h_pen, 0, this.movepoint.Y, this.ClientRectangle.Width, this.movepoint.Y);
                    h_pen.Dispose();
                }
                if (this.vLineShow)
                {
                    Pen v_pen = new Pen(this.VLineColor);
                    g.DrawLine(v_pen, this.movepoint.X, 0, this.movepoint.X, this.Height);
                    v_pen.Dispose();
                }

                #endregion

                #region 鼠标值
                string str = String.Format("{0}%", (int)(((rectf.Height - this.movepoint.Y) / rectf.Height) * 100));
                SolidBrush str_sb = new SolidBrush(this.TipColor);
                SizeF s = g.MeasureString(str, this.TipFont);

                Rectangle str_rect = new Rectangle(this.movepoint.X + 5, this.movepoint.Y - (int)s.Height - 5, (int)s.Width, (int)s.Height);
                if (str_rect.Right > this.ClientRectangle.Width)
                {
                    str_rect.X = this.movepoint.X - str_rect.Width - 5;
                }
                if (str_rect.Y < 0)
                {
                    str_rect.Y = this.movepoint.Y + 20 + 5;
                }

                SolidBrush back_sb = new SolidBrush(this.TipBackColor);
                g.FillRectangle(back_sb, str_rect);
                g.DrawString(str, this.tipFont, str_sb, str_rect.X, str_rect.Y);
                back_sb.Dispose();
                str_sb.Dispose();

                #endregion
            }

            #endregion

        border:
            #region 边框
            if (this.BorderShow)
            {
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(border_pen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

                if (border_pen != null)
                    border_pen.Dispose();
            }

            #endregion
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.enterLeave = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.enterLeave = false;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Location != this.movepoint)
            {
                this.movepoint = e.Location;
                this.Invalidate();
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 添加路径值
        /// </summary>
        /// <param name="value"></param>
        public void AddPathPoint(float value)
        {
            ArrayList new_pathpoints = new ArrayList();
            new_pathpoints.Add(value);
            for (int i = 0; i < this.pathpoints.Count; i++)
            {
                if (this.ClientRectangle.Width - i * this.GridsWidthIntervalPixel >= 0)
                {
                    new_pathpoints.Add(this.pathpoints[i]);
                }
                else
                {
                    break;
                }
            }
            this.pathpoints = new_pathpoints;
            this.Invalidate();
        }

        #endregion

        #region 类

        /// <summary>
        /// 线区域背景颜色级别配置集合
        /// </summary>
        [Description("线区域背景颜色级别配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ColorItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList colorItemList = new ArrayList();
            private ChartExt owner;

            public ColorItemCollection(ChartExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ColorItem[] listArray = new ColorItem[this.colorItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ColorItem)this.colorItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.colorItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.colorItemList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            public int Add(object value)
            {
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                return this.Add((ColorItem)value);
            }

            public int Add(ColorItem item)
            {
                this.colorItemList.Add(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.colorItemList.Clear();
                this.owner.Invalidate();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is ColorItem)
                {
                    return this.Contains((ColorItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ColorItem)
                {
                    return this.colorItemList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                this.Remove((ColorItem)value);
            }

            public void Remove(ColorItem item)
            {
                this.colorItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.colorItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public ColorItem this[int index]
            {
                get
                {
                    return (ColorItem)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                }
            }

            #endregion

        }

        /// <summary>
        /// 线区域背景颜色级别配置
        /// </summary>
        [Description("线区域背景颜色级别配置")]
        public class ColorItem
        {
            private float position = 0f;
            /// <summary>
            ///渐变值0-1
            /// </summary>
            [DefaultValue(0f)]
            [Description("渐变值0-1")]
            public float Position
            {
                get { return this.position; }
                set
                {
                    if (this.position == value || value < 0 || value > 1)
                        return;
                    this.position = value;
                }
            }

            private Color color = Color.Empty;
            /// <summary>
            /// 渐变值对应渐变颜色
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("渐变值对应渐变颜色")]
            public Color Color
            {
                get { return this.color; }
                set
                {
                    if (this.color == value)
                        return;
                    this.color = value;
                }
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 线区域背景颜色类型
        /// </summary>
        [Description("线区域背景颜色类型")]
        public enum ChartColorType
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 渐变
            /// </summary>
            Gradient
        }

        #endregion
    }

}
