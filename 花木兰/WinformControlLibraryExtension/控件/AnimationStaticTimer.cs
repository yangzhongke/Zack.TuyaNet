
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
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 静态动画控件共用定时器(ButtonExt、SwitchButtonExt、WaveRippleExt)
    /// </summary>
    [ToolboxItem(false)]
    [Description("静态动画控件共用定时器(ButtonExt、SwitchButtonExt)")]
    public class AnimationStaticTimer : Control
    {
        #region 字段
        /// <summary>
        /// 动画对象列表锁
        /// </summary>
        protected internal static object buttonExtList_object = new object();
        /// <summary>
        /// 动画对象列表
        /// </summary>
        protected internal static List<object> buttonExtList = new List<object>();
        /// <summary>
        /// 动画定时器锁
        /// </summary>
        protected internal static object timer_object = new object();
        /// <summary>
        /// 动画定时器
        /// </summary>
        protected internal static Timer timer = null;
        /// <summary>
        /// 动画定时器空闲时间
        /// </summary>
        protected internal static int leisure_time = 0;
        /// <summary>
        /// 动画定时器最大空闲时间(超过关闭定时器)
        /// </summary>
        protected internal static int leisure_maxtime = 10000;

        #endregion

        #region 重写

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal static void Timer_Tick(object sender, EventArgs e)
        {
            leisure_time += timer.Interval;
            lock (buttonExtList_object)
            {
                for (int i = 0; i < buttonExtList.Count; i++)
                {
                    if (buttonExtList[i] != null)
                    {
                        ((IAnimationStaticTimer)buttonExtList[i]).Animationing();
                        leisure_time = 0;
                    }
                }
            }
            if (leisure_time > leisure_maxtime)
            {
                lock (buttonExtList_object)
                {
                    timer.Enabled = false;
                    buttonExtList.Clear();
                }
            }
        }

        /// <summary>
        /// 开始指定控件动画
        /// </summary>
        protected internal static void AnimationStart(object control)
        {
            if (timer == null)
            {
                lock (timer_object)
                {
                    timer = new Timer();
                    timer.Interval = 20;
                    timer.Tick += Timer_Tick;
                }
            }
            timer.Enabled = true;
            lock (buttonExtList_object)
            {
                if (buttonExtList.IndexOf(control) < 0)
                {
                    buttonExtList.Add(control);
                }
            }
            leisure_time = 0;
        }

        /// <summary>
        /// 停止指定控件动画
        /// </summary>
        protected internal static void AnimationStop(object control)
        {
            for (int i = 0; i < buttonExtList.Count; i++)
            {
                if (buttonExtList[i] == control)
                {
                    buttonExtList[i] = null;
                }
            }
        }

        #endregion

    }

    /// <summary>
    /// 动画控件一般要继承该接口
    /// </summary>
    public interface IAnimationStaticTimer
    {
        /// <summary>
        /// 动画控件动画中要处理的内容
        /// </summary>
        void Animationing();
    }
}
