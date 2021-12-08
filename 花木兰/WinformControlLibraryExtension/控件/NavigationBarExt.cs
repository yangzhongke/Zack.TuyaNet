
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
    /// 面包屑导航栏控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("面包屑导航栏控件")]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class NavigationBarExt : Control
    {
        #region 新增事件

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);
        private event ItemClickEventHandler itemClick;
        /// <summary>
        /// 导航选项单击事件
        /// </summary>
        [Description("导航选项单击事件")]
        public event ItemClickEventHandler ItemClick
        {
            add { this.itemClick += value; }
            remove { this.itemClick -= value; }
        }

        public delegate void SelectedChangedEventHandler(object sender, SelectedChangedEventArgs e);
        private event SelectedChangedEventHandler selectedChanged;
        /// <summary>
        /// 导航选中选项更改事件
        /// </summary>
        [Description("导航选中选项更改事件")]
        public event SelectedChangedEventHandler SelectedChanged
        {
            add { this.selectedChanged += value; }
            remove { this.selectedChanged -= value; }
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
                this.InitializeItemsRectangle();
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(189, 183, 107);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "189, 183, 107")]
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

        private Color activateColor = Color.Gray;
        /// <summary>
        /// 控件激活的虚线框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("控件激活的虚线框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ActivateColor
        {
            get { return this.activateColor; }
            set
            {
                if (this.activateColor == value)
                    return;
                this.activateColor = value;
                this.Invalidate();
            }
        }

        private ItemStyles itemStyle = ItemStyles.Arrows;
        /// <summary>
        /// 选项样式
        /// </summary>
        [DefaultValue(ItemStyles.Arrows)]
        [Description("选项样式")]
        [RefreshProperties(RefreshProperties.All)]
        public ItemStyles ItemStyle
        {
            get { return this.itemStyle; }
            set
            {
                if (this.itemStyle == value)
                    return;
                this.itemStyle = value;
                this.InitializeItemsRectangle();
                this.Invalidate();
            }
        }

        private int itemMinWidth = 0;
        /// <summary>
        ///选项最小宽度
        /// </summary>
        [DefaultValue(0)]
        [Description("选项最小宽度")]
        public int ItemMinWidth
        {
            get { return this.itemMinWidth; }
            set
            {
                if (this.itemMinWidth == value || value < 0)
                    return;
                this.itemMinWidth = value;
                this.InitializeItemsRectangle();
                this.Invalidate();
            }
        }

        private int itemMaxWidth = 0;
        /// <summary>
        ///选项最大宽度
        /// </summary>
        [DefaultValue(0)]
        [Description("选项最大宽度")]
        public int ItemMaxWidth
        {
            get { return this.itemMaxWidth; }
            set
            {
                if (this.itemMaxWidth == value || value < this.ItemMinWidth)
                    return;
                this.itemMaxWidth = value;
                this.InitializeItemsRectangle();
                this.Invalidate();
            }
        }

        private int itemInterval = 1;
        /// <summary>
        ///选项间隔距离
        /// </summary>
        [DefaultValue(1)]
        [Description("选项间隔距离")]
        public int ItemInterval
        {
            get { return this.itemInterval; }
            set
            {
                if (this.itemInterval == value || value < 0)
                    return;
                this.itemInterval = value;
                this.InitializeItemsRectangle();
                this.Invalidate();
            }
        }

        private Font itemTextFont = new Font("宋体", 11);
        /// <summary>
        /// 选项文本字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 11pt")]
        [Description("选项文本字体")]
        public Font ItemTextFont
        {
            get { return this.itemTextFont; }
            set
            {
                if (this.itemTextFont == value)
                    return;
                this.itemTextFont = value;
                this.Invalidate();
            }
        }

        private Color symbolColor = Color.FromArgb(193, 202, 126);
        /// <summary>
        /// 符号颜色(ItemStyles.Symbol才有效)
        /// </summary>
        [DefaultValue(typeof(Color), "193, 202, 126")]
        [Description("符号颜色(ItemStyles.Symbol才有效)")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color SymbolColor
        {
            get { return this.symbolColor; }
            set
            {
                if (this.symbolColor == value)
                    return;
                this.symbolColor = value;
                this.Invalidate();
            }
        }

        private Color itemNormalBackColor = Color.FromArgb(205, 213, 138);
        /// <summary>
        /// 选项背景颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "205, 213, 138")]
        [Description("选项背景颜色（正常）")]
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

        private Color itemNormalTextColor = Color.White;
        /// <summary>
        /// 选项文本颜色（正常）
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("选项文本颜色（正常）")]
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

        private Color itemEnterBackColor = Color.FromArgb(193, 202, 126);
        /// <summary>
        /// 选项背景颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "193, 202, 126")]
        [Description("选项背景颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemEnterBackColor
        {
            get { return this.itemEnterBackColor; }
            set
            {
                if (this.itemEnterBackColor == value)
                    return;
                this.itemEnterBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemEnterTextColor = Color.White;
        /// <summary>
        /// 选项文本颜色（鼠标进入）
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("选项文本颜色（鼠标进入）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemEnterTextColor
        {
            get { return this.itemEnterTextColor; }
            set
            {
                if (this.itemEnterTextColor == value)
                    return;
                this.itemEnterTextColor = value;
                this.Invalidate();
            }
        }

        private Color itemSelectedBackColor = Color.FromArgb(192, 192, 0);
        /// <summary>
        /// 选项背景颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 0")]
        [Description("选项背景颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemSelectedBackColor
        {
            get { return this.itemSelectedBackColor; }
            set
            {
                if (this.itemSelectedBackColor == value)
                    return;
                this.itemSelectedBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemSelectedTextColor = Color.White;
        /// <summary>
        /// 选项文本颜色（选中）
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        [Description("选项文本颜色（选中）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemSelectedTextColor
        {
            get { return this.itemSelectedTextColor; }
            set
            {
                if (this.itemSelectedTextColor == value)
                    return;
                this.itemSelectedTextColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableBackColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// 选项背景颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "224, 224, 224")]
        [Description("选项背景颜色（禁止）")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color ItemDisableBackColor
        {
            get { return this.itemDisableBackColor; }
            set
            {
                if (this.itemDisableBackColor == value)
                    return;
                this.itemDisableBackColor = value;
                this.Invalidate();
            }
        }

        private Color itemDisableTextColor = Color.FromArgb(128, 128, 128);
        /// <summary>
        /// 选项文本颜色（禁止）
        /// </summary>
        [DefaultValue(typeof(Color), "128, 128, 128")]
        [Description("选项文本颜色（禁止）")]
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

        private NavigationBarItemCollection navigationBarItemCollection;
        /// <summary>
        /// 导航选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("导航选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NavigationBarItemCollection Items
        {
            get
            {
                if (this.navigationBarItemCollection == null)
                    this.navigationBarItemCollection = new NavigationBarItemCollection(this);
                return this.navigationBarItemCollection;
            }
        }

        #endregion

        #region 重写属性

        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 24);
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
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
        /// 控件激活状态
        /// </summary>
        private bool activatedState = false;

        /// <summary>
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStateIndex = -1;

        /// <summary>
        /// 边框厚度
        /// </summary>
        private int borderThickness = 1;

        /// <summary>
        /// 选项文字垂直居中
        /// </summary>
        protected StringFormat text_sf = new StringFormat() { LineAlignment = StringAlignment.Center };

        #endregion

        public NavigationBarExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            #region 边框
            if (this.BorderShow)
            {
                Rectangle border_rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                Pen border_pen = new Pen(this.BorderColor, this.borderThickness);
                g.DrawRectangle(border_pen, border_rect);
                border_pen.Dispose();
            }
            #endregion

            #region 父画笔
            SolidBrush normal_back_sb = null;
            SolidBrush normal_text_sb = null;
            SolidBrush enter_back_sb = null;
            SolidBrush enter_text_sb = null;
            SolidBrush selected_back_sb = null;
            SolidBrush selected_text_sb = null;
            SolidBrush disable_back_sb = null;
            SolidBrush disable_text_sb = null;

            SolidBrush commom_back_sb = null;
            SolidBrush commom_text_sb = null;
            bool subitemsBackBrush = false;
            bool subitemsTextBrush = false;

            if (this.Enabled)
            {
                normal_back_sb = new SolidBrush(this.ItemNormalBackColor);
                normal_text_sb = new SolidBrush(this.ItemNormalTextColor);
                enter_back_sb = new SolidBrush(this.ItemEnterBackColor);
                enter_text_sb = new SolidBrush(this.ItemEnterTextColor);
                selected_back_sb = new SolidBrush(this.ItemSelectedBackColor);
                selected_text_sb = new SolidBrush(this.ItemSelectedTextColor);
            }
            else
            {
                disable_back_sb = new SolidBrush(this.ItemDisableBackColor);
                disable_text_sb = new SolidBrush(this.ItemDisableTextColor);
            }
            #endregion

            #region 绘制
            for (int i = 0; i < this.Items.Count; i++)
            {
                #region 子画笔
                if (this.Enabled)
                {
                    if (this.Items[i].Selected)
                    {
                        #region
                        if (this.Items[i].SelectedBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = selected_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].SelectedBackColor);
                        }
                        if (this.Items[i].SelectedTextColor == Color.Empty)
                        {
                            subitemsTextBrush = false;
                            commom_text_sb = selected_text_sb;
                        }
                        else
                        {
                            subitemsTextBrush = true;
                            commom_text_sb = new SolidBrush(this.Items[i].SelectedTextColor);
                        }
                        #endregion
                    }
                    else if (this.Items[i].ItemStatus == ItemStatuss.Enter)
                    {
                        #region
                        if (this.Items[i].EnterBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = enter_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].EnterBackColor);
                        }
                        if (this.Items[i].EnterTextColor == Color.Empty)
                        {
                            subitemsTextBrush = false;
                            commom_text_sb = enter_text_sb;
                        }
                        else
                        {
                            subitemsTextBrush = true;
                            commom_text_sb = new SolidBrush(this.Items[i].EnterTextColor);
                        }
                        #endregion
                    }
                    else
                    {
                        #region
                        if (this.Items[i].NormalBackColor == Color.Empty)
                        {
                            subitemsBackBrush = false;
                            commom_back_sb = normal_back_sb;
                        }
                        else
                        {
                            subitemsBackBrush = true;
                            commom_back_sb = new SolidBrush(this.Items[i].NormalBackColor);
                        }
                        if (this.Items[i].NormalTextColor == Color.Empty)
                        {
                            subitemsTextBrush = false;
                            commom_text_sb = normal_text_sb;
                        }
                        else
                        {
                            subitemsTextBrush = true;
                            commom_text_sb = new SolidBrush(this.Items[i].NormalTextColor);
                        }
                        #endregion
                    }
                }
                else
                {
                    #region
                    if (this.Items[i].DisableBackColor == Color.Empty)
                    {
                        subitemsBackBrush = false;
                        commom_back_sb = disable_back_sb;
                    }
                    else
                    {
                        subitemsBackBrush = true;
                        commom_back_sb = new SolidBrush(this.Items[i].DisableBackColor);
                    }
                    if (this.Items[i].DisableTextColor == Color.Empty)
                    {
                        subitemsTextBrush = false;
                        commom_text_sb = disable_text_sb;
                    }
                    else
                    {
                        subitemsTextBrush = true;
                        commom_text_sb = new SolidBrush(this.Items[i].DisableTextColor);
                    }
                    #endregion
                }
                #endregion

                DrawItem(i, this.Items[i], g, commom_back_sb, commom_text_sb);

                if (subitemsBackBrush && commom_back_sb != null)
                {
                    commom_back_sb.Dispose();
                    commom_back_sb = null;
                }

                if (subitemsTextBrush && commom_text_sb != null)
                {
                    commom_text_sb.Dispose();
                    commom_text_sb = null;
                }
            }
            #endregion

            if (normal_back_sb != null)
                normal_back_sb.Dispose();
            if (normal_text_sb != null)
                normal_text_sb.Dispose();
            if (enter_back_sb != null)
                enter_back_sb.Dispose();
            if (enter_text_sb != null)
                enter_text_sb.Dispose();
            if (selected_back_sb != null)
                selected_back_sb.Dispose();
            if (selected_text_sb != null)
                selected_text_sb.Dispose();
            if (disable_back_sb != null)
                disable_back_sb.Dispose();
            if (disable_text_sb != null)
                disable_text_sb.Dispose();
        }

        protected override void OnEnter(EventArgs e)
        {
            this.activatedState = true;
            this.activatedStateIndex = 0;
            this.Invalidate();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.Invalidate();

            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.activatedState = true;
            this.Invalidate();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.activatedState = false;
            this.Invalidate();

            base.OnLostFocus(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    this.activatedStateIndex--;
                    if (this.activatedStateIndex < 0)
                    {
                        this.activatedStateIndex = this.Items.Count - 1;
                    }
                    this.Invalidate();
                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    this.activatedStateIndex++;
                    if (this.activatedStateIndex > this.Items.Count - 1)
                    {
                        this.activatedStateIndex = 0;
                    }
                    this.Invalidate();
                    return false;
                }
                #endregion
                #region Enter、Space
                else if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    for (int j = 0; j < this.Items.Count; j++)
                    {
                        this.Items[j].Selected = false;
                    }
                    this.Items[this.activatedStateIndex].Selected = true;
                    this.Invalidate();

                    this.OnItemClick(new ItemClickEventArgs() { Item = this.Items[this.activatedStateIndex] });

                    return false;
                }
                #endregion
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Point point = this.PointToClient(Control.MousePosition);

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].BackRectF.Contains(point))
                {
                    for (int j = 0; j < this.Items.Count; j++)
                    {
                        this.Items[j].Selected = false;
                    }
                    this.Items[i].Selected = true;
                    if (this.TabStop)
                    {
                        this.Select();
                        this.activatedStateIndex = -1;
                    }
                    this.Invalidate();

                    this.OnItemClick(new ItemClickEventArgs() { Item = this.Items[i] });
                    this.SetSelectedItem(i);
                    break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool isenter = false;
            bool refresh = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].BackRectF.Contains(e.Location))
                {
                    isenter = true;
                    if (this.Items[i].ItemStatus != ItemStatuss.Enter)
                    {
                        refresh = true;
                        this.Items[i].ItemStatus = ItemStatuss.Enter;
                    }
                }
                else
                {
                    if (this.Items[i].ItemStatus != ItemStatuss.Normal)
                    {
                        refresh = true;
                    }
                    this.Items[i].ItemStatus = ItemStatuss.Normal;
                }
            }
            if (isenter)
            {
                if (this.Cursor != Cursors.Hand)
                {
                    this.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (this.Cursor != Cursors.Default)
                {
                    this.Cursor = Cursors.Default;
                }
            }
            if (refresh)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.Cursor = Cursors.Default;
            bool refresh = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].ItemStatus != ItemStatuss.Normal)
                {
                    refresh = true;
                }
                this.Items[i].ItemStatus = ItemStatuss.Normal;
            }
            if (refresh)
            {
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeItemsRectangle();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Items != null)
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].Path != null)
                        {
                            this.Items[i].Path.Dispose();
                        }
                    }
                }
                if (this.text_sf != null)
                    this.text_sf.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.itemClick != null)
            {
                this.itemClick(this, e);
            }
        }

        protected virtual void OnSelectedChanged(SelectedChangedEventArgs e)
        {
            if (this.selectedChanged != null)
            {
                this.selectedChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 清除选中项
        /// </summary>
        [Description("清除选中项")]
        public void ClearSelectedItemStatus()
        {
            bool isreset = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Selected == true)
                {
                    this.Items[i].Selected = false;
                    isreset = true;
                }
            }
            this.Invalidate();

            if (isreset)
            {
                this.OnSelectedChanged(new SelectedChangedEventArgs() { Item = null });
            }
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        [Description("获取选中项")]
        public NavigationBarItem GetSelectedItem()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Selected)
                    return this.Items[i];
            }
            return null;
        }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="item"></param>
        [Description("设置选中项")]
        public void SetSelectedItem(NavigationBarItem item)
        {
            if (item == null)
            {
                this.ClearSelectedItemStatus();
            }
            else
            {
                bool isexist = false;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i] == item)
                    {
                        isexist = true;
                        break;
                    }
                }
                if (isexist == false)
                {
                    return;
                }

                bool isreset = false;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i] == item)
                    {
                        if (this.Items[i].Selected == false)
                        {
                            this.Items[i].Selected = true;
                            isreset = true;
                        }
                    }
                    else
                    {
                        this.Items[i].Selected = false;
                    }
                }
                if (isreset)
                {
                    this.OnSelectedChanged(new SelectedChangedEventArgs() { Item = item });
                }
            }
        }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="index"></param>
        [Description("设置选中项")]
        public void SetSelectedItem(int index)
        {
            if (index < 0 || index > this.Items.Count - 1)
            {
                return;
            }

            bool isreset = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (i == index)
                {
                    if (this.Items[i].Selected == false)
                    {
                        this.Items[i].Selected = true;
                        isreset = true;
                    }
                }
                else
                {
                    this.Items[i].Selected = false;
                }
            }
            if (isreset)
            {
                this.OnSelectedChanged(new SelectedChangedEventArgs() { Item = this.Items[index] });
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化导航选项rect
        /// </summary>
        private void InitializeItemsRectangle()
        {
            Graphics g = this.CreateGraphics();
            RectangleF rect = this.ClientRectangle;

            float sawtoothLine = 1;//开启抗锯齿功能xy都会增大1px
            float item_x = this.borderThickness - sawtoothLine;//选项内容x坐标
            float item_y = this.borderThickness - sawtoothLine;//选项内容y坐标
            float item_height = rect.Height - this.borderThickness;//选项内容高度

            #region Quadrangle
            if (this.ItemStyle == ItemStyles.Quadrangle)//选项宽度=内容
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width, item_height);
                    item_x += this.Items[i].BackRectF.Width - sawtoothLine + this.ItemInterval;
                }
            }
            #endregion
            #region Circular
            else if (this.ItemStyle == ItemStyles.Circular)//选项宽度=内容+选项高度
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width + item_height, item_height);
                    item_x += this.Items[i].BackRectF.Width - sawtoothLine + this.ItemInterval;

                    GraphicsPath back_gp = new GraphicsPath();
                    back_gp.AddArc(new RectangleF(this.Items[i].BackRectF.Right - this.Items[i].BackRectF.Height * 2, this.Items[i].BackRectF.Y, this.Items[i].BackRectF.Height * 2, this.Items[i].BackRectF.Height * 2), 270, 90);
                    back_gp.AddLine(this.Items[i].BackRectF.X, this.Items[i].BackRectF.Bottom, this.Items[i].BackRectF.X, this.Items[i].BackRectF.Y);
                    back_gp.CloseFigure();
                    if (this.Items[i].Path == null)
                    {
                        this.Items[i].Path = back_gp;
                    }
                    else
                    {
                        this.Items[i].Path.Reset();
                        this.Items[i].Path = back_gp;
                    }
                }
            }
            #endregion
            #region Parallelogram、Arrows、RoundCap
            else if (this.ItemStyle == ItemStyles.Arrows || this.ItemStyle == ItemStyles.Parallelogram || this.ItemStyle == ItemStyles.RoundCap)//选项宽度=内容+选项高度
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width + item_height, item_height);
                    item_x += this.Items[i].BackRectF.Width - item_height / 2f - sawtoothLine + this.ItemInterval;

                    GraphicsPath back_gp = new GraphicsPath();
                    if (this.ItemStyle == ItemStyles.Arrows)
                    {
                        back_gp.AddPolygon(new PointF[] {
                                                     new PointF(this.Items[i].BackRectF.X, this.Items[i].BackRectF.Y),
                                                     new PointF(this.Items[i].BackRectF.Right- this.Items[i].BackRectF.Height / 2, this.Items[i].BackRectF.Y),
                                                     new PointF(this.Items[i].BackRectF.Right, this.Items[i].BackRectF.Y+this.Items[i].BackRectF.Height / 2),
                                                     new PointF(this.Items[i].BackRectF.Right- this.Items[i].BackRectF.Height / 2, this.Items[i].BackRectF.Bottom),
                                                     new PointF(this.Items[i].BackRectF.X , this.Items[i].BackRectF.Bottom),
                                                     new PointF(this.Items[i].BackRectF.X+this.Items[i].BackRectF.Height / 2 , this.Items[i].BackRectF.Y+this.Items[i].BackRectF.Height / 2)
                                                     });
                        back_gp.CloseFigure();
                    }
                    else if (this.ItemStyle == ItemStyles.Parallelogram)
                    {
                        back_gp.AddPolygon(new PointF[] {
                                                     new PointF(this.Items[i].BackRectF.X, this.Items[i].BackRectF.Y),
                                                     new PointF(this.Items[i].BackRectF.Right - this.Items[i].BackRectF.Height / 2, this.Items[i].BackRectF.Y),
                                                     new PointF(this.Items[i].BackRectF.Right , this.Items[i].BackRectF.Bottom),
                                                     new PointF(this.Items[i].BackRectF.X + this.Items[i].BackRectF.Height / 2, this.Items[i].BackRectF.Bottom)
                                                     });
                        back_gp.CloseFigure();
                    }
                    else if (this.ItemStyle == ItemStyles.RoundCap)
                    {
                        back_gp.AddArc(new RectangleF(this.Items[i].BackRectF.X - this.Items[i].BackRectF.Height / 2, this.Items[i].BackRectF.Y, this.Items[i].BackRectF.Height, this.Items[i].BackRectF.Height), 270, 180);
                        back_gp.Reverse();
                        back_gp.AddArc(new RectangleF(this.Items[i].BackRectF.Right - this.Items[i].BackRectF.Height, this.Items[i].BackRectF.Y, this.Items[i].BackRectF.Height, this.Items[i].BackRectF.Height), 270, 180);
                        back_gp.CloseFigure();
                    }
                    if (this.Items[i].Path == null)
                    {
                        this.Items[i].Path = back_gp;
                    }
                    else
                    {
                        this.Items[i].Path.Reset();
                        this.Items[i].Path = back_gp;
                    }
                }
            }
            #endregion
            #region Leaf
            else if (this.ItemStyle == ItemStyles.Leaf)//选项宽度=内容+选项高度*2
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width + item_height * 2, item_height);
                    item_x += this.Items[i].BackRectF.Width - item_height / 4f - sawtoothLine + this.ItemInterval;

                    GraphicsPath back_gp = new GraphicsPath();
                    back_gp.AddArc(new RectangleF(this.Items[i].BackRectF.Right - this.Items[i].BackRectF.Height * 2, this.Items[i].BackRectF.Y, this.Items[i].BackRectF.Height * 2, this.Items[i].BackRectF.Height * 2), 270, 90);
                    back_gp.AddArc(new RectangleF(this.Items[i].BackRectF.X, this.Items[i].BackRectF.Y - this.Items[i].BackRectF.Height, this.Items[i].BackRectF.Height * 2, this.Items[i].BackRectF.Height * 2), 90, 90);
                    back_gp.CloseFigure();
                    if (this.Items[i].Path == null)
                    {
                        this.Items[i].Path = back_gp;
                    }
                    else
                    {
                        this.Items[i].Path.Reset();
                        this.Items[i].Path = back_gp;
                    }
                }
            }
            #endregion
            #region Symbol
            else if (this.ItemStyle == ItemStyles.Symbol)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width, item_height);
                    this.Items[i].SymbolRectF = new RectangleF(this.Items[i].BackRectF.Right + this.ItemInterval, item_y + this.Items[i].TextSize.Height / 6f, item_height / 2f, item_height - this.Items[i].TextSize.Height / 6f * 2);
                    item_x += this.Items[i].BackRectF.Width + this.ItemInterval + this.Items[i].SymbolRectF.Width + this.ItemInterval;
                }
            }
            #endregion
            #region ObliqueLine
            else if (this.ItemStyle == ItemStyles.ObliqueLine)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].TextSize = this.GetItemTextSize(g, this.Items[i].Text);
                    this.Items[i].BackRectF = new RectangleF(item_x, item_y, this.Items[i].TextSize.Width, item_height);
                    this.Items[i].SymbolRectF = new RectangleF(this.Items[i].BackRectF.Right + this.ItemInterval, item_y, item_height / 4f * 2f, item_height);
                    item_x += this.Items[i].BackRectF.Width + this.ItemInterval + this.Items[i].SymbolRectF.Width + this.ItemInterval;
                }
            }
            #endregion

            g.Dispose();
        }

        /// <summary>
        /// 获取选项文本size
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text">选项文本</param>
        /// <returns></returns>
        private SizeF GetItemTextSize(Graphics g, string text)
        {
            SizeF text_size = g.MeasureString(text, this.ItemTextFont);
            text_size = new SizeF(text_size.Width + 1, text_size.Height);
            if (this.ItemMinWidth > 0)
            {
                text_size.Width = Math.Max(text_size.Width, this.ItemMinWidth);
            }
            if (this.ItemMaxWidth > 0)
            {
                text_size.Width = Math.Min(text_size.Width, this.ItemMaxWidth);
            }
            return text_size;
        }

        /// <summary>
        /// 绘制选项
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <param name="item"></param>
        /// <param name="g"></param>
        /// <param name="back_sb"></param>
        /// <param name="text_sb"></param>
        private void DrawItem(int itemIndex, NavigationBarItem item, Graphics g, SolidBrush back_sb, SolidBrush text_sb)
        {
            #region Arrows
            if (this.ItemStyle == ItemStyles.Arrows)
            {
                g.FillPath(back_sb, item.Path);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF((item.BackRectF.X + item.BackRectF.Height / 2), item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.Path);
                }
            }
            #endregion
            #region Symbol
            else if (this.ItemStyle == ItemStyles.Symbol)
            {
                g.FillRectangle(back_sb, item.BackRectF);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF(item.BackRectF.X, item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.BackRectF);
                }

                if (itemIndex < this.Items.Count - 1)
                {
                    float w = item.SymbolRectF.Width - 4;
                    Pen arrows_pen = new Pen(this.SymbolColor, 2);
                    g.DrawLine(arrows_pen, item.SymbolRectF.X, item.SymbolRectF.Y, item.SymbolRectF.X + w / 6 * 5, item.SymbolRectF.Y + item.SymbolRectF.Height / 2);
                    g.DrawLine(arrows_pen, item.SymbolRectF.X + w / 6 * 5, item.SymbolRectF.Y + item.SymbolRectF.Height / 2, item.SymbolRectF.X, item.SymbolRectF.Y + item.SymbolRectF.Height);

                    g.DrawLine(arrows_pen, item.SymbolRectF.X + w / 6 + 4, item.SymbolRectF.Y, item.SymbolRectF.X + w + 4, item.SymbolRectF.Y + item.SymbolRectF.Height / 2);
                    g.DrawLine(arrows_pen, item.SymbolRectF.X + w + 4, item.SymbolRectF.Y + item.SymbolRectF.Height / 2, item.SymbolRectF.X + w / 6 + 4, item.SymbolRectF.Y + item.SymbolRectF.Height);
                    arrows_pen.Dispose();
                }
            }
            #endregion
            #region ObliqueLine
            else if (this.ItemStyle == ItemStyles.ObliqueLine)
            {
                g.FillRectangle(back_sb, item.BackRectF);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF(item.BackRectF.X, item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.BackRectF);
                }

                if (itemIndex < this.Items.Count - 1)
                {
                    Pen arrows_pen = new Pen(this.SymbolColor, 2);
                    arrows_pen.StartCap = LineCap.Round;
                    arrows_pen.EndCap = LineCap.Round;
                    g.DrawLine(arrows_pen, item.SymbolRectF.X, item.SymbolRectF.Y + (item.SymbolRectF.Height - item.TextSize.Height) / 2f + item.TextSize.Height / 6, item.SymbolRectF.Right, item.SymbolRectF.Bottom - (item.SymbolRectF.Height - item.TextSize.Height) / 2f - item.TextSize.Height / 6);
                    arrows_pen.Dispose();
                }
            }
            #endregion
            #region Parallelogram
            else if (this.ItemStyle == ItemStyles.Parallelogram)
            {
                g.FillPath(back_sb, item.Path);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF((item.BackRectF.X + item.BackRectF.Height / 2), item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.Path);
                }
            }
            #endregion
            #region Quadrangle
            else if (this.ItemStyle == ItemStyles.Quadrangle)
            {
                g.FillRectangle(back_sb, item.BackRectF);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF(item.BackRectF.X, item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.BackRectF);
                }
            }
            #endregion
            #region RoundCap
            else if (this.ItemStyle == ItemStyles.RoundCap)
            {
                g.FillPath(back_sb, item.Path);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF((item.BackRectF.X + item.BackRectF.Height / 2), item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.Path);
                }
            }
            #endregion
            #region Circular
            else if (this.ItemStyle == ItemStyles.Circular)
            {
                g.FillPath(back_sb, item.Path);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF(item.BackRectF.X, item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.Path);
                }
            }
            #endregion
            #region Leaf
            else if (this.ItemStyle == ItemStyles.Leaf)
            {
                g.FillPath(back_sb, item.Path);

                g.DrawString(item.Text, this.ItemTextFont, text_sb, new RectangleF((item.BackRectF.X + item.BackRectF.Height / 2), item.BackRectF.Y + (item.BackRectF.Height - item.TextSize.Height) / 2f, item.BackRectF.Width, item.BackRectF.Height), this.text_sf);

                if (this.activatedState && this.activatedStateIndex == itemIndex)
                {
                    this.DrawActivatedBorder(g, item.Path);
                }
            }
            #endregion
        }

        /// <summary>
        /// 绘制激活选项边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="path"></param>
        private void DrawActivatedBorder(Graphics g, GraphicsPath path)
        {
            Pen item_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
            g.DrawPath(item_pen, path);
            item_pen.Dispose();
        }

        /// <summary>
        /// 绘制激活选项边框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectf"></param>
        private void DrawActivatedBorder(Graphics g, RectangleF rectf)
        {
            Pen item_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
            g.DrawRectangle(item_pen, rectf.X, rectf.Y, rectf.Width, rectf.Height);
            item_pen.Dispose();
        }

        #endregion

        #region 类

        /// <summary>
        /// 导航选项集合
        /// </summary>
        [Description("导航选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class NavigationBarItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList navigationBarItemList = new ArrayList();
            private NavigationBarExt owner;

            public NavigationBarItemCollection(NavigationBarExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                NavigationBarItem[] listArray = new NavigationBarItem[this.navigationBarItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (NavigationBarItem)this.navigationBarItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.navigationBarItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.navigationBarItemList.Count;
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
                if (!(value is NavigationBarItem))
                {
                    throw new ArgumentException("NavigationBarItem");
                }
                return this.Add((NavigationBarItem)value);
            }

            public int Add(NavigationBarItem item)
            {
                this.navigationBarItemList.Add(item);
                this.owner.InitializeItemsRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.navigationBarItemList.Clear();
                this.owner.InitializeItemsRectangle();
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
                if (item is NavigationBarItem)
                {
                    return this.Contains((NavigationBarItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is NavigationBarItem)
                {
                    return this.navigationBarItemList.IndexOf(item);
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
                if (!(value is NavigationBarItem))
                {
                    throw new ArgumentException("DisplayImageItem");
                }
                this.Remove((NavigationBarItem)value);
            }

            public void Remove(NavigationBarItem item)
            {
                this.navigationBarItemList.Remove(item);
                this.owner.InitializeItemsRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.navigationBarItemList.RemoveAt(index);
                this.owner.InitializeItemsRectangle();
                this.owner.Invalidate();
            }

            public NavigationBarItem this[int index]
            {
                get
                {
                    return (NavigationBarItem)this.navigationBarItemList[index];
                }
                set
                {
                    this.navigationBarItemList[index] = (NavigationBarItem)value;
                    this.owner.InitializeItemsRectangle();
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.navigationBarItemList[index];
                }
                set
                {
                    this.navigationBarItemList[index] = (NavigationBarItem)value;
                    this.owner.InitializeItemsRectangle();
                }
            }

            #endregion

        }

        /// <summary>
        /// 实际坐标
        /// </summary>
        [Description("实际坐标")]
        public class NavigationBarItem
        {
            private bool selected = false;
            /// <summary>
            /// 选项是否选中
            /// </summary>
            [Browsable(false)]
            [DefaultValue(false)]
            [Description("选项是否选中")]
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

            private ItemStatuss itemStatus = ItemStatuss.Normal;
            /// <summary>
            /// 选项状态
            /// </summary>
            [Browsable(false)]
            [DefaultValue(ItemStatuss.Normal)]
            [Description("导航选项状态")]
            public ItemStatuss ItemStatus
            {
                get { return this.itemStatus; }
                set
                {
                    if (this.itemStatus == value)
                        return;
                    this.itemStatus = value;
                }
            }

            private string text;
            /// <summary>
            /// 文本
            /// </summary>
            [DefaultValue("")]
            [Description("文本")]
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

            private Color normalBackColor = Color.Empty;
            /// <summary>
            /// 选项背景颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项背景颜色（正常）")]
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
            /// 选项文本颜色（正常）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项文本颜色（正常）")]
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
            /// 选项背景颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项背景颜色（鼠标进入）")]
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
            /// 选项文本颜色（鼠标进入）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项文本颜色（鼠标进入）")]
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
            /// 选项背景颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项背景颜色（选中）")]
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
            /// 选项文本颜色（选中）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项文本颜色（选中）")]
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
            /// 选项背景颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项背景颜色（禁止）")]
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
            /// 选项文本颜色（禁止）
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("选项文本颜色（禁止）")]
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

            private RectangleF backRectF;
            /// <summary>
            /// 选项背景RectF
            /// </summary>
            [Browsable(false)]
            [Description("选项背景RectF")]
            public RectangleF BackRectF
            {
                get { return this.backRectF; }
                set
                {
                    if (this.backRectF == value)
                        return;
                    this.backRectF = value;
                }
            }

            private SizeF textSize;
            /// <summary>
            /// 选项文字SizeF
            /// </summary>
            [Browsable(false)]
            [Description("选项文字SizeF")]
            public SizeF TextSize
            {
                get { return this.textSize; }
                set
                {
                    if (this.textSize == value)
                        return;
                    this.textSize = value;
                }
            }

            private RectangleF symbolRectF;
            /// <summary>
            /// 符号RectF
            /// </summary>
            [Browsable(false)]
            [Description("符号RectF")]
            public RectangleF SymbolRectF
            {
                get { return this.symbolRectF; }
                set
                {
                    if (this.symbolRectF == value)
                        return;
                    this.symbolRectF = value;
                }
            }

            private GraphicsPath path = null;
            /// <summary>
            /// 不规则图形路径
            /// </summary>
            [Browsable(false)]
            [Description("不规则图形路径")]
            public GraphicsPath Path
            {
                get { return this.path; }
                set
                {
                    if (this.path == value)
                        return;
                    this.path = value;
                }
            }

        }

        /// <summary>
        /// 导航选项单击事件参数
        /// </summary>
        [Description("导航选项单击事件参数")]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 导航选项
            /// </summary>
            [Description("导航选项")]
            public NavigationBarItem Item { get; set; }
        }

        /// <summary>
        /// 导航选中选项更改事件参数
        /// </summary>
        [Description("导航选中选项更改事件参数")]
        public class SelectedChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 选中选项
            /// </summary>
            [Description("选中选项")]
            public NavigationBarItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 导航选项状态
        /// </summary>
        [Description("导航选项状态")]
        public enum ItemStatuss
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
        /// 导航样式
        /// </summary>
        [Description("导航样式")]
        public enum ItemStyles
        {
            /// <summary>
            /// 箭头
            /// </summary>
            Arrows,
            /// <summary>
            /// 符号
            /// </summary>
            Symbol,
            /// <summary>
            /// 斜线
            /// </summary>
            ObliqueLine,
            /// <summary>
            /// 平行四边形
            /// </summary>
            Parallelogram,
            /// <summary>
            /// 四边形
            /// </summary>
            Quadrangle,
            /// <summary>
            /// 圆帽
            /// </summary>
            RoundCap,
            /// <summary>
            /// 圆角
            /// </summary>
            Circular,
            /// <summary>
            /// 叶子
            /// </summary>
            Leaf
        }

        #endregion
    }
}
