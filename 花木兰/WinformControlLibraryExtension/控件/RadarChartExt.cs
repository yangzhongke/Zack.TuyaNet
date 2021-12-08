
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 雷达分析图控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("雷达分析图控件")]
    [DefaultProperty("ChartLineItems")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class RadarChartExt : Control, IAnimationStaticTimer
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

        private int animationTime = 200;
        /// <summary>
        /// 动画时间
        /// </summary>
        [DefaultValue(200)]
        [Description("动画时间")]
        public int AnimationTime
        {
            get { return this.animationTime; }
            set
            {
                if (this.animationTime == value)
                    return;
                this.animationTime = value;
                this.options.AllTransformTime = value;
            }
        }

        private ChartTypes chartType = ChartTypes.Circle;
        /// <summary>
        /// 雷达分析图显示类型
        /// </summary>
        [DefaultValue(ChartTypes.Circle)]
        [Description("雷达分析图显示类型")]
        public ChartTypes ChartType
        {
            get { return this.chartType; }
            set
            {
                if (this.chartType == value)
                    return;
                this.chartType = value;
                this.Invalidate();
            }
        }

        private ChartAnchors chartAnchor = ChartAnchors.Left;
        /// <summary>
        /// 分析图布局
        /// </summary>
        [DefaultValue(ChartAnchors.Left)]
        [Description("分析图布局")]
        public ChartAnchors ChartAnchor
        {
            get { return this.chartAnchor; }
            set
            {
                if (this.chartAnchor == value)
                    return;
                this.chartAnchor = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Size chartSize = new Size(200, 200);
        /// <summary>
        /// 分析图Size
        /// </summary>
        [DefaultValue(typeof(Size), "200, 200")]
        [Description("分析图Size")]
        public Size ChartSize
        {
            get { return this.chartSize; }
            set
            {
                if (this.chartSize == value || value.Width < 2 || value.Height < 2)
                    return;
                this.chartSize = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private ChartLoopCollection chartLoopCollection;
        /// <summary>
        /// 分析图环形配置集合
        /// </summary>
        [Browsable(false)]
        [Description("分析图环形配置集合")]
        public ChartLoopCollection ChartLoopItems
        {
            get
            {
                if (this.chartLoopCollection == null)
                    this.chartLoopCollection = new ChartLoopCollection(this);
                return this.chartLoopCollection;
            }
        }

        private ChartLineCollection chartLineCollection;
        /// <summary>
        /// 分析图角度线配置集合
        /// </summary>
        [Description("分析图角度线配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartLineCollection ChartLineItems
        {
            get
            {
                if (this.chartLineCollection == null)
                    this.chartLineCollection = new ChartLineCollection(this);
                return this.chartLineCollection;
            }
        }

        private ChartItemCollection chartItemCollection;
        /// <summary>
        /// 分析图选项集合
        /// </summary>
        [Browsable(false)]
        [Description("分析图选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChartItemCollection ChartItemItems
        {
            get
            {
                if (this.chartItemCollection == null)
                    this.chartItemCollection = new ChartItemCollection(this);
                return this.chartItemCollection;
            }
        }

        #region  环形

        private int loopCount = 5;
        /// <summary>
        /// 环形数量
        /// </summary>
        [DefaultValue(5)]
        [Description("环形数量")]
        public int LoopCount
        {
            get { return this.loopCount; }
            set
            {
                if (this.loopCount == value || value < 1)
                    return;
                this.loopCount = value;
                this.InitializeChartLoop();
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private float loopInterval = 20f;
        /// <summary>
        /// 环形间隔值
        /// </summary>
        [DefaultValue(20f)]
        [Description("环形间隔值")]
        public float LoopInterval
        {
            get { return this.loopInterval; }
            set
            {
                if (this.loopInterval == value || value < 0f)
                    return;
                this.loopInterval = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int loopBorderthickness = 1;
        /// <summary>
        /// 环形线厚度
        /// </summary>
        [DefaultValue(1)]
        [Description("环形线厚度")]
        public int LoopBorderthickness
        {
            get { return this.loopBorderthickness; }
            set
            {
                if (this.loopBorderthickness == value || this.loopBorderthickness < 1)
                    return;
                this.loopBorderthickness = value;
                this.Invalidate();
            }
        }

        private Color loopBorderColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 环形线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("环形线颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopBorderColor
        {
            get { return this.loopBorderColor; }
            set
            {
                if (this.loopBorderColor == value)
                    return;
                this.loopBorderColor = value;
                this.Invalidate();
            }
        }

        private Color loopOddBackColor = Color.FromArgb(62, 224, 224, 224);
        /// <summary>
        /// 奇数环形背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "62, 224, 224, 224")]
        [Description("奇数环形背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopOddBackColor
        {
            get { return this.loopOddBackColor; }
            set
            {
                if (this.loopOddBackColor == value)
                    return;
                this.loopOddBackColor = value;
                this.Invalidate();
            }
        }

        private Color loopEvenBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 偶数环形背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("偶数环形背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopEvenBackColor
        {
            get { return this.loopEvenBackColor; }
            set
            {
                if (this.loopEvenBackColor == value)
                    return;
                this.loopEvenBackColor = value;
                this.Invalidate();
            }
        }

        private Color loopScaleTextColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 环形刻度文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("环形刻度文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopScaleTextColor
        {
            get { return this.loopScaleTextColor; }
            set
            {
                if (this.loopScaleTextColor == value)
                    return;
                this.loopScaleTextColor = value;
                this.Invalidate();
            }
        }

        private Color loopLineTextColor = Color.FromArgb(0, 192, 192);
        /// <summary>
        /// 环形选项文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "0, 192, 192")]
        [Description("环形选项文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopLineTextColor
        {
            get { return this.loopLineTextColor; }
            set
            {
                if (this.loopLineTextColor == value)
                    return;
                this.loopLineTextColor = value;
                this.Invalidate();
            }
        }

        private bool loopLineMaxValueShow = false;
        /// <summary>
        /// 动画中是否显示环形选项最大值高亮背景颜色
        /// </summary>
        [DefaultValue(false)]
        [Description("动画中是否显示环形选项最大值高亮背景颜色")]
        public bool LoopLineMaxValueShow
        {
            get { return this.loopLineMaxValueShow; }
            set
            {
                if (this.loopLineMaxValueShow == value)
                    return;
                this.loopLineMaxValueShow = value;
                this.Invalidate();
            }
        }

        private Color loopLineMaxValueTextColor = Color.FromArgb(255, 128, 128);
        /// <summary>
        /// 环形选项最大值高亮背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 128, 128")]
        [Description("环形选项最大值高亮背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopLineMaxValueTextColor
        {
            get { return this.loopLineMaxValueTextColor; }
            set
            {
                if (this.loopLineMaxValueTextColor == value)
                    return;
                this.loopLineMaxValueTextColor = value;
                this.Invalidate();
            }
        }

        private bool loopLineMinValueShow = false;
        /// <summary>
        /// 动画中是否显示环形选项最小值高亮背景颜色
        /// </summary>
        [DefaultValue(false)]
        [Description("动画中是否显示环形选项最小值高亮背景颜色")]
        public bool LoopLineMinValueShow
        {
            get { return this.loopLineMinValueShow; }
            set
            {
                if (this.loopLineMinValueShow == value)
                    return;
                this.loopLineMinValueShow = value;
                this.Invalidate();
            }
        }

        private Color loopLineMinValueTextColor = Color.FromArgb(65, 105, 225);
        /// <summary>
        /// 环形选项最小值高亮背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "65, 105, 225")]
        [Description("环形选项最小值高亮背景颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color LoopLineMinValueTextColor
        {
            get { return this.loopLineMinValueTextColor; }
            set
            {
                if (this.loopLineMinValueTextColor == value)
                    return;
                this.loopLineMinValueTextColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 选项列表

        private bool optionAreaShow = true;
        /// <summary>
        /// 是否显示选项列表
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示选项列表")]
        public bool OptionAreaShow
        {
            get { return this.optionAreaShow; }
            set
            {
                if (this.optionAreaShow == value)
                    return;
                this.optionAreaShow = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int optionAreaWidth = 40;
        /// <summary>
        /// 选项列表区域宽度
        /// </summary>
        [DefaultValue(40)]
        [Description("选项列表区域宽度")]
        public int OptionAreaWidth
        {
            get { return this.optionAreaWidth; }
            set
            {
                if (this.optionAreaWidth == value || this.optionAreaWidth < 0)
                    return;
                this.optionAreaWidth = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private Color optionTextColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 选项文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("选项文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color OptionTextColor
        {
            get { return this.optionTextColor; }
            set
            {
                if (this.optionTextColor == value)
                    return;
                this.optionTextColor = value;
                this.Invalidate();
            }
        }

        private Color optionTipTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 选项提示文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("选项提示文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color OptionTipTextColor
        {
            get { return this.optionTipTextColor; }
            set
            {
                if (this.optionTipTextColor == value)
                    return;
                this.optionTipTextColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 标题

        private TitleAnchors titleAnchor = TitleAnchors.Bottom;
        /// <summary>
        /// 标题布局
        /// </summary>
        [DefaultValue(TitleAnchors.Bottom)]
        [Description("标题布局")]
        public TitleAnchors TitleAnchor
        {
            get { return this.titleAnchor; }
            set
            {
                if (this.titleAnchor == value)
                    return;
                this.titleAnchor = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private int titleAreaHeight = 30;
        /// <summary>
        /// 标题文本区域高度
        /// </summary>
        [DefaultValue(30)]
        [Description("标题文本区域高度")]
        public int TitleAreaHeight
        {
            get { return this.titleAreaHeight; }
            set
            {
                if (this.titleAreaHeight == value || this.titleAreaHeight < 0)
                    return;
                this.titleAreaHeight = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        private string title = "";
        /// <summary>
        /// 标题
        /// </summary>
        [DefaultValue("")]
        [Description("标题")]
        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title == value)
                    return;
                this.title = value;
                this.Invalidate();
            }
        }

        private Color titleColor = Color.FromArgb(219, 112, 147);
        /// <summary>
        /// 标题颜色
        /// </summary>
        [DefaultValue(typeof(Color), "219, 112, 147")]
        [Description("标题颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color TitleColor
        {
            get { return this.titleColor; }
            set
            {
                if (this.titleColor == value)
                    return;
                this.titleColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region 重写属性

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(10);
            }
        }

        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                if (this.Padding == value)
                    return;
                this.Padding = value;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(150, 150); ;
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
        /// 雷达分析图信息
        /// </summary>
        private ChartRectangle ChartMainRect = new ChartRectangle();
        /// <summary>
        /// 分析图选项状态
        /// </summary>
        private ChartItemMoveStatuss ChartItemMoveStatus = ChartItemMoveStatuss.Normal;
        /// <summary>
        /// 默认开始角度
        /// </summary>
        private float DefaultAngle = 270f;
        /// <summary>
        /// 选中环形对角线
        /// </summary>
        private ItemLine SelectItemLine = null;
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;
        /// <summary>
        /// 动画参数
        /// </summary>
        private AnimationOptions options = new AnimationOptions() { AllTransformTime = 200 };
        #endregion

        public RadarChartExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.InitializeChartLoop();
            this.InitializeRectangle();
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.ChartLineItems.Count < 3)
                return;

            Graphics g = e.Graphics;
            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath loop_gp = new GraphicsPath();
            #region 环形

            Pen loopBorder_pen = new Pen(this.LoopBorderColor, this.LoopBorderthickness);
            SolidBrush loopoddback_sb = new SolidBrush(this.LoopOddBackColor);
            SolidBrush loopevenback_sb = new SolidBrush(this.LoopEvenBackColor);
            SolidBrush looplinetext_sb = new SolidBrush(this.LoopLineTextColor);
            SolidBrush looplinemaxvaluetext_sb = this.LoopLineMaxValueShow ? new SolidBrush(this.LoopLineMaxValueTextColor) : null;
            SolidBrush looplineminvaluetext_sb = this.LoopLineMinValueShow ? new SolidBrush(this.LoopLineMinValueTextColor) : null;

            for (int i = 0; i < this.ChartLoopItems.Count; i++)
            {
                if (this.ChartLoopItems[i].DataPoints.Length < 3)
                    continue;

                if (this.ChartType == ChartTypes.Rhombus)
                {
                    loop_gp.Reset();
                    loop_gp.AddPolygon(this.ChartLoopItems[i].DataPoints);
                    loop_gp.CloseFigure();
                    g.DrawPath(loopBorder_pen, loop_gp);

                    loop_gp.Reset();
                    loop_gp.AddPolygon(this.ChartLoopItems[i].DataPoints);
                    if (i > 0)
                    {
                        loop_gp.StartFigure();
                        loop_gp.AddPolygon(this.ChartLoopItems[i - 1].DataPoints);
                    }
                    g.FillPath((i % 2 == 0) ? loopoddback_sb : loopevenback_sb, loop_gp);
                }
                else
                {
                    loop_gp.Reset();
                    loop_gp.AddEllipse(new RectangleF(this.ChartLoopItems[i].LoopCenter.X - this.ChartLoopItems[i].LoopRadius, this.ChartLoopItems[i].LoopCenter.Y - this.ChartLoopItems[i].LoopRadius, this.ChartLoopItems[i].LoopRadius * 2, this.ChartLoopItems[i].LoopRadius * 2));
                    g.DrawPath(loopBorder_pen, loop_gp);

                    loop_gp.Reset();
                    loop_gp.AddEllipse(new RectangleF(this.ChartLoopItems[i].LoopCenter.X - this.ChartLoopItems[i].LoopRadius, this.ChartLoopItems[i].LoopCenter.Y - this.ChartLoopItems[i].LoopRadius, this.ChartLoopItems[i].LoopRadius * 2, this.ChartLoopItems[i].LoopRadius * 2));
                    if (i > 0)
                    {
                        loop_gp.StartFigure();
                        loop_gp.AddEllipse(new RectangleF(this.ChartLoopItems[i - 1].LoopCenter.X - this.ChartLoopItems[i - 1].LoopRadius, this.ChartLoopItems[i - 1].LoopCenter.Y - this.ChartLoopItems[i - 1].LoopRadius, this.ChartLoopItems[i - 1].LoopRadius * 2, this.ChartLoopItems[i - 1].LoopRadius * 2));
                    }
                    g.FillPath((i % 2 == 0) ? loopoddback_sb : loopevenback_sb, loop_gp);
                }
            }

            #endregion

            #region 角度线
            float maxValue = 0f;
            float minValue = 0f;
            List<int> maxIndexList = new List<int>();
            List<int> minIndexList = new List<int>();

            if (this.LoopLineMaxValueShow && this.ChartItemItems.Count > 0)
            {
                for (int i = 0; i < this.ChartItemItems[0].DataTargrt.Length; i++)
                {
                    if (i == 0)
                    {
                        maxValue = this.ChartItemItems[0].DataTargrt[0];
                    }
                    if (this.ChartItemItems[0].DataTargrt[i] > maxValue)
                    {
                        maxValue = this.ChartItemItems[0].DataTargrt[i];
                        maxIndexList.Clear();
                        maxIndexList.Add(i);
                    }
                    else if (this.ChartItemItems[0].DataTargrt[i] == maxValue)
                    {
                        maxIndexList.Add(i);
                    }
                }
            }

            if (this.LoopLineMinValueShow && this.ChartItemItems.Count > 0)
            {
                for (int i = 0; i < this.ChartItemItems[0].DataTargrt.Length; i++)
                {
                    if (i == 0)
                    {
                        minValue = this.ChartItemItems[0].DataTargrt[0];
                    }
                    if (this.ChartItemItems[0].DataTargrt[i] < minValue)
                    {
                        minValue = this.ChartItemItems[0].DataTargrt[i];
                        minIndexList.Clear();
                        minIndexList.Add(i);
                    }
                    else if (this.ChartItemItems[0].DataTargrt[i] == minValue)
                    {
                        minIndexList.Add(i);
                    }
                }
            }

            for (int i = 0; i < this.ChartLineItems.Count; i++)
            {
                string loopline_txt = this.ChartLineItems[i].LineText;
                SizeF loopline_textsize = g.MeasureString(loopline_txt, this.Font);
                PointF loopline_txt_point = this.ChartLineItems[i].LineEndPoint;
                if (this.ChartLineItems[i].LineAngle == 0)
                {
                    loopline_txt_point.Y = loopline_txt_point.Y - loopline_textsize.Height / 2;
                }
                else if (this.ChartLineItems[i].LineAngle < 90)
                {

                }
                else if (this.ChartLineItems[i].LineAngle == 90)
                {
                    loopline_txt_point.X = loopline_txt_point.X - loopline_textsize.Width / 2;
                }
                else if (this.ChartLineItems[i].LineAngle < 180)
                {
                    loopline_txt_point.X = loopline_txt_point.X - loopline_textsize.Width;
                }
                else if (this.ChartLineItems[i].LineAngle == 180)
                {
                    loopline_txt_point.Y = loopline_txt_point.Y - loopline_textsize.Height / 2;
                    loopline_txt_point.X = loopline_txt_point.X - loopline_textsize.Width;
                }
                else if (this.ChartLineItems[i].LineAngle < 270)
                {
                    loopline_txt_point.Y = loopline_txt_point.Y - loopline_textsize.Height;
                    loopline_txt_point.X = loopline_txt_point.X - loopline_textsize.Width;
                }
                else if (this.ChartLineItems[i].LineAngle == 270)
                {
                    loopline_txt_point.Y = loopline_txt_point.Y - loopline_textsize.Height;
                    loopline_txt_point.X = loopline_txt_point.X - loopline_textsize.Width / 2;
                }
                else if (this.ChartLineItems[i].LineAngle < 360)
                {
                    loopline_txt_point.Y = loopline_txt_point.Y - loopline_textsize.Height;
                }

                SolidBrush sb = looplinetext_sb;
                if (maxIndexList.IndexOf(i) != -1)
                {
                    sb = looplinemaxvaluetext_sb;
                }
                if (minIndexList.IndexOf(i) != -1)
                {
                    sb = looplineminvaluetext_sb;
                }

                g.DrawString(loopline_txt, this.Font, sb, loopline_txt_point);

            }

            for (int j = 0; j < this.ChartLineItems.Count; j++)
            {
                g.DrawLine(loopBorder_pen, this.ChartLineItems[j].LoopCenter, this.ChartLineItems[j].LineEndPoint);
            }

            #endregion

            loop_gp.Dispose();
            loopBorder_pen.Dispose();
            loopoddback_sb.Dispose();
            loopevenback_sb.Dispose();
            looplinetext_sb.Dispose();
            if (looplinemaxvaluetext_sb != null)
                looplinemaxvaluetext_sb.Dispose();
            if (looplineminvaluetext_sb != null)
                looplineminvaluetext_sb.Dispose();
            #region 数据
            SolidBrush databack_sb = new SolidBrush(Color.White);
            if (this.ChartItemItems.Count > 0)
            {
                GraphicsPath databack_gp = new GraphicsPath();
                Pen databorder_pen = new Pen(Color.White, 1);
                Pen datadot_pen = new Pen(Color.White, 1);

                for (int i = 0; i < this.ChartItemItems.Count; i++)
                {
                    if (this.ChartItemItems[i].DataPoints.Length < 2)
                        continue;

                    databack_gp.Reset();
                    databack_gp.AddPolygon(this.ChartItemItems[i].DataPoints);
                    databack_gp.CloseFigure();

                    databack_sb.Color = Color.FromArgb(50, this.ChartItemItems[i].BackColor);
                    g.FillPath(databack_sb, databack_gp);

                    databorder_pen.Color = this.ChartItemItems[i].BackColor;
                    g.DrawPath(databorder_pen, databack_gp);

                    datadot_pen.Color = this.ChartItemItems[i].BackColor;
                    for (int j = 0; j < this.ChartItemItems[i].DataPoints.Length; j++)
                    {
                        g.DrawEllipse(datadot_pen, this.ChartItemItems[i].DataRectF[j]);
                    }
                }
                databack_gp.Dispose();
                databorder_pen.Dispose();
                datadot_pen.Dispose();

            }

            #endregion

            g.SmoothingMode = sm;

            #region 数据选项
            if (this.OptionAreaShow)
            {
                float desc_padding = 5;
                float descitem_height = 0;

                SolidBrush descitem_sb = new SolidBrush(Color.White);
                SolidBrush desctext_sb = new SolidBrush(this.OptionTextColor);
                for (int i = 0; i < this.ChartItemItems.Count; i++)
                {
                    descitem_sb.Color = this.ChartItemItems[i].BackColor;
                    SizeF desc_size = g.MeasureString(this.ChartItemItems[i].Text, this.Font);
                    RectangleF desc_item_rect = new RectangleF(this.ChartMainRect.OptionRect.X + desc_padding, this.ChartMainRect.OptionRect.Y + descitem_height, 20, 10);
                    RectangleF desctxt_rect = new RectangleF(this.ChartMainRect.OptionRect.X + desc_padding + desc_item_rect.Width + 5, this.ChartMainRect.OptionRect.Y + descitem_height, this.ChartMainRect.OptionRect.Width - desc_padding - desc_item_rect.Width - 5, desc_size.Height);

                    g.FillRectangle(descitem_sb, desc_item_rect);
                    g.DrawString(this.ChartItemItems[i].Text, this.Font, desctext_sb, desctxt_rect);

                    descitem_height += desc_size.Height + desc_padding;
                }

                descitem_sb.Dispose();
                desctext_sb.Dispose();
            }
            #endregion

            #region 刻度
            SolidBrush loopscaletext_sb = new SolidBrush(this.LoopScaleTextColor);
            Pen loopscaletext_pen = new Pen(this.LoopScaleTextColor);
            for (int i = 0; i < this.ChartLoopItems.Count; i++)
            {
                string loopscale_txt = (this.LoopInterval * (i + 1)).ToString();
                SizeF loopscale_size = g.MeasureString(loopscale_txt, this.Font);
                g.DrawLine(loopscaletext_pen, this.ChartLoopItems[i].DataPoints[0].X, this.ChartLoopItems[i].DataPoints[0].Y, this.ChartLoopItems[i].DataPoints[0].X + 3, this.ChartLoopItems[i].DataPoints[0].Y);

                g.DrawString(loopscale_txt, this.Font, loopscaletext_sb, new RectangleF(this.ChartLoopItems[i].DataPoints[0].X + 5, this.ChartLoopItems[i].DataPoints[0].Y - loopscale_size.Height / 2, loopscale_size.Width, loopscale_size.Height));
            }
            loopscaletext_sb.Dispose();
            #endregion

            #region 数据点提示

            if (this.ChartItemMoveStatus == ChartItemMoveStatuss.Enter)
            {
                if (this.SelectItemLine != null)
                {
                    float datadottipback_padding = 2;
                    databack_sb.Color = Color.FromArgb(100, this.ChartItemItems[this.SelectItemLine.ItemIndex].BackColor);
                    Pen tipborder_pen = new Pen(this.ChartItemItems[this.SelectItemLine.ItemIndex].BackColor);
                    SolidBrush datadottiptext_sb = new SolidBrush(this.OptionTipTextColor);
                    StringFormat datadottiptext_sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                    string datadottip_txt = this.SelectItemLine.LineIndex >= this.ChartItemItems[this.SelectItemLine.ItemIndex].DataTargrt.Count() ? " " : this.ChartItemItems[this.SelectItemLine.ItemIndex].DataTargrt[this.SelectItemLine.LineIndex].ToString();
                    SizeF datadottiptxt_size = g.MeasureString(datadottip_txt, this.Font);
                    RectangleF datadottip_rect = new RectangleF(this.ChartItemItems[this.SelectItemLine.ItemIndex].DataRectF[this.SelectItemLine.LineIndex].X - (datadottiptxt_size.Width + datadottipback_padding * 2) / 2, this.ChartItemItems[this.SelectItemLine.ItemIndex].DataRectF[this.SelectItemLine.LineIndex].Y - datadottiptxt_size.Height - datadottipback_padding * 3, datadottiptxt_size.Width + datadottipback_padding * 2, datadottiptxt_size.Height + datadottipback_padding * 2);

                    g.FillRectangle(databack_sb, datadottip_rect);
                    g.DrawRectangle(tipborder_pen, datadottip_rect.X, datadottip_rect.Y, datadottip_rect.Width, datadottip_rect.Height);
                    g.DrawString(datadottip_txt, this.Font, datadottiptext_sb, datadottip_rect, datadottiptext_sf);

                    datadottiptext_sb.Dispose();
                    tipborder_pen.Dispose();
                    datadottiptext_sf.Dispose();
                }
            }

            #endregion
            databack_sb.Dispose();

            #region 标题
            SolidBrush title_sb = new SolidBrush(this.TitleColor);
            StringFormat title_sf = new StringFormat() { Alignment = StringAlignment.Center };

            g.DrawString(this.Title, this.Font, title_sb, this.ChartMainRect.TitleRect, title_sf);
            title_sb.Dispose();
            title_sf.Dispose();
            #endregion


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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.ChartMainRect.ChartRect.Contains(e.Location))
            {
                for (int i = 0; i < this.ChartItemItems.Count; i++)
                {
                    for (int j = 0; j < this.ChartItemItems[i].DataRectF.Length; j++)
                    {
                        if (this.ChartItemItems[i].DataRectF[j].Contains(e.Location))
                        {
                            this.SelectItemLine = new ItemLine() { ItemIndex = i, LineIndex = j };
                            this.ChartItemMoveStatus = ChartItemMoveStatuss.Enter;
                            this.Invalidate();
                            return;
                        }
                    }
                }
                if (this.ChartItemMoveStatus != ChartItemMoveStatuss.Normal)
                {
                    this.ChartItemMoveStatus = ChartItemMoveStatuss.Normal;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.ChartItemMoveStatus != ChartItemMoveStatuss.Normal)
            {
                this.ChartItemMoveStatus = ChartItemMoveStatuss.Normal;
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeRectangle();
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
            bool finish = false;
            this.usedTime += AnimationStaticTimer.timer.Interval;
            if (this.usedTime > this.options.AllTransformTime)
            {
                this.usedTime = this.options.AllTransformTime;
                AnimationStaticTimer.AnimationStop(this);
                finish = true;
            }

            double progress = AnimationTimer.GetProgress(AnimationTypes.EaseBoth, this.options, this.usedTime);
            if (finish)
            {
                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;

                this.usedTime = 0;
            }

            #region 数据
            PointF chart_center = new PointF(this.ChartMainRect.ChartRect.X + this.ChartMainRect.ChartRect.Width / 2, this.ChartMainRect.ChartRect.Y + this.ChartMainRect.ChartRect.Height / 2);
            for (int i = 0; i < this.ChartItemItems.Count; i++)
            {
                this.ChartItemItems[i].DataPoints = new PointF[this.ChartLineItems.Count];
                this.ChartItemItems[i].DataRectF = new RectangleF[this.ChartLineItems.Count];

                float sum = this.ChartLoopItems.Count * this.LoopInterval;
                int datalen = this.ChartItemItems[i].DataCurrent.Count();
                int linelen = this.ChartLineItems.Count;
                for (int j = 0; j < linelen; j++)
                {
                    float value = (float)(this.ChartItemItems[i].DataCurrent[j] + (this.ChartItemItems[i].DataTargrt[j] - this.ChartItemItems[i].DataBefore[j]) * progress);
                    PointF pointf = chart_center;
                    if (j < datalen)
                    {
                        pointf = ControlCommom.CalculatePointForAngle(chart_center, this.ChartLineItems[j].LoopRadius * value / sum, this.ChartLineItems[j].LineAngle);
                    }
                    this.ChartItemItems[i].DataCurrent[j] = value;
                    this.ChartItemItems[i].DataPoints[j] = pointf;
                    this.ChartItemItems[i].DataRectF[j] = new RectangleF(this.ChartItemItems[i].DataPoints[j].X - 2, this.ChartItemItems[i].DataPoints[j].Y - 2, 4, 4);
                }
            }
            #endregion
            this.Invalidate();
        }

        /// <summary>
        /// 动画更新数据
        /// </summary>
        /// <param name="AnimationData"></param>
        public void AnimationChangeData(List<ChartItemAnimationData> AnimationData)
        {
            if (AnimationData.Count != this.ChartItemItems.Count)
                return;

            bool dataChanged = false;
            for (int i = 0; i < this.ChartItemItems.Count; i++)
            {
                for (int j = 0; j < this.ChartItemItems[i].DataCurrent.Length; j++)
                {
                    if (this.ChartItemItems[i].DataCurrent[j] != AnimationData[i].Data[j])
                    {
                        dataChanged = true;
                        break;
                    }
                }
            }
            if (dataChanged)
            {
                for (int i = 0; i < this.ChartItemItems.Count; i++)
                {
                    this.ChartItemItems[i].DataBefore = this.ChartItemItems[i].DataCurrent;
                    this.ChartItemItems[i].DataTargrt = AnimationData[i].Data;
                }
                this.usedTime = 0;
                AnimationStaticTimer.AnimationStart(this);
            }
        }

        /// <summary>
        /// 绑定数据后更新
        /// </summary>
        public void DataBind()
        {
            for (int i = 0; i < this.ChartItemItems.Count; i++)
            {
                this.ChartItemItems[i].DataBefore = this.ChartItemItems[i].DataCurrent;
                this.ChartItemItems[i].DataTargrt = this.ChartItemItems[i].DataCurrent;
                this.InitializeRectangle();
                this.Invalidate();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化环形配置
        /// </summary>
        private void InitializeChartLoop()
        {
            this.ChartLoopItems.Clear();
            for (int i = 0; i < this.LoopCount; i++)
            {
                this.ChartLoopItems.Add(new ChartLoop());
            }
        }

        /// <summary>
        /// 初始化控件布局
        /// </summary>
        private void InitializeRectangle()
        {
            if (this.ChartLineItems.Count < 3)
                return;

            float now_radius = 0f;
            float now_angle = this.DefaultAngle;
            Rectangle rect = new Rectangle(this.ClientRectangle.X + this.Padding.Left, this.ClientRectangle.Y + this.Padding.Top, this.ClientRectangle.Width - this.Padding.Left - this.Padding.Right, this.ClientRectangle.Height - this.Padding.Top - this.Padding.Bottom);
            Rectangle option_rect = new Rectangle();
            int ptionarea_width = !this.OptionAreaShow ? 0 : this.OptionAreaWidth;
            #region Rect
            if (TitleAnchor == TitleAnchors.Top)
            {
                this.ChartMainRect.TitleRect = new RectangleF(rect.X, rect.Y, rect.Width, this.TitleAreaHeight);
                if (this.ChartAnchor == ChartAnchors.Left)
                {
                    this.ChartMainRect.OptionRect = !this.OptionAreaShow ? option_rect : new RectangleF(rect.Right - ptionarea_width, rect.Y + this.TitleAreaHeight, ptionarea_width, rect.Height - this.TitleAreaHeight);
                    this.ChartMainRect.ChartRect = new RectangleF(rect.X + (rect.Width - ptionarea_width - this.ChartSize.Width) / 2, rect.Y + this.TitleAreaHeight + (rect.Height - this.ChartSize.Height) / 2, this.ChartSize.Width, this.ChartSize.Height);
                }
                else
                {
                    this.ChartMainRect.OptionRect = !this.OptionAreaShow ? option_rect : new RectangleF(rect.X, rect.Y + this.TitleAreaHeight, ptionarea_width, rect.Height - this.TitleAreaHeight);
                    this.ChartMainRect.ChartRect = new RectangleF(rect.X + ptionarea_width + (rect.Width - ptionarea_width - this.ChartSize.Width) / 2, rect.Y + this.TitleAreaHeight + (rect.Height - this.ChartSize.Height) / 2, this.ChartSize.Width, this.ChartSize.Height);
                }
            }
            else
            {
                this.ChartMainRect.TitleRect = new RectangleF(rect.X, rect.Bottom - this.TitleAreaHeight, rect.Width, this.TitleAreaHeight);
                if (this.ChartAnchor == ChartAnchors.Left)
                {
                    this.ChartMainRect.OptionRect = !this.OptionAreaShow ? option_rect : new RectangleF(rect.Right - ptionarea_width, rect.Y, ptionarea_width, rect.Height - this.TitleAreaHeight);
                    this.ChartMainRect.ChartRect = new RectangleF(rect.X + (rect.Width - ptionarea_width - this.ChartSize.Width) / 2, rect.Y + (rect.Height - this.ChartSize.Height) / 2, this.ChartSize.Width, this.ChartSize.Height);
                }
                else
                {
                    this.ChartMainRect.OptionRect = !this.OptionAreaShow ? option_rect : new RectangleF(rect.X, rect.Y, ptionarea_width, rect.Height - this.TitleAreaHeight);
                    this.ChartMainRect.ChartRect = new RectangleF(rect.X + ptionarea_width + (rect.Width - ptionarea_width - this.ChartSize.Width) / 2, rect.Y + (rect.Height - this.ChartSize.Height) / 2, this.ChartSize.Width, this.ChartSize.Height);
                }
            }
            #endregion

            PointF chart_center = new PointF(this.ChartMainRect.ChartRect.X + this.ChartMainRect.ChartRect.Width / 2, this.ChartMainRect.ChartRect.Y + this.ChartMainRect.ChartRect.Height / 2);
            float chart_radius = Math.Min(this.ChartMainRect.ChartRect.Width, this.ChartMainRect.ChartRect.Height) / 2;

            #region 圆环
            for (int i = 0; i < this.ChartLoopItems.Count; i++)
            {
                this.ChartLoopItems[i].DataPoints = new PointF[this.ChartLineItems.Count];

                now_angle = this.DefaultAngle;
                now_radius = chart_radius / (this.ChartLoopItems.Count) * (i + 1);
                this.ChartLoopItems[i].LoopCenter = chart_center;
                this.ChartLoopItems[i].LoopRadius = now_radius;

                for (int j = 0; j < this.ChartLineItems.Count; j++)
                {
                    now_angle = this.DefaultAngle + 360f / this.ChartLineItems.Count * j;
                    if (now_angle > 360)
                        now_angle -= 360;

                    this.ChartLoopItems[i].DataPoints[j] = ControlCommom.CalculatePointForAngle(chart_center, now_radius, now_angle);
                }
            }

            #endregion

            #region 角度线
            now_angle = this.DefaultAngle;
            now_radius = chart_radius / (this.ChartLoopItems.Count) * this.ChartLoopItems.Count;

            for (int j = 0; j < this.ChartLineItems.Count; j++)
            {
                now_angle = this.DefaultAngle + 360f / this.ChartLineItems.Count * j;
                if (now_angle > 360)
                    now_angle -= 360;

                this.ChartLineItems[j].LoopCenter = chart_center;
                this.ChartLineItems[j].LoopRadius = now_radius;
                this.ChartLineItems[j].LineAngle = now_angle;
                this.ChartLineItems[j].LineEndPoint = ControlCommom.CalculatePointForAngle(chart_center, now_radius, now_angle);
            }
            #endregion

            #region 数据
            for (int i = 0; i < this.ChartItemItems.Count; i++)
            {
                this.ChartItemItems[i].DataPoints = new PointF[this.ChartLineItems.Count];
                this.ChartItemItems[i].DataRectF = new RectangleF[this.ChartLineItems.Count];

                float sum = this.ChartLoopItems.Count * this.LoopInterval;
                int datalen = this.ChartItemItems[i].DataCurrent.Count();
                int linelen = this.ChartLineItems.Count;
                for (int j = 0; j < linelen; j++)
                {
                    PointF pointf = chart_center;
                    if (j < datalen)
                    {
                        pointf = ControlCommom.CalculatePointForAngle(chart_center, this.ChartLineItems[j].LoopRadius * this.ChartItemItems[i].DataCurrent[j] / sum, this.ChartLineItems[j].LineAngle);
                    }
                    this.ChartItemItems[i].DataPoints[j] = pointf;
                    this.ChartItemItems[i].DataRectF[j] = new RectangleF(this.ChartItemItems[i].DataPoints[j].X - 2, this.ChartItemItems[i].DataPoints[j].Y - 2, 4, 4);
                }
            }
            #endregion

        }

        #endregion

        #region 类

        /// <summary>
        /// 分析图环形配置集合
        /// </summary>
        [Description("分析图环形配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ChartLoopCollection : IList, ICollection, IEnumerable
        {
            private ArrayList chartLoopList = new ArrayList();
            private RadarChartExt owner;

            public ChartLoopCollection(RadarChartExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ChartLoop[] listArray = new ChartLoop[this.chartLoopList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ChartLoop)this.chartLoopList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.chartLoopList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.chartLoopList.Count;
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
                if (!(value is ChartLoop))
                {
                    throw new ArgumentException("ChartLoop");
                }
                return this.Add((ChartLoop)value);
            }

            public int Add(ChartLoop item)
            {
                this.chartLoopList.Add(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.chartLoopList.Clear();
                this.owner.InitializeRectangle();
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
                if (item is ChartLoop)
                {
                    return this.Contains((ChartLoop)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ChartLoop)
                {
                    return this.chartLoopList.IndexOf(item);
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
                if (!(value is ChartLoop))
                {
                    throw new ArgumentException("ChartLoop");
                }
                this.Remove((ChartLoop)value);
            }

            public void Remove(ChartLoop item)
            {
                this.chartLoopList.Remove(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.chartLoopList.RemoveAt(index);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public ChartLoop this[int index]
            {
                get
                {
                    if (index >= this.Count)
                        return null;
                    return (ChartLoop)this.chartLoopList[index];
                }
                set
                {
                    this.chartLoopList[index] = (ChartLoop)value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.chartLoopList[index];
                }
                set
                {
                    this.chartLoopList[index] = (ChartLoop)value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 分析图角度线配置集合
        /// </summary>
        [Description("分析图角度线配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ChartLineCollection : IList, ICollection, IEnumerable
        {
            private ArrayList chartLineList = new ArrayList();
            private RadarChartExt owner;

            public ChartLineCollection(RadarChartExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ChartLine[] listArray = new ChartLine[this.chartLineList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ChartLine)this.chartLineList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.chartLineList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.chartLineList.Count;
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
                if (!(value is ChartLine))
                {
                    throw new ArgumentException("ChartLine");
                }
                return this.Add((ChartLine)value);
            }

            public int Add(ChartLine item)
            {
                this.chartLineList.Add(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.chartLineList.Clear();
                this.owner.InitializeRectangle();
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
                if (item is ChartLine)
                {
                    return this.Contains((ChartLine)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ChartLine)
                {
                    return this.chartLineList.IndexOf(item);
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
                if (!(value is ChartLine))
                {
                    throw new ArgumentException("ChartLine");
                }
                this.Remove((ChartLine)value);
            }

            public void Remove(ChartLine item)
            {
                this.chartLineList.Remove(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.chartLineList.RemoveAt(index);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public ChartLine this[int index]
            {
                get
                {
                    if (index >= this.Count)
                        return null;
                    return (ChartLine)this.chartLineList[index];
                }
                set
                {
                    this.chartLineList[index] = (ChartLine)value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.chartLineList[index];
                }
                set
                {
                    this.chartLineList[index] = (ChartLine)value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 分析图选项集合
        /// </summary>
        [Description("分析图选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ChartItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList chartItemList = new ArrayList();
            private RadarChartExt owner;

            public ChartItemCollection(RadarChartExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ChartItem[] listArray = new ChartItem[this.chartItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ChartItem)this.chartItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.chartItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.chartItemList.Count;
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
                if (!(value is ChartItem))
                {
                    throw new ArgumentException("ChartItem");
                }
                return this.Add((ChartItem)value);
            }

            public int Add(ChartItem value)
            {
                this.chartItemList.Add(value);
                return this.Count - 1;
            }

            public void Clear()
            {
                this.chartItemList.Clear();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is ChartItem)
                {
                    return this.Contains((ChartItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ChartItem)
                {
                    return this.chartItemList.IndexOf(item);
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
                if (!(value is ChartItem))
                {
                    throw new ArgumentException("ChartItem");
                }
                this.chartItemList.Remove((ChartItem)value);
            }

            public void Remove(ChartItem item)
            {
                this.chartItemList.Remove(item);
            }

            public void RemoveAt(int index)
            {
                this.chartItemList.RemoveAt(index);
            }

            public ChartItem this[int index]
            {
                get
                {
                    return (ChartItem)this.chartItemList[index];
                }
                set
                {
                    this.chartItemList[index] = (ChartItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.chartItemList[index];
                }
                set
                {
                    this.chartItemList[index] = (ChartItem)value;
                }
            }

            #endregion

        }

        /// <summary>
        /// 分析图信息
        /// </summary>
        [Description("分析图信息")]
        public class ChartRectangle
        {
            /// <summary>
            /// 雷达分析图标题Rect
            /// </summary>
            public RectangleF TitleRect;
            /// <summary>
            /// 雷达分析图选项Rect
            /// </summary>
            public RectangleF OptionRect;
            /// <summary>
            /// 雷达分析图Rect
            /// </summary>
            public RectangleF ChartRect;
        }

        /// <summary>
        /// 环形对角线
        /// </summary>
        [Description("环形对角线")]
        public class ItemLine
        {
            /// <summary>
            /// 选项索引
            /// </summary>
            [Description("选项索引")]
            public int ItemIndex { get; set; }
            /// <summary>
            /// 对角线索引
            /// </summary>
            [Description("对角线索引")]
            public int LineIndex { get; set; }
        }

        /// <summary>
        /// 分析图环形配置
        /// </summary>
        [Description("分析图环形配置")]
        public class ChartLoop
        {
            /// <summary>
            /// 环形中心坐标
            /// </summary>
            [Description("环形中心坐标")]
            public PointF LoopCenter { get; set; }
            /// <summary>
            /// 环形半径
            /// </summary>
            [Description("环形半径")]
            public float LoopRadius { get; set; }
            /// <summary>
            /// 角度值坐标
            /// </summary>
            [Description("角度值坐标")]
            public PointF[] DataPoints { get; set; }
        }

        /// <summary>
        /// 分析图角度线配置
        /// </summary>
        [Description("分析图角度线配置")]
        public class ChartLine
        {
            /// <summary>
            /// 环形中心坐标
            /// </summary>
            [Browsable(false)]
            [Description("环形中心坐标")]
            public PointF LoopCenter { get; set; }
            /// <summary>
            /// 环形半径
            /// </summary>
            [Browsable(false)]
            [Description("环形半径")]
            public float LoopRadius { get; set; }
            /// <summary>
            /// 角度线文本
            /// </summary>
            [Description("角度线文本")]
            public string LineText { get; set; }
            /// <summary>
            /// 角度线角度
            /// </summary>
            [Browsable(false)]
            [Description("角度线角度")]
            public float LineAngle { get; set; }
            /// <summary>
            /// 角度线终点坐标
            /// </summary>
            [Browsable(false)]
            [Description("角度线终点坐标")]
            public PointF LineEndPoint { get; set; }

        }

        /// <summary>
        /// 分析图选项
        /// </summary>
        [Description("分析图选项")]
        public class ChartItem
        {
            /// <summary>
            /// 分析图选项文本
            /// </summary>
            [Description("分析图选项文本")]
            public string Text { get; set; }

            /// <summary>
            /// 分析图选项背景颜色
            /// </summary>
            [Description("分析图选项背景颜色")]
            public Color BackColor { get; set; }

            /// <summary>
            /// 当前角度线上数据
            /// </summary>
            [Description("当前角度线上数据")]
            public float[] DataCurrent { get; set; }

            /// <summary>
            /// 运动前角度线上数据
            /// </summary>
            [Description("运动前角度线上数据")]
            public float[] DataBefore { get; set; }
            /// <summary>
            /// 目标角度线上数据
            /// </summary>
            [Description("目标角度线上数据")]
            public float[] DataTargrt { get; set; }

            /// <summary>
            /// 角度线上数据坐标
            /// </summary>
            [Description("角度线上数据坐标")]
            public PointF[] DataPoints { get; set; }

            /// <summary>
            /// 角度线上数据RectF
            /// </summary>
            [Description("角度线上数据RectF")]
            public RectangleF[] DataRectF { get; set; }
        }

        /// <summary>
        /// 分析图选项动画数据
        /// </summary>
        [Description("分析图选项数据")]
        public class ChartItemAnimationData
        {
            /// <summary>
            /// 角度线上数据
            /// </summary>
            [Description("角度线上数据")]
            public float[] Data { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 雷达分析图显示类型
        /// </summary>
        [Description("雷达分析图显示类型")]
        public enum ChartTypes
        {
            /// <summary>
            /// 圆形
            /// </summary>
            Circle,
            /// <summary>
            /// 菱形
            /// </summary>
            Rhombus
        }

        /// <summary>
        /// 分析图布局
        /// </summary>
        [Description("分析图布局")]
        public enum ChartAnchors
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
        /// 描述布局
        /// </summary>
        [Description("描述布局")]
        public enum TitleAnchors
        {
            /// <summary>
            /// 顶部
            /// </summary>
            Top,
            /// <summary>
            /// 底部
            /// </summary>
            Bottom
        }

        /// <summary>
        /// 分析图选项状态
        /// </summary>
        [Description("分析图选项状态")]
        public enum ChartItemMoveStatuss
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 鼠标进入
            /// </summary>
            Enter
        }

        #endregion
    }
}
