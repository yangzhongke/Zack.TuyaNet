
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
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 仪表控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("仪表控件")]
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class MeterExt : Control, IAnimationStaticTimer
    {
        #region 新增事件

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        private event ValueChangedEventHandler valueChanged;
        /// <summary>
        /// 值更改事件
        /// </summary>
        [Description("值更改事件")]
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

        private int animationTime = 150;
        /// <summary>
        /// 动画时间(毫秒)
        /// </summary>
        [DefaultValue(150)]
        [Description("动画时间(毫秒)")]
        public int AnimationTime
        {
            get { return this.animationTime; }
            set
            {
                if (this.animationTime == value)
                    return;

                this.options.AllTransformTime = value;
                this.animationTime = value;
            }
        }

        #region 内圆
        private int circleRadius = 40;
        /// <summary>
        /// 控件内部圆形半径
        /// </summary>
        [DefaultValue(40)]
        [Description("控件内部圆形半径")]
        public int CircleRadius
        {
            get { return this.circleRadius; }
            set
            {
                if (this.circleRadius == value || value < 1)
                    return;
                this.circleRadius = value;
                this.Invalidate();
            }
        }

        private int arcAngle = 270;
        /// <summary>
        /// 控件弧度大小
        /// </summary>
        [DefaultValue(270)]
        [Description("控件弧度大小")]
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
        #endregion

        #region 背景

        private bool backShow = true;
        /// <summary>
        /// 是否显示背景
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示背景")]
        public bool BackShow
        {
            get { return this.backShow; }
            set
            {
                if (this.backShow == value)
                    return;
                this.backShow = value;
                this.Invalidate();
            }
        }

        private int backBorder = 5;
        /// <summary>
        /// 背景边框大小
        /// </summary>
        [DefaultValue(5)]
        [Description("背景边框大小")]
        public int BackBorder
        {
            get { return this.backBorder; }
            set
            {
                if (this.backBorder == value || value < 0)
                    return;
                this.backBorder = value;
                this.Invalidate();
            }
        }

        private Color backBorderColor = Color.Gray;
        /// <summary>
        /// 背景边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("背景边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackBorderColor
        {
            get { return this.backBorderColor; }
            set
            {
                if (this.backBorderColor == value)
                    return;
                this.backBorderColor = value;
                this.Invalidate();
            }
        }

        private int backShadow = 5;
        /// <summary>
        /// 背景边框阴影
        /// </summary>
        [DefaultValue(5)]
        [Description("背景边框阴影")]
        public int BackShadow
        {
            get { return this.backShadow; }
            set
            {
                if (this.backShadow == value || value < 0)
                    return;
                this.backShadow = value;
                this.Invalidate();
            }
        }

        private Color backShadowColor = Color.Gray;
        /// <summary>
        /// 背景边框阴影颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("背景边框阴影颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackShadowColor
        {
            get { return this.backShadowColor; }
            set
            {
                if (this.backShadowColor == value)
                    return;
                this.backShadowColor = value;
                this.Invalidate();
            }
        }

        private Color backInnerColor = Color.FromArgb(220, 220, 220);
        /// <summary>
        /// 背景内容颜色
        /// </summary>
        [DefaultValue(typeof(Color), "220, 220, 220")]
        [Description("背景内容颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BackInnerColor
        {
            get { return this.backInnerColor; }
            set
            {
                if (this.backInnerColor == value)
                    return;
                this.backInnerColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 弧线

        private bool arcShow = true;
        /// <summary>
        /// 是否显示弧线
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示弧线")]
        public bool ArcShow
        {
            get { return this.arcShow; }
            set
            {
                if (this.arcShow == value)
                    return;
                this.arcShow = value;
                this.Invalidate();
            }
        }

        private int arcThickness = 5;
        /// <summary>
        /// 弧线厚度
        /// </summary>
        [DefaultValue(5)]
        [Description("弧线厚度")]
        public int ArcThickness
        {
            get { return this.arcThickness; }
            set
            {
                if (this.arcThickness == value || value < 0 || value > this.CircleRadius)
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

        private Color arcBackColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 弧线背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
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

        private Color arcValueColor = Color.FromArgb(154, 205, 50);
        /// <summary>
        /// 弧线值颜色
        /// </summary>
        [DefaultValue(typeof(Color), "154, 205, 50")]
        [Description("弧线值颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ArcValueColor
        {
            get { return this.arcValueColor; }
            set
            {
                if (this.arcValueColor == value)
                    return;
                this.arcValueColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 刻度

        private float scaleInterval = 20;
        /// <summary>
        /// 刻度间隔值大小
        /// </summary>
        [DefaultValue(20)]
        [Description("刻度间隔值大小")]
        public float ScaleInterval
        {
            get { return this.scaleInterval; }
            set
            {
                if (this.scaleInterval == value || value < 0f)
                    return;
                this.scaleInterval = value;
                this.Invalidate();
            }
        }

        private int scaleWidth = 3;
        /// <summary>
        /// 刻度宽度
        /// </summary>
        [DefaultValue(3)]
        [Description("刻度宽度")]
        public int ScaleWidth
        {
            get { return this.scaleWidth; }
            set
            {
                if (this.scaleWidth == value || value < 1)
                    return;
                this.scaleWidth = value;
                this.Invalidate();
            }
        }

        private int scaleHeight = 10;
        /// <summary>
        /// 刻度高度
        /// </summary>
        [DefaultValue(10)]
        [Description("刻度高度")]
        public int ScaleHeight
        {
            get { return this.scaleHeight; }
            set
            {
                if (this.scaleHeight == value)
                    return;
                this.scaleHeight = value;
                this.Invalidate();
            }
        }

        private Color scaleColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 刻度颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("刻度颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScaleColor
        {
            get { return this.scaleColor; }
            set
            {
                if (this.scaleColor == value)
                    return;
                this.scaleColor = value;
                this.Invalidate();
            }
        }

        private int scaleTextRadius = 25;
        /// <summary>
        /// 刻度文本环形半径大小
        /// </summary>
        [DefaultValue(25)]
        [Description("刻度文本环形半径大小")]
        public int ScaleTextRadius
        {
            get { return this.scaleTextRadius; }
            set
            {
                if (this.scaleTextRadius == value || value < 0)
                    return;
                this.scaleTextRadius = value;
                this.Invalidate();
            }
        }

        private Color scaleTextColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 刻度文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("刻度文本颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ScaleTextColor
        {
            get { return this.scaleTextColor; }
            set
            {
                if (this.scaleTextColor == value)
                    return;
                this.scaleTextColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 子刻度

        private bool splitScaleShow = true;
        /// <summary>
        /// 是否显示子刻度
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示子刻度")]
        public bool SplitScaleShow
        {
            get { return this.splitScaleShow; }
            set
            {
                if (this.splitScaleShow == value)
                    return;
                this.splitScaleShow = value;
                this.Invalidate();
            }
        }

        private int splitScaleWidth = 2;
        /// <summary>
        /// 子刻度宽度
        /// </summary>
        [DefaultValue(2)]
        [Description("子刻度宽度")]
        public int SplitScaleWidth
        {
            get { return this.splitScaleWidth; }
            set
            {
                if (this.splitScaleWidth == value || value < 0)
                    return;
                this.splitScaleWidth = value;
                this.Invalidate();
            }
        }

        private int splitScaleHeight = 5;
        /// <summary>
        /// 子刻度高度
        /// </summary>
        [DefaultValue(5)]
        [Description("子刻度高度")]
        public int SplitScaleHeight
        {
            get { return this.splitScaleHeight; }
            set
            {
                if (this.splitScaleHeight == value || value < 0)
                    return;
                this.splitScaleHeight = value;
                this.Invalidate();
            }
        }

        private int splitScaleCount = 5;
        /// <summary>
        /// 刻度分隔数量
        /// </summary>
        [DefaultValue(5)]
        [Description("刻度分隔数量")]
        public int SplitScaleCount
        {
            get { return this.splitScaleCount; }
            set
            {
                if (this.splitScaleCount == value || value < 0)
                    return;
                this.splitScaleCount = value;
                this.Invalidate();
            }
        }

        private Color splitScaleColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 子刻度颜色
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("子刻度颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SplitScaleColor
        {
            get { return this.splitScaleColor; }
            set
            {
                if (this.splitScaleColor == value)
                    return;
                this.splitScaleColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 渐变

        private bool gradualShow = false;
        /// <summary>
        /// 是否显示弧形渐变
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示弧形渐变")]
        public bool GradualShow
        {
            get { return this.gradualShow; }
            set
            {
                if (this.gradualShow == value)
                    return;
                this.gradualShow = value;
                this.Invalidate();
            }
        }

        private int gradualThickness = 20;
        /// <summary>
        /// 渐变弧线背景厚度
        /// </summary>
        [DefaultValue(20)]
        [Description("渐变弧线背景厚度")]
        public int GradualThickness
        {
            get { return this.gradualThickness; }
            set
            {
                if (this.gradualThickness == value || value < 0)
                    return;
                this.gradualThickness = value;
                this.Invalidate();
            }
        }

        private ColorItemCollection gradualColorCollection;
        /// <summary>
        /// 渐变颜色配置集合
        /// </summary>
        [Description("渐变颜色配置集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorItemCollection GradualColorItems
        {
            get
            {
                if (this.gradualColorCollection == null)
                    this.gradualColorCollection = new ColorItemCollection(this);
                return this.gradualColorCollection;
            }
        }

        #endregion

        #region 指针
        private Color pointerColor = Color.FromArgb(107, 142, 35);
        /// <summary>
        /// 指针颜色
        /// </summary>
        [DefaultValue(typeof(Color), "107, 142, 35")]
        [Description("指针颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PointerColor
        {
            get { return this.pointerColor; }
            set
            {
                if (this.pointerColor == value)
                    return;
                this.pointerColor = value;
                this.Invalidate();
            }
        }

        private Color pointerCapColor = Color.FromArgb(107, 142, 35);
        /// <summary>
        /// 针帽颜色
        /// </summary>
        [DefaultValue(typeof(Color), "107, 142, 35")]
        [Description("针帽颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color PointerCapColor
        {
            get { return this.pointerCapColor; }
            set
            {
                if (this.pointerCapColor == value)
                    return;
                this.pointerCapColor = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 值

        private bool valueShow = false;
        /// <summary>
        /// 是否显示值文本
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示值文本")]
        public bool ValueShow
        {
            get { return this.valueShow; }
            set
            {
                if (this.valueShow == value)
                    return;
                this.valueShow = value;
                this.Invalidate();
            }
        }

        private float minvalue = 0f;
        /// <summary>
        /// 最小值
        /// </summary>
        [DefaultValue(0f)]
        [Description("最小值")]
        public float MinValue
        {
            get { return this.minvalue; }
            set
            {
                if (this.minvalue == value || value >= this.MaxValue)
                    return;
                this.minvalue = value;
                this.Invalidate();
            }
        }

        private float maxvalue = 100f;
        /// <summary>
        /// 最大值
        /// </summary>
        [DefaultValue(100f)]
        [Description("最大值")]
        public float MaxValue
        {
            get { return this.maxvalue; }
            set
            {
                if (this.maxvalue == value || value <= this.MinValue)
                    return;
                this.maxvalue = value;
                this.Invalidate();
            }
        }

        private float value = 0f;
        /// <summary>
        /// 值
        /// </summary>
        [DefaultValue(0f)]
        [Description("值")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value || value < this.MinValue || value > this.MaxValue)
                    return;

                if (this.DesignMode)
                {
                    this.animationCurrentValue = value;
                    this.value = value;
                    this.Invalidate();
                }
                else
                {
                    this.animationInitialValue = this.value;
                    this.animationCurrentValue = this.value;
                    this.value = value;

                    this.usedTime = 0;
                    AnimationStaticTimer.AnimationStart(this);
                    this.Invalidate();

                    this.OnValueChanged(new ValueChangedEventArgs() { Value = value });
                }
            }
        }

        private Font valueFont = new Font("宋体", 15);
        /// <summary>
        /// 值文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 15pt")]
        [Description("值文本字体")]
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

        private Color valueColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 值文本颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("值文本颜色")]
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

        private int valueDistance = 10;
        /// <summary>
        /// 值文本距离底部距离
        /// </summary>
        [DefaultValue(10)]
        [Description("值文本距离底部距离")]
        public int ValueDistance
        {
            get { return this.valueDistance; }
            set
            {
                if (this.valueDistance == value || value < 0)
                    return;
                this.valueDistance = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 文本

        private int textDistance = 0;
        /// <summary>
        /// 文本距离底部距离
        /// </summary>
        [DefaultValue(0)]
        [Description("文本距离底部距离")]
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
                return new Size(180, 180);
            }
        }

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        [DefaultValue(typeof(Color), "Black")]
        protected new Color ForeColor
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

        #region 字段

        /// <summary>
        /// 动画前指针值
        /// </summary>
        private float animationInitialValue = 0;
        /// <summary>
        /// 动画中指针值
        /// </summary>
        private float animationCurrentValue = 0;
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;
        /// <summary>
        /// 动画参数
        /// </summary>
        private AnimationOptions options = new AnimationOptions() { AllTransformTime = 150 };
        #endregion

        public MeterExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ForeColor = Color.Black;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float start = 90 + (180 - (this.ArcAngle) / 2f);//绘制开始角度
            float border_radius = this.BackBorder + this.BackShadow + this.ScaleTextRadius + (this.GradualShow ? this.GradualThickness : this.ScaleHeight) + this.CircleRadius;//外圆半径

            RectangleF rect = RectangleF.Empty;
            PointF rect_center = PointF.Empty;
            if (this.ArcAngle > 180)
            {
                rect = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
                rect_center = new PointF(rect.Width / 2f, rect.Height / 2f);
            }
            else
            {
                int pie_bottom_radian_left_right_height = (int)(this.CircleRadius * (2f / 5f));//扇形底部左右圆弧高度,不能写死
                int pie_bottom_radian_height = (int)(15 + (this.CircleRadius - 50) / 20f);//扇形底部圆弧高度,不能写死
                float height = border_radius + pie_bottom_radian_left_right_height + pie_bottom_radian_height;
                rect = new RectangleF(this.ClientRectangle.X, this.ClientRectangle.Y + (this.ClientRectangle.Height - height) / 2f, this.ClientRectangle.Width, this.ClientRectangle.Height);
                rect_center = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
            }

            #region 背景
            if (this.BackShow)
            {
                if (this.ArcAngle > 180)//圆
                {
                    #region 边框
                    RectangleF circle_border_rect = new RectangleF(rect_center.X - border_radius, rect_center.Y - border_radius, border_radius * 2, border_radius * 2);
                    LinearGradientBrush circle_border_lgb = new LinearGradientBrush(circle_border_rect, Color.White, this.BackBorderColor, 45);
                    g.FillEllipse(circle_border_lgb, circle_border_rect);
                    #endregion

                    #region 内圆
                    RectangleF circle_in_rect = new RectangleF(rect_center.X - border_radius + this.BackBorder + this.BackShadow, rect_center.Y - border_radius + this.BackBorder + this.BackShadow, (border_radius - this.BackBorder - this.BackShadow) * 2, (border_radius - this.BackBorder - this.BackShadow) * 2);
                    SolidBrush circle_in_sb = new SolidBrush(this.BackInnerColor);
                    g.FillEllipse(circle_in_sb, circle_in_rect);
                    #endregion

                    #region 边框阴影
                    LinearGradientBrush circle_in_lgb = new LinearGradientBrush(circle_in_rect, Color.White, this.BackShadowColor, 225);
                    Pen circle_shadow_pen = new Pen(circle_in_lgb, this.BackShadow);
                    circle_shadow_pen.Alignment = PenAlignment.Outset;
                    g.DrawEllipse(circle_shadow_pen, circle_in_rect);
                    #endregion

                    circle_border_lgb.Dispose();
                    circle_in_sb.Dispose();
                    circle_in_lgb.Dispose();
                    circle_shadow_pen.Dispose();
                }
                else//扇形
                {
                    int pie_bottom_radian_left_right_height = (int)(this.CircleRadius * (2f / 5f));//扇形底部左右圆弧高度,不能写死
                    int pie_bottom_radian_height = (int)(15 + (this.CircleRadius - 50) / 20f);//扇形底部圆弧高度,不能写死

                    #region 边框
                    RectangleF pie_border_rect = new RectangleF(rect_center.X - border_radius, rect_center.Y - border_radius, border_radius * 2, border_radius * 2);
                    LinearGradientBrush pie_border_lgb = new LinearGradientBrush(pie_border_rect, Color.White, this.BackBorderColor, 45);

                    GraphicsPath pie_border_gp = new GraphicsPath();
                    pie_border_gp.AddArc(pie_border_rect, 180, 180);

                    pie_border_gp.AddBezier(
                    pie_border_gp.GetLastPoint(),
                    new PointF(pie_border_rect.Right, pie_border_rect.Y + pie_border_rect.Height / 2 + pie_bottom_radian_left_right_height * 1.5f + pie_bottom_radian_height),
                    new PointF(pie_border_rect.Right - pie_border_rect.Width / 2, pie_border_rect.Y + pie_border_rect.Height / 2 + pie_bottom_radian_left_right_height * 1.5f + pie_bottom_radian_height),
                    new PointF(pie_border_rect.Right - pie_border_rect.Width / 2, pie_border_rect.Y + pie_border_rect.Height / 2 + pie_bottom_radian_left_right_height * 1.5f + pie_bottom_radian_height));

                    pie_border_gp.AddBezier(
                    new PointF(pie_border_rect.X + pie_border_rect.Width / 2, pie_border_rect.Y + pie_border_rect.Height / 2 + pie_bottom_radian_left_right_height * 1.5f + pie_bottom_radian_height),
                    new PointF(pie_border_rect.X, pie_border_rect.Y + pie_border_rect.Height / 2 + pie_bottom_radian_left_right_height * 1.5f + pie_bottom_radian_height),
                    pie_border_gp.PathPoints[0],
                    pie_border_gp.PathPoints[0]);

                    pie_border_gp.CloseAllFigures();
                    g.FillPath(pie_border_lgb, pie_border_gp);
                    #endregion

                    #region 内扇形
                    RectangleF pie_in_rect = new RectangleF(rect_center.X - border_radius + this.BackBorder + this.BackShadow, rect_center.Y - border_radius + this.BackBorder + this.BackShadow, (border_radius - this.BackBorder - this.BackShadow) * 2, (border_radius - this.BackBorder - this.BackShadow) * 2);
                    SolidBrush pie_in_sb = new SolidBrush(this.BackInnerColor);

                    GraphicsPath pie_in_gp = new GraphicsPath();
                    pie_in_gp.AddArc(pie_in_rect, 180, 180);

                    pie_in_gp.AddBezier(
                    pie_in_gp.GetLastPoint(),
                    new PointF(pie_in_rect.Right, pie_in_rect.Y + pie_in_rect.Height / 2 + pie_bottom_radian_left_right_height),
                    new PointF(pie_in_rect.Right - pie_bottom_radian_left_right_height, pie_in_rect.Y + pie_in_rect.Height / 2 + pie_bottom_radian_left_right_height),
                    new PointF(pie_in_rect.Right - pie_bottom_radian_left_right_height, pie_in_rect.Y + pie_in_rect.Height / 2 + pie_bottom_radian_left_right_height));

                    pie_in_gp.AddBezier(
                    new PointF(pie_in_rect.X + pie_bottom_radian_left_right_height, pie_in_rect.Y + pie_in_rect.Height / 2 + pie_bottom_radian_left_right_height),
                    new PointF(pie_in_rect.X, pie_in_rect.Y + pie_in_rect.Height / 2 + pie_bottom_radian_left_right_height),
                    pie_in_gp.PathPoints[0],
                    pie_in_gp.PathPoints[0]);
                    pie_in_gp.CloseAllFigures();
                    g.FillPath(pie_in_sb, pie_in_gp);
                    #endregion

                    #region 边框阴影
                    LinearGradientBrush pie_in_lgb = new LinearGradientBrush(pie_in_rect, Color.White, this.BackShadowColor, 225);
                    Pen pie_shadow_pen = new Pen(pie_in_lgb, this.BackShadow);
                    pie_shadow_pen.Alignment = PenAlignment.Outset;
                    g.DrawPath(pie_shadow_pen, pie_in_gp);
                    #endregion

                    pie_border_lgb.Dispose();
                    pie_border_gp.Dispose();
                    pie_in_sb.Dispose();
                    pie_in_gp.Dispose();
                    pie_in_lgb.Dispose();
                    pie_shadow_pen.Dispose();
                }
            }
            #endregion

            #region 弧线、值弧线
            if (this.ArcShow)
            {
                RectangleF arc_rect = new RectangleF(rect_center.X - this.CircleRadius + this.ArcThickness / 2f, rect_center.Y - this.CircleRadius + this.ArcThickness / 2f, (this.CircleRadius - this.ArcThickness / 2f) * 2, (this.CircleRadius - this.ArcThickness / 2f) * 2);

                //弧线
                Pen arcback_pen = new Pen(this.ArcBackColor, this.ArcThickness);
                arcback_pen.Alignment = PenAlignment.Outset;
                g.DrawArc(arcback_pen, arc_rect, start, this.ArcAngle);

                // 值弧线背景
                Pen arcvalueback_pen = new Pen(this.ArcValueColor, this.ArcThickness);
                arcvalueback_pen.Alignment = PenAlignment.Outset;
                if (this.ArcRound)
                {
                    arcvalueback_pen.EndCap = LineCap.Round;
                }
                g.DrawArc(arcvalueback_pen, arc_rect, start, this.ArcAngle * (this.animationCurrentValue / this.MaxValue));

                arcback_pen.Dispose();
                arcvalueback_pen.Dispose();
            }
            #endregion

            #region 渐变环背景
            if (this.GradualShow && this.GradualColorItems.Count > 1)
            {
                Pen gradual_pen = new Pen(Color.White, this.CircleRadius / 50f * 2f);
                int gradual_now_angle = 0;
                float item_start_angle = 0;

                for (int i = 1; i < this.GradualColorItems.Count; i++)
                {
                    float color_angle = (float)this.ArcAngle * (this.GradualColorItems[i].Position - this.GradualColorItems[i - 1].Position);

                    float rgb_r = (this.GradualColorItems[i].Color.R - this.GradualColorItems[i - 1].Color.R) / color_angle;
                    float rgb_g = (this.GradualColorItems[i].Color.G - this.GradualColorItems[i - 1].Color.G) / color_angle;
                    float rgb_b = (this.GradualColorItems[i].Color.B - this.GradualColorItems[i - 1].Color.B) / color_angle;

                    for (int k = 0; k < color_angle; k++)
                    {
                        gradual_pen.Color = Color.FromArgb(
                        ControlCommom.VerifyRGB((int)(this.GradualColorItems[i - 1].Color.R + rgb_r * k)),
                        ControlCommom.VerifyRGB((int)(this.GradualColorItems[i - 1].Color.G + rgb_g * k)),
                        ControlCommom.VerifyRGB((int)(this.GradualColorItems[i - 1].Color.B + rgb_b * k)));
                        gradual_now_angle = (int)(start + item_start_angle + k);
                        PointF gradual_line_start_point = ControlCommom.CalculatePointForAngle(rect_center, this.CircleRadius, gradual_now_angle);
                        PointF gradual_line_end_point = ControlCommom.CalculatePointForAngle(gradual_line_start_point, this.GradualThickness, gradual_now_angle);

                        g.DrawLine(gradual_pen, gradual_line_start_point, gradual_line_end_point);
                    }
                    item_start_angle += color_angle;
                }
                gradual_pen.Dispose();
            }
            #endregion

            #region 刻度线、子刻度线、刻度线文本
            StringFormat scale_sf = new StringFormat(StringFormatFlags.NoClip);
            Pen scale_pen = new Pen(this.ScaleColor, this.ScaleWidth);
            SolidBrush scale_value_sb = new SolidBrush(this.ScaleTextColor);
            Pen split_pen = new Pen(this.SplitScaleColor, this.SplitScaleWidth);
            float scale_now_angle = 0;

            int count = (int)(Math.Abs(this.MaxValue - this.MinValue) / this.ScaleInterval) + (Math.Abs(this.MaxValue - this.MinValue) % this.ScaleInterval == 0 ? 0 : 1);
            for (int i = 0; i <= count; i++)
            {
                scale_now_angle = start + this.ArcAngle / count * i;

                #region 刻度线
                PointF scale_now_start_point = ControlCommom.CalculatePointForAngle(rect_center, this.CircleRadius, scale_now_angle);
                PointF scale_now_end_point = ControlCommom.CalculatePointForAngle(scale_now_start_point, this.ScaleHeight, scale_now_angle);
                g.DrawLine(scale_pen, scale_now_start_point, scale_now_end_point);
                #endregion

                #region 刻度线文本
                string scale_text = (this.MinValue + this.ScaleInterval * i).ToString();
                SizeF scale_text_size = g.MeasureString(scale_text, this.Font, 0, scale_sf);
                PointF scale_text_point = ControlCommom.CalculatePointForAngle(scale_now_start_point, (this.GradualShow && this.GradualColorItems.Count > 1) ? this.GradualThickness : this.ScaleHeight, scale_now_angle);
                #region 刻度线文本坐标
                if (scale_now_angle == 0)
                {
                    scale_text_point.Y = scale_text_point.Y - scale_text_size.Height / 2;
                }
                else if (scale_now_angle < 90)
                {

                }
                else if (scale_now_angle == 90)
                {
                    scale_text_point.X = scale_text_point.X - scale_text_size.Width / 2;
                }
                else if (scale_now_angle < 180)
                {
                    scale_text_point.X = scale_text_point.X - scale_text_size.Width;
                }
                else if (scale_now_angle == 180)
                {
                    scale_text_point.Y = scale_text_point.Y - scale_text_size.Height / 2;
                    scale_text_point.X = scale_text_point.X - scale_text_size.Width;
                }
                else if (scale_now_angle < 270)
                {
                    scale_text_point.Y = scale_text_point.Y - scale_text_size.Height;
                    scale_text_point.X = scale_text_point.X - scale_text_size.Width;
                }
                else if (scale_now_angle == 270)
                {
                    scale_text_point.Y = scale_text_point.Y - scale_text_size.Height;
                    scale_text_point.X = scale_text_point.X - scale_text_size.Width / 2;
                }
                else if (scale_now_angle < 360)
                {
                    scale_text_point.Y = scale_text_point.Y - scale_text_size.Height;
                }
                #endregion

                g.DrawString(scale_text, this.Font, scale_value_sb, scale_text_point, scale_sf);
                #endregion

                #region 子刻度线
                if (SplitScaleShow)
                {

                    if (i < count)
                    {
                        for (int k = 1; k < this.SplitScaleCount; k++)
                        {
                            PointF split_now_start_point = ControlCommom.CalculatePointForAngle(rect_center, this.CircleRadius, start + (float)this.ArcAngle / count * i + ((float)this.ArcAngle / count / this.SplitScaleCount * k));
                            PointF split_now_end_point = ControlCommom.CalculatePointForAngle(split_now_start_point, this.SplitScaleHeight, start + (float)this.ArcAngle / count * i + ((float)this.ArcAngle / count / this.SplitScaleCount * k));
                            g.DrawLine(split_pen, split_now_start_point, split_now_end_point);
                        }
                    }
                }
                #endregion

            }
            scale_pen.Dispose();
            scale_value_sb.Dispose();
            split_pen.Dispose();
            scale_sf.Dispose();
            #endregion

            #region 指针
            SolidBrush pointer_sb = new SolidBrush(this.PointerColor);
            float pointer_now_angle = start + this.ArcAngle * (this.animationCurrentValue / this.MaxValue);
            PointF pointer_now_end_point = ControlCommom.CalculatePointForAngle(rect_center, (float)this.CircleRadius - (this.ArcShow ? this.ArcThickness : 0f), pointer_now_angle);

            // 针
            int pointer_width = 8;//指针宽度
            float pointer_acutance = 20f;//指针顶端锐度
            float pointer_acutance_length = (float)(pointer_width / 2 / Math.Sin(2 * Math.PI * pointer_acutance / 360));//指针顶端锐度两边斜线长度

            GraphicsPath pointer_gp = new GraphicsPath();
            PointF[] pointer_point_arr = new PointF[] {
             ControlCommom.CalculatePointForAngle(pointer_now_end_point,pointer_acutance_length,pointer_now_angle-90-(90-pointer_acutance)),
            pointer_now_end_point,
             ControlCommom.CalculatePointForAngle(pointer_now_end_point,pointer_acutance_length,pointer_now_angle-90-(90-pointer_acutance)-pointer_acutance*2),
             ControlCommom.CalculatePointForAngle(rect_center,pointer_width/2,pointer_now_angle+90),
             ControlCommom.CalculatePointForAngle(rect_center,pointer_width/2,pointer_now_angle-90)};
            pointer_gp.AddLines(pointer_point_arr);
            pointer_gp.CloseAllFigures();
            g.FillPath(pointer_sb, pointer_gp);

            float pointer_heart_out_radius = 10;
            float pointer_heart_in_radius = 5;

            //外针帽
            SolidBrush pointer_heart_out_sb = new SolidBrush(this.PointerCapColor);
            RectangleF pointer_heart_out_rect = new RectangleF(rect_center.X - pointer_heart_out_radius, rect_center.Y - pointer_heart_out_radius, pointer_heart_out_radius * 2, pointer_heart_out_radius * 2);
            g.FillEllipse(pointer_heart_out_sb, pointer_heart_out_rect);

            //内针帽
            RectangleF pointer_heart_in_rect = new RectangleF(rect_center.X - pointer_heart_out_radius + pointer_heart_in_radius, rect_center.Y - pointer_heart_out_radius + pointer_heart_in_radius, pointer_heart_in_radius * 2, pointer_heart_in_radius * 2);
            LinearGradientBrush pointer_heart_in_lgb = new LinearGradientBrush(pointer_heart_in_rect, Color.White, this.PointerCapColor, 225);
            g.FillEllipse(pointer_heart_in_lgb, pointer_heart_in_rect);

            pointer_sb.Dispose();
            pointer_gp.Dispose();
            pointer_heart_out_sb.Dispose();
            pointer_heart_in_lgb.Dispose();
            #endregion

            #region 文本
            if (String.IsNullOrWhiteSpace(this.Text) == false)
            {
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                StringFormat text_sf = new StringFormat(StringFormatFlags.NoClip);
                SizeF text_size = g.MeasureString(this.Text, this.Font);
                g.DrawString(this.Text, this.Font, text_sb, new RectangleF(this.ClientRectangle.X + (rect.Width - text_size.Width) / 2f, this.ClientRectangle.Bottom - text_size.Height - this.TextDistance, text_size.Width, text_size.Height), text_sf);
                text_sb.Dispose();
                text_sf.Dispose();
            }
            #endregion

            #region 值文本
            if (ValueShow)
            {
                string valueText = this.Value.ToString();
                SolidBrush text_sb = new SolidBrush(this.ValueColor);
                StringFormat text_sf = new StringFormat(StringFormatFlags.NoClip);
                SizeF text_size = g.MeasureString(valueText, this.ValueFont);
                g.DrawString(valueText, this.ValueFont, text_sb, new RectangleF(this.ClientRectangle.X + (rect.Width - text_size.Width) / 2f, this.ClientRectangle.Bottom - text_size.Height - this.ValueDistance, text_size.Width, text_size.Height), text_sf);
                text_sb.Dispose();
                text_sf.Dispose();
            }
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

            double progress = AnimationTimer.GetProgress(AnimationTypes.EaseOut, this.options, this.usedTime);
            if (finish)
            {
                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;

                this.usedTime = 0;
            }

            this.animationCurrentValue = (float)(this.animationInitialValue + (this.Value - this.animationInitialValue) * progress);
            this.Invalidate();
        }
        #endregion

        #region 类

        /// <summary>
        /// 渐变颜色配置集合
        /// </summary>
        [Description("渐变颜色配置集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ColorItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList colorItemList = new ArrayList();
            private MeterExt owner;

            public ColorItemCollection(MeterExt owner)
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
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
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
                    this.owner.Invalidate();
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
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 渐变颜色配置
        /// </summary>
        [Description("渐变颜色配置")]
        public class ColorItem
        {
            private float position = 0f;
            /// <summary>
            /// 渐变值0-1
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

            private Color color = Color.FromArgb(255, 128, 128);
            /// <summary>
            /// 渐变值对应渐变颜色
            /// </summary>
            [DefaultValue(typeof(Color), "255, 128, 128")]
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

        /// <summary>
        /// 值更改事件参数
        /// </summary>
        [Description("值更改事件参数")]
        public class ValueChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 值
            /// </summary>
            [Description("值")]
            public float Value { get; set; }
        }

        #endregion
    }

}
