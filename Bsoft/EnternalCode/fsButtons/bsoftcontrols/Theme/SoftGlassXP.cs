namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class SoftGlassXP
    {
        private Rectangle My;
        private bool TextEffects;
        private Color ThemeColor;

        public SoftGlassXP(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawBase(PaintEventArgs e, States s)
        {
            Brush brush;
            if (s == States.Disabled)
            {
                brush = new SolidBrush(modColorFunctions.cRGB(0xc9, 0xc7, 0xba));
            }
            else
            {
                brush = new SolidBrush(modColorFunctions.OpacityMix(Color.Black, this.ThemeColor, 0x2d));
            }
            Rectangle rect = new Rectangle(0, 0, this.My.Width, this.My.Height);
            this.FillRoundedRectangle(brush, 4, rect, e);
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60), Color.White, 100), Color.White, 60));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 60), Color.Black, 60));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60), Color.White, 100);
            Color color2 = modColorFunctions.SoftLightMix(this.ThemeColor, modColorFunctions.cRGB(0x34, 0x34, 0x34), 60);
            Color color3 = modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 60);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, 0.25f, 1f };
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color3);
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
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 40), Color.Black, 100), Color.Black, 50));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60), Color.White, 100));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 40), Color.Black, 100);
            Color color2 = modColorFunctions.SoftLightMix(this.ThemeColor, modColorFunctions.cRGB(0xcb, 0xcb, 0xcb), 60);
            Color color3 = modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, 0.25f, 1f };
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color3);
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(brush2, 2, rect, e);
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60), Color.White, 100), Color.White, 60));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 60), Color.Black, 60));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.Black, 60), Color.White, 100);
            Color color2 = modColorFunctions.SoftLightMix(this.ThemeColor, modColorFunctions.cRGB(0x34, 0x34, 0x34), 60);
            Color color3 = modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 60);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, 0.25f, 1f };
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color3);
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(brush2, 2, rect, e);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 50), Color.Black, 60), Color.White, 100), Color.White, 60));
            Rectangle rect = new Rectangle(1, 1, this.My.Width - 2, this.My.Height - 2);
            this.FillRoundedRectangle(b, 3, rect, e);
            b = new SolidBrush(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 50), Color.White, 60), Color.Black, 60));
            rect = new Rectangle(2, 2, this.My.Width - 3, this.My.Height - 3);
            this.FillRoundedRectangle(b, 3, rect, e);
            Color color = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 50), Color.Black, 60), Color.White, 100);
            Color color2 = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 50), modColorFunctions.cRGB(0x34, 0x34, 0x34), 60);
            Color color3 = modColorFunctions.SoftLightMix(modColorFunctions.SoftLightMix(this.ThemeColor, Color.White, 50), Color.White, 60);
            blend.Colors = new Color[] { color, color2, color3 };
            blend.Positions = new float[] { 0f, 0.25f, 1f };
            Point point = new Point(0, 1);
            Point point2 = new Point(0, this.My.Height - 1);
            LinearGradientBrush brush2 = new LinearGradientBrush(point, point2, color, color3);
            brush2.InterpolationColors = blend;
            brush2.GammaCorrection = true;
            rect = new Rectangle(2, 2, this.My.Width - 4, this.My.Height - 4);
            this.FillRoundedRectangle(brush2, 2, rect, e);
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
                    brush = new SolidBrush(Color.FromArgb(0x4c, Color.Black));
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
                    brush = new SolidBrush(Color.FromArgb(0x4c, Color.Black));
                    ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
        }

        public void DrawTheme(PaintEventArgs e, States state, Color tcolor, bool TextFx)
        {
            this.ThemeColor = tcolor;
            this.TextEffects = TextFx;
            this.DrawBase(e, state);
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

