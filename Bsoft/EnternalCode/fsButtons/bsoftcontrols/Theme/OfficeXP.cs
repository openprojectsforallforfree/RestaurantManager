namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class OfficeXP
    {
        private bool isFocused;
        private Rectangle My;
        private Color tc;
        private bool TextEffects;

        public OfficeXP(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(this.tc);
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            brush = new SolidBrush(modColorFunctions.OverlayMix(modColorFunctions.OpacityMix(Color.White, this.tc, 0x4b), Color.Black, 50));
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 1), (int) (this.My.Top + 1), (int) (this.My.Width - 2), (int) (this.My.Height - 2));
            if (this.isFocused)
            {
                Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
                pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 7), (int) (this.My.Height - 7));
            }
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawRectangle(pen, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 7), (int) (this.My.Height - 7));
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(this.tc);
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            brush = new SolidBrush(Color.FromArgb(0xbf, Color.White));
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 1), (int) (this.My.Top + 1), (int) (this.My.Width - 2), (int) (this.My.Height - 2));
            if (this.isFocused)
            {
                Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
                pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 7), (int) (this.My.Height - 7));
            }
        }

        public void DrawText(PaintEventArgs e, States s, string text, Font font, Color forecolor)
        {
            Brush brush;
            RectangleF ef3;
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            SizeF layoutArea = new SizeF((float) (this.My.Width - 2), (float) (this.My.Height - 2));
            SizeF ef = e.Graphics.MeasureString(text, font, layoutArea, stringFormat);
            text = text + "                    ";
            if (s == States.MouseDown)
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x26, Color.Black));
                    ef3 = new RectangleF(3f, 3f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else if (s == States.Disabled)
            {
                brush = new SolidBrush(Color.FromKnownColor(KnownColor.GrayText));
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x26, Color.Black));
                    ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
        }

        public void DrawTheme(PaintEventArgs e, States state, bool textfx, Color themecolor, bool focused)
        {
            this.TextEffects = textfx;
            this.isFocused = focused;
            this.tc = themecolor;
            if (state == States.MouseOver)
            {
                this.DrawOverButtonBody(e);
            }
            else if (state == States.Focused)
            {
                this.DrawFocusButtonBody(e);
            }
            else if (state == States.MouseDown)
            {
                this.DrawDownButtonBody(e);
            }
        }
    }
}

