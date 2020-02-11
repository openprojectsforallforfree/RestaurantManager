namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class Office2003
    {
        private bool isFocused;
        private Rectangle My;
        private Color tc;
        private bool TextEffects;

        public Office2003(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.OverlayMix(modColorFunctions.OpacityMix(Color.White, this.tc, 0x37), Color.White, 60);
            Color baseColor = modColorFunctions.OpacityMix(Color.White, this.tc, 0x37);
            Color color3 = modColorFunctions.OpacityMix(Color.Black, baseColor, 15);
            blend.Colors = new Color[] { color, baseColor, color3 };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            Point point = new Point(0, this.My.Top);
            Point point2 = new Point(0, this.My.Top + this.My.Height);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, color, color3);
            brush.InterpolationColors = blend;
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x59, Color.White)), this.My.Left, this.My.Top, this.My.Left + this.My.Width, this.My.Top);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x59, Color.White)), this.My.Left, this.My.Top, this.My.Left, this.My.Top + this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), this.My.Left, (this.My.Top + this.My.Height) - 1, this.My.Left + this.My.Width, (this.My.Top + this.My.Height) - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), (this.My.Left + this.My.Width) - 1, this.My.Top, (this.My.Left + this.My.Width) - 1, this.My.Top + this.My.Height);
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            Color baseColor = modColorFunctions.OpacityMix(Color.White, modColorFunctions.OverlayMix(modColorFunctions.InvertColor(this.tc), Color.White, 10), 50);
            Color color2 = modColorFunctions.OverlayMix(baseColor, Color.Black, 0x23);
            Color color3 = modColorFunctions.OverlayMix(baseColor, Color.White, 0x19);
            Point point = new Point(0, this.My.Top);
            Point point2 = new Point(0, this.My.Top + this.My.Height);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, color2, color3);
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            e.Graphics.DrawRectangle(new Pen(modColorFunctions.OpacityMix(Color.Black, modColorFunctions.OverlayMix(this.tc, Color.Black, 0x4b), 50)), this.My.Left, this.My.Top, this.My.Width - 1, this.My.Height - 1);
            if (this.isFocused)
            {
                Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
                pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, (int)(this.My.Left + 3), (int)(this.My.Top + 3), (int)(this.My.Width - 7), (int)(this.My.Height - 7));
            }
        }

        private void DrawFocusButtonBody(PaintEventArgs e)
        {
            ColorBlend blend = new ColorBlend();
            Color color = modColorFunctions.OverlayMix(modColorFunctions.OpacityMix(Color.White, this.tc, 0x37), Color.White, 60);
            Color baseColor = modColorFunctions.OpacityMix(Color.White, this.tc, 0x37);
            Color color3 = modColorFunctions.OpacityMix(Color.Black, baseColor, 15);
            blend.Colors = new Color[] { color, baseColor, color3 };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            Point point = new Point(0, this.My.Top);
            Point point2 = new Point(0, this.My.Top + this.My.Height);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, color, color3);
            brush.InterpolationColors = blend;
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawRectangle(pen, (int)(this.My.Left + 3), (int)(this.My.Top + 3), (int)(this.My.Width - 7), (int)(this.My.Height - 7));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x40, Color.White)), this.My.Left, this.My.Top, this.My.Left + this.My.Width, this.My.Top);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x40, Color.White)), this.My.Left, this.My.Top, this.My.Left, this.My.Top + this.My.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), this.My.Left, (this.My.Top + this.My.Height) - 1, this.My.Left + this.My.Width, (this.My.Top + this.My.Height) - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(0x1a, Color.Black)), (this.My.Left + this.My.Width) - 1, this.My.Top, (this.My.Left + this.My.Width) - 1, this.My.Top + this.My.Height);
        }

        private void DrawOverButtonBody(PaintEventArgs e)
        {
            Color baseColor = modColorFunctions.OpacityMix(Color.White, modColorFunctions.OverlayMix(modColorFunctions.InvertColor(this.tc), Color.White, 0x19), 50);
            Color color2 = modColorFunctions.OverlayMix(baseColor, Color.White, 50);
            Color color3 = modColorFunctions.OverlayMix(baseColor, Color.Black, 15);
            Point point = new Point(0, this.My.Top);
            Point point2 = new Point(0, this.My.Top + this.My.Height);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, color2, color3);
            e.Graphics.FillRectangle(brush, this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            e.Graphics.DrawRectangle(new Pen(modColorFunctions.OpacityMix(Color.Black, modColorFunctions.OverlayMix(this.tc, Color.Black, 0x4b), 50)), this.My.Left, this.My.Top, this.My.Width - 1, this.My.Height - 1);
            if (this.isFocused)
            {
                Pen pen = new Pen(Color.FromArgb(0x80, Color.Black));
                pen.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(pen, (int)(this.My.Left + 3), (int)(this.My.Top + 3), (int)(this.My.Width - 7), (int)(this.My.Height - 7));
            }
        }

        public void DrawText(PaintEventArgs e, States s, string text, Font font, Color forecolor)
        {
            int andLocation = text.IndexOf('&');
            if (andLocation >= 0)
            {
                text = text.Remove(andLocation, 1);
            }

            Brush brush;
            RectangleF ef3;
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            SizeF layoutArea = new SizeF((float)(this.My.Width - 2), (float)(this.My.Height - 2));
            SizeF ef = e.Graphics.MeasureString(text, font, layoutArea, stringFormat);
            text = text + "                    ";
            if (s == States.MouseDown)
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x26, Color.Black));
                    ef3 = new RectangleF(3f, 3f, (float)(this.My.Width - 2), (float)(this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                if (andLocation >= 0)
                {
                    e.Graphics.DrawString("Alt + " + text.Substring(andLocation, 1),new Font ( font,FontStyle .Bold ), Brushes.BlueViolet, 3, 3);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(2f, 2f, (float)(this.My.Width - 2), (float)(this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else if (s == States.Disabled)
            {
                brush = new SolidBrush(Color.FromKnownColor(KnownColor.GrayText));
                ef3 = new RectangleF(1f, 1f, (float)(this.My.Width - 2), (float)(this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x26, Color.Black));
                    ef3 = new RectangleF(2f, 2f, (float)(this.My.Width - 2), (float)(this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(1f, 1f, (float)(this.My.Width - 2), (float)(this.My.Height - 2));
                SizeF sz = new SizeF(ef3.Width, ef3.Height);
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);

                //draw bold & location



            }
        }

        public void DrawTheme(PaintEventArgs e, States state, bool textfx, Color themecolor, bool focused)
        {
            this.TextEffects = textfx;
            this.isFocused = focused;
            this.tc = themecolor;
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
                this.DrawButtonBody(e);
            }
        }
    }
}

