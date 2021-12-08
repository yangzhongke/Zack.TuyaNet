
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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;
using System.Diagnostics;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// GDI不规则圆弧菜单控件(窗体版)句柄
    /// </summary>
    [ToolboxItem(true)]
    [Description("GDI不规则圆弧菜单控件(窗体版)句柄")]
    [DefaultProperty("Rmec")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class RadianMenuHandleButtonExt : Control
    {
        #region 新增事件

        public delegate void DrawEventHandler(object sender, PaintEventArgs e);

        private event DrawEventHandler draw;
        /// <summary>
        /// 自定义绘制事件
        /// </summary>
        [Description("自定义绘制事件")]
        public event DrawEventHandler Draw
        {
            add { this.draw += value; }
            remove { this.draw -= value; }
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

        private bool customDraw = false;
        /// <summary>
        /// 是否自定义绘制句柄界面
        /// </summary>
        [Description("是否自定义绘制句柄界面")]
        [DefaultValue(false)]
        public bool CustomDraw
        {
            get { return this.customDraw; }
            set
            {
                if (this.customDraw == value)
                    return;

                this.customDraw = value;
                this.Invalidate();
            }
        }

        private RadianMenuComponentExt rmce = null;
        /// <summary>
        ///  GDI不规则圆弧菜单控件(窗体版)
        /// </summary>
        [Description(" GDI不规则圆弧菜单控件(窗体版)")]
        [DefaultValue(null)]
        public RadianMenuComponentExt Rmce
        {
            get { return this.rmce; }
            set
            {
                if (this.rmce == value)
                    return;

                if (value == null)
                {
                    if (this.rmce != null)
                    {
                        this.rmce.OwnerControl = null;
                    }
                    this.rmce = value;
                }
                else
                {
                    this.rmce = value;
                    this.rmce.OwnerControl = this;
                }

                this.Invalidate();
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
        private bool activatedStatus = false;

        /// <summary>
        /// 是否按下单击事件
        /// </summary>
        private bool isClickDown = false;

        #endregion

        public RadianMenuHandleButtonExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, true);

        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.rmce != null && !this.rmce.LayerVisible)//圆弧菜单未显示
            {
                #region 自定义绘制控件界面
                if (this.CustomDraw)
                {
                    this.OnDraw(e);
                }
                #endregion
                #region 默认控件界面绘制事件
                else
                {
                    if (this.rmce != null && this.rmce.Items.Count > 0)
                    {
                        Graphics g = e.Graphics;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        float diameter = this.rmce.CircleRadius * 2 - 2;//直径
                        RectangleF radian_rect = new RectangleF(this.ClientRectangle.X + (this.ClientRectangle.Width - diameter) / 2, this.ClientRectangle.Y + (this.ClientRectangle.Height - diameter) / 2, diameter, diameter);

                        #region 控件形状
                        GraphicsPath rect_gp = new GraphicsPath();
                        rect_gp.AddEllipse(radian_rect);
                        e.Graphics.SetClip(rect_gp);
                        rect_gp.Dispose();
                        #endregion

                        #region 背景
                        SolidBrush radian_sb = new SolidBrush(this.rmce.Items[0].RadianBackColor);
                        g.FillEllipse(radian_sb, new RectangleF(radian_rect.X + 1, radian_rect.Y + 1, radian_rect.Width - 2, radian_rect.Height - 2));
                        radian_sb.Dispose();
                        #endregion

                        #region 激活边框
                        if (this.activatedStatus)
                        {
                            Pen activeborder_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
                            g.DrawEllipse(activeborder_pen, new RectangleF(radian_rect.X + 2, radian_rect.Y + 2, radian_rect.Width - 4, radian_rect.Height - 4));
                            activeborder_pen.Dispose();
                        }
                        #endregion

                        #region 文本
                        if (!String.IsNullOrWhiteSpace(this.rmce.Items[0].Text) && this.rmce.TextFont != null)
                        {
                            SolidBrush text_sb = new SolidBrush(this.rmce.Items[0].RadianTextColor);
                            SizeF str_size = this.rmce.Items[0].RadianTextSize;
                            str_size = new SizeF(str_size.Width + 2f, str_size.Height + 2f);
                            g.DrawString(this.rmce.Items[0].Text, this.rmce.TextFont, text_sb, new RectangleF(this.ClientRectangle.X + (this.ClientRectangle.Width - str_size.Width) / 2, this.ClientRectangle.Y + (this.ClientRectangle.Height - str_size.Height) / 2, str_size.Width, str_size.Height));
                            text_sb.Dispose();
                        }
                        #endregion
                    }
                }
                #endregion
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            this.activatedStatus = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedStatus = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.Select();
            this.isClickDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.isClickDown = false;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.isClickDown = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.DesignMode)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.rmce != null && !this.rmce.LayerVisible)
                {
                    this.rmce.ShowLayerView();
                }
            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.DesignMode)
                return base.ProcessDialogKey(keyData);

            #region Up
            if (keyData == Keys.Up)
            {
                if (this.rmce != null && !this.rmce.LayerVisible)
                {
                    this.rmce.ShowLayerView();
                    return false;
                }
            }
            #endregion
            return base.ProcessDialogKey(keyData);
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Rmce != null)
                    this.Rmce.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnDraw(PaintEventArgs e)
        {
            if (this.draw != null)
            {
                this.draw(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 显示圆弧菜单分层界面
        /// </summary>
        public void ShowLayerView()
        {
            if (this.rmce != null)
            {
                this.rmce.ShowLayerView();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 隐藏圆弧菜单分层界面
        /// </summary>
        public void HideLayerView()
        {
            if (this.rmce != null)
            {
                this.rmce.HideLayerView();
                this.Invalidate();
            }
        }

        #endregion

    }

    /// <summary>
    /// GDI不规则圆弧菜单控件(窗体版)
    /// </summary>
    [ToolboxItem(true)]
    [Description("不规则圆弧菜单控件(窗体版)")]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    public class RadianMenuComponentExt : Component
    {
        #region 新增事件

        public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);

        private event ItemClickEventHandler itemClick;
        /// <summary>
        /// 圆弧选项单击事件
        /// </summary>
        [Description("圆弧选项单击事件")]
        public event ItemClickEventHandler ItemClick
        {
            add { this.itemClick += value; }
            remove { this.itemClick -= value; }
        }

        #endregion

        #region 新增属性

        private bool enabled = true;
        /// <summary>
        /// 是否启用控件
        /// </summary>
        [DefaultValue(true)]
        [Description("是否启用控件")]
        public bool Enabled
        {
            get { return this.enabled; }
            set
            {
                if (this.enabled == value)
                    return;

                this.enabled = value;
                this.rml.Enabled = this.enabled;
                this.timer.Enabled = this.Enabled;
            }
        }

        private Control ownerControl = null;
        /// <summary>
        /// 圆弧菜单分层所属的控件
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        [Description("圆弧菜单分层所属的控件")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control OwnerControl
        {
            get { return this.ownerControl; }
            set
            {
                if (this.ownerControl == value)
                    return;

                this.ownerControl = value;
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
                this.InvalidateLayer();
            }
        }

        private int circleRadius = 50;
        /// <summary>
        /// 圆半径
        /// </summary>
        [DefaultValue(50)]
        [Description("圆半径(默认50)")]
        public int CircleRadius
        {
            get { return this.circleRadius; }
            set
            {
                if (this.circleRadius == value || value < 1)
                    return;

                this.circleRadius = value;
                this.UpdateLayerSizeLocation();
                this.InitializeRectangle();
                this.InvalidateLayer();
            }
        }

        private int radianOpacity = 150;
        /// <summary>
        /// 圆弧透明度(0-255)
        /// </summary>
        [DefaultValue(150)]
        [Description("圆弧透明度(0-255)(默认150)")]
        public int RadianOpacity
        {
            get { return this.radianOpacity; }
            set
            {
                if (this.radianOpacity == value || this.radianOpacity < 0 || this.radianOpacity > 255)
                    return;

                this.radianOpacity = value;
                this.InvalidateLayer();
            }
        }

        private int radianTextOpacity = 220;
        /// <summary>
        /// 圆弧文字透明度(0-255)
        /// </summary>
        [DefaultValue(220)]
        [Description("圆弧文字透明度(0-255)(默认220)")]
        public int RadianTextOpacity
        {
            get { return this.radianTextOpacity; }
            set
            {
                if (this.radianTextOpacity == value || this.radianTextOpacity < 0 || this.radianTextOpacity > 255)
                    return;

                this.radianTextOpacity = value;
                this.InvalidateLayer();
            }
        }

        private int radianWidth = 36;
        /// <summary>
        /// 圆弧宽度
        /// </summary>
        [DefaultValue(36)]
        [Description("圆弧宽度(默认36)")]
        public int RadianWidth
        {
            get { return this.radianWidth; }
            set
            {
                if (this.radianWidth == value || value < 0)
                    return;

                this.radianWidth = value;
                this.UpdateLayerSizeLocation();
                this.InitializeRectangle();
                this.InvalidateLayer();
            }
        }

        private int radianZoonTime = 300;
        /// <summary>
        /// 圆弧缩放动画播放的总时间(默认300毫秒)
        /// </summary>
        [DefaultValue(1000)]
        [Description("圆弧缩放动画播放的总时间(默认300毫秒)")]
        public int RadianZoonTime
        {
            get { return this.radianZoonTime; }
            set
            {
                this.radianZoonTime = value;
                this.radianZoomOptions.AllTransformTime = this.radianZoonTime;
            }
        }

        private int radianWidthShakeLargen = 10;
        /// <summary>
        /// 圆弧宽度震动时放大值(默认10)
        /// </summary>
        [DefaultValue(10)]
        [Description("圆弧宽度震动时放大值(默认10)")]
        public int RadianWidthShakeLargen
        {
            get { return this.radianWidthShakeLargen; }
            set
            {
                if (this.radianWidthShakeLargen == value || value < 0)
                    return;

                this.radianWidthShakeLargen = value;
                this.UpdateLayerSizeLocation();
                this.InitializeRectangle();
                this.InvalidateLayer();
            }
        }

        private int radianShakeTime = 350;
        /// <summary>
        /// 圆弧震动动画播放的总时间(默认350毫秒)
        /// </summary>
        [DefaultValue(350)]
        [Description("圆弧震动动画播放的总时间(默认350毫秒)")]
        public int RadianShakeTime
        {
            get
            {
                return this.radianShakeTime;
            }
            set
            {
                this.radianShakeTime = value;
                this.radianShakeOptions.AllTransformTime = this.radianShakeTime;
            }
        }

        private bool radianIsRotate = false;
        /// <summary>
        /// 圆弧是否旋转动画
        /// </summary>
        [DefaultValue(false)]
        [Description("圆弧是否旋转动画")]
        public bool RadianIsRotate
        {
            get { return this.radianIsRotate; }
            set
            {
                if (this.radianIsRotate == value)
                    return;
                this.radianIsRotate = value;

                if (this.radianIsRotate)
                {
                    if (this.Enabled && !this.DesignMode && this.radianZoonStatus == RadianZoonStatuss.Max)
                    {
                        for (int i = 1; i < this.Items.Count; i++)
                        {
                            this.Items[i].RadianRotateIng = true;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].RadianRotateIng = false; ;
                    }
                }
            }
        }

        private int radianRotateTime = 1000;
        /// <summary>
        /// 圆弧旋转动画播放的总时间(默认1000毫秒)
        /// </summary>
        [DefaultValue(1000)]
        [Description("圆弧旋转动画播放的总时间(默认1000毫秒)")]
        public int RadianRotateTime
        {
            get { return this.radianRotateTime; }
            set
            {
                this.radianRotateTime = value;
                this.radianRotateOptions.AllTransformTime = this.radianRotateTime;
            }
        }

        private Font textFont = new Font("幼圆", 12, FontStyle.Bold);
        /// <summary>
        /// 文本字体
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Font), "幼圆, 12pt, style=Bold")]
        [Description("文本字体")]
        public Font TextFont
        {
            get
            {
                if (this.textFont == null)
                    textFont = new Font("幼圆", 12, FontStyle.Bold);
                return this.textFont;
            }
            set
            {
                if (this.textFont == value)
                    return;
                this.textFont = value;

                this.InitializeText();
                this.InitializeRectangle();
                this.InvalidateLayer();
            }
        }

        /// <summary>
        /// 圆弧菜单分层是否已显示
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("圆弧菜单分层是否已显示")]
        public bool LayerVisible
        {
            get { return this.rml.Visible; }

        }

        private RadianMenuItemCollection radianMenuItemCollection;
        /// <summary>
        /// 圆弧选项配置列表
        /// </summary>
        [Description("圆弧选项配置列表")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadianMenuItemCollection Items
        {
            get
            {
                if (this.radianMenuItemCollection == null)
                    this.radianMenuItemCollection = new RadianMenuItemCollection(this);
                return this.radianMenuItemCollection;
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

        #endregion

        #region 字段

        /// <summary>
        /// 控件激活状态
        /// </summary>
        private bool activatedStatus = false;

        /// <summary>
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStatusIndex = -1;

        /// <summary>
        /// 控件缩放状态
        /// </summary>
        private RadianZoonStatuss radianZoonStatus = RadianZoonStatuss.Min;

        /// <summary>
        /// 是否启动缩放定时器部分
        /// </summary>
        private bool radianZoomIng = false;

        /// <summary>
        /// 选项缩放已使用的时间
        /// </summary>
        private float radianZoomUsedTime;

        /// <summary>
        /// 圆弧背景色
        /// </summary>
        private SolidBrush radian_sb = new SolidBrush(Color.White);

        /// <summary>
        /// 圆弧文本颜色
        /// </summary>
        private SolidBrush text_sb = new SolidBrush(Color.White);

        /// <summary>
        /// 文本格式
        /// </summary>
        private StringFormat text_sf = new StringFormat() { FormatFlags = StringFormatFlags.NoClip, Trimming = StringTrimming.None, Alignment = StringAlignment.Center };

        /// <summary>
        /// 圆弧菜单分层
        /// </summary>
        private RadianMenuLayer rml = null;

        /// <summary>
        ///动画对象
        /// </summary>
        private Timer timer = null;

        /// <summary>
        /// 选项缩放总配置
        /// </summary>
        private AnimationOptions radianZoomOptions = new AnimationOptions();

        /// <summary>
        /// 选项震动总配置
        /// </summary>
        private AnimationOptions radianShakeOptions = new AnimationOptions();

        /// <summary>
        /// 选项旋转总配置
        /// </summary>
        private AnimationOptions radianRotateOptions = new AnimationOptions();

        #endregion

        #region 扩展

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        #endregion

        public RadianMenuComponentExt(IContainer container)
        {
            this.rml = new RadianMenuLayer(this);
            this.rml.Enabled = this.Enabled;
            this.radianZoomOptions.AllTransformTime = this.radianZoonTime;
            this.radianShakeOptions.AllTransformTime = this.radianShakeTime;
            this.radianRotateOptions.AllTransformTime = this.radianRotateTime;

            this.UpdateLayerSizeLocation();

            if (!this.DesignMode)
            {
                this.timer = new Timer();
                this.timer.Interval = 56;
                this.timer.Tick += new EventHandler(this.timer_Animationing);
                this.timer.Enabled = this.Enabled;
            }

            if (container == null)
                throw new ArgumentNullException("container");
            container.Add(this);
        }

        #region 重写

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.timer != null)
                    this.timer.Dispose();

                if (this.radian_sb != null)
                    this.radian_sb.Dispose();

                if (this.text_sb != null)
                    this.text_sb.Dispose();

                if (this.text_sf != null)
                    this.text_sf.Dispose();

                if (this.TextFont != null)
                    this.TextFont.Dispose();

                if (this.rml != null)
                    this.rml.Dispose();

                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].RadianNowPath != null)
                        this.Items[i].RadianNowPath.Dispose();
                }
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

        #endregion

        #region 公开方法

        /// <summary>
        /// 使分层控件的整个图面无效并导致重绘控件
        /// </summary>
        public void InvalidateLayer()
        {
            this.rml.InvalidateLayer();
        }

        /// <summary>
        /// 显示圆弧菜单分层界面
        /// </summary>
        public void ShowLayerView()
        {
            if (!this.Enabled)
                return;

            if (this.DesignMode || this.LayerVisible)
                return;

            #region 全局控件
            if (this.OwnerControl == null)
            {
                this.rml.TopMost = true;
                this.rml.Show();
                this.UpdateLayerMinRectangle();
                this.rml.InvalidateLayer();
            }
            #endregion
            #region 局部控件
            else
            {
                Point point = this.OwnerControl.PointToScreen(new Point(0, 0));
                this.rml.SetBounds(point.X + (this.OwnerControl.Width) / 2 - this.rml.Width / 2, point.Y + (this.OwnerControl.Height) / 2 - this.rml.Height / 2, this.rml.Width, this.rml.Height, BoundsSpecified.Location);
                this.rml.Show();
                this.UpdateLayerMinRectangle();
                this.rml.InvalidateLayer();
                this.MaxLayerView();
            }
            #endregion
        }

        /// <summary>
        /// 隐藏圆弧菜单分层界面
        /// </summary>
        public void HideLayerView()
        {
            if (!this.Enabled)
                return;

            if (this.OwnerControl != null)
            {
                if (this.RadianIsRotate == true)
                {
                    for (int i = 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].RadianRotateIng = false;
                    }
                }
                this.UpdateLayerMinRectangle();
                this.radianZoonStatus = RadianZoonStatuss.Min;
                this.rml.Hide();
            }
        }

        /// <summary>
        /// 缩放功能放大
        /// </summary>
        public void MaxLayerView()
        {
            if (!this.Enabled)
                return;

            if (this.radianZoonStatus == RadianZoonStatuss.Min || this.radianZoonStatus == RadianZoonStatuss.Mining)
            {
                this.StopZoomTimer();
                this.radianZoonStatus = RadianZoonStatuss.Maxing;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].RadianZoonBeforeRectF = this.Items[i].RadianNowRectF;
                    this.Items[i].RadianZoonProgress = 0f;
                }
                this.StartZoomTimer(this.radianZoomUsedTime == 0 ? 0 : this.RadianShakeTime - this.radianZoomUsedTime);
            }
        }

        /// <summary>
        /// 缩放功能缩小
        /// </summary>
        public void MinLayerView()
        {
            if (!this.Enabled)
                return;

            if (this.radianZoonStatus == RadianZoonStatuss.Max || this.radianZoonStatus == RadianZoonStatuss.Maxing)
            {
                #region 停止旋转
                if (this.RadianIsRotate == true && this.radianZoonStatus == RadianZoonStatuss.Max)
                {
                    for (int i = 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].RadianRotateIng = false;
                    }
                }
                #endregion
                if (this.activatedStatusIndex > 0)
                {
                    this.activatedStatusIndex = 0;
                }
                #region 缩小
                this.StopZoomTimer();
                this.radianZoonStatus = RadianZoonStatuss.Mining;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    this.Items[i].RadianZoonBeforeRectF = this.Items[i].RadianNowRectF;
                    this.Items[i].RadianZoonProgress = 100f;
                }
                this.StartZoomTimer(this.radianZoomUsedTime == 0 ? 0 : this.RadianShakeTime - this.radianZoomUsedTime);
                #endregion
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化圆弧控件大小位置
        /// </summary>
        private void InitializeRectangle()
        {
            float client_width = this.rml.ClientRectangle.Width;
            float client_height = this.rml.ClientRectangle.Height;
            float diameter = this.CircleRadius * 2;//直径

            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Index = i;
                #region 圆心
                if (i == 0)
                {
                    float w = diameter;
                    float h = diameter;
                    float x = (client_width - w) / 2f;
                    float y = (client_height - h) / 2f;

                    float max_w = w + (float)this.RadianWidthShakeLargen * 2;
                    float max_h = h + (float)this.RadianWidthShakeLargen * 2;
                    float max_x = (client_width - max_w) / 2f;
                    float max_y = (client_height - max_h) / 2f;

                    this.Items[i].RadianNormalRectF = new RectangleF(x, y, w, h);
                    this.Items[i].RadianShakeMaxRectF = new RectangleF(max_x, max_y, max_w, max_h);
                    this.Items[i].RadianNowRectF = this.Items[i].RadianNormalRectF;

                    GraphicsPath gp_out = new GraphicsPath();
                    gp_out.AddEllipse(this.Items[i].RadianNormalRectF);
                    this.Items[i].RadianNowPath = gp_out;
                }
                #endregion
                #region 圆弧
                else
                {
                    float w = diameter + (float)this.RadianWidth * 2 * i;
                    float h = diameter + (float)this.RadianWidth * 2 * i;
                    float x = (client_width - w) / 2f;
                    float y = (client_height - h) / 2f;

                    float max_w = w + (float)this.RadianWidthShakeLargen * 2;
                    float max_h = h + (float)this.RadianWidthShakeLargen * 2;
                    float max_x = (client_width - max_w) / 2f;
                    float max_y = (client_height - max_h) / 2f;

                    this.Items[i].RadianNormalRectF = new RectangleF(x, y, w, h);
                    this.Items[i].RadianShakeMaxRectF = new RectangleF(max_x, max_y, max_w, max_h);
                    this.Items[i].RadianZoonMinRectF = new RectangleF(this.Items[0].RadianNormalRectF.X, this.Items[0].RadianNormalRectF.Y, this.Items[0].RadianNormalRectF.Width, this.Items[0].RadianNormalRectF.Height);
                    this.Items[i].RadianNowRectF = this.Items[i].RadianZoonMinRectF;

                    this.Items[i].RadianNormalThickness = this.RadianWidth;
                    this.Items[i].RadianMaxThickness = this.RadianWidth + this.RadianWidthShakeLargen * 2;
                    this.Items[i].RadianNowThickness = this.RadianWidth;
                    this.Items[i].RadianNowStartAngle = this.Items[i].RadianStartAngle;

                    GraphicsPath gp_out = new GraphicsPath();
                    GraphicsPath gp_in = new GraphicsPath();
                    gp_out.AddArc(this.Items[i].RadianNormalRectF.X, this.Items[i].RadianNormalRectF.Y, this.Items[i].RadianNormalRectF.Width, this.Items[i].RadianNormalRectF.Height, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                    gp_in.AddArc(this.Items[i].RadianNormalRectF.X + this.Items[i].RadianNormalThickness, this.Items[i].RadianNormalRectF.Y + this.Items[i].RadianNormalThickness, this.Items[i].RadianNormalRectF.Width - this.Items[i].RadianNormalThickness * 2, this.Items[i].RadianNormalRectF.Height - this.Items[i].RadianNormalThickness * 2, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                    gp_in.Reverse();
                    gp_out.AddPath(gp_in, true);
                    gp_out.CloseFigure();
                    this.Items[i].RadianNowPath = gp_out;
                }
                #endregion
            }
            this.InitializeText();
        }

        /// <summary>
        /// 初始化圆弧文本size
        /// </summary>
        private void InitializeText()
        {
            IntPtr hDC = GetWindowDC(this.rml.Handle);
            Graphics g = Graphics.FromHdc(hDC);
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].RadianTextSize = g.MeasureString(this.Items[i].Text, this.TextFont);
            }
            g.Dispose();
            ReleaseDC(this.rml.Handle, hDC);
        }

        #region 动画

        private void timer_Animationing(object sender, EventArgs e)
        {
            bool isreset = false;

            #region 缩放
            if (this.radianZoomIng)
            {
                if (this.radianZoonStatus == RadianZoonStatuss.Maxing || this.radianZoonStatus == RadianZoonStatuss.Mining)
                {
                    this.radianZoomUsedTime += this.timer.Interval;
                    if (this.radianZoomUsedTime > this.radianZoomOptions.AllTransformTime)
                    {
                        this.radianZoomUsedTime = (float)this.radianZoomOptions.AllTransformTime;
                    }
                    #region 动画中
                    if (this.radianZoomUsedTime <= this.radianZoomOptions.AllTransformTime)
                    {
                        float pv = (float)AnimationTimer.GetProgress(AnimationTypes.EaseOut, this.radianZoomOptions, this.radianZoomUsedTime);

                        for (int i = 1; i < this.Items.Count; i++)
                        {
                            float w = 0f;
                            float h = 0f;
                            if (this.radianZoonStatus == RadianZoonStatuss.Maxing)
                            {
                                w = (float)(this.Items[i].RadianZoonBeforeRectF.Width + (this.Items[i].RadianNormalRectF.Width - this.Items[i].RadianZoonBeforeRectF.Width) * pv);
                                h = (float)(this.Items[i].RadianZoonBeforeRectF.Height + (this.Items[i].RadianNormalRectF.Height - this.Items[i].RadianZoonBeforeRectF.Height) * pv);
                            }
                            else if (this.radianZoonStatus == RadianZoonStatuss.Mining)
                            {
                                w = (float)(this.Items[i].RadianZoonBeforeRectF.Width - (this.Items[i].RadianZoonBeforeRectF.Width - this.Items[i].RadianZoonMinRectF.Width) * pv);
                                h = (float)(this.Items[i].RadianZoonBeforeRectF.Height - (this.Items[i].RadianZoonBeforeRectF.Height - this.Items[i].RadianZoonMinRectF.Height) * pv);
                            }
                            float x = ((float)this.rml.ClientRectangle.Width - w) / 2f;
                            float y = ((float)this.rml.ClientRectangle.Height - h) / 2f;
                            this.Items[i].RadianNowRectF = new RectangleF(x, y, w, h);
                            this.Items[i].RadianNowThickness = this.Items[i].RadianNormalThickness;

                            GraphicsPath gp_out = new GraphicsPath();
                            GraphicsPath gp_in = new GraphicsPath();
                            gp_out.AddArc(this.Items[i].RadianNowRectF.X, this.Items[i].RadianNowRectF.Y, this.Items[i].RadianNowRectF.Width, this.Items[i].RadianNowRectF.Height, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                            gp_in.AddArc(this.Items[i].RadianNowRectF.X + this.Items[i].RadianNowThickness, this.Items[i].RadianNowRectF.Y + this.Items[i].RadianNowThickness, this.Items[i].RadianNowRectF.Width - this.Items[i].RadianNowThickness * 2, this.Items[i].RadianNowRectF.Height - this.Items[i].RadianNowThickness * 2, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                            gp_in.Reverse();
                            gp_out.AddPath(gp_in, true);
                            gp_out.CloseFigure();
                            GraphicsPath gp_dis = this.Items[i].RadianNowPath;
                            this.Items[i].RadianNowPath = gp_out;
                            gp_dis.Dispose();
                            this.Items[i].RadianZoonProgress = (float)(pv * 100);
                        }

                        isreset = true;
                        #region 动画结束
                        if (this.radianZoomUsedTime == this.radianZoomOptions.AllTransformTime)
                        {
                            this.ZoomEnd();
                        }
                        #endregion

                    }
                    #endregion
                }
            }

            #endregion
            #region 震动
            for (int i = 0; i < this.Items.Count; i++)
            {
                RadianMenuItem rmi = this.Items[i];
                if (rmi.RadianShakeIng)
                {
                    if (this.Items[i].RadianMouseStatus == RadianMouseStatuss.EnterAnimation || this.Items[i].RadianMouseStatus == RadianMouseStatuss.LeaveAnimation)
                    {
                        AnimationTypes at = AnimationTypes.ElasticOut;

                        #region 动画中
                        #region
                        if (this.Items[i].RadianShakeForward)
                        {
                            this.Items[i].RadianShakeUsedTime += this.timer.Interval;
                            if (this.Items[i].RadianShakeUsedTime > this.radianShakeOptions.AllTransformTime)
                            {
                                this.Items[i].RadianShakeUsedTime = (float)this.radianShakeOptions.AllTransformTime;
                            }
                        }
                        else
                        {
                            at = AnimationTypes.BackIn;
                            this.Items[i].RadianShakeUsedTime -= this.timer.Interval;
                            if (this.Items[i].RadianShakeUsedTime < 0)
                            {
                                this.Items[i].RadianShakeUsedTime = 0f;
                            }
                        }
                        #endregion
                        if ((!this.Items[i].RadianShakeForward && this.Items[i].RadianShakeUsedTime >= 0) || (this.Items[i].RadianShakeForward && this.Items[i].RadianShakeUsedTime <= this.radianShakeOptions.AllTransformTime))
                        {
                            float pv = (float)AnimationTimer.GetProgress(at, this.radianShakeOptions, this.Items[i].RadianShakeUsedTime);
                            if (this.Items[i].RadianShakeUsedTime == this.radianShakeOptions.AllTransformTime)
                            {
                                pv = 1.0f;
                            }
                            else if (this.Items[i].RadianShakeUsedTime == 0f)
                            {
                                pv = 0.0f;
                            }

                            float largen = this.RadianWidthShakeLargen * pv * 2;
                            float w = (float)(rmi.RadianNormalRectF.Width + largen);
                            float h = (float)(rmi.RadianNormalRectF.Height + largen);
                            float x = ((float)this.rml.ClientRectangle.Width - w) / 2f;
                            float y = ((float)this.rml.ClientRectangle.Height - h) / 2f;
                            rmi.RadianNowRectF = new RectangleF(x, y, w, h);
                            rmi.RadianNowThickness = (int)(rmi.RadianNormalThickness + largen);

                            if (rmi.Index == 0)
                            {
                                GraphicsPath gp_out = new GraphicsPath();
                                gp_out.AddEllipse(rmi.RadianNowRectF);
                                GraphicsPath gp_dis = rmi.RadianNowPath;
                                rmi.RadianNowPath = gp_out;
                                gp_dis.Dispose();
                            }
                            else
                            {
                                GraphicsPath gp_out = new GraphicsPath();
                                GraphicsPath gp_in = new GraphicsPath();
                                gp_out.AddArc(rmi.RadianNowRectF.X, rmi.RadianNowRectF.Y, rmi.RadianNowRectF.Width, rmi.RadianNowRectF.Height, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                                gp_in.AddArc(rmi.RadianNowRectF.X + rmi.RadianNowThickness, rmi.RadianNowRectF.Y + rmi.RadianNowThickness, rmi.RadianNowRectF.Width - rmi.RadianNowThickness * 2, rmi.RadianNowRectF.Height - rmi.RadianNowThickness * 2, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                                gp_in.Reverse();
                                gp_out.AddPath(gp_in, true);
                                gp_out.CloseFigure();
                                GraphicsPath gp_dis = rmi.RadianNowPath;
                                rmi.RadianNowPath = gp_out;
                                gp_dis.Dispose();
                            }
                            isreset = true;
                            #region 动画结束
                            if ((!this.Items[i].RadianShakeForward && this.Items[i].RadianShakeUsedTime == 0) || (this.Items[i].RadianShakeForward && this.Items[i].RadianShakeUsedTime == this.radianShakeOptions.AllTransformTime))
                            {
                                this.ShakEnd(rmi);
                                if (this.Items[i].RadianMouseStatus == RadianMouseStatuss.Leave)
                                {
                                    this.StartRotateTimer(this.Items[i], this.Items[i].RadianRotateUsedTime);
                                }
                            }
                            #endregion

                        }
                        #endregion
                    }
                }
            }
            #endregion
            #region 旋转
            if (this.radianZoonStatus == RadianZoonStatuss.Max && this.RadianIsRotate)
            {
                for (int i = 1; i < this.Items.Count; i++)
                {
                    RadianMenuItem rmi = this.Items[i];
                    if (rmi.RadianRotateIng)
                    {
                        #region 动画中
                        this.Items[i].RadianRotateUsedTime += this.timer.Interval;
                        if (this.Items[i].RadianRotateUsedTime > this.radianRotateOptions.AllTransformTime)
                        {
                            this.Items[i].RadianRotateUsedTime = (float)this.radianRotateOptions.AllTransformTime;
                        }
                        if (this.Items[i].RadianRotateUsedTime <= this.radianRotateOptions.AllTransformTime)
                        {
                            float pv = (float)AnimationTimer.GetProgress(AnimationTypes.UniformMotion, this.radianRotateOptions, this.Items[i].RadianRotateUsedTime);

                            if (rmi.RadianMouseStatus == RadianMouseStatuss.Leave)
                            {
                                if (rmi.RadianRotateOrientation == RadianRotateOrientations.Forward)//旋转方向
                                {
                                    rmi.RadianNowStartAngle = rmi.RadianStartAngle + rmi.RadianRotateValue * pv;
                                }
                                else
                                {
                                    rmi.RadianNowStartAngle = (rmi.RadianStartAngle + rmi.RadianRotateValue) - rmi.RadianRotateValue * pv;
                                }

                                GraphicsPath gp_out = new GraphicsPath();
                                GraphicsPath gp_in = new GraphicsPath();
                                gp_out.AddArc(rmi.RadianNormalRectF.X, rmi.RadianNormalRectF.Y, rmi.RadianNormalRectF.Width, rmi.RadianNormalRectF.Height, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                                gp_in.AddArc(rmi.RadianNormalRectF.X + rmi.RadianNormalThickness, rmi.RadianNormalRectF.Y + rmi.RadianNormalThickness, rmi.RadianNormalRectF.Width - rmi.RadianNormalThickness * 2, rmi.RadianNormalRectF.Height - rmi.RadianNormalThickness * 2, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                                gp_in.Reverse();
                                gp_out.AddPath(gp_in, true);
                                gp_out.CloseFigure();
                                GraphicsPath gp_dis = rmi.RadianNowPath;
                                rmi.RadianNowPath = gp_out;
                                gp_dis.Dispose();

                                isreset = true;

                                #region 动画结束
                                if (this.Items[i].RadianRotateUsedTime == this.radianRotateOptions.AllTransformTime)
                                {
                                    this.StopRotateTimer(rmi);
                                    rmi.RadianRotateOrientation = (rmi.RadianRotateOrientation == RadianRotateOrientations.Forward) ? RadianRotateOrientations.Inversion : RadianRotateOrientations.Forward;
                                    this.StartRotateTimer(rmi, 0f);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion

            if (isreset)
            {
                this.InvalidateLayer();
            }
        }

        /// <summary>
        /// 启动定时器的菜单缩放处理功能
        /// </summary>
        /// <param name="time"></param>
        private void StartZoomTimer(float time)
        {
            this.radianZoomUsedTime = time;
            this.radianZoomIng = true;
        }

        /// <summary>
        /// 停止定时器的菜单缩放处理功能
        /// </summary>
        private void StopZoomTimer()
        {
            this.radianZoomIng = false;
        }

        /// <summary>
        /// 菜单缩放结束
        /// </summary>
        private void ZoomEnd()
        {
            if (this.radianZoonStatus == RadianZoonStatuss.Mining)
            {
                this.radianZoonStatus = RadianZoonStatuss.Min;
                if (this.OwnerControl != null)
                {
                    this.HideLayerView();
                }
            }
            else if (this.radianZoonStatus == RadianZoonStatuss.Maxing)
            {
                this.radianZoonStatus = RadianZoonStatuss.Max;
                if (this.RadianIsRotate == true)
                {
                    for (int i = 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].RadianRotateIng = true;
                    }
                }
            }
            this.StopZoomTimer();
            this.radianZoomUsedTime = 0;
        }

        /// <summary>
        /// 启动定时器的菜单选项震动处理功能
        /// </summary>
        /// <param name="rmi"></param>
        /// <param name="usedTime"></param>
        private void StartShakeTimer(RadianMenuItem rmi, float usedTime)
        {
            rmi.RadianShakeUsedTime = usedTime;
            rmi.RadianShakeIng = true;
        }

        /// <summary>
        /// 停止定时器的菜单选项震动处理功能
        /// </summary>
        /// <param name="rmi"></param>
        private void StopShakeTimer(RadianMenuItem rmi)
        {
            rmi.RadianShakeIng = false;
        }

        /// <summary>
        /// 圆弧选项震动结束
        /// </summary>
        /// <param name="rmi"></param>
        private void ShakEnd(RadianMenuItem rmi)
        {
            if (rmi.RadianMouseStatus == RadianMouseStatuss.LeaveAnimation)
            {
                rmi.RadianMouseStatus = RadianMouseStatuss.Leave;
            }
            else if (rmi.RadianMouseStatus == RadianMouseStatuss.EnterAnimation)
            {
                rmi.RadianMouseStatus = RadianMouseStatuss.Enter;
            }
            this.StopShakeTimer(rmi);
            rmi.RadianShakeUsedTime = 0;
            rmi.RadianShakeForward = true;
        }

        /// <summary>
        /// 启动定时器的菜单选项旋转处理功能
        /// </summary>
        /// <param name="rmi"></param>
        /// <param name="usedTime"></param>
        private void StartRotateTimer(RadianMenuItem rmi, float usedTime)
        {
            rmi.RadianRotateUsedTime = usedTime;
            rmi.RadianRotateIng = true;
        }

        /// <summary>
        /// 停止定时器的菜单选项旋转处理功能
        /// </summary>
        /// <param name="rmi"></param>
        private void StopRotateTimer(RadianMenuItem rmi)
        {
            rmi.RadianRotateIng = false;
        }

        #endregion

        #region 分层

        /// <summary>
        /// 更新分层菜单Size、Location
        /// </summary>
        private void UpdateLayerSizeLocation()
        {
            float diameter = this.CircleRadius * 2;//直径
            float w = diameter + (float)this.RadianWidth * 2 * this.Items.Count;
            float h = diameter + (float)this.RadianWidth * 2 * this.Items.Count;
            float max_w = w + (float)this.RadianWidthShakeLargen * 2;
            float max_h = h + (float)this.RadianWidthShakeLargen * 2;
            this.rml.SetBounds(this.rml.Location.X, this.rml.Location.Y, (int)max_w, (int)max_h);

            this.InvalidateLayer();
        }

        /// <summary>
        /// 更新分层菜单最小化后圆弧选项的rect
        /// </summary>
        private void UpdateLayerMinRectangle()
        {
            for (int i = 1; i < this.Items.Count; i++)
            {
                this.Items[i].RadianNowRectF = this.Items[i].RadianZoonMinRectF;
                this.Items[i].RadianNowThickness = this.Items[i].RadianNormalThickness;
                this.Items[i].RadianZoonProgress = 0f;

                GraphicsPath gp_out = new GraphicsPath();
                GraphicsPath gp_in = new GraphicsPath();
                gp_out.AddArc(this.Items[i].RadianNowRectF.X, this.Items[i].RadianNowRectF.Y, this.Items[i].RadianNowRectF.Width, this.Items[i].RadianNowRectF.Height, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                gp_in.AddArc(this.Items[i].RadianNowRectF.X + this.Items[i].RadianNowThickness, this.Items[i].RadianNowRectF.Y + this.Items[i].RadianNowThickness, this.Items[i].RadianNowRectF.Width - this.Items[i].RadianNowThickness * 2, this.Items[i].RadianNowRectF.Height - this.Items[i].RadianNowThickness * 2, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                gp_in.Reverse();
                gp_out.AddPath(gp_in, true);
                gp_out.CloseFigure();
                GraphicsPath gp_dis = this.Items[i].RadianNowPath;
                this.Items[i].RadianNowPath = gp_out;
                gp_dis.Dispose();
                this.Items[i].RadianZoonProgress = 100.0f;
            }
        }

        /// <summary>
        /// 生成分层控件画面图片
        /// </summary>
        private Bitmap CreateLayerImage()
        {
            Bitmap bmp = new Bitmap(this.rml.Width, this.rml.Height);
            Graphics g = Graphics.FromImage(bmp);

            #region

            SmoothingMode sm = g.SmoothingMode;
            TextRenderingHint trh = g.TextRenderingHint;

            Pen activeborder_pen = null;

            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                if (this.radianZoonStatus == RadianZoonStatuss.Min && i > 0)
                    continue;

                int back_opacity = this.RadianOpacity;
                int text_opacity = this.RadianTextOpacity;
                float progress = 100f;
                if ((this.radianZoonStatus == RadianZoonStatuss.Maxing || this.radianZoonStatus == RadianZoonStatuss.Mining) && (this.OwnerControl != null || this.OwnerControl == null && i > 0))
                {
                    if (this.radianZoonStatus == RadianZoonStatuss.Maxing)
                    {
                        progress = this.Items[i].RadianZoonProgress;
                    }
                    else if (this.radianZoonStatus == RadianZoonStatuss.Mining)
                    {
                        progress = 100f - this.Items[i].RadianZoonProgress;
                    }
                    back_opacity = ControlCommom.VerifyRGB((int)((float)back_opacity / 100f * progress));
                    text_opacity = ControlCommom.VerifyRGB((int)((float)text_opacity / 100f * progress));
                }

                this.radian_sb.Color = Color.FromArgb(back_opacity, this.Items[i].RadianBackColor);

                #region 圆弧背景
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(this.radian_sb, this.Items[i].RadianNowPath);

                #region 激活边框
                if (
                    (this.activatedStatus && this.OwnerControl == null && (this.radianZoonStatus == RadianZoonStatuss.Max && this.activatedStatusIndex == i))
                    ||
                    (this.activatedStatus && this.OwnerControl != null && (this.radianZoonStatus == RadianZoonStatuss.Max || this.radianZoonStatus == RadianZoonStatuss.Min) && this.activatedStatusIndex == i)
                    )
                {
                    activeborder_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
                    g.DrawPath(activeborder_pen, this.Items[i].RadianNowPath);
                }
                #endregion

                g.SmoothingMode = sm;
                #endregion

                #region 文本
                if (!String.IsNullOrWhiteSpace(Items[i].Text) && this.TextFont != null)
                {
                    this.text_sb.Color = Color.FromArgb(text_opacity, this.Items[i].RadianTextColor);
                    SizeF str_size = this.Items[i].RadianTextSize;
                    if (i == 0)//圆心
                    {
                        str_size = new SizeF(str_size.Width + 2f, str_size.Height + 2f);
                        g.DrawString(this.Items[i].Text, this.TextFont, this.text_sb, new RectangleF(this.Items[i].RadianNowRectF.X + (this.Items[i].RadianNowRectF.Width - str_size.Width) / 2, this.Items[i].RadianNowRectF.Y + (this.Items[i].RadianNowRectF.Height - str_size.Height) / 2, str_size.Width, str_size.Height));
                    }
                    else//圆弧
                    {
                        float angle_sum = 0f;
                        double degrees = ((2 * Math.PI * this.Items[i].RadianNormalRectF.Width / 2f + this.Items[i].RadianNormalThickness / 2f) / 360f);//一度弧长
                        float angle = (float)((float)str_size.Width / (float)this.Items[i].Text.Length / degrees);//一个字符要旋转的角度

                        g.TranslateTransform((float)this.rml.ClientRectangle.Width / 2f, (float)this.rml.ClientRectangle.Height / 2f);//更改起始坐标
                        g.RotateTransform(90 + this.Items[i].RadianNowStartAngle);//更改起始角度

                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        for (int j = 0; j < this.Items[i].Text.Length; j++)
                        {
                            angle_sum += angle;
                            g.RotateTransform(angle);
                            g.DrawString(this.Items[i].Text[j].ToString(), this.TextFont, this.text_sb, 0, -this.Items[i].RadianNowRectF.Height / 2 + (this.Items[i].RadianNowThickness - str_size.Height) / 2, this.text_sf);
                        }
                        g.TextRenderingHint = trh;

                        g.RotateTransform(-(90 + this.Items[i].RadianNowStartAngle + angle_sum));
                        g.TranslateTransform(-this.rml.ClientRectangle.Width / 2f, -this.rml.ClientRectangle.Height / 2f);//更改起始坐标

                    }
                }

                #endregion
            }

            if (activeborder_pen != null)
                activeborder_pen.Dispose();

            #endregion

            #region 释放

            g.Dispose();

            #endregion


            return bmp;
        }

        #endregion

        #endregion

        #region 类

        /// <summary>
        /// 圆弧选项集合
        /// </summary>
        [Description("圆弧选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public sealed class RadianMenuItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList radianMenuItemList = new ArrayList();
            private RadianMenuComponentExt owner;

            public RadianMenuItemCollection(RadianMenuComponentExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                RadianMenuItem[] listArray = new RadianMenuItem[this.radianMenuItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (RadianMenuItem)this.radianMenuItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.radianMenuItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.radianMenuItemList.Count;
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
                if (!(value is RadianMenuItem))
                {
                    throw new ArgumentException("RadianMenuItem");
                }
                return this.Add((RadianMenuItem)value);
            }

            public int Add(RadianMenuItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                this.radianMenuItemList.Add(item);
                this.owner.UpdateLayerSizeLocation();
                this.owner.InitializeRectangle();
                this.owner.InvalidateLayer();
                return this.Count - 1;
            }

            public void Clear()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    RadianMenuItem item = (RadianMenuItem)this.radianMenuItemList[i];
                    if (item.RadianNowPath != null)
                    {
                        item.RadianNowPath.Dispose();
                        item.RadianNowPath = null;
                    }
                }
                this.radianMenuItemList.Clear();
                this.owner.UpdateLayerSizeLocation();
                this.owner.InitializeRectangle();
                this.owner.InvalidateLayer();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is RadianMenuItem)
                {
                    return this.Contains((RadianMenuItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is RadianMenuItem)
                {
                    return this.radianMenuItemList.IndexOf(item);
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
                if (!(value is RadianMenuItem))
                {
                    throw new ArgumentException("RadianMenuItem");
                }

                RadianMenuItem item = (RadianMenuItem)value;
                this.Remove(item);
            }

            public void Remove(RadianMenuItem item)
            {
                if (item.RadianNowPath != null)
                {
                    item.RadianNowPath.Dispose();
                    item.RadianNowPath = null;
                }
                this.radianMenuItemList.Remove(item);
                this.owner.UpdateLayerSizeLocation();
                this.owner.InitializeRectangle();
                this.owner.InvalidateLayer();
            }

            public void RemoveAt(int index)
            {
                RadianMenuItem item = (RadianMenuItem)this.radianMenuItemList[index];
                if (item.RadianNowPath != null)
                {
                    item.RadianNowPath.Dispose();
                    item.RadianNowPath = null;
                }
                this.radianMenuItemList.RemoveAt(index);
                this.owner.UpdateLayerSizeLocation();
                this.owner.InitializeRectangle();
                this.owner.InvalidateLayer();
            }

            public RadianMenuItem this[int index]
            {
                get
                {
                    return (RadianMenuItem)this.radianMenuItemList[index];
                }
                set
                {
                    this.radianMenuItemList[index] = (RadianMenuItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.radianMenuItemList[index];
                }
                set
                {
                    this.radianMenuItemList[index] = (RadianMenuItem)value;
                }
            }

            #endregion

        }

        /// <summary>
        /// 圆弧选项
        /// </summary>
        [Description("圆弧选项")]
        public class RadianMenuItem
        {
            #region

            private int index = -1;
            /// <summary>
            /// 圆弧索引
            /// </summary>
            [Browsable(false)]
            [DefaultValue(-1)]
            [Description("圆弧索引")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int Index
            {
                get { return this.index; }
                set
                {
                    if (this.index == value)
                        return;

                    this.index = value;
                }
            }

            private Color radianBackColor = Color.YellowGreen;
            /// <summary>
            /// 圆弧背景颜色
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "YellowGreen")]
            [Description("圆弧背景颜色")]
            public Color RadianBackColor
            {
                get { return this.radianBackColor; }
                set
                {
                    if (this.radianBackColor == value)
                        return;

                    this.radianBackColor = value;
                }
            }

            private float radianStartAngle = 0f;
            /// <summary>
            ///  圆弧开始角度
            /// </summary>
            [Browsable(true)]
            [DefaultValue(0f)]
            [Description("圆弧开始角度")]
            public float RadianStartAngle
            {
                get { return this.radianStartAngle; }
                set
                {
                    if (this.radianStartAngle == value || value < -360 || value > 360)
                        return;

                    this.radianStartAngle = value;
                }
            }

            private float radianSweepAngle = 90f;
            /// <summary>
            /// 圆弧从 RadianStartAngle 参数到圆弧的结束点沿顺时针方向度量的角（以度为单位）。
            /// </summary>
            [Browsable(true)]
            [DefaultValue(90f)]
            [Description("圆弧从 RadianStartAngle 参数到圆弧的结束点沿顺时针方向度量的角（以度为单位）。")]
            public float RadianSweepAngle
            {
                get { return this.radianSweepAngle; }
                set
                {
                    if (this.radianSweepAngle == value || value < -360 || value > 360)
                        return;

                    this.radianSweepAngle = value;
                }
            }

            private float radianNowStartAngle;
            /// <summary>
            /// 当前圆弧开始角度
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("当前圆弧开始角度")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float RadianNowStartAngle
            {
                get { return this.radianNowStartAngle; }
                set
                {
                    if (this.radianNowStartAngle == value || value < -360 || value > 360)
                        return;

                    this.radianNowStartAngle = value;
                }
            }

            private RectangleF radianNormalRectF;
            /// <summary>
            /// 圆弧默认Rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧默认Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RadianNormalRectF
            {
                get { return this.radianNormalRectF; }
                set
                {
                    if (this.radianNormalRectF == value)
                        return;
                    this.radianNormalRectF = value;
                }
            }

            private RectangleF radianNowRectF;
            /// <summary>
            /// 圆弧当前Rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧当前Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RadianNowRectF
            {
                get { return this.radianNowRectF; }
                set
                {
                    if (this.radianNowRectF == value)
                        return;
                    this.radianNowRectF = value;
                }
            }

            private GraphicsPath radianNowPath = new GraphicsPath();
            /// <summary>
            /// 圆弧当前Path
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧当前Path")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public GraphicsPath RadianNowPath
            {
                get { return this.radianNowPath; }
                set
                {
                    if (this.radianNowPath == value)
                        return;

                    this.radianNowPath = value;
                }
            }

            #endregion

            #region 圆弧文本

            private string text = "";
            /// <summary>
            /// 圆弧文本
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("圆弧文本")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value || value == null)
                        return;

                    this.text = value;
                }
            }

            private Color radianTextColor = Color.White;
            /// <summary>
            /// 圆弧文本颜色
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "White")]
            [Description("圆弧文本颜色")]
            public Color RadianTextColor
            {
                get { return this.radianTextColor; }
                set
                {
                    if (this.radianTextColor == value)
                        return;

                    this.radianTextColor = value;
                }
            }

            private SizeF radianTextSize = SizeF.Empty;
            /// <summary>
            /// 圆弧文本大小
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DefaultValue(typeof(Font), "0,0")]
            [Description("圆弧文本大小")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public SizeF RadianTextSize
            {
                get
                {
                    return this.radianTextSize;
                }
                set
                {
                    if (this.radianTextSize == value)
                        return;

                    this.radianTextSize = value;
                }
            }

            #endregion

            #region 圆弧震动

            private RectangleF radianShakeMaxRectF;
            /// <summary>
            /// 圆弧震动最大Rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧震动最大Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RadianShakeMaxRectF
            {
                get { return this.radianShakeMaxRectF; }
                set
                {
                    if (this.radianShakeMaxRectF == value)
                        return;

                    this.radianShakeMaxRectF = value;
                }
            }

            private bool radianShakeIng = true;
            /// <summary>
            /// 圆弧是否处于震动状态中(用于定时器)
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧是否处于震动状态中(用于定时器)")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool RadianShakeIng
            {
                get { return this.radianShakeIng; }
                set
                {
                    if (this.radianShakeIng == value)
                        return;

                    this.radianShakeIng = value;
                }
            }

            private float radianShakeUsedTime;
            /// <summary>
            /// 圆弧震动已使用的时间
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧震动已使用的时间")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float RadianShakeUsedTime
            {
                get { return this.radianShakeUsedTime; }
                set
                {
                    if (this.radianShakeUsedTime == value)
                        return;

                    this.radianShakeUsedTime = value;
                }
            }

            private bool radianShakeForward = true;
            /// <summary>
            /// 是否为正向震动
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("是否为正向震动")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool RadianShakeForward
            {
                get { return this.radianShakeForward; }
                set
                {
                    if (this.radianShakeForward == value)
                        return;

                    this.radianShakeForward = value;
                }
            }

            private RadianMouseStatuss radianMouseStatus = RadianMouseStatuss.Leave;
            /// <summary>
            /// 圆弧鼠标状态
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧鼠标状态")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RadianMouseStatuss RadianMouseStatus
            {
                get { return this.radianMouseStatus; }
                set
                {
                    if (this.radianMouseStatus == value)
                        return;

                    this.radianMouseStatus = value;
                }
            }

            #endregion

            #region 圆弧缩放

            private RectangleF radianZoonMinRectF;
            /// <summary>
            /// 圆弧缩放到最小时Rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧缩放到最小时Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RadianZoonMinRectF
            {
                get { return this.radianZoonMinRectF; }
                set
                {
                    if (this.radianZoonMinRectF == value)
                        return;

                    this.radianZoonMinRectF = value;
                }
            }

            private RectangleF radianZoonBeforeRectF;
            /// <summary>
            /// 圆弧缩小前Rect
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧缩小前Rect")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RectangleF RadianZoonBeforeRectF
            {
                get { return this.radianZoonBeforeRectF; }
                set
                {
                    if (this.radianZoonBeforeRectF == value)
                        return;

                    this.radianZoonBeforeRectF = value;
                }
            }

            private float radianZoonProgress = 100f;
            /// <summary>
            /// 圆弧缩放的进度
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DefaultValue(100f)]
            [Description("圆弧缩放的进度")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float RadianZoonProgress
            {
                get { return this.radianZoonProgress; }
                set
                {
                    if (this.radianZoonProgress == value)
                        return;

                    this.radianZoonProgress = value;
                }
            }

            #endregion

            #region 圆弧旋转

            private int radianRotateValue = 0;
            /// <summary>
            /// 圆弧要旋转的角度(-180至180)
            /// </summary>
            [Browsable(true)]
            [DefaultValue(0)]
            [Description("弧度要旋转的角度(-180至180)(默认0)")]
            public int RadianRotateValue
            {
                get { return this.radianRotateValue; }
                set
                {
                    if (this.radianRotateValue == value || value < -180 || value > 180)
                        return;

                    this.radianRotateValue = value;
                }
            }

            private RadianRotateOrientations radianRotateOrientation = RadianRotateOrientations.Forward;
            /// <summary>
            /// 圆弧旋转方向
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧旋转方向")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public RadianRotateOrientations RadianRotateOrientation
            {
                get { return this.radianRotateOrientation; }
                set
                {
                    if (this.radianRotateOrientation == value)
                        return;

                    this.radianRotateOrientation = value;
                }
            }

            private bool radianRotateIng = true;
            /// <summary>
            /// 圆弧是否处于旋转状态中(用于定时器)
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧是否处于旋转状态中(用于定时器)")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool RadianRotateIng
            {
                get { return this.radianRotateIng; }
                set
                {
                    if (this.radianRotateIng == value)
                        return;

                    this.radianRotateIng = value;
                }
            }

            private float radianRotateUsedTime;
            /// <summary>
            /// 圆弧旋转已使用的时间
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧旋转已使用的时间")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float RadianRotateUsedTime
            {
                get { return this.radianRotateUsedTime; }
                set
                {
                    if (this.radianRotateUsedTime == value)
                        return;

                    this.radianRotateUsedTime = value;
                }
            }

            #endregion

            #region 圆弧厚度

            private int radianNormalThickness;
            /// <summary>
            /// 圆弧默认厚度
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧默认厚度")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int RadianNormalThickness
            {
                get { return this.radianNormalThickness; }
                set
                {
                    if (this.radianNormalThickness == value)
                        return;

                    this.radianNormalThickness = value;
                }
            }

            private int radianMaxThickness;
            /// <summary>
            /// 圆弧最大厚度
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("圆弧最大厚度")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int RadianMaxThickness
            {
                get { return this.radianMaxThickness; }
                set
                {
                    if (this.radianMaxThickness == value)
                        return;

                    this.radianMaxThickness = value;
                }
            }

            private int radianNowThickness;
            /// <summary>
            /// 当前圆弧厚度
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Description("当前圆弧厚度")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int RadianNowThickness
            {
                get { return this.radianNowThickness; }
                set
                {
                    if (this.radianNowThickness == value)
                        return;

                    this.radianNowThickness = value;
                }
            }

            #endregion
        }

        /// <summary>
        /// 圆弧选项单击事件参数
        /// </summary>
        [Description("圆弧选项单击事件参数")]
        public class ItemClickEventArgs : EventArgs
        {
            /// <summary>
            /// 圆弧选项
            /// </summary>
            [Description("圆弧选项")]
            public RadianMenuItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 圆弧选项鼠标状态
        /// </summary>
        [Description("圆弧选项鼠标状态")]
        public enum RadianMouseStatuss
        {
            /// <summary>
            /// 鼠标已离圆弧选项开可视区(动画完成)
            /// </summary>
            Leave,
            /// <summary>
            ///鼠标已离开圆弧选项可视区(动画还在进行中)
            /// </summary>
            LeaveAnimation,
            /// <summary>
            /// 鼠标已进入圆弧选项可视区(动画完成)
            /// </summary>
            Enter,
            /// <summary>
            /// 鼠标已进入圆弧选项可视区(动画还在进行中)
            /// </summary>
            EnterAnimation
        }

        /// <summary>
        /// 圆弧缩放状态
        /// </summary>
        [Description("圆弧缩放状态")]
        public enum RadianZoonStatuss
        {
            /// <summary>
            /// 已最大化
            /// </summary>
            Max,
            /// <summary>
            /// 最大化中
            /// </summary>
            Maxing,
            /// <summary>
            /// 已最小化
            /// </summary>
            Min,
            /// <summary>
            /// 最小化中
            /// </summary>
            Mining
        }

        /// <summary>
        /// 圆弧当前旋转方向
        /// </summary>
        [Description("圆弧当前旋转方向")]
        public enum RadianRotateOrientations
        {
            /// <summary>
            /// 与RadianRotateValue方向相同
            /// </summary>
            Forward,
            /// <summary>
            /// 与RadianRotateValue方向相反
            /// </summary>
            Inversion
        }

        #endregion

        #region 配件

        /// <summary>
        /// 圆弧菜单弹层
        /// </summary>
        [Description("圆弧菜单弹层")]
        protected class RadianMenuLayer : Form
        {
            #region 扩展

            /// <summary>
            /// 窗户是分层的窗户。如果窗口中有一个不能用这种风格类样式之一CS_OWNDC或CS_CLASSDC。Windows 8的：该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。
            /// </summary>
            private const int WS_EX_LAYERED = 0x80000;

            private const byte AC_SRC_OVER = 0;
            private const byte AC_SRC_ALPHA = 1;
            /// <summary>
            /// 使用pblend作为混合功能。如果显示模式为256色或更小，则此值的效果与ULW_OPAQUE的效果相同。
            /// </summary>
            private const Int32 ULW_ALPHA = 0x00000002;

            /// <summary>
            /// 该BLENDFUNCTION结构控制通过指定源和目的地的位图的混合函数共混。
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                /// <summary>
                /// 源混合操作。当前，唯一已定义的源和目标混合操作是AC_SRC_OVER。有关详细信息，请参见以下“备注”部分。
                /// </summary>
                public byte BlendOp;
                /// <summary>
                /// 必须为零。
                /// </summary>
                public byte BlendFlags;
                /// <summary>
                /// 指定要在整个源位图上使用的Alpha透明度值。所述SourceConstantAlpha值与源位图任何每像素的alpha值组合。如果将SourceConstantAlpha设置为0，则假定图像是透明的。当您只想使用每像素Alpha值时，请将SourceConstantAlpha值设置为255（不透明）。
                /// </summary>
                public byte SourceConstantAlpha;
                /// <summary>
                /// 该成员控制解释源位图和目标位图的方式。AlphaFormat具有以下值。
                /// AC_SRC_ALPHA	
                /// 当位图具有Alpha通道（即每像素alpha）时，将设置此标志。请注意，API使用预乘Alpha，这意味着位图中的红色，绿色和蓝色通道值必须预乘Alpha通道值。例如，如果Alpha通道值为x，则在调用之前，红色，绿色和蓝色通道必须乘以x并除以0xff。
                /// </summary>
                public byte AlphaFormat;
            }

            /// <summary>
            /// 检索句柄用于指定窗口的客户区或整个屏幕的设备上下文（DC）。您可以在后续的GDI函数中使用返回的句柄来绘制DC。设备上下文是一个不透明的数据结构，其值由GDI内部使用。
            /// </summary>
            /// <param name="hWnd">要获取其DC的窗口的句柄。如果此值为NULL，则GetDC检索整个屏幕的DC。</param>
            /// <returns>如果函数成功，则返回值是指定窗口的客户区DC的句柄。如果函数失败，则返回值为NULL。</returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            /// <summary>
            /// 创建具有指定设备兼容的存储器设备上下文（DC）。
            /// </summary>
            /// <param name="hdc">现有DC的句柄。如果此句柄为NULL，则该函数将创建一个与应用程序当前屏幕兼容的内存DC。</param>
            /// <returns>如果函数成功，则返回值是内存DC的句柄。如果函数失败，则返回值为NULL。</returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            /// <summary>
            /// 释放设备上下文（DC），释放它，以供其他应用程序使用。ReleaseDC功能的效果取决于DC的类型。它仅释放公共DC和窗口DC。它对班级或专用DC无效。
            /// </summary>
            /// <param name="hWnd">要释放其DC的窗口的句柄。</param>
            /// <param name="hDC">要释放的DC的句柄。</param>
            /// <returns></returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            /// <summary>
            /// 删除指定的设备上下文（DC）。。
            /// </summary>
            /// <param name="hdc">设备上下文的句柄。</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteDC(IntPtr hdc);

            /// <summary>
            /// 选择一个对象到指定的设备上下文（DC）。新对象将替换相同类型的先前对象。
            /// </summary>
            /// <param name="hdc">DC的句柄。</param>
            /// <param name="h">要选择的对象的句柄。必须使用以下功能之一创建指定的对象。
            /// CreateBitmap，CreateBitmapIndirect，CreateCompatibleBitmap，CreateDIBitmap，CreateDIBSection
            /// 位图只能选择到存储器DC中。单个位图不能同时选择到多个DC中。
            /// CreateBrushIndirect，CreateDIBPatternBrush，CreateDIBPatternBrushPt，CreateHatchBrush，CreatePatternBrush，CreateSolidBrush
            /// CreateFont，CreateFontIndirect
            /// 创建笔，创建笔间接
            /// CombineRgn，CreateEllipticRgn，CreateEllipticRgnIndirect，CreatePolygonRgn，CreateRectRgn，CreateRectRgnIndirect</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

            /// <summary>
            /// 删除逻辑笔，刷子，字体，位图，区域或调色板，释放与该对象相关联的所有系统资源。删除对象后，指定的句柄不再有效。
            /// </summary>
            /// <param name="ho">逻辑笔，画笔，字体，位图，区域或调色板的句柄。</param>
            /// <returns></returns>
            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteObject(IntPtr ho);

            /// <summary>
            /// 更新分层窗口的位置，大小，形状，内容和半透明。
            /// </summary>
            /// <param name="hWnd">分层窗口的句柄。使用CreateWindowEx函数创建窗口时，可以通过指定WS_EX_LAYERED来创建分层窗口。Windows 8的：  该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。</param>
            /// <param name="hdcDst">屏幕DC的句柄。通过在调用函数时指定NULL可获得此句柄。当窗口内容更新时，它用于调色板颜色匹配。如果hdcDst为NULL，则将使用默认调色板。如果hdcSrc为NULL，则hdcDst必须为NULL。</param>
            /// <param name="pptDst">指向指定分层窗口的新屏幕位置的结构的指针。如果当前位置未更改，则pptDst可以为NULL。</param>
            /// <param name="psize">指向指定分层窗口新大小的结构的指针。如果窗口的大小未更改，则psize可以为NULL。如果hdcSrc为NULL，则psize必须为NULL。</param>
            /// <param name="hdcSrc">DC的句柄，用于定义分层窗口的表面。可以通过调用CreateCompatibleDC函数获得此句柄。如果窗口的形状和视觉上下文未更改，则hdcSrc可以为NULL。</param>
            /// <param name="pptSrc">指向指定设备上下文中层位置的结构的指针。如果hdcSrc为NULL，则pptSrc应该为NULL。</param>
            /// <param name="crKey">一个结构，用于指定在组成分层窗口时要使用的颜色键。要生成COLORREF，请使用RGB宏。</param>
            /// <param name="pblend">指向结构的指针，该结构指定组成分层窗口时要使用的透明度值。</param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            #endregion

            #region 字段

            /// <summary>
            /// 拖动功能是否按下鼠标
            /// </summary>
            private bool mouseMoveDown = false;

            /// <summary>
            /// 拖动功能记录鼠标按下的坐标
            /// </summary>
            private Point mouseMoveOffset;

            /// <summary>
            /// 鼠标按下的圆弧选项索引
            /// </summary>
            private int mouseDownIndex = -1;

            /// <summary>
            /// 分层窗体句柄创建完成
            /// </summary>
            private bool isHandleCreate = false;

            /// <summary>
            /// 不规则圆弧菜单控件
            /// </summary>
            private RadianMenuComponentExt rmce = null;

            #endregion

            public RadianMenuLayer(RadianMenuComponentExt rmce)
            {
                this.rmce = rmce;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
            }

            #region 重写

            protected override void OnHandleCreated(EventArgs e)
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Selectable, false);

                base.OnHandleCreated(e);
                this.isHandleCreate = true;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cParms = base.CreateParams;
                    cParms.ExStyle |= WS_EX_LAYERED;
                    return cParms;
                }
            }

            protected override void OnActivated(EventArgs e)
            {
                base.OnActivated(e);

                this.rmce.activatedStatus = true;
                if (this.rmce.activatedStatusIndex == -1)
                {
                    this.rmce.activatedStatusIndex = 0;
                }
                this.InvalidateLayer();
            }

            protected override void OnDeactivate(EventArgs e)
            {
                base.OnDeactivate(e);

                this.mouseMoveDown = false;
                this.mouseDownIndex = -1;
                this.rmce.activatedStatus = false;
                if (this.rmce.radianZoonStatus == RadianZoonStatuss.Mining || this.rmce.radianZoonStatus == RadianZoonStatuss.Min)
                {
                    this.rmce.activatedStatusIndex = -1;
                }
                this.InvalidateLayer();

                if (this.rmce.OwnerControl != null)
                {
                    this.rmce.HideLayerView();
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);

                for (int i = 0; i < this.rmce.Items.Count; i++)
                {
                    #region 停止旋转
                    if (this.rmce.RadianIsRotate)
                    {
                        if (this.rmce.Items[i].RadianRotateIng == false)
                        {
                            this.rmce.Items[i].RadianRotateIng = true;
                        }
                    }
                    #endregion
                    #region 还原震动
                    if (this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.Enter || this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.EnterAnimation)
                    {
                        this.rmce.StopShakeTimer(this.rmce.Items[i]);
                        this.rmce.Items[i].RadianMouseStatus = RadianMouseStatuss.LeaveAnimation;
                        this.rmce.Items[i].RadianShakeForward = false;
                        this.rmce.StartShakeTimer(this.rmce.Items[i], this.rmce.Items[i].RadianShakeUsedTime == 0 ? this.rmce.RadianShakeTime : this.rmce.Items[i].RadianShakeUsedTime);
                    }
                    #endregion
                }
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);

                this.Activate();

                for (int i = 0; i < this.rmce.Items.Count; i++)
                {
                    if (this.rmce.Items[i].RadianNowPath.IsVisible(e.Location))
                    {
                        this.mouseDownIndex = i;
                        break;
                    }
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (this.rmce.OwnerControl == null)
                    {
                        this.mouseMoveDown = true;
                        this.mouseMoveOffset = Control.MousePosition;
                    }
                }
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);

                this.mouseDownIndex = -1;
                if (e.Button == MouseButtons.Left)
                {
                    if (this.rmce.OwnerControl == null)
                    {
                        this.mouseMoveDown = false;
                        this.mouseMoveOffset = Point.Empty;
                    }
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);

                #region 取消鼠标按下的圆弧选项索引
                if (this.rmce.OwnerControl == null && this.mouseDownIndex > -1)
                {
                    this.mouseDownIndex = -1;
                }
                #endregion

                #region 全局控件移动
                if (this.rmce.OwnerControl == null && this.mouseMoveDown)
                {
                    Point point = Control.MousePosition;
                    int rangeX = point.X - mouseMoveOffset.X;
                    int rangeY = point.Y - mouseMoveOffset.Y;
                    if (rangeX != 0 || rangeY != 0)
                    {
                        Point p = new Point(this.Location.X + rangeX, this.Location.Y + rangeY);
                        Rectangle screen_rect = System.Windows.Forms.Screen.GetWorkingArea(this);
                        if (screen_rect.Contains(new Point(p.X + this.Width / 2, p.Y + this.Height / 2)))
                        {
                            this.mouseMoveOffset = Control.MousePosition;
                            this.Location = p;
                        }
                    }
                }
                #endregion

                #region 圆弧震动
                if (this.rmce.radianZoonStatus == RadianZoonStatuss.Max)
                {
                    for (int i = 0; i < this.rmce.Items.Count; i++)
                    {
                        #region  鼠标进入圆弧
                        if (this.rmce.Items[i].RadianNowPath.IsVisible(e.Location))
                        {
                            if (this.rmce.RadianIsRotate)
                            {
                                this.rmce.StopRotateTimer(this.rmce.Items[i]);
                            }
                            if (this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.Leave || this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.LeaveAnimation)
                            {
                                this.rmce.StopShakeTimer(this.rmce.Items[i]);
                                this.rmce.Items[i].RadianMouseStatus = RadianMouseStatuss.EnterAnimation;
                                this.rmce.Items[i].RadianShakeForward = true;
                                this.rmce.StartShakeTimer(this.rmce.Items[i], this.rmce.Items[i].RadianShakeUsedTime == 0 ? 0 : this.rmce.RadianShakeTime - this.rmce.Items[i].RadianShakeUsedTime);
                            }
                        }
                        #endregion
                        #region  鼠标离开圆弧
                        else
                        {
                            if (this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.Enter || this.rmce.Items[i].RadianMouseStatus == RadianMouseStatuss.EnterAnimation)
                            {
                                this.rmce.StopShakeTimer(this.rmce.Items[i]);
                                this.rmce.Items[i].RadianMouseStatus = RadianMouseStatuss.LeaveAnimation;
                                this.rmce.Items[i].RadianShakeForward = false;
                                this.rmce.StartShakeTimer(this.rmce.Items[i], this.rmce.Items[i].RadianShakeUsedTime == 0 ? this.rmce.RadianShakeTime : this.rmce.Items[i].RadianShakeUsedTime);
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);

                #region 左键
                if (e.Button == MouseButtons.Left)
                {
                    #region 单击事件
                    if (this.mouseDownIndex > -1 && this.rmce.Items[this.mouseDownIndex].RadianNowPath.IsVisible(e.Location))
                    {
                        this.rmce.activatedStatusIndex = this.mouseDownIndex;
                        this.rmce.OnItemClick(new ItemClickEventArgs() { Item = this.rmce.Items[this.rmce.activatedStatusIndex] });
                    }
                    #endregion
                }
                #endregion
                #region 右键
                else if (e.Button == MouseButtons.Right)
                {
                    #region 缩放
                    if (this.mouseDownIndex > -1)
                    {
                        if (this.rmce.Items.Count > 0 && this.rmce.Items[0].RadianNowPath.IsVisible(e.Location))
                        {
                            this.rmce.activatedStatusIndex = 0;

                            float HideProgress = 0f;
                            #region
                            if (this.rmce.OwnerControl == null)
                            {
                                if (this.rmce.radianZoonStatus == RadianZoonStatuss.Max || this.rmce.radianZoonStatus == RadianZoonStatuss.Maxing)
                                {
                                    this.rmce.radianZoonStatus = RadianZoonStatuss.Mining;
                                    HideProgress = 100f;
                                }
                                else if (this.rmce.OwnerControl == null)
                                {
                                    if (this.rmce.radianZoonStatus == RadianZoonStatuss.Min || this.rmce.radianZoonStatus == RadianZoonStatuss.Mining)
                                    {
                                        this.rmce.radianZoonStatus = RadianZoonStatuss.Maxing;
                                        HideProgress = 0f;
                                    }
                                }
                            }
                            else
                            {
                                if (this.rmce.radianZoonStatus == RadianZoonStatuss.Max || this.rmce.radianZoonStatus == RadianZoonStatuss.Maxing)
                                {
                                    this.rmce.radianZoonStatus = RadianZoonStatuss.Mining;
                                    HideProgress = 100f;
                                }
                                //局部时展开功能由句柄控件实现
                            }
                            #endregion
                            for (int i = 0; i < this.rmce.Items.Count; i++)
                            {
                                this.rmce.Items[i].RadianZoonBeforeRectF = this.rmce.Items[i].RadianNowRectF;
                                this.rmce.Items[i].RadianZoonProgress = HideProgress;

                            }
                            this.rmce.StartZoomTimer(this.rmce.radianZoomUsedTime == 0 ? 0 : this.rmce.RadianShakeTime - this.rmce.radianZoomUsedTime);

                        }
                    }
                    #endregion
                }
                #endregion
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (this.rmce.activatedStatus)
                {
                    #region Left
                    if (keyData == Keys.Left)
                    {
                        if (this.rmce.radianZoonStatus == RadianZoonStatuss.Max)
                        {
                            this.rmce.activatedStatusIndex--;
                            if (this.rmce.activatedStatusIndex < 0)
                            {
                                this.rmce.activatedStatusIndex = this.rmce.Items.Count - 1;
                            }

                            this.InvalidateLayer();
                        }
                        return false;
                    }
                    #endregion
                    #region Right
                    else if (keyData == Keys.Right)
                    {
                        if (this.rmce.radianZoonStatus == RadianZoonStatuss.Max)
                        {
                            this.rmce.activatedStatusIndex++;
                            if (this.rmce.activatedStatusIndex > this.rmce.Items.Count - 1)
                            {
                                this.rmce.activatedStatusIndex = 0;
                            }
                            this.InvalidateLayer();
                        }

                        return false;
                    }
                    #endregion
                    #region Up
                    else if (keyData == Keys.Up)
                    {
                        this.rmce.MaxLayerView();
                        return false;
                    }
                    #endregion
                    #region Down
                    else if (keyData == Keys.Down)
                    {
                        this.rmce.MinLayerView();
                        return false;
                    }
                    #endregion
                    #region Enter
                    else if (keyData == Keys.Enter)
                    {
                        #region 单击事件
                        if (this.rmce.activatedStatusIndex > -1)
                        {
                            this.rmce.OnItemClick(new ItemClickEventArgs() { Item = this.rmce.Items[this.rmce.activatedStatusIndex] });
                        }
                        return false;
                        #endregion
                    }
                    #endregion
                }

                return base.ProcessDialogKey(keyData);
            }

            #endregion

            #region 公开方法

            /// <summary>
            /// 使分层控件的整个图面无效并导致重绘控件（Invalidate已失效）。
            /// </summary>
            public void InvalidateLayer()
            {
                if (this.isHandleCreate && this.Visible)
                {
                    this.DrawImageToLayer(this.rmce.CreateLayerImage());
                }
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 绘制图片到分层控件上
            /// </summary>
            /// <param name="bitmap"></param>
            private void DrawImageToLayer(Bitmap bitmap)
            {
                IntPtr hdcDst = GetDC(this.Handle);
                IntPtr hdcSrc = CreateCompatibleDC(hdcDst);

                IntPtr newBitmap = bitmap.GetHbitmap(Color.FromArgb(0));//创建一张位图
                IntPtr oldBitmap = SelectObject(hdcSrc, newBitmap);//位图绑定到DC设备上

                Point pptDst = new Point(this.Left, this.Top);
                Size psize = new Size(bitmap.Width, bitmap.Height);
                Point pptSrc = new Point(0, 0);

                BLENDFUNCTION pblend = new BLENDFUNCTION();
                pblend.BlendOp = AC_SRC_OVER;
                pblend.SourceConstantAlpha = 255;
                pblend.AlphaFormat = AC_SRC_ALPHA;
                pblend.BlendFlags = 0;

                UpdateLayeredWindow(this.Handle, hdcDst, ref pptDst, ref psize, hdcSrc, ref pptSrc, 0, ref pblend, ULW_ALPHA);

                if (oldBitmap != IntPtr.Zero)
                {
                    if (oldBitmap != IntPtr.Zero)
                        DeleteObject(newBitmap);
                    if (oldBitmap != IntPtr.Zero)
                        DeleteObject(newBitmap);
                }
                if (bitmap != null)
                    bitmap.Dispose();
                ReleaseDC(this.Handle, hdcDst);
                DeleteDC(hdcSrc);
            }

            #endregion

        }

        #endregion

    }

}
