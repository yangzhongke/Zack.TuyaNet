
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
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 百分比进度控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("百分比进度控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class PercentageProgressExt : Control
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 百分比值更改事件
        /// </summary>
        [Description("百分比值更改事件")]
        public event ValueChangedEventHandler ValueChanged
        {
            add { this.valueChanged += value; }
            remove { this.valueChanged -= value; }
        }

        #endregion

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

        private PercentageType type = PercentageType.Annulus;
        /// <summary>
        /// 百分比显示类型
        /// </summary>
        [DefaultValue(PercentageType.Annulus)]
        [Description("百分比显示类型")]
        public PercentageType Type
        {
            get { return this.type; }
            set
            {
                if (this.type == value)
                    return;
                this.type = value;
                this.Invalidate();
            }
        }

        private int arcRadius = 50;
        /// <summary>
        /// 圆形半径
        /// </summary>
        [DefaultValue(50)]
        [Description("圆形半径")]
        public int ArcRadius
        {
            get { return this.arcRadius; }
            set
            {
                if (this.arcRadius == value || value < 0)
                    return;
                this.arcRadius = value;
                this.Invalidate();
            }
        }

        private int arcAngle = 360;
        /// <summary>
        /// 圆弧弧度大小
        /// </summary>
        [DefaultValue(360)]
        [Description("圆弧弧度大小")]
        public int ArcAngle
        {
            get { return this.arcAngle; }
            set
            {
                if (this.arcAngle == value || value < 0 || value > 360)
                    return;
                this.arcAngle = value;
                this.Invalidate();
            }
        }

        private int arcThickness = 10;
        /// <summary>
        /// 弧线大小
        /// </summary>
        [DefaultValue(10)]
        [Description("弧线大小")]
        public int ArcThickness
        {
            get { return this.arcThickness; }
            set
            {
                if (this.arcThickness == value || value < 0 || value > this.ArcRadius)
                    return;
                this.arcThickness = value;
                this.Invalidate();
            }
        }

        private bool arcRound = false;
        /// <summary>
        /// 弧线是否为圆角
        /// </summary>
        [DefaultValue(false)]
        [Description("弧线是否为圆角")]
        public bool ArcRound
        {
            get { return this.arcRound; }
            set
            {
                if (this.arcRound == value)
                    return;
                this.arcRound = value;
                this.Invalidate();
            }
        }

        private Color arcAnnulusBackColor = Color.Empty;
        /// <summary>
        /// 环形背景颜色(仅限于Annulus、Sector)
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("环形背景颜色(仅限于Annulus、Sector)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ArcAnnulusBackColor
        {
            get { return this.arcAnnulusBackColor; }
            set
            {
                if (this.arcAnnulusBackColor == value)
                    return;
                this.arcAnnulusBackColor = value;
                this.Invalidate();
            }
        }

        private Color arcBackColor = Color.FromArgb(112, 220, 220, 220);
        /// <summary>
        /// 弧线背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "112, 220, 220, 220")]
        [Description("弧线背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ArcBackColor
        {
            get { return this.arcBackColor; }
            set
            {
                if (this.arcBackColor == value)
                    return;
                this.arcBackColor = value;
                this.Invalidate();
            }
        }

        private Color arcColor = Color.FromArgb(227, 240, 128, 128);
        /// <summary>
        /// 弧线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "227, 240, 128, 128")]
        [Description("弧线颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ArcColor
        {
            get { return this.arcColor; }
            set
            {
                if (this.arcColor == value)
                    return;
                this.arcColor = value;
                this.Invalidate();
            }
        }

        #region 方形

        private int squareWidth = 10;
        /// <summary>
        /// 方形小格大小
        /// </summary>
        [DefaultValue(10)]
        [Description("方形小格大小")]
        public int SquareWidth
        {
            get { return this.squareWidth; }
            set
            {
                if (this.squareWidth == value || value < 0)
                    return;
                this.squareWidth = value;
                this.Invalidate();
            }
        }

        private Color squareBorderColor = Color.FromArgb(149, 255, 255, 255);
        /// <summary>
        /// 方形小格边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "149, 255, 255, 255")]
        [Description("方形小格边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SquareBorderColor
        {
            get { return this.squareBorderColor; }
            set
            {
                if (this.squareBorderColor == value)
                    return;
                this.squareBorderColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 值文本

        private float value = 0f;
        /// <summary>
        /// 百分比值(0-1)
        /// </summary>
        [DefaultValue(0f)]
        [Description("百分比值(0-1)")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value || value < 0 || value > 1)
                    return;
                this.value = value;
                this.Invalidate();

                this.OnValueChanged(new ValueChangedEventArgs() { Value = this.value });
            }
        }

        private Font valueFont = new Font("宋体", 15);
        /// <summary>
        /// 百分比值字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 15pt")]
        [Description("百分比值字体")]
        public Font ValueFont
        {
            get { return this.valueFont; }
            set
            {
                if (this.valueFont == value)
                    return;
                this.valueFont = value;
                this.Invalidate();
            }
        }

        private Color valueColor = Color.FromArgb(227, 255, 255, 255);
        /// <summary>
        /// 百分比值颜色
        /// </summary>
        [DefaultValue(typeof(Color), "227, 255, 255, 255")]
        [Description("百分比值颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ValueColor
        {
            get { return this.valueColor; }
            set
            {
                if (this.valueColor == value)
                    return;
                this.valueColor = value;
                this.Invalidate();
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
                return new Size(100, 100);
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

        public PercentageProgressExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle((int)this.ClientRectangle.X + ((int)this.ClientRectangle.Width / 2 - this.ArcRadius) + 1, (int)this.ClientRectangle.Y + ((int)this.ClientRectangle.Height / 2 - this.ArcRadius) + 1, this.ArcRadius * 2 - 2, this.ArcRadius * 2 - 2);

            #region 环形
            if (this.Type == PercentageType.Annulus)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                #region 背景
                Pen arcback_pen = new Pen(this.ArcBackColor, this.ArcThickness);
                g.DrawArc(arcback_pen, ControlCommom.TransformRectangleByPen(rect, this.ArcThickness), 270, 360);
                arcback_pen.Dispose();
                #endregion

                if (this.ArcAnnulusBackColor != Color.Empty)
                {
                    SolidBrush arcannulusback_sb = new SolidBrush(this.ArcAnnulusBackColor);
                    g.FillPie(arcannulusback_sb, rect.X + this.ArcThickness / 2, rect.Y + this.ArcThickness / 2, rect.Width - this.ArcThickness, rect.Height - this.ArcThickness, 270, 360);
                    arcannulusback_sb.Dispose();
                }

                #region 百分比值
                Pen arc_pen = new Pen(this.ArcColor, this.ArcThickness);
                if (this.ArcRound)
                {
                    arc_pen.StartCap = LineCap.Round;
                    arc_pen.EndCap = LineCap.Round;
                }
                g.DrawArc(arc_pen, ControlCommom.TransformRectangleByPen(rect, this.ArcThickness), 270, 360 * this.Value);
                arc_pen.Dispose();
                #endregion

                #region 文本
                this.DrawValueText(g, rect);
                #endregion

            }
            #endregion
            #region 扇形
            else if (this.Type == PercentageType.Sector)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                #region 背景
                SolidBrush arcback_sb = new SolidBrush(this.ArcBackColor);
                g.FillPie(arcback_sb, rect.X, rect.Y, rect.Width, rect.Height, 270, 360);
                arcback_sb.Dispose();
                #endregion

                if (this.ArcAnnulusBackColor != Color.Empty)
                {
                    SolidBrush arcannulusback_sb = new SolidBrush(this.ArcAnnulusBackColor);
                    g.FillPie(arcannulusback_sb, rect.X + this.ArcThickness / 2, rect.Y + this.ArcThickness / 2, rect.Width - this.ArcThickness, rect.Height - this.ArcThickness, 270, 360);
                    arcannulusback_sb.Dispose();
                }

                #region 百分比值
                SolidBrush arc_sb = new SolidBrush(this.ArcColor);
                g.FillPie(arc_sb, rect.X, rect.Y, rect.Width, rect.Height, 270, 360 * this.Value);
                arc_sb.Dispose();
                #endregion

                #region 文本
                this.DrawValueText(g, rect);
                #endregion

            }
            #endregion
            #region 圆弧
            else if (this.Type == PercentageType.Arc)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int start = this.ArcAngle == 360 ? 270 : 180 + (180 - this.ArcAngle) / 2;

                #region 背景
                Pen arcback_pen = new Pen(this.ArcBackColor, this.ArcThickness);
                g.DrawArc(arcback_pen, ControlCommom.TransformRectangleByPen(rect, this.ArcThickness), start, this.ArcAngle);
                arcback_pen.Dispose();
                #endregion

                #region 百分比值
                Pen arc_pen = new Pen(this.ArcColor, this.ArcThickness);
                if (this.ArcRound)
                {
                    arc_pen.EndCap = LineCap.Round;
                }
                g.DrawArc(arc_pen, ControlCommom.TransformRectangleByPen(rect, this.ArcThickness), start, this.ArcAngle * this.Value);
                arc_pen.Dispose();
                #endregion

                #region 文本
                this.DrawValueText(g, rect);
                #endregion

            }
            #endregion
            #region 方形
            else if (this.Type == PercentageType.Quadrangle)
            {
                RectangleF rectf = new RectangleF();
                rectf.Width = 10 + this.SquareWidth * 10;
                rectf.Height = 10 + this.SquareWidth * 10;
                rectf.X = this.ClientRectangle.X + (this.ClientRectangle.Width - rectf.Width) / 2;
                rectf.Y = this.ClientRectangle.Bottom - rectf.Height;

                #region 背景
                SolidBrush arcback_sb = new SolidBrush(this.ArcBackColor);
                g.FillRectangle(arcback_sb, rectf);
                arcback_sb.Dispose();
                #endregion

                #region 百分比值
                SolidBrush arc_sb = new SolidBrush(this.ArcColor);
                string str = this.Value.ToString("F4");
                int index = str.IndexOf('.');
                int row = int.Parse(str.Substring(index + 1, 1));
                RectangleF row_rectf = new RectangleF();
                row_rectf.Width = rectf.Width;
                row_rectf.Height = row * 1 + row * this.SquareWidth;
                row_rectf.X = rectf.X;
                row_rectf.Y = rectf.Bottom - row_rectf.Height;
                g.FillRectangle(arc_sb, row_rectf);

                int col = int.Parse(str.Substring(index + 2, 1));
                if (col > 0)
                {
                    RectangleF col_rectf = new RectangleF();
                    col_rectf.Width = col * 1 + col * this.SquareWidth;
                    col_rectf.Height = this.SquareWidth + 1;
                    col_rectf.X = rectf.X;
                    col_rectf.Y = row_rectf.Y - col_rectf.Height;
                    g.FillRectangle(arc_sb, col_rectf);
                }

                arc_sb.Dispose();
                #endregion

                #region 边框
                Pen arcbackborder_pen = new Pen(this.SquareBorderColor, 1);
                for (int i = 0; i < 11; i++)//行
                {
                    g.DrawLine(arcbackborder_pen, rectf.X, rectf.Y + i * 1 + i * this.SquareWidth, rectf.Right, rectf.Y + i * 1 + i * this.SquareWidth);
                }
                for (int i = 0; i < 11; i++)//列
                {
                    g.DrawLine(arcbackborder_pen, rectf.X + i * 1 + i * this.SquareWidth, rectf.Y, rectf.X + i * 1 + i * this.SquareWidth, rectf.Bottom);
                }
                arcbackborder_pen.Dispose();
                #endregion

                #region 百分比值文本
                string value_str = (this.Value * 100).ToString("F0") + "%";
                StringFormat value_sf = new StringFormat();
                value_sf.FormatFlags = StringFormatFlags.NoWrap;
                value_sf.Alignment = StringAlignment.Center;
                value_sf.Trimming = StringTrimming.None;
                Size value_size = g.MeasureString(value_str, this.ValueFont, new Size(), value_sf).ToSize();
                SolidBrush value_sb = new SolidBrush(this.ValueColor);
                g.DrawString(value_str, this.ValueFont, value_sb, new RectangleF(rectf.X + (rectf.Width - value_size.Width) / 2, rectf.Y - value_size.Height, value_size.Width, value_size.Height), value_sf);
                value_sb.Dispose();
                value_sf.Dispose();
                #endregion

            }
            #endregion
            #region 条形
            else if (this.Type == PercentageType.Bar)
            {
                if (this.ArcRound)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                }
                RectangleF rectf = new RectangleF();
                rectf.Width = this.ClientRectangle.Width - (this.ArcRound ? this.ArcThickness : 0);
                rectf.Height = this.ArcThickness;
                rectf.X = this.ClientRectangle.X + (this.ArcRound ? this.ArcThickness / 2 : 0);
                rectf.Y = this.ClientRectangle.Bottom - rectf.Height;

                #region 背景
                Pen arcback_pen = new Pen(this.ArcBackColor, this.ArcThickness);
                if (this.ArcRound)
                {
                    arcback_pen.StartCap = LineCap.Round;
                    arcback_pen.EndCap = LineCap.Round;
                }
                g.DrawLine(arcback_pen, rectf.X, rectf.Bottom - rectf.Height / 2, rectf.Right, rectf.Bottom - rectf.Height / 2);
                arcback_pen.Dispose();
                #endregion

                #region 百分比值
                Pen arc_pen = new Pen(this.ArcColor, this.ArcThickness);
                if (this.ArcRound)
                {
                    arc_pen.StartCap = LineCap.Round;
                    arc_pen.EndCap = LineCap.Round;
                }
                g.DrawLine(arc_pen, rectf.X, rectf.Bottom - rectf.Height / 2, (int)(rectf.Right * this.Value), rectf.Bottom - rectf.Height / 2);
                arc_pen.Dispose();
                #endregion

                #region 百分比值文本
                string value_str = (this.Value * 100).ToString("F0") + "%";
                StringFormat value_sf = new StringFormat();
                value_sf.FormatFlags = StringFormatFlags.NoWrap;
                value_sf.Alignment = StringAlignment.Center;
                value_sf.Trimming = StringTrimming.None;
                Size value_size = g.MeasureString(value_str, this.ValueFont, new Size(), value_sf).ToSize();
                SolidBrush value_sb = new SolidBrush(this.ValueColor);
                g.DrawString(value_str, this.ValueFont, value_sb, new RectangleF(rectf.X + (rectf.Width - value_size.Width) / 2, rectf.Y - value_size.Height, value_size.Width, value_size.Height), value_sf);
                value_sb.Dispose();
                value_sf.Dispose();
                #endregion

            }
            #endregion

        }

        #endregion

        #region 虚方法

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            if (this.valueChanged != null)
            {
                this.valueChanged(this, e);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 绘制百分值文本
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        private void DrawValueText(Graphics g, RectangleF rectf)
        {
            string value_str = (this.Value * 100).ToString("F0") + "%";
            StringFormat value_sf = new StringFormat();
            value_sf.FormatFlags = StringFormatFlags.NoWrap;
            value_sf.Alignment = StringAlignment.Center;
            value_sf.Trimming = StringTrimming.None;
            Size value_size = g.MeasureString(value_str, this.ValueFont, new Size(), value_sf).ToSize();
            SolidBrush value_sb = new SolidBrush(this.ValueColor);
            g.DrawString(value_str, this.ValueFont, value_sb, new RectangleF(rectf.X + (rectf.Width - value_size.Width) / 2f, rectf.Y + (rectf.Height - value_size.Height) / 2f, value_size.Width, value_size.Height), value_sf);
            value_sb.Dispose();
            value_sf.Dispose();
        }

        #endregion

        #region 类

        /// <summary>
        /// 百分比值更改事件参数
        /// </summary>
        [Description("百分比值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 百分比值
            /// </summary>
            [Description("百分比值")]
            public float Value { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 百分比显示类型
        /// </summary>
        [Description("百分比显示类型")]
        public enum PercentageType
        {
            /// <summary>
            /// 环形
            /// </summary>
            Annulus,
            /// <summary>
            /// 圆弧
            /// </summary>
            Arc,
            /// <summary>
            /// 扇形
            /// </summary>
            Sector,
            /// <summary>
            /// 方形
            /// </summary>
            Quadrangle,
            /// <summary>
            ///  条形
            /// </summary>
            Bar
        }

        #endregion

    }
}
