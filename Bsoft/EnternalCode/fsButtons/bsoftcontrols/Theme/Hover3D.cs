namespace bsoftcontrols.Theme
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class Hover3D
    {
        private bool isFocused;
        private Rectangle My;
        private bool TextEffects;

        public Hover3D(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x26, Color.Black)), this.My.Left, this.My.Top, this.My.Left + this.My.Width, this.My.Top);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x26, Color.Black)), this.My.Left, this.My.Top, this.My.Left, this.My.Top + this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0xa6, Color.White)), this.My.Left, (this.My.Top + this.My.Height) - 1, this.My.Left + this.My.Width, (this.My.Top + this.My.Height) - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0xa6, Color.White)), (this.My.Left + this.My.Width) - 1, this.My.Top, (this.My.Left + this.My.Width) - 1, this.My.Top + this.My.Height);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(6, Color.Black)), this.My.Left, this.My.Top, this.My.Width, this.My.Height);
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
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x40, Color.White)), this.My.Left, this.My.Top, this.My.Left + this.My.Width, this.My.Top);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x40, Color.White)), this.My.Left, this.My.Top, this.My.Left, this.My.Top + this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), this.My.Left, (this.My.Top + this.My.Height) - 1, this.My.Left + this.My.Width, (this.My.Top + this.My.Height) - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), (this.My.Left + this.My.Width) - 1, this.My.Top, (this.My.Left + this.My.Width) - 1, this.My.Top + this.My.Height);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            if (this.isFocused)
            {
                Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
                pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 7), (int) (this.My.Height - 7));
            }
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0xbf, Color.White)), this.My.Left, this.My.Top, this.My.Left + this.My.Width, this.My.Top);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0xbf, Color.White)), this.My.Left, this.My.Top, this.My.Left, this.My.Top + this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x59, Color.Black)), this.My.Left, (this.My.Top + this.My.Height) - 1, this.My.Left + this.My.Width, (this.My.Top + this.My.Height) - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x59, Color.Black)), (this.My.Left + this.My.Width) - 1, this.My.Top, (this.My.Left + this.My.Width) - 1, this.My.Top + this.My.Height);
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

        public void DrawTheme(PaintEventArgs e, States state, bool textfx, bool focused)
        {
            this.TextEffects = textfx;
            this.isFocused = focused;
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

