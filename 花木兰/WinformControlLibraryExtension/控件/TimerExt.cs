
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
using System.Runtime.InteropServices;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 毫秒级别计时器扩展
    /// </summary>
    [ToolboxItem(true)]
    [Description("毫秒级别计时器扩展")]
    [DefaultProperty("Interval")]
    [DefaultEvent("Tick")]
    public class TimerExt : Component
    {
        #region 新增事件

        private event EventHandler tick;
        /// <summary>
        /// 计时器间隔引发事件
        /// </summary>
        public event EventHandler Tick
        {
            add { this.tick += value; }
            remove { this.tick -= value; }
        }

        #endregion

        #region 新增属性

        private uint interval = 10;
        /// <summary>
        ///   获取或设置在相对于上一次发生的Tick 事件引发的时间（以毫秒为单位）。
        /// </summary>
        [DefaultValue(10)]
        [Description("获取或设置在相对于上一次发生的Tick 事件引发的时间（以毫秒为单位）。")]
        public uint Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (this.interval == value || value < timecaps.wPeriodMin || value > timecaps.wPeriodMax)
                    return;

                this.interval = value;

                if (this.Enabled)
                {
                    this.ReStart();
                }
            }
        }

        private bool enabled = false;
        /// <summary>
        /// 获取或设置计时器是否正在运行。
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置计时器是否正在运行。")]
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (this.enabled == value)
                    return;

                if (this.enabled == false)
                {
                    this.Start();
                }
                else
                {
                    this.Stop();
                }
                this.enabled = value;
            }
        }

        /// <summary>
        /// 计时器分辨率的信息
        /// </summary>
        [Browsable(false)]
        [Description("计时器分辨率的信息")]
        public TIMECAPS Timecaps
        {
            get { return TimerExt.timecaps; }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 计时器分辨率的信息
        /// </summary>
        private static TIMECAPS timecaps;

        /// <summary>
        ///作为fptc参数的函数指针
        /// </summary>
        private TimerExtCallback timerExtCallback;

        /// <summary>
        /// 定期是标识
        /// </summary>
        private uint timerID;

        #endregion

        #region  扩展

        private delegate void TimerExtCallback(uint uTimerID, uint uMsg, uint dwUser, UIntPtr dw1, UIntPtr dw2); // timeSetEvent所对应的回调函数的签名

        /// <summary>
        /// 查询计时器设备以确定其分辨率成功
        /// </summary>
        private const int TIMERR_NOERROR = 0x0000;

        /// <summary>
        /// 当计时器到期时，系统将调用fptc参数指向的函数。
        /// </summary>
        private const int TIME_CALLBACK_FUNCTION = 0x0001;

        /// <summary>
        /// 此结构包含有关计时器分辨率的信息。单位是ms
        /// </summary>
        [Description("此结构包含有关计时器分辨率的信息。单位是ms")]
        [StructLayout(LayoutKind.Sequential)]
        public struct TIMECAPS
        {
            /// <summary>
            /// 支持的最小期限。
            /// </summary>
            [Description("支持的最小期限")]
            public uint wPeriodMin;
            /// <summary>
            /// 支持的最大期限。
            /// </summary>
            [Description("支持的最大期限")]
            public uint wPeriodMax;
        }

        /// <summary>
        /// 此函数启动指定的计时器事件。
        /// </summary>
        /// <param name="uDelay">事件延迟，以毫秒为单位。如果该值不在计时器支持的最小和最大事件延迟范围内，则该函数返回错误。</param>
        /// <param name="uResolution">计时器事件的分辨率，以毫秒为单位。分辨率越高，分辨率越高；零分辨率表示周期性事件应该以最大可能的精度发生。但是，为减少系统开销，应使用适合您的应用程序的最大值。</param>
        /// <param name="fptc">如果fuEvent指定TIME_CALLBACK_EVENT_SET或TIME_CALLBACK_EVENT_PULSE标志，则fptc参数将解释为事件对象的句柄。事件将在单个事件完成时设置或发出脉冲，或者在周期性事件完成时定期设置或触发。对于fuEvent的任何其他值，fptc参数将被解释为函数指针。</param>
        /// <param name="dwUser">用户提供的回调数据。</param>
        /// <param name="fuEvent">计时器事件类型。下表显示了fuEvent参数可以包含的值。</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern uint timeSetEvent(uint uDelay, uint uResolution, TimerExtCallback fptc, uint dwUser, uint fuEvent);

        /// <summary>
        /// 此功能取消指定的计时器事件。
        /// </summary>
        /// <param name="id">要取消的计时器事件的标识符。此标识符由timeSetEvent函数返回，该函数启动指定的计时器事件。</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern uint timeKillEvent(uint uTimerID);

        /// <summary>
        /// 此函数查询计时器设备以确定其分辨率。
        /// </summary>
        /// <param name="ptc">指向TIMECAPS结构的指针。该结构充满了有关计时器设备分辨率的信息。</param>
        /// <param name="cbtc">TIMECAPS结构的大小（以字节为单位）。</param>
        /// <returns>如果成功，则返回TIMERR_NOERROR，如果未能返回计时器设备功能，则返回TIMERR_STRUCT。</returns>
        [DllImport("winmm.dll")]
        private static extern uint timeGetDevCaps(ref TIMECAPS ptc, int cbtc);

        #endregion

        static TimerExt()
        {
            uint result = timeGetDevCaps(ref timecaps, Marshal.SizeOf(timecaps));
            if (result != TIMERR_NOERROR)
            {
                throw new Exception("timeGetDevCaps失败");
            }
        }

        public TimerExt()
        {
            this.timerExtCallback = new TimerExtCallback(this.TimerExtCallbackFun);
        }

        public TimerExt(IContainer container)
        {
            this.timerExtCallback = new TimerExtCallback(this.TimerExtCallbackFun);

            container.Add(this);
        }

        #region 重写

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (this.timerID != 0)
            {
                timeKillEvent(this.timerID);
                this.timerID = 0;
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 启动定时器
        /// </summary>
        public void Start()
        {
            if (!this.Enabled)
            {
                uint result = timeSetEvent(this.interval, Math.Min(1, timecaps.wPeriodMin), this.timerExtCallback, 0, TIME_CALLBACK_FUNCTION); // 间隔性地运行
                if (result == 0)
                {
                    throw new Exception("timeSetEvent启动计时器失败");
                }
                this.enabled = true;
                this.timerID = result;
            }
        }

        /// <summary>
        /// 重新开始定时器
        /// </summary>
        public void ReStart()
        {
            this.Stop();
            this.Start();
        }

        /// <summary>
        /// 暂停定时器
        /// </summary>
        public void Stop()
        {
            if (this.Enabled)
            {
                timeKillEvent(this.timerID);
                this.enabled = false;
            }
        }

        #endregion

        #region 私有方法

        private void TimerExtCallbackFun(uint uTimerID, uint uMsg, uint dwUser, UIntPtr dw1, UIntPtr dw2)
        {
            if (this.tick != null)
            {
                this.tick(this, null);
            }
        }

        #endregion

    }
}
