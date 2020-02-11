namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class WindowsXP
    {
        private Rectangle My;
        private bool TextEffects;

        public WindowsXP(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawBase(PaintEventArgs e, States state)
        {
            Brush brush;
            if (state == States.Disabled)
            {
                brush = new SolidBrush(modColorFunctions.cRGB(0xc9, 0xc7, 0xba));
            }
            else
            {
                brush = new SolidBrush(modColorFunctions.cRGB(0, 60, 0x74));
            }
            Rectangle rect = new Rectangle(this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            this.FillRoundedRectangle(brush, 2, rect, e);
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.cRGB(0xff, 0xff, 0xff);
            Color color2 = modColorFunctions.cRGB(0xf4, 0xf2, 0xe8);
            Color color3 = modColorFunctions.cRGB(220, 0xd7, 0xcb);
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color, color3);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, (float) (((double) (this.My.Height - 5)) / ((double) this.My.Height)), 1f };
            b.InterpolationColors = blend;
            b.GammaCorrection = true;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 1, rect, e);
            e.Graphics.DrawLine(new Pen(color3), this.My.Width - 2, 2, this.My.Width - 2, this.My.Height - 3);
        }

        private void DrawDisabledButtonBody(PaintEventArgs e)
        {
            Brush b = new SolidBrush(modColorFunctions.cRGB(0xf5, 0xf4, 0xea));
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 1, rect, e);
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.cRGB(0xd1, 0xcc, 0xc1);
            Color color2 = modColorFunctions.cRGB(0xe3, 0xe2, 0xda);
            Color color3 = modColorFunctions.cRGB(0xef, 0xee, 0xea);
            Point point = new Point(0, this.My.Top + 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color, color3);
            blend.Colors = new Color[] { color, color2, color2, color3 };
            blend.Positions = new float[] { 0f, (float) (4.0 / ((double) this.My.Height)), (float) (((double) (this.My.Height - 5)) / ((double) this.My.Height)), 1f };
            b.InterpolationColors = blend;
            b.GammaCorrection = true;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 1, rect, e);
            e.Graphics.DrawLine(new Pen(color), (int) (this.My.Left + 1), (int) (this.My.Top + 2), (int) (this.My.Left + 1), (int) (this.My.Height - 3));
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.cRGB(0xc2, 0xdb, 0xff);
            Color color2 = modColorFunctions.cRGB(140, 180, 0xf2);
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color, color2);
            b.GammaCorrection = true;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 1, rect, e);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xce, 0xe7, 0xff)), 2, 1, this.My.Width - 3, 1);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x69, 130, 0xee)), 2, this.My.Height - 2, this.My.Width - 3, this.My.Height - 2);
            color = modColorFunctions.cRGB(0xff, 0xff, 0xff);
            color2 = modColorFunctions.cRGB(0xf4, 0xf2, 0xe8);
            Color color3 = modColorFunctions.cRGB(220, 0xd7, 0xcb);
            point2 = new Point(this.My.Left, this.My.Top + 1);
            point = new Point(this.My.Left, this.My.Height - 1);
            b = new LinearGradientBrush(point2, point, color, color3);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, (float) (((double) (this.My.Height - 5)) / ((double) this.My.Height)), 1f };
            b.InterpolationColors = blend;
            b.GammaCorrection = true;
            e.Graphics.FillRectangle(b, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 6), (int) (this.My.Height - 6));
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.cRGB(0xff, 0xda, 140);
            Color color2 = modColorFunctions.cRGB(0xff, 0xb8, 0x34);
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color, color2);
            b.GammaCorrection = true;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 1, rect, e);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xff, 240, 0xcf)), 2, 1, this.My.Width - 3, 1);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xe5, 0x97, 0)), 2, this.My.Height - 2, this.My.Width - 3, this.My.Height - 2);
            color = modColorFunctions.cRGB(0xff, 0xff, 0xff);
            color2 = modColorFunctions.cRGB(0xf4, 0xf2, 0xe8);
            Color color3 = modColorFunctions.cRGB(220, 0xd7, 0xcb);
            point2 = new Point(0, 1);
            point = new Point(0, this.My.Height - 1);
            b = new LinearGradientBrush(point2, point, color, color3);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, (float) (((double) (this.My.Height - 5)) / ((double) this.My.Height)), 1f };
            b.InterpolationColors = blend;
            b.GammaCorrection = true;
            e.Graphics.FillRectangle(b, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 6), (int) (this.My.Height - 6));
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
                    brush = new SolidBrush(Color.FromArgb(0xbf, Color.White));
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
                    brush = new SolidBrush(Color.FromArgb(0xbf, Color.White));
                    ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
        }

        public void DrawTheme(PaintEventArgs e, States state, bool TextFX)
        {
            this.DrawBase(e, state);
            this.TextEffects = TextFX;
            if (state == States.Normal)
            {
                this.DrawButtonBody(e);
            }
            else if (state == States.MouseOver)
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
            else if (state == States.Disabled)
            {
                this.DrawDisabledButtonBody(e);
            }
        }

        private void FillRoundedRectangle(Brush b, int Radius, Rectangle Rect, PaintEventArgs e)
        {
            Point point3 = new Point(Rect.Left, Rect.Top);
            Point point4 = new Point(Rect.Left + Rect.Width, Rect.Top);
            Point point = new Point(Rect.Left, Rect.Top + Rect.Height);
            Point point2 = new Point(Rect.Left + Rect.Width, Rect.Top + Rect.Height);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(point3.X, point3.Y, Radius * 2, Radius * 2);
            e.Graphics.FillEllipse(b, rect);
            rect = new Rectangle(point.X, (point.Y - (Radius * 2)) - 1, Radius * 2, Radius * 2);
            e.Graphics.FillEllipse(b, rect);
            rect = new Rectangle((point4.X - (Radius * 2)) - 1, point4.Y, Radius * 2, Radius * 2);
            e.Graphics.FillEllipse(b, rect);
            rect = new Rectangle((point2.X - (Radius * 2)) - 1, (point2.Y - (Radius * 2)) - 1, Radius * 2, Radius * 2);
            e.Graphics.FillEllipse(b, rect);
            e.Graphics.SmoothingMode = SmoothingMode.Default;
            rect = new Rectangle(point3.X, point3.Y + Radius, Rect.Width, Rect.Height - (Radius * 2));
            e.Graphics.FillRectangle(b, rect);
            rect = new Rectangle(point3.X + Radius, point3.Y, Rect.Width - (Radius * 2), Rect.Height);
            e.Graphics.FillRectangle(b, rect);
        }
    }
}

