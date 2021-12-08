
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
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// Button缩放动画扩展
    /// </summary>
    [Description("Button缩放动画扩展")]
    public class ButtonExt : Button, IAnimationStaticTimer
    {
        #region 新增属性

        private AnimationClass animation = new AnimationClass();
        /// <summary>
        /// 动画设置
        /// </summary>
        [Description("动画设置")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AnimationClass Animation
        {
            get
            {
                return this.animation;
            }
            set
            {
                this.animation = value;
            }
        }

        #endregion

        #region 重写属性

        [DefaultValue(FlatStyle.Flat)]
        public new FlatStyle FlatStyle
        {
            get
            {
                return base.FlatStyle;
            }
            set
            {
                base.FlatStyle = value;
            }
        }

        [DefaultValue(false)]
        public new bool UseVisualStyleBackColor
        {
            get
            {
                return base.UseVisualStyleBackColor;
            }
            set
            {
                base.UseVisualStyleBackColor = value;
            }
        }

        [DefaultValue(typeof(Color), "245, 168, 154")]
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

        [DefaultValue(typeof(Color), "White")]
        public override System.Drawing.Color ForeColor
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
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
                return new Size(100, 40);
            }
        }

        #endregion

        #region 字段
        /// <summary>
        /// 动画计时器方式
        /// </summary>
        private AnimationIntervalTypes animationIntervalTypes = AnimationIntervalTypes.Add;
        /// <summary>
        /// 动画已使用的时间
        /// </summary>
        private double usedTime = 0;

        private bool original_isload = false;
        private double original_w = 0.0;// 动画对象开始制定属性原始值
        private double original_h = 0.0;// 动画对象开始制定属性原始值
        private int original_x = 0;// 动画对象开始制定属性原始值
        private int original_y = 0;// 动画对象开始制定属性原始值
        #endregion

        public ButtonExt()
        {
            this.BackColor = Color.OliveDrab;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.ForeColor = Color.White;
        }

        #region 重写

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (this.DesignMode)
                return;

            this.LoadOriginal(this.original_isload);
            this.animationIntervalTypes = AnimationIntervalTypes.Add;
            AnimationStaticTimer.AnimationStart(this);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.DesignMode)
                return;

            this.LoadOriginal(this.original_isload);
            this.animationIntervalTypes = AnimationIntervalTypes.Subtrac;
            AnimationStaticTimer.AnimationStart(this);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 缩放动画中(禁止手动调用)
        /// </summary>
        [Description("缩放动画中(禁止手动调用)")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Animationing()
        {
            bool finish = false;
            if (this.animationIntervalTypes == AnimationIntervalTypes.Add)
            {
                this.usedTime += AnimationStaticTimer.timer.Interval;
                if (this.usedTime > this.Animation.ZoomTime)
                {
                    this.usedTime = this.Animation.ZoomTime;
                    AnimationStaticTimer.AnimationStop(this);
                    finish = true;
                }
            }
            else
            {
                this.usedTime -= AnimationStaticTimer.timer.Interval;
                if (this.usedTime < 0)
                {
                    this.usedTime = 0;
                    AnimationStaticTimer.AnimationStop(this);
                    finish = true;
                }
            }

            double progress = AnimationTimer.GetProgress(this.animationIntervalTypes == AnimationIntervalTypes.Add ? this.Animation.ZoomMagnifyTypes : this.Animation.ZoomShrinkTypes, this.Animation.Options, this.usedTime);
            if (finish)
            {
                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;
            }

            ButtonExt control = this;
            control.Width = (int)((double)control.original_w + this.Animation.ZoomValue * progress);
            control.Height = (int)((double)control.original_h + this.Animation.ZoomValue * progress);
            int x = (int)((this.original_w - control.Width) / 2.0);
            int y = (int)((this.original_h - control.Height) / 2.0);
            control.Location = new Point((int)this.original_x + x, (int)this.original_y + y);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化控件原始位置信息
        /// </summary>
        /// <param name="_isload"></param>
        private void LoadOriginal(bool _isload)
        {
            if (!_isload)
            {
                this.original_w = this.Width;
                this.original_h = this.Height;
                this.original_x = this.Location.X;
                this.original_y = this.Location.Y;
                this.original_isload = true;
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 动画设置
        /// </summary>
        [Description("动画设置")]
        [TypeConverter(typeof(EmptyConverter))]
        public class AnimationClass
        {
            private int zoomValue = 10;
            /// <summary>
            /// 缩放值
            /// </summary>
            [Description("缩放值")]
            [DefaultValue(10)]
            public int ZoomValue
            {
                get
                {
                    return this.zoomValue;
                }
                set
                {
                    this.zoomValue = value;
                }
            }

            /// <summary>
            /// 动画要变换的总时间(默认值250.0)
            /// </summary>
            [Description("动画要变换的总时间(默认值250.0)")]
            [DefaultValue(250.0)]
            public double ZoomTime
            {
                get { return this.Options.AllTransformTime; }
                set
                {
                    if (value > AnimationStaticTimer.leisure_maxtime / 2)
                        value = AnimationStaticTimer.leisure_maxtime / 2;

                    this.Options.AllTransformTime = value;
                }
            }

            private AnimationTypes zoomMagnifyTypes = AnimationTypes.ElasticOut;
            /// <summary>
            /// 放大动画类型
            /// </summary>
            [Description("放大动画类型")]
            [DefaultValue(AnimationTypes.ElasticOut)]
            public AnimationTypes ZoomMagnifyTypes
            {
                get
                {
                    return this.zoomMagnifyTypes;
                }
                set
                {
                    this.zoomMagnifyTypes = value;
                }
            }

            private AnimationTypes zoomShrinkTypes = AnimationTypes.BackIn;
            /// <summary>
            /// 缩小动画类型
            /// </summary>
            [Description("缩小动画类型")]
            [DefaultValue(AnimationTypes.BackIn)]
            public AnimationTypes ZoomShrinkTypes
            {
                get
                {
                    return this.zoomShrinkTypes;
                }
                set
                {
                    this.zoomShrinkTypes = value;
                }
            }

            /// <summary>
            /// 动画曲线幂(默认值3.0)
            /// (限于EaseIn、EaseOut、EaseBoth、BackIn、BackOut、BackBoth)
            /// </summary>
            [Description("动画曲线幂(默认值3)")]
            [DefaultValue(3.0)]
            public double Power
            {
                get { return this.Options.Power; }
                set { this.Options.Power = value; }
            }

            /// <summary>
            /// 收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1.0。
            /// (限于BackIn、BackOut、BackBoth)
            /// </summary>
            [Description("收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1.0")]
            [DefaultValue(1.0)]
            public double Amplitude
            {
                get { return this.Options.Amplitude; }
                set { this.Options.Amplitude = value; }
            }

            /// <summary>
            /// 反弹次数。值必须大于或等于零(默认值为3)
            /// (限于BounceIn、BounceOut、BounceBoth）
            /// </summary>
            [Description("反弹次数。值必须大于或等于零(默认值为3)")]
            [DefaultValue(3)]
            public int Bounces
            {
                get { return this.Options.Bounces; }
                set { this.Options.Bounces = value; }
            }

            /// <summary>
            /// 指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2.0)
            /// (限于BounceIn、BounceOut、BounceBoth）
            /// </summary>
            [Description("指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2.0)")]
            [DefaultValue(2.0)]
            public double Bounciness
            {
                get { return this.Options.Bounciness; }
                set { this.Options.Bounciness = value; }
            }

            /// <summary>
            /// 目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)
            /// (限于ElasticIn、ElasticOut、ElasticBoth）
            /// </summary>
            [Description("目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)")]
            [DefaultValue(3)]
            public int Oscillations
            {
                get { return this.Options.Oscillations; }
                set { this.Options.Oscillations = value; }
            }

            /// <summary>
            /// 弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3.0)
            /// (限于ElasticIn、ElasticOut、ElasticBoth）
            /// </summary>
            [Description("弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3.0)")]
            [DefaultValue(3.0)]
            public double Springiness
            {
                get { return this.Options.Springiness; }
                set { this.Options.Springiness = value; }
            }

            private AnimationOptions options = new AnimationOptions() { AllTransformTime = 250 };
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public AnimationOptions Options
            {
                get { return this.options; }
                set { this.options = value; }
            }
        }

        #endregion
    }
}
