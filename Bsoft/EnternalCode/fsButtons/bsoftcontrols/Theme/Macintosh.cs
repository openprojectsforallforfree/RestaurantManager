namespace bsoftcontrols.Theme
{
    using bsoftcontrols;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class Macintosh
    {
        private Rectangle My;
        private Color tc;
        private bool TextEffects;

        public Macintosh(Rectangle Owner)
        {
            this.My = Owner;
        }

        private void DrawBase(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(modColorFunctions.OpacityMix(Color.Black, modColorFunctions.SoftLightMix(this.tc, Color.Black, 100), 50));
            Rectangle rect = new Rectangle(this.My.Left, this.My.Top, this.My.Width, this.My.Height);
            this.FillPlate(b, rect, e);
        }

        private void DrawButtonBody(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(modColorFunctions.OpacityMix(Color.Black, modColorFunctions.SoftLightMix(this.tc, Color.Black, 100), 30));
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(this.tc);
            rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 3, this.My.Height - 3);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(Color.White);
            rect = new Rectangle(this.My.Left + 2, this.My.Top + 2, this.My.Width - 4, this.My.Height - 4);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(this.tc);
            rect = new Rectangle(this.My.Left + 3, this.My.Top + 3, this.My.Width - 5, this.My.Height - 5);
            this.FillPlate(b, rect, e);
            Color color = modColorFunctions.SoftLightMix(this.tc, Color.Black, 50);
            e.Graphics.DrawLine(new Pen(color), (int) (this.My.Left + 1), (int) ((this.My.Top + this.My.Height) - 3), (int) ((this.My.Left + this.My.Width) - 4), (int) ((this.My.Top + this.My.Height) - 3));
            e.Graphics.DrawLine(new Pen(color), (int) ((this.My.Left + this.My.Width) - 3), (int) (this.My.Top + 1), (int) ((this.My.Left + this.My.Width) - 3), (int) ((this.My.Top + this.My.Height) - 4));
        }

        private void DrawDownButtonBody(PaintEventArgs e)
        {
            Color baseColor = modColorFunctions.OpacityMix(Color.Black, modColorFunctions.SoftLightMix(this.tc, Color.Black, 100), 30);
            SolidBrush b = new SolidBrush(modColorFunctions.SoftLightMix(baseColor, Color.Black, 0x4b));
            Rectangle rect = new Rectangle(this.My.Left + 1, this.My.Top + 1, this.My.Width - 2, this.My.Height - 2);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(baseColor);
            rect = new Rectangle(this.My.Left + 2, this.My.Top + 2, this.My.Width - 3, this.My.Height - 3);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(modColorFunctions.OpacityMix(Color.White, baseColor, 15));
            rect = new Rectangle(this.My.Left + 2, this.My.Top + 2, this.My.Width - 4, this.My.Height - 4);
            this.FillPlate(b, rect, e);
            b = new SolidBrush(baseColor);
            rect = new Rectangle(this.My.Left + 2, this.My.Top + 2, this.My.Width - 5, this.My.Height - 5);
            this.FillPlate(b, rect, e);
            Color color = modColorFunctions.SoftLightMix(baseColor, Color.Black, 0x19);
            e.Graphics.DrawLine(new Pen(color), (int) (this.My.Left + 2), (int) (this.My.Top + 3), (int) (this.My.Left + 2), (int) ((this.My.Top + this.My.Height) - 2));
            e.Graphics.DrawLine(new Pen(color), (int) (this.My.Left + 3), (int) (this.My.Top + 2), (int) ((this.My.Left + this.My.Width) - 2), (int) (this.My.Top + 2));
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
                    brush = new SolidBrush(Color.FromArgb(0x80, Color.White));
                    ef3 = new RectangleF(3f, 3f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                    e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                }
                brush = new SolidBrush(forecolor);
                ef3 = new RectangleF(2f, 2f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else if (s == States.Disabled)
            {
                brush = new SolidBrush(Color.FromArgb(0x80, Color.White));
                ef3 = new RectangleF(3f, 3f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
                brush = new SolidBrush(Color.FromKnownColor(KnownColor.GrayText));
                ef3 = new RectangleF(1f, 1f, (float) (this.My.Width - 2), (float) (this.My.Height - 2));
                e.Graphics.DrawString(text, font, brush, ef3, stringFormat);
            }
            else
            {
                if (this.TextEffects)
                {
                    brush = new SolidBrush(Color.FromArgb(0x80, Color.White));
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
            this.TextEffects = textfx;
            this.tc = themecolor;
            this.DrawBase(e);
            if (state == States.Normal)
            {
                this.DrawButtonBody(e);
            }
            else if (state == States.MouseOver)
            {
                this.DrawButtonBody(e);
            }
            else if (state == States.Focused)
            {
                this.DrawButtonBody(e);
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

        private void FillPlate(Brush b, Rectangle rect, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(b, rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
            e.Graphics.FillRectangle(b, rect.Left + 1, rect.Top, rect.Width - 2, rect.Height);
        }
    }
}

