
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 加载等待控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("加载等待控件")]
    [DefaultProperty("Active")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class LoadExt : Control, IAnimationStaticTimer
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

        private LoadProgressType progressType = LoadProgressType.Line;
        /// <summary>
        /// 加载等待条类型
        /// </summary>
        [Description("加载等待条类型")]
        [DefaultValue(typeof(LoadProgressType), "Line")]
        public LoadProgressType ProgressType
        {
            get { return this.progressType; }
            set
            {
                if (this.progressType == value)
                    return;
                this.progressType = value;
                if (value == LoadProgressType.Line || value == LoadProgressType.Dot)
                {
                    this.InitializeAngles();
                    this.InitializeColors();
                }
                this.Invalidate();
            }
        }

        private int drawCircleRadius = 16;
        /// <summary>
        /// 画板半径大小(仅限Line、Dot、Arc、MultiArc)
        /// </summary>
        [Description("画板半径大小(仅限Line、Dot、Arc、MultiArc)")]
        [DefaultValue(16)]
        public int DrawCircleRadius
        {
            get
            {
                return this.drawCircleRadius;
            }
            set
            {
                if (this.drawCircleRadius == value && value < 1)
                    return;
                this.drawCircleRadius = value;
                this.Invalidate();
            }
        }

        private int thickness = 4;
        /// <summary>
        /// 画笔粗细程度
        /// </summary>
        [Description("画笔粗细程度")]
        [DefaultValue(4)]
        public int Thickness
        {
            get
            {
                return this.thickness;
            }
            set
            {
                if (this.thickness == value || value < 1)
                    return;
                this.thickness = value;
                this.Invalidate();
            }
        }

        private Color thicknessColor = Color.OliveDrab;
        /// <summary>
        /// 画笔颜色
        /// </summary>
        [Description("画笔颜色")]
        [DefaultValue(typeof(Color), "OliveDrab")]
        public Color ThicknessColor
        {
            get
            {
                return this.thicknessColor;
            }
            set
            {
                if (this.thicknessColor == value)
                    return;
                this.thicknessColor = value;
                if (this.ProgressType == LoadProgressType.Line || this.ProgressType == LoadProgressType.Dot)
                {
                    this.InitializeColors();
                }
                this.Invalidate();
            }
        }

        private int lineDotNumber = 8;
        /// <summary>
        /// 直线或圆点的数量(限制Line、Dot类型)
        /// </summary>
        [Description("直线或圆点的数量(限制Line、Dot类型)")]
        [DefaultValue(8)]
        public int LineDotNumber
        {
            get
            {
                return this.lineDotNumber;
            }
            set
            {
                if (this.lineDotNumber == value && value < 1)
                    return;
                this.lineDotNumber = value;
                if (this.ProgressType == LoadProgressType.Line || this.ProgressType == LoadProgressType.Dot)
                {
                    this.InitializeColors();
                    this.InitializeAngles();
                }
                this.Invalidate();
            }
        }

        private int lineLenght = 8;
        /// <summary>
        /// 直线长度(仅限Line)
        /// </summary>
        [Description("直线长度(仅限Line)")]
        [DefaultValue(8)]
        public int LineLenght
        {
            get
            {
                return this.lineLenght;
            }
            set
            {
                if (this.lineLenght == value)
                    return;
                this.lineLenght = value;
                this.Invalidate();
            }
        }

        private bool active = false;
        /// <summary>
        /// 是否激活
        /// </summary>
        [Description("是否激活")]
        [DefaultValue(false)]
        public bool Active
        {
            get
            {
                return this.active;
            }
            set
            {
                if (this.active == value)
                    return;
                this.active = value;
                this.positiveProgress = 0;
                this.negativeProgress = 0;
                if (this.ProgressType == LoadProgressType.Line || this.ProgressType == LoadProgressType.Dot)
                {
                    this.InitializeColors();
                }

                this.Invalidate();

                if (this.DesignMode)
                    return;

                if (this.Enabled = false || this.Visible == false || this.active == false)
                {
                    AnimationStaticTimer.AnimationStop(this);
                }
                else
                {
                    AnimationStaticTimer.AnimationStart(this);
                }
            }
        }

        private bool textShow = false;
        /// <summary>
        /// 是否显示文本
        /// </summary>
        [Description("是否显示文本")]
        [DefaultValue(false)]
        public bool TextShow
        {
            get
            {
                return this.textShow;
            }
            set
            {
                if (this.textShow == value)
                    return;
                this.textShow = value;
                this.Invalidate();
            }
        }

        private int interval = 80;
        /// <summary>
        /// 动画时间间隔(毫秒)最小80
        /// </summary>
        [Description("动画时间间隔(毫秒)最小80")]
        [DefaultValue(80)]
        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (this.interval == value || value < 80)
                    return;

                this.interval = value;
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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(40, 40);
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
        /// 正向进度条值
        /// </summary>
        private int positiveProgress = 0;
        /// <summary>
        /// 负向进度条值
        /// </summary>
        private int negativeProgress = 0;
        /// <summary>
        /// 每条直线角度
        /// </summary>
        private List<double> lineAngles;
        /// <summary>
        /// 每条直线颜色
        /// </summary>
        private List<Color> lineColors;
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;

        #endregion

        public LoadExt()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.InitializeAngles();
            this.InitializeColors();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;

            #region 图案
            switch (this.ProgressType)
            {
                case LoadProgressType.Line:
                    {
                        #region
                        int node = this.positiveProgress;
                        for (int i = 0; i < this.LineDotNumber; i++)
                        {
                            node = node % this.LineDotNumber;
                            PointF point1 = this.GetCoordinate(this.ClientRectangle, this.DrawCircleRadius - this.LineLenght, this.lineAngles[node]);
                            PointF point2 = this.GetCoordinate(this.ClientRectangle, this.DrawCircleRadius, this.lineAngles[node]);

                            Pen line_pen = new Pen(this.lineColors[i], this.Thickness);
                            line_pen.StartCap = LineCap.Round;
                            line_pen.EndCap = LineCap.Round;
                            g.DrawLine(line_pen, point1, point2);
                            line_pen.Dispose();

                            node++;
                        }
                        break;
                        #endregion
                    }
                case LoadProgressType.Dot:
                    {
                        #region
                        int node = this.positiveProgress;
                        for (int i = 0; i < this.LineDotNumber; i++)
                        {
                            node = node % this.LineDotNumber;
                            PointF point = this.GetCoordinate(this.ClientRectangle, this.DrawCircleRadius, this.lineAngles[node]);

                            SolidBrush dot_sb = new SolidBrush(this.lineColors[i]);
                            g.FillEllipse(dot_sb, point.X - this.Thickness / 2, point.Y - this.Thickness / 2, this.Thickness, this.Thickness);
                            dot_sb.Dispose();

                            node++;
                        }
                        break;
                        #endregion
                    }
                case LoadProgressType.Arc:
                    {
                        #region
                        int arc_w = this.DrawCircleRadius * 2;
                        int arc_h = this.DrawCircleRadius * 2;
                        Rectangle arc_rect = new Rectangle((this.ClientRectangle.Width - arc_w) / 2, (this.ClientRectangle.Height - arc_h) / 2, arc_w, arc_h);

                        Pen arc_pen = new Pen(this.ThicknessColor, this.Thickness);
                        g.DrawArc(arc_pen, arc_rect, this.positiveProgress, 290);
                        arc_pen.Dispose();
                        break;
                        #endregion
                    }
                case LoadProgressType.MultiArc:
                    {
                        #region
                        int multiArc_w = this.DrawCircleRadius * 2;
                        int multiArc_h = this.DrawCircleRadius * 2;
                        Rectangle multiArc_rect = new Rectangle((this.ClientRectangle.Width - multiArc_w) / 2, (this.ClientRectangle.Height - multiArc_h) / 2, multiArc_w, multiArc_h);

                        Pen multiArc_pen = new Pen(this.ThicknessColor, this.thickness);
                        g.DrawArc(multiArc_pen, multiArc_rect, this.positiveProgress, 90);//外1弧度

                        int out2 = this.positiveProgress + 180;
                        if (out2 > 360)
                            out2 -= 360;
                        g.DrawArc(multiArc_pen, multiArc_rect, out2, 90);//外2弧度

                        Rectangle interior_rect = new Rectangle(multiArc_rect.X + multiArc_rect.Width / 4, multiArc_rect.Y + multiArc_rect.Height / 4, multiArc_rect.Width / 2, multiArc_rect.Height / 2);
                        int interior1 = this.negativeProgress + 90;
                        if (interior1 > 360)
                            interior1 -= 360;
                        g.DrawArc(multiArc_pen, interior_rect, interior1, 90);//内1弧度

                        int interior2 = interior1 + 180;
                        if (interior2 > 360)
                            interior2 -= 360;
                        g.DrawArc(multiArc_pen, interior_rect, interior2, 90);//内2弧度

                        multiArc_pen.Dispose();
                        break;
                        #endregion
                    }
                case LoadProgressType.Bar:
                    {
                        #region
                        int line_c = 9;//线条数量
                        int bar_w = this.Thickness * line_c;
                        int bar_h = this.Thickness * line_c;
                        int bar_x = (this.ClientRectangle.Width - bar_w) / 2;
                        int bar_y = (this.ClientRectangle.Height - bar_h) / 2;
                        int line_min_h = bar_h / 2;

                        Pen bar_pen = new Pen(this.ThicknessColor, this.Thickness);
                        for (int i = 0; i < line_c; i++)
                        {
                            if (i % 2 == 0)
                            {
                                int num = i / 2;//只绘制偶数线条
                                float differ = Math.Abs(this.positiveProgress - num);//指定线条与进度值线条的差用于计算缩放比例

                                float reality_h = bar_h - differ * (bar_h / 4);//线条要绘制的高度
                                if (reality_h < line_min_h)
                                    reality_h = line_min_h;

                                float line_x1 = bar_x + i * this.Thickness;
                                float line_y1 = bar_y + (bar_h - reality_h) / 2;
                                float line_x2 = line_x1;
                                float line_y2 = bar_y + (bar_h - reality_h) / 2 + reality_h;
                                g.DrawLine(bar_pen, line_x1, line_y1, line_x2, line_y2);
                            }
                        }
                        bar_pen.Dispose();
                        break;
                        #endregion
                    }
            }
            #endregion

            #region 文本
            if (this.TextShow && !String.IsNullOrWhiteSpace(this.Text))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                StringFormat text_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter };
                SizeF text_sizef = g.MeasureString(this.Text, this.Font);
                g.DrawString(this.Text, this.Font, text_sb, new RectangleF(0.0f, this.ClientRectangle.Bottom - text_sizef.Height, (float)this.ClientRectangle.Width, text_sizef.Height), text_sf);
                text_sb.Dispose();
                text_sf.Dispose();
            }
            #endregion

        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            AnimationStaticTimer.AnimationStop(this);
            base.Dispose(disposing);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 值更改动画中(禁止手动调用)
        /// </summary>
        [Description("值更改动画中(禁止手动调用)")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            this.usedTime += AnimationStaticTimer.timer.Interval;
            if (this.usedTime > this.Interval)
            {
                this.usedTime = 0;

                switch (this.ProgressType)
                {
                    case LoadProgressType.Arc:
                        {
                            this.positiveProgress += 25;
                            if (this.positiveProgress > 360)
                                this.positiveProgress -= 360;
                            break;
                        }
                    case LoadProgressType.MultiArc:
                        {
                            this.positiveProgress += 25;
                            if (this.positiveProgress > 360)
                                this.positiveProgress -= 360;

                            this.negativeProgress -= 28;
                            if (this.negativeProgress < 0)
                                this.negativeProgress += 360;
                            break;
                        }
                    case LoadProgressType.Bar:
                        {
                            this.positiveProgress += 1;
                            if (this.positiveProgress > 4)
                                this.positiveProgress -= 4;
                            break;
                        }
                    default:
                        {
                            this.positiveProgress += 1;
                            if (this.positiveProgress > this.LineDotNumber - 1)
                                this.positiveProgress -= this.LineDotNumber - 1;
                            break;
                        }
                }
                this.Invalidate();
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化每条直线或圆点角度
        /// </summary>
        /// <returns></returns>
        private void InitializeAngles()
        {
            this.lineAngles = new List<double>();
            double avgAngle = 360d / (double)this.LineDotNumber;
            for (int i = 0; i < this.LineDotNumber; i++)
            {
                this.lineAngles.Add((i + 1) * avgAngle);
            }
        }

        /// <summary>
        /// 初始化每条直线或圆点颜色
        /// </summary>
        /// <returns></returns>
        private void InitializeColors()
        {
            this.lineColors = new List<Color>();

            byte transparent = 0;//颜色透明度
            byte transparentIncrement = (byte)(byte.MaxValue / this.LineDotNumber);//颜色透明度增量
            for (int i = 0; i < this.LineDotNumber; i++)
            {
                Color color = this.ThicknessColor;
                if (this.Active && i > 0)
                {
                    transparent += transparentIncrement;
                    transparent = Math.Min(transparent, byte.MaxValue);
                    color = Color.FromArgb(transparent, Math.Min(this.ThicknessColor.R, byte.MaxValue), Math.Min(this.ThicknessColor.G, byte.MaxValue), Math.Min(this.ThicknessColor.B, byte.MaxValue));
                }
                this.lineColors.Add(color);
            }
        }

        /// <summary>
        /// 已绘图区中心坐标根据角度获取圆环上对应坐标
        /// </summary>
        /// <param name="rect">绘图区</param>
        /// <param name="radius">圆环半径</param>
        /// <param name="angle">角度</param>
        /// <returns>圆环上对应坐标</returns>
        private PointF GetCoordinate(Rectangle rect, int radius, double angle)
        {
            //经纬度转化成弧度(弧度=经纬度 * Math.PI / 180d);
            double dblAngle = angle * Math.PI / 180d;
            return new PointF(rect.Width / 2 + radius * (float)Math.Cos(dblAngle), rect.Height / 2 + radius * (float)Math.Sin(dblAngle));
        }

        #endregion

        #region 类

        /// <summary>
        /// 直线或圆点的角度和颜色
        /// </summary>
        [Description("直线或圆点的角度和颜色")]
        public class AnglesColor
        {
            /// <summary>
            /// 直线或圆点的角度
            /// </summary>
            [Description("直线或圆点的角度")]
            public double Angles { get; set; }
            /// <summary>
            /// 直线或圆点的颜色
            /// </summary>
            [Description("直线或圆点的颜色")]
            public Color Color { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 加载等待条类型
        /// </summary>
        [Description("加载等待条类型")]
        public enum LoadProgressType
        {
            /// <summary>
            /// 直线
            /// </summary>
            Line,
            /// <summary>
            /// 圆球
            /// </summary>
            Dot,
            /// <summary>
            ///圆弧 
            /// </summary>
            Arc,
            /// <summary>
            /// 多圆弧
            /// </summary>
            MultiArc,
            /// <summary>
            /// 条形
            /// </summary>
            Bar
        }

        #endregion
    }


}
