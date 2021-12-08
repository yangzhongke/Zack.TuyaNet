
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
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 步骤流程控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("步骤流程控件")]
    [DefaultProperty("Items")]
    [DefaultEvent("IndexChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class ProcedureExt : Control
    {
        #region 新增事件

        public delegate void IndexChangedEventHandler(object sender, IndexChangedEventArgs e);

        private event IndexChangedEventHandler indexChanged;
        /// <summary>
        /// 步骤流程选项更改事件
        /// </summary>
        [Description("步骤流程选项更改事件")]
        public event IndexChangedEventHandler IndexChanged
        {
            add { this.indexChanged += value; }
            remove { this.indexChanged -= value; }
        }

        #endregion

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

        private Orientations orientation = Orientations.HorizontalTop;
        /// <summary>
        /// 步骤流程方向位置
        /// </summary>
        [DefaultValue(Orientations.HorizontalTop)]
        [Description("步骤流程方向位置")]
        public Orientations Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;
                this.orientation = value;
                this.InitializeStepProcessRectangle();
                this.Invalidate();
            }
        }

        private int line = 2;
        /// <summary>
        /// 步骤流程线条大小
        /// </summary>
        [DefaultValue(2)]
        [Description("步骤流程线条大小")]
        public int Line
        {
            get { return this.line; }
            set
            {
                if (this.line == value || value < 0)
                    return;
                this.line = value;
                this.InitializeStepProcessRectangle();
                this.Invalidate();
            }
        }

        private int radius = 12;
        /// <summary>
        /// 步骤流程选项圆形半径
        /// </summary>
        [DefaultValue(12)]
        [Description("步骤流程选项圆形半径")]
        public int Radius
        {
            get { return this.radius; }
            set
            {
                if (this.radius == value || value < 0)
                    return;
                this.radius = value;
                this.InitializeStepProcessRectangle();
                this.Invalidate();
            }
        }

        private int interval = 80;
        /// <summary>
        /// 步骤流程选项间距
        /// </summary>
        [DefaultValue(80)]
        [Description("步骤流程选项间距")]
        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (this.interval == value || value < 0)
                    return;
                this.interval = value;
                this.InitializeStepProcessRectangle();
                this.Invalidate();
            }
        }

        private int selectIndex = 0;
        /// <summary>
        /// 当前步骤流程选项的索引
        /// </summary>
        [DefaultValue(0)]
        [Description("当前步骤流程选项的索引")]
        public int SelectIndex
        {
            get { return this.selectIndex; }
            set
            {
                if (this.selectIndex == value || value < 0 || value > Items.Count + 1)
                    return;
                this.selectIndex = value;
                this.Invalidate();

                this.OnIndexChanged(new IndexChangedEventArgs() { Item = (value == 0 || value == Items.Count + 1) ? null : this.Items[this.selectIndex - 1] });
            }
        }

        private ProcedureItemCollection stepProcessItemCollection;
        /// <summary>
        /// 步骤流程选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("步骤流程选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ProcedureItemCollection Items
        {
            get
            {
                if (this.stepProcessItemCollection == null)
                    this.stepProcessItemCollection = new ProcedureItemCollection(this);
                return this.stepProcessItemCollection;
            }
        }

        private Font textFont = new Font("宋体", 11, FontStyle.Regular);
        /// <summary>
        /// 步骤流程选项文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "11pt style=Regular")]
        [Description("步骤流程选项文本字体")]
        public Font TextFont
        {
            get { return this.textFont; }
            set
            {
                if (this.textFont == value)
                    return;
                this.textFont = value;
                this.Invalidate();
            }
        }

        #region 步骤流程选项

        #region （正常）

        private Color itemNormalBackColor = Color.FromArgb(90, 255, 192, 203);
        /// <summary>
        /// 步骤流程选项背景颜色（正常）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "90, 255, 192, 203")]
        [Description("步骤流程选项背景颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemNormalBackColor
        {
            get { return this.itemNormalBackColor; }
            set
            {
                if (this.itemNormalBackColor == value)
                    return;
                this.itemNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemNormalTextColor = Color.FromArgb(154, 205, 50);
        /// <summary>
        /// 步骤流程选项文本颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "154, 205, 50")]
        [Description("步骤流程选项文本颜色（正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemNormalTextColor
        {
            get { return this.itemNormalTextColor; }
            set
            {
                if (this.itemNormalTextColor == value)
                    return;
                this.itemNormalTextColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region （进行中）
        private Color itemProceedBackColor = Color.FromArgb(179, 255, 160, 122);
        /// <summary>
        /// 步骤流程选项背景颜色（进行中）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "179, 255, 160, 122")]
        [Description("步骤流程选项背景颜色（进行中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemProceedBackColor
        {
            get { return this.itemProceedBackColor; }
            set
            {
                if (this.itemProceedBackColor == value)
                    return;
                this.itemProceedBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemProceedBorderColor = Color.FromArgb(179, 255, 160, 122);
        /// <summary>
        /// 步骤流程选项边框颜色（进行中）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "179, 255, 160, 122")]
        [Description("步骤流程选项边框颜色（进行中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemProceedBorderColor
        {
            get { return this.itemProceedBorderColor; }
            set
            {
                if (this.itemProceedBorderColor == value)
                    return;
                this.itemProceedBorderColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region（完成）

        private Color itemFinishBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 步骤流程选项背景颜色（完成）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("步骤流程选项背景颜色（完成）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemFinishBackColor
        {
            get { return this.itemFinishBackColor; }
            set
            {
                if (this.itemFinishBackColor == value)
                    return;
                this.itemFinishBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemFinishBorderColor = Color.FromArgb(183, 154, 205, 50);
        /// <summary>
        /// 步骤流程选项边框颜色（完成）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "183, 154, 205, 50")]
        [Description("步骤流程选项边框颜色（完成）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemFinishBorderColor
        {
            get { return this.itemFinishBorderColor; }
            set
            {
                if (this.itemFinishBorderColor == value)
                    return;
                this.itemFinishBorderColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region（禁止）

        private Color itemDisableNormalBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 步骤流程选项背景颜色（禁止正常）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("步骤流程选项背景颜色（禁止正常）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableNormalBackColor
        {
            get { return this.itemDisableNormalBackColor; }
            set
            {
                if (this.itemDisableNormalBackColor == value)
                    return;
                this.itemDisableNormalBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableProceedBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 步骤流程选项背景颜色（禁止进行中）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("步骤流程选项背景颜色（禁止进行中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableProceedBackColor
        {
            get { return this.itemDisableProceedBackColor; }
            set
            {
                if (this.itemDisableProceedBackColor == value)
                    return;
                this.itemDisableProceedBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableFinishBackColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 步骤流程选项背景颜色（禁止完成）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("步骤流程选项背景颜色（禁止完成）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableFinishBackColor
        {
            get { return this.itemDisableFinishBackColor; }
            set
            {
                if (this.itemDisableFinishBackColor == value)
                    return;
                this.itemDisableFinishBackColor = value;
                this.Invalidate();
            }
        }


        private Color itemDisableProceedBorderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 步骤流程选项边框颜色（禁止进行中）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("步骤流程选项边框颜色（禁止进行中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableProceedBorderColor
        {
            get { return this.itemDisableProceedBorderColor; }
            set
            {
                if (this.itemDisableProceedBorderColor == value)
                    return;
                this.itemDisableProceedBorderColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableFinishBorderColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 步骤流程选项边框颜色（禁止完成）
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("步骤流程选项边框颜色（禁止完成）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableFinishBorderColor
        {
            get { return this.itemDisableFinishBorderColor; }
            set
            {
                if (this.itemDisableFinishBorderColor == value)
                    return;
                this.itemDisableFinishBorderColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableTextColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 步骤流程选项文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("步骤流程选项文本颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableTextColor
        {
            get { return this.itemDisableTextColor; }
            set
            {
                if (this.itemDisableTextColor == value)
                    return;
                this.itemDisableTextColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region 步骤流程选项提示信息

        private bool tipShow = true;
        /// <summary>
        /// 是否显示提示信息
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示提示信息")]
        public bool TipShow
        {
            get { return this.tipShow; }
            set
            {
                if (this.tipShow == value)
                    return;
                this.tipShow = value;
            }
        }

        /// <summary>
        /// 提示信息标题背景颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 206, 55")]
        [Description("提示信息标题背景颜色")]
        public Color TipTitleBackColor
        {
            get { return this.tooltip.TitleBackColor; }
            set
            {
                if (this.tooltip.TitleBackColor == value)
                    return;
                this.tooltip.TitleBackColor = value;
            }
        }

        /// <summary>
        /// 提示信息标题颜色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("提示信息标题颜色")]
        public Color TipTitleColor
        {
            get { return this.tooltip.TitleColor; }
            set
            {
                if (this.tooltip.TitleColor == value)
                    return;
                this.tooltip.TitleColor = value;
            }
        }

        /// <summary>
        /// 提示信息文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("提示信息文本字体")]
        public Font TipTextFont
        {
            get { return this.tooltip.Font; }
            set
            {
                if (this.tooltip.Font == value)
                    return;
                this.tooltip.Font = value;
            }
        }

        /// <summary>
        /// 提示信息文本颜色
        /// </summary>
        [Description("提示信息文本颜色")]
        public Color TipTextColor
        {
            get { return this.tooltip.ForeColor; }
            set
            {
                if (this.tooltip.ForeColor == value)
                    return;
                this.tooltip.ForeColor = value;
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

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(20, 10, 20, 10);
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 60);
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
        ///  提示信息
        /// </summary>
        private ToolTipExt tooltip;
        /// <summary>
        /// 提示信息状态
        /// </summary>
        private bool tipShowStatus = false;

        /// <summary>
        /// 文本格式
        /// </summary>
        protected static StringFormat text_sf = new StringFormat() { FormatFlags = StringFormatFlags.NoWrap, Alignment = StringAlignment.Center, Trimming = StringTrimming.None };

        #endregion

        public ProcedureExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.tooltip = new ToolTipExt();
            this.tooltip.TitleShow = true;
            this.tooltip.MinSize = new Size(70, 30);
            this.tooltip.MaxSize = new Size(400, 0);
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectf = new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientRectangle.Width - this.Padding.Left - this.Padding.Right, this.ClientRectangle.Height - this.Padding.Top - this.Padding.Bottom);

            #region 父画笔
            SolidBrush normal_back_sb = null;
            SolidBrush proceed_back_sb = null;
            SolidBrush finish_back_sb = null;
            Pen normal_border_pen = null;
            Pen proceed_border_pen = null;
            Pen finish_border_pen = null;
            SolidBrush finish_border_sb = null;
            SolidBrush normal_text_sb = null;

            SolidBrush disable_normal_back_sb = null;
            SolidBrush disable_proceed_back_sb = null;
            SolidBrush disable_finish_back_sb = null;
            Pen disable_normal_border_pen = null;
            Pen disable_proceed_border_pen = null;
            Pen disable_finish_border_pen = null;
            SolidBrush disable_finish_border_sb = null;
            SolidBrush disable_text_sb = null;


            if (this.Enabled)
            {
                normal_back_sb = new SolidBrush(this.ItemNormalBackColor);
                proceed_back_sb = new SolidBrush(this.ItemProceedBackColor);
                finish_back_sb = new SolidBrush(this.ItemFinishBackColor);

                normal_border_pen = new Pen(this.ItemNormalBackColor, this.Line);
                proceed_border_pen = new Pen(this.ItemProceedBorderColor, this.Line);
                finish_border_pen = new Pen(this.ItemFinishBorderColor, this.Line);
                finish_border_sb = new SolidBrush(this.ItemFinishBorderColor);

                normal_text_sb = new SolidBrush(this.ItemNormalTextColor);
            }
            else
            {
                disable_normal_back_sb = new SolidBrush(this.ItemDisableNormalBackColor);
                disable_proceed_back_sb = new SolidBrush(this.ItemDisableProceedBackColor);
                disable_finish_back_sb = new SolidBrush(this.ItemDisableFinishBackColor);

                disable_normal_border_pen = new Pen(this.ItemDisableNormalBackColor, this.Line);
                disable_proceed_border_pen = new Pen(this.ItemDisableProceedBorderColor, this.Line);
                disable_finish_border_pen = new Pen(this.ItemDisableFinishBorderColor, this.Line);
                disable_finish_border_sb = new SolidBrush(this.ItemDisableFinishBorderColor);

                disable_text_sb = new SolidBrush(this.ItemDisableTextColor);
            }

            SolidBrush commom_back_sb = null;
            bool subitemsBackBrush = false;
            Pen commom_border_pen = null;
            bool subitemsBorderPen = false;
            SolidBrush commom_border_sb = null;
            bool subitemsBorderBrush = false;
            SolidBrush commom_text_sb = null;
            bool subitemsTextBrush = false;
            #endregion

            for (int i = 0; i < this.Items.Count; i++)
            {
                #region 间隔线
                if (this.Enabled)
                {
                    #region
                    if (i < this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemFinishBorderColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = finish_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemFinishBorderColor, this.Line);
                        }
                    }
                    else if (i == this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemProceedBorderColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = proceed_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemProceedBorderColor, this.Line);
                        }
                    }
                    else
                    {
                        if (this.Items[i].ItemNormalBackColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = normal_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemNormalBackColor, this.Line);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region
                    if (i < this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemDisableFinishBorderColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = disable_finish_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemDisableFinishBorderColor, this.Line);
                        }
                    }
                    else if (i == this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemDisableProceedBorderColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = disable_proceed_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemDisableProceedBorderColor, this.Line);
                        }
                    }
                    else
                    {
                        if (this.Items[i].ItemDisableNormalBackColor == Color.Empty)
                        {
                            subitemsBorderPen = false;
                            commom_border_pen = disable_normal_border_pen;
                        }
                        else
                        {
                            subitemsBorderPen = true;
                            commom_border_pen = new Pen(this.Items[i].ItemDisableNormalBackColor, this.Line);
                        }
                    }
                    #endregion
                }
                if (i > 0)
                {
                    this.DrawLine(i, g, commom_border_pen);
                }
                #endregion

                #region 选项背景
                if (this.Enabled)
                {
                    #region
                    if (i < this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemFinishBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = finish_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemFinishBackColor);
                        }
                    }
                    else if (i == this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemProceedBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = proceed_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemProceedBackColor);
                        }
                    }
                    else
                    {
                        if (this.Items[i].ItemNormalBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = normal_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemNormalBackColor);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region
                    if (i < this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemDisableFinishBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = disable_finish_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemDisableFinishBackColor);
                        }
                    }
                    else if (i == this.SelectIndex - 1)
                    {
                        if (this.Items[i].ItemDisableProceedBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = disable_proceed_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemDisableProceedBackColor);
                        }
                    }
                    else
                    {
                        if (this.Items[i].ItemDisableNormalBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = disable_normal_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].ItemDisableNormalBackColor);
                        }
                    }
                    #endregion
                }
                g.FillEllipse(commom_back_sb, this.Items[i].RectF);
                #endregion

                #region 选项边框
                if (i <= this.SelectIndex - 1)
                {
                    g.DrawEllipse(commom_border_pen, ControlCommom.TransformRectangleF(this.Items[i].RectF, this.Line));
                }
                #endregion

                #region 选项圆心
                if (i < this.SelectIndex - 1)
                {
                    if (this.Enabled)
                    {
                        #region
                        if (this.Items[i].ItemFinishBorderColor == Color.Empty)
                        {
                            subitemsBorderBrush = false;
                            commom_border_sb = finish_border_sb;
                        }
                        else
                        {
                            subitemsBorderBrush = true;
                            commom_border_sb = new SolidBrush(this.Items[i].ItemFinishBorderColor);
                        }
                        #endregion
                    }
                    else
                    {
                        #region
                        if (this.Items[i].ItemDisableFinishBorderColor == Color.Empty)
                        {
                            subitemsBorderBrush = false;
                            commom_border_sb = disable_finish_border_sb;
                        }
                        else
                        {
                            subitemsBorderBrush = true;
                            commom_border_sb = new SolidBrush(this.Items[i].ItemDisableFinishBorderColor);
                        }
                        #endregion
                    }
                    this.DrawCircleCentre(i, g, commom_border_sb);
                }
                #endregion

                #region 选项文本
                if (this.Enabled)
                {
                    #region
                    if (this.Items[i].ItemNormalTextColor == Color.Empty)
                    {
                        subitemsTextBrush = false;
                        commom_text_sb = normal_text_sb;
                    }
                    else
                    {
                        subitemsTextBrush = true;
                        commom_text_sb = new SolidBrush(this.Items[i].ItemNormalTextColor);
                    }
                    #endregion
                }
                else
                {
                    #region
                    if (this.Items[i].ItemDisableTextColor == Color.Empty)
                    {
                        subitemsTextBrush = false;
                        commom_text_sb = disable_text_sb;
                    }
                    else
                    {
                        subitemsTextBrush = true;
                        commom_text_sb = new SolidBrush(this.Items[i].ItemDisableTextColor);
                    }
                    #endregion
                }
                this.DrawText(this.Items[i], g, commom_text_sb);
                #endregion

                #region 子画笔释放
                if (subitemsBackBrush && commom_back_sb != null)
                {
                    commom_back_sb.Dispose();
                    commom_back_sb = null;
                }
                if (subitemsBorderPen && commom_border_pen != null)
                {
                    commom_border_pen.Dispose();
                    commom_border_pen = null;
                }
                if (subitemsBorderBrush && commom_border_sb != null)
                {
                    commom_border_sb.Dispose();
                    commom_border_sb = null;
                }
                if (subitemsTextBrush && commom_text_sb != null)
                {
                    commom_text_sb.Dispose();
                    commom_text_sb = null;
                }
                #endregion
            }

            #region

            if (normal_back_sb != null)
                normal_back_sb.Dispose();
            if (proceed_back_sb != null)
                proceed_back_sb.Dispose();
            if (finish_back_sb != null)
                finish_back_sb.Dispose();
            if (normal_border_pen != null)
                normal_border_pen.Dispose();
            if (proceed_border_pen != null)
                proceed_border_pen.Dispose();
            if (finish_border_pen != null)
                finish_border_pen.Dispose();
            if (finish_border_sb != null)
                finish_border_sb.Dispose();
            if (normal_text_sb != null)
                normal_text_sb.Dispose();

            if (disable_normal_back_sb != null)
                disable_normal_back_sb.Dispose();
            if (disable_proceed_back_sb != null)
                disable_proceed_back_sb.Dispose();
            if (disable_finish_back_sb != null)
                disable_finish_back_sb.Dispose();
            if (disable_normal_border_pen != null)
                disable_normal_border_pen.Dispose();
            if (disable_proceed_border_pen != null)
                disable_proceed_border_pen.Dispose();
            if (disable_finish_border_pen != null)
                disable_finish_border_pen.Dispose();
            if (disable_finish_border_sb != null)
                disable_finish_border_sb.Dispose();
            if (disable_text_sb != null)
                disable_text_sb.Dispose();
            #endregion

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            int index = this.GetSelectedItemIndex(this.PointToClient(Control.MousePosition));
            if (index > -1)
            {
                if (this.TipShow)
                {
                    if (!this.tipShowStatus)
                    {
                        ToolTipExt.ToolTipAnchor anchor = ToolTipExt.ToolTipAnchor.TopCenter;
                        if (this.Orientation == Orientations.HorizontalBottom)
                        {
                            anchor = ToolTipExt.ToolTipAnchor.BottomCenter;
                        }
                        else if (this.Orientation == Orientations.VerticalLeft)
                        {
                            anchor = ToolTipExt.ToolTipAnchor.LeftCenter;
                        }
                        else if (this.Orientation == Orientations.VerticalRight)
                        {
                            anchor = ToolTipExt.ToolTipAnchor.RightCenter;
                        }
                        Rectangle rect = new Rectangle((int)this.Items[index].RectF.X, (int)this.Items[index].RectF.Y, (int)this.Items[index].RectF.Width, (int)this.Items[index].RectF.Height);
                        this.tooltip.ToolTipTitle = this.Items[index].Text;
                        string str = this.Items[index].Description == String.Empty ? " " : this.Items[index].Description;
                        this.tooltip.Show(str, this, rect, anchor);
                        this.tipShowStatus = true;
                    }

                    if (this.Cursor != Cursors.Hand)
                    {
                        this.Cursor = Cursors.Hand;
                    }
                }
            }
            else
            {
                if (this.tipShowStatus)
                {
                    this.tooltip.Hide(this);
                    this.tipShowStatus = false;
                }

                if (this.Cursor != Cursors.Default)
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.tipShowStatus = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeStepProcessRectangle();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.tooltip != null)
                    this.tooltip.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnIndexChanged(IndexChangedEventArgs e)
        {
            if (this.indexChanged != null)
            {
                this.indexChanged(this, e);
            }
        }

        #endregion


        #region 公开方法

        /// <summary>
        /// 步骤是否完成
        /// </summary>
        /// <returns></returns>
        public bool IsComplete()
        {
            if (this.Items.Count > 0 && this.SelectIndex > this.Items.Count)
            {
                return true;
            }
            return false;
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 初始化步骤流程选项rect
        /// </summary>
        /// <param name="item"></param>
        private void InitializeStepProcessRectangle()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.InitializeStepProcessItemRectangle(this.Items[i]);
            }
        }

        /// <summary>
        /// 初始化步骤流程选项rect
        /// </summary>
        /// <param name="item"></param>
        private void InitializeStepProcessItemRectangle(ProcedureItem item)
        {
            RectangleF rectf = new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientRectangle.Width - this.Padding.Left - this.Padding.Right, this.ClientRectangle.Height - this.Padding.Top - this.Padding.Bottom);

            int index = this.Items.IndexOf(item);
            if (this.Orientation == Orientations.HorizontalTop || this.Orientation == Orientations.HorizontalBottom)
            {
                float x = (float)this.Padding.Left - (float)this.Radius / 2f + index * this.Interval;
                float y = (this.Orientation == Orientations.HorizontalTop) ? this.Padding.Top + (float)this.Radius / 2 : rectf.Bottom - this.Padding.Bottom - this.Radius * 2;
                item.RectF = new RectangleF(x, y, this.Radius * 2, this.Radius * 2);
            }
            else
            {
                float x = (this.Orientation == Orientations.VerticalLeft) ? this.Padding.Top + this.Radius / 2 : rectf.Right - this.Padding.Right - this.Radius;
                float y = this.Padding.Top - (float)this.Radius / 2 + index * this.Interval;
                item.RectF = new RectangleF(x, y, this.Radius * 2, this.Radius * 2);
            }
        }

        /// <summary>
        /// 获取选中步骤流程选项索引
        /// </summary>
        /// <param name="point">当前鼠标坐标</param>
        /// <returns></returns>
        private int GetSelectedItemIndex(Point point)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].RectF.Contains(point))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 绘制步骤流程选项文本
        /// </summary>
        /// <param name="index"></param>
        /// <param name="g"></param>
        /// <param name="border_pen"></param>
        private void DrawLine(int index, Graphics g, Pen border_pen)
        {
            PointF point_strat = new PointF(this.Items[index - 1].RectF.Right - this.Line + (float)this.Line / 2f, this.Items[index - 1].RectF.Y + this.Items[index].RectF.Height / 2f);
            PointF point_end = new PointF(this.Items[index].RectF.X + this.Line - (float)this.Line / 2f, this.Items[index].RectF.Y + this.Items[index].RectF.Height / 2);
            if (this.Orientation == Orientations.VerticalLeft || this.Orientation == Orientations.VerticalRight)
            {
                point_strat = new PointF(this.Items[index - 1].RectF.X + this.Items[index].RectF.Width / 2f, this.Items[index - 1].RectF.Bottom - this.Line + (float)this.Line / 2);
                point_end = new PointF(this.Items[index].RectF.X + this.Items[index].RectF.Width / 2f, this.Items[index].RectF.Y + this.Line - (float)this.Line / 2);
            }
            g.DrawLine(border_pen, point_strat, point_end);

        }

        /// <summary>
        /// 绘制步骤流程选项圆心
        /// </summary>
        /// <param name="index"></param>
        /// <param name="g"></param>
        /// <param name="border_sb"></param>
        private void DrawCircleCentre(int index, Graphics g, SolidBrush border_sb)
        {
            float heart_w = this.Items[index].RectF.Width - this.Line * 2 - this.Line * 2;
            float heart_h = this.Items[index].RectF.Height - this.Line * 2 - this.Line * 2;
            RectangleF heart_rect = new RectangleF(this.Items[index].RectF.X + (this.Items[index].RectF.Width - heart_w) / 2f, this.Items[index].RectF.Y + (this.Items[index].RectF.Height - heart_h) / 2f, heart_w, heart_h);
            g.FillEllipse(border_sb, heart_rect);
        }

        /// <summary>
        /// 绘制步骤流程选项文本
        /// </summary>
        /// <param name="item"></param>
        /// <param name="g"></param>
        /// <param name="text_sb"></param>
        private void DrawText(ProcedureItem item, Graphics g, SolidBrush text_sb)
        {

            int text_space = 10;//文本离圆形距离
            Size text_size = g.MeasureString(item.Text, item.TextFont, new SizeF(), text_sf).ToSize();
            RectangleF text_rectf = new RectangleF(item.RectF.X + (item.RectF.Width - text_size.Width) / 2f, item.RectF.Bottom + text_space, text_size.Width, text_size.Height);
            if (this.Orientation == Orientations.HorizontalBottom)
            {
                text_rectf.Y = item.RectF.Y - text_space - text_size.Height;
            }
            else if (this.Orientation == Orientations.VerticalLeft)
            {
                text_rectf.X = item.RectF.Right + text_space;
                text_rectf.Y = item.RectF.Y + (item.RectF.Height - text_size.Height) / 2f;
            }
            else if (this.Orientation == Orientations.VerticalRight)
            {
                text_rectf.X = item.RectF.X - text_space - text_size.Width;
                text_rectf.Y = item.RectF.Y + (item.RectF.Height - text_size.Height) / 2f;
            }

            g.DrawString(item.Text, item.TextFont, text_sb, text_rectf, text_sf);
        }

        #endregion

        #region 类

        /// <summary>
        /// 步骤流程选项集合
        /// </summary>
        [Description("步骤流程选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class ProcedureItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList procedureItemList = new ArrayList();
            private ProcedureExt owner;

            public ProcedureItemCollection(ProcedureExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ProcedureItem[] listArray = new ProcedureItem[this.procedureItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ProcedureItem)this.procedureItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.procedureItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.procedureItemList.Count;
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
                if (!(value is ProcedureItem))
                {
                    throw new ArgumentException("StepProcessItem");
                }
                return this.Add((ProcedureItem)value);
            }

            public int Add(ProcedureItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                item.owner = this.owner;
                item.self = item;
                this.procedureItemList.Add(item);
                this.owner.InitializeStepProcessItemRectangle(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.procedureItemList.Clear();
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
                if (item is ProcedureItem)
                {
                    return this.Contains((ProcedureItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ProcedureItem)
                {
                    return this.procedureItemList.IndexOf(item);
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
                if (!(value is ProcedureItem))
                {
                    throw new ArgumentException("StepProcessItem");
                }
                this.Remove((ProcedureItem)value);
            }

            public void Remove(ProcedureItem item)
            {
                this.procedureItemList.Remove(item);
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.procedureItemList.RemoveAt(index);
                this.owner.Invalidate();
            }

            public ProcedureItem this[int index]
            {
                get
                {
                    return (ProcedureItem)this.procedureItemList[index];
                }
                set
                {
                    this.procedureItemList[index] = (ProcedureItem)value;
                    this.owner.InitializeStepProcessItemRectangle((ProcedureItem)value);
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.procedureItemList[index];
                }
                set
                {
                    this.procedureItemList[index] = (ProcedureItem)value;
                    this.owner.InitializeStepProcessItemRectangle((ProcedureItem)value);
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 步骤流程选项
        /// </summary>
        [Description("步骤流程选项")]
        public class ProcedureItem
        {
            /// <summary>
            /// 步骤流程控件主体
            /// </summary>
            public ProcedureExt owner;
            /// <summary>
            /// 当前步骤流程选项
            /// </summary>
            public ProcedureItem self;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ProcedureItem()
            {

            }

            public ProcedureItem(ProcedureExt owner)
            {
                this.owner = owner;
            }

            private string text = "";
            /// <summary>
            /// 步骤流程选项文本
            /// </summary>
            [DefaultValue("")]
            [Description("步骤流程选项文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private string description = "";
            /// <summary>
            /// 步骤流程选项描述
            /// </summary>
            [DefaultValue("")]
            [Description("步骤流程选项描述")]
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public string Description
            {
                get { return this.description; }
                set
                {
                    if (this.description == value)
                        return;
                    this.description = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Font textFont = new Font("宋体", 11, FontStyle.Regular);
            /// <summary>
            /// 步骤流程选项文本字体
            /// </summary>
            [DefaultValue(typeof(Font), "11pt style=Regular")]
            [Description("步骤流程选项文本字体")]
            public Font TextFont
            {
                get { return this.textFont; }
                set
                {
                    if (this.textFont == value)
                        return;
                    this.textFont = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private RectangleF rectf = new RectangleF();
            /// <summary>
            /// 步骤流程选项rectf
            /// </summary>
            [Browsable(false)]
            [Description("步骤流程选项rectf")]
            public RectangleF RectF
            {
                get { return this.rectf; }
                set
                {
                    if (this.rectf == value)
                        return;
                    this.rectf = value;
                }
            }

            #region （正常）

            private Color itemNormalBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（正常）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemNormalBackColor
            {
                get { return this.itemNormalBackColor; }
                set
                {
                    if (this.itemNormalBackColor == value)
                        return;
                    this.itemNormalBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemNormalTextColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项文本颜色（正常）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemNormalTextColor
            {
                get { return this.itemNormalTextColor; }
                set
                {
                    if (this.itemNormalTextColor == value)
                        return;
                    this.itemNormalTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #region （进行中）

            private Color itemProceedBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（进行中）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（进行中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemProceedBackColor
            {
                get { return this.itemProceedBackColor; }
                set
                {
                    if (this.itemProceedBackColor == value)
                        return;
                    this.itemProceedBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemProceedBorderColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项边框颜色（进行中）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项边框颜色（进行中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemProceedBorderColor
            {
                get { return this.itemProceedBorderColor; }
                set
                {
                    if (this.itemProceedBorderColor == value)
                        return;
                    this.itemProceedBorderColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #region （完成）

            private Color itemFinishBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（完成）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（完成）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemFinishBackColor
            {
                get { return this.itemFinishBackColor; }
                set
                {
                    if (this.itemFinishBackColor == value)
                        return;
                    this.itemFinishBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemFinishBorderColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项边框颜色（完成）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项边框颜色（完成）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemFinishBorderColor
            {
                get { return this.itemFinishBorderColor; }
                set
                {
                    if (this.itemFinishBorderColor == value)
                        return;
                    this.itemFinishBorderColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            #region（禁止）

            private Color itemDisableNormalBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（禁止正常）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（禁止正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableNormalBackColor
            {
                get { return this.itemDisableNormalBackColor; }
                set
                {
                    if (this.itemDisableNormalBackColor == value)
                        return;
                    this.itemDisableNormalBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemDisableProceedBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（禁止进行中）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（禁止进行中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableProceedBackColor
            {
                get { return this.itemDisableProceedBackColor; }
                set
                {
                    if (this.itemDisableProceedBackColor == value)
                        return;
                    this.itemDisableProceedBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemDisableFinishBackColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项背景颜色（禁止完成）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项背景颜色（禁止完成）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableFinishBackColor
            {
                get { return this.itemDisableFinishBackColor; }
                set
                {
                    if (this.itemDisableFinishBackColor == value)
                        return;
                    this.itemDisableFinishBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemDisableProceedBorderColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项边框颜色（禁止进行中）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项边框颜色（禁止进行中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableProceedBorderColor
            {
                get { return this.itemDisableProceedBorderColor; }
                set
                {
                    if (this.itemDisableProceedBorderColor == value)
                        return;
                    this.itemDisableProceedBorderColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemDisableFinishBorderColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项边框颜色（禁止完成）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项边框颜色（禁止完成）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableFinishBorderColor
            {
                get { return this.itemDisableFinishBorderColor; }
                set
                {
                    if (this.itemDisableFinishBorderColor == value)
                        return;
                    this.itemDisableFinishBorderColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private Color itemDisableTextColor = Color.Empty;
            /// <summary>
            /// 步骤流程选项文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("步骤流程选项文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color ItemDisableTextColor
            {
                get { return this.itemDisableTextColor; }
                set
                {
                    if (this.itemDisableTextColor == value)
                        return;
                    this.itemDisableTextColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 步骤流程选项更改事件参数
        /// </summary>
        [Description("步骤流程选项更改事件参数")]
        public class IndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 步骤流程选项
            /// </summary>
            [Description("步骤流程选项")]
            public ProcedureItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 步骤流程方向位置
        /// </summary>
        [Description("步骤流程方向位置")]
        public enum Orientations
        {
            /// <summary>
            ///水平放置靠近上边
            /// </summary>
            HorizontalTop,
            /// <summary>
            /// 水平放置靠近下边
            /// </summary>
            HorizontalBottom,
            /// <summary>
            /// 垂直放置靠近左边
            /// </summary>
            VerticalLeft,
            /// <summary>
            /// 垂直放置靠近右边
            /// </summary>
            VerticalRight,
        }

        #endregion
    }
}
