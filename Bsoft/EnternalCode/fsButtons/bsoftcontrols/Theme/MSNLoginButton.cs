namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class MSNLoginButton
    {
        private Rectangle My;
        private bool TextEffects;

        public MSNLoginButton(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawBase(PaintEventArgs e, States state, Color backcolor)
        {
            Brush brush;
            if (state == States.MouseDown)
            {
                brush = new SolidBrush(Color.FromArgb(0x40, 7, 0x42, 0x83));
                e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top + 1, this.My.Width - 1, this.My.Height - 3);
                e.Graphics.FillRectangle(brush, this.My.Left + 1, this.My.Top, this.My.Width - 3, this.My.Height - 1);
                brush = new SolidBrush(modColorFunctions.cRGB(7, 0x42, 0x83));
                e.Graphics.FillRectangle(brush, (int) (this.My.Left + 1), (int) (this.My.Top + 2), (int) (this.My.Width - 1), (int) (this.My.Height - 3));
                e.Graphics.FillRectangle(brush, (int) (this.My.Left + 2), (int) (this.My.Top + 1), (int) (this.My.Width - 3), (int) (this.My.Height - 1));
            }
            else if (state == States.Disabled)
            {
                brush = new SolidBrush(modColorFunctions.cRGB(0x75, 120, 0x8a));
                e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top + 1, this.My.Width - 1, this.My.Height - 3);
                e.Graphics.FillRectangle(brush, this.My.Left + 1, this.My.Top, this.My.Width - 3, this.My.Height - 1);
            }
            else
            {
                brush = new SolidBrush(modColorFunctions.cRGB(7, 0x42, 0x83));
                e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top + 1, this.My.Width - 1, this.My.Height - 3);
                e.Graphics.FillRectangle(brush, this.My.Left + 1, this.My.Top, this.My.Width - 3, this.My.Height - 1);
            }
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush brush2 = new SolidBrush(modColorFunctions.cRGB(0xee, 0xa3, 0x35));
            e.Graphics.FillRectangle(brush2, (int) (this.My.Left + 1), (int) (this.My.Top + 1), (int) (this.My.Width - 3), (int) (this.My.Height - 3));
            brush2 = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush2, (int) (this.My.Left + 2), (int) (this.My.Top + 2), (int) (this.My.Width - 5), (int) (this.My.Height - 5));
            Color white = Color.White;
            Color color2 = modColorFunctions.cRGB(0xda, 0xe1, 0xfc);
            Point point = new Point(0, this.My.Top + 2);
            Point point2 = new Point(0, (this.My.Top + this.My.Height) - 3);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, white, color2);
            blend = new ColorBlend();
            blend.Colors = new Color[] { white, white, color2 };
            blend.Positions = new float[] { 0f, (float) (2.0 / ((double) (this.My.Height - 3))), 1f };
            brush.InterpolationColors = blend;
            brush.GammaCorrection = true;
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 4), (int) (this.My.Top + 4), (int) (this.My.Width - 10), (int) (this.My.Height - 7));
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xba, 0xc9, 0xf5)), (int) ((this.My.Left + this.My.Width) - 4), (int) (this.My.Top + 3), (int) ((this.My.Left + this.My.Width) - 4), (int) ((this.My.Top + this.My.Height) - 4));
            float num = this.My.Left + 2;
            float num2 = (this.My.Top + this.My.Height) - 3;
            float num3 = (float) (((double) (this.My.Width - 4)) / 4.0);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xf9, 0xac, 20)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x98, 0x35, 3)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(7, 80, 0x8f)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x11, 0x93, 0x31)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num = this.My.Left + 2;
            num2--;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xfb, 0xb5, 0x2a)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xec, 0x70, 0x66)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x27, 0x77, 0xd1)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x24, 190, 0x4a)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
        }

        private void DrawDisabledButtonBody(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(modColorFunctions.cRGB(0xb0, 0xb2, 0xbf));
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 1), (int) (this.My.Top + 1), (int) (this.My.Width - 3), (int) (this.My.Height - 3));
            brush = new SolidBrush(modColorFunctions.cRGB(0xe0, 0xe2, 0xec));
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 2), (int) (this.My.Top + 2), (int) (this.My.Width - 5), (int) (this.My.Height - 5));
            float num = this.My.Left + 2;
            float num2 = (this.My.Top + this.My.Height) - 4;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xc2, 0xc5, 0xd1)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            SolidBrush brush2 = new SolidBrush(modColorFunctions.cRGB(0x7b, 140, 0xc4));
            e.Graphics.FillRectangle(brush2, (int) (this.My.Left + 2), (int) (this.My.Top + 2), (int) (this.My.Width - 3), (int) (this.My.Height - 3));
            brush2 = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush2, (int) (this.My.Left + 3), (int) (this.My.Top + 3), (int) (this.My.Width - 5), (int) (this.My.Height - 5));
            Color white = Color.White;
            Color color2 = modColorFunctions.cRGB(0xda, 0xe1, 0xfc);
            Point point = new Point(0, this.My.Top + 3);
            Point point2 = new Point(0, (this.My.Top + this.My.Height) - 2);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, white, color2);
            blend = new ColorBlend();
            blend.Colors = new Color[] { white, white, color2 };
            blend.Positions = new float[] { 0f, (float) (2.0 / ((double) (this.My.Height - 3))), 1f };
            brush.InterpolationColors = blend;
            brush.GammaCorrection = true;
            e.Graphics.FillRectangle(brush, (int) (this.My.Left + 5), (int) (this.My.Top + 5), (int) (this.My.Width - 10), (int) (this.My.Height - 7));
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xba, 0xc9, 0xf5)), (int) ((this.My.Left + this.My.Width) - 3), (int) (this.My.Top + 4), (int) ((this.My.Left + this.My.Width) - 3), (int) ((this.My.Top + this.My.Height) - 3));
            float num = this.My.Left + 3;
            float num2 = (this.My.Top + this.My.Height) - 2;
            float num3 = (float) (((double) (this.My.Width - 4)) / 4.0);
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xf9, 0xac, 20)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x98, 0x35, 3)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(7, 80, 0x8f)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x11, 0x93, 0x31)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num = this.My.Left + 3;
            num2--;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xfb, 0xb5, 0x2a)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0xec, 0x70, 0x66)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x27, 0x77, 0xd1)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
            num += num3;
            e.Graphics.DrawLine(new Pen(modColorFunctions.cRGB(0x24, 190, 0x4a)), num, num2, (float) ((this.My.Left + this.My.Width) - 3), num2);
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            this.DrawButtonBody(e);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            this.DrawButtonBody(e);
        }

        public object DrawText(PaintEventArgs e, States s, string text, Font font)
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
                    brush = new SolidBrush(Color.FromArgb(0x40, modColorFunctions.cRGB(100, 0x7f, 0xcd)));
                    ef3 = new RectangleF((float) (this.My.Left + 4), (float) (this.My.Top + 4), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(modColorFunctions.cRGB(100, 0x7f, 0xcd));
                ef3 = new RectangleF((float) (this.My.Left + 3), (float) (this.My.Top + 3), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                return null;
            }
            if (s == States.Disabled)
            {
                brush = new SolidBrush(modColorFunctions.cRGB(0x75, 120, 0x8a));
                ef3 = new RectangleF((float) (this.My.Left + 2), (float) (this.My.Top + 2), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                return null;
            }
            if (s == States.MouseOver)
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x40, modColorFunctions.cRGB(100, 0x7f, 0xcd)));
                    ef3 = new RectangleF((float) (this.My.Left + 3), (float) (this.My.Top + 3), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(modColorFunctions.cRGB(100, 0x7f, 0xcd));
                ef3 = new RectangleF((float) (this.My.Left + 2), (float) (this.My.Top + 2), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                return null;
            }
            if (this.TextEffects)
            {
                brush = new SolidBrush(Color.FromArgb(0x40, modColorFunctions.cRGB(0x2f, 0x4a, 0x8f)));
                ef3 = new RectangleF((float) (this.My.Left + 3), (float) (this.My.Top + 3), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            brush = new SolidBrush(modColorFunctions.cRGB(0x2f, 0x4a, 0x8f));
            ef3 = new RectangleF((float) (this.My.Left + 2), (float) (this.My.Top + 2), (float) (this.My.Width - 5), (float) (this.My.Height - 2));
            e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            return null;
        }

        public void DrawTheme(PaintEventArgs e, States state, bool textfx, Color backcolor)
        {
            this.DrawBase(e, state, backcolor);
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
    }
}

