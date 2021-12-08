
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
using System.Drawing.Imaging;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 动态图片显示控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("动态图片显示控件")]
    [DefaultProperty("Image")]
    [DefaultEvent("ImageChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class ImageExt : Control
    {
        #region 新增事件

        public delegate void ImageChangedEventHandler(object sender, ImageChangedEventArgs e);
        private event ImageChangedEventHandler imageChanged;
        /// <summary>
        /// 图片引更改事件
        /// </summary>
        [Description("图片引更改事件")]
        public event ImageChangedEventHandler ImageChanged
        {
            add { this.imageChanged += value; }
            remove { this.imageChanged -= value; }
        }

        public delegate void FrameIndexChangedEventHandler(object sender, FrameIndexChangedEventArgs e);
        private event FrameIndexChangedEventHandler frameIndexChanged;
        /// <summary>
        /// 活动帧的索引更改事件
        /// </summary>
        [Description("活动帧的索引更改事件")]
        public event FrameIndexChangedEventHandler FrameIndexChanged
        {
            add { this.frameIndexChanged += value; }
            remove { this.frameIndexChanged -= value; }
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

        private bool isAnimation;
        /// <summary>   
        /// 是否为动态图片   
        /// </summary>  
        [Browsable(false)]
        [DefaultValue(false)]
        [Description("是否为动态图片")]
        public bool IsAnimation
        {
            get { return this.isAnimation; }
        }

        private Image image = null;
        /// <summary>   
        /// 要显示的图片   
        /// </summary>
        [Browsable(true)]
        [DefaultValue(null)]
        [Description("要显示的图片")]
        public Image Image
        {
            get { return this.image; }
            set
            {
                if (this.image == value)
                    return;

                if (value == null)//清除图片
                {
                    if (this.isAnimation)
                    {
                        this.StopAnimation();
                    }
                    this.image = value;
                    this.Invalidate();

                    if (!this.DesignMode)
                    {
                        this.OnImageChanged(new ImageChangedEventArgs() { Image = this.image });
                    }
                }
                else//加载图片
                {
                    if (this.isAnimation)
                    {
                        this.StopAnimation();
                    }
                    this.image = value;

                    if (!this.DesignMode)
                    {
                        this.OnImageChanged(new ImageChangedEventArgs() { Image = this.image });
                    }

                    lock (this.image)
                    {
                        this.isAnimation = ImageAnimator.CanAnimate(this.image);
                        if (this.isAnimation)//gif图片
                        {
                            Guid[] guid = this.image.FrameDimensionsList;
                            this.frameDimension = new FrameDimension(guid[0]);
                            this.frameCount = this.image.GetFrameCount(this.frameDimension);
                            this.currentFrame = 0;
                            this.image.SelectActiveFrame(this.frameDimension, this.currentFrame);
                            this.Invalidate();
                            this.StartAnimation();
                        }
                        else//普通图片
                        {
                            this.frameCount = 1;
                            this.currentFrame = 0;
                            this.Invalidate();
                        }
                    }
                }
            }
        }

        private int frameCount = 1;
        /// <summary>   
        /// 图片总帧数。   
        /// </summary>  
        [Browsable(false)]
        [DefaultValue(1)]
        [Description("图片总帧数")]
        public int FrameCount
        {
            get { return this.frameCount; }
        }

        private int currentFrame = 0;
        /// <summary>   
        /// 当前播放的帧索引   
        /// </summary>   
        [Browsable(false)]
        [DefaultValue(0)]
        [Description("当前播放的帧数")]
        public int CurrentFrame
        {
            get { return this.currentFrame; }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        #region 字段

        /// <summary>
        /// 图像的框架维度的属性
        /// </summary>
        private FrameDimension frameDimension;

        #endregion

        public ImageExt()
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

            if (this.Image != null)
            {
                lock (this.Image)
                {
                    g.DrawImage(this.Image, new Point(0, 0));
                }
            }

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

        protected virtual void OnImageChanged(ImageChangedEventArgs e)
        {
            if (this.imageChanged != null)
            {
                this.imageChanged(this, e);
            }
        }

        protected virtual void OnFrameIndexChanged(FrameIndexChangedEventArgs e)
        {
            if (this.frameIndexChanged != null)
            {
                this.frameIndexChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 刷新图片
        /// </summary>
        public void ResetImage()
        {
            if (this.Image == null)//清除图片
            {
                if (this.isAnimation)
                {
                    this.StopAnimation();
                }
                this.Invalidate();
            }
            else//加载图片
            {
                if (this.isAnimation)
                {
                    this.StopAnimation();
                }

                lock (this.image)
                {
                    this.isAnimation = ImageAnimator.CanAnimate(this.image);
                    if (this.isAnimation)//gif图片
                    {
                        Guid[] guid = this.image.FrameDimensionsList;
                        this.frameDimension = new FrameDimension(guid[0]);
                        this.frameCount = this.image.GetFrameCount(this.frameDimension);
                        this.currentFrame = 0;
                        this.image.SelectActiveFrame(this.frameDimension, this.currentFrame);
                        this.Invalidate();
                        this.StartAnimation();
                    }
                    else//普通图片
                    {
                        this.frameCount = 1;
                        this.currentFrame = 0;
                        this.Invalidate();
                    }
                }
            }
        }

        #endregion

        #region 私有方法

        /// <summary>   
        /// 开始循环播放动态图片   
        /// </summary>   
        private void StartAnimation()
        {
            lock (this.Image)
            {
                ImageAnimator.Animate(this.Image, new EventHandler(this.FrameChanged));


                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new FrameIndexChangedEventArgs() { FrameIndex = currentFrame });
                }
            }
        }

        /// <summary>   
        /// 停止循环播放动态图片  
        /// </summary>   
        private void StopAnimation()
        {
            lock (this.Image)
            {
                ImageAnimator.StopAnimate(this.Image, new EventHandler(this.FrameChanged));
                this.resetProperty();

                if (!this.DesignMode)
                {
                    this.OnFrameIndexChanged(new FrameIndexChangedEventArgs() { FrameIndex = currentFrame });
                }
            }
        }

        /// <summary>
        /// 重置图片信息
        /// </summary>
        private void resetProperty()
        {
            this.frameDimension = null;
            this.isAnimation = false;
            this.frameCount = 0;
            this.currentFrame = -1;
        }

        /// <summary>
        /// 当前帧更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrameChanged(object sender, EventArgs e)
        {
            this.currentFrame = this.currentFrame + 1 >= this.frameCount ? 0 : this.currentFrame + 1;
            lock (this.image)
            {
                this.image.SelectActiveFrame(this.frameDimension, this.currentFrame);
                this.Invalidate();
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 图片更改事件参数
        /// </summary>
        [Description("图片更改事件参数")]
        public class ImageChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 图片
            /// </summary>
            [Description("图片")]
            public Image Image { get; set; }
        }

        /// <summary>
        /// 活动帧的索引更改事件参数
        /// </summary>
        [Description("活动帧的索引更改事件参数")]
        public class FrameIndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 活动帧的索引
            /// </summary>
            [Description("活动帧的索引")]
            public int FrameIndex { get; set; }
        }

        #endregion
    }

}
