namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class LiquidChromeXP
    {
        private Rectangle My;
        private bool TextEffects;

        public LiquidChromeXP(Rectangle Owner)
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
                brush = new SolidBrush(modColorFunctions.cRGB(0x23, 0x37, 0x55));
            }
            Rectangle rect = new Rectangle(0, 0, this.My.Width, this.My.Height);
            this.FillRoundedRectangle(brush, 4, rect, e);
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0xb9, 0xb9, 0xb9));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.cRGB(0xee, 240, 0xf1);
            Color color2 = modColorFunctions.cRGB(0xce, 0xd1, 0xd6);
            Color white = Color.White;
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, white);
            blend.Colors = new Color[] { color, color2, white };
            blend.Positions = new float[] { 0f, 0.75f, 1f };
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(brush2, 2, rect, e);
        }

        private void DrawDisabledButtonBody(PaintEventArgs e)
        {
            Brush b = new SolidBrush(modColorFunctions.cRGB(0xf5, 0xf4, 0xea));
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(modColorFunctions.cRGB(0x89, 0x8d, 0x92));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0xff, 0xff, 0xff));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.cRGB(170, 0xaf, 0xb9);
            Color color2 = modColorFunctions.cRGB(230, 0xe8, 0xea);
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            brush2.GammaCorrection = true;
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(brush2, 1, rect, e);
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.cRGB(0x99, 0xd6, 0xff));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0, 0x7a, 0xcc));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0, 0x99, 0xff));
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(b, 2, rect, e);
            Color color = modColorFunctions.cRGB(0xee, 240, 0xf1);
            Color color2 = modColorFunctions.cRGB(0xce, 0xd1, 0xd6);
            Color white = Color.White;
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            blend.Colors = new Color[] { color, color2, white };
            blend.Positions = new float[] { 0f, 0.75f, 1f };
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(3, 3, this.My.Width - 6, this.My.Height - 6);
            this.FillRoundedRectangle(brush2, 1, rect, e);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.cRGB(0xff, 0xd6, 0x99));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0xcc, 0x7a, 0));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.cRGB(0xff, 0x99, 0));
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(b, 2, rect, e);
            Color color = modColorFunctions.cRGB(0xf3, 0xf4, 0xf5);
            Color color2 = modColorFunctions.cRGB(0xda, 0xdd, 0xe0);
            Color white = Color.White;
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color2);
            blend.Colors = new Color[] { color, color2, white };
            blend.Positions = new float[] { 0f, 0.75f, 1f };
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(3, 3, this.My.Width - 6, this.My.Height - 6);
            this.FillRoundedRectangle(brush2, 1, rect, e);
        }

        public object DrawText(PaintEventArgs e, States s, string text, Font font, Color forecolor)
        {
            Brush brush;
            object obj2;
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
                    brush = new SolidBrush(Color.FromArgb(0x80, Color.White));
                    ef3 = new RectangleF(3f, 3f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                return null;
            }
            if (s == States.Disabled)
            {
                brush = new SolidBrush(Color.FromKnownColor(KnownColor.GrayText));
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                return null;
            }
            if (this.TextEffects)
            {
                brush = new SolidBrush(Color.FromArgb(0x80, Color.White));
                ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            brush = new SolidBrush(forecolor);
            ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
            e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            return null;
        }

        public void DrawTheme(PaintEventArgs e, States state, bool textfx)
        {
            this.DrawBase(e, state);
            this.TextEffects = textfx;
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

