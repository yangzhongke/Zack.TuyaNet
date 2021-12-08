
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
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 验证码图片控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("验证码图片控件")]
    [DefaultProperty("")]
    [DefaultEvent("ValidCodeChanged")]
    [Designer(typeof(DottedLineBorderExtDesigner))]
    public class ValidCodeExt : Control
    {
        #region 新增事件

        public delegate void ValidCodeChangedEventHandler(object sender, ValidCodeChangedEventArgs e);
        private event ValidCodeChangedEventHandler validCodeChanged;
        /// <summary>
        /// 验证码更改事件
        /// </summary>
        [Description("验证码更改事件")]
        public event ValidCodeChangedEventHandler ValidCodeChanged
        {
            add { this.validCodeChanged += value; }
            remove { this.validCodeChanged -= value; }
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

        private string validCode = "";
        /// <summary>
        ///验证码
        /// </summary>
        [Browsable(false)]
        [DefaultValue("")]
        [Description("验证码")]
        public string ValidCode
        {
            get { return this.validCode; }
        }

        private bool animationShow = true;
        /// <summary>   
        /// 是否为动画验证码   
        /// </summary>  
        [DefaultValue(true)]
        [Description("是否为动画验证码")]
        public bool AnimationShow
        {
            get { return this.animationShow; }
            set
            {
                if (this.animationShow == value)
                    return;
                this.animationShow = value;
            }
        }

        private VerificationCode.GifFrameType animationType = VerificationCode.GifFrameType.EveryFrame;
        /// <summary>   
        /// 动态验证码类型   
        /// </summary>  
        [DefaultValue(VerificationCode.GifFrameType.EveryFrame)]
        [Description("动态验证码类型")]
        public VerificationCode.GifFrameType AnimationType
        {
            get { return this.animationType; }
            set
            {
                if (this.animationType == value)
                    return;
                this.animationType = value;
            }
        }

        private ValidCodeTypes validCodeType = ValidCodeTypes.Number;
        /// <summary>   
        /// 验证码类型   
        /// </summary>  
        [DefaultValue(ValidCodeTypes.Number)]
        [Description("验证码类型")]
        public ValidCodeTypes ValidCodeType
        {
            get { return this.validCodeType; }
            set
            {
                if (this.validCodeType == value)
                    return;
                this.validCodeType = value;
            }
        }

        private int chineseNumber = 4;
        /// <summary>   
        /// 数字或汉字的个数(限制于 ValidCodeTypes.Chinese、ValidCodeTypes.Number)
        /// </summary>  
        [DefaultValue(4)]
        [Description("数字或汉字的个数(限制于 ValidCodeTypes.Chinese、ValidCodeTypes.Number)")]
        public int ChineseNumber
        {
            get { return this.chineseNumber; }
            set
            {
                if (this.chineseNumber == value || value < 1)
                    return;
                this.chineseNumber = value;
            }
        }

        private Color fontStartColor = Color.FromArgb(193, 0, 91);
        /// <summary>
        /// 文本开始颜色
        /// </summary>
        [DefaultValue(typeof(Color), "193, 0, 91")]
        [Description("文本开始颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color FontStartColor
        {
            get { return this.fontStartColor; }
            set
            {
                if (this.fontStartColor == value)
                    return;
                this.fontStartColor = value;
            }
        }

        private Color fontEndColor = Color.FromArgb(136, 193, 0);
        /// <summary>
        /// 文本结束颜色
        /// </summary>
        [DefaultValue(typeof(Color), "136, 193, 0")]
        [Description("文本结束颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color FontEndColor
        {
            get { return this.fontEndColor; }
            set
            {
                if (this.fontEndColor == value)
                    return;
                this.fontEndColor = value;
            }
        }

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

        #endregion

        #region 重写属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(Color), "White")]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(Font), "微软雅黑, 25pt,style=Bold|Italic ")]
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
                return new Size(120, 50);
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
        /// <summary>   
        /// 图片总帧数。   
        /// </summary>  
        private int frameCount = 1;
        /// <summary>   
        /// 当前播放的帧索引   
        /// </summary>  
        private int currentFrame = 0;

        /// <summary>
        /// 验证码图片
        /// </summary>
        private Image image = null;

        #endregion

        public ValidCodeExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.White;
            this.Font = new Font("微软雅黑", 25, FontStyle.Bold | FontStyle.Italic);
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (this.image != null)
            {
                lock (this.image)
                {
                    g.DrawImage(this.image, new Point(0, 0));
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

        protected virtual void OnValidCodeChanged(ValidCodeChangedEventArgs e)
        {
            if (this.validCodeChanged != null)
            {
                this.validCodeChanged(this, e);
            }
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 刷新验证码
        /// </summary>
        public void ResetCode()
        {
            if (this.DesignMode)
                return;

            VerificationCode.ArithmeticEquation ae = new VerificationCode.ArithmeticEquation();
            if (this.ValidCodeType == ValidCodeTypes.Arithmetic)
            {
                ae = VerificationCode.CreateValidateArithmetic();
            }
            else if (this.ValidCodeType == ValidCodeTypes.Chinese)
            {
                string va = VerificationCode.CreateValidateChinese(this.ChineseNumber);
                ae.value = va;
                ae.text = VerificationCode.StringToArray(va);
            }
            else
            {
                string va = VerificationCode.CreateValidateNumber(this.ChineseNumber);
                ae.value = va;
                ae.text = VerificationCode.StringToArray(va);
            }

            VerificationCode.BitmapParam bp = new VerificationCode.BitmapParam(ae.text, this.Width, this.Height, this.BackColor, this.Font, this.fontStartColor, this.fontEndColor);
            Image image = VerificationCode.CreateValidateImage(bp, new VerificationCode.BitmapStyle() { IsGif = this.AnimationShow, Repeat = 0, FrameType = this.AnimationType, Delay = this.AnimationType == VerificationCode.GifFrameType.EveryFrame ? 500 : 1000 });

            this.StopAnimation();

            if (this.image == null)
            {
                this.image = image;
                this.validCode = ae.value;
            }
            else
            {
                lock (this.image)
                {
                    Image img = this.image;
                    this.image = image;
                    this.validCode = ae.value;
                    img.Dispose();
                }
            }

            lock (this.image)
            {
                if (this.animationShow)//gif图片
                {
                    Guid[] guid = this.image.FrameDimensionsList;
                    this.frameDimension = new FrameDimension(guid[0]);
                    this.frameCount = this.image.GetFrameCount(this.frameDimension);
                    this.currentFrame = 0;
                    this.image.SelectActiveFrame(this.frameDimension, 0);
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
            this.OnValidCodeChanged(new ValidCodeChangedEventArgs() { ValidCode = this.ValidCode });

        }

        #endregion

        #region 私有方法

        /// <summary>   
        /// 开始循环播放动态图片   
        /// </summary>   
        private void StartAnimation()
        {
            lock (this.image)
            {
                ImageAnimator.Animate(this.image, new EventHandler(this.FrameChanged));
            }
        }

        /// <summary>   
        /// 停止循环播放动态图片  
        /// </summary>   
        private void StopAnimation()
        {
            if (this.image != null)
            {
                lock (this.image)
                {
                    ImageAnimator.StopAnimate(this.image, new EventHandler(this.FrameChanged));
                    this.resetProperty();
                }
            }
        }

        /// <summary>
        /// 重置图片信息
        /// </summary>
        private void resetProperty()
        {
            this.frameDimension = null;
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
        /// 验证码更改事件参数
        /// </summary>
        [Description("验证码更改事件参数")]
        public class ValidCodeChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 验证码
            /// </summary>
            [Description("验证码")]
            public string ValidCode { get; set; }
        }

        public class VerificationCode
        {

            //产生验证码的字符集
            private static string[] ValidateCharArray = new string[] { "2", "3", "4", "5", "6", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "R", "S", "U", "W", "X", "Y", "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", "m", "n", "p", "r", "s", "u", "w", "x", "y" };
            //产生验证码的算术符号
            private static string[] ArithmeticSymbol = new string[] { "＋", "－", "×", "÷" };

            ///<summary>
            ///生成随机验证码（数字字母）
            ///</summary>
            ///<param name="length">验证码的长度</param>
            ///<returns></returns>
            public static string CreateValidateNumber(int length)
            {
                string randomCode = "";
                int temp = -1;

                Random rand = new Random();
                for (int i = 0; i < length; i++)
                {
                    if (temp != -1)
                    {
                        rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                    }
                    int t = rand.Next(ValidateCharArray.Length);
                    if (temp != -1 && temp == t)
                    {
                        return CreateValidateNumber(length);
                    }
                    temp = t;
                    randomCode += ValidateCharArray[t];
                }
                return randomCode;
            }

            /// <summary>
            /// 生成随机验证码（常用汉字）
            /// </summary>
            /// <param name="length">要产生常用汉字的个数</param>
            /// <returns></returns>
            public static string CreateValidateChinese(int length)
            {
                /*gb2312中文编码表由区码和位码表示*/
                string randomCode = "";
                Random rand = new Random();
                Encoding encoding = Encoding.GetEncoding("gb2312");//从gb2312中文编码表提取汉字
                for (int i = 0; i < length; i++)
                {
                    int regionCode = rand.Next(16, 56); // 获取区码(常用汉字的区码范围为16-55)    
                    int locationCode = rand.Next(1, (regionCode == 55 ? 90 : 95));// 获取位码(位码范围为1-94 由于55区的90,91,92,93,94为空,故将其排除)

                    randomCode += encoding.GetString(new byte[] { (byte)(regionCode + 160), (byte)(locationCode + 160) });//区码位码分别加上A0H（160）的方法转换为存储码
                }
                return randomCode;
            }

            ///<summary>
            ///生成随机验证码（算术等式）
            ///</summary>
            ///<returns></returns>
            public static ArithmeticEquation CreateValidateArithmetic()
            {
                Random rand = new Random();
                ArithmeticEquation ai = new ArithmeticEquation();
                ai.text = new List<string>();
                ai.text.Add("");
                ai.text.Add("");
                ai.text.Add("");
                ai.text.Add("＝");

                ai.text[1] = ArithmeticSymbol[rand.Next(0, 4)];

                if (ai.text[1] == ArithmeticSymbol[0])//加
                {
                    int len = rand.Next(1, 3);
                    if (len == 1)
                    {
                        ai.text[0] = rand.Next(0, 10).ToString();
                    }
                    else
                    {
                        ai.text[0] = rand.Next(1, 10).ToString();
                        ai.text[0] += rand.Next(0, 10).ToString();
                    }

                    if (len == 1)
                    {
                        ai.text[2] = rand.Next(1, 10).ToString();
                        ai.text[2] += rand.Next(0, 10).ToString();
                    }
                    else
                    {
                        ai.text[2] = rand.Next(0, 10).ToString();
                    }
                }
                else if (ai.text[1] == ArithmeticSymbol[1])//减
                {
                    int len = rand.Next(1, 3);
                    if (len == 1)
                    {
                        ai.text[0] = rand.Next(0, 10).ToString();
                    }
                    else
                    {
                        ai.text[0] = rand.Next(1, 10).ToString();
                        ai.text[0] += rand.Next(0, 10).ToString();
                    }

                    if (len == 1)
                    {
                        ai.text[2] = rand.Next(0, int.Parse(ai.text[0]) + 1).ToString();
                    }
                    else
                    {
                        ai.text[2] = rand.Next(0, 10).ToString();
                    }
                }
                else if (ai.text[1] == ArithmeticSymbol[2])//乘
                {
                    ai.text[0] = rand.Next(1, 10).ToString();

                    ai.text[2] = rand.Next(1, 10).ToString();
                }
                else
                {
                    ai.text[2] = rand.Next(1, 10).ToString();

                    ai.text[0] = (int.Parse(ai.text[2]) * rand.Next(1, 10)).ToString();

                }

                ai.value = calculate(ai.text[1], int.Parse(ai.text[0]), int.Parse(ai.text[2])).ToString();

                return ai;
            }

            ///<summary>
            ///创建验证码的图片
            ///</summary>
            ///<param name="bitmapParam">验证码参数</param>
            ///<param name="isGif">Gif样式</param>
            public static Image CreateValidateImage(BitmapParam bitmapParam, BitmapStyle bitmapStyle)
            {
                Bitmap result = null;
                Random random = new Random();
                string text = String.Concat(bitmapParam.textarr);
                int count = bitmapParam.textarr.Count;

                Bitmap bmp_template = new Bitmap(bitmapParam.width, bitmapParam.height);
                Graphics g_template = Graphics.FromImage(bmp_template);
                #region 绘制干扰线

                g_template.Clear(bitmapParam.backColor);
                using (Pen pen = new Pen(Color.Silver))
                {
                    for (int i = 0; i < 25; i++)
                    {
                        int x1 = random.Next(bmp_template.Width);
                        int x2 = random.Next(bmp_template.Width);
                        int y1 = random.Next(bmp_template.Height);
                        int y2 = random.Next(bmp_template.Height);
                        g_template.DrawLine(pen, x1, y1, x2, y2);
                    }
                }

                #endregion

                List<Dot> dotlist = new List<Dot>();
                #region 计算干扰点坐标

                for (int i = 0; i < 100; i++)
                {
                    dotlist.Add(new Dot() { gyd = new Point(random.Next(bmp_template.Width), random.Next(bmp_template.Height)), color = Color.FromArgb(random.Next()) });
                }
                #endregion


                SizeF text_size = g_template.MeasureString(text, bitmapParam.font);
                LinearGradientBrush text_brush = new LinearGradientBrush(new Rectangle(0, 0, bmp_template.Width, bmp_template.Height), Color.FromArgb(193, 0, 91), Color.FromArgb(136, 193, 0), 1.2f, true);

                float x_align = ((float)bitmapParam.width - text_size.Width) / 2.0f;
                float y_align = ((float)bitmapParam.height - text_size.Height) / 2.0f;
                List<BitmapFrame> bitmapframelist = new List<BitmapFrame>();
                if (!bitmapStyle.IsGif || (bitmapStyle.IsGif && bitmapStyle.FrameType == GifFrameType.FullFrame))
                {
                    bitmapframelist.Add(new BitmapFrame() { frame = (Bitmap)bmp_template.Clone() });
                    using (Graphics graphics = Graphics.FromImage(bitmapframelist[0].frame))
                    {
                        graphics.DrawString(text, bitmapParam.font, text_brush, x_align, y_align);
                        foreach (Dot dot in dotlist)
                        {
                            bitmapframelist[0].frame.SetPixel(dot.gyd.X, dot.gyd.Y, dot.color);
                        }
                    }
                    if (!bitmapStyle.IsGif)
                    {
                        result = bitmapframelist[0].frame;
                    }
                    else
                    {
                        GifCore gif = new GifCore(bitmapStyle.Delay, bitmapStyle.Repeat);
                        foreach (Dot dot in dotlist)
                        {
                            bmp_template.SetPixel(dot.gyd.X, dot.gyd.Y, dot.color);
                        }
                        gif.AddFrame(bmp_template, delay: -1);
                        gif.AddFrame((Image)bitmapframelist[0].frame, delay: -1);
                        result = gif.Finish();
                        foreach (BitmapFrame item in bitmapframelist)
                        {
                            item.frame.Dispose();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        bitmapframelist.Add(new BitmapFrame() { frame = (Bitmap)bmp_template.Clone() });
                    }

                    #region 计算每一帧文字坐标


                    if (count == 1)
                    {
                        bitmapframelist[0].x = x_align;
                        bitmapframelist[0].y = y_align;
                        bitmapframelist[0].z_width = 0;
                    }
                    else
                    {
                        for (int k = 0; k < count; k++)
                        {
                            if (k == 0)
                            {
                                bitmapframelist[0].x = x_align;
                                bitmapframelist[0].y = y_align;
                                bitmapframelist[0].z_width = g_template.MeasureString(GetScopeString(bitmapParam.textarr, 0, k + 2), bitmapParam.font).Width - g_template.MeasureString(bitmapParam.textarr[k + 1], bitmapParam.font).Width;
                            }
                            else
                            {
                                bitmapframelist[k].x = bitmapframelist[k - 1].x + bitmapframelist[k - 1].z_width;
                                bitmapframelist[k].y = y_align;
                                bitmapframelist[k].z_width = g_template.MeasureString(GetScopeString(bitmapParam.textarr, 0, k + 1), bitmapParam.font).Width - g_template.MeasureString(GetScopeString(bitmapParam.textarr, 0, k), bitmapParam.font).Width;
                            }
                        }
                    }

                    #endregion

                    #region 绘制每一帧文字坐标

                    for (int k = 0; k < count; k++)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmapframelist[k].frame))
                        {
                            graphics.DrawString(bitmapParam.textarr[k], bitmapParam.font, text_brush, bitmapframelist[k].x, bitmapframelist[k].y);
                            foreach (Dot dot in dotlist) //画图片的前景干扰点
                            {
                                bitmapframelist[k].frame.SetPixel(dot.gyd.X, dot.gyd.Y, dot.color);
                            }
                        }
                    }

                    #endregion

                    #region 生成Gif

                    GifCore gif = new GifCore(bitmapStyle.Delay, bitmapStyle.Repeat);
                    if (count == 1)
                    {
                        foreach (Dot dot in dotlist)
                        {
                            bmp_template.SetPixel(dot.gyd.X, dot.gyd.Y, dot.color);
                        }
                        gif.AddFrame(bmp_template, delay: -1);
                    }
                    foreach (BitmapFrame item in bitmapframelist)
                    {
                        gif.AddFrame((Image)item.frame, delay: -1);
                    }
                    result = gif.Finish();
                    foreach (BitmapFrame item in bitmapframelist)
                    {
                        item.frame.Dispose();
                    }

                    #endregion
                }

                text_brush.Dispose();
                g_template.Dispose();
                bmp_template.Dispose();

                using (MemoryStream ms = new MemoryStream())
                {
                    result.Save(ms, bitmapStyle.IsGif ? ImageFormat.Gif : ImageFormat.Jpeg);
                    if (result != null)
                        result.Dispose();
                    return Image.FromStream(new MemoryStream(ms.ToArray()));
                }
            }

            /// <summary>
            /// 拆分文本
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public static List<string> StringToArray(string str)
            {
                str = str.Trim();
                List<string> result = new List<string>();
                for (int i = 0; i < str.Length; i++)
                {
                    result.Add(str.Substring(i, 1));
                }
                return result;
            }

            /// <summary>
            ///获取数组指定范围字符 
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="start"></param>
            /// <param name="len"></param>
            /// <returns></returns>
            public static string GetScopeString(List<string> arr, int start, int len)
            {
                string result = String.Empty;
                for (int i = 0; i < len; i++)
                {
                    result += arr[start + i];
                }
                return result;
            }

            /// <summary>
            /// 计算
            /// </summary>
            /// <param name="type"></param>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            private static int calculate(string type, int value1, int value2)
            {
                if (type == ArithmeticSymbol[0])//加
                {
                    return value1 + value2;
                }
                else if (type == ArithmeticSymbol[1])//减
                {
                    return value1 - value2;
                }
                else if (type == ArithmeticSymbol[2])//乘
                {
                    return value1 * value2;
                }
                else
                {
                    return value1 / value2;
                }
            }

            /// <summary>
            /// 干扰点
            /// </summary>
            private class Dot
            {
                public Point gyd;
                public Color color;
            }

            /// <summary>
            /// 图片帧
            /// </summary>
            private class BitmapFrame
            {
                /// <summary>
                /// 帧
                /// </summary>
                public Bitmap frame;
                public float x;
                public float y;
                public float z_width;
            }

            /// <summary>
            /// 验证码（算术等式）
            /// </summary>
            public class ArithmeticEquation
            {
                /// <summary>
                /// 算术等式
                /// </summary>
                public List<string> text;
                /// <summary>
                /// 算术值
                /// </summary>
                public string value;
            }

            /// <summary>
            /// Gif帧类型
            /// </summary>
            public enum GifFrameType
            {
                /// <summary>
                /// 每个字符一帧
                /// </summary>
                EveryFrame,
                /// <summary>
                /// 全部字符一帧
                /// </summary>
                FullFrame
            }

            /// <summary>
            /// 验证码参数
            /// </summary>
            public class BitmapParam
            {
                public BitmapParam(List<string> _textarr, int _width, int _height, Color _backColor, Font _font, Color _fontBrushStrat, Color _fontBrushEnd)
                {
                    this.textarr = _textarr;
                    this.width = _width;
                    this.height = _height;
                    this.backColor = _backColor;
                    this.font = _font;
                    this.fontBrushStrat = _fontBrushStrat;
                    this.fontBrushEnd = _fontBrushEnd;
                }

                /// <summary>
                /// 验证码字符集
                /// </summary>
                public List<string> textarr;
                /// <summary>
                /// 验证码图片宽
                /// </summary>
                public int width = 120;
                /// <summary>
                /// 验证码图片高
                /// </summary>
                public int height = 50;

                /// <summary>
                /// 图片背景颜色
                /// </summary>
                public Color backColor = Color.White;

                /// <summary>
                /// 验证码字体样式
                /// </summary>
                public Font font = null;

                /// <summary>
                /// 字体画笔颜色开始
                /// </summary>
                public Color fontBrushStrat = Color.FromArgb(193, 0, 91);

                /// <summary>
                /// 字体画笔颜色结束
                /// </summary>
                public Color fontBrushEnd = Color.FromArgb(136, 193, 0);

            }

            /// <summary>
            /// Gif样式
            /// </summary>
            public class BitmapStyle
            {
                public BitmapStyle()
                {

                }

                public BitmapStyle(bool _IsGif, GifFrameType _FrameType, int _Delay, int _Repeat)
                {
                    this.IsGif = _IsGif;
                    this.FrameType = _FrameType;
                    this.Delay = _Delay;
                    this.Repeat = _Repeat;
                }

                /// <summary>
                /// 是否生成Gif动画
                /// </summary>
                public bool IsGif = false;
                /// <summary>
                ///  Gif帧类型
                /// </summary>
                public GifFrameType FrameType = GifFrameType.EveryFrame;
                /// <summary>
                /// 帧之间的延迟(毫秒)
                /// </summary>
                public int Delay = 500;
                /// <summary>
                /// GIF重复计数(0表示永久)
                /// </summary>
                public int Repeat = 0;
            }
        }

        public class GifCore
        {
            private MemoryStream _stream;
            private string _filePath;
            private int _delay;
            private int _repeat;

            /// <summary>
            /// 创建一个新的动画GIF
            /// </summary>
            /// <param name="delay">帧之间的延迟(毫秒)</param>
            /// <param name="repeat">GIF重复计数(0表示永久)</param>
            /// <returns></returns>
            public GifCore(int delay = 500, int repeat = 0)
            {
                this._delay = delay;
                this._repeat = repeat;
            }

            /// <summary>
            /// 为GIF添加一个新帧
            /// </summary>
            /// <param name="image">要添加到GIF堆栈中的图像</param>
            /// <param name="delay">帧之间的延迟(毫秒)(-1:使用全局设置)</param>
            public void AddFrame(Image image, int delay = -1)
            {
                GifInfo gif = new GifInfo();
                gif.LoadGifPicture(image);

                if (this._stream == null)//创建一张新的GIF89a图片
                {
                    this._stream = new MemoryStream();
                    Write(this._stream, CreateHeaderBlock());
                    Write(this._stream, gif.LogicalScreenDescriptor.ToArray());
                    Write(this._stream, CreateApplicationExtensionBlock(this._repeat));
                }

                Write(this._stream, CreateGraphicsControlExtensionBlock(delay == -1 ? this._delay : delay));
                Write(this._stream, gif.ImageDescriptor.ToArray());
                Write(this._stream, gif.ColorTable.ToArray());
                Write(this._stream, gif.ImageData.ToArray());

            }

            /// <summary>
            /// 完成创建GIF并开始刷新
            /// </summary>
            public Bitmap Finish()
            {
                if (this._stream == null)
                    return null;
                this._stream.WriteByte(0x3B); // Image terminator
                Bitmap result = new Bitmap(this._stream);
                this._stream.Dispose();
                return result;
            }

            /// <summary>
            /// 创建GIF89a头部块（6个字节）
            /// </summary>
            private static byte[] CreateHeaderBlock()
            {
                //标识符 Signature (3字节） ---GIF
                //版本   Version  （3字节） ---87a (or 89a)
                return new[] { (byte)'G', (byte)'I', (byte)'F', (byte)'8', (byte)'9', (byte)'a' };
            }

            /// <summary>
            /// 创建应用程序扩充块
            /// </summary>
            /// <param name="repeat"></param>
            /// <returns></returns>
            private static byte[] CreateApplicationExtensionBlock(int repeat)
            {
                byte[] buffer = new byte[19];
                buffer[0] = 0x21; // Extension introducer
                buffer[1] = 0xFF; // Application extension
                buffer[2] = 0x0B; // Size of block
                buffer[3] = (byte)'N'; // NETSCAPE2.0
                buffer[4] = (byte)'E';
                buffer[5] = (byte)'T';
                buffer[6] = (byte)'S';
                buffer[7] = (byte)'C';
                buffer[8] = (byte)'A';
                buffer[9] = (byte)'P';
                buffer[10] = (byte)'E';
                buffer[11] = (byte)'2';
                buffer[12] = (byte)'.';
                buffer[13] = (byte)'0';
                buffer[14] = 0x03; // Size of block
                buffer[15] = 0x01; // Loop indicator
                buffer[16] = (byte)(repeat % 0x100); // 指定重复次数
                buffer[17] = (byte)(repeat / 0x100); // 0代表无穷循环
                buffer[18] = 0x00; // Block terminator
                return buffer;
            }

            /// <summary>
            /// 创建图像控制扩展块(这个块可选)（8个字节）
            /// </summary>
            /// <param name="delay"></param>
            /// <returns></returns>
            private static byte[] CreateGraphicsControlExtensionBlock(int delay)
            {
                byte[] buffer = new byte[8];
                buffer[0] = 0x21; // Extension Introducer - 标识一个extension块的开始，这个字段值为0x21。
                buffer[1] = 0xF9; // Graphic Control Label - 标识当前块为一个Graphic Control Extension。这个字段值为0xF9。
                buffer[2] = 0x04; // Block Size - 在块中的字节数，在这个Block Size Field之后，直到但是并不包括Block Terminator，这个field包含固定的值4。
                buffer[3] = 0x09; // Flags: reserved, disposal method, user input, transparent color
                buffer[4] = (byte)(delay / 10 % 0x100); // Delay time low byte
                buffer[5] = (byte)(delay / 10 / 0x100); // Delay time high byte
                buffer[6] = 0xFF; // Transparent color index
                buffer[7] = 0x00; // Block terminator
                return buffer;
            }

            private static void Write(MemoryStream stream, byte[] array)
            {
                stream.Write(array, 0, array.Length);
            }

        }

        public class GifInfo
        {
            /// <summary>
            /// 图片颜色表
            /// </summary>
            public List<byte> ColorTable = new List<byte>();
            /// <summary>
            /// 图片数据
            /// </summary>
            public List<byte> ImageData = new List<byte>();
            /// <summary>
            /// 图像描述块信息
            /// </summary>
            public List<byte> ImageDescriptor = new List<byte>();
            /// <summary>
            /// 逻辑屏幕描述符块信息
            /// </summary>
            public List<byte> LogicalScreenDescriptor = new List<byte>();

            /// <summary>
            /// 加载指定图片
            /// </summary>
            /// <param name="img"></param>
            public void LoadGifPicture(Image img)
            {
                List<byte> dataList;

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Gif);
                    dataList = new List<byte>(ms.ToArray());
                }

                this.AnalyzeHeader(dataList);
                this.AnalyzeLogicalScreenDescriptor(dataList);

                var blockType = this.GetTypeOfNextBlock(dataList);
                while (blockType != GifBlockType.Trailer)
                {
                    switch (blockType)
                    {
                        case GifBlockType.ImageDescriptor:
                            this.AnalyzeImageDescriptor(dataList);
                            break;
                        case GifBlockType.Extension:
                            this.ThrowAwayExtensionBlock(dataList);
                            break;
                    }
                    blockType = this.GetTypeOfNextBlock(dataList);
                }
            }

            /// <summary>
            /// 分析图片文件头块(6个字节)
            /// </summary>
            /// <param name="gifData"></param>
            /// <returns></returns>
            private void AnalyzeHeader(List<byte> gifData)
            {
                gifData.RemoveRange(0, 6);
            }

            /// <summary>
            /// 分析逻辑屏幕描述符块(7个字节)
            /// </summary>
            /// <param name="gifData"></param>
            private void AnalyzeLogicalScreenDescriptor(List<byte> gifData)
            {
                for (int i = 0; i < 7; i++)//提取逻辑屏幕描述块
                {
                    this.LogicalScreenDescriptor.Add(gifData[i]);
                }
                gifData.RemoveRange(0, 7);

                bool globalColorTableFollows = (this.LogicalScreenDescriptor[4] & 0x80) != 0;//全局颜色表

                if (globalColorTableFollows)
                {
                    int pixel = this.LogicalScreenDescriptor[4] & 0x07;
                    int lengthOfColorTableInByte = 3 * (int)Math.Pow(2, pixel + 1);
                    for (int i = 0; i < lengthOfColorTableInByte; i++)
                    {
                        this.ColorTable.Add(gifData[i]);
                    }
                    gifData.RemoveRange(0, lengthOfColorTableInByte);
                }

                this.LogicalScreenDescriptor[4] = (byte)(this.LogicalScreenDescriptor[4] & 0x7F);
            }

            /// <summary>
            /// 分析图像描述块(10个字节)
            /// </summary>
            /// <param name="gifData"></param>
            private void AnalyzeImageDescriptor(List<byte> gifData)
            {
                for (int i = 0; i < 10; i++)
                {
                    this.ImageDescriptor.Add(gifData[i]);
                }
                gifData.RemoveRange(0, 10);

                bool localColorMapFollows = (this.ImageDescriptor[9] & 0x80) != 0;//本地颜色表
                if (localColorMapFollows)
                {
                    this.ColorTable.Clear();
                    int pixel = this.ImageDescriptor[9] & 0x07;
                    int lengthOfColorTableInByte = 3 * (int)Math.Pow(2, pixel + 1);
                    for (int i = 0; i < lengthOfColorTableInByte; i++)
                    {
                        this.ColorTable.Add(gifData[i]);
                    }
                    gifData.RemoveRange(0, lengthOfColorTableInByte);
                }
                else
                {
                    int lastThreeBitsOfGlobalTableDescription = this.LogicalScreenDescriptor[4] & 0x07;
                    this.ImageDescriptor[9] = (byte)(this.ImageDescriptor[9] & 0xF8);
                    this.ImageDescriptor[9] = (byte)(this.ImageDescriptor[9] | lastThreeBitsOfGlobalTableDescription);
                }

                this.ImageDescriptor[9] = (byte)(this.ImageDescriptor[9] | 0x80);
                this.GetImageData(gifData);
            }

            /// <summary>
            /// 获取图片数据
            /// </summary>
            /// <param name="gifData"></param>
            private void GetImageData(List<byte> gifData)
            {
                this.ImageData.Add(gifData[0]);
                gifData.RemoveAt(0);

                while (gifData[0] != 0x00)//0x00表示后面已经没有图片数据
                {
                    int countOfFollowingDataBytes = gifData[0];
                    for (int i = 0; i <= countOfFollowingDataBytes; i++)
                    {
                        this.ImageData.Add(gifData[i]);
                    }
                    gifData.RemoveRange(0, countOfFollowingDataBytes + 1);
                }

                this.ImageData.Add(gifData[0]);
                gifData.RemoveAt(0);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="gifData"></param>
            private void ThrowAwayExtensionBlock(List<byte> gifData)
            {
                gifData.RemoveRange(0, 2); // Delete ExtensionBlockIndicator and ExtensionDetermination

                while (gifData[0] != 0)
                {
                    gifData.RemoveRange(0, gifData[0] + 1);
                }
                gifData.RemoveAt(0);
            }

            /// <summary>
            /// 获取下一个区块类型
            /// </summary>
            /// <param name="gifData"></param>
            /// <returns></returns>
            private GifBlockType GetTypeOfNextBlock(List<byte> gifData)
            {
                return (GifBlockType)gifData[0];
            }

            /// <summary>
            /// 类型转换
            /// </summary>
            /// <param name="b"></param>
            /// <returns></returns>
            private char ByteToChar(byte b)
            {
                return (char)b;
            }

            /// <summary>
            /// 区块类型
            /// </summary>
            public enum GifBlockType
            {
                /// <summary>
                /// 图像描述块
                /// </summary>
                ImageDescriptor = 0x2C,
                /// <summary>
                /// 
                /// </summary>
                Extension = 0x21,
                /// <summary>
                /// 文件尾端标志块(固定为3B)
                /// </summary>
                Trailer = 0x3B
            }

        }

        #endregion

        #region 枚举

        /// <summary>
        /// 验证码类型
        /// </summary>
        [Description("验证码类型")]
        public enum ValidCodeTypes
        {
            /// <summary>
            /// 算术
            /// </summary>
            Arithmetic,
            /// <summary>
            /// 汉字
            /// </summary>
            Chinese,
            /// <summary>
            /// 数字字母
            /// </summary>
            Number
        }

        #endregion

    }

}
