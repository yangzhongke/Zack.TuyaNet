
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
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// GDI不规则圆弧菜单控件(控件版)(废弃)
    /// </summary>
    [ToolboxItem(true)]
    [Description("GDI不规则圆弧菜单控件(控件版)(废弃)")]
    [DefaultProperty("Items")]
    [DefaultEvent("ItemClick")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class RadianMenuExt : Control
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
                this.InitializeRectangle();
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
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
                this.InitializeRectangle();
                this.Invalidate();
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
                this.InitializeRectangle();
                this.Invalidate();
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
                if (this.radianShakeTime == value || value < 1)
                    return;
                this.radianShakeTime = value;
                if (!this.DesignMode)
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        this.Items[i].AnimationShake.Options.AllTransformTime = value;
                    }
                }
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

                if (!this.Enabled)
                    return;

                if (!this.DesignMode)
                {
                    if (value)
                    {
                        this.InitializeRadianAnimation();
                    }
                    else
                    {
                        this.UnInitializeRadianAnimation();
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
                if (this.radianRotateTime == value || value < 1)
                    return;
                this.radianRotateTime = value;

                if (!this.DesignMode)
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        this.Items[i].AnimationRadian.Options.AllTransformTime = value;
                    }
                }
            }
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

        protected override Size DefaultSize
        {
            get
            {
                return new Size(450, 450);
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
        /// 控件激活状态选项索引
        /// </summary>
        private int activatedStateIndex = -1;

        /// <summary>
        /// 选中圆弧选项
        /// </summary>
        private RadianMenuItem selectedItem = null;

        /// <summary>
        /// 缩放动画对象
        /// </summary>
        private AnimationTimer animationZoon = null;

        /// <summary>
        /// 控件缩放状态
        /// </summary>
        private RadianZoonStates radianZoonState = RadianZoonStates.Max;

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

        #endregion

        public RadianMenuExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (!this.DesignMode)
            {
                this.animationZoon = new AnimationTimer(this, new AnimationOptions() { EveryNewTimer = false });
                this.animationZoon.Animationing += new AnimationTimer.AnimationEventHandler(this.AnimationZoon_Animationing);
                this.animationZoon.AnimationEnding += new AnimationTimer.AnimationEventHandler(this.AnimationZoon_AnimationEnding);
                this.animationZoon.AnimationType = AnimationTypes.EaseOut;
                this.animationZoon.Options.EveryNewTimer = false;
            }
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            SmoothingMode sm = g.SmoothingMode;
            TextRenderingHint trh = g.TextRenderingHint;

            Pen activeborder_pen = null;
            if (this.activatedState)
            {
                activeborder_pen = new Pen(this.ActivateColor) { DashStyle = DashStyle.Dash };
            }

            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                if (this.radianZoonState == RadianZoonStates.Min && i > 0)
                    continue;

                int back_opacity = this.RadianOpacity;
                int text_opacity = this.RadianTextOpacity;
                float progress = 100f;
                if ((this.radianZoonState == RadianZoonStates.Maxing || this.radianZoonState == RadianZoonStates.Mining) && i > 0)
                {
                    if (this.radianZoonState == RadianZoonStates.Maxing)
                    {
                        progress = this.Items[i].RadianHideProgress;
                    }
                    else if (this.radianZoonState == RadianZoonStates.Mining)
                    {
                        progress = 100f - this.Items[i].RadianHideProgress;
                    }
                    back_opacity = (int)((float)back_opacity / 100f * progress);
                    back_opacity = ControlCommom.VerifyRGB(back_opacity);
                    text_opacity = (int)((float)text_opacity / 100f * progress);
                    text_opacity = ControlCommom.VerifyRGB(text_opacity);
                }

                this.radian_sb.Color = Color.FromArgb(back_opacity, this.Items[i].RadianColor);
                #region 圆弧背景
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(this.radian_sb, this.Items[i].RadianPath);
                #region 激活边框
                if (this.activatedState && this.activatedStateIndex == i)
                {
                    g.DrawPath(activeborder_pen, this.Items[i].RadianPath);
                }
                #endregion

                g.SmoothingMode = sm;
                #endregion

                #region 文本
                if (!String.IsNullOrWhiteSpace(Items[i].Text) && this.Items[i].TextFont != null)
                {
                    this.text_sb.Color = Color.FromArgb(text_opacity, this.Items[i].TextColor);
                    SizeF str_size = this.Items[i].TextSize;
                    if (i == 0)//圆心
                    {
                        str_size = new SizeF(str_size.Width + 2f, str_size.Height + 2f);
                        g.DrawString(this.Items[i].Text, this.Items[i].TextFont, this.text_sb, new RectangleF(this.Items[i].RadianNowRectF.X + (this.Items[i].RadianNowRectF.Width - str_size.Width) / 2, this.Items[i].RadianNowRectF.Y + (this.Items[i].RadianNowRectF.Height - str_size.Height) / 2, str_size.Width, str_size.Height));
                    }
                    else//圆弧
                    {
                        float angle_sum = 0f;
                        double degrees = ((2 * Math.PI * this.Items[i].RadianNormalRectF.Width / 2f + this.Items[i].RadianNormalWidth / 2f) / 360f);//一度弧长
                        float angle = (float)((float)str_size.Width / (float)this.Items[i].Text.Length / degrees);//一个字符要旋转的角度

                        g.TranslateTransform((float)this.ClientRectangle.Width / 2f, (float)this.ClientRectangle.Height / 2f);//更改起始坐标
                        g.RotateTransform(90 + this.Items[i].RadianNowStartAngle);//更改起始角度

                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                        for (int j = 0; j < this.Items[i].Text.Length; j++)
                        {
                            angle_sum += angle;
                            g.RotateTransform(angle);
                            g.DrawString(this.Items[i].Text[j].ToString(), this.Items[i].TextFont, this.text_sb, 0, -this.Items[i].RadianNowRectF.Height / 2 + (this.Items[i].RadianNowWidth - str_size.Height) / 2, this.text_sf);
                        }
                        g.TextRenderingHint = trh;

                        g.RotateTransform(-(90 + this.Items[i].RadianNowStartAngle + angle_sum));
                        g.TranslateTransform(-this.ClientRectangle.Width / 2f, -this.ClientRectangle.Height / 2f);//更改起始坐标

                    }
                }

                #endregion
            }

            if (activeborder_pen != null)
                activeborder_pen.Dispose();

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (this.DesignMode)
                return;

            for (int i = 0; i < this.Items.Count; i++)
            {
                this.activatedState = true;
                this.activatedStateIndex = i;
                this.Invalidate();
                break;
            }

        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.activatedStateIndex = -1;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (this.DesignMode)
                return;

            this.activatedState = false;
            this.Invalidate();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.activatedState)
            {
                #region Left
                if (keyData == Keys.Left)
                {
                    if (this.radianZoonState == RadianZoonStates.Max)
                    {
                        this.activatedStateIndex--;
                        if (this.activatedStateIndex < 0)
                        {
                            this.activatedStateIndex = this.Items.Count - 1;
                        }
                        this.Invalidate();
                    }

                    return false;
                }
                #endregion
                #region Right
                else if (keyData == Keys.Right)
                {
                    if (this.radianZoonState == RadianZoonStates.Max)
                    {
                        this.activatedStateIndex++;
                        if (this.activatedStateIndex > this.Items.Count - 1)
                        {
                            this.activatedStateIndex = 0;
                        }
                        this.Invalidate();
                    }

                    return false;
                }
                #endregion
                #region Up
                else if (keyData == Keys.Up)
                {
                    if (this.radianZoonState == RadianZoonStates.Min || this.radianZoonState == RadianZoonStates.Mining)
                    {
                        if (this.RadianIsRotate == true)
                        {
                            for (int i = 1; i < this.Items.Count; i++)
                            {
                                this.Items[i].AnimationRadian.Stop();
                            }
                        }
                        this.radianZoonState = RadianZoonStates.Maxing;
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            this.Items[i].RadianHideBeforeRectF = this.Items[i].RadianNowRectF;
                            this.Items[i].RadianHideProgress = 0f;
                            this.animationZoon.Start(AnimationIntervalTypes.Add, 0);
                        }
                    }

                    return false;
                }
                #endregion
                #region Down
                else if (keyData == Keys.Down)
                {
                    if (this.radianZoonState == RadianZoonStates.Max || this.radianZoonState == RadianZoonStates.Maxing)
                    {
                        if (this.RadianIsRotate == true)
                        {
                            for (int i = 1; i < this.Items.Count; i++)
                            {
                                this.Items[i].AnimationRadian.Stop();
                            }
                        }
                        this.activatedStateIndex = 0;
                        this.radianZoonState = RadianZoonStates.Mining;
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            this.Items[i].RadianHideBeforeRectF = this.Items[i].RadianNowRectF;
                            this.Items[i].RadianHideProgress = 100f;
                        }
                        this.animationZoon.Start(AnimationIntervalTypes.Add, 0);
                    }

                    return false;
                }
                #endregion
                #region Enter、Space
                else if (keyData == Keys.Enter || keyData == Keys.Space)
                {
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

            if (this.DesignMode)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.selectedItem != null && this.selectedItem.Index == 0)
                {
                    if (this.RadianIsRotate == true)
                    {
                        for (int i = 1; i < this.Items.Count; i++)
                        {
                            this.Items[i].AnimationRadian.Stop();
                        }
                    }
                    bool iszoon = false;
                    if (this.radianZoonState == RadianZoonStates.Max || this.radianZoonState == RadianZoonStates.Maxing)
                    {
                        this.radianZoonState = RadianZoonStates.Mining;
                        iszoon = true;
                    }
                    else if (this.radianZoonState == RadianZoonStates.Min || this.radianZoonState == RadianZoonStates.Mining)
                    {
                        this.radianZoonState = RadianZoonStates.Maxing;
                        iszoon = false;
                    }
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        this.Items[i].RadianHideBeforeRectF = this.Items[i].RadianNowRectF;
                        this.Items[i].RadianHideProgress = iszoon ? 100f : 0f;

                    }
                    this.animationZoon.Start(AnimationIntervalTypes.Add, 0);
                }
            }
            else
            {
                if (this.selectedItem != null)
                {
                    this.OnItemClick(new ItemClickEventArgs() { Item = this.selectedItem });
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.DesignMode)
                return;

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.radianZoonState != RadianZoonStates.Max && i > 0)
                    return;

                if (this.Items[i].RadianPath.IsVisible(e.Location))//鼠标进入
                {
                    if (this.Items[i].RadianMoveState == RadianMoveStates.Leave)
                    {
                        this.selectedItem = this.Items[i];
                        if (this.RadianIsRotate == true && i > 0)
                        {
                            this.Items[i].AnimationRadian.Suspend();
                        }

                        this.Items[i].RadianMoveState = RadianMoveStates.EnterAnimation;

                        this.Items[i].AnimationShake.AnimationType = AnimationTypes.ElasticOut;
                        this.Items[i].AnimationShake.Options.AllTransformTime = this.RadianShakeTime;
                        this.Items[i].AnimationShake.Start(AnimationIntervalTypes.Add, this.Items[i].AnimationShake.AnimationUsedTime);
                    }
                }
                else//鼠标离开
                {
                    if (this.Items[i].RadianMoveState == RadianMoveStates.Enter || this.Items[i].RadianMoveState == RadianMoveStates.EnterAnimation)
                    {
                        if (this.selectedItem != null && this.selectedItem.Equals(this.Items[i]))
                            this.selectedItem = null;
                        this.Items[i].RadianMoveState = RadianMoveStates.LeaveAnimation;

                        if (this.RadianIsRotate == true && i > 0)
                        {
                            this.Items[i].AnimationRadian.Continue();
                        }

                        this.Items[i].AnimationShake.AnimationType = AnimationTypes.BackIn;
                        this.Items[i].AnimationShake.Options.AllTransformTime = this.RadianShakeTime;
                        this.Items[i].AnimationShake.Start(AnimationIntervalTypes.Subtrac, this.Items[i].AnimationShake.AnimationUsedTime);
                    }
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.selectedItem = null;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitializeRectangle();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.animationZoon != null)
                    this.animationZoon.Dispose();
                if (this.radian_sb != null)
                    this.radian_sb.Dispose();
                if (this.text_sb != null)
                    this.text_sb.Dispose();
                if (this.text_sf != null)
                    this.text_sf.Dispose();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].AnimationShake != null)
                        this.Items[i].AnimationShake.Dispose();

                    if (this.Items[i].AnimationRadian != null)
                        this.Items[i].AnimationRadian.Dispose();

                    if (this.Items[i].RadianPath != null)
                        this.Items[i].RadianPath.Dispose();

                    if (this.Items[i].TextFont != null)
                        this.Items[i].TextFont.Dispose();
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

        #region 私有方法

        #region 动画

        /// <summary>
        /// 震动动画进行中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationShake_Animationing(object sender, AnimationEventArgs e)
        {
            RadianMenuItem rmi = (RadianMenuItem)e.Data;
            float w = (float)(rmi.RadianNormalRectF.Width + this.RadianWidthShakeLargen * e.ProgressValue * 2);
            float h = (float)(rmi.RadianNormalRectF.Height + this.RadianWidthShakeLargen * e.ProgressValue * 2);
            float x = ((float)this.ClientRectangle.Width - w) / 2f;
            float y = ((float)this.ClientRectangle.Height - h) / 2f;
            rmi.RadianNowRectF = new RectangleF(x, y, w, h);
            float v = (float)(this.RadianWidthShakeLargen * e.ProgressValue * 2);
            rmi.RadianNowWidth = (int)(rmi.RadianNormalWidth + v);

            if (rmi.Index == 0)
            {
                GraphicsPath gp_out = new GraphicsPath();
                gp_out.AddEllipse(rmi.RadianNowRectF);
                GraphicsPath gp_dis = rmi.RadianPath;
                rmi.RadianPath = gp_out;
                gp_dis.Dispose();
            }
            else
            {
                GraphicsPath gp_out = new GraphicsPath();
                GraphicsPath gp_in = new GraphicsPath();
                gp_out.AddArc(rmi.RadianNowRectF.X, rmi.RadianNowRectF.Y, rmi.RadianNowRectF.Width, rmi.RadianNowRectF.Height, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                gp_in.AddArc(rmi.RadianNowRectF.X + rmi.RadianNowWidth, rmi.RadianNowRectF.Y + rmi.RadianNowWidth, rmi.RadianNowRectF.Width - rmi.RadianNowWidth * 2, rmi.RadianNowRectF.Height - rmi.RadianNowWidth * 2, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                gp_in.Reverse();
                gp_out.AddPath(gp_in, true);
                gp_out.CloseFigure();
                GraphicsPath gp_dis = rmi.RadianPath;
                rmi.RadianPath = gp_out;
                gp_dis.Dispose();
            }
            this.Invalidate();
        }

        /// <summary>
        /// 震动动画结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationShake_AnimationEnding(object sender, AnimationEventArgs e)
        {
            RadianMenuItem rmi = (RadianMenuItem)e.Data;
            if (rmi.RadianMoveState == RadianMoveStates.LeaveAnimation)
            {
                rmi.RadianMoveState = RadianMoveStates.Leave;
            }
            else if (rmi.RadianMoveState == RadianMoveStates.EnterAnimation)
            {
                rmi.RadianMoveState = RadianMoveStates.Enter;
            }
        }

        /// <summary>
        /// 旋转动画进行中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationRadian_Animationing(object sender, AnimationEventArgs e)
        {
            RadianMenuItem rmi = (RadianMenuItem)e.Data;
            if (rmi.RadianMoveState == RadianMoveStates.Leave)
            {
                float original = 0f;
                if (rmi.RadianRotateValue < 0)//旋转方向
                {
                    original = rmi.AnimationRadian.Options.AllTransformValue < 0 ? rmi.RadianStartAngle : (rmi.RadianStartAngle + rmi.RadianRotateValue);
                }
                else
                {
                    original = rmi.AnimationRadian.Options.AllTransformValue > 0 ? rmi.RadianStartAngle : (rmi.RadianStartAngle + rmi.RadianRotateValue);
                }
                rmi.RadianNowStartAngle = (float)(original + e.AllTransformValue * e.ProgressValue);


                GraphicsPath gp_out = new GraphicsPath();
                GraphicsPath gp_in = new GraphicsPath();
                gp_out.AddArc(rmi.RadianNormalRectF.X, rmi.RadianNormalRectF.Y, rmi.RadianNormalRectF.Width, rmi.RadianNormalRectF.Height, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                gp_in.AddArc(rmi.RadianNormalRectF.X + rmi.RadianNormalWidth, rmi.RadianNormalRectF.Y + rmi.RadianNormalWidth, rmi.RadianNormalRectF.Width - rmi.RadianNormalWidth * 2, rmi.RadianNormalRectF.Height - rmi.RadianNormalWidth * 2, rmi.RadianNowStartAngle, rmi.RadianSweepAngle);
                gp_in.Reverse();
                gp_out.AddPath(gp_in, true);
                gp_out.CloseFigure();
                GraphicsPath gp_dis = rmi.RadianPath;
                rmi.RadianPath = gp_out;
                gp_dis.Dispose();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 旋转动画间隔重复事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationRadian_AnimationRepetition(object sender, AnimationEventArgs e)
        {
            RadianMenuItem rmi = (RadianMenuItem)e.Data;
            rmi.AnimationRadian.Options.AllTransformValue = -1 * rmi.AnimationRadian.Options.AllTransformValue;
        }

        /// <summary>
        /// 缩放动画事件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationZoon_Animationing(object sender, AnimationEventArgs e)
        {
            for (int i = 1; i < this.Items.Count; i++)
            {
                float w = 0f;
                float h = 0f;
                if (this.radianZoonState == RadianZoonStates.Maxing)
                {
                    w = (float)(this.Items[i].RadianHideBeforeRectF.Width + (this.Items[i].RadianNormalRectF.Width - this.Items[i].RadianHideBeforeRectF.Width) * e.ProgressValue);
                    h = (float)(this.Items[i].RadianHideBeforeRectF.Height + (this.Items[i].RadianNormalRectF.Height - this.Items[i].RadianHideBeforeRectF.Height) * e.ProgressValue);
                }
                else if (this.radianZoonState == RadianZoonStates.Mining)
                {
                    w = (float)(this.Items[i].RadianHideBeforeRectF.Width - (this.Items[i].RadianHideBeforeRectF.Width - this.Items[i].RadianHideRectF.Width) * e.ProgressValue);
                    h = (float)(this.Items[i].RadianHideBeforeRectF.Height - (this.Items[i].RadianHideBeforeRectF.Height - this.Items[i].RadianHideRectF.Height) * e.ProgressValue);
                }
                float x = ((float)this.ClientRectangle.Width - w) / 2f;
                float y = ((float)this.ClientRectangle.Height - h) / 2f;
                this.Items[i].RadianNowRectF = new RectangleF(x, y, w, h);
                this.Items[i].RadianNowWidth = this.Items[i].RadianNormalWidth;

                GraphicsPath gp_out = new GraphicsPath();
                GraphicsPath gp_in = new GraphicsPath();
                gp_out.AddArc(this.Items[i].RadianNowRectF.X, this.Items[i].RadianNowRectF.Y, this.Items[i].RadianNowRectF.Width, this.Items[i].RadianNowRectF.Height, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                gp_in.AddArc(this.Items[i].RadianNowRectF.X + this.Items[i].RadianNowWidth, this.Items[i].RadianNowRectF.Y + this.Items[i].RadianNowWidth, this.Items[i].RadianNowRectF.Width - this.Items[i].RadianNowWidth * 2, this.Items[i].RadianNowRectF.Height - this.Items[i].RadianNowWidth * 2, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                gp_in.Reverse();
                gp_out.AddPath(gp_in, true);
                gp_out.CloseFigure();
                GraphicsPath gp_dis = this.Items[i].RadianPath;
                this.Items[i].RadianPath = gp_out;
                gp_dis.Dispose();
                this.Items[i].RadianHideProgress = (float)(e.ProgressValue * 100);

            }
            this.Invalidate();
        }

        /// <summary>
        /// 缩放动画结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnimationZoon_AnimationEnding(object sender, AnimationEventArgs e)
        {
            if (this.radianZoonState == RadianZoonStates.Mining)
            {
                this.radianZoonState = RadianZoonStates.Min;
            }
            else if (this.radianZoonState == RadianZoonStates.Maxing)
            {
                if (this.RadianIsRotate == true)
                {
                    for (int i = 1; i < this.Items.Count; i++)
                    {
                        this.Items[i].AnimationRadian.Start(AnimationIntervalTypes.Add, 0);
                    }
                }
                this.radianZoonState = RadianZoonStates.Max;
            }
        }

        #endregion

        /// <summary>
        /// 初始化圆弧控件大小位置
        /// </summary>
        private void InitializeRectangle()
        {
            float client_width = this.ClientRectangle.Width;
            float client_height = this.ClientRectangle.Height;
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
                    this.Items[i].RadianMaxRectF = new RectangleF(max_x, max_y, max_w, max_h);
                    this.Items[i].RadianNowRectF = this.Items[i].RadianNormalRectF;

                    GraphicsPath gp_out = new GraphicsPath();
                    gp_out.AddEllipse(this.Items[i].RadianNormalRectF);
                    this.Items[i].RadianPath = gp_out;
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
                    this.Items[i].RadianMaxRectF = new RectangleF(max_x, max_y, max_w, max_h);
                    this.Items[i].RadianHideRectF = new RectangleF(this.Items[0].RadianNormalRectF.X, this.Items[0].RadianNormalRectF.Y, this.Items[0].RadianNormalRectF.Width, this.Items[0].RadianNormalRectF.Height);
                    this.Items[i].RadianNowRectF = this.Items[i].RadianNormalRectF;

                    this.Items[i].RadianNormalWidth = this.RadianWidth;
                    this.Items[i].RadianMaxWidth = this.RadianWidth + this.RadianWidthShakeLargen * 2;
                    this.Items[i].RadianNowWidth = this.RadianWidth;
                    this.Items[i].RadianNowStartAngle = this.Items[i].RadianStartAngle;

                    GraphicsPath gp_out = new GraphicsPath();
                    GraphicsPath gp_in = new GraphicsPath();
                    gp_out.AddArc(this.Items[i].RadianNormalRectF.X, this.Items[i].RadianNormalRectF.Y, this.Items[i].RadianNormalRectF.Width, this.Items[i].RadianNormalRectF.Height, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                    gp_in.AddArc(this.Items[i].RadianNormalRectF.X + this.Items[i].RadianNormalWidth, this.Items[i].RadianNormalRectF.Y + this.Items[i].RadianNormalWidth, this.Items[i].RadianNormalRectF.Width - this.Items[i].RadianNormalWidth * 2, this.Items[i].RadianNormalRectF.Height - this.Items[i].RadianNormalWidth * 2, this.Items[i].RadianNowStartAngle, this.Items[i].RadianSweepAngle);
                    gp_in.Reverse();
                    gp_out.AddPath(gp_in, true);
                    gp_out.CloseFigure();
                    this.Items[i].RadianPath = gp_out;
                }
                #endregion
                #region
                if (!this.DesignMode)
                {
                    if (this.Items[i].AnimationShake == null)
                    {
                        this.Items[i].AnimationShake = new AnimationTimer(this, new AnimationOptions());
                        this.Items[i].AnimationShake.Options.Data = this.Items[i];
                        this.Items[i].AnimationShake.Animationing += new AnimationTimer.AnimationEventHandler(this.AnimationShake_Animationing);
                        this.Items[i].AnimationShake.AnimationEnding += new AnimationTimer.AnimationEventHandler(this.AnimationShake_AnimationEnding);
                    }
                }
                #endregion
            }
            this.InitializeText();
        }

        /// <summary>
        /// 初始化圆弧文本
        /// </summary>
        private void InitializeText()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].TextSize = g.MeasureString(this.Items[i].Text, this.Items[i].TextFont);
            }
            g.Dispose();
        }

        /// <summary>
        /// 加载旋转动画
        /// </summary>
        private void InitializeRadianAnimation()
        {
            for (int i = 1; i < this.Items.Count; i++)
            {
                if (this.Items[i].RadianRotateValue != 0)
                {
                    this.Items[i].AnimationRadian = new AnimationTimer(this, new AnimationOptions() { EveryNewTimer = false });
                    this.Items[i].AnimationRadian.Animationing += new AnimationTimer.AnimationEventHandler(this.AnimationRadian_Animationing);
                    this.Items[i].AnimationRadian.AnimationRepetition += new AnimationTimer.AnimationEventHandler(this.AnimationRadian_AnimationRepetition);

                    this.Items[i].AnimationRadian.Options.AnimationTimerType = AnimationTimerTypes.AlwaysRepeatAnimation;
                    this.Items[i].AnimationRadian.Options.Data = this.Items[i];
                    this.Items[i].AnimationRadian.Options.AllTransformValue = this.Items[i].RadianRotateValue;
                    this.Items[i].AnimationRadian.Options.AllTransformTime = this.RadianRotateTime;
                    this.Items[i].AnimationRadian.AnimationType = AnimationTypes.UniformMotion;
                    this.Items[i].AnimationRadian.Options.EveryNewTimer = false;
                    this.Items[i].AnimationRadian.Start(AnimationIntervalTypes.Add, 0);
                }
            }
        }

        /// <summary>
        /// 卸载旋转动画
        /// </summary>
        private void UnInitializeRadianAnimation()
        {
            for (int i = 1; i < this.Items.Count; i++)
            {
                if (this.Items[i].RadianRotateValue != 0)
                {
                    if (this.Items[i].AnimationRadian != null)
                    {
                        this.Items[i].AnimationRadian.Dispose();
                        this.Items[i].AnimationRadian = null;
                    }
                }
            }
        }

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
            private RadianMenuExt owner;

            public RadianMenuItemCollection(RadianMenuExt owner)
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
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    RadianMenuItem item = (RadianMenuItem)this.radianMenuItemList[i];
                    if (item.AnimationShake != null)
                    {
                        item.AnimationShake.Dispose();
                        item.AnimationShake = null;
                    }
                    if (item.AnimationRadian != null)
                    {
                        item.AnimationRadian.Dispose();
                        item.AnimationRadian = null;
                    }
                    if (item.RadianPath != null)
                    {
                        item.RadianPath.Dispose();
                        item.RadianPath = null;
                    }
                    if (item.TextFont != null)
                    {
                        item.TextFont.Dispose();
                        item.TextFont = null;
                    }
                }
                this.radianMenuItemList.Clear();
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
                if (item.AnimationShake != null)
                {
                    item.AnimationShake.Dispose();
                    item.AnimationShake = null;
                }
                if (item.AnimationRadian != null)
                {
                    item.AnimationRadian.Dispose();
                    item.AnimationRadian = null;
                }
                if (item.RadianPath != null)
                {
                    item.RadianPath.Dispose();
                    item.RadianPath = null;
                }
                if (item.TextFont != null)
                {
                    item.TextFont.Dispose();
                    item.TextFont = null;
                }
                this.radianMenuItemList.Remove(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public void Remove(RadianMenuItem item)
            {
                if (item.AnimationShake != null)
                {
                    item.AnimationShake.Dispose();
                    item.AnimationShake = null;
                }
                if (item.AnimationRadian != null)
                {
                    item.AnimationRadian.Dispose();
                    item.AnimationRadian = null;
                }
                if (item.RadianPath != null)
                {
                    item.RadianPath.Dispose();
                    item.RadianPath = null;
                }
                if (item.TextFont != null)
                {
                    item.TextFont.Dispose();
                    item.TextFont = null;
                }
                this.radianMenuItemList.Remove(item);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                RadianMenuItem item = (RadianMenuItem)this.radianMenuItemList[index];
                if (item.AnimationShake != null)
                {
                    item.AnimationShake.Dispose();
                    item.AnimationShake = null;
                }
                if (item.AnimationRadian != null)
                {
                    item.AnimationRadian.Dispose();
                    item.AnimationRadian = null;
                }
                if (item.RadianPath != null)
                {
                    item.RadianPath.Dispose();
                    item.RadianPath = null;
                }
                if (item.TextFont != null)
                {
                    item.TextFont.Dispose();
                    item.TextFont = null;
                }
                this.radianMenuItemList.RemoveAt(index);
                this.owner.InitializeRectangle();
                this.owner.Invalidate();
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
            private int index = -1;
            /// <summary>
            /// 当前圆弧索引
            /// </summary>
            [Browsable(false)]
            [DefaultValue(-1)]
            [Description("当前圆弧索引")]
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

            private AnimationTimer animationShake = null;
            /// <summary>
            /// 震动动画对象
            /// </summary>
            [Browsable(false)]
            [DefaultValue(null)]
            [Description("震动动画对象")]
            public AnimationTimer AnimationShake
            {
                get { return this.animationShake; }
                set
                {
                    if (this.animationShake == value)
                        return;
                    this.animationShake = value;
                }
            }

            private AnimationTimer animationRadian = null;
            /// <summary>
            /// 旋转动画对象
            /// </summary>
            [Browsable(false)]
            [DefaultValue(null)]
            [Description("旋转动画对象")]
            public AnimationTimer AnimationRadian
            {
                get { return this.animationRadian; }
                set
                {
                    if (this.animationRadian == value)
                        return;
                    this.animationRadian = value;
                }
            }

            private RectangleF radianNormalRectF;
            /// <summary>
            /// 圆弧选项默认Rect
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项默认Rect")]
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

            private RectangleF radianMaxRectF;
            /// <summary>
            /// 圆弧选项最大Rect
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项最大Rect")]
            public RectangleF RadianMaxRectF
            {
                get { return this.radianMaxRectF; }
                set
                {
                    if (this.radianMaxRectF == value)
                        return;
                    this.radianMaxRectF = value;
                }
            }

            private RectangleF radianHideRectF;
            /// <summary>
            /// 圆弧选项隐藏Rect
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项隐藏Rect")]
            public RectangleF RadianHideRectF
            {
                get { return this.radianHideRectF; }
                set
                {
                    if (this.radianHideRectF == value)
                        return;
                    this.radianHideRectF = value;
                }
            }

            private RectangleF radianHideBeforeRectF;
            /// <summary>
            /// 圆弧选项隐藏前Rect
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项隐藏前Rect")]
            public RectangleF RadianHideBeforeRectF
            {
                get { return this.radianHideBeforeRectF; }
                set
                {
                    if (this.radianHideBeforeRectF == value)
                        return;
                    this.radianHideBeforeRectF = value;
                }
            }

            private RectangleF radianNowRectF;
            /// <summary>
            /// 圆弧选项当前Rect
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项当前Rect")]
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

            private float radianHideProgress = 100f;
            /// <summary>
            /// 圆弧选项隐藏过程进度
            /// </summary>
            [Browsable(false)]
            [DefaultValue(100f)]
            [Description("圆弧选项隐藏过程进度")]
            public float RadianHideProgress
            {
                get { return this.radianHideProgress; }
                set
                {
                    if (this.radianHideProgress == value)
                        return;
                    this.radianHideProgress = value;
                }
            }

            private GraphicsPath radianPath = new GraphicsPath();
            /// <summary>
            /// 圆弧选项Path
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项Path")]
            public GraphicsPath RadianPath
            {
                get { return this.radianPath; }
                set
                {
                    if (this.radianPath == value)
                        return;
                    this.radianPath = value;
                }
            }

            private RadianMoveStates radianMoveState = RadianMoveStates.Leave;
            /// <summary>
            /// 圆弧选项鼠标状态
            /// </summary>
            [Browsable(false)]
            [Description("圆弧选项鼠标状态")]
            public RadianMoveStates RadianMoveState
            {
                get { return this.radianMoveState; }
                set
                {
                    if (this.radianMoveState == value)
                        return;
                    this.radianMoveState = value;
                }
            }

            private string text = "";
            /// <summary>
            /// 圆弧选项文本
            /// </summary>
            [Browsable(true)]
            [DefaultValue("")]
            [Description("圆弧选项文本")]
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
                }
            }

            private SizeF textSize = SizeF.Empty;
            /// <summary>
            /// 文本大小
            /// </summary>
            [Browsable(false)]
            [DefaultValue(typeof(Font), "0,0")]
            [Description("文本大小")]
            public SizeF TextSize
            {
                get
                {
                    return this.textSize;
                }
                set
                {
                    if (this.textSize == value)
                        return;
                    this.textSize = value;
                }
            }

            private Color textColor = Color.White;
            /// <summary>
            /// 文本字体颜色
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "White")]
            [Description("文本字体颜色")]
            public Color TextColor
            {
                get { return this.textColor; }
                set
                {
                    if (this.textColor == value)
                        return;
                    this.textColor = value;
                }
            }

            private Color radianColor = Color.YellowGreen;
            /// <summary>
            /// 圆弧颜色
            /// </summary>
            [Browsable(true)]
            [DefaultValue(typeof(Color), "YellowGreen")]
            [Description("圆弧颜色")]
            public Color RadianColor
            {
                get { return this.radianColor; }
                set
                {
                    if (this.radianColor == value)
                        return;
                    this.radianColor = value;
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

            private float radianNowStartAngle;
            /// <summary>
            /// 当前圆弧开始角度
            /// </summary>
            [Browsable(false)]
            [Description("当前圆弧开始角度")]
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

            private int radianNormalWidth;
            /// <summary>
            /// 圆弧默认宽度
            /// </summary>
            [Browsable(false)]
            [Description("圆弧默认宽度")]
            public int RadianNormalWidth
            {
                get { return this.radianNormalWidth; }
                set
                {
                    if (this.radianNormalWidth == value)
                        return;
                    this.radianNormalWidth = value;
                }
            }

            private int radianMaxWidth;
            /// <summary>
            /// 圆弧最大宽度
            /// </summary>
            [Browsable(false)]
            [Description("圆弧最大宽度")]
            public int RadianMaxWidth
            {
                get { return this.radianMaxWidth; }
                set
                {
                    if (this.radianMaxWidth == value)
                        return;
                    this.radianMaxWidth = value;
                }
            }

            private int radianNowWidth;
            /// <summary>
            /// 当前圆弧宽度
            /// </summary>
            [Browsable(false)]
            [Description("当前圆弧宽度")]
            public int RadianNowWidth
            {
                get { return this.radianNowWidth; }
                set
                {
                    if (this.radianNowWidth == value)
                        return;
                    this.radianNowWidth = value;
                }
            }
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
        public enum RadianMoveStates
        {
            /// <summary>
            /// 光标已离开可视区
            /// </summary>
            Leave,
            /// <summary>
            /// 光标已离开可视区(动画还在进行中)
            /// </summary>
            LeaveAnimation,
            /// <summary>
            /// 光标已进入可视区
            /// </summary>
            Enter,
            /// <summary>
            /// 光标已进入可视区(动画还在进行中)
            /// </summary>
            EnterAnimation
        }

        /// <summary>
        /// 控件缩放状态
        /// </summary>
        [Description("控件缩放状态")]
        public enum RadianZoonStates
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
        #endregion
    }

}
