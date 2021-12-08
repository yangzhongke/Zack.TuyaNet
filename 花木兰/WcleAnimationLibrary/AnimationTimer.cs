
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

namespace WcleAnimationLibrary
{
    /// <summary>
    /// 动画定时器类
    /// </summary>
    [Category("动画定时器类")]
    [DefaultProperty("Options")]
    [DefaultEvent("Animationing")]
    [TypeConverter(typeof(EmptyExpandableObjectConverter))]
    public class AnimationTimer : IDisposable
    {
        #region 新增事件

        public delegate void AnimationEventHandler(object sender, AnimationEventArgs e);

        private event AnimationEventHandler animationStart = null;
        /// <summary>
        /// 动画开始前事件
        /// </summary>
        [Description("动画开始前事件")]
        public event AnimationEventHandler AnimationStart
        {
            add { this.animationStart += value; }
            remove { this.animationStart -= value; }
        }

        private event AnimationEventHandler animationing = null;
        /// <summary>
        /// 动画时间间隔发生事件
        /// </summary>
        [Description("动画时间间隔发生事件")]
        public event AnimationEventHandler Animationing
        {
            add { this.animationing += value; }
            remove { this.animationing -= value; }
        }

        private event AnimationEventHandler animationEnding = null;
        /// <summary>
        /// 动画结束时事件
        /// </summary>
        [Description("动画结束时事件")]
        public event AnimationEventHandler AnimationEnding
        {
            add { this.animationEnding += value; }
            remove { this.animationEnding -= value; }
        }

        private event AnimationEventHandler animationRepetition = null;
        /// <summary>
        /// 动画重复间隔时事件
        /// </summary>
        [Description("动画重复间隔时事件")]
        public event AnimationEventHandler AnimationRepetition
        {
            add { this.animationRepetition += value; }
            remove { this.animationRepetition -= value; }
        }

        #endregion

        #region 新增属性

        public AnimationTypes animationType = AnimationTypes.EaseIn;
        /// <summary>
        /// 动画类型(默认值EaseIn)
        /// </summary>
        [Description("动画类型")]
        [DefaultValue(AnimationTypes.EaseIn)]
        public AnimationTypes AnimationType
        {
            get { return this.animationType; }
            set { this.animationType = value; }
        }

        public System.Windows.Forms.Control _control = null;
        /// <summary>
        /// 动画所属控件
        /// </summary>
        [Description("动画所属控件")]
        [DefaultValue(null)]
        public System.Windows.Forms.Control Control
        {
            get { return this._control; }
            set { this._control = value; }
        }

        private AnimationOptions options;
        /// <summary>
        /// 动画设置参数
        /// </summary>
        [Description("动画设置参数")]
        public AnimationOptions Options
        {
            get { return this.options; }
            set { this.options = value; }
        }

        private int interval = 20;
        /// <summary>
        /// 动画定时器时间间隔(默认值20毫秒)
        /// </summary>
        [Description("动画定时器时间间隔")]
        [DefaultValue(20)]
        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (this.interval == value)
                    return;
                this.interval = value;
                if (this.timer != null)
                    this.timer.Interval = this.interval;
            }
        }

        private double animationUsedTime = 0.0;
        /// <summary>
        /// 动画已经使用了多少时间(默认值0.0毫秒)
        /// </summary>
        [Description("动画已经使用了多少时间(默认值0.0毫秒)")]
        [Browsable(false)]
        [DefaultValue(0.0)]
        public double AnimationUsedTime
        {
            get { return this.animationUsedTime; }
        }

        #endregion

        #region 字段

        private bool disposed = false;

        /// <summary>
        /// 动画定时器
        /// </summary>
        private System.Windows.Forms.Timer timer = null;

        /// <summary>
        /// 添加还是减少动画时间间隔(决定动画方向)
        /// </summary>
        private AnimationIntervalTypes intervalTypes = AnimationIntervalTypes.Add;

        /// <summary>
        /// 动画进行中时间累计器
        /// </summary>
        [DefaultValue(0.0)]
        private double runTime = 0.0;

        #endregion

        #region 析构

        /// <summary>
        /// 用于组件的初始化
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationTimer()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_control">要变化动画的控件</param>
        /// <param name="_options">动画配置</param>
        public AnimationTimer(System.Windows.Forms.Control _control, AnimationOptions _options)
        {
            this._control = _control;
            this.options = _options;
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 动画开始
        /// </summary>
        /// <param name="_intervalTypes">添加还是减少动画时间间隔(决定动画方向)</param>
        /// <param name="_usedTime">动画已经使用了多少时间(默认值0.0毫秒)</param>
        public void Start(AnimationIntervalTypes _intervalTypes, double _usedTime)
        {
            this.intervalTypes = _intervalTypes;
            this.Stop();
            this.runTime = _usedTime;
            if (this.animationStart != null)
            {
                this.animationStart.Invoke(this._control, new AnimationEventArgs() { Data = this.options.Data, AllTransformValue = this.options.AllTransformValue, AnimationUsedTime = this.runTime, ProgressValue = GetProgress(this.AnimationType, this.options, this.runTime) });
            }
            if (this.timer == null || this.options.EveryNewTimer)
            {
                this.timer = new System.Windows.Forms.Timer();
                this.timer.Tick += new EventHandler(this.timer_Tick);
                this.timer.Interval = this.interval;
            }
            this.timer.Start();
        }

        /// <summary>
        /// 动画停止
        /// </summary>
        public void Stop()
        {
            if (this.timer != null)
            {
                this.timer.Enabled = false;
                if (this.options.EveryNewTimer)
                {
                    this.timer.Dispose();
                }
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Suspend()
        {
            if (this.timer != null)
            {
                this.timer.Enabled = false;
            }
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue()
        {
            if (this.timer != null)
            {
                this.timer.Enabled = true;
            }
        }

        /// <summary>
        /// 获取动画的进度（0.0-1.0）
        /// </summary>
        /// <param name="_animationType">动画类型</param>
        /// <param name="_options">动画参数</param>
        /// <param name="_usedTime">动画已经使用了多少时间</param>
        /// <returns></returns>
        public static double GetProgress(AnimationTypes _animationType, AnimationOptions _options, double _usedTime)
        {
            if (_usedTime <= 0)
                return 0.0;
            if (_usedTime >= _options.AllTransformTime)
                return 1.0;

            double result = 0.0;

            switch (_animationType)
            {
                case AnimationTypes.UniformMotion:
                    result = AnimationCore.UniformMotionCore(_usedTime, _options.AllTransformTime);
                    break;
                case AnimationTypes.EaseIn:
                    result = AnimationCore.EaseInCore(_usedTime / _options.AllTransformTime, _options.Power);
                    break;
                case AnimationTypes.EaseOut:
                    result = AnimationCore.EaseOutCore(_usedTime / _options.AllTransformTime, _options.Power);
                    break;
                case AnimationTypes.EaseBoth:
                    result = AnimationCore.EaseBothCore(_usedTime / _options.AllTransformTime, _options.Power);
                    break;
                case AnimationTypes.BackIn:
                    result = AnimationCore.BackInCore(_usedTime / _options.AllTransformTime, _options.Power, _options.Amplitude);
                    break;
                case AnimationTypes.BackOut:
                    result = AnimationCore.BackOutCore(_usedTime / _options.AllTransformTime, _options.Power, _options.Amplitude);
                    break;
                case AnimationTypes.BackBoth:
                    result = AnimationCore.BackBothCore(_usedTime / _options.AllTransformTime, _options.Power, _options.Amplitude);
                    break;
                case AnimationTypes.BounceIn:
                    result = AnimationCore.BounceInCore(_usedTime / _options.AllTransformTime, _options.Bounces, _options.Bounciness);
                    break;
                case AnimationTypes.BounceOut:
                    result = AnimationCore.BounceOutCore(_usedTime / _options.AllTransformTime, _options.Bounces, _options.Bounciness);
                    break;
                case AnimationTypes.BounceBoth:
                    result = AnimationCore.BounceBothCore(_usedTime / _options.AllTransformTime, _options.Bounces, _options.Bounciness);
                    break;
                case AnimationTypes.ElasticIn:
                    result = AnimationCore.ElasticInCore(_usedTime / _options.AllTransformTime, _options.Oscillations, _options.Springiness);
                    break;
                case AnimationTypes.ElasticOut:
                    result = AnimationCore.ElasticOutCore(_usedTime / _options.AllTransformTime, _options.Oscillations, _options.Springiness);
                    break;
                case AnimationTypes.ElasticBoth:
                    result = AnimationCore.ElasticBothCore(_usedTime / _options.AllTransformTime, _options.Oscillations, _options.Springiness);
                    break;
                case AnimationTypes.QuadraticIn:
                    result = AnimationCore.QuadraticInCore(_usedTime / _options.AllTransformTime);
                    break;
                case AnimationTypes.QuadraticOut:
                    result = AnimationCore.QuadraticOutCore(_usedTime / _options.AllTransformTime);
                    break;
            }

            return result;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 动画定时更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.intervalTypes == AnimationIntervalTypes.Add)
                this.runTime += this.timer.Interval;
            else
                this.runTime -= this.timer.Interval;

            if ((this.runTime >= 0 && this.runTime < this.options.AllTransformTime) || this.options.AnimationTimerType == AnimationTimerTypes.AlwaysAnimation)
            {
                if (this.animationing != null)
                {
                    this.animationUsedTime = this.runTime;
                    this.animationing.Invoke(this._control, new AnimationEventArgs() { Data = this.options.Data, AllTransformValue = this.options.AllTransformValue, AnimationUsedTime = this.runTime, ProgressValue = GetProgress(this.AnimationType, this.options, this.runTime) });
                }
            }
            else
            {
                if (this.animationing != null)//保证最后一次百分百变化
                {
                    this.animationUsedTime = this.runTime < 0 ? 0.0 : this.options.AllTransformTime;
                    this.animationing.Invoke(this._control, new AnimationEventArgs() { Data = this.options.Data, AllTransformValue = this.options.AllTransformValue, AnimationUsedTime = this.runTime, ProgressValue = GetProgress(this.AnimationType, this.options, this.runTime) });
                }

                if (this.options.AnimationTimerType == AnimationTimerTypes.AlwaysRepeatAnimation)
                {
                    this.runTime = 0.0;
                    if (this.animationRepetition != null)
                    {
                        this.animationRepetition.Invoke(this._control, new AnimationEventArgs() { Data = this.options.Data, AllTransformValue = this.options.AllTransformValue, AnimationUsedTime = this.runTime, ProgressValue = GetProgress(this.AnimationType, this.options, this.runTime) });
                    }
                }
                else
                {
                    this.Stop();
                    if (this.animationEnding != null)
                    {
                        this.animationUsedTime = this.runTime < 0 ? 0.0 : this.options.AllTransformTime;
                        this.animationEnding.Invoke(this._control, new AnimationEventArgs() { Data = this.options.Data, AllTransformValue = this.options.AllTransformValue, AnimationUsedTime = this.animationUsedTime, ProgressValue = this.runTime < 0 ? 0.0 : 1.0 });
                    }
                }
            }
        }

        #endregion

        #region 析构器

        ~AnimationTimer()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
            {
                if (this.timer != null)
                {
                    this.timer.Dispose();
                    this.timer = (System.Windows.Forms.Timer)null;
                }
            }
            this.disposed = true;
        }

        #endregion

    }

    #region 类

    /// <summary>
    /// 动画参数设置
    /// </summary>
    [Description("动画参数设置")]
    [TypeConverter(typeof(EmptyExpandableObjectConverter))]
    public class AnimationOptions
    {
        private bool everyNewTimer = true;
        /// <summary>
        /// 是否每一次调用Start方法是都重新创建一个Timer定时器实例(默认值为true)
        /// </summary>
        [Description("是否每一次调用Start方法是都重新创建一个Timer定时器实例(默认值为true)")]
        [DefaultValue(true)]
        public bool EveryNewTimer
        {
            get { return this.everyNewTimer; }
            set { this.everyNewTimer = value; }
        }

        private AnimationTimerTypes animationTimerType = AnimationTimerTypes.Normal;
        /// <summary>
        /// 动画定时器类型
        /// </summary>
        [Description("动画定时器类型")]
        [DefaultValue(AnimationTimerTypes.Normal)]
        public AnimationTimerTypes AnimationTimerType
        {
            get { return this.animationTimerType; }
            set { this.animationTimerType = value; }
        }

        private double allTransformTime = 300.0;
        /// <summary>
        /// 动画要变换的总时间(默认值300.0)
        /// </summary>
        [Description("动画要变换的总时间(默认值300.0)")]
        [DefaultValue(300.0)]
        public double AllTransformTime
        {
            get { return this.allTransformTime; }
            set { this.allTransformTime = value; }
        }

        private double allTransformValue = 10.0;
        /// <summary>
        /// 动画要变换的总变化值(默认值10.0)
        /// </summary>
        [Description("动画要变换的总变化值(默认值10.0)")]
        [DefaultValue(10.0)]
        public double AllTransformValue
        {
            get { return this.allTransformValue; }
            set { this.allTransformValue = value; }
        }

        private object data = null;
        /// <summary>
        /// 自定义参数
        /// </summary>
        [Description("自定义参数")]
        [Browsable(false)]
        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        private double power = 3.0;
        /// <summary>
        /// 动画曲线幂(默认值3.0)
        /// (限于EaseIn、EaseOut、EaseBoth、BackIn、BackOut、BackBoth)
        /// </summary>
        [Description("动画曲线幂(默认值3)")]
        [DefaultValue(3.0)]
        public double Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        private double amplitude = 1.0;
        /// <summary>
        /// 收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1.0。
        /// (限于BackIn、BackOut、BackBoth)
        /// </summary>
        [Description("收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1.0")]
        [DefaultValue(1.0)]
        public double Amplitude
        {
            get { return this.amplitude; }
            set { this.amplitude = value; }
        }

        private int bounces = 3;
        /// <summary>
        /// 反弹次数。值必须大于或等于零(默认值为3)
        /// (限于BounceIn、BounceOut、BounceBoth）
        /// </summary>
        [Description("反弹次数。值必须大于或等于零(默认值为3)")]
        [DefaultValue(3)]
        public int Bounces
        {
            get { return this.bounces; }
            set { this.bounces = value; }
        }

        private double bounciness = 2.0;
        /// <summary>
        /// 指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2.0)
        /// (限于BounceIn、BounceOut、BounceBoth）
        /// </summary>
        [Description("指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2.0)")]
        [DefaultValue(2.0)]
        public double Bounciness
        {
            get { return this.bounciness; }
            set { this.bounciness = value; }
        }

        private int oscillations = 3;
        /// <summary>
        /// 目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)
        /// (限于ElasticIn、ElasticOut、ElasticBoth）
        /// </summary>
        [Description("目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)")]
        [DefaultValue(3)]
        public int Oscillations
        {
            get { return this.oscillations; }
            set { this.oscillations = value; }
        }

        private double springiness = 3.0;
        /// <summary>
        /// 弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3.0)
        /// (限于ElasticIn、ElasticOut、ElasticBoth）
        /// </summary>
        [Description("弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3.0)")]
        [DefaultValue(3.0)]
        public double Springiness
        {
            get { return this.springiness; }
            set { this.springiness = value; }
        }

    }

    /// <summary>
    /// 动画事件数据
    /// </summary>
    [Description("动画事件数据")]
    public class AnimationEventArgs : EventArgs
    {
        /// <summary>
        /// 动画要变换的总变化值
        /// </summary>
        public double AllTransformValue { get; set; }
        /// <summary>
        /// 已进行了多少动画时间
        /// </summary>
        public double AnimationUsedTime { get; set; }
        /// <summary>
        /// 动画总变化值的进度（0.0-1.0）
        /// </summary>
        public double ProgressValue { get; set; }
        /// <summary>
        /// 自定义参数
        /// </summary>
        public object Data { get; set; }
    }

    #endregion

    #region 枚举

    /// <summary>
    /// 动画定时器类型
    /// </summary>
    [Description("动画定时器类型")]
    public enum AnimationTimerTypes
    {
        /// <summary>
        /// 一次性动画
        /// </summary>
        Normal,
        /// <summary>
        /// 永久动画
        /// </summary>
        AlwaysAnimation,
        /// <summary>
        /// 永久重复动画
        /// </summary>
        AlwaysRepeatAnimation
    }

    /// <summary>
    /// 动画时间操作类型(决定动画方向)
    /// </summary>
    [Description("动画时间操作类型(决定动画方向)")]
    public enum AnimationIntervalTypes
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 减少
        /// </summary>
        Subtrac
    }

    #endregion

    #region  Design

    /// <summary>
    /// 展开属性选型去除描述
    /// </summary>
    [Description("展开属性选型去除描述")]
    public class EmptyExpandableObjectConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// 当该属性为展开属性选型时，属性编辑器删除该属性的描述
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(string))
                return (object)"";
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion

}
