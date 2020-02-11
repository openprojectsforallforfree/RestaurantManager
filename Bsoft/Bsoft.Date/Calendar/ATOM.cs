﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bsoft.Date
{
    public partial class ATOM : UserControl
    {
        public ATOM()
        {
            showShadow = false;
            showToolTip = false;
            showEnglish = true;
            autoSizeFont = false;
            EnglishFontHeight = 12;
            NepaliFontHeight = 14;
            InitializeComponent();
        }

        public Bsoft.Date.NepaliDate Nepalidate;
        private short npday;
        private short enday;
        private PointF nptop = new PointF();
        private SizeF ent = new SizeF();
        private Font nepfont;
        private Font enFont;
        private static float nepfontheight = 1;
        private static float enfontheight = 1;
        public short npmonth;

        //endate is main
        private System.DateTime endate_;

        public System.DateTime engdate
        {
            get { return endate_; }
            set
            {
                endate_ = value;
                Nepalidate = Bsoft.Date.BsoftDateConverter.NepaliDate(endate_);
                npday = (short)Nepalidate.Day;
                npmonth = (short)Nepalidate.Month;
                enday = (short)value.Day;
                if (showToolTip)
                {
                    this.toolTip1.SetToolTip(this, endate_.ToString("yyyy/MM/dd") + "\n" + Nepalidate.ToString());
                }
            }
        }

        private StringFormat f = new StringFormat();
        private Bsoft.Date.BsoftDateConverter dc = new BsoftDateConverter();

        private void ATOM_Load(object sender, EventArgs e)
        {
            nptop = new Point(0, 0);
            nepfont = new Font("Times New Roman", nepfontheight, FontStyle.Bold, GraphicsUnit.Pixel);
            enFont = new Font("Courier", enfontheight, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Pixel);
            f.Alignment = StringAlignment.Far;
            f.LineAlignment = StringAlignment.Far;
        }

        private void ATOM_Resize(object sender, EventArgs e)
        {
            ent.Height = Height;
            ent.Width = Width;
            if (autoSizeFont)
            {
                if (Height < Width)
                {
                    nepfontheight = (float)(Convert.ToDecimal(Height * 0.65));
                }
                else
                {
                    nepfontheight = (float)(Convert.ToDecimal(Width * 0.65));
                }
                enfontheight = (float)(Convert.ToDecimal(nepfontheight * 0.75));
            }

            nepfont = new Font("Times New Roman", nepfontheight, FontStyle.Bold, GraphicsUnit.Pixel);
            enFont = new Font("Courier", enfontheight, FontStyle.Italic, GraphicsUnit.Pixel);

            Refresh();
        }

        private static SolidBrush blackBrush = new SolidBrush(Color.Magenta);
        private static SolidBrush blueBrush = new SolidBrush(Color.DarkOrange);

        private void ATOM_Paint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            if (isShadow)
            {
                if (showShadow)
                {
                    dc.DrawString(generalNepaliFunctions.getUnicodeNepali(npday.ToString()), nepfont, blueBrush, nptop);
                    if (showEnglish)
                    {
                        dc.DrawString(enday.ToString(), enFont, blackBrush, ent.Width, ent.Height, f);
                    }
                }
            }
            else
            {
                dc.DrawString(generalNepaliFunctions.getUnicodeNepali(npday.ToString()), nepfont, blueBrush, nptop);
                if (showEnglish)
                {
                    dc.DrawString(enday.ToString(), enFont, blackBrush, ent.Width, ent.Height, f);
                }
            }
            if (DateTime.Now.Date == endate_)
            {
                BackColor = TodayColor;
            }
        }

        private Color originalColor = Color.Beige;
        public bool isSelected = false;

        private void ATOM_MouseEnter(object sender, EventArgs e)
        {
            if (isShadow && !showShadow)
                return;
            originalColor = BackColor;
            BackColor = HoverColor;
        }

        private void ATOM_MouseLeave(object sender, EventArgs e)
        {
            if (isShadow && !showShadow)
                return;
            BackColor = originalColor;
            if (isSelected)
            {
                BackColor = SelectedColor;
            }
        }

        #region "Properties"

        public static bool showShadow { get; set; }

        public bool isShadow { get; set; }

        public static bool showToolTip { get; set; }

        public static bool showEnglish { get; set; }

        public static Color HoverColor { get; set; }

        public static Color TodayColor { get; set; }

        public static Color SelectedColor { get; set; }

        private static Color EnglishForeColor_;
        private static Color NepaliForeColor_;

        public static Color EnglishForeColor
        {
            get { return EnglishForeColor_; }
            set
            {
                EnglishForeColor_ = value;
                blackBrush = new SolidBrush(value);
            }
        }

        public static Color NepaliForeColor
        {
            get { return NepaliForeColor_; }
            set
            {
                NepaliForeColor_ = value;
                blueBrush = new SolidBrush(value);
            }
        }

        public static float NepaliFontHeight
        {
            get { return nepfontheight; }
            set { nepfontheight = value; }
        }

        public static float EnglishFontHeight
        {
            get { return enfontheight; }
            set { enfontheight = value; }
        }

        public static bool autoSizeFont
        {
            get;
            set;
        }

        #endregion "Properties"
    }
}