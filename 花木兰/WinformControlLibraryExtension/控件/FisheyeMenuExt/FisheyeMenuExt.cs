
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
    /// 鱼眼菜单(控件版)(废弃)
    /// </summary>
    [ToolboxItem(true)]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    [Description("鱼眼菜单(控件版)(废弃)")]
    [Designer(typeof(FisheyeMenuExtDesigner))]
    public class FisheyeMenuExt : Control
    {
        #region 新增事件

        public delegate void IndexChangedEventHandler(object sender, IndexChangedEventArgs e);

        private event IndexChangedEventHandler indexChanged;
        /// <summary>
        /// 鱼眼菜单选项选中索引更改事件
        /// </summary>
        [Description("鱼眼菜单选项选中索引更改事件")]
        public event IndexChangedEventHandler IndexChanged
        {
            add { this.indexChanged += value; }
            remove { this.indexChanged -= value; }
        }

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);

        private event ItemClickEventHandler itemClick;
        /// <summary>
        /// 鱼眼菜单选项单击事件
        /// </summary>
        [Description("鱼眼菜单选项单击事件")]
        public event ItemClickEventHandler ItemClick
        {
            add { this.itemClick += value; }
            remove { this.itemClick -= value; }
        }

        public delegate void ItemUpClickEventHandler(object sender, ItemUpClickEventArgs e);

        private event ItemUpClickEventHandler itemUpClick;
        /// <summary>
        /// 鱼眼菜单选项光标选中释放事件
        /// </summary>
        [Description("鱼眼菜单选项光标选中释放事件")]
        public event ItemUpClickEventHandler ItemUpClick
        {
            add { this.itemUpClick += value; }
            remove { this.itemUpClick -= value; }
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
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
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

        private FisheyeMenuTypes type = FisheyeMenuTypes.ImageText;
        /// <summary>
        /// 鱼眼菜单类型
        /// </summary>
        [DefaultValue(FisheyeMenuTypes.ImageText)]
        [Description("鱼眼菜单类型")]
        public FisheyeMenuTypes Type
        {
            get { return this.type; }
            set
            {
                if (this.type == value)
                    return;
                this.type = value;
                if (this.Type == FisheyeMenuTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.TransformReflectionImages();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private FisheyeMenuOrientation orientation = FisheyeMenuOrientation.Bottom;
        /// <summary>
        /// 鱼眼菜单方向位置
        /// </summary>
        [DefaultValue(FisheyeMenuOrientation.Bottom)]
        [Description("鱼眼菜单方向位置")]
        public FisheyeMenuOrientation Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation == value)
                    return;
                this.orientation = value;
                if (this.Type == FisheyeMenuTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.TransformReflectionImages();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private float proportion = 0.5f;
        /// <summary>
        /// 鱼眼菜单选项正常状态默认缩放比例( 0<Proportion<1 )
        /// </summary>
        [DefaultValue(0.5f)]
        [Description("鱼眼菜单选项正常状态默认缩放比例( 0<Proportion<1 )")]
        public float Proportion
        {
            get { return this.proportion; }
            set
            {
                if (this.proportion == value || value <= 0 || value >= 1)
                    return;
                this.proportion = value;
                this.ResetFisheyeMenuItemsProportion();
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private int distance = 0;
        /// <summary>
        /// 鱼眼菜单选项间距
        /// </summary>
        [DefaultValue(0)]
        [Description("鱼眼菜单选项间距")]
        public int Distance
        {
            get { return this.distance; }
            set
            {
                if (this.distance == value || value < 0)
                    return;
                this.distance = value;
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private Color borderActivateColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 激活控件激活虚线边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("激活控件激活虚线边框颜色")]
        public Color BorderActivateColor
        {
            get { return this.borderActivateColor; }
            set
            {
                if (this.borderActivateColor == value)
                    return;
                this.borderActivateColor = value;
                this.Invalidate();
            }
        }

        private int itemWidth = 128;
        /// <summary>
        /// 选项宽度
        /// </summary>
        [DefaultValue(128)]
        [Description("选项宽度")]
        public int ItemWidth
        {
            get { return this.itemWidth; }
            set
            {
                if (this.itemWidth == value || value < 0)
                    return;
                this.itemWidth = value;
                if (this.Type == FisheyeMenuTypes.ImageText)
                {
                    this.InitializeFisheyeMenuRectangle();
                    this.Invalidate();
                }
            }
        }

        private int itemHeight = 128;
        /// <summary>
        /// 选项高度
        /// </summary>
        [DefaultValue(128)]
        [Description("选项高度")]
        public int ItemHeight
        {
            get { return this.itemHeight; }
            set
            {
                if (this.itemHeight == value || value < 0)
                    return;
                this.itemHeight = value;
                if (this.Type == FisheyeMenuTypes.ImageText)
                {
                    this.InitializeFisheyeMenuRectangle();
                    this.Invalidate();
                }
            }
        }

        private int itemPadding = 10;
        /// <summary>
        /// 鱼眼菜单选项内边距间距(限于FisheyeMenuOrientation.Bottom、FisheyeMenuOrientation.Top、FisheyeMenuOrientation.Left、FisheyeMenuOrientation.Right)
        /// </summary>
        [DefaultValue(10)]
        [Description("鱼眼菜单选项内边距间距(限于FisheyeMenuOrientation.Bottom、FisheyeMenuOrientation.Top、FisheyeMenuOrientation.Left、FisheyeMenuOrientation.Right)")]
        public int ItemPadding
        {
            get { return this.itemPadding; }
            set
            {
                if (this.itemPadding == value || value < 0)
                    return;
                this.itemPadding = value;
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();

            }
        }

        private FisheyeMenuItemCollection fisheyeMenuItemCollection;
        /// <summary>
        /// 鱼眼菜单选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("鱼眼菜单选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FisheyeMenuItemCollection Items
        {
            get
            {
                if (this.fisheyeMenuItemCollection == null)
                    this.fisheyeMenuItemCollection = new FisheyeMenuItemCollection(this);
                return this.fisheyeMenuItemCollection;
            }
        }

        #region 图片

        private bool imageAutoFree = true;
        /// <summary>
        /// 控件释放时是否自动释放倒影图片
        /// </summary>
        [DefaultValue(true)]
        [Description("控件释放时是否自动释放倒影图片")]
        public bool ImageAutoFree
        {
            get { return this.imageAutoFree; }
            set
            {
                if (this.imageAutoFree == value)
                    return;
                this.imageAutoFree = value;
            }
        }

        private bool imageReflection = false;
        /// <summary>
        /// 图片是否添加倒影(限于FisheyeMenuOrientation.Top 、 FisheyeMenuOrientation.Bottom、 FisheyeMenuOrientation.HorizontalCenter)
        /// </summary>
        [DefaultValue(false)]
        [Description("图片是否添加倒影(限于FisheyeMenuOrientation.Top 、 FisheyeMenuOrientation.Bottom、 FisheyeMenuOrientation.HorizontalCenter)")]
        public bool ImageReflection
        {
            get { return this.imageReflection; }
            set
            {
                if (this.imageReflection == value)
                    return;
                this.imageReflection = value;
                if (this.Type == FisheyeMenuTypes.ImageText && this.ImageReflection && this.ISHorizontal())
                {
                    this.TransformReflectionImages();
                }
                else
                {
                    this.FreeReflectionImages();
                }
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        #endregion

        #region 文本

        private int textTlasticity = 10;
        /// <summary>
        /// 文本弹性系数（一般为选项宽或高的6倍）
        /// </summary>
        [DefaultValue(10)]
        [Description("文本弹性系数（一般为选项宽或高的6倍）")]
        public int TextTlasticity
        {
            get { return this.textTlasticity; }
            set
            {
                if (this.textTlasticity == value)
                    return;
                this.textTlasticity = value;
            }
        }

        private bool textVertical = false;
        /// <summary>
        /// 选项文本是否垂直对齐(限于FisheyeMenuOrientation.Left、FisheyeMenuOrientation.Right、FisheyeMenuOrientation.VerticalCenter)
        /// </summary>
        [DefaultValue(false)]
        [Description("选项文本是否垂直对齐(限于FisheyeMenuOrientation.Left、FisheyeMenuOrientation.Right、FisheyeMenuOrientation.VerticalCenter)")]
        public bool TextVertical
        {
            get { return this.textVertical; }
            set
            {
                if (this.textVertical == value)
                    return;
                this.textVertical = value;
                this.Invalidate();
            }
        }

        private bool textShow = false;
        /// <summary>
        /// 是否显示选项文本(限于FisheyeMenuTypes.ImageText)
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示选项文本(限于FisheyeMenuTypes.ImageText)")]
        public bool TextShow
        {
            get { return this.textShow; }
            set
            {
                if (this.textShow == value)
                    return;
                this.textShow = value;
                this.Invalidate();
            }
        }

        private Font textFont = new Font("宋体", 10);
        /// <summary>
        /// 选项文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("选项文本字体")]
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

        private Color textNormalColor = Color.FromArgb(64, 64, 64);
        /// <summary>
        /// 选项文本颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "64, 64, 64")]
        [Description("选项文本颜色（正常）")]
        public Color TextNormalColor
        {
            get { return this.textNormalColor; }
            set
            {
                if (this.textNormalColor == value)
                    return;
                this.textNormalColor = value;
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private Color textActivateColor = Color.OliveDrab;
        /// <summary>
        /// 选项文本颜色（激活）
        /// </summary>
        [DefaultValue(typeof(Color), "OliveDrab")]
        [Description("选项文本颜色（激活）")]
        public Color TextActivateColor
        {
            get { return this.textActivateColor; }
            set
            {
                if (this.textActivateColor == value)
                    return;
                this.textActivateColor = value;
                this.InitializeFisheyeMenuRectangle();
                this.Invalidate();
            }
        }

        private Color textDisableColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 选项文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("选项文本颜色（禁止）")]
        public Color TextDisableColor
        {
            get { return this.textDisableColor; }
            set
            {
                if (this.textDisableColor == value)
                    return;
                this.textDisableColor = value;
                this.InitializeFisheyeMenuRectangle();
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

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(0);
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(600, 128);
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
        /// 控件激活状态
        /// </summary>
        private bool activatedState = false;

        /// <summary>
        /// 控件激活状态
        /// </summary>
        private int activatedStateIndex = -1;

        /// <summary>
        /// 控件激活状态显示边框
        /// </summary>
        private bool activatedStateShow = false;

        /// <summary>
        /// 控件激活状态鼠标是否按下
        /// </summary>
        private bool activatedStateMoveDown = false;

        /// <summary>
        /// 鼠标单击的选项
        /// </summary>
        private int clickIndex = -1;

        /// <summary>
        /// 激活虚线框边距
        /// </summary>
        private int activated_border = 1;

        #endregion

        public FisheyeMenuExt()
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

            #region 文本画笔
            StringFormat item_text_sf = this.GetTextStringFormat();
            SolidBrush normal_item_text_sb = null;
            SolidBrush activate_item_text_sb = null;
            SolidBrush disable_item_text_sb = null;
            if (Type == FisheyeMenuTypes.Text || (this.Type == FisheyeMenuTypes.ImageText && this.TextShow))
            {
                if (this.Enabled)
                {
                    normal_item_text_sb = new SolidBrush(this.TextNormalColor);
                    activate_item_text_sb = new SolidBrush(this.TextActivateColor);
                }
                else
                {
                    disable_item_text_sb = new SolidBrush(this.TextDisableColor);
                }
            }
            #endregion

            if (this.Type == FisheyeMenuTypes.ImageText)
            {
                #region 倒影图片
                if (this.ImageReflection && this.ISHorizontal())
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].ReflectionImage != null)
                        {
                            g.DrawImage(this.Items[i].ReflectionImage, new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height));
                        }
                    }
                }
                #endregion
                #region 正常图片
                else
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].Image != null)
                        {
                            g.DrawImage(this.Items[i].Image, new RectangleF(this.Items[i].now_rectf.X, this.Items[i].now_rectf.Y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height));
                        }
                    }
                }
                #endregion
            }

            #region 文本
            if (Type == FisheyeMenuTypes.Text || (this.Type == FisheyeMenuTypes.ImageText && this.TextShow))
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (!String.IsNullOrWhiteSpace(this.Items[i].Text))
                    {
                        RectangleF item_text_rectf = this.GetTextRectangle(g, this.Items[i], item_text_sf);
                        g.DrawString(this.Items[i].Text, this.TextFont, (!this.Enabled) ? disable_item_text_sb : ((this.activatedStateIndex == i) ? activate_item_text_sb : normal_item_text_sb), item_text_rectf, item_text_sf);
                    }
                }
            }
            #endregion

            #region 激活边框
            if (this.activatedState && this.activatedStateShow && this.Items.Count > 0)
            {
                SizeF image_size = this.GetImageRealitySize();
                Pen active_border_pen = new Pen(this.BorderActivateColor, 1) { DashStyle = DashStyle.Dash };
                RectangleF rectf = RectangleF.Empty;
                if (this.ISHorizontal())
                {
                    rectf = new RectangleF(this.Items[0].now_rectf.X - 1, this.Items[0].now_rectf.Y - 1, image_size.Width * this.Proportion * this.Items.Count + this.Distance * (this.Items.Count - 1), image_size.Height * this.Proportion);
                }
                else if (this.ISVertical())
                {
                    rectf = new RectangleF(this.Items[0].now_rectf.X - 1, this.Items[0].now_rectf.Y - 1, image_size.Width * this.Proportion, image_size.Height * this.Proportion * this.Items.Count + this.Distance * (this.Items.Count - 1));
                }

                g.DrawRectangle(active_border_pen, rectf.X, rectf.Y, rectf.Width, rectf.Height);
                active_border_pen.Dispose();
            }
            #endregion

            #region 释放

            if (normal_item_text_sb != null)
                normal_item_text_sb.Dispose();
            if (activate_item_text_sb != null)
                activate_item_text_sb.Dispose();
            if (disable_item_text_sb != null)
                disable_item_text_sb.Dispose();

            if (item_text_sf != null)
                item_text_sf.Dispose();

            #endregion

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.activatedStateIndex = -1;
            this.activatedStateShow = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.activatedStateShow = false;
            this.ResetFisheyeMenuItemsProportion();
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.activatedStateShow = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.activatedStateShow = false;
            this.ResetFisheyeMenuItemsProportion();
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
            {
                return base.ProcessDialogKey(keyData);
            }

            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    int pre_activatedStateIndex = this.activatedStateIndex;
                    this.activatedStateIndex--;
                    if (this.activatedStateIndex < 0)
                    {
                        this.activatedStateIndex = this.Items.Count - 1;
                    }

                    this.UpdateFisheyeMenuItemZoom(new PointF(this.Items[this.activatedStateIndex].now_centerpointf.X, this.Items[this.activatedStateIndex].now_centerpointf.Y));
                    this.InitializeFisheyeMenuRectangle();

                    this.activatedStateShow = false;
                    this.Invalidate();
                    if (pre_activatedStateIndex != this.activatedStateIndex)
                    {
                        this.FisheyeMenuIndexChanged(this.activatedStateIndex);
                    }
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    int pre_activatedStateIndex = this.activatedStateIndex;
                    this.activatedStateIndex++;
                    if (this.activatedStateIndex > this.Items.Count - 1)
                    {
                        this.activatedStateIndex = 0;
                    }

                    this.UpdateFisheyeMenuItemZoom(new PointF(this.Items[this.activatedStateIndex].now_centerpointf.X, this.Items[this.activatedStateIndex].now_centerpointf.Y));
                    this.InitializeFisheyeMenuRectangle();

                    this.activatedStateShow = false;
                    this.Invalidate();
                    if (pre_activatedStateIndex != this.activatedStateIndex)
                    {
                        this.FisheyeMenuIndexChanged(this.activatedStateIndex);
                    }
                    return false;
                }
                #endregion
                #region Enter、Space
                else if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    this.ResetFisheyeMenuItemsProportion();
                    this.InitializeFisheyeMenuRectangle();
                    this.Invalidate();

                    this.OnItemClick(new ItemClickEventArgs() { Item = this.Items[this.activatedStateIndex] });

                    this.activatedStateIndex = -1;
                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            this.Select();
            this.activatedState = true;
            this.activatedStateIndex = -1;
            this.activatedStateShow = false;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.ResetFisheyeMenuItemsProportion();
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            this.activatedStateShow = false;
            if (this.activatedStateMoveDown)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].now_rectf.Contains(e.Location))
                    {
                        int pre_activatedStateIndex = this.activatedStateIndex;
                        this.activatedStateIndex = i;
                        if (pre_activatedStateIndex != this.activatedStateIndex)
                        {
                            this.FisheyeMenuIndexChanged(this.activatedStateIndex);
                        }
                    }
                }
            }
            else
            {
                this.activatedStateIndex = -1;
            }

            this.UpdateFisheyeMenuItemZoom(e.Location);
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (this.DesignMode)
                return;

            this.activatedStateMoveDown = true;
            this.clickIndex = -1;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].now_rectf.Contains(e.Location))
                {
                    this.clickIndex = i;
                    int pre_activatedStateIndex = this.activatedStateIndex;
                    this.activatedStateIndex = i;
                    if (pre_activatedStateIndex != this.activatedStateIndex)
                    {
                        this.FisheyeMenuIndexChanged(this.activatedStateIndex);
                    }
                    break;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.DesignMode)
                return;

            if (this.activatedStateMoveDown && this.activatedStateIndex > -1)
            {
                this.OnUpItemClick(new ItemUpClickEventArgs() { Item = this.Items[this.activatedStateIndex] });
            }

            this.activatedStateIndex = -1;
            this.activatedStateMoveDown = false;
            this.clickIndex = -1;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point point = this.PointToClient(Control.MousePosition);
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].now_rectf.Contains(point) && this.clickIndex == i)
                    {
                        this.OnItemClick(new ItemClickEventArgs() { Item = this.Items[i] });
                        break;
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeFisheyeMenuRectangle();
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
                if (this.ImageAutoFree)
                    this.FreeReflectionImages();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnIndexChangedClick(IndexChangedEventArgs e)
        {
            if (this.indexChanged != null)
            {
                this.indexChanged(this, e);
            }
        }

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.itemClick != null)
            {
                this.itemClick(this, e);
            }
        }

        protected virtual void OnUpItemClick(ItemUpClickEventArgs e)
        {
            if (this.itemUpClick != null)
            {
                this.itemUpClick(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 刷新控件
        /// </summary>
        public void ResetControl()
        {
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        /// <summary>
        /// 刷新控件并重新刷新所有倒影图片
        /// </summary>
        public void ResetControlAndImages()
        {
            if (this.Type == FisheyeMenuTypes.ImageText && this.ImageReflection && this.ImageReflection && this.ISHorizontal())
            {
                this.TransformReflectionImages();
            }
            this.InitializeFisheyeMenuRectangle();
            this.Invalidate();
        }

        /// <summary>
        /// 变换指定图片添加倒影
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Bitmap TransformImage(FisheyeMenuItem item)
        {
            if (item.Image == null)
            {
                return null;
            }
            return ControlCommom.TransformReflection((Bitmap)item.Image, 0, 0, 150, 0, item.Image.Height / 3);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化所有鱼眼菜单选项Rectangle
        /// </summary>
        private void InitializeFisheyeMenuRectangle()
        {
            SizeF image_size = this.GetImageRealitySize();
            RectangleF rectf = new RectangleF(this.activated_border, this.activated_border, this.ClientRectangle.Width - this.activated_border * 2, this.ClientRectangle.Height - this.activated_border * 2);
            float sum = 0f;
            for (int i = 0; i < this.Items.Count; i++)
            {
                float item_now_width = image_size.Width * this.Items[i].now_proportion;
                float item_now_height = image_size.Height * this.Items[i].now_proportion;
                this.Items[i].now_rectf = new RectangleF(0f, 0f, item_now_width, item_now_height);
                sum = sum + (this.ISHorizontal() ? item_now_width : item_now_height) + ((i < this.Items.Count - 1) ? this.Distance : 0);

            }
            #region  计算选项图片Rectangle
            for (int i = 0; i < this.Items.Count; i++)
            {
                float x = 0;
                float y = 0;
                switch (this.Orientation)
                {
                    case FisheyeMenuOrientation.Bottom:
                        {
                            x = (i == 0) ? (rectf.Width - sum) / 2f : this.Items[i - 1].now_rectf.Right + this.Distance;
                            y = rectf.Bottom - this.ItemPadding - this.Items[i].now_rectf.Height - activated_border;
                            break;
                        }
                    case FisheyeMenuOrientation.Top:
                        {
                            x = (i == 0) ? (rectf.Width - sum) / 2f : this.Items[i - 1].now_rectf.Right + this.Distance;
                            y = activated_border + this.ItemPadding;
                            break;
                        }

                    case FisheyeMenuOrientation.HorizontalCenter:
                        {
                            x = (i == 0) ? (rectf.Width - sum) / 2f : this.Items[i - 1].now_rectf.Right + this.Distance;
                            y = (rectf.Height - this.Items[i].now_rectf.Height) / 2f;
                            break;
                        }
                    case FisheyeMenuOrientation.Left:
                        {
                            x = activated_border + this.ItemPadding;
                            y = (i == 0) ? (rectf.Height - sum) / 2f : this.Items[i - 1].now_rectf.Bottom + this.Distance;
                            break;
                        }
                    case FisheyeMenuOrientation.Right:
                        {
                            x = rectf.Right - this.ItemPadding - this.Items[i].now_rectf.Width - activated_border;
                            y = (i == 0) ? (rectf.Height - sum) / 2f : this.Items[i - 1].now_rectf.Bottom + this.Distance;
                            break;
                        }
                    case FisheyeMenuOrientation.VerticalCenter:
                        {
                            x = (rectf.Right - this.Items[i].now_rectf.Width) / 2f;
                            y = (i == 0) ? (rectf.Height - sum) / 2f : this.Items[i - 1].now_rectf.Bottom + this.Distance;
                            break;
                        }
                }
                this.Items[i].now_rectf = new RectangleF(x, y, this.Items[i].now_rectf.Width, this.Items[i].now_rectf.Height);
                this.Items[i].now_centerpointf = new PointF(this.Items[i].now_rectf.X + (this.Items[i].now_rectf.Width / 2f), this.Items[i].now_rectf.Y + (this.Items[i].now_rectf.Height / 2f));
            }
            #endregion
        }

        /// <summary>
        ///重置所有鱼眼菜单选项默认缩放比例
        /// </summary>
        private void ResetFisheyeMenuItemsProportion()
        {
            foreach (FisheyeMenuItem item in this.Items)
            {
                item.now_proportion = this.Proportion;
            }
        }

        /// <summary>
        ///重置指定鱼眼菜单选项默认缩放比例
        /// </summary>
        /// <param name="item"></param>
        private void ResetFisheyeMenuItemProportion(FisheyeMenuItem item)
        {
            item.now_proportion = this.Proportion;
        }

        /// <summary>
        /// 更新所有选项的对应缩放比例
        /// </summary>
        /// <param name="point">鼠标坐标</param>
        private void UpdateFisheyeMenuItemZoom(PointF point)
        {
            SizeF image_size = this.GetImageRealitySize();
            for (int i = 0; i < this.Items.Count; i++)
            {
                #region 计算当前选项的缩放比例
                float distance = (float)Math.Sqrt(Math.Pow(Math.Abs(this.Items[i].now_centerpointf.X - point.X), 2) + Math.Pow(Math.Abs(this.Items[i].now_centerpointf.Y - point.Y), 2));//鼠标焦点和选项圆心的距离
                float item_distance = (float)Math.Sqrt(Math.Pow(image_size.Width, 2) + Math.Pow(image_size.Height, 2));
                float p = 1 - distance / item_distance / 2f + this.Distance / 2f;//当焦点位于两个选项中间时应放大剩余还原百分比的二分之一。例如宽度100px 默认缩放0.6那么剩余还原百分比为0.4
                if (p < this.Proportion)
                {
                    p = this.Proportion;
                }
                this.Items[i].now_proportion = p;
                #endregion
            }
        }

        /// <summary>
        ///  选项是否横向排列
        /// </summary>
        /// <returns></returns>
        private bool ISHorizontal()
        {
            return (this.orientation == FisheyeMenuOrientation.Top || this.orientation == FisheyeMenuOrientation.Bottom || this.orientation == FisheyeMenuOrientation.HorizontalCenter);
        }

        /// <summary>
        /// 选项是否纵向排列
        /// </summary>
        /// <returns></returns>
        private bool ISVertical()
        {
            return (this.orientation == FisheyeMenuOrientation.Left || this.orientation == FisheyeMenuOrientation.Right || this.orientation == FisheyeMenuOrientation.VerticalCenter);
        }

        /// <summary>
        /// 鱼眼菜单选项选中索引更改方法
        /// </summary>
        /// <param name="index"></param>
        protected virtual void FisheyeMenuIndexChanged(int index)
        {
            if (!this.DesignMode)
            {
                if (index > 0 && index < this.Items.Count)
                {
                    this.OnIndexChangedClick(new IndexChangedEventArgs() { Item = this.Items[index] });
                }
            }
        }

        #region 图片

        /// <summary>
        /// 变换所有图片添加倒影
        /// </summary>
        private void TransformReflectionImages()
        {
            Image oldImage = null;
            for (int i = 0; i < this.Items.Count; i++)
            {
                oldImage = this.Items[i].ReflectionImage;
                if (this.Items[i].Image == null)
                {
                    this.Items[i].ReflectionImage = null;
                }
                else
                {
                    this.Items[i].ReflectionImage = TransformImage(this.Items[i]);
                }
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
        }


        /// <summary>
        /// 释放所有倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void FreeReflectionImages()
        {
            if (this.Items != null)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ReflectionImage != null)
                    {
                        this.Items[i].ReflectionImage.Dispose();
                        this.Items[i].ReflectionImage = null;
                    }
                }
            }
        }

        /// <summary>
        /// 释放指定索引倒影图片
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void FreeReflectionImage(int index)
        {
            if (this.Items != null && index >= 0 && index < this.Items.Count)
            {
                if (this.Items[index].ReflectionImage != null)
                {
                    this.Items[index].ReflectionImage.Dispose();
                    this.Items[index].ReflectionImage = null;
                }
            }
        }

        /// <summary>
        /// 获取图片处理后的Size
        /// </summary>
        private SizeF GetImageRealitySize()
        {
            if (this.Type == FisheyeMenuTypes.ImageText && this.ImageReflection && this.ISHorizontal())
            {
                return new SizeF((float)this.ItemWidth, this.ItemHeight + this.ItemHeight / 3f);
            }
            else
            {
                return new SizeF(this.ItemWidth, this.ItemHeight);
            }
        }

        #endregion

        #region 文本

        /// <summary>
        /// 获取文本Rectangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="item"></param>
        /// <param name="sf"></param>
        /// <returns></returns>
        private RectangleF GetTextRectangle(Graphics g, FisheyeMenuItem item, StringFormat sf)
        {
            RectangleF item_text_rectf = RectangleF.Empty;
            SizeF item_text_size = g.MeasureString(item.Text, this.TextFont, new SizeF(), sf);

            #region 文本弹性距离
            float item_text_tlasticity = 0f;
            if (this.Type == FisheyeMenuTypes.Text)
            {
                item_text_tlasticity = (this.ISHorizontal() ? item_text_size.Height : item_text_size.Width) * this.TextTlasticity * (item.now_proportion - this.Proportion);
            }
            #endregion

            #region 文本Rectangle
            switch (this.Orientation)
            {
                case FisheyeMenuOrientation.Top:
                    {
                        if (item.now_rectf.Width > item_text_size.Width)
                        {
                            float x = item.now_rectf.X + (item.now_rectf.Width - item_text_size.Width) / 2f;
                            float y = (this.Type == FisheyeMenuTypes.Text ? this.ItemPadding : item.now_rectf.Bottom) + item_text_size.Height + item_text_tlasticity;
                            item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                        }
                        else
                        {
                            float x = item.now_rectf.X;
                            float y = (this.Type == FisheyeMenuTypes.Text ? this.ItemPadding : item.now_rectf.Bottom) + item_text_size.Height + item_text_tlasticity;
                            item_text_rectf = new RectangleF(x, y, item.now_rectf.Width, item_text_size.Height);
                        }
                        break;
                    }
                case FisheyeMenuOrientation.HorizontalCenter:
                case FisheyeMenuOrientation.Bottom:
                    {
                        if (item.now_rectf.Width > item_text_size.Width)
                        {
                            float x = item.now_rectf.X + (item.now_rectf.Width - item_text_size.Width) / 2f;
                            float y = (this.Type == FisheyeMenuTypes.Text ? item.now_rectf.Bottom - this.ItemPadding : item.now_rectf.Y) - item_text_size.Height - item_text_tlasticity;
                            item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                        }
                        else
                        {
                            float x = item.now_rectf.X;
                            float y = (this.Type == FisheyeMenuTypes.Text ? item.now_rectf.Bottom - this.ItemPadding : item.now_rectf.Y) - item_text_size.Height - item_text_tlasticity;
                            item_text_rectf = new RectangleF(x, y, item.now_rectf.Width, item_text_size.Height);
                        }
                        break;
                    }
                case FisheyeMenuOrientation.VerticalCenter:
                case FisheyeMenuOrientation.Left:
                    {
                        if (this.TextVertical)
                        {
                            if (item.now_rectf.Height > item_text_size.Height)
                            {
                                float x = (this.Type == FisheyeMenuTypes.Text ? this.ItemPadding : item.now_rectf.Right) + item_text_tlasticity;
                                float y = item.now_rectf.Y + (item.now_rectf.Height - item_text_size.Height) / 2f;
                                item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                            }
                            else
                            {
                                float x = (this.Type == FisheyeMenuTypes.Text ? this.ItemPadding : item.now_rectf.Right) + item_text_tlasticity;
                                float y = item.now_rectf.Y;
                                item_text_rectf = new RectangleF(x, y, item_text_size.Width, item.now_rectf.Height);
                            }
                        }
                        else
                        {
                            float x = (this.Type == FisheyeMenuTypes.Text ? this.ItemPadding : item.now_rectf.Right) + item_text_tlasticity;
                            float y = item.now_rectf.Y + (item.now_rectf.Height - item_text_size.Height) / 2f;
                            item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                        }
                        break;
                    }
                case FisheyeMenuOrientation.Right:
                    {
                        if (this.TextVertical)
                        {
                            if (item.now_rectf.Height > item_text_size.Height)
                            {
                                float x = (this.Type == FisheyeMenuTypes.Text ? item.now_rectf.Right - this.ItemPadding : item.now_rectf.X) - item_text_size.Width - item_text_tlasticity;
                                float y = item.now_rectf.Y + (item.now_rectf.Height - item_text_size.Height) / 2f;
                                item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                            }
                            else
                            {
                                float x = (this.Type == FisheyeMenuTypes.Text ? item.now_rectf.Right - this.ItemPadding : item.now_rectf.X) - item_text_size.Width - item_text_tlasticity;
                                float y = item.now_rectf.Y;
                                item_text_rectf = new RectangleF(x, y, item_text_size.Width, item.now_rectf.Height);
                            }
                        }
                        else
                        {
                            float x = (this.Type == FisheyeMenuTypes.Text ? item.now_rectf.Right - this.ItemPadding : item.now_rectf.X) - item_text_size.Width - item_text_tlasticity;
                            float y = item.now_rectf.Y + (item.now_rectf.Height - item_text_size.Height) / 2f;
                            item_text_rectf = new RectangleF(x, y, item_text_size.Width, item_text_size.Height);
                        }
                        break;
                    }
            }
            #endregion

            return item_text_rectf;
        }

        /// <summary>
        /// 获取文本格式
        /// </summary>
        /// <returns></returns>
        private StringFormat GetTextStringFormat()
        {
            if (this.Type == FisheyeMenuTypes.Text || (this.Type == FisheyeMenuTypes.ImageText && this.TextShow))
            {
                StringFormat item_text_sf = new StringFormat() { Trimming = StringTrimming.EllipsisCharacter };
                if (this.ISHorizontal() && this.TextVertical)
                {
                    item_text_sf.FormatFlags = StringFormatFlags.DirectionVertical;
                }
                return item_text_sf;
            }
            return null; ;
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 鱼眼菜单选项集合
        /// </summary>
        [Description("鱼眼菜单选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class FisheyeMenuItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList fisheyeMenuItemList = new ArrayList();
            private FisheyeMenuExt owner;

            public FisheyeMenuItemCollection(FisheyeMenuExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                FisheyeMenuItem[] listArray = new FisheyeMenuItem[this.fisheyeMenuItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (FisheyeMenuItem)this.fisheyeMenuItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                    array.SetValue(this.fisheyeMenuItemList[i], i + index);
            }

            public int Count
            {
                get
                {
                    return this.fisheyeMenuItemList.Count;
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
                if (!(value is FisheyeMenuItem))
                {
                    throw new ArgumentException("FisheyeMenuItem");
                }
                return this.Add((FisheyeMenuItem)value);
            }

            public int Add(FisheyeMenuItem item)
            {
                this.owner.ResetFisheyeMenuItemProportion(item);
                this.fisheyeMenuItemList.Add(item);
                if (this.owner.Type == FisheyeMenuTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    item.ReflectionImage = this.owner.TransformImage(item);
                }
                this.owner.InitializeFisheyeMenuRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.fisheyeMenuItemList.Clear();
                if (this.owner.Type == FisheyeMenuTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImages();
                }
                this.owner.InitializeFisheyeMenuRectangle();
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
                if (item is FisheyeMenuItem)
                {
                    return this.Contains((FisheyeMenuItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is FisheyeMenuItem)
                {
                    return this.fisheyeMenuItemList.IndexOf(item);
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
                if (!(value is FisheyeMenuItem))
                {
                    throw new ArgumentException("FisheyeMenuItem");
                }
                int index = this.fisheyeMenuItemList.IndexOf((FisheyeMenuItem)value);
                this.Remove((FisheyeMenuItem)value);
            }

            public void Remove(FisheyeMenuItem item)
            {
                int index = this.fisheyeMenuItemList.IndexOf(item);
                if (this.owner.Type == FisheyeMenuTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImage(index);
                }
                this.fisheyeMenuItemList.Remove(item);
                this.owner.InitializeFisheyeMenuRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                if (this.owner.Type == FisheyeMenuTypes.ImageText && this.owner.ImageReflection && this.owner.ISHorizontal())
                {
                    this.owner.FreeReflectionImage(index);
                }
                this.fisheyeMenuItemList.RemoveAt(index);
                this.owner.InitializeFisheyeMenuRectangle();
                this.owner.Invalidate();
            }

            public FisheyeMenuItem this[int index]
            {
                get
                {
                    return (FisheyeMenuItem)this.fisheyeMenuItemList[index];
                }
                set
                {
                    this.fisheyeMenuItemList[index] = (FisheyeMenuItem)value;
                    this.owner.InitializeFisheyeMenuRectangle();
                    this.owner.Invalidate();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.fisheyeMenuItemList[index];
                }
                set
                {
                    this.fisheyeMenuItemList[index] = (FisheyeMenuItem)value;
                    this.owner.InitializeFisheyeMenuRectangle();
                    this.owner.Invalidate();
                }
            }

            #endregion

        }

        /// <summary>
        /// 鱼眼菜单选项
        /// </summary>
        [Description("鱼眼菜单选项")]
        public class FisheyeMenuItem
        {
            /// <summary>
            /// 选项图片
            /// </summary>
            [Browsable(true)]
            [DefaultValue(null)]
            [Description("选项图片")]
            public Image Image { get; set; }

            private Image reflectionImage = null;
            /// <summary>
            /// 倒影图片
            /// </summary>
            [Browsable(false)]
            [DefaultValue(null)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("倒影图片")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Image ReflectionImage
            {
                get { return this.reflectionImage; }
                set
                {
                    if (this.reflectionImage == value)
                        return;
                    this.reflectionImage = value;
                }
            }

            /// <summary>
            /// 文本信息
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("文本信息")]
            public string Text { get; set; }

            /// <summary>
            /// 当前选项大小比例
            /// </summary>
            [Browsable(false)]
            public float now_proportion { get; set; }

            /// <summary>
            /// 当前选项rectf
            /// </summary>
            [Browsable(false)]
            public RectangleF now_rectf { get; set; }

            /// <summary>
            /// 当前选项rectf中心坐标
            /// </summary>
            [Browsable(false)]
            public PointF now_centerpointf { get; set; }
        }

        /// <summary>
        /// 鱼眼菜单选项选中索引更改事件参数
        /// </summary>
        [Description("鱼眼菜单选项选中索引更改事件参数")]
        public class IndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        /// <summary>
        /// 鱼眼菜单选项单击事件参数
        /// </summary>
        [Description("鱼眼菜单选项单击事件参数")]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        /// <summary>
        /// 鱼眼菜单选项光标选中释放事件参数
        /// </summary>
        [Description("鱼眼菜单选项光标选中释放事件参数")]
        public class ItemUpClickEventArgs : EventArgs
        {
            /// <summary>
            /// 鱼眼菜单选项
            /// </summary>
            [Description("鱼眼菜单选项")]
            public FisheyeMenuItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 鱼眼菜单方向位置
        /// </summary>
        [Description("鱼眼菜单方向位置")]
        public enum FisheyeMenuOrientation
        {
            /// <summary>
            /// 靠上
            /// </summary>
            Top,
            /// <summary>
            /// 靠左
            /// </summary>
            Left,
            /// <summary>
            /// 靠下
            /// </summary>
            Bottom,
            /// <summary>
            /// 靠右
            /// </summary>
            Right,
            /// <summary>
            /// 横向居中
            /// </summary>
            HorizontalCenter,
            /// <summary>
            /// 垂直居中
            /// </summary>
            VerticalCenter
        }

        /// <summary>
        /// 鱼眼菜单类型
        /// </summary>
        [Description("鱼眼菜单类型")]
        public enum FisheyeMenuTypes
        {
            /// <summary>
            /// 图片文本
            /// </summary>
            ImageText,
            /// <summary>
            /// 文本
            /// </summary>
            Text
        }

        #endregion

    }
}
