
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
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 控件工具类
    /// </summary>
    public class ControlCommom
    {

        /// <summary>
        /// 转换成圆角
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="radius">圆角半径的大小</param>
        /// <returns></returns>
        public static GraphicsPath TransformCircular(RectangleF rectf, float radius = 0)
        {
            return TransformCircular(rectf, radius, radius, radius, radius);
        }

        /// <summary>
        /// 转换成圆角
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="leftTopRadius">左上角</param>
        /// <param name="rightTopRadius">右上角</param>
        /// <param name="rightBottomRadius">右下角</param>
        /// <param name="leftBottomRadius">左下角</param>
        /// <returns></returns>
        public static GraphicsPath TransformCircular(RectangleF rectf, float leftTopRadius = 0f, float rightTopRadius = 0f, float rightBottomRadius = 0f, float leftBottomRadius = 0f)
        {
            GraphicsPath gp = new GraphicsPath();
            if (leftTopRadius > 0)
            {
                RectangleF lefttop_rect = new RectangleF(rectf.X, rectf.Y, leftTopRadius * 2, leftTopRadius * 2);
                gp.AddArc(lefttop_rect, 180, 90);
            }
            else
            {
                gp.AddLine(new PointF(rectf.X, rectf.Y), new PointF(rightTopRadius > 0 ? rectf.Right - rightTopRadius * 2 : rectf.Right, rectf.Y));
            }
            if (rightTopRadius > 0)
            {
                RectangleF righttop_rect = new RectangleF(rectf.Right - rightTopRadius * 2, rectf.Y, rightTopRadius * 2, rightTopRadius * 2);
                gp.AddArc(righttop_rect, 270, 90);
            }
            else
            {
                gp.AddLine(new PointF(rectf.Right, rectf.Y), new PointF(rectf.Right, rightBottomRadius > 0 ? rectf.Bottom - rightTopRadius * 2 : rectf.Bottom));
            }
            if (rightBottomRadius > 0)
            {
                RectangleF rightbottom_rect = new RectangleF(rectf.Right - rightTopRadius * 2, rectf.Bottom - rightTopRadius * 2, rightBottomRadius * 2, rightBottomRadius * 2);
                gp.AddArc(rightbottom_rect, 0, 90);
            }
            else
            {
                gp.AddLine(new PointF(rectf.Right, rectf.Bottom), new PointF(leftBottomRadius > 0 ? leftBottomRadius * 2 : rectf.X, rectf.Bottom));
            }
            if (leftBottomRadius > 0)
            {
                RectangleF rightbottom_rect = new RectangleF(rectf.X, rectf.Bottom - leftBottomRadius * 2, leftBottomRadius * 2, leftBottomRadius * 2);
                gp.AddArc(rightbottom_rect, 90, 90);
            }
            else
            {
                gp.AddLine(new PointF(rectf.X, rectf.Bottom), new PointF(rectf.X, leftTopRadius > 0 ? rectf.X + leftTopRadius * 2 : rectf.X));
            }
            gp.CloseAllFigures();
            return gp;
        }

        /// <summary>
        /// 根据画笔大小计算出真是rectf
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="pen">画笔大小大小</param>
        /// <returns></returns>
        public static RectangleF TransformRectangleF(RectangleF rectf, float pen)
        {
            RectangleF result = new RectangleF();
            result.Width = rectf.Width - (pen < 1 ? 0 : pen);
            result.Height = rectf.Height - (pen < 1 ? 0 : pen);
            result.X = rectf.X + (pen / 2f);
            result.Y = rectf.Y + (pen / 2f);
            return result;
        }

        /// <summary>
        /// 倒影变换
        /// </summary>
        /// <param name="bmp">原图片</param>
        /// <param name="reflectionTop">倒影边距</param>
        /// <param name="reflectionBrightness">明亮度</param>
        /// <param name="reflectionTransparentStart">倒影开始透明度</param>
        /// <param name="reflectionTransparentEnd">倒影结束透明度</param>
        /// <param name="reflectionHeight">倒影高度</param>
        /// <returns></returns>
        public static Bitmap TransformReflection(Bitmap bmp, int reflectionTop = 10, int reflectionBrightness = -50, int reflectionTransparentStart = 200, int reflectionTransparentEnd = -0, int reflectionHeight = 50)
        {
            /// <summary>
            /// 图片最终高度
            /// </summary>
            int finallyHeight = bmp.Height + reflectionTop + reflectionHeight;

            Color pixel;
            int transparentGradient = 0;//透明梯度
            transparentGradient = (reflectionTransparentEnd - reflectionTransparentStart) / reflectionHeight;
            if (transparentGradient == 0)
                transparentGradient = 1;

            Bitmap result = new Bitmap(bmp.Width, finallyHeight);
            Graphics graphic = Graphics.FromImage(result);
            graphic.DrawImage(bmp, new RectangleF(0, 0, bmp.Width, bmp.Height));
            graphic.Dispose();

            for (int y = 0; y < reflectionHeight; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    pixel = bmp.GetPixel(x, bmp.Height - 1 - y);
                    int a = VerifyRGB(reflectionTransparentStart + y * transparentGradient);
                    if (pixel.A == 0 || pixel.A < a)
                    {
                        result.SetPixel(x, bmp.Height - 1 + reflectionTop + y, pixel);
                    }
                    else
                    {
                        int r = VerifyRGB(pixel.R + reflectionBrightness);
                        int g = VerifyRGB(pixel.G + reflectionBrightness);
                        int b = VerifyRGB(pixel.B + reflectionBrightness);
                        result.SetPixel(x, bmp.Height - 1 + reflectionTop + y, Color.FromArgb(a, r, g, b));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 检查RGB值ed有效范围
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static int VerifyRGB(int rgb)
        {
            if (rgb < 0)
                return 0;
            if (rgb > 255)
                return 255;
            return rgb;
        }

        /// <summary>
        /// 计算指定角度的坐标
        /// </summary>
        /// <param name="center">圆心坐标</param>
        /// <param name="radius">圆半径</param>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static PointF CalculatePointForAngle(PointF center, float radius, float angle)
        {
            if (radius == 0)
                return center;

            float w = 0;
            float h = 0;
            if (angle <= 90)
            {
                w = radius * (float)Math.Cos(Math.PI / 180 * angle);
                h = radius * (float)Math.Sin(Math.PI / 180 * angle);
            }
            else if (angle <= 180)
            {
                w = -radius * (float)Math.Sin(Math.PI / 180 * (angle - 90));
                h = radius * (float)Math.Cos(Math.PI / 180 * (angle - 90));

            }
            else if (angle <= 270)
            {
                w = -radius * (float)Math.Cos(Math.PI / 180 * (angle - 180));
                h = -radius * (float)Math.Sin(Math.PI / 180 * (angle - 180));
            }
            else
            {
                w = radius * (float)Math.Sin(Math.PI / 180 * (angle - 270));
                h = -radius * (float)Math.Cos(Math.PI / 180 * (angle - 270));

            }
            return new PointF(center.X + w, center.Y + h);
        }

        /// <summary>
        /// 根据画笔大小转换rectf
        /// </summary>
        /// <param name="rectf">要转换的rectf</param>
        /// <param name="pen">画笔大小大小</param>
        /// <returns></returns>
        public static RectangleF TransformRectangleByPen(RectangleF rectf, float pen)
        {
            RectangleF result = new RectangleF();
            result.Width = rectf.Width - (pen < 1 ? 0 : pen);
            result.Height = rectf.Height - (pen < 1 ? 0 : pen);
            result.X = rectf.X + (float)(pen / 2);
            result.Y = rectf.Y + (float)(pen / 2);
            return result;
        }

        /// <summary>
        /// 结构转指针
        /// </summary>
        /// <typeparam name="T">结构类型</typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IntPtr StructToIntPtr<T>(T info)
        {
            int size = Marshal.SizeOf(info);
            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(info, intPtr, true);
            return intPtr;
        }

        /// <summary>
        /// 指针转结构
        /// </summary>
        /// <typeparam name="T">结构类型</typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static T IntPtrToStruct<T>(IntPtr info)
        {
            return (T)Marshal.PtrToStructure(info, typeof(T));
        }
    }
}
