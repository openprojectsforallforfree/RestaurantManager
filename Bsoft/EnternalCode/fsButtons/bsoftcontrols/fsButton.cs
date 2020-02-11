namespace bsoftcontrols
{
    using bsoftcontrols.Theme;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class fsButton : Button
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        private bool _ShowTextEffects;
        private Themes _Theme;
        private Color _ThemeColor;
        private bool isFocused;
        private bool isMouseDown;
        private bool isMouseOver;

        public fsButton()
        {
            List<WeakReference> list = __ENCList;
            lock (list)
            {
                __ENCList.Add(new WeakReference(this));
            }
            this.isMouseOver = false;
            this.isMouseDown = false;
            this.isFocused = false;
            this._ThemeColor = modColorFunctions.cRGB(0, 0x66, 0xff);
            this._ShowTextEffects = true;
            this.InitializeComponent();
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

         

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.ResumeLayout(false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.isFocused = true;
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                this.isMouseDown = true;
            }
            this.Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Space)
            {
                this.isMouseDown = false;
                base.OnClick(e);
            }
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.isFocused = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
                if (rectangle.Contains(e.X, e.Y))
                {
                    this.isMouseDown = true;
                }
                else
                {
                    this.isMouseDown = false;
                }
                this.Focus();
            }
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.isMouseOver = false;
            this.isMouseDown = false;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Rectangle rectangle2;
            base.OnMouseMove(e);
            if ((e.Button == MouseButtons.None) | (e.Button == MouseButtons.Left))
            {
                if (e.Button == MouseButtons.None)
                {
                    this.isMouseDown = false;
                }
                this.isMouseOver = true;
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
                rectangle2 = rectangle;
                if (!rectangle2.Contains(e.X, e.Y))
                {
                    this.isMouseOver = false;
                }
                else
                {
                    this.isMouseOver = true;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                rectangle2 = new Rectangle(0, 0, this.Width, this.Height);
                if (!rectangle2.Contains(e.X, e.Y))
                {
                    this.isMouseDown = false;
                }
                else
                {
                    this.isMouseDown = true;
                }
            }
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                this.isMouseDown = false;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            States disabled;
            Rectangle rectangle;
            base.OnPaint(e);
            if (!this.Enabled)
            {
                disabled = States.Disabled;
            }
            else if (!this.isMouseDown)
            {
                if (this.isMouseOver)
                {
                    disabled = States.MouseOver;
                }
                else if (this.isFocused)
                {
                    disabled = States.Focused;
                }
                else
                {
                    disabled = States.Normal;
                }
            }
            else
            {
                disabled = States.MouseDown;
            }
            switch (this._Theme)
            {
                case Themes.Office2003:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    Office2003 office = new Office2003(rectangle);
                    office.DrawTheme(e, disabled, this._ShowTextEffects, this._ThemeColor, this.isFocused);
                    office.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.SoftGlassXP:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    SoftGlassXP sxp = new SoftGlassXP(rectangle);
                    sxp.DrawTheme(e, disabled, this._ThemeColor, this._ShowTextEffects);
                    sxp.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.WindowsXP:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    WindowsXP sxp2 = new WindowsXP(rectangle);
                    sxp2.DrawTheme(e, disabled, this._ShowTextEffects);
                    sxp2.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.MSNLoginButton:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    MSNLoginButton button = new MSNLoginButton(rectangle);
                    button.DrawTheme(e, disabled, this._ShowTextEffects, this.BackColor);
                    button.DrawText(e, disabled, this.Text, this.Font);
                    break;
                }
                case Themes.Aqua:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    Aqua aqua = new Aqua(rectangle);
                    aqua.DrawTheme(e, disabled, this._ShowTextEffects, this._ThemeColor);
                    aqua.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.Hover3D:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    Hover3D hoverd = new Hover3D(rectangle);
                    hoverd.DrawTheme(e, disabled, this._ShowTextEffects, this.isFocused);
                    hoverd.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.OfficeXP:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    OfficeXP exp2 = new OfficeXP(rectangle);
                    exp2.DrawTheme(e, disabled, this._ShowTextEffects, this._ThemeColor, this.isFocused);
                    exp2.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.LiquidChromeXP:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    LiquidChromeXP exp = new LiquidChromeXP(rectangle);
                    exp.DrawTheme(e, disabled, this._ShowTextEffects);
                    exp.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
                case Themes.Macintosh:
                {
                    rectangle = new Rectangle(0, 0, this.Width, this.Height);
                    Macintosh macintosh = new Macintosh(rectangle);
                    macintosh.DrawTheme(e, disabled, this._ShowTextEffects, this._ThemeColor);
                    macintosh.DrawText(e, disabled, this.Text, this.Font, this.ForeColor);
                    break;
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }

        [Description("Controls the theme which is applied to the button."), DefaultValue(typeof(Themes), "LiquidChromeXP")]
        public Themes ButtonTheme
        {
            get
            {
                return this._Theme;
            }
            set
            {
                this._Theme = value;
                this.Invalidate();
               
            }
        }

        [DefaultValue(typeof(bool), "True"), Description("Determines whether or not to show the text effects for the selected theme.")]
        public bool ShowTextEffects
        {
            get
            {
                return this._ShowTextEffects;
            }
            set
            {
                this._ShowTextEffects = value;
                this.Invalidate();
               
            }
        }

        [DefaultValue(typeof(Color), "0, 102, 255"), Description("Sets the base color for the theme.")]
        public Color ThemeColor
        {
            get
            {
                return this._ThemeColor;
            }
            set
            {
                this._ThemeColor = value;
                this.Invalidate();
              
            }
        }

        
      

        public enum Themes
        {
            Office2003,
            SoftGlassXP,
            WindowsXP,
            MSNLoginButton,
            Aqua,
            Hover3D,
            OfficeXP,
            LiquidChromeXP,
            Macintosh
        }
    }
}

