
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
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// SlideMenuPanelExt菜单面板控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("SlideMenuPanelExt菜单面板控件")]
    [DefaultProperty("Menu")]
    [DefaultEvent("ItemClick")]
    [TypeConverter(typeof(EmptyConverter))]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class SlideMenuPanelExt : Control
    {
        #region 新增事件

        public delegate void NodeClickEventHandler(object sender, NodeClickEventArgs e);
        private event NodeClickEventHandler nodeClick;
        /// <summary>
        /// 节点单击事件
        /// </summary>
        [Description("节点单击事件")]
        public event NodeClickEventHandler NodeClick
        {
            add { this.nodeClick += value; }
            remove { this.nodeClick -= value; }
        }

        public delegate void DrawNodeEventHandler(object sender, DrawNodeEventArgs e);
        private event DrawNodeEventHandler drawNode;
        /// <summary>
        /// 节点绘制事件
        /// </summary>
        [Description("节点绘制事件")]
        public event DrawNodeEventHandler DrawNode
        {
            add { this.drawNode += value; }
            remove { this.drawNode -= value; }
        }

        public delegate void SelectedChangedEventHandler(object sender, SelectedChangedEventArgs e);
        private event SelectedChangedEventHandler selectedChanged;
        /// <summary>
        /// 选中选项更改事件
        /// </summary>
        [Description("选中选项更改事件")]
        public event SelectedChangedEventHandler SelectedChanged
        {
            add { this.selectedChanged += value; }
            remove { this.selectedChanged -= value; }
        }

        public delegate void DrawPaintEventHandler(object sender, DragPaintEventArgs e);
        private event DrawPaintEventHandler dragPaint;
        /// <summary>
        /// 拖载条绘制事件
        /// </summary>
        [Description("拖载条绘制事件")]
        public event DrawPaintEventHandler DragPaint
        {
            add { this.dragPaint += value; }
            remove { this.dragPaint -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add { base.MarginChanged += value; }
            remove { base.MarginChanged -= value; }
        }

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
        public new event EventHandler BackgroundImageChanged
        {
            add { base.BackgroundImageChanged += value; }
            remove { base.BackgroundImageChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged
        {
            add { base.BackgroundImageLayoutChanged += value; }
            remove { base.BackgroundImageLayoutChanged -= value; }
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

        private bool borderShow = true;
        /// <summary>
        /// 是否显示边框
        /// </summary>
        [DefaultValue(true)]
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

        private Color borderColor = Color.FromArgb(100, 128, 128, 128);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "100, 128, 128, 128")]
        [Description(" 边框颜色")]
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

        private int moveWheelMagnify = 1;
        /// <summary>
        /// 鼠标滚轮旋转一格要移动多少个像素
        /// </summary>
        [DefaultValue(1)]
        [Description("鼠标滚轮旋转一格要移动多少个像素")]
        public int MoveWheelMagnify
        {
            get { return this.moveWheelMagnify; }
            set
            {
                if (this.moveWheelMagnify == value || value < 1)
                    return;

                this.moveWheelMagnify = value;
            }
        }

        private int lrAnimationAllTimer = 200;
        /// <summary>
        /// 展左右滑动动画总时间(毫秒)
        /// </summary>
        [DefaultValue(200)]
        [Description("展左右滑动动画总时间(毫秒)")]
        public int LRAnimationAllTimer
        {
            get { return this.lrAnimationAllTimer; }
            set
            {
                if (this.lrAnimationAllTimer == value)
                    return;

                this.lrAnimationAllTimer = value;
            }
        }

        private int ecAnimationAllTimer = 80;
        /// <summary>
        /// 展开折叠动画总时间(毫秒)
        /// </summary>
        [DefaultValue(80)]
        [Description("展开折叠动画总时间(毫秒)")]
        public int ECAnimationAllTimer
        {
            get { return this.ecAnimationAllTimer; }
            set
            {
                if (this.ecAnimationAllTimer == value)
                    return;

                this.ecAnimationAllTimer = value;
                this.Invalidate();
            }
        }

        private int nodeLRDistance = 10;
        /// <summary>
        /// 节点左右滑动滑动距离
        /// </summary>
        [Description("节点左右滑动滑动距离")]
        [DefaultValue(10)]
        public int NodeLRDistance
        {
            get { return this.nodeLRDistance; }
            set
            {
                if (this.nodeLRDistance == value || value < 0)
                    return;

                this.nodeLRDistance = value;
            }
        }

        private int nodeIndent = 16;
        /// <summary>
        /// 节点相对父节点缩进距离(限于NodeContentOrientations.Left)
        /// </summary>
        [Description("节点相对父节点缩进距离(限于NodeContentOrientations.Left)")]
        [DefaultValue(16)]
        public int NodeIndent
        {
            get { return this.nodeIndent; }
            set
            {
                if (this.nodeIndent == value)
                    return;

                this.nodeIndent = value;
                this.Invalidate();
            }
        }

        private bool nodeBorderShow = true;
        /// <summary>
        /// 是否显示节点边框
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示节点边框")]
        public bool NodeBorderShow
        {
            get { return this.nodeBorderShow; }
            set
            {
                if (this.nodeBorderShow == value)
                    return;

                this.nodeBorderShow = value;
                this.Invalidate();
            }
        }

        private NodeBorderStyles nodeBorderStyle = NodeBorderStyles.AroundBorder;
        /// <summary>
        /// 节点边框风格
        /// </summary>
        [DefaultValue(NodeBorderStyles.AroundBorder)]
        [Description("节点边框风格")]
        public NodeBorderStyles NodeBorderStyle
        {
            get { return this.nodeBorderStyle; }
            set
            {
                if (this.nodeBorderStyle == value)
                    return;

                this.nodeBorderStyle = value;
                this.Invalidate();
            }
        }

        private Color nodeBorderColor = Color.FromArgb(100, 128, 128, 128);
        /// <summary>
        /// 节点边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "100, 128, 128, 128")]
        [Description(" 节点边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color NodeBorderColor
        {
            get { return this.nodeBorderColor; }
            set
            {
                if (this.nodeBorderColor == value)
                    return;

                this.nodeBorderColor = value;
                this.Invalidate();
            }
        }

        private int nodeTextPaddingLeft = 0;
        /// <summary>
        /// 节点文本左边距
        /// </summary>
        [Description("节点文本左边距")]
        [DefaultValue(0)]
        public int NodeTextPaddingLeft
        {
            get { return this.nodeTextPaddingLeft; }
            set
            {
                if (this.nodeTextPaddingLeft == value || value < 0)
                    return;

                this.nodeTextPaddingLeft = value;
                this.Invalidate();
            }
        }


        private int nodeTextPaddingRight = 0;
        /// <summary>
        /// 节点文本右边距
        /// </summary>
        [Description("节点文本右边距")]
        [DefaultValue(0)]
        public int NodeTextPaddingRight
        {
            get { return this.nodeTextPaddingRight; }
            set
            {
                if (this.nodeTextPaddingRight == value || value < 0)
                    return;

                this.nodeTextPaddingRight = value;
                this.Invalidate();
            }
        }

        private int nodeImagePaddingLeft = 0;
        /// <summary>
        /// 节点图片左边距
        /// </summary>
        [Description("节点图片左边距")]
        [Localizable(true)]
        [DefaultValue(0)]
        public int NodeImagePaddingLeft
        {
            get { return this.nodeImagePaddingLeft; }
            set
            {
                if (this.nodeImagePaddingLeft == value || value < 0)
                    return;

                this.nodeImagePaddingLeft = value;
                this.Invalidate();
            }
        }

        private int nodeImagePaddingRight = 0;
        /// <summary>
        /// 节点图片右边距
        /// </summary>
        [Description("节点图片右边距")]
        [Localizable(true)]
        [DefaultValue(0)]
        public int NodeImagePaddingRight
        {
            get { return this.nodeImagePaddingRight; }
            set
            {
                if (this.nodeImagePaddingRight == value || value < 0)
                    return;

                this.nodeImagePaddingRight = value;
                this.Invalidate();
            }
        }

        public ToolClass tool;
        /// <summary>
        /// 工具栏
        /// </summary>
        [Description("工具栏")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolClass Tool
        {
            get
            {
                if (this.tool == null)
                    this.tool = new ToolClass(this);
                return this.tool;
            }
        }

        public NodeMenuClass menu;
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NodeMenuClass Menu
        {
            get
            {
                if (this.menu == null)
                    this.menu = new NodeMenuClass(this);
                return this.menu;
            }
        }

        public NodeMenuTabClass menuTab;
        /// <summary>
        /// 选项
        /// </summary>
        [Description("选项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NodeMenuTabClass MenuTab
        {
            get
            {
                if (this.menuTab == null)
                    this.menuTab = new NodeMenuTabClass(this);
                return this.menuTab;
            }
        }

        private ScrollClass scroll;
        /// <summary>
        /// 滚动条
        /// </summary>
        [Description("滚动条")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ScrollClass Scroll
        {
            get
            {
                if (this.scroll == null)
                    this.scroll = new ScrollClass(this);
                return this.scroll;
            }
        }

        private DragClass drag;
        /// <summary>
        /// 拖载条
        /// </summary>
        [Description("拖载条")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DragClass Drag
        {
            get
            {
                if (this.drag == null)
                    this.drag = new DragClass(this);
                return this.drag;
            }
        }

        private NodeCollection nodeCollection;
        /// <summary>
        /// 节点集合
        /// </summary>
        [DefaultValue(null)]
        [Description("节点集合")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NodeCollection Nodes
        {
            get
            {
                if (this.nodeCollection == null)
                    this.nodeCollection = new NodeCollection(null);
                return this.nodeCollection;
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
                return new Size(200, 300);
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
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

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
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
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
        /// 动画播放定时器
        /// </summary>
        private Timer intervalTimer;

        /// <summary>
        /// 展左右滑动动画参数
        /// </summary>
        private AnimationOptions lrAnimationOptions;
        /// <summary>
        /// 左右滑动节点列表
        /// </summary>
        private List<Node> lrAnimationList = new List<Node>();

        /// <summary>
        /// 展开折叠动画参数
        /// </summary>
        private AnimationOptions ecAnimationOptions;
        /// <summary>
        /// 展开折叠节点列表
        /// </summary>
        private List<Node> ecAnimationList = new List<Node>();

        /// <summary>
        /// 菜单Rect
        /// </summary>
        private Rectangle menuRect = Rectangle.Empty;
        /// <summary>
        /// 真实菜单Rect
        /// </summary>
        private Rectangle realityMenuRect = Rectangle.Empty;

        /// <summary>
        /// 是否显示滚动条
        /// </summary>
        private bool isShowScroll = false;

        /// <summary>
        /// 鼠标按下信息
        /// </summary>
        private MouseDownClass MouseDownInfo = new MouseDownClass();
        /// <summary>
        /// 是否按下鼠标
        /// </summary>
        private bool ismovedown = false;
        /// <summary>
        /// 鼠标按下的坐标
        /// </summary>
        private Point movedownpoint = Point.Empty;

        /// <summary>
        /// 是否按下拖动鼠标
        /// </summary>
        private bool isdrawmovedown = false;
        /// <summary>
        /// 鼠标按下拖动的坐标
        /// </summary>
        private Point drawmovedownpoint = Point.Empty;

        #endregion

        public SlideMenuPanelExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);

            this.InitializeRectangle();

            if (!this.DesignMode)
            {
                this.lrAnimationOptions = new AnimationOptions() { AllTransformTime = this.LRAnimationAllTimer };
                this.ecAnimationOptions = new AnimationOptions() { AllTransformTime = this.ECAnimationAllTimer };

                this.intervalTimer = new Timer();
                this.intervalTimer.Interval = 20;
                this.intervalTimer.Tick += new EventHandler(this.intervalTimer_Tick);
            }

        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            #region 背景

            SolidBrush back_sb = new SolidBrush(this.BackColor);
            g.FillRectangle(back_sb, this.menuRect);
            back_sb.Dispose();

            #endregion

            #region Drag背景
            if (this.Drag.Enabled)
            {
                SolidBrush drag_sb = new SolidBrush(this.Drag.BackColor);
                g.FillRectangle(drag_sb, this.Drag.Rect);
                drag_sb.Dispose();

                this.OnDragPaint(new DragPaintEventArgs() { Rect = this.Drag.Rect, g = g });
            }
            #endregion

            #region 工具栏
            if (this.Tool.Enabled)
            {
                #region 背景
                SolidBrush tool_back_sb = new SolidBrush(this.Tool.BackColor);
                g.FillRectangle(tool_back_sb, this.Tool.Rect);
                tool_back_sb.Dispose();
                #endregion

                #region MinBtn
                if (this.Tool.MinBtn.Enabled)
                {
                    if (this.Tool.MinBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_min_back_sb = new SolidBrush(this.Tool.MinBtn.EnterBackColor);
                        g.FillRectangle(tool_min_back_sb, this.Tool.MinBtn.Rect);
                        tool_min_back_sb.Dispose();
                    }
                    g.DrawImage((this.Tool.MinBtn.Image != null ? this.Tool.MinBtn.Image : global::WinformControlLibraryExtension.Resources.layout), this.Tool.MinBtn.Rect);
                }
                #endregion

                #region FixedBtn
                if (this.Tool.FixedBtn.Enabled)
                {
                    if (this.Tool.FixedBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_fixed_back_sb = new SolidBrush(this.Tool.FixedBtn.EnterBackColor);
                        g.FillRectangle(tool_fixed_back_sb, this.Tool.FixedBtn.Rect);
                        tool_fixed_back_sb.Dispose();
                    }
                    if (this.Tool.FixedBtn.ButtonChecked)
                    {
                        g.DrawImage((this.Tool.FixedBtn.CheckImage != null ? this.Tool.FixedBtn.CheckImage : global::WinformControlLibraryExtension.Resources._fixed), this.Tool.FixedBtn.Rect);
                    }
                    else
                    {
                        g.DrawImage((this.Tool.FixedBtn.UncheckImage != null ? this.Tool.FixedBtn.UncheckImage : global::WinformControlLibraryExtension.Resources.unfixed), this.Tool.FixedBtn.Rect);
                    }

                }
                #endregion

                #region AllExpandBtn
                if (this.Tool.AllExpandBtn.Enabled)
                {
                    if (this.Tool.AllExpandBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_expand_back_sb = new SolidBrush(this.Tool.AllExpandBtn.EnterBackColor);
                        g.FillRectangle(tool_expand_back_sb, this.Tool.AllExpandBtn.Rect);
                        tool_expand_back_sb.Dispose();
                    }
                    g.DrawImage((this.Tool.AllExpandBtn.Image != null ? this.Tool.AllExpandBtn.Image : global::WinformControlLibraryExtension.Resources.expandbtn), this.Tool.AllExpandBtn.Rect);
                }
                #endregion

                #region FirstExpandBtn
                if (this.Tool.FirstExpandBtn.Enabled)
                {
                    if (this.Tool.FirstExpandBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_firstexpand_back_sb = new SolidBrush(this.Tool.FirstExpandBtn.EnterBackColor);
                        g.FillRectangle(tool_firstexpand_back_sb, this.Tool.FirstExpandBtn.Rect);
                        tool_firstexpand_back_sb.Dispose();
                    }
                    g.DrawImage((this.Tool.FirstExpandBtn.Image != null ? this.Tool.FirstExpandBtn.Image : global::WinformControlLibraryExtension.Resources.expandfirstbtn), this.Tool.FirstExpandBtn.Rect);
                }
                #endregion

                #region AllCollapseBtn
                if (this.Tool.AllCollapseBtn.Enabled)
                {
                    if (this.Tool.AllCollapseBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_collapse_back_sb = new SolidBrush(this.Tool.AllCollapseBtn.EnterBackColor);
                        g.FillRectangle(tool_collapse_back_sb, this.Tool.AllCollapseBtn.Rect);
                        tool_collapse_back_sb.Dispose();
                    }
                    g.DrawImage((this.Tool.AllCollapseBtn.Image != null ? this.Tool.AllCollapseBtn.Image : global::WinformControlLibraryExtension.Resources.collapsebtn), this.Tool.AllCollapseBtn.Rect);
                }
                #endregion

                #region SearchClearBtn
                if (this.Tool.Search)
                {
                    if (this.Tool.SearchClearBtn.MouseStatus == NodeMouseStatuss.Enter)
                    {
                        SolidBrush tool_searchclear_back_sb = new SolidBrush(this.Tool.SearchClearBtn.EnterBackColor);
                        g.FillRectangle(tool_searchclear_back_sb, this.Tool.SearchClearBtn.Rect);
                        tool_searchclear_back_sb.Dispose();
                    }
                    g.DrawImage((this.Tool.SearchClearBtn.Image != null ? this.Tool.SearchClearBtn.Image : global::WinformControlLibraryExtension.Resources.searchclearbtn), this.Tool.SearchClearBtn.Rect);
                }
                #endregion
            }
            #endregion

            #region 节点

            #region 颜色

            Pen nodeborder_pen = null;
            LinearGradientBrush nodeborder_lgb = null;
            if (this.NodeBorderShow)
            {
                if (this.NodeBorderStyle == NodeBorderStyles.AroundBorder)
                {
                    nodeborder_pen = new Pen(this.NodeBorderColor, 1);
                }
                else
                {
                    nodeborder_lgb = new LinearGradientBrush(new PointF(this.menuRect.X, this.menuRect.Y), new PointF(this.menuRect.Right, this.menuRect.Y), Color.Transparent, Color.Transparent);
                    ColorBlend nodeborder_cb = new ColorBlend();
                    nodeborder_cb.Colors = new Color[] { Color.Transparent, this.NodeBorderColor, this.NodeBorderColor, Color.Transparent };
                    nodeborder_cb.Positions = new float[] { 0.0f, 0.23f, 0.70f, 1.0f };
                    nodeborder_lgb.InterpolationColors = nodeborder_cb;
                    nodeborder_pen = new Pen(nodeborder_lgb, 1);
                }
            }

            SolidBrush menu_normal_back_sb = new SolidBrush(this.Menu.NormalBackColor);
            SolidBrush menu_enter_back_sb = new SolidBrush(this.Menu.EnterBackColor);
            SolidBrush menu_disable_back_sb = new SolidBrush(this.Menu.DisableBackColor);

            SolidBrush menu_normal_text_sb = new SolidBrush(this.Menu.NormalTextColor);
            SolidBrush menu_enter_text_sb = new SolidBrush(this.Menu.EnterTextColor);
            SolidBrush menu_disable_text_sb = new SolidBrush(this.Menu.DisableTextColor);


            SolidBrush menutab_normal_back_sb = new SolidBrush(this.MenuTab.NormalBackColor);
            SolidBrush menutab_enter_back_sb = new SolidBrush(this.MenuTab.EnterBackColor);
            SolidBrush menutab_selected_back_sb = new SolidBrush(this.MenuTab.SelectedBackColor);
            SolidBrush menutab_disable_back_sb = new SolidBrush(this.MenuTab.DisableBackColor);

            SolidBrush menutab_normal_text_sb = new SolidBrush(this.MenuTab.NormalTextColor);
            SolidBrush menutab_enter_text_sb = new SolidBrush(this.MenuTab.EnterTextColor);
            SolidBrush menutab_selected_text_sb = new SolidBrush(this.MenuTab.SelectedTextColor);
            SolidBrush menutab_disable_text_sb = new SolidBrush(this.MenuTab.DisableTextColor);

            #endregion

            #region 绘制
            Region client_region = null;
            Region menu_region = null;
            if (this.Tool.Enabled)
            {
                client_region = g.Clip.Clone();
                menu_region = new Region(this.menuRect);
                g.Clip = menu_region;
            }

            this.RecursionNodePaint(this.Nodes, g, nodeborder_pen
                , menu_normal_back_sb, menu_enter_back_sb, menu_disable_back_sb, menu_normal_text_sb, menu_enter_text_sb, menu_disable_text_sb
                , menutab_normal_back_sb, menutab_enter_back_sb, menutab_selected_back_sb, menutab_disable_back_sb, menutab_normal_text_sb, menutab_enter_text_sb, menutab_selected_text_sb, menutab_disable_text_sb);

            if (menu_region != null)
            {
                g.Clip = client_region;
                menu_region.Dispose();
            }
            #endregion

            #region 释放全局画笔

            if (nodeborder_pen != null)
                nodeborder_pen.Dispose();

            if (nodeborder_lgb != null)
                nodeborder_lgb.Dispose();

            if (menu_normal_back_sb != null)
                menu_normal_back_sb.Dispose();
            if (menu_enter_back_sb != null)
                menu_enter_back_sb.Dispose();
            if (menu_disable_back_sb != null)
                menu_disable_back_sb.Dispose();

            if (menu_normal_text_sb != null)
                menu_normal_text_sb.Dispose();
            if (menu_enter_text_sb != null)
                menu_enter_text_sb.Dispose();
            if (menu_disable_text_sb != null)
                menu_disable_text_sb.Dispose();


            if (menutab_normal_back_sb != null)
                menutab_normal_back_sb.Dispose();
            if (menutab_enter_back_sb != null)
                menutab_enter_back_sb.Dispose();
            if (menutab_selected_back_sb != null)
                menutab_selected_back_sb.Dispose();
            if (menutab_disable_back_sb != null)
                menutab_disable_back_sb.Dispose();

            if (menutab_normal_text_sb != null)
                menutab_normal_text_sb.Dispose();
            if (menutab_enter_text_sb != null)
                menutab_enter_text_sb.Dispose();
            if (menutab_selected_text_sb != null)
                menutab_selected_text_sb.Dispose();
            if (menutab_disable_text_sb != null)
                menutab_disable_text_sb.Dispose();

            #endregion

            #endregion

            #region 滚动条
            if (this.realityMenuRect.Height > this.menuRect.Height)
            {
                if (!this.Scroll.Auto || this.isShowScroll)
                {
                    #region 画笔
                    SolidBrush bar_back_sb = null;
                    Pen slide_back_pen = null;

                    if (this.Enabled)
                    {
                        bar_back_sb = new SolidBrush(this.Scroll.BarNormalBackColor);
                        slide_back_pen = new Pen(this.Scroll.SlideStatus == ScrollSlideMoveStatus.Normal ? this.Scroll.SlideNormalBackColor : this.Scroll.SlideEnterBackColor, this.Scroll.Thickness);
                    }
                    else
                    {
                        bar_back_sb = new SolidBrush(this.Scroll.BarDisableBackColor);
                        slide_back_pen = new Pen(this.Scroll.SlideDisableBackColor, this.Scroll.Thickness);
                    }

                    if (this.Scroll.SlideRadius)
                    {
                        slide_back_pen.StartCap = LineCap.Round;
                        slide_back_pen.EndCap = LineCap.Round;
                    }
                    #endregion

                    #region 滑条
                    g.FillRectangle(bar_back_sb, this.Scroll.Rect);
                    #endregion

                    #region  滑块
                    PointF sp_start = PointF.Empty;
                    PointF sp_end = PointF.Empty;
                    if (this.Scroll.SlideRadius)
                    {
                        sp_start = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Y + this.Scroll.Thickness / 2);
                        sp_end = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Bottom - this.Scroll.Thickness / 2);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                    else
                    {
                        sp_start = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Y);
                        sp_end = new PointF(this.Scroll.SlideRect.X + this.Scroll.Thickness / 2, this.Scroll.SlideRect.Bottom);
                    }
                    g.DrawLine(slide_back_pen, sp_start, sp_end);

                    #endregion

                    #region 释放全局画笔

                    if (bar_back_sb != null)
                        bar_back_sb.Dispose();
                    if (slide_back_pen != null)
                        slide_back_pen.Dispose();

                    #endregion
                }
            }
            #endregion

            #region 边框

            if (this.BorderShow)
            {
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(border_pen, new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, (int)(this.Drag.Rect.X - 1), this.ClientRectangle.Height - 1));
                border_pen.Dispose();
            }

            #endregion

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            this.isShowScroll = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            if (!this.ismovedown)
            {
                this.isShowScroll = false;
            }

            if (this.Scroll.SlideStatus != ScrollSlideMoveStatus.Normal)
            {
                this.Scroll.SlideStatus = ScrollSlideMoveStatus.Normal;
                this.Invalidate();
            }

            Point point = this.PointToClient(MousePosition);
            this.UpdateToolButtonMouseStatus(point);
            this.UpdateNodeMouseStatus(point);
            this.AddNodeToLeftRightAnimation(point);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            if (!this.Focused)
            {
                this.Focus();
            }

            this.ismovedown = true;
            Point point = this.PointToClient(Control.MousePosition);
            this.movedownpoint = point;

            if (this.Tool.Enabled && this.Tool.Rect.Contains(e.Location))
            {
                if (this.Tool.MinBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.MinBtn;
                }
                else if (this.Tool.FixedBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.FixedBtn;
                }
                else if (this.Tool.AllCollapseBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.AllCollapseBtn;
                }
                else if (this.Tool.AllExpandBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.AllExpandBtn;
                }
                else if (this.Tool.FirstExpandBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.FirstExpandBtn;
                }
                else if (this.Tool.SearchClearBtn.Rect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.ToolButton;
                    this.MouseDownInfo.Sender = this.Tool.SearchClearBtn;
                }
                else
                {
                    this.MouseDownInfo.Type = MouseDownTypes.None;
                    this.MouseDownInfo.Sender = null;
                }
            }
            else if (this.Scroll.Rect.Contains(e.Location))
            {
                if (this.Scroll.SlideRect.Contains(e.Location))
                {
                    this.MouseDownInfo.Type = MouseDownTypes.Scroll;
                    this.MouseDownInfo.Sender = this.Scroll;
                }
                else
                {
                    this.MouseDownInfo.Type = MouseDownTypes.None;
                    this.MouseDownInfo.Sender = null;
                }
            }
            else if (this.menuRect.Contains(e.Location))
            {
                Node node = this.FindMouseDownNode(e.Location);
                if (node != null)
                {
                    this.MouseDownInfo.Type = MouseDownTypes.MenuNode;
                    this.MouseDownInfo.Sender = node;
                }
                else
                {
                    this.MouseDownInfo.Type = MouseDownTypes.None;
                    this.MouseDownInfo.Sender = null;
                }
            }
            else if (this.Drag.Enabled && this.Drag.Rect.Contains(e.Location))
            {

                this.isdrawmovedown = true;
                this.drawmovedownpoint = Control.MousePosition;
                this.MouseDownInfo.Type = MouseDownTypes.Drag;
                this.MouseDownInfo.Sender = this.Drag;
            }
            else
            {
                this.MouseDownInfo.Type = MouseDownTypes.None;
                this.MouseDownInfo.Sender = null;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            this.ismovedown = false;
            if (this.ClientRectangle.Contains(e.Location) == false)
            {
                this.isShowScroll = false;
                this.Invalidate();
            }

            if (this.MouseDownInfo.Type == MouseDownTypes.Drag)
            {
                Point point = Control.MousePosition;
                int offset = point.X - this.drawmovedownpoint.X;
                this.drawmovedownpoint = point;
                this.Drag.OnDraged(new DragingEventArgs() { X = offset });
                this.isdrawmovedown = false;
            }

            this.MouseDownInfo.Type = MouseDownTypes.None;
            this.MouseDownInfo.Sender = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            if (this.ismovedown)
            {
                Point point = this.PointToClient(Control.MousePosition);

                if (this.MouseDownInfo.Type == MouseDownTypes.Scroll)
                {
                    bool isreset = false;

                    #region scroll
                    if (this.Scroll.SlideRect.Contains(point))
                    {
                        if (this.Scroll.SlideStatus != ScrollSlideMoveStatus.Enter)
                        {
                            this.Scroll.SlideStatus = ScrollSlideMoveStatus.Enter;
                            isreset = true;
                        }
                    }
                    else
                    {
                        if (this.Scroll.SlideStatus != ScrollSlideMoveStatus.Normal)
                        {
                            this.Scroll.SlideStatus = ScrollSlideMoveStatus.Normal;
                            isreset = true;
                        }
                    }
                    #endregion

                    if (this.ismovedown)
                    {
                        if (this.MouseDownInfo.Type == MouseDownTypes.Scroll && (ScrollClass)this.MouseDownInfo.Sender == this.Scroll)
                        {
                            int offset = (int)((point.Y - this.movedownpoint.Y));
                            this.movedownpoint = point;

                            this.MouseMoveWheel(offset);
                        }
                    }

                    if (isreset)
                    {
                        this.Invalidate();
                    }
                }
                else if (this.MouseDownInfo.Type == MouseDownTypes.Drag)
                {
                    int offset = (int)((point.X - this.movedownpoint.X));
                    this.movedownpoint = point;
                    this.Drag.OnDraging(new DragingEventArgs() { X = offset });
                }
            }
            else
            {
                this.UpdateNodeMouseStatus(e.Location);
                this.AddNodeToLeftRightAnimation(e.Location);
            }

            this.UpdateToolButtonMouseStatus(e.Location);
            this.UpdateDrawMouseStatus(e.Location);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (this.MouseDownInfo.Type == MouseDownTypes.MenuNode)
                {
                    this.AddNodeToExpandCollapseAnimation((Node)this.MouseDownInfo.Sender, e.Location);
                    this.UpdateNodeSelectedStatus((Node)this.MouseDownInfo.Sender, e.Location);
                    this.OnNodeClick(new NodeClickEventArgs() { Node = (Node)this.MouseDownInfo.Sender });
                }
                else if (this.MouseDownInfo.Type == MouseDownTypes.ToolButton)
                {
                    if (this.MouseDownInfo.Sender == this.Tool.MinBtn)
                    {
                        this.Tool.MinBtn.OnClick(new EventArgs());
                    }
                    else if (this.MouseDownInfo.Sender == this.Tool.FixedBtn)
                    {
                        this.Tool.FixedBtn.ButtonChecked = !this.Tool.FixedBtn.ButtonChecked;
                        this.Tool.FixedBtn.OnClick(new EventArgs());
                        this.Invalidate();
                    }
                    else if (this.MouseDownInfo.Sender == this.Tool.AllCollapseBtn)
                    {
                        this.ExpandCollapse(false);
                        this.Tool.AllCollapseBtn.OnClick(new EventArgs());
                    }
                    else if (this.MouseDownInfo.Sender == this.Tool.AllExpandBtn)
                    {
                        this.ExpandCollapse(true);
                        this.Tool.AllExpandBtn.OnClick(new EventArgs());
                    }
                    else if (this.MouseDownInfo.Sender == this.Tool.FirstExpandBtn)
                    {
                        this.ExpandFirstNode();
                        this.Tool.FirstExpandBtn.OnClick(new EventArgs());

                    }
                    else if (this.MouseDownInfo.Sender == this.Tool.SearchClearBtn)
                    {
                        this.Tool.SearchText.Text = "";
                        this.Tool.SearchClearBtn.OnClick(new EventArgs());
                    }
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (this.DesignMode)
                return;

            int offset = e.Delta > 1 ? -this.MoveWheelMagnify : this.MoveWheelMagnify;
            this.MouseMoveWheel(offset);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (width < this.Drag.Width + 1)
            {
                width = this.Drag.Width + 1;
            }
            if (height < this.Tool.ButtonHeight + 1)
            {
                height = this.Tool.ButtonHeight + 1;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeDragRectangle();
            this.InitializeToolRectangle();
            this.InitializeMenuRectangle();
            this.Scroll.Rect = new Rectangle((int)this.Drag.Rect.X - this.Scroll.Thickness, this.Tool.Rect.Bottom, this.Scroll.Thickness, this.ClientRectangle.Height - this.Tool.Rect.Height);
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.intervalTimer != null)
                    this.intervalTimer.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnNodeClick(NodeClickEventArgs e)
        {
            if (this.nodeClick != null)
            {
                this.nodeClick(this, e);
            }
        }

        protected virtual void OnSelectedChanged(SelectedChangedEventArgs e)
        {
            if (this.selectedChanged != null)
            {
                this.selectedChanged(this, e);
            }
        }

        protected virtual void OnDragPaint(DragPaintEventArgs e)
        {
            if (this.dragPaint != null)
            {
                this.dragPaint(this, e);
            }
        }

        protected virtual void OnDrawNode(DrawNodeEventArgs e)
        {
            if (this.drawNode != null)
            {
                this.drawNode(this, e);
            }
        }

        #endregion

        #region  公开方法

        /// <summary>
        /// 刷新所有节点信息(Level、Menu、ContainerHeight、NodeRect)
        /// </summary>
        public void RestMenuNodes()
        {
            this.SetNodeLevel();
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 重新计算所有节点信息(Menu、ContainerHeight、NodeRect)
        /// </summary>
        public void UpdateMenuContentRect()
        {
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 过滤并显示节点
        /// </summary>
        /// <param name="text">要查找的文本</param>
        public void FilterByText(string text)
        {
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.RecursionFilter(this.Nodes[i], text);
            }
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 只展开第一层节点其余的折叠起来
        /// </summary>
        public void ExpandFirstNode()
        {
            this.RecursionExpandFirstNode(this.Nodes);
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 放弃过滤查询的结果
        /// </summary>
        public void GiveupFilter()
        {
            this.RecursionGiveupFilter(this.Nodes);
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 展开或折叠节点
        /// </summary>
        /// <param name="isExpand">是否展开</param>
        public void ExpandCollapse(bool isExpand)
        {
            this.RecursionExpandCollapse(this.Nodes, isExpand);
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
            this.Invalidate();
        }

        /// <summary>
        /// 查找选中节点
        /// </summary>
        /// <returns></returns>
        public Node GetSelectedNode()
        {
            return this.RecursionGetSelectedNode(this.Nodes);
        }

        /// <summary>
        /// 查找选中节点
        /// </summary>
        /// <returns>节点集合状态是否有更新过</returns>
        public bool SetSelectedNode(Node node)
        {
            bool result = false;
            if (node == null)
            {
                result = this.RecursionClearSelectedNode(this.Nodes);
            }
            else if (node.ItemType == NodeTypes.Menu)
            {
                return false;
            }
            else
            {
                result = this.RecursionSetSelectedNode(this.Nodes, node);
            }
            if (result)
            {
                this.Invalidate();
                this.OnSelectedChanged(new SelectedChangedEventArgs() { Node = node });
            }
            return result;
        }

        /// <summary>
        /// 根据节点文本查找符合条件的节点
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<Node> FindNodeByText(string text)
        {
            List<Node> nl = new List<Node>();
            this.RecursionFindNodeByText(this.Nodes, text, nl);
            return nl;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件Rect
        /// </summary>
        public void InitializeRectangle()
        {
            this.InitializeDragRectangle();
            this.InitializeToolRectangle();
            this.InitializeMenuRectangle();
            this.InitializeRealityMenuRectangle();
            this.InitializeScrollRectangle();
        }

        /// <summary>
        /// 初始化拖载条Rect
        /// </summary>
        private void InitializeDragRectangle()
        {
            if (this.Drag.Enabled)
            {
                this.Drag.Rect = new RectangleF(this.ClientRectangle.Right - this.Drag.Width, this.ClientRectangle.Y, this.Drag.Width, this.ClientRectangle.Height);
            }
            else
            {
                this.Drag.Rect = new RectangleF(this.ClientRectangle.Right, this.ClientRectangle.Y, 0, this.ClientRectangle.Height);
            }
        }

        /// <summary>
        /// 初始化工具栏Rect
        /// </summary>
        private void InitializeToolRectangle()
        {
            int tool_btn_padding = 4;
            Size tool_btn_size = new Size(16, 16);
            int tool_height_tmp = this.Tool.ButtonHeight + (this.Tool.Search ? this.Tool.SearchHeight : 0);
            this.Tool.Rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, (int)this.Drag.Rect.X, (this.Tool.Enabled ? tool_height_tmp : 0));

            this.Tool.MinBtn.Rect = new RectangleF(this.Tool.Rect.Right - (this.Tool.MinBtn.Enabled ? tool_btn_padding + tool_btn_size.Width : 0), this.Tool.Rect.Y + (this.Tool.ButtonHeight - tool_btn_size.Height) / 2, (this.Tool.MinBtn.Enabled ? tool_btn_size.Width : 0), tool_btn_size.Height);
            this.Tool.FixedBtn.Rect = new RectangleF(this.Tool.MinBtn.Rect.X - (this.Tool.FixedBtn.Enabled ? tool_btn_padding + tool_btn_size.Width : 0), this.Tool.Rect.Y + (this.Tool.ButtonHeight - tool_btn_size.Height) / 2, (this.Tool.FixedBtn.Enabled ? tool_btn_size.Width : 0), tool_btn_size.Height);
            this.Tool.AllExpandBtn.Rect = new RectangleF(this.Tool.FixedBtn.Rect.X - (this.Tool.AllExpandBtn.Enabled ? tool_btn_padding + tool_btn_size.Width : 0), this.Tool.Rect.Y + (this.Tool.ButtonHeight - tool_btn_size.Height) / 2, (this.Tool.AllExpandBtn.Enabled ? tool_btn_size.Width : 0), tool_btn_size.Height);
            this.Tool.FirstExpandBtn.Rect = new RectangleF(this.Tool.AllExpandBtn.Rect.X - (this.Tool.FirstExpandBtn.Enabled ? tool_btn_padding + tool_btn_size.Width : 0), this.Tool.Rect.Y + (this.Tool.ButtonHeight - tool_btn_size.Height) / 2, (this.Tool.FirstExpandBtn.Enabled ? tool_btn_size.Width : 0), tool_btn_size.Height);
            this.Tool.AllCollapseBtn.Rect = new RectangleF(this.Tool.FirstExpandBtn.Rect.X - (this.Tool.AllCollapseBtn.Enabled ? tool_btn_padding + tool_btn_size.Width : 0), this.Tool.Rect.Y + (this.Tool.ButtonHeight - tool_btn_size.Height) / 2, (this.Tool.AllCollapseBtn.Enabled ? tool_btn_size.Width : 0), tool_btn_size.Height);

            if (this.Tool.Search)
            {
                this.Tool.SearchClearBtn.Rect = new RectangleF(this.Tool.Rect.Right - tool_btn_padding - tool_btn_size.Width, this.Tool.Rect.Bottom - (this.Tool.SearchHeight - tool_btn_size.Height) / 2 - tool_btn_size.Height, tool_btn_size.Width, tool_btn_size.Height);

                int text_padding = 2;
                this.Tool.SearchText.Size = new Size((int)(this.Tool.SearchClearBtn.Rect.X - tool_btn_padding - text_padding * 2), this.Tool.SearchHeight - text_padding * 2);
                this.Tool.SearchText.Location = new Point(this.Tool.Rect.X + text_padding, this.Tool.Rect.Bottom - (this.Tool.SearchHeight - this.Tool.SearchText.Size.Height) / 2 - this.Tool.SearchText.Size.Height);
            }
        }

        /// <summary>
        /// 初始化菜单Rect
        /// </summary>
        private void InitializeMenuRectangle()
        {
            this.menuRect = new Rectangle(this.ClientRectangle.X, this.Tool.Rect.Bottom, this.Tool.Rect.Width, this.ClientRectangle.Height - this.Tool.Rect.Height);
        }

        /// <summary>
        /// 初始化真实菜单Rect
        /// </summary>
        private void InitializeRealityMenuRectangle()
        {
            this.realityMenuRect = new Rectangle(this.menuRect.X, this.menuRect.Y, this.menuRect.Width, 0);
            this.UpdateAllNodeContainerHeight();
            this.UpdateRealityMenuAndAllNodeRect();
        }

        /// <summary>
        /// 初始化滚动条Rect
        /// </summary>
        private void InitializeScrollRectangle()
        {
            this.Scroll.Rect = new Rectangle((int)this.Drag.Rect.X - this.Scroll.Thickness, this.Tool.Rect.Bottom, this.Scroll.Thickness, this.ClientRectangle.Height - this.Tool.Rect.Height);
            float bi = (float)this.menuRect.Height / (float)this.realityMenuRect.Height;
            if (bi > 1)
            {
                bi = 1;
            }
            float slide_height = this.Scroll.Rect.Height * bi;
            if (slide_height < this.Scroll.SlideMinHeight)
            {
                slide_height = this.Scroll.SlideMinHeight;
            }
            this.Scroll.SlideRect = new RectangleF(this.Scroll.Rect.X, this.Scroll.Rect.Y, this.Scroll.Thickness, slide_height);
        }

        /// <summary>
        /// 开始动画计时器
        /// </summary>
        private void IntervalTimerStart()
        {
            if (this.intervalTimer.Enabled == false && (this.lrAnimationList.Count > 0 || this.ecAnimationList.Count > 0))
            {
                this.intervalTimer.Enabled = true;
            }
        }

        /// <summary>
        /// 停止动画计时器
        /// </summary>
        private void IntervalTimerStop()
        {
            if (this.intervalTimer.Enabled == true && this.lrAnimationList.Count < 1 && this.ecAnimationList.Count < 1)
            {
                this.intervalTimer.Enabled = false;
            }
        }

        /// <summary>
        /// 更新工具栏按钮鼠标状态
        /// </summary>
        /// <param name="mousePoint"></param>
        private void UpdateToolButtonMouseStatus(Point mousePoint)
        {
            if (this.Tool.Enabled)
            {
                bool is_invalidate = false;
                if (this.Tool.MinBtn.Enabled)
                {
                    bool isInButtonRect = this.Tool.MinBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.MinBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.MinBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (this.Tool.FixedBtn.Enabled)
                {
                    bool isInButtonRect = this.Tool.FixedBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.FixedBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.FixedBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (this.Tool.AllCollapseBtn.Enabled)
                {
                    bool isInButtonRect = this.Tool.AllCollapseBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.AllCollapseBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.AllCollapseBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (this.Tool.AllExpandBtn.Enabled)
                {
                    bool isInButtonRect = this.Tool.AllExpandBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.AllExpandBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.AllExpandBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (this.Tool.FirstExpandBtn.Enabled)
                {
                    bool isInButtonRect = this.Tool.FirstExpandBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.FirstExpandBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.FirstExpandBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (this.Tool.Search)
                {
                    bool isInButtonRect = this.Tool.SearchClearBtn.Rect.Contains(mousePoint);
                    if ((this.Tool.SearchClearBtn.MouseStatus == NodeMouseStatuss.Enter) != isInButtonRect)
                    {
                        this.Tool.SearchClearBtn.MouseStatus = isInButtonRect ? NodeMouseStatuss.Enter : NodeMouseStatuss.Normal;
                        is_invalidate = true;
                    }
                }
                if (is_invalidate)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 更新拖动条鼠标状态
        /// </summary>
        /// <param name="mousePoint"></param>
        private void UpdateDrawMouseStatus(Point mousePoint)
        {
            if (this.Drag.Enabled)
            {
                if (this.Drag.Rect.Contains(mousePoint))
                {
                    if (this.Cursor != Cursors.VSplit)
                        this.Cursor = Cursors.VSplit;
                }
                else
                {
                    if (this.isdrawmovedown == false)
                    {
                        if (this.Cursor != Cursors.Default)
                            this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        /// 递归查找查找并节点是否带有指定文本
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool RecursionFilter(Node node, string text)
        {
            bool current_include = false;
            if (this.Tool.SearchLetterLower)
            {
                current_include = node.Text.Contains(text);
            }
            else
            {
                current_include = node.Text.ToLower().Contains(text.ToLower());
            }

            bool children_include = false;
            for (int i = 0; i < node.Children.Count; i++)
            {
                if (this.RecursionFilter(node.Children[i], text))
                {
                    children_include = true;
                    node.Children[i].Display = true;
                }
                else
                {
                    node.Children[i].Display = false;
                }
            }

            node.Display = (current_include || children_include) ? true : false;
            return node.Display;

        }

        /// <summary>
        /// 递归只展开第一层节点其余的折叠起来
        /// </summary>
        /// <param name="nodeList"></param>
        private void RecursionExpandFirstNode(NodeCollection nodeList)
        {
            foreach (Node node in nodeList)
            {
                node.Expand = node.Level == 0 ? true : false;
                this.RecursionExpandFirstNode(node.Children);
            }
        }

        /// <summary>
        /// 递归放弃过滤查询的结果
        /// </summary>
        /// <param name="nodeList"></param>
        private void RecursionGiveupFilter(NodeCollection nodeList)
        {
            foreach (Node node in nodeList)
            {
                node.Display = true;
                this.RecursionGiveupFilter(node.Children);
            }
        }

        /// <summary>
        /// 递归展开或折叠节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="isExpand"></param>
        private void RecursionExpandCollapse(NodeCollection nodeList, bool isExpand)
        {
            foreach (Node node in nodeList)
            {
                node.Expand = isExpand;
                this.RecursionExpandCollapse(node.Children, isExpand);
            }
        }

        /// <summary>
        /// 更新节点的鼠标状态
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        /// <returns>界面是否需要刷新</returns>
        private void UpdateNodeMouseStatus(Point mousePoint)
        {
            if (this.RecursionUpdateNodeMouseStatus(this.Nodes, mousePoint, (this.menuRect.Contains(mousePoint) && !this.Scroll.Rect.Contains(mousePoint))))
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 递归更新节点的鼠标状态
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="mousePoint"></param>
        /// <param name="isInMenuRect"></param>
        private bool RecursionUpdateNodeMouseStatus(NodeCollection nodeList, Point mousePoint, bool isInMenuRect)
        {
            bool result = false;
            foreach (Node node in nodeList)
            {
                if (node.Enabled && node.Display)
                {
                    if (isInMenuRect && node.Rect.Contains(mousePoint))
                    {
                        if (node.MouseStatus == NodeMouseStatuss.Normal)
                        {
                            node.MouseStatus = NodeMouseStatuss.Enter;
                            result = true;
                        }
                    }
                    else
                    {
                        if (node.MouseStatus == NodeMouseStatuss.Enter)
                        {
                            node.MouseStatus = NodeMouseStatuss.Normal;
                            result = true;
                        }
                    }
                }
                if (this.RecursionUpdateNodeMouseStatus(node.Children, mousePoint, isInMenuRect))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 查找被按下的子节节点
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        /// <returns>没有为null</returns>
        private Node FindMouseDownNode(Point mousePoint)
        {
            return this.RecursionFindMouseDownNode(this.Nodes, mousePoint);
        }

        /// <summary>
        /// 递归查找被按下的子节节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="mousePoint"></param>
        private Node RecursionFindMouseDownNode(NodeCollection nodeList, Point mousePoint)
        {
            foreach (Node node in nodeList)
            {
                if (node.Enabled && node.Display)
                {
                    if (node.Rect.Contains(mousePoint))
                    {
                        return node;
                    }
                }
                Node chileren_node = this.RecursionFindMouseDownNode(node.Children, mousePoint);
                if (chileren_node != null)
                {
                    return chileren_node;
                }
            }
            return null;
        }

        /// <summary>
        /// 查找并添加符合条件的节点到左右滑动动画中
        /// </summary>
        /// <param name="mousePoint"></param>
        private void AddNodeToLeftRightAnimation(Point mousePoint)
        {
            this.RecursionAddNodeToLeftRightAnimation(this.Nodes, mousePoint, (this.menuRect.Contains(mousePoint) && !this.Scroll.Rect.Contains(mousePoint)));
            this.IntervalTimerStart();
        }

        /// <summary>
        /// 递归查找并添加符合条件的节点到左右滑动动画中
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="mousePoint"></param>
        /// <param name="isInMenuRect"></param>
        private void RecursionAddNodeToLeftRightAnimation(NodeCollection nodeList, Point mousePoint, bool isInMenuRect)
        {
            foreach (Node node in nodeList)
            {
                bool node_text_center = node.ItemType == NodeTypes.Menu ? (this.Menu.ContentOrientation == NodeContentOrientations.Center) : (this.MenuTab.ContentOrientation == NodeContentOrientations.Center);
                if (node.Enabled && node.Display && node_text_center == false)
                {
                    if (isInMenuRect && node.Rect.Contains(mousePoint))
                    {
                        if (node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreed || node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreing)
                        {
                            node.LRAnimationStatus = NodeLRAnimationStatuss.Slideing;
                            this.lrAnimationList.Add(node);
                        }
                    }
                    else
                    {
                        if (node.LRAnimationStatus == NodeLRAnimationStatuss.Slideed || node.LRAnimationStatus == NodeLRAnimationStatuss.Slideing)
                        {
                            node.LRAnimationStatus = NodeLRAnimationStatuss.Restoreing;
                            this.lrAnimationList.Add(node);
                        }
                    }
                }
                this.RecursionAddNodeToLeftRightAnimation(node.Children, mousePoint, isInMenuRect);
            }
        }

        /// <summary>
        /// 判断指定节点是否符合条件并添加到展开折叠动画中
        /// </summary>
        /// <param name="node"></param>
        /// <param name="mousePoint"></param>
        private void AddNodeToExpandCollapseAnimation(Node node, Point mousePoint)
        {
            if (node.Enabled && node.Display && node.Rect.Contains(mousePoint))
            {
                if (node.ECAnimationStatus == NodeECAnimationStatuss.Expanded || node.ECAnimationStatus == NodeECAnimationStatuss.Expanding)//折叠
                {
                    if (node.ECAnimationTime == 0)
                    {
                        node.ECAnimationTime = this.ECAnimationAllTimer;
                    }
                    node.ContainerHeightTmp = this.GetNodeNoAnimationExpandContainerHeight(node);
                    node.ECAnimationStatus = NodeECAnimationStatuss.Collapseing;
                }
                else//展开
                {
                    node.ContainerHeightTmp = this.GetNodeNoAnimationExpandContainerHeight(node);
                    node.ECAnimationStatus = NodeECAnimationStatuss.Expanding;
                }
                this.ecAnimationList.Add(node);
                this.IntervalTimerStart();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 更新节点的选中状态
        /// </summary>
        /// <param name="mousePoint"></param>
        /// <returns></returns>
        private void UpdateNodeSelectedStatus(Node down_node, Point mousePoint)
        {
            if (down_node.ItemType == NodeTypes.MenuTab)
            {
                Node node = this.RecursionUpdateNodeSelectedStatus(this.Nodes, down_node, mousePoint);
                if (node != null)
                {
                    this.Invalidate();
                    this.OnSelectedChanged(new SelectedChangedEventArgs() { Node = node });
                }
            }
        }

        /// <summary>
        /// 递归更新节点的选中状态并返回该节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="mousePoint"></param>
        /// <returns></returns>
        private Node RecursionUpdateNodeSelectedStatus(NodeCollection nodeList, Node down_node, Point mousePoint)
        {
            Node result_node = null;//用来判断是否需要刷新
            foreach (Node node in nodeList)
            {
                if (down_node == node && node.Enabled && node.Display && node.Rect.Contains(mousePoint))
                {
                    if (node.Selected == false)
                    {
                        result_node = node;
                    }
                    node.Selected = true;
                }
                else
                {
                    node.Selected = false;
                }
                Node children_node = this.RecursionUpdateNodeSelectedStatus(node.Children, down_node, mousePoint);
                if (children_node != null)
                {
                    result_node = children_node;
                }
            }
            return result_node;
        }

        /// <summary>
        /// 递归查找选中节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        private Node RecursionGetSelectedNode(NodeCollection nodeList)
        {
            foreach (Node node in nodeList)
            {
                if (node.Selected)
                {
                    return node;
                }
                Node children_node = this.RecursionGetSelectedNode(node.Children);
                if (children_node != null)
                {
                    return children_node;
                }
            }
            return null;
        }

        /// <summary>
        /// 递归设置指定节点为选中节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="current_node"></param>
        /// <returns>指定节点选中状态是否更改过</returns>
        private bool RecursionSetSelectedNode(NodeCollection nodeList, Node current_node)
        {
            bool result = false;
            foreach (Node node in nodeList)
            {
                if (current_node == node)
                {
                    if (node.Selected == false)
                    {
                        node.Selected = true;
                        result = true;
                    }
                }
                else
                {
                    node.Selected = false;
                }
                bool children = this.RecursionSetSelectedNode(node.Children, current_node);
                if (children == true)
                {
                    result = children;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据节点文本查找符合条件的节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="text"></param>
        /// <param name="nl">查找结果集合</param>
        private void RecursionFindNodeByText(NodeCollection nodeList, string text, List<Node> nl)
        {
            foreach (Node node in nodeList)
            {
                if (node.Text == text)
                {
                    nl.Add(node);
                }
                this.RecursionFindNodeByText(node.Children, text, nl);
            }
        }

        /// <summary>
        /// 递归清除选中节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns>是否找到要清理的选中节点</returns>
        private bool RecursionClearSelectedNode(NodeCollection nodeList)
        {
            foreach (Node node in nodeList)
            {
                if (node.Selected)
                {
                    node.Selected = false;
                    return true;
                }
                bool children = this.RecursionClearSelectedNode(node.Children);
                if (children == true)
                {
                    return true;
                }
            }
            return false;
        }

        #region 节点Rect

        /// <summary>
        /// 设置所有节点深度
        /// </summary>
        private void SetNodeLevel()
        {
            this.RecursionSetNodeLevel(this.Nodes);
        }

        /// <summary>
        /// 递归设置所有节点深度
        /// </summary>
        /// <param name="nodeList"></param>
        private void RecursionSetNodeLevel(NodeCollection nodeList)
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                int level = (nodeList[i].Parent == null) ? 0 : nodeList[i].Parent.Level + 1;
                nodeList[i].Level = level;
                this.RecursionSetNodeLevel(nodeList[i].Children);
            }
        }

        /// <summary>
        /// 更新所有节点容器高度
        /// </summary>
        private void UpdateAllNodeContainerHeight()
        {
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.Nodes[i].ContainerHeight = this.RecursionSetNodeContainerHeight(this.Nodes[i]);
            }
        }

        /// <summary>
        /// 递归设置节点容器高度
        /// </summary>
        /// <param name="node">节点</param>
        /// <returns>返回节点容器高度</returns>
        private int RecursionSetNodeContainerHeight(Node node)
        {
            int container_height = 0;

            if (node.ItemType == NodeTypes.MenuTab)
            {
                node.ContainerHeight = container_height;
                return container_height;
            }
            else
            {
                if (node.ECAnimationStatus == NodeECAnimationStatuss.Expanded || node.ECAnimationStatus == NodeECAnimationStatuss.Collapseed)//非动画中
                {
                    if (node.ECAnimationStatus == NodeECAnimationStatuss.Expanded)
                    {
                        for (int i = 0; i < node.Children.Count; i++)
                        {
                            if (node.Children[i].Display)
                            {
                                container_height += node.Children[i].ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height;
                            }
                            int children_container_height = this.RecursionSetNodeContainerHeight(node.Children[i]);
                            if (node.Children[i].ItemType == NodeTypes.Menu && (node.Children[i].ECAnimationStatus == NodeECAnimationStatuss.Expanding || node.Children[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseing))
                            {
                                children_container_height = (int)(children_container_height * WcleAnimationLibrary.AnimationTimer.GetProgress(AnimationTypes.UniformMotion, ecAnimationOptions, node.Children[i].ECAnimationTime));
                            }
                            if (node.Children[i].Display)
                            {
                                container_height += children_container_height;
                            }
                        }
                    }
                    else if (node.ECAnimationStatus == NodeECAnimationStatuss.Collapseed)
                    {
                        container_height = 0;
                    }
                }
                else if (node.ECAnimationStatus == NodeECAnimationStatuss.Expanding || node.ECAnimationStatus == NodeECAnimationStatuss.Collapseing)//动画中
                {
                    double progress = WcleAnimationLibrary.AnimationTimer.GetProgress(AnimationTypes.UniformMotion, ecAnimationOptions, node.ECAnimationTime);
                    if (progress > 1)
                    {
                        progress = 1;
                    }
                    if (progress < 0)
                    {
                        progress = 0;
                    }
                    node.ContainerHeight = (int)(node.ContainerHeightTmp * progress);
                    container_height = node.ContainerHeight;
                }

                if (node.Display == false)
                {
                    container_height = 0;
                }
                node.ContainerHeight = container_height;
                return container_height;
            }
        }

        /// <summary>
        /// 获取指定节点在非动画展开状态下的容器深度
        /// </summary>
        /// <param name="node"></param>
        /// <returns>返回指定节点在非动画展开状态下的容器深度</returns>
        private int GetNodeNoAnimationExpandContainerHeight(Node node)
        {
            int container_height = 0;

            if (node.ItemType == NodeTypes.MenuTab)
            {
                return container_height;
            }

            for (int i = 0; i < node.Children.Count; i++)
            {
                container_height += this.GetNodeHeight(node.Children[i], node.Children[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseed);
            }
            return container_height;
        }

        /// <summary>
        /// 获取指定节点实际高度(GetNodeNoAnimationExpandContainerHeight 调用)
        /// </summary>
        /// <param name="node">指定节点</param>
        /// <param name="ancestorCollapse">祖先节点是否折叠过</param>
        /// <returns>返回指定节点实际高度</returns>
        private int GetNodeHeight(Node node, bool ancestorCollapse)
        {
            int container_height = 0;

            if (node.ItemType == NodeTypes.MenuTab)
            {
                if (node.Display)
                {
                    container_height += this.MenuTab.Height;
                }
                return container_height;
            }
            else
            {
                if (node.Display)
                {
                    container_height += this.Menu.Height;
                }
                if (ancestorCollapse == true)
                {
                    return container_height;
                }
                else
                {
                    for (int i = 0; i < node.Children.Count; i++)//子子节及选项
                    {
                        if (node.Children[i].Display)
                        {
                            bool collapse = ancestorCollapse ? true : (node.Children[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseed);
                            container_height += GetNodeHeight(node.Children[i], collapse);
                        }
                    }
                }
            }
            return container_height;
        }

        /// <summary>
        /// 更新计算真实菜单Rect和所有节点Rect
        /// </summary>
        private void UpdateRealityMenuAndAllNodeRect()
        {
            bool ancestorCollapse = false;//祖先节点是否折叠过
            int height = 0;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.RecursionSetNodeRect(this.Nodes, this.Nodes[i], ancestorCollapse);
                if (this.Nodes[i].Display)
                {
                    height += (this.Nodes[i].ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height) + this.Nodes[i].ContainerHeight;
                }
            }

            this.realityMenuRect = new Rectangle(this.realityMenuRect.X, this.realityMenuRect.Y, this.realityMenuRect.Width, height);


            int y = this.realityMenuRect.Y;
            if (this.realityMenuRect.Bottom < this.menuRect.Bottom)
            {
                y += (this.menuRect.Bottom - this.realityMenuRect.Bottom);
            }
            if (y > this.menuRect.Y)
            {
                y = this.menuRect.Y;
            }
            this.realityMenuRect = new Rectangle(this.realityMenuRect.X, y, this.realityMenuRect.Width, this.realityMenuRect.Height);

            bool ancestorCollapse2 = false;//祖先节点是否折叠过
            int height2 = 0;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.RecursionSetNodeRect(this.Nodes, this.Nodes[i], ancestorCollapse2);
                if (this.Nodes[i].Display)
                {
                    height2 += (this.Nodes[i].ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height) + this.Nodes[i].ContainerHeight;
                }
            }

            this.UpdateScrollSlideRectLocation();
        }

        /// <summary>
        /// 更新滑块的RectLocation
        /// </summary>
        public void UpdateScrollSlideRectLocation()
        {
            float slide_height = this.Scroll.Rect.Height * ((float)this.menuRect.Height / ((float)this.realityMenuRect.Height));
            if (slide_height < this.Scroll.SlideMinHeight)
            {
                slide_height = this.Scroll.SlideMinHeight;
            }
            float h = this.menuRect.Y - this.realityMenuRect.Y;
            if (this.realityMenuRect.Y < 0)
            {
                h = this.menuRect.Y + Math.Abs(this.realityMenuRect.Y);
            }
            float slide_y = this.Scroll.Rect.Y + (this.Scroll.Rect.Height - slide_height) * h / (float)(this.realityMenuRect.Height - this.menuRect.Height);

            this.Scroll.SlideRect = new RectangleF(this.Scroll.Rect.X, slide_y, this.Scroll.SlideRect.Width, slide_height);

        }

        /// <summary>
        /// 递归设置节点Rect
        /// </summary>
        /// <param name="nodeList">和节点相同位置的列表</param>
        /// <param name="node">节点</param>
        /// <param name="ancestorCollapse">祖先节点是否折叠过</param>
        private void RecursionSetNodeRect(NodeCollection nodeList, Node node, bool ancestorCollapse)
        {
            int node_index = nodeList.IndexOf(node);//节点在列表的索引值
            int node_x = 0;
            int node_y = 0;
            int node_h = 0;
            if (ancestorCollapse == true)
            {
                if (node.Parent.ECAnimationStatus == NodeECAnimationStatuss.Expanding || node.Parent.ECAnimationStatus == NodeECAnimationStatuss.Collapseing)
                {
                    node_h = node.ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height;
                }

                if (node_index == 0)//0索引
                {
                    if (node.Level == 0)//0深度
                    {
                        node_y = this.realityMenuRect.Top;
                    }
                    else
                    {
                        node_y = (int)node.Parent.Rect.Bottom;
                    }
                }
                else
                {
                    int k_index = -1;
                    for (int k = node_index - 1; k >= 0; k--)
                    {
                        if (nodeList[k].Display)
                        {
                            k_index = k;
                            break;
                        }
                    }
                    if (k_index > -1)
                    {
                        node_y = (int)(nodeList[k_index].Rect.Bottom);
                    }
                    else
                    {
                        if (node.Level == 0)
                        {
                            node_y = this.realityMenuRect.Top;
                        }
                        else
                        {
                            node_y = (int)node.Parent.Rect.Bottom;
                        }
                    }
                }
            }
            else
            {
                node_h = node.ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height;
                if (node_index == 0)
                {
                    if (node.Level == 0)
                    {
                        node_y = this.realityMenuRect.Top;
                    }
                    else
                    {
                        node_y = (int)node.Parent.Rect.Bottom;
                    }
                }
                else
                {
                    int k_index = -1;
                    for (int k = node_index - 1; k >= 0; k--)
                    {
                        if (nodeList[k].Display)
                        {
                            k_index = k;
                            break;
                        }
                    }
                    if (k_index > -1)
                    {
                        node_y = (int)(nodeList[k_index].Rect.Bottom + nodeList[k_index].ContainerHeight);
                    }
                    else
                    {
                        if (node.Level == 0)
                        {
                            node_y = this.realityMenuRect.Top;
                        }
                        else
                        {
                            node_y = (int)node.Parent.Rect.Bottom;
                        }
                    }
                }
            }

            node.Rect = new RectangleF(node_x, node_y, this.menuRect.Width, node_h);

            for (int i = 0; i < node.Children.Count; i++)
            {
                if (node.Parent != null && (node.Parent.ECAnimationStatus == NodeECAnimationStatuss.Expanding || node.Parent.ECAnimationStatus == NodeECAnimationStatuss.Collapseing))
                {
                    ancestorCollapse = false;
                }
                bool collapse = ancestorCollapse ? true : (node.ECAnimationStatus == NodeECAnimationStatuss.Collapseed ? true : false);
                this.RecursionSetNodeRect(node.Children, node.Children[i], collapse);
            }
        }

        /// <summary>
        /// 滚动条移动或鼠标滚轮移动
        /// </summary>
        /// <param name="offset"></param>
        private void MouseMoveWheel(int offset)
        {
            float y = this.Scroll.SlideRect.Y;
            y += offset;
            if (y < this.Scroll.Rect.Y)
            {
                y = this.Scroll.Rect.Y;
            }
            if (y > this.Scroll.Rect.Bottom - this.Scroll.SlideRect.Height)
            {
                y = this.Scroll.Rect.Bottom - this.Scroll.SlideRect.Height;
            }

            this.Scroll.SlideRect = new RectangleF(this.Scroll.SlideRect.Location.X, y, this.Scroll.SlideRect.Width, this.Scroll.SlideRect.Height);

            float bi = (float)(this.Scroll.SlideRect.Y - this.Scroll.Rect.Y) / (float)(this.Scroll.Rect.Height - this.Scroll.SlideRect.Height);

            float scroll_h = this.realityMenuRect.Height - this.menuRect.Height < 0 ? 0 : (this.realityMenuRect.Height - this.menuRect.Height);
            this.realityMenuRect.Y = (int)(this.menuRect.Y - scroll_h * bi);


            bool ancestorCollapse = false;//祖先节点是否折叠过
            int height = 0;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.RecursionSetNodeRect(this.Nodes, this.Nodes[i], ancestorCollapse);
                if (this.Nodes[i].Display)
                {
                    height += (this.Nodes[i].ItemType == NodeTypes.Menu ? this.Menu.Height : this.MenuTab.Height) + this.Nodes[i].ContainerHeight;
                }
            }

            this.Invalidate();
        }

        #endregion

        #region 绘制

        /// <summary>
        /// 递归绘制所有节点
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="g"></param>
        /// <param name="nodeborder_pen"></param>
        /// <param name="menu_normal_back_sb"></param>
        /// <param name="menu_enter_back_sb"></param>
        /// <param name="menu_disable_back_sb"></param>
        /// <param name="menu_normal_text_sb"></param>
        /// <param name="menu_enter_text_sb"></param>
        /// <param name="menu_disable_text_sb"></param>
        /// <param name="menutab_normal_back_sb"></param>
        /// <param name="menutab_enter_back_sb"></param>
        /// <param name="menutab_selected_back_sb"></param>
        /// <param name="menutab_disable_back_sb"></param>
        /// <param name="menutab_normal_text_sb"></param>
        /// <param name="menutab_enter_text_sb"></param>
        /// <param name="menutab_selected_text_sb"></param>
        /// <param name="menutab_disable_text_sb"></param>
        private void RecursionNodePaint(NodeCollection nodeList, Graphics g, Pen nodeborder_pen
            , SolidBrush menu_normal_back_sb, SolidBrush menu_enter_back_sb, SolidBrush menu_disable_back_sb, SolidBrush menu_normal_text_sb, SolidBrush menu_enter_text_sb, SolidBrush menu_disable_text_sb
            , SolidBrush menutab_normal_back_sb, SolidBrush menutab_enter_back_sb, SolidBrush menutab_selected_back_sb, SolidBrush menutab_disable_back_sb, SolidBrush menutab_normal_text_sb, SolidBrush menutab_enter_text_sb, SolidBrush menutab_selected_text_sb, SolidBrush menutab_disable_text_sb)
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                #region 绘制当前节点

                if (nodeList[i].Display && nodeList[i].Rect.Bottom >= this.ClientRectangle.Y && nodeList[i].Rect.Y <= this.ClientRectangle.Bottom)
                {
                    SolidBrush commom_back_sb = null;
                    SolidBrush commom_text_sb = null;
                    bool custom_back_sb = false;
                    bool custom_text_sb = false;

                    if (nodeList[i].Enabled == false)
                    {
                        if (nodeList[i].DisableBackColor == Color.Empty)
                        {
                            commom_back_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_disable_back_sb : menutab_disable_back_sb;
                        }
                        else
                        {
                            custom_back_sb = true;
                            commom_back_sb = new SolidBrush(nodeList[i].DisableBackColor);
                        }
                        if (nodeList[i].DisableTextColor == Color.Empty)
                        {
                            commom_text_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_disable_text_sb : menutab_disable_text_sb;
                        }
                        else
                        {
                            custom_text_sb = true;
                            commom_text_sb = new SolidBrush(nodeList[i].DisableTextColor);
                        }
                    }
                    else
                    {
                        if (nodeList[i].MouseStatus == NodeMouseStatuss.Enter)
                        {
                            if (nodeList[i].EnterBackColor == Color.Empty)
                            {
                                commom_back_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_enter_back_sb : menutab_enter_back_sb;
                            }
                            else
                            {
                                custom_back_sb = true;
                                commom_back_sb = new SolidBrush(nodeList[i].EnterBackColor);
                            }
                            if (nodeList[i].EnterTextColor == Color.Empty)
                            {
                                commom_text_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_enter_text_sb : menutab_enter_text_sb;
                            }
                            else
                            {
                                custom_text_sb = true;
                                commom_text_sb = new SolidBrush(nodeList[i].EnterTextColor);
                            }
                        }
                        else
                        {
                            if (nodeList[i].Selected == true)
                            {
                                if (nodeList[i].SelectedBackColor == Color.Empty)
                                {
                                    commom_back_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_normal_back_sb : menutab_selected_back_sb;
                                }
                                else
                                {
                                    custom_back_sb = true;
                                    commom_back_sb = new SolidBrush(nodeList[i].SelectedBackColor);
                                }
                                if (nodeList[i].SelectedTextColor == Color.Empty)
                                {
                                    commom_text_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_normal_text_sb : menutab_selected_text_sb;
                                }
                                else
                                {
                                    custom_text_sb = true;
                                    commom_text_sb = new SolidBrush(nodeList[i].SelectedTextColor);
                                }
                            }
                            else
                            {
                                if (nodeList[i].NormalBackColor == Color.Empty)
                                {
                                    commom_back_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_normal_back_sb : menutab_normal_back_sb;
                                }
                                else
                                {
                                    custom_back_sb = true;
                                    commom_back_sb = new SolidBrush(nodeList[i].NormalBackColor);
                                }
                                if (nodeList[i].NormalTextColor == Color.Empty)
                                {
                                    commom_text_sb = nodeList[i].ItemType == NodeTypes.Menu ? menu_normal_text_sb : menutab_normal_text_sb;
                                }
                                else
                                {
                                    custom_text_sb = true;
                                    commom_text_sb = new SolidBrush(nodeList[i].NormalTextColor);
                                }
                            }
                        }
                    }

                    NodePaint(nodeList[i], g, nodeborder_pen, commom_back_sb, commom_text_sb);

                    if (custom_back_sb && commom_back_sb != null)
                        commom_back_sb.Dispose();
                    if (custom_text_sb && commom_text_sb != null)
                        commom_text_sb.Dispose();
                }

                #endregion

                #region 绘制子节点

                if (nodeList[i].ItemType == NodeTypes.Menu)
                {
                    if (nodeList[i].ECAnimationStatus == NodeECAnimationStatuss.Expanding || nodeList[i].ECAnimationStatus == NodeECAnimationStatuss.Expanded || nodeList[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseing)
                    {
                        Region container_region = null;
                        Region animation_region = null;
                        if (nodeList[i].ECAnimationStatus == NodeECAnimationStatuss.Expanding || nodeList[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseing)
                        {
                            container_region = g.Clip.Clone();
                            animation_region = new Region(new RectangleF(nodeList[i].Rect.X, nodeList[i].Rect.Bottom, nodeList[i].Rect.Width, nodeList[i].ContainerHeight));
                            g.Clip = animation_region;
                        }

                        RecursionNodePaint(nodeList[i].Children, g, nodeborder_pen
                             , menu_normal_back_sb, menu_enter_back_sb, menu_disable_back_sb, menu_normal_text_sb, menu_enter_text_sb, menu_disable_text_sb
                             , menutab_normal_back_sb, menutab_enter_back_sb, menutab_selected_back_sb, menutab_disable_back_sb, menutab_normal_text_sb, menutab_enter_text_sb, menutab_selected_text_sb, menutab_disable_text_sb);

                        if (animation_region != null)
                        {
                            g.Clip = container_region;
                            animation_region.Dispose();
                        }
                    }

                }

                #endregion
            }
        }


        /// <summary>
        /// 绘制当前节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="g"></param>
        /// <param name="nodeborder_pen"></param>
        /// <param name="commom_back_sb"></param>
        /// <param name="commom_text_sb"></param>
        protected virtual void NodePaint(Node node, Graphics g, Pen nodeborder_pen, SolidBrush commom_back_sb, SolidBrush commom_text_sb)
        {
            #region 节点背景
            g.FillRectangle(commom_back_sb, node.Rect);
            #endregion

            #region 节点文本

            SizeF text_size = g.MeasureString(node.Text, this.Font);
            float text_x = 0;
            switch (node.ItemType == NodeTypes.Menu ? this.Menu.ContentOrientation : this.MenuTab.ContentOrientation)
            {
                case NodeContentOrientations.Left:
                    {
                        int fold_image_w = (this.Menu.FoldImageShow && this.Menu.FoldImageOrientation == NodeImageOrientations.Left) ? this.Menu.FoldImageSize.Width + this.Menu.FoldImagePaddingLeft + this.Menu.FoldImagePaddingRight : 0;
                        int image_w = node.ItemType == NodeTypes.Menu ? (this.Menu.ImageShow ? this.Menu.ImageSize.Width + this.NodeImagePaddingLeft + this.NodeImagePaddingRight : 0) : (this.MenuTab.ImageShow ? this.MenuTab.ImageSize.Width + this.NodeImagePaddingLeft + this.NodeImagePaddingRight : 0);
                        if (node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreed)
                        {
                            text_x = node.Rect.X + node.Level * this.NodeIndent + fold_image_w + image_w + this.NodeTextPaddingLeft;
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Slideed)
                        {
                            text_x = node.Rect.X + node.Level * this.NodeIndent + fold_image_w + image_w + this.NodeTextPaddingLeft + this.NodeLRDistance;
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Slideing)
                        {
                            text_x = node.Rect.X + node.Level * this.NodeIndent + fold_image_w + image_w + this.NodeTextPaddingLeft + (float)(this.NodeLRDistance * AnimationTimer.GetProgress(AnimationTypes.EaseOut, lrAnimationOptions, node.LRAnimationTime));
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreing)
                        {
                            text_x = node.Rect.X + node.Level * this.NodeIndent + fold_image_w + image_w + this.NodeTextPaddingLeft + (float)(this.NodeLRDistance * AnimationTimer.GetProgress(AnimationTypes.EaseOut, lrAnimationOptions, (this.LRAnimationAllTimer - node.LRAnimationTime)));
                        }
                        break;
                    }
                case NodeContentOrientations.Center:
                    {
                        text_x = node.Rect.X + (node.Rect.Width - text_size.Width) / 2f;
                        break;
                    }
                case NodeContentOrientations.Right:
                    {
                        int fold_image_w = (this.Menu.FoldImageShow && this.Menu.FoldImageOrientation == NodeImageOrientations.Right) ? this.Menu.FoldImageSize.Width + this.Menu.FoldImagePaddingLeft + this.Menu.FoldImagePaddingRight : 0;
                        int image_w = 0;
                        if (node.ItemType == NodeTypes.Menu)
                        {
                            if (this.Menu.ImageShow && ((this.Menu.ContentOrientation != NodeContentOrientations.Right && this.Menu.ContentOrientation != NodeContentOrientations.Right) || (this.Menu.ContentOrientation == NodeContentOrientations.Right && this.Menu.ContentOrientation == NodeContentOrientations.Right)))
                            {
                                image_w = this.Menu.ImageSize.Width + this.NodeImagePaddingLeft + this.NodeImagePaddingRight;
                            }
                        }
                        else
                        {
                            if (this.MenuTab.ImageShow && ((this.MenuTab.ContentOrientation != NodeContentOrientations.Right && this.MenuTab.ContentOrientation != NodeContentOrientations.Right) || (this.MenuTab.ContentOrientation == NodeContentOrientations.Right && this.MenuTab.ContentOrientation == NodeContentOrientations.Right)))
                            {
                                image_w = this.MenuTab.ImageSize.Width + this.NodeImagePaddingLeft + this.NodeImagePaddingRight;
                            }
                        }

                        if (node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreed)
                        {
                            text_x = node.Rect.Right - fold_image_w - image_w - this.NodeTextPaddingRight - text_size.Width;
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Slideed)
                        {
                            text_x = node.Rect.Right - fold_image_w - image_w - this.NodeTextPaddingRight - text_size.Width - this.NodeLRDistance;
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Slideing)
                        {
                            text_x = node.Rect.Right - fold_image_w - image_w - this.NodeTextPaddingRight - text_size.Width - (float)(this.NodeLRDistance * AnimationTimer.GetProgress(AnimationTypes.EaseOut, lrAnimationOptions, node.LRAnimationTime));
                        }
                        else if (node.LRAnimationStatus == NodeLRAnimationStatuss.Restoreing)
                        {
                            text_x = node.Rect.Right - fold_image_w - image_w - this.NodeTextPaddingRight - text_size.Width - (float)(this.NodeLRDistance * AnimationTimer.GetProgress(AnimationTypes.EaseOut, lrAnimationOptions, (this.LRAnimationAllTimer - node.LRAnimationTime)));
                        }
                        break;
                    }
            }
            RectangleF text_rect = new RectangleF(text_x, node.Rect.Y + (node.Rect.Height - text_size.Height) / 2f, text_size.Width, text_size.Height);
            g.DrawString(node.Text, this.Font, commom_text_sb, text_rect);

            #endregion

            #region 节点图片
            if (node.ItemType == NodeTypes.Menu)
            {
                Image image = node.Image != null ? node.Image : this.Menu.Image;
                if (this.Menu.ImageShow && image != null)
                {
                    Rectangle image_rect = new Rectangle((int)(text_rect.X - this.Menu.ImageSize.Width - this.NodeTextPaddingLeft - this.NodeImagePaddingRight), (int)(node.Rect.Y + (node.Rect.Height - this.Menu.ImageSize.Height) / 2), this.Menu.ImageSize.Width, this.Menu.ImageSize.Height);
                    if (this.Menu.ContentOrientation == NodeContentOrientations.Right)
                    {
                        image_rect = new Rectangle((int)(text_rect.Right + this.NodeTextPaddingLeft), (int)(node.Rect.Y + (node.Rect.Height - this.Menu.ImageSize.Height) / 2), this.Menu.ImageSize.Width, this.Menu.ImageSize.Height);
                    }
                    g.DrawImage(image, image_rect);
                }
            }
            else
            {
                Image image = node.Image != null ? node.Image : this.MenuTab.Image;
                if (this.MenuTab.ImageShow && image != null)
                {
                    Rectangle image_rect = new Rectangle((int)(text_rect.X - this.MenuTab.ImageSize.Width - this.NodeTextPaddingLeft - this.NodeImagePaddingRight), (int)(node.Rect.Y + (node.Rect.Height - this.MenuTab.ImageSize.Height) / 2), this.MenuTab.ImageSize.Width, this.MenuTab.ImageSize.Height);
                    if (this.Menu.ContentOrientation == NodeContentOrientations.Right)
                    {
                        image_rect = new Rectangle((int)(text_rect.Right + this.NodeTextPaddingLeft), (int)(node.Rect.Y + (node.Rect.Height - this.MenuTab.ImageSize.Height) / 2), this.MenuTab.ImageSize.Width, this.MenuTab.ImageSize.Height);
                    }
                    g.DrawImage(image, image_rect);
                }
            }

            #endregion

            #region 节点展开折叠图片

            if (this.Menu.FoldImageShow && node.ItemType == NodeTypes.Menu)
            {
                Rectangle image_rect = new Rectangle((int)(node.Rect.Right - this.Menu.FoldImageSize.Width - this.Menu.FoldImagePaddingRight), (int)(node.Rect.Y + (node.Rect.Height - this.Menu.FoldImageSize.Height) / 2), this.Menu.FoldImageSize.Width, this.Menu.FoldImageSize.Height);
                if (this.Menu.FoldImageOrientation == NodeImageOrientations.Left)
                {
                    image_rect = new Rectangle((int)(node.Rect.X + this.Menu.FoldImagePaddingLeft), (int)(node.Rect.Y + (node.Rect.Height - this.Menu.FoldImageSize.Height) / 2), this.Menu.FoldImageSize.Width, this.Menu.FoldImageSize.Height);
                }
                if (node.ECAnimationStatus == NodeECAnimationStatuss.Expanded)
                {
                    if (this.Menu.FoldImageExpand != null)
                    {
                        g.DrawImage(this.Menu.FoldImageExpand, image_rect);
                    }
                }
                else
                {
                    if (this.Menu.FoldImageCollapse != null)
                    {
                        g.DrawImage(this.Menu.FoldImageCollapse, image_rect);
                    }
                }
            }

            #endregion

            #region 自定义节点绘制事件
            this.OnDrawNode(new DrawNodeEventArgs() { Node = node, TextRect = text_rect, g = g });
            #endregion

            #region 节点边框

            if (this.NodeBorderShow)
            {
                if (this.NodeBorderStyle == NodeBorderStyles.AroundBorder)
                {
                    g.DrawRectangle(nodeborder_pen, node.Rect.X, node.Rect.Y, node.Rect.Width - 1, node.Rect.Height);
                }
                else
                {
                    if (node.ItemType == NodeTypes.Menu)
                    {
                        if (node.ECAnimationStatus == NodeECAnimationStatuss.Collapseed || node.Children.Count < 1)
                        {
                            g.DrawLine(nodeborder_pen, node.Rect.X, node.Rect.Bottom - 1, node.Rect.Right, node.Rect.Bottom - 1);
                        }
                    }
                    else
                    {
                        if (node.Parent != null)
                        {
                            int index = node.Parent.Children.IndexOf(node);
                            if (index == node.Parent.Children.Count - 1)
                            {
                                g.DrawLine(nodeborder_pen, node.Rect.X, node.Rect.Bottom - 1, node.Rect.Right, node.Rect.Bottom - 1);
                            }
                        }
                    }
                }
            }

            #endregion
        }

        #endregion

        #region 动画

        /// <summary>
        /// 动画进行中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTimer_Tick(object sender, EventArgs e)
        {
            #region 左右滑动
            for (int i = 0; i < this.lrAnimationList.Count; i++)
            {
                this.lrAnimationList[i].LRAnimationTime += this.intervalTimer.Interval;
                if (lrAnimationList[i].LRAnimationTime > this.LRAnimationAllTimer)
                {
                    this.lrAnimationList[i].LRAnimationTime = LRAnimationAllTimer;
                }
                this.Invalidate();
                if (lrAnimationList[i].LRAnimationTime == LRAnimationAllTimer)
                {
                    if (lrAnimationList[i].LRAnimationStatus == NodeLRAnimationStatuss.Slideing)
                    {
                        this.lrAnimationList[i].LRAnimationStatus = NodeLRAnimationStatuss.Slideed;
                        this.lrAnimationList[i].LRAnimationTime = 0;
                        this.IntervalTimerStop();
                    }
                    else if (lrAnimationList[i].LRAnimationStatus == NodeLRAnimationStatuss.Restoreing)
                    {
                        this.lrAnimationList[i].LRAnimationStatus = NodeLRAnimationStatuss.Restoreed;
                        this.lrAnimationList[i].LRAnimationTime = 0;
                        this.IntervalTimerStop();
                    }
                }
            }

            List<Node> lrAnimationList_tmp = new List<Node>();

            for (int i = 0; i < this.lrAnimationList.Count; i++)
            {
                if (this.lrAnimationList[i].LRAnimationStatus == NodeLRAnimationStatuss.Slideing || this.lrAnimationList[i].LRAnimationStatus == NodeLRAnimationStatuss.Restoreing)
                {
                    lrAnimationList_tmp.Add(this.lrAnimationList[i]);
                }
            }
            this.lrAnimationList = lrAnimationList_tmp;

            #endregion

            #region  展开折叠

            for (int i = 0; i < this.ecAnimationList.Count; i++)
            {
                if (ecAnimationList[i].ECAnimationStatus == NodeECAnimationStatuss.Expanding)
                {
                    ecAnimationList[i].ECAnimationTime += this.intervalTimer.Interval;
                    if (ecAnimationList[i].ECAnimationTime > this.ECAnimationAllTimer)
                    {
                        ecAnimationList[i].ECAnimationTime = ECAnimationAllTimer;
                    }


                    if (ecAnimationList[i].ECAnimationTime == ECAnimationAllTimer)
                    {
                        ecAnimationList[i].ECAnimationStatus = NodeECAnimationStatuss.Expanded;
                        ecAnimationList[i].ECAnimationTime = 0;
                        this.IntervalTimerStop();
                    }
                }
                else if (ecAnimationList[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseing)
                {
                    ecAnimationList[i].ECAnimationTime -= this.intervalTimer.Interval;
                    if (ecAnimationList[i].ECAnimationTime < 0)
                    {
                        ecAnimationList[i].ECAnimationTime = 0;
                    }

                    if (ecAnimationList[i].ECAnimationTime == 0)
                    {
                        ecAnimationList[i].ECAnimationStatus = NodeECAnimationStatuss.Collapseed;
                        ecAnimationList[i].ECAnimationTime = 0;
                        this.IntervalTimerStop();
                    }
                }

            }

            List<Node> ecAnimationList_tmp = new List<Node>();
            if (this.ecAnimationList.Count > 0)
            {
                this.UpdateAllNodeContainerHeight();
                this.UpdateRealityMenuAndAllNodeRect();
                this.Invalidate();
            }

            for (int i = 0; i < this.ecAnimationList.Count; i++)
            {
                if (this.ecAnimationList[i].ECAnimationStatus == NodeECAnimationStatuss.Expanding || this.ecAnimationList[i].ECAnimationStatus == NodeECAnimationStatuss.Collapseing)
                {
                    ecAnimationList_tmp.Add(this.ecAnimationList[i]);
                }
            }
            this.ecAnimationList = ecAnimationList_tmp;



            #endregion
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        ///节点集合
        /// </summary>
        [Description("节点集合")]
        public sealed class NodeCollection : IList, ICollection, IEnumerable
        {
            private Node ownerNode = null;

            private ArrayList nodeList = new ArrayList();

            public NodeCollection(Node ownerNode)
            {
                this.ownerNode = ownerNode;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                Node[] listArray = new Node[this.nodeList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (Node)this.nodeList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.nodeList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.nodeList.Count;
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
                if (!(value is Node))
                {
                    throw new ArgumentException("Node");
                }
                return this.Add((Node)value);
            }

            public int Add(Node item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                if (this.ownerNode != null)
                {
                    this.ownerNode.ItemType = NodeTypes.Menu;
                }
                item.Parent = this.ownerNode;
                this.nodeList.Add(item);
                return this.Count - 1;
            }

            public void Clear()
            {
                this.nodeList.Clear();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is Node)
                {
                    return this.Contains((Node)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is Node)
                {
                    return this.nodeList.IndexOf(item);
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
                if (!(value is Node))
                {
                    throw new ArgumentException("Node");
                }
                this.Remove((Node)value);
            }

            public void Remove(Node item)
            {
                this.nodeList.Remove(item);
            }

            public void RemoveAt(int index)
            {
                this.nodeList.RemoveAt(index);
            }

            public Node this[int index]
            {
                get
                {
                    return (Node)this.nodeList[index];
                }
                set
                {
                    Node node = (Node)value;
                    node.Parent = this.ownerNode;
                    this.nodeList[index] = node;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.nodeList[index];
                }
                set
                {
                    Node node = (Node)value;
                    node.Parent = this.ownerNode;
                    this.nodeList[index] = node;
                }
            }

            #endregion
        }

        /// <summary>
        /// 节点
        /// </summary>
        [Description("节点")]
        public class Node
        {
            public Node(Node parent)
            {
                this.parent = parent;
            }

            private Node parent = null;
            /// <summary>
            /// 父节点
            /// </summary>
            [Description("父节点")]
            [DefaultValue(null)]
            [Browsable(false)]
            public Node Parent
            {
                get { return this.parent; }
                set
                {
                    if (this.parent == value)
                        return;

                    this.parent = value;
                }
            }

            private NodeTypes itemType = NodeTypes.Menu;
            /// <summary>
            /// 节点类型
            /// </summary>
            [Description("节点类型")]
            [DefaultValue(NodeTypes.Menu)]
            [Browsable(false)]
            public NodeTypes ItemType
            {
                get { return this.itemType; }
                set
                {
                    if (this.itemType == value)
                        return;

                    this.itemType = value;
                }
            }

            private bool enabled = true;
            /// <summary>
            /// 节点是否启用
            /// </summary>
            [Description("节点是否启用")]
            [DefaultValue(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                }
            }

            private bool display = true;
            /// <summary>
            /// 节点是否显示
            /// </summary>
            [Description("节点是否启用")]
            [DefaultValue(true)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool Display
            {
                get { return this.display; }
                set
                {
                    if (this.display == value)
                        return;

                    this.display = value;
                }
            }

            private NodeMouseStatuss mouseStatus = NodeMouseStatuss.Normal;
            /// <summary>
            /// 节点鼠标状态
            /// </summary>
            [Description("节点鼠标状态")]
            [DefaultValue(NodeMouseStatuss.Normal)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public NodeMouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            /// <summary>
            /// 节点是否展开
            /// </summary>
            [Description("节点是否展开")]
            public bool Expand
            {
                get
                {
                    return (this.ECAnimationStatus == NodeECAnimationStatuss.Expanded || this.ECAnimationStatus == NodeECAnimationStatuss.Expanding);
                }
                set
                {
                    if (value == true)
                    {
                        this.ECAnimationStatus = NodeECAnimationStatuss.Expanded;
                    }
                    else
                    {
                        this.ECAnimationStatus = NodeECAnimationStatuss.Collapseed;
                    }
                }
            }

            private bool selected = false;
            /// <summary>
            /// 节点是否选中
            /// </summary>
            [Description("节点是否选中")]
            [DefaultValue(false)]
            public bool Selected
            {
                get { return this.selected; }
                set
                {
                    if (this.selected == value)
                        return;

                    this.selected = value;
                }
            }

            private string text = "";
            /// <summary>
            /// 节点文本
            /// </summary>
            [Description("节点文本")]
            [DefaultValue("")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;

                    this.text = value;
                }
            }

            private object data = null;
            /// <summary>
            /// 节点自定义数据
            /// </summary>
            [Description("节点自定义数据")]
            public object Data
            {
                get { return this.data; }
                set
                {
                    this.data = value;
                }
            }

            private Image image = null;
            /// <summary>
            /// 菜单图片
            /// </summary>
            [Description("菜单图片")]
            [DefaultValue(null)]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;

                    this.image = value;
                }
            }

            private int level = 0;
            /// <summary>
            /// 节点深度
            /// </summary>
            [Description("节点深度")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int Level
            {
                get { return this.level; }
                set
                {
                    if (this.level == value)
                        return;

                    this.level = value;
                }
            }

            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 节点Rect
            /// </summary>
            [Description("节点Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private int containerHeight = 0;
            /// <summary>
            /// 节点容器高度
            /// </summary>
            [Description("节点容器高度")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int ContainerHeight
            {
                get { return this.containerHeight; }
                set
                {
                    if (this.containerHeight == value)
                        return;

                    this.containerHeight = value;
                }
            }

            private int containerHeightTmp = 0;
            /// <summary>
            /// 节点非动画展开的容器高度
            /// </summary>
            [Description("节点非动画展开的容器高度")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int ContainerHeightTmp
            {
                get { return this.containerHeightTmp; }
                set
                {
                    if (this.containerHeightTmp == value)
                        return;

                    this.containerHeightTmp = value;
                }
            }

            private NodeCollection menuItemCollection;
            /// <summary>
            /// 子节点集合
            /// </summary>
            [Description("子节点集合")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public NodeCollection Children
            {
                get
                {
                    if (this.menuItemCollection == null)
                        this.menuItemCollection = new NodeCollection(this);
                    return this.menuItemCollection;
                }
            }

            #region 颜色

            private Color normalBackColor = Color.Empty;
            /// <summary>
            /// 节点背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalBackColor
            {
                get { return this.normalBackColor; }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                }
            }

            private Color normalTextColor = Color.Empty;
            /// <summary>
            /// 节点文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color NormalTextColor
            {
                get { return this.normalTextColor; }
                set
                {
                    if (this.normalTextColor == value)
                        return;

                    this.normalTextColor = value;
                }
            }

            private Color enterBackColor = Color.Empty;
            /// <summary>
            /// 节点背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                }
            }

            private Color enterTextColor = Color.Empty;
            /// <summary>
            /// 节点文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点文本颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color EnterTextColor
            {
                get { return this.enterTextColor; }
                set
                {
                    if (this.enterTextColor == value)
                        return;

                    this.enterTextColor = value;
                }
            }

            private Color selectedBackColor = Color.Empty;
            /// <summary>
            /// 节点背景颜色（选中）(限于MenuTab类型)
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点背景颜色（选中）(限于MenuTab类型)")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SelectedBackColor
            {
                get { return this.selectedBackColor; }
                set
                {
                    if (this.selectedBackColor == value)
                        return;

                    this.selectedBackColor = value;
                }
            }

            private Color selectedTextColor = Color.Empty;
            /// <summary>
            /// 节点文本颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点文本颜色（选中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color SelectedTextColor
            {
                get { return this.selectedTextColor; }
                set
                {
                    if (this.selectedTextColor == value)
                        return;

                    this.selectedTextColor = value;
                }
            }

            private Color disableBackColor = Color.Empty;
            /// <summary>
            /// 节点背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color DisableBackColor
            {
                get { return this.disableBackColor; }
                set
                {
                    if (this.disableBackColor == value)
                        return;

                    this.disableBackColor = value;
                }
            }

            private Color disableTextColor = Color.Empty;
            /// <summary>
            /// 节点文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "")]
            [Description(" 节点文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color DisableTextColor
            {
                get { return this.disableTextColor; }
                set
                {
                    if (this.disableTextColor == value)
                        return;

                    this.disableTextColor = value;
                }
            }

            #endregion

            private NodeLRAnimationStatuss lRAnimationStatus = NodeLRAnimationStatuss.Restoreed;
            /// <summary>
            /// 节点文本左右动画状态
            /// </summary>
            [Description("节点文本左右动画状态")]
            [DefaultValue(NodeLRAnimationStatuss.Restoreed)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public NodeLRAnimationStatuss LRAnimationStatus
            {
                get { return this.lRAnimationStatus; }
                set
                {
                    if (this.lRAnimationStatus == value)
                        return;

                    this.lRAnimationStatus = value;
                }
            }

            private int lRAnimationTime = 0;
            /// <summary>
            /// 节点文本左右动画已使用时间
            /// </summary>
            [Description("节点文本左右动画已使用时间")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int LRAnimationTime
            {
                get { return this.lRAnimationTime; }
                set
                {
                    if (this.lRAnimationTime == value)
                        return;

                    this.lRAnimationTime = value;
                }
            }

            private NodeECAnimationStatuss eCAnimationStatus = NodeECAnimationStatuss.Expanded;
            /// <summary>
            /// 节点子节展开折叠动画状态
            /// </summary>
            [Description("节点子节展开折叠动画状态")]
            [DefaultValue(NodeECAnimationStatuss.Collapseed)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public NodeECAnimationStatuss ECAnimationStatus
            {
                get { return this.eCAnimationStatus; }
                set
                {
                    if (this.eCAnimationStatus == value)
                        return;

                    this.eCAnimationStatus = value;
                }
            }

            private int eCAnimationTime = 0;
            /// <summary>
            /// 节点子节展开折叠已使用时间
            /// </summary>
            [Description("节点子节展开折叠已使用时间")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int ECAnimationTime
            {
                get { return this.eCAnimationTime; }
                set
                {
                    if (this.eCAnimationTime == value)
                        return;

                    this.eCAnimationTime = value;
                }
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        [TypeConverter(typeof(EmptyConverter))]
        public class NodeMenuClass
        {
            private SlideMenuPanelExt owner = null;

            public NodeMenuClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

            private int height = 35;
            /// <summary>
            ///  菜单高度
            /// </summary>
            [DefaultValue(35)]
            [Description(" 菜单高度")]
            [NotifyParentProperty(true)]
            public int Height
            {
                get { return this.height; }
                set
                {
                    if (this.height == value || value < 0)
                        return;

                    this.height = value;
                    this.owner.UpdateMenuContentRect();
                }
            }

            private NodeContentOrientations contentOrientation = NodeContentOrientations.Left;
            /// <summary>
            /// 菜单内容方位
            /// </summary>
            [DefaultValue(NodeContentOrientations.Left)]
            [Description(" 菜单内容方位")]
            [NotifyParentProperty(true)]
            public NodeContentOrientations ContentOrientation
            {
                get { return this.contentOrientation; }
                set
                {
                    if (this.contentOrientation == value)
                        return;

                    this.contentOrientation = value;
                    this.owner.Invalidate();
                }
            }

            private bool foldImageShow = true;
            /// <summary>
            /// 是否显示折叠图片
            /// </summary>
            [DefaultValue(true)]
            [Description("是否显示折叠图片")]
            [NotifyParentProperty(true)]
            public bool FoldImageShow
            {
                get { return this.foldImageShow; }
                set
                {
                    if (this.foldImageShow == value)
                        return;

                    this.foldImageShow = value;
                    this.owner.Invalidate();
                }
            }

            private Size foldImageSize = new Size(16, 16);
            /// <summary>
            /// 折叠图片Size
            /// </summary>
            [DefaultValue(typeof(Size), "16,16")]
            [Description("折叠图片Size")]
            [NotifyParentProperty(true)]
            public Size FoldImageSize
            {
                get { return this.foldImageSize; }
                set
                {
                    if (this.foldImageSize == value)
                        return;

                    this.foldImageSize = value;
                    this.owner.Invalidate();
                }
            }


            private int foldImagePaddingLeft = 0;
            /// <summary>
            /// 折叠图片左边距
            /// </summary>
            [Description("折叠图片左边距")]
            [DefaultValue(0)]
            [NotifyParentProperty(true)]
            public int FoldImagePaddingLeft
            {
                get { return this.foldImagePaddingLeft; }
                set
                {
                    if (this.foldImagePaddingLeft == value || value < 0)
                        return;

                    this.foldImagePaddingLeft = value;
                    this.owner.Invalidate();
                }
            }

            private int foldImagePaddingRight = 10;
            /// <summary>
            /// 折叠图片右边距
            /// </summary>
            [Description("折叠图片右边距")]
            [DefaultValue(10)]
            [NotifyParentProperty(true)]
            public int FoldImagePaddingRight
            {
                get { return this.foldImagePaddingRight; }
                set
                {
                    if (this.foldImagePaddingRight == value || value < 0)
                        return;

                    this.foldImagePaddingRight = value;
                    this.owner.Invalidate();
                }
            }

            private NodeImageOrientations foldImageOrientation = NodeImageOrientations.Right;
            /// <summary>
            /// 折叠图片方位
            /// </summary>
            [DefaultValue(NodeImageOrientations.Right)]
            [Description("折叠图片方位")]
            [NotifyParentProperty(true)]
            public NodeImageOrientations FoldImageOrientation
            {
                get { return this.foldImageOrientation; }
                set
                {
                    if (this.foldImageOrientation == value)
                        return;

                    this.foldImageOrientation = value;
                    this.owner.Invalidate();
                }
            }

            private Image foldImageExpand = null;
            /// <summary>
            /// 展开图片
            /// </summary>
            [DefaultValue(null)]
            [Description("展开图片")]
            [NotifyParentProperty(true)]
            public Image FoldImageExpand
            {
                get { return this.foldImageExpand; }
                set
                {
                    if (this.foldImageExpand == value)
                        return;

                    this.foldImageExpand = value;
                    this.owner.Invalidate();
                }
            }

            private Image foldImageCollapse = null;
            /// <summary>
            /// 折叠图片
            /// </summary>
            [DefaultValue(null)]
            [Description("折叠图片")]
            [NotifyParentProperty(true)]
            public Image FoldImageCollapse
            {
                get { return this.foldImageCollapse; }
                set
                {
                    if (this.foldImageCollapse == value)
                        return;

                    this.foldImageCollapse = value;
                    this.owner.Invalidate();
                }
            }

            private Image image = null;
            /// <summary>
            /// 菜单图片
            /// </summary>
            [DefaultValue(null)]
            [Description("菜单图片")]
            [NotifyParentProperty(true)]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;

                    this.image = value;
                    this.owner.Invalidate();
                }
            }

            private bool imageShow = true;
            /// <summary>
            /// 是否显示图片
            /// </summary>
            [DefaultValue(true)]
            [Description("是否显示图片")]
            [NotifyParentProperty(true)]
            public bool ImageShow
            {
                get { return this.imageShow; }
                set
                {
                    if (this.imageShow == value)
                        return;

                    this.imageShow = value;
                    this.owner.Invalidate();
                }
            }

            private Size imageSize = new Size(16, 16);
            /// <summary>
            /// 菜单图片Size
            /// </summary>
            [DefaultValue(typeof(Size), "16,16")]
            [Description("菜单图片Size")]
            [NotifyParentProperty(true)]
            public Size ImageSize
            {
                get { return this.imageSize; }
                set
                {
                    if (this.imageSize == value)
                        return;

                    this.imageSize = value;
                    this.owner.Invalidate();
                }
            }

            private Color normalBackColor = Color.FromArgb(189, 208, 188);
            /// <summary>
            /// 菜单背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "189, 208, 188")]
            [Description(" 菜单背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color NormalBackColor
            {
                get { return this.normalBackColor; }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color normalTextColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 菜单文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Description(" 菜单文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color NormalTextColor
            {
                get { return this.normalTextColor; }
                set
                {
                    if (this.normalTextColor == value)
                        return;

                    this.normalTextColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color enterBackColor = Color.FromArgb(176, 197, 175);
            /// <summary>
            /// 菜单背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "176, 197, 175")]
            [Description(" 菜单背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color enterTextColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 菜单文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Description(" 菜单文本颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterTextColor
            {
                get { return this.enterTextColor; }
                set
                {
                    if (this.enterTextColor == value)
                        return;

                    this.enterTextColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color disableBackColor = Color.Empty;
            /// <summary>
            /// 菜单背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "128, 128, 128")]
            [Description(" 菜单背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color DisableBackColor
            {
                get { return this.disableBackColor; }
                set
                {
                    if (this.disableBackColor == value)
                        return;

                    this.disableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color disableTextColor = Color.Empty;
            /// <summary>
            /// 菜单文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "128, 128, 128")]
            [Description(" 菜单文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color DisableTextColor
            {
                get { return this.disableTextColor; }
                set
                {
                    if (this.disableTextColor == value)
                        return;

                    this.disableTextColor = value;
                    this.owner.Invalidate();
                }
            }
        }

        /// <summary>
        /// 选项
        /// </summary>
        [Description("选项")]
        [TypeConverter(typeof(EmptyConverter))]
        public class NodeMenuTabClass
        {
            private SlideMenuPanelExt owner = null;

            public NodeMenuTabClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

            private int height = 30;
            /// <summary>
            /// 选项高度
            /// </summary>
            [DefaultValue(30)]
            [Description("选项高度")]
            public int Height
            {
                get { return this.height; }
                set
                {
                    if (this.height == value || value < 0)
                        return;

                    this.height = value;
                    this.owner.UpdateMenuContentRect();
                }
            }

            private NodeContentOrientations contentOrientation = NodeContentOrientations.Left;
            /// <summary>
            /// 选项内容方位
            /// </summary>
            [DefaultValue(NodeContentOrientations.Left)]
            [Description("选项内容方位")]
            [NotifyParentProperty(true)]
            public NodeContentOrientations ContentOrientation
            {
                get { return this.contentOrientation; }
                set
                {
                    if (this.contentOrientation == value)
                        return;

                    this.contentOrientation = value;
                    this.owner.Invalidate();
                }
            }

            private Image image = null;
            /// <summary>
            /// 选项图片
            /// </summary>
            [DefaultValue(null)]
            [Description("选项图片")]
            [NotifyParentProperty(true)]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;

                    this.image = value;
                    this.owner.Invalidate();
                }
            }

            private bool imageShow = true;
            /// <summary>
            /// 是否显示图片
            /// </summary>
            [DefaultValue(true)]
            [Description("是否显示图片")]
            [NotifyParentProperty(true)]
            public bool ImageShow
            {
                get { return this.imageShow; }
                set
                {
                    if (this.imageShow == value)
                        return;

                    this.imageShow = value;
                    this.owner.Invalidate();
                }
            }
            private Size imageSize = new Size(16, 16);
            /// <summary>
            /// 选项图片Size
            /// </summary>
            [DefaultValue(typeof(Size), "16,16")]
            [Description("选项图片Size")]
            [NotifyParentProperty(true)]
            public Size ImageSize
            {
                get { return this.imageSize; }
                set
                {
                    if (this.imageSize == value)
                        return;

                    this.imageSize = value;
                    this.owner.Invalidate();
                }
            }

            private Color normalBackColor = Color.FromArgb(168, 128, 187);
            /// <summary>
            /// 选项背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "168, 128, 187")]
            [Description(" 选项背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color NormalBackColor
            {
                get { return this.normalBackColor; }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color normalTextColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 选项文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Description(" 选项文本颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color NormalTextColor
            {
                get { return this.normalTextColor; }
                set
                {
                    if (this.normalTextColor == value)
                        return;

                    this.normalTextColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color enterBackColor = Color.FromArgb(137, 101, 154);
            /// <summary>
            /// 选项背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "137, 101, 154")]
            [Description(" 选项背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color enterTextColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 选项文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Description(" 选项文本颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterTextColor
            {
                get { return this.enterTextColor; }
                set
                {
                    if (this.enterTextColor == value)
                        return;

                    this.enterTextColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color selectedBackColor = Color.FromArgb(137, 101, 154);
            /// <summary>
            /// 选项背景颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "137, 101, 154")]
            [Description(" 选项背景颜色（选中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SelectedBackColor
            {
                get { return this.selectedBackColor; }
                set
                {
                    if (this.selectedBackColor == value)
                        return;

                    this.selectedBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color selectedTextColor = Color.FromArgb(255, 255, 255);
            /// <summary>
            /// 选项文本颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "255, 255, 255")]
            [Description(" 选项文本颜色（选中）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SelectedTextColor
            {
                get { return this.selectedTextColor; }
                set
                {
                    if (this.selectedTextColor == value)
                        return;

                    this.selectedTextColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color disableBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "128, 128, 128")]
            [Description(" 选项背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color DisableBackColor
            {
                get { return this.disableBackColor; }
                set
                {
                    if (this.disableBackColor == value)
                        return;

                    this.disableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color disableTextColor = Color.Empty;
            /// <summary>
            /// 选项文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "128, 128, 128")]
            [Description("选项文本颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color DisableTextColor
            {
                get { return this.disableTextColor; }
                set
                {
                    if (this.disableTextColor == value)
                        return;

                    this.disableTextColor = value;
                    this.owner.Invalidate();
                }
            }

        }

        /// <summary>
        /// 滚动条
        /// </summary>
        [Description("滚动条")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ScrollClass
        {
            #region 字段

            private SlideMenuPanelExt owner = null;

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
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private bool auto = false;
            /// <summary>
            /// 滑条是否自动显示
            /// </summary>
            [DefaultValue(false)]
            [Description("滑条是否自动显示")]
            [NotifyParentProperty(true)]
            public bool Auto
            {
                get { return this.auto; }
                set
                {
                    if (this.auto == value)
                        return;

                    this.auto = value;
                    this.owner.Invalidate();
                }
            }

            private int thickness = 10;
            /// <summary>
            /// 滑条厚度
            /// </summary>
            [DefaultValue(10)]
            [Description("滑条厚度")]
            [NotifyParentProperty(true)]
            public int Thickness
            {
                get { return this.thickness; }
                set
                {
                    if (this.thickness == value || value < 0)
                        return;

                    this.thickness = value;
                    this.owner.InitializeScrollRectangle();
                    this.owner.Invalidate();
                }
            }

            #region 滑条

            private Color barNormalBackColor = Color.FromArgb(68, 128, 128, 128);
            /// <summary>
            /// 滑条背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "68, 128, 128, 128")]
            [Description("滑条背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BarNormalBackColor
            {
                get { return this.barNormalBackColor; }
                set
                {
                    if (this.barNormalBackColor == value)
                        return;

                    this.barNormalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color barDisableBackColor = Color.FromArgb(224, 224, 224);
            /// <summary>
            /// 滑条背景颜色（禁止）
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "224, 224, 224")]
            [Description("滑条背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BarDisableBackColor
            {
                get { return this.barDisableBackColor; }
                set
                {
                    if (this.barDisableBackColor == value)
                        return;

                    this.barDisableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            #endregion

            #region 滑块

            private bool slideRadius = false;
            /// <summary>
            /// 背景是否为圆角
            /// </summary>
            [DefaultValue(false)]
            [Description("背景是否为圆角")]
            [NotifyParentProperty(true)]
            public bool SlideRadius
            {
                get { return this.slideRadius; }
                set
                {
                    if (this.slideRadius == value)
                        return;

                    this.slideRadius = value;
                    this.owner.Invalidate();
                }
            }

            private int slideMinHeight = 26;
            /// <summary>
            /// 滑块最小高度
            /// </summary>
            [DefaultValue(26)]
            [Description("滑块最小高度")]
            [NotifyParentProperty(true)]
            public int SlideMinHeight
            {
                get { return this.slideMinHeight; }
                set
                {
                    if (this.slideMinHeight == value || value < 1)
                        return;
                    this.slideMinHeight = value;

                    this.owner.Invalidate();
                }
            }

            private Color slideNormalBackColor = Color.FromArgb(120, 64, 64, 64);
            /// <summary>
            /// 滑块背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "120, 64, 64, 64")]
            [Description("滑块背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideNormalBackColor
            {
                get { return this.slideNormalBackColor; }
                set
                {
                    if (this.slideNormalBackColor == value)
                        return;

                    this.slideNormalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color slideEnterBackColor = Color.FromArgb(160, 64, 64, 64);
            /// <summary>
            /// 滑块背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "160,64, 64, 64")]
            [Description("滑块背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideEnterBackColor
            {
                get { return this.slideEnterBackColor; }
                set
                {
                    if (this.slideEnterBackColor == value)
                        return;

                    this.slideEnterBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color slideDisableBackColor = Color.FromArgb(192, 192, 192);
            /// <summary>
            /// 滑块背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "192, 192, 192")]
            [Description("滑块背景颜色（禁止）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color SlideDisableBackColor
            {
                get { return this.slideDisableBackColor; }
                set
                {
                    if (this.slideDisableBackColor == value)
                        return;

                    this.slideDisableBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private RectangleF slideRect = RectangleF.Empty;
            /// <summary>
            /// 滑块rect
            /// </summary>
            [Description("滑块rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF SlideRect
            {
                get { return this.slideRect; }
                set { this.slideRect = value; }
            }

            private ScrollSlideMoveStatus slideStatus = ScrollSlideMoveStatus.Normal;
            /// <summary>
            /// 滑块鼠标状态
            /// </summary>
            [Browsable(false)]
            [Description("滑块鼠标状态")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ScrollSlideMoveStatus SlideStatus
            {
                get { return this.slideStatus; }
                set { this.slideStatus = value; }
            }
            #endregion

            #endregion

            public ScrollClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

        }

        /// <summary>
        /// 拖载条
        /// </summary>
        [Description("拖载条")]
        [TypeConverter(typeof(EmptyConverter))]
        public class DragClass
        {
            #region 事件

            private event EventHandler click;
            /// <summary>
            /// 单击事件
            /// </summary>
            [Description("单击事件")]
            public event EventHandler Click
            {
                add { this.click += value; }
                remove { this.click -= value; }
            }

            public delegate void DragingEventHandler(object sender, DragingEventArgs e);

            private event DragingEventHandler draging;
            /// <summary>
            /// 拖动中事件
            /// </summary>
            [Description("拖动中事件")]
            public event DragingEventHandler Draging
            {
                add { this.draging += value; }
                remove { this.draging -= value; }
            }

            private event DragingEventHandler draged;
            /// <summary>
            /// 拖动完成事件
            /// </summary>
            [Description("拖动完成事件")]
            public event DragingEventHandler Draged
            {
                add { this.draged += value; }
                remove { this.draged -= value; }
            }

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用
            /// </summary>
            [Description("是否启用")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private int width = 5;
            /// <summary>
            /// 拖载条宽度
            /// </summary>
            [Description("拖载条宽度")]
            [DefaultValue(5)]
            public int Width
            {
                get { return this.width; }
                set
                {
                    if (this.width == value || value < 0)
                        return;

                    this.width = value;

                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 按钮Rect
            /// </summary>
            [Description("按钮Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private Color backColor = Color.FromArgb(100, 176, 197, 175);
            /// <summary>
            /// 背景颜色
            /// </summary>
            [DefaultValue(typeof(Color), "100, 176, 197, 175")]
            [Description("背景颜色")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BackColor
            {
                get { return this.backColor; }
                set
                {
                    if (this.backColor == value)
                        return;

                    this.backColor = value;
                    this.owner.Invalidate();
                }
            }

            #endregion

            #region 字段

            private SlideMenuPanelExt owner = null;

            #endregion

            public DragClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

            #region  虚方法

            public virtual void OnClick(EventArgs e)
            {
                if (this.click != null)
                {
                    this.click(this, e);
                }
            }

            public virtual void OnDraging(DragingEventArgs e)
            {
                if (this.draging != null)
                {
                    this.draging(this, e);
                }
            }

            public virtual void OnDraged(DragingEventArgs e)
            {
                if (this.draged != null)
                {
                    this.draged(this, e);
                }
            }
            #endregion

        }

        /// <summary>
        /// 工具栏
        /// </summary>
        [Description("工具栏")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ToolClass
        {
            #region 字段
            private SlideMenuPanelExt owner = null;
            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用
            /// </summary>
            [Description("是否启用")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

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
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private int buttonHeight = 20;
            /// <summary>
            /// 工具栏高度
            /// </summary>
            [Description("工具栏高度")]
            [DefaultValue(20)]
            [NotifyParentProperty(true)]
            public int ButtonHeight
            {
                get { return this.buttonHeight; }
                set
                {
                    if (this.buttonHeight == value || value < 0)
                        return;

                    this.buttonHeight = value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private bool search = true;
            /// <summary>
            /// 是否启用过滤功能
            /// </summary>
            [Description("是否启用过滤功能")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool Search
            {
                get { return this.search; }
                set
                {
                    if (this.search == value)
                        return;

                    this.search = value;
                    if (this.search)
                    {
                        this.owner.Controls.Add(this.searchText);
                    }
                    else
                    {
                        this.owner.Controls.Remove(this.searchText);
                    }
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private bool searchLetterLower = true;
            /// <summary>
            /// 过滤功能是否识别大小写
            /// </summary>
            [Description("过滤功能是否识别大小写")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool SearchLetterLower
            {
                get { return this.searchLetterLower; }
                set
                {
                    if (this.searchLetterLower == value)
                        return;

                    this.searchLetterLower = value;
                }
            }

            private int searchHeight = 24;
            /// <summary>
            /// 工具栏过滤功能高度
            /// </summary>
            [Description("工具栏过滤功能高度")]
            [DefaultValue(24)]
            [NotifyParentProperty(true)]
            public int SearchHeight
            {
                get { return this.searchHeight; }
                set
                {
                    if (this.searchHeight == value || value < 0)
                        return;

                    this.searchHeight = value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private TextBox searchText;
            /// <summary>
            /// 过滤输入框
            /// </summary>
            [Description("过滤输入框")]
            [Browsable(false)]
            [NotifyParentProperty(true)]
            public TextBox SearchText
            {
                get { return this.searchText; }
            }

            private ToolButtonClass searchClearBtn;
            /// <summary>
            /// 过滤清空按钮
            /// </summary>
            [Description("过滤清空按钮")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolButtonClass SearchClearBtn
            {
                get { return this.searchClearBtn; }
                set
                {
                    if (this.searchClearBtn == value)
                        return;

                    this.searchClearBtn = value;
                }
            }


            private ToolButtonClass allCollapseBtn;
            /// <summary>
            /// 折叠所有节点
            /// </summary>
            [Description("折叠所有节点")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolButtonClass AllCollapseBtn
            {
                get { return this.allCollapseBtn; }
                set
                {
                    if (this.allCollapseBtn == value)
                        return;

                    this.allCollapseBtn = value;
                }
            }

            private ToolButtonClass allExpandBtn;
            /// <summary>
            /// 展开所有节点
            /// </summary>
            [Description("展开所有节点")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolButtonClass AllExpandBtn
            {
                get { return this.allExpandBtn; }
                set
                {
                    if (this.allExpandBtn == value)
                        return;

                    this.allExpandBtn = value;
                }
            }

            private ToolButtonClass firstExpandBtn;
            /// <summary>
            /// 展开等级为0的节点
            /// </summary>
            [Description("展开等级为0的节点")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolButtonClass FirstExpandBtn
            {
                get { return this.firstExpandBtn; }
                set
                {
                    if (this.firstExpandBtn == value)
                        return;

                    this.firstExpandBtn = value;
                }
            }

            private ToolCheckButtonClass fixedBtn;
            /// <summary>
            /// 固定按钮
            /// </summary>
            [Description("固定按钮")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolCheckButtonClass FixedBtn
            {
                get { return this.fixedBtn; }
                set
                {
                    if (this.fixedBtn == value)
                        return;

                    this.fixedBtn = value;
                }
            }

            private ToolButtonClass minBtn;
            /// <summary>
            /// 最小化按钮
            /// </summary>
            [Description("最小化按钮")]
            [NotifyParentProperty(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ToolButtonClass MinBtn
            {
                get { return this.minBtn; }
                set
                {
                    if (this.minBtn == value)
                        return;

                    this.minBtn = value;
                }
            }

            private Color backColor = Color.FromArgb(176, 197, 175);
            /// <summary>
            /// 背景颜色
            /// </summary>
            [DefaultValue(typeof(Color), "176, 197, 175")]
            [Description("背景颜色")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color BackColor
            {
                get { return this.backColor; }
                set
                {
                    if (this.backColor == value)
                        return;

                    this.backColor = value;
                    this.owner.Invalidate();
                }
            }

            #endregion

            public ToolClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
                this.allCollapseBtn = new ToolButtonClass(this.owner);
                this.allExpandBtn = new ToolButtonClass(this.owner);
                this.firstExpandBtn = new ToolButtonClass(this.owner);
                this.fixedBtn = new ToolCheckButtonClass(this.owner);
                this.minBtn = new ToolButtonClass(this.owner);
                this.searchText = new TextBox() { BorderStyle = BorderStyle.None };
                this.searchText.TabStop = false;
                this.searchText.AutoSize = false;
                this.searchText.Font = new Font("宋体", 11);
                this.searchText.ForeColor = Color.FromArgb(102, 102, 102);
                this.searchText.TextChanged += this.SearchText_TextChanged;
                this.searchClearBtn = new ToolButtonClass(this.owner);

                if (this.search)
                {
                    this.owner.Controls.Add(this.searchText);
                }
                else
                {
                    this.owner.Controls.Remove(this.searchText);
                }
            }

            #region 私有方法

            private void SearchText_TextChanged(object sender, EventArgs e)
            {
                string text = this.SearchText.Text.Trim();
                if (text == "")
                {
                    this.owner.GiveupFilter();
                }
                else
                {
                    this.owner.FilterByText(text);
                }
            }

            #endregion

        }

        /// <summary>
        /// 工具栏按钮
        /// </summary>
        [Description("工具栏按钮")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ToolButtonClass
        {
            #region 事件

            private event EventHandler click;
            /// <summary>
            /// 单击事件
            /// </summary>
            [Description("单击事件")]
            public event EventHandler Click
            {
                add { this.click += value; }
                remove { this.click -= value; }
            }

            #endregion

            #region 字段

            private SlideMenuPanelExt owner = null;

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用
            /// </summary>
            [Description("是否启用")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    if (this.owner != null)
                    {
                        this.owner.InitializeRectangle();
                        this.owner.Invalidate();
                    }
                }
            }

            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 按钮Rect
            /// </summary>
            [Description("按钮Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private Image image = null;
            /// <summary>
            /// 按钮图片
            /// </summary>
            [DefaultValue(null)]
            [Localizable(true)]
            [Description(" 按钮图片")]
            [NotifyParentProperty(true)]
            public Image Image
            {
                get { return this.image; }
                set
                {
                    if (this.image == value)
                        return;

                    this.image = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            private NodeMouseStatuss mouseStatus = NodeMouseStatuss.Normal;
            /// <summary>
            /// 按钮鼠标状态
            /// </summary>
            [Description("按钮鼠标状态")]
            [DefaultValue(NodeMouseStatuss.Normal)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public NodeMouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            private Color enterBackColor = Color.FromArgb(100, 64, 64, 64);
            /// <summary>
            /// 按钮背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "100, 64, 64, 64")]
            [Description(" 按钮背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                    if (this.owner != null)
                    {
                        this.owner.Invalidate();
                    }
                }
            }

            #endregion

            public ToolButtonClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

            #region  虚方法

            public virtual void OnClick(EventArgs e)
            {
                if (this.click != null)
                {
                    this.click(this, e);
                }
            }

            #endregion
        }

        /// <summary>
        /// 工具栏状态按钮
        /// </summary>
        [Description("工具栏状态按钮")]
        [TypeConverter(typeof(EmptyConverter))]
        public class ToolCheckButtonClass
        {
            #region 事件

            private event EventHandler click;
            /// <summary>
            /// 单击事件
            /// </summary>
            [Description("单击事件")]
            public event EventHandler Click
            {
                add { this.click += value; }
                remove { this.click -= value; }
            }

            #endregion

            #region 属性

            private bool enabled = true;
            /// <summary>
            /// 是否启用
            /// </summary>
            [Description("是否启用")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool Enabled
            {
                get { return this.enabled; }
                set
                {
                    if (this.enabled == value)
                        return;

                    this.enabled = value;
                    this.owner.InitializeRectangle();
                    this.owner.Invalidate();
                }
            }

            private RectangleF rect = RectangleF.Empty;
            /// <summary>
            /// 按钮Rect
            /// </summary>
            [Description("按钮Rect")]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [NotifyParentProperty(true)]
            public RectangleF Rect
            {
                get { return this.rect; }
                set
                {
                    if (this.rect == value)
                        return;

                    this.rect = value;
                }
            }

            private bool buttonChecked = true;
            /// <summary>
            /// 按钮状态
            /// </summary>
            [Description("按钮状态")]
            [DefaultValue(true)]
            [NotifyParentProperty(true)]
            public bool ButtonChecked
            {
                get { return this.buttonChecked; }
                set
                {
                    if (this.buttonChecked == value)
                        return;

                    this.buttonChecked = value;
                    this.owner.Invalidate();
                }
            }

            private Image uncheckImage = null;
            /// <summary>
            /// 按钮图片（正常）
            /// </summary>
            [DefaultValue(null)]
            [Localizable(true)]
            [Description(" 按钮图片（正常）")]
            [NotifyParentProperty(true)]
            public Image UncheckImage
            {
                get { return this.uncheckImage; }
                set
                {
                    if (this.uncheckImage == value)
                        return;

                    this.uncheckImage = value;
                    this.owner.Invalidate();
                }
            }

            private Image checkImage = null;
            /// <summary>
            /// 按钮图片（选中）
            /// </summary>
            [DefaultValue(null)]
            [Localizable(true)]
            [Description(" 按钮图片（选中）")]
            [NotifyParentProperty(true)]
            public Image CheckImage
            {
                get { return this.checkImage; }
                set
                {
                    if (this.checkImage == value)
                        return;

                    this.checkImage = value;
                    this.owner.Invalidate();
                }
            }

            private NodeMouseStatuss mouseStatus = NodeMouseStatuss.Normal;
            /// <summary>
            /// 鼠标状态
            /// </summary>
            [Description("鼠标状态")]
            [DefaultValue(NodeMouseStatuss.Normal)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [NotifyParentProperty(true)]
            public NodeMouseStatuss MouseStatus
            {
                get { return this.mouseStatus; }
                set
                {
                    if (this.mouseStatus == value)
                        return;

                    this.mouseStatus = value;
                }
            }

            private Color normalBackColor = Color.FromArgb(189, 208, 188);
            /// <summary>
            /// 按钮背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "189, 208, 188")]
            [Description(" 按钮背景颜色（正常）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color NormalBackColor
            {
                get { return this.normalBackColor; }
                set
                {
                    if (this.normalBackColor == value)
                        return;

                    this.normalBackColor = value;
                    this.owner.Invalidate();
                }
            }

            private Color enterBackColor = Color.FromArgb(100, 64, 64, 64);
            /// <summary>
            /// 按钮背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "100, 64, 64, 64")]
            [Description(" 按钮背景颜色（鼠标进入）")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            [NotifyParentProperty(true)]
            public Color EnterBackColor
            {
                get { return this.enterBackColor; }
                set
                {
                    if (this.enterBackColor == value)
                        return;

                    this.enterBackColor = value;
                    this.owner.Invalidate();
                }
            }

            #endregion

            #region 字段

            private SlideMenuPanelExt owner = null;

            #endregion

            public ToolCheckButtonClass(SlideMenuPanelExt owner)
            {
                this.owner = owner;
            }

            #region  虚方法

            public virtual void OnClick(EventArgs e)
            {
                if (this.click != null)
                {
                    this.click(this, e);
                }
            }

            #endregion
        }

        /// <summary>
        /// 鼠标按下功能类型
        /// </summary>
        [Description("鼠标按下功能类型")]
        public class MouseDownClass
        {
            /// <summary>
            /// 鼠标按下功能类型
            /// </summary>
            [Description("鼠标按下功能类型")]
            public MouseDownTypes Type { get; set; }
            /// <summary>
            /// 鼠标按下功能对象
            /// </summary>
            [Description("鼠标按下功能对象")]
            public object Sender { get; set; }
        }

        /// <summary>
        /// 节点单击事件参数
        /// </summary>
        [Description("节点单击事件参数")]
        public class NodeClickEventArgs : EventArgs
        {
            /// <summary>
            /// 节点
            /// </summary>
            [Description("节点")]
            public Node Node { get; set; }
        }

        /// <summary>
        /// 选中节点更改事件参数
        /// </summary>
        [Description("选中节点更改事件参数")]
        public class SelectedChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 选中节点
            /// </summary>
            [Description("选中节点")]
            public Node Node { get; set; }
        }

        /// <summary>
        /// 拖载条拖动事件参数
        /// </summary>
        [Description("拖载条拖动事件参数")]
        public class DragingEventArgs : EventArgs
        {
            /// <summary>
            /// 拖动值
            /// </summary>
            [Description("拖动值")]
            public int X { get; set; }
        }

        /// <summary>
        /// 拖载条绘制事件参数
        /// </summary>
        [Description("拖载条绘制事件参数")]
        public class DragPaintEventArgs : EventArgs
        {
            /// <summary>
            /// 拖载条Rect
            /// </summary>
            [Description("拖载条Rect")]
            public RectangleF Rect { get; set; }

            /// <summary>
            /// 拖载条Graphics
            /// </summary>
            [Description("拖载条Graphics")]
            public Graphics g { get; set; }
        }

        /// <summary>
        /// 节点绘制绘制事件参数
        /// </summary>
        [Description("节点绘制绘制事件参数")]
        public class DrawNodeEventArgs : EventArgs
        {
            /// <summary>
            /// 当前节点
            /// </summary>
            [Description("当前节点")]
            public Node Node { get; set; }

            /// <summary>
            /// 节点文本Rect
            /// </summary>
            [Description("节点文本Rect")]
            public RectangleF TextRect { get; set; }

            /// <summary>
            /// Graphics
            /// </summary>
            [Description("Graphics")]
            public Graphics g { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 节点边框风格
        /// </summary>
        [Description("节点边框风格")]
        public enum NodeBorderStyles
        {
            /// <summary>
            /// 四周边框
            /// </summary>
            AroundBorder,
            /// <summary>
            /// 底部边框
            /// </summary>
            BottomBorder
        }

        /// <summary>
        /// 鼠标单击类型
        /// </summary>
        [Description("鼠标单击类型")]
        public enum MouseDownTypes
        {
            /// <summary>
            /// 空
            /// </summary>
            None,
            /// <summary>
            /// 工具栏按钮按下
            /// </summary>
            ToolButton,
            /// <summary>
            /// 节点按下
            /// </summary>
            MenuNode,
            /// <summary>
            /// 滚动条按下
            /// </summary>
            Scroll,
            /// <summary>
            /// 拖载条
            /// </summary>
            Drag
        }

        /// <summary>
        /// 节点文本左右动画状态
        /// </summary>
        [Description("节点文本左右动画状态")]
        public enum NodeLRAnimationStatuss
        {
            /// <summary>
            /// 还原中
            /// </summary>
            Restoreing,
            /// <summary>
            /// 原始
            /// </summary>
            Restoreed,
            /// <summary>
            /// 滑动中
            /// </summary>
            Slideing,
            /// <summary>
            /// 已滑动
            /// </summary>
            Slideed
        }

        /// <summary>
        /// 节点子节展开折叠动画状态
        /// </summary>
        [Description("节点子节展开折叠动画状态")]
        public enum NodeECAnimationStatuss
        {
            /// <summary>
            /// 折叠中
            /// </summary>
            Collapseing,
            /// <summary>
            /// 已折叠
            /// </summary>
            Collapseed,
            /// <summary>
            /// 展开中
            /// </summary>
            Expanding,
            /// <summary>
            /// 已展开
            /// </summary>
            Expanded

        }

        /// <summary>
        /// 节点图片方位
        /// </summary>
        [Description("节点图片方位")]
        public enum NodeImageOrientations
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
        /// 节点内容方位
        /// </summary>
        [Description("节点内容方位")]
        public enum NodeContentOrientations
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

        /// <summary>
        /// 节点类型
        /// </summary>
        [Description("节点类型")]
        public enum NodeTypes
        {
            /// <summary>
            /// 子节
            /// </summary>
            Menu,
            /// <summary>
            /// 选项
            /// </summary>
            MenuTab
        }

        /// <summary>
        ///节点鼠标状态
        /// </summary>
        [Description("节点鼠标状态")]
        public enum NodeMouseStatuss
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

        /// <summary>
        /// 滚动条滑块鼠标状态
        /// </summary>
        [Description("滚动条滑块鼠标状态")]
        public enum ScrollSlideMoveStatus
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

        #region test
        //public string getTest(NodeCollection menuList)
        //{
        //    StringBuilder str = new StringBuilder();
        //    for (int i = 0; i < menuList.Count; i++)
        //    {
        //        str.AppendLine(String.Format("name:{0} Display:{7}  containerHeight:{1}  containerHeightTmp:{6}  x:{2}  y:{3}  w:{4}  h:{5}",
        //            menuList[i].Text.PadRight(10, ' '),
        //            menuList[i].ContainerHeight.ToString().PadRight(10, ' '),
        //            menuList[i].Rect.X.ToString().PadRight(5, ' '),
        //            menuList[i].Rect.Y.ToString().PadRight(5, ' '),
        //            menuList[i].Rect.Width.ToString().PadRight(5, ' '),
        //            menuList[i].Rect.Height.ToString().PadRight(5, ' '),
        //            menuList[i].ContainerHeightTmp.ToString().PadRight(5, ' '),
        //            menuList[i].Display.ToString()));

        //        str.AppendLine(getTest(menuList[i].Children));
        //    }
        //    return str.ToString();
        //}
        #endregion

    }
}
