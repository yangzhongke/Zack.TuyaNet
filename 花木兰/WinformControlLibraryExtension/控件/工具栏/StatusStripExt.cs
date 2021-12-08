
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
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// StatusStripExt状态栏
    /// </summary>
    [Description("StatusStripExt状态栏")]
    [ToolboxItem(true)]
    public class StatusStripExt : StatusStrip
    {
        #region 重写属性

        /// <summary>
        ///  的前景色
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Browsable(true)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (base.ForeColor == value)
                    return;

                base.ForeColor = value;
            }
        }

        /// <summary>
        ///  大小调整手柄
        /// </summary>
        [DefaultValue(false)]
        [Browsable(true)]
        public new bool SizingGrip
        {
            get
            {
                return base.SizingGrip;
            }
            set
            {
                if (base.SizingGrip == value)
                    return;

                base.SizingGrip = value;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ToolStripRenderMode RenderMode
        {
            get
            {
                return ToolStripRenderMode.Professional;
            }
            set
            {
                base.RenderMode = ToolStripRenderMode.Professional;
            }
        }

        #endregion

        public StatusStripExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.SizingGrip = false;
            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripExtRenderer(new ToolStripExtColorTable());
        }

        private const int WM_NCHITTEST = 0x0084;
        private const int HTBOTTOMRIGHT = 17;

        private const int GA_ROOT = 2;


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, x + width, y + height);
            }

            public System.Drawing.Size Size
            {
                get
                {
                    return new System.Drawing.Size(this.right - this.left, this.bottom - this.top);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

#if DEBUG
            public override string ToString()
            {
                return "{x=" + x + ", y=" + y + "}";
            }
#endif
        }

        [DllImport("User32", ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] POINT pt, int cPoints);

        [DllImport("User32", ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        public static extern bool IsZoomed(HandleRef hWnd);

        [DllImport("User32", ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport("User32", ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetAncestor(HandleRef hWnd, int flags);



        // for a given handle, finds the toplevel handle
        public static HandleRef GetRootHWnd(HandleRef hwnd)
        {
            IntPtr rootHwnd = GetAncestor(new HandleRef(hwnd, hwnd.Handle), GA_ROOT);
            return new HandleRef(hwnd.Wrapper, rootHwnd);
        }

        // for a given control, finds the toplevel handle
        public static HandleRef GetRootHWnd(Control control)
        {
            return GetRootHWnd(new HandleRef(control, control.Handle));
        }


        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_NCHITTEST) && SizingGrip)
            {
                // if we're within the grip bounds tell windows
                // that we're the bottom right of the window.  
                Rectangle sizeGripBounds = SizeGripBounds;
                int x = WindowNavigate.LOWORD(m.LParam);
                int y = WindowNavigate.HIWORD(m.LParam);


                if (sizeGripBounds.Contains(PointToClient(new Point(x, y))))
                {
                    HandleRef rootHwnd = GetRootHWnd(this);

                    // if the main window isnt maximized - we should paint a resize grip.
                    // double check that we're at the bottom right hand corner of the window.
                    if (rootHwnd.Handle != IntPtr.Zero && !IsZoomed(rootHwnd))
                    {
                        // get the client area of the topmost window.  If we're next to the edge then 
                        // the sizing grip is valid.
                        RECT rootHwndClientArea = new RECT();
                        GetClientRect(rootHwnd, ref rootHwndClientArea);

                        // map the size grip FROM statusStrip coords TO the toplevel window coords.
                        POINT gripLocation;
                        if (RightToLeft == RightToLeft.Yes)
                        {
                            gripLocation = new POINT(SizeGripBounds.Left, SizeGripBounds.Bottom);
                        }
                        else
                        {
                            gripLocation = new POINT(SizeGripBounds.Right, SizeGripBounds.Bottom + 24);
                        }
                        int hh = MapWindowPoints(new HandleRef(this, this.Handle), rootHwnd, gripLocation, 1);

                        Point point = new Point(WindowNavigate.LOWORD(hh), WindowNavigate.HIWORD(hh));
                        point = PointToClient(point);


                        int deltaBottomEdge = Math.Abs(rootHwndClientArea.bottom - gripLocation.y);
                        int deltaRightEdge = Math.Abs(rootHwndClientArea.right - gripLocation.x);

                        if (RightToLeft != RightToLeft.Yes)
                        {
                            if ((deltaRightEdge + deltaBottomEdge) < 2)
                            {
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                                return;
                            }
                        }


                    }

                }
            }
            base.WndProc(ref m);
        }
    }
}
