namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class Aqua
    {
        private Rectangle My;
        private Color tc;
        private bool TextEffects;

        public Aqua(Rectangle Owner)
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
                brush = new SolidBrush(modColorFunctions.OpacityMix(Color.Black, this.tc, 70));
            }
            Rectangle rect = new Rectangle(0, 0, this.My.Width, this.My.Height);
            this.FillPill(brush, rect, e);
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.OpacityMix(Color.White, modColorFunctions.SoftLightMix(this.tc, Color.Black, 100), 40);
            Color white = modColorFunctions.OpacityMix(Color.White, modColorFunctions.SoftLightMix(this.tc, modColorFunctions.cRGB(0x40, 0x40, 0x40), 100), 20);
            Color color3 = modColorFunctions.SoftLightMix(this.tc, modColorFunctions.cRGB(0x80, 0x80, 0x80), 100);
            Color color4 = modColorFunctions.SoftLightMix(this.tc, modColorFunctions.cRGB(0xc0, 0xc0, 0xc0), 100);
            Color color5 = modColorFunctions.OverlayMix(modColorFunctions.SoftLightMix(this.tc, Color.White, 100), Color.White, 0x4b);
            Color[] colorArray = new Color[] { color, white, color3, color4, color5 };
            blend.Colors = colorArray;
            blend.Positions = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1f };
            Point point = new Point(this.My.Left + 1, this.My.Top);
            Point point2 = new Point(this.My.Left + 1, (this.My.Top + this.My.Height) - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color, color5);
            b.InterpolationColors = blend;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPill(b, rect, e);
            white = Color.White;
            colorArray = new Color[] { white, color3, color4, color5 };
            blend.Colors = colorArray;
            blend.Positions = new float[] { 0f, 0.5f, 0.75f, 1f };
            point2 = new Point(this.My.Left + 1, this.My.Top);
            point = new Point(this.My.Left + 1, (this.My.Top + this.My.Height) - 1);
            b = new LinearGradientBrush(point2, point, white, color5);
            b.InterpolationColors = blend;
            rect = new Rectangle(this.My.Left + 4, this.My.Top + 4, this.My.Width - 8, this.My.Height - 8);
            this.FillPill(b, rect, e);
        }

        private void DrawDisabledButtonBody(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(modColorFunctions.cRGB(0xf5, 0xf4, 0xea));
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPill(b, rect, e);
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            blend.Colors = new Color[] { modColorFunctions.OpacityMix(Color.Black, this.tc, 0x19), this.tc, modColorFunctions.OpacityMix(Color.Black, this.tc, 0x19) };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            Point point = new Point(this.My.Left + 1, this.My.Top);
            Point point2 = new Point(this.My.Left + 1, (this.My.Top + this.My.Height) - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, modColorFunctions.OpacityMix(Color.Black, this.tc, 0x19), modColorFunctions.OpacityMix(Color.Black, this.tc, 0x19));
            b.InterpolationColors = blend;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPill(b, rect, e);
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            this.DrawButtonBody(e);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color baseColor = modColorFunctions.SoftLightMix(this.tc, Color.White, 60);
            Color color2 = modColorFunctions.OpacityMix(Color.White, modColorFunctions.SoftLightMix(baseColor, Color.Black, 100), 40);
            Color white = modColorFunctions.OpacityMix(Color.White, modColorFunctions.SoftLightMix(baseColor, modColorFunctions.cRGB(0x40, 0x40, 0x40), 100), 20);
            Color color4 = modColorFunctions.SoftLightMix(baseColor, modColorFunctions.cRGB(0x80, 0x80, 0x80), 100);
            Color color5 = modColorFunctions.SoftLightMix(baseColor, modColorFunctions.cRGB(0xc0, 0xc0, 0xc0), 100);
            Color color6 = modColorFunctions.OverlayMix(modColorFunctions.SoftLightMix(baseColor, Color.White, 100), Color.White, 0x4b);
            Color[] colorArray = new Color[] { color2, white, color4, color5, color6 };
            blend.Colors = colorArray;
            blend.Positions = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1f };
            Point point = new Point(this.My.Left + 1, this.My.Top);
            Point point2 = new Point(this.My.Left + 1, (this.My.Top + this.My.Height) - 1);
            LinearGradientBrush b = new LinearGradientBrush(point, point2, color2, color6);
            b.InterpolationColors = blend;
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPill(b, rect, e);
            white = Color.White;
            colorArray = new Color[] { white, color4, color5, color6 };
            blend.Colors = colorArray;
            blend.Positions = new float[] { 0f, 0.5f, 0.75f, 1f };
            point2 = new Point(this.My.Left + 1, this.My.Top);
            point = new Point(this.My.Left + 1, (this.My.Top + this.My.Height) - 1);
            b = new LinearGradientBrush(point2, point, white, color6);
            b.InterpolationColors = blend;
            rect = new Rectangle(this.My.Left + 4, this.My.Top + 4, this.My.Width - 8, this.My.Height - 8);
            this.FillPill(b, rect, e);
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
                    brush = new SolidBrush(Color.FromArgb(0x59, Color.Black));
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
                    brush = new SolidBrush(Color.FromArgb(0x59, Color.Black));
                    ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
        }

        public void DrawTheme(PaintEventArgs e, States state, bool textfx, Color themecolor)
        {
            this.tc = themecolor;
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

        private void FillPill(Brush b, Rectangle rect, PaintEventArgs e)
        {
            Rectangle rectangle;
            if (rect.Width > rect.Height)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                rectangle = new Rectangle(rect.Left, rect.Top, rect.Height, rect.Height);
                e.Graphics.FillEllipse(b, rectangle);
                rectangle = new Rectangle((rect.Left + rect.Width) - rect.Height, rect.Top, rect.Height, rect.Height);
                e.Graphics.FillEllipse(b, rectangle);
                e.Graphics.SmoothingMode = SmoothingMode.Default;
                rectangle = new Rectangle((int) Math.Round((double) (rect.Left + (((double) rect.Height) / 2.0))), rect.Top, rect.Width - rect.Height, rect.Height);
                e.Graphics.FillRectangle(b, rectangle);
            }
            else if (rect.Width < rect.Height)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                rectangle = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Width);
                e.Graphics.FillEllipse(b, rectangle);
                rectangle = new Rectangle(rect.Left, (rect.Top + rect.Height) - rect.Width, rect.Width, rect.Width);
                e.Graphics.FillEllipse(b, rectangle);
                e.Graphics.SmoothingMode = SmoothingMode.Default;
                rectangle = new Rectangle(rect.Left, (int) Math.Round((double) (rect.Top + (((double) rect.Width) / 2.0))), rect.Width, rect.Height - rect.Width);
                e.Graphics.FillRectangle(b, rectangle);
            }
            else if (rect.Width == rect.Height)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillEllipse(b, rect);
                e.Graphics.SmoothingMode = SmoothingMode.Default;
            }
        }
    }
}

