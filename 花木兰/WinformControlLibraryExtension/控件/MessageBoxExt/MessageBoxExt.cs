
/**版权******************************************************************

            版权：  唧唧复唧唧木兰当户织
            作者：  唧唧复唧唧木兰当户织
            博客：  https://www.cnblogs.com/tlmbem/
        源码地址：  https://www.cnblogs.com/tlmbem/
            描述：  授权使用在 https://www.cnblogs.com/tlmbem/ 上有介绍，禁止删除下面的木兰诗。
            日期：  2020-10-28
	
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
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 提示信息窗口
    /// </summary>
    [Description("提示信息窗口")]
    public sealed class MessageBoxExt
    {
        #region 属性

        private static MessageBoxExtStyles _styles = new MessageBoxExtStyles();
        /// <summary>
        /// 提示信息窗口样式配置
        /// </summary>
        [Description("提示信息窗口样式配置")]
        public static MessageBoxExtStyles Styles
        {
            get
            {
                if (_styles == null)
                    _styles = new MessageBoxExtStyles();

                return _styles;
            }
            set
            {
                _styles = value;
            }
        }

        #endregion

        #region 公开方法

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, String.Empty, MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxExtButtons.OK, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons)
        {
            return Show(owner, text, caption, buttons, MessageBoxExtIcon.None, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxExtDefaultButton.Button1, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton)
        {
            return Show(owner, text, caption, buttons, icon, defaultButton, Styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton, MessageBoxExtStyles styles)
        {
            return Show(owner, text, caption, buttons, icon, defaultButton, styles, null);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxExtButtons buttons, MessageBoxExtIcon icon, MessageBoxExtDefaultButton defaultButton, MessageBoxExtStyles styles, Image customImage)
        {
            if (styles == null)
            {
                styles = Styles;
            }

            Size minsize = new Size(200, 100);
            Size maxsize = new Size(900, 600);
            Size ico_size = new Size(32, 32);
            int btn_rect_height = 30;
            int btn_interval = 10;
            int btn_w = 75;
            int btn_h = 24;
            int text_padding = 10;
            int text_maxwidth = (maxsize.Width - text_padding * 2 - (icon != MessageBoxExtIcon.None ? ico_size.Width : 0));

            if (buttons == MessageBoxExtButtons.YesNoCancel || buttons == MessageBoxExtButtons.AbortRetryIgnore)
            {
                minsize = new Size(text_padding * 2 + btn_w * 3 + btn_interval * 2, minsize.Height);
            }


            FormExt fe = new FormExt();
            fe.BorderColor = styles.BorderColor;
            fe.ShowInTaskbar = false;
            fe.ShowIcon = false;
            fe.ResizeType = FormExt.ResizeTypes.NoResize;
            fe.StartPosition = FormStartPosition.CenterParent;
            fe.TextOrientation = FormExt.TextOrientations.Left;
            fe.MinimumSize = minsize;
            fe.Size = minsize;
            fe.Text = caption;
            fe.BackColor = styles.BackColor;
            fe.CaptionBox.CloseBtn.Enabled = false;
            fe.CaptionBox.MaxBtn.Enabled = false;
            fe.CaptionBox.MinBtn.Enabled = false;
            fe.CaptionBox.BackColor = styles.CaptionBackColor;
            fe.ForeColor = styles.CaptionTextColor;


            SizeF text_sizef = GetTextSize(fe, text, text_maxwidth);
            if (text_sizef.Height < ico_size.Height)
            {
                text_sizef = new SizeF(text_sizef.Width, ico_size.Height);
            }
            if (icon != MessageBoxExtIcon.None)
            {
                text_sizef = new SizeF(text_sizef.Width + ico_size.Width + 40, ico_size.Height);
            }
            Label label = new Label();
            label.AutoSize = false;
            label.Text = text;
            label.ForeColor = styles.TextColor;
            label.ImageAlign = ContentAlignment.MiddleLeft;
            label.TextAlign = ContentAlignment.MiddleCenter;
            if (icon != MessageBoxExtIcon.None)
            {
                label.Image = GetIco(icon, customImage);
            }
            label.SetBounds(fe.ClientRectangle.X + text_padding, fe.ClientRectangle.Y + text_padding + fe.CaptionBox.Height, (int)text_sizef.Width, (int)text_sizef.Height);
            fe.Controls.Add(label);



            List<MessageBoxExtButton> btnList = new List<MessageBoxExtButton>();
            if (buttons == MessageBoxExtButtons.OK)
            {
                MessageBoxExtButton ok_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "确定" : styles.Button1Text, OK_Click, btn_w, btn_h, 0, styles);
                ok_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - ok_btn.Width) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);
            }
            else if (buttons == MessageBoxExtButtons.OKCancel)
            {
                MessageBoxExtButton ok_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "确定" : styles.Button1Text, OK_Click, btn_w, btn_h, 0, styles);
                ok_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton cancel_btn = CreateButton(fe, styles.Button2Text == String.Empty ? "取消" : styles.Button2Text, Cancel_Click, btn_w, btn_h, 1, styles);
                cancel_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2) + cancel_btn.Width + btn_interval,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.YesNo)
            {
                MessageBoxExtButton ok_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "是" : styles.Button1Text, OK_Click, btn_w, btn_h, 0, styles);
                ok_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton cancel_btn = CreateButton(fe, styles.Button2Text == String.Empty ? "否" : styles.Button2Text, No_Click, btn_w, btn_h, 1, styles);
                cancel_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2) + cancel_btn.Width + btn_interval,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.YesNoCancel)
            {
                MessageBoxExtButton ok_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "是" : styles.Button1Text, OK_Click, btn_w, btn_h, 0, styles);
                ok_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(ok_btn);
                btnList.Add(ok_btn);

                MessageBoxExtButton no_btn = CreateButton(fe, styles.Button2Text == String.Empty ? "否" : styles.Button2Text, No_Click, btn_w, btn_h, 1, styles);
                no_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2) + no_btn.Width + btn_interval,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(no_btn);
                btnList.Add(no_btn);

                MessageBoxExtButton cancel_btn = CreateButton(fe, styles.Button3Text == String.Empty ? "取消" : styles.Button3Text, Cancel_Click, btn_w, btn_h, 2, styles);
                cancel_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2) + cancel_btn.Width * 2 + btn_interval * 2,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.RetryCancel)
            {
                MessageBoxExtButton retry_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "重试" : styles.Button1Text, Retry_Click, btn_w, btn_h, 0, styles);
                retry_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(retry_btn);
                btnList.Add(retry_btn);

                MessageBoxExtButton cancel_btn = CreateButton(fe, styles.Button2Text == String.Empty ? "取消" : styles.Button2Text, Cancel_Click, btn_w, btn_h, 1, styles);
                cancel_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 2 - btn_interval) / 2) + cancel_btn.Width + btn_interval,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(cancel_btn);
                btnList.Add(cancel_btn);
            }
            else if (buttons == MessageBoxExtButtons.AbortRetryIgnore)
            {
                MessageBoxExtButton abort_btn = CreateButton(fe, styles.Button1Text == String.Empty ? "中止" : styles.Button1Text, Abort_Click, btn_w, btn_h, 0, styles);
                abort_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2),
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(abort_btn);
                btnList.Add(abort_btn);

                MessageBoxExtButton retry_btn = CreateButton(fe, styles.Button2Text == String.Empty ? "重试" : styles.Button2Text, Retry_Click, btn_w, btn_h, 1, styles);
                retry_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2) + retry_btn.Width + btn_interval,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(retry_btn);
                btnList.Add(retry_btn);

                MessageBoxExtButton ignore_btn = CreateButton(fe, styles.Button3Text == String.Empty ? "忽略" : styles.Button3Text, Ignore_Click, btn_w, btn_h, 2, styles);
                ignore_btn.Location = new Point(
                    (int)((fe.ClientSize.Width - btn_w * 3 - btn_interval * 2) / 2) + ignore_btn.Width * 2 + btn_interval * 2,
                    (int)(fe.ClientRectangle.Bottom - btn_h - (btn_rect_height - btn_h) / 2));

                fe.Controls.Add(ignore_btn);
                btnList.Add(ignore_btn);
            }

            fe.Size = new Size(fe.Size.Width, fe.CaptionBox.Height + (int)text_sizef.Height + btn_rect_height + text_padding * 2);

            if (defaultButton == MessageBoxExtDefaultButton.Button1)
            {
                if (btnList[0] != null)
                {
                    btnList[0].Focus();
                    btnList[0].Select();
                }
            }
            else if (defaultButton == MessageBoxExtDefaultButton.Button2)
            {

                if (btnList[1] != null)
                {
                    btnList[0].Focus();
                    btnList[1].Select();
                }
            }
            else if (defaultButton == MessageBoxExtDefaultButton.Button3)
            {

                if (btnList[2] != null)
                {
                    btnList[0].Focus();
                    btnList[2].Select();
                }
            }

            fe.ShowDialog(owner);
            return (DialogResult)fe.Tag;
        }

        #endregion

        #region 私有方法

        private static void OK_Click(object sender, EventArgs e)
        {
            FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
            fe.Tag = DialogResult.OK;
            fe.Hide();
            fe.Dispose();
        }

        private static void Yes_Click(object sender, EventArgs e)
        {
            FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
            fe.Tag = DialogResult.Yes;
            fe.Hide();
            fe.Dispose();
        }

        private static void No_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.No;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Cancel_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Cancel;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Abort_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Abort;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Retry_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Retry;
                fe.Hide();
                fe.Dispose();
            }
        }

        private static void Ignore_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            if (mea.Button == MouseButtons.Left)
            {
                FormExt fe = (FormExt)(((MessageBoxExtButton)sender).Tag);
                fe.Tag = DialogResult.Ignore;
                fe.Hide();
                fe.Dispose();
            }
        }

        /// <summary>
        /// 创建按钮控件
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="text"></param>
        /// <param name="handler"></param>
        /// <param name="btn_w"></param>
        /// <param name="btn_h"></param>
        /// <returns></returns>
        private static MessageBoxExtButton CreateButton(FormExt fe, string text, EventHandler handler, int btn_w, int btn_h, int tabIndex, MessageBoxExtStyles style)
        {
            MessageBoxExtButton btn = new MessageBoxExtButton();
            btn.Text = text;
            btn.Size = new Size(btn_w, btn_h);
            btn.TabIndex = tabIndex;
            btn.TabStop = true;
            btn.Tag = fe;
            btn.BackColor = style.ButtonBackColor;
            btn.BackEnterColor = style.ButtonBackEnterColor;
            btn.ForeColor = style.ButtonTextColor;
            btn.Click += handler;
            return btn;
        }

        /// <summary>
        /// 获取文本Size
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="text"></param>
        /// <param name="maxwidth"></param>
        /// <returns></returns>
        private static Size GetTextSize(FormExt fe, string text, int maxwidth)
        {
            IntPtr hDC = WindowNavigate.GetWindowDC(fe.Handle);
            Graphics g = Graphics.FromHdc(hDC);

            SizeF text_sizef = g.MeasureString(text, fe.Font, maxwidth);

            g.Dispose();
            WindowNavigate.ReleaseDC(fe.Handle, hDC);

            return Size.Ceiling(text_sizef);
        }

        /// <summary>
        /// 获取图标图片
        /// </summary>
        /// <param name="ico">图标类别</param>
        /// <param name="image">自定义图片</param>
        /// <returns></returns>
        private static Image GetIco(MessageBoxExtIcon ico, Image image)
        {
            if (ico == MessageBoxExtIcon.Warning)
            {
                return global::WinformControlLibraryExtension.Resources.message_warning;
            }

            else if (ico == MessageBoxExtIcon.Question)
            {
                return global::WinformControlLibraryExtension.Resources.message_question;
            }
            else if (ico == MessageBoxExtIcon.Error)
            {
                return global::WinformControlLibraryExtension.Resources.message_error;
            }
            else if (ico == MessageBoxExtIcon.Custom)
            {
                return image;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        public class MessageBoxExtButton : Control
        {
            #region 属性

            /// <summary>
            /// 边框颜色
            /// </summary>
            [Description("边框颜色")]
            private Color borderColor = Color.White;
            internal Color BorderColor
            {
                get
                {
                    return this.borderColor;
                }
                set
                {
                    if (this.borderColor == value)
                        return;

                    this.borderColor = value;
                    this.Invalidate();
                }
            }

            /// <summary>
            /// 背景颜色（鼠标进入）
            /// </summary>
            [Description("背景颜色（鼠标进入）")]
            private Color backEnterColor = Color.White;
            internal Color BackEnterColor
            {
                get
                {
                    return this.backEnterColor;
                }
                set
                {
                    if (this.backEnterColor == value)
                        return;

                    this.backEnterColor = value;
                    this.Invalidate();
                }
            }

            #endregion

            #region 字段

            /// <summary>
            /// 控件Tab状态
            /// </summary>
            private bool tabStatus = false;
            /// <summary>
            /// 鼠标是否进入
            /// </summary>
            private bool isEnter = false;

            #endregion

            #region 重写

            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);

                this.tabStatus = true;
                this.Invalidate();
            }

            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);

                this.tabStatus = false;
                this.Invalidate();
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);

                this.isEnter = true;
                this.Invalidate();
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);

                this.isEnter = false;
                this.Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;

                #region 背景

                SolidBrush back_sb = new SolidBrush(this.isEnter ? this.BackEnterColor : this.BackColor);
                g.FillRectangle(back_sb, this.ClientRectangle);
                back_sb.Dispose();

                #endregion

                #region 文本

                int padding = 2;
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                StringFormat text_sf = new StringFormat() { FormatFlags = StringFormatFlags.NoWrap, Trimming = StringTrimming.None, LineAlignment = StringAlignment.Center };
                Size text_size = Size.Ceiling(g.MeasureString(this.Text, this.Font, this.Width - padding * 2, text_sf));

                Rectangle text_rect = new Rectangle(
                    this.ClientRectangle.X + padding + (this.ClientRectangle.Width - padding * 2 - text_size.Width) / 2,
                     this.ClientRectangle.Y + padding + (this.ClientRectangle.Height - padding * 2 - text_size.Height) / 2,
                     text_size.Width,
                     text_size.Height
                     );
                g.DrawString(this.Text, this.Font, text_sb, text_rect, text_sf);

                text_sb.Dispose();
                text_sf.Dispose();

                #endregion

                #region tab边框
                if (this.tabStatus)
                {
                    Pen tabborder_pen = new Pen(Color.FromArgb(150, this.BorderColor), 1);
                    tabborder_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawRectangle(tabborder_pen, new Rectangle(this.ClientRectangle.X + padding, this.ClientRectangle.Y + padding, this.ClientRectangle.Width - padding * 2 - 1, this.ClientRectangle.Height - padding * 2 - 1));
                    tabborder_pen.Dispose();
                }
                #endregion
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (this.DesignMode)
                {
                    return base.ProcessDialogKey(keyData);
                }

                if (this.tabStatus)
                {
                    #region Enter
                    if (keyData == Keys.Enter)
                    {
                        this.InvokeOnClick(this, (EventArgs)(new MouseEventArgs(MouseButtons.Left, 1, this.ClientRectangle.X + this.ClientRectangle.Width / 2, this.ClientRectangle.Y + this.ClientRectangle.Height / 2, 0)));

                        return false;
                    }
                    #endregion
                }

                return base.ProcessDialogKey(keyData);
            }

            #endregion

        }

        #endregion

    }

    #region 类

    /// <summary>
    /// 提示框样式
    /// </summary>
    [Description("提示框样式")]
    public class MessageBoxExtStyles
    {
        private Color borderColor = Color.FromArgb(137, 158, 136);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor == value)
                    return;

                this.borderColor = value;
            }
        }

        private Color backColor = Color.White;
        /// <summary>
        /// 背景颜色
        /// </summary>
        [Description("背景颜色")]
        public Color BackColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                if (this.backColor == value)
                    return;

                this.backColor = value;
            }
        }

        private Color captionBackColor = Color.FromArgb(137, 165, 136);
        /// <summary>
        /// 标题栏背景颜色
        /// </summary>
        [Description("标题栏背景颜色")]
        public Color CaptionBackColor
        {
            get
            {
                return this.captionBackColor;
            }
            set
            {
                if (this.captionBackColor == value)
                    return;

                this.captionBackColor = value;
            }
        }

        private Color captionTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 标题文本颜色
        /// </summary>
        [Description("标题文本颜色")]
        public Color CaptionTextColor
        {
            get
            {
                return this.captionTextColor;
            }
            set
            {
                if (this.captionTextColor == value)
                    return;

                this.captionTextColor = value;
            }
        }

        private Color textColor = Color.Gray;
        /// <summary>
        /// 信息文本颜色
        /// </summary>
        [Description("信息文本颜色")]
        public Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                if (this.textColor == value)
                    return;

                this.textColor = value;
            }
        }

        private Color buttonBackColor = Color.FromArgb(137, 165, 136);
        /// <summary>
        /// 按钮背景颜色
        /// </summary>
        [Description("按钮背景颜色")]
        public Color ButtonBackColor
        {
            get
            {
                return this.buttonBackColor;
            }
            set
            {
                if (this.buttonBackColor == value)
                    return;

                this.buttonBackColor = value;
            }
        }

        private Color buttonBackEnterColor = Color.FromArgb(123, 148, 122);
        /// <summary>
        /// 按钮背景颜色(鼠标进入)
        /// </summary>
        [Description("按钮背景颜色(鼠标进入)")]
        public Color ButtonBackEnterColor
        {
            get
            {
                return this.buttonBackEnterColor;
            }
            set
            {
                if (this.buttonBackEnterColor == value)
                    return;

                this.buttonBackEnterColor = value;
            }
        }

        private Color buttonTextColor = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 按钮文本颜色
        /// </summary>
        [Description("按钮文本颜色")]
        public Color ButtonTextColor
        {
            get
            {
                return this.buttonTextColor;
            }
            set
            {
                if (this.buttonTextColor == value)
                    return;

                this.buttonTextColor = value;
            }
        }

        private string button1Text = String.Empty;
        /// <summary>
        /// Button1自定义文本
        /// </summary>
        [Description("Button1自定义文本")]
        public string Button1Text
        {
            get
            {
                return this.button1Text;
            }
            set
            {
                if (this.button1Text == value)
                    return;

                this.button1Text = value.Trim();
            }
        }

        private string button2Text = String.Empty;
        /// <summary>
        /// Button2自定义文本
        /// </summary>
        [Description("Button2自定义文本")]
        public string Button2Text
        {
            get
            {
                return this.button2Text;
            }
            set
            {
                if (this.button2Text == value)
                    return;

                this.button2Text = value.Trim();
            }
        }

        private string button3Text = String.Empty;
        /// <summary>
        /// Button3自定义文本
        /// </summary>
        [Description("Button3自定义文本")]
        public string Button3Text
        {
            get
            {
                return this.button3Text;
            }
            set
            {
                if (this.button3Text == value)
                    return;

                this.button3Text = value.Trim();
            }
        }

    }

    #endregion

    #region 枚举

    /// <summary>
    /// 提示按钮类型
    /// </summary>
    [Description("提示按钮类型")]
    public enum MessageBoxExtButtons
    {
        /// <summary>
        /// 消息框包含“确定”按钮。
        /// </summary>
        OK = 0,
        /// <summary>
        /// 消息框包含“确定”和“取消”按钮。
        /// </summary>
        OKCancel = 1,
        /// <summary>
        /// 消息框包含“中止”、“重试”和“忽略”按钮。
        /// </summary>
        AbortRetryIgnore = 2,
        /// <summary>
        /// 消息框包含“是”、“否”和“取消”按钮。
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// 消息框包含“是”和“否”按钮。
        /// </summary>
        YesNo = 4,
        /// <summary>
        /// 消息框包含“重试”和“取消”按钮。
        /// </summary>
        RetryCancel = 5
    }

    /// <summary>
    /// 提示框图标（32x32）
    /// </summary>
    [Description("提示框图标（32x32）")]
    public enum MessageBoxExtIcon
    {
        /// <summary>
        /// 不包含符号
        /// </summary>
        None = 0,
        /// <summary>
        /// 疑问
        /// </summary>
        Question,
        /// <summary>
        /// 错区
        /// </summary>
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }

    /// <summary>
    /// 默认激活按钮
    /// </summary>
    [Description("默认激活按钮")]
    public enum MessageBoxExtDefaultButton
    {
        /// <summary>
        /// 第一个按钮
        /// </summary>
        Button1,
        /// <summary>
        /// 第二个按钮
        /// </summary>
        Button2,
        /// <summary>
        /// 第三个按钮
        /// </summary>
        Button3
    }

    #endregion

}
