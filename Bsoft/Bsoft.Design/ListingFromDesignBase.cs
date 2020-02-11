//using TPPIMS.AppClass;
//using Bsoft.Controls;
using Bsoft.Controls;
using Bsoft.Date;
using Bsoft.Forms;
using Friuts;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//using Bsoft.Common;
//using Bsoft.Data;

namespace Bsoft.Design
{
    [System.ComponentModel.DesignerCategory("form")]
    public class ListingFromDesignBase : Friuts.ListingFormBase
    {
        //constant
        private int TopPix = 20;

        //for resize
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        //for move
        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //for maximize control over area
        public new FormWindowState WindowState
        {
            get
            {
                return base.WindowState;
            }
            set
            {
                if (value == FormWindowState.Maximized)
                {
                    this.MaximizedBounds =
                       SystemInformation.WorkingArea;
                    this.MaximumSize = SystemInformation.WorkingArea.Size;
                }
                base.WindowState = value;
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Y < TopPix)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }
                else if (WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Y < TopPix)//Is the pixel size at top
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ReleaseCapture();
                        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    }
                }
            }
        }

        //#region Dragable form
        //const int WM_NCHITTEST = 0x84;
        //const int HTCAPTION = 2;
        //const int HTCLIENT = 1;
        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.Msg == WM_NCHITTEST && m.Result.ToInt32() == HTCLIENT)
        //    {
        //        m.Result = new IntPtr(HTCAPTION);
        //    }
        //}
        //#endregion

        public static Font MainFont = new Font("Veranda", 10);
        public static Font DigitFont = new Font("Veranda", 10);
        private Font _titleFont = new Font("Verdana", 15);
        private Color _titleForeColor = Color.Wheat;

        private HorizontalAlignment _titleFontAlignment = HorizontalAlignment.Left;
        private SizeF _titleBarSize = new Size();
        //added to change the form title properties

        //public Form _ThisForm = null;
        public Color _Original = Color.Transparent;

        public Color _Focuscolor = Color.Yellow;
        public Color _OriginalButtonTheme = Color.RoyalBlue;
        public Color _FocusButoonTheme = Color.Yellow;

        public RoundRectButton _closeButton = new RoundRectButton();

        private static Bitmap topBar = Properties.Resources.headerTop;
        private static Bitmap rightBar = Properties.Resources.BorderVertical;
        private static Bitmap bottomBar = Properties.Resources.BorderHorizontall;
        private static Bitmap leftBar = Properties.Resources.BorderVertical;
        private static Bitmap bodybmp = Properties.Resources.body;

        protected bool _isFormLoaded = false;

        #region Set Default values , constructors

        public ListingFromDesignBase()
        {
            this.ShowMessageBox += new showMessageBox(EntryFromDesignBase_ShowMessageBox);
            this.MouseDoubleClick += Form1_MouseDoubleClick;
            this.MouseMove += Form1_MouseMove;
            tom = new SMcMaster.TabOrderManager(this);
            SetDefaultValues();//DhirajFx
        }

        private void EntryFromDesignBase_ShowMessageBox(Friuts.FormBase.MessageArgs msg)
        {
            msg.dialogResult = MessageBoxMy.Show(msg.Message, msg.msgbuttons);
        }

        private void SetDefaultValues()
        {
            InitializeButtons();
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            Font = MainFont;
            ShowIcon = false;
            ForeColor = Color.Black;
            ShowInTaskbar = false;
            // TabAccrossFirst ();
            EnableDoubleBuffering();
        }

        private void InitializeButtons()
        {
            //
            // _closeButton
            //
            this._closeButton.BackColor = System.Drawing.Color.Transparent;
            this._closeButton.ButtonImage = global::Bsoft.Design.Properties.Resources.closeButton;
            this._closeButton.ButtonDisabledImage = null;
            this._closeButton.ButtonHoverImage = global::Bsoft.Design.Properties.Resources.closeButtonHover;
            this._closeButton.ButtonPressedImage = global::Bsoft.Design.Properties.Resources.closeButtonPressed;
            this._closeButton.DisableForeColor = System.Drawing.Color.DimGray;

            this._closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._closeButton.HeightEllipse = 0;
            //this._closeButton.Location = new System.Drawing.Point(263, 4);
            // this._closeButton.Size = _closeButton.BackgroundImage.Size;
            this._closeButton.Size = new System.Drawing.Size(32, 32);
            this._closeButton.Location = new Point(this.Width - _closeButton.Width, 0);
            this._closeButton.Margin = new System.Windows.Forms.Padding(0);
            this._closeButton.Name = "_closeButton";

            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.WidthEllipse = 0;
            this._closeButton.Click += new EventHandler(closeButton_Click);
            this.Controls.Add(_closeButton);
            this.CancelButton = _closeButton;
            this._closeButton.TabStop = false;
        }

        #endregion Set Default values , constructors

        #region Properties

        public HorizontalAlignment TitleFontAlignment
        {
            get { return _titleFontAlignment; }
            set
            {
                _titleFontAlignment = value;
                DrawFormBackGround();
            }
        }

        #endregion Properties

        #region Tab and focus color events

        //To manage tab order
        private SMcMaster.TabOrderManager tom;

        public void AddEvents(Control container)
        {//By Dhiraj For tab control focus
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Panel || ctrl is FlowLayoutPanel || ctrl is GroupBox || ctrl is TabControl || ctrl is TableLayoutPanel || ctrl is SplitContainer || ctrl is UserControl)
                {
                    AddEvents(ctrl);
                }
                else if (ctrl is bsoftcontrols.fsButton)
                {
                    ((bsoftcontrols.fsButton)ctrl).ThemeColor = _OriginalButtonTheme;
                    ctrl.Enter += tb_Enter;
                    ctrl.Leave += tb_Leave;
                }
                else if (ctrl is TextBox || ctrl is VtextBox || ctrl is RadioButton || ctrl is CheckBox || ctrl is DateTimePicker || ctrl is mydatePicker)
                {
                    ctrl.Enter += tb_Enter;
                    ctrl.Leave += tb_Leave;
                }

                //For language
                if (ctrl is TextBox || ctrl is VtextBox)
                {
                    if (!((TextBox)ctrl).ReadOnly)
                    {
                        if (ctrl.Font.Name.Contains("Mangal") || ctrl.Font.Name.Contains("Kanjirowa"))
                        {
                            Bsoft.Common.Language.LanguageUtility.SetNep(ctrl);
                        }
                        else
                        {
                            Bsoft.Common.Language.LanguageUtility.SetEng(ctrl);
                        }
                    }
                }
                if (ctrl is mydatePicker)
                {
                    if (ctrl.Font.Name.Contains("Mangal") || ctrl.Font.Name.Contains("Kanjirowa"))
                    {
                        Bsoft.Common.Language.LanguageUtility.SetNep(ctrl);
                    }
                    else
                    {
                        Bsoft.Common.Language.LanguageUtility.SetEng(ctrl);
                    }
                }
            }
        }

        public void tb_Enter(object sender, EventArgs e)
        {
            if (sender is bsoftcontrols.fsButton)
            {
                bsoftcontrols.fsButton btn = (bsoftcontrols.fsButton)sender;
                btn.ThemeColor = _FocusButoonTheme;
            }
            else
            {
                Control ctr = (Control)sender;
                // _Original = ctr.BackColor;
                ctr.BackColor = _Focuscolor;
            }
            base.OnGotFocus(e);
        }

        public void tb_Leave(object sender, EventArgs e)
        {
            if (sender is bsoftcontrols.fsButton)
            {
                bsoftcontrols.fsButton btn = (bsoftcontrols.fsButton)sender;
                btn.ThemeColor = _OriginalButtonTheme;
            }
            else
            {
                Control ctr = (Control)sender;
                try
                {
                    ctr.BackColor = _Original;
                }
                catch { ctr.BackColor = Color.White; }
            }
            base.OnLostFocus(e);
        }

        public void TabAccrossFirst()
        {
            tom.SetTabOrder(SMcMaster.TabOrderManager.TabScheme.AcrossFirst);
        }

        public void TabDownFirst()
        {
            tom.SetTabOrder(SMcMaster.TabOrderManager.TabScheme.DownFirst);
        }

        #endregion Tab and focus color events

        #region Events Handlers

        //protected override void OnMove(EventArgs e)
        //{
        //    base.OnMove(e);

        //    Invalidate();
        //}

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion Events Handlers

        #region BackGroundDesgin Section

        protected override void OnLoad(EventArgs e)
        {
            //_isFormLoaded = true;

            //DrawFormBackGround();
            //AddEvents((Control)this);
            //base.OnLoad(e);
            // _isFormLoaded = false;
            //this.BackgroundImage = Properties.Resources.body;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            AddEvents((Control)this);
            //  DrawFormBackGround();
            base.OnLoad(e);
            //SetDefaultValues();//DhirajFx
            _isFormLoaded = true;
            DrawFormBackGround();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //Graphics g = e.Graphics;

            //   DrawFormBackGround(e.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //  set the close button location.
            // SetButtonsLocation();
            DrawFormBackGround();
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    if (DesignMode)
        //    {
        //        if (!_isPerformingPaint)
        //        {
        //            _isPerformingPaint = true;
        //            try
        //            {
        //                DrawFormBackGround();
        //                //DrawFormBackGroundPaint();
        //            }
        //            catch
        //            {
        //                _isPerformingPaint = false;
        //            }
        //            finally
        //            {
        //                _isPerformingPaint = false;
        //            }
        //        }
        //    }
        //}

        private void DrawFormBackGround()
        {
            //DhirajFx
            //don't draw the Form background until the form is loaded successfully
            if (!_isFormLoaded)
                return;
            if (DesignMode)
            {
                // BackColor = Color.FromArgb(128, 255, 255);
                BackColor = Color.SkyBlue;
                //     GetBackGroundImage2(Properties.Resources.body, Size);
            }
            else
            {
                GetBackGroundImage();
            }
            _closeButton.Location = new Point(this.Width - _closeButton.Width - 2, 2);
        }

        private void GetBackGroundImage()
        {
            TopPix = topBar.Height;
            //resize image
            string tmp = Text.Length == 0 ? "T" : Text;
            Bitmap bmp = new Bitmap(Size.Width, Size.Height);
            //Bitmap bmp = new Bitmap(image, Size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                //get the max of text height and title height
                _titleBarSize = g.MeasureString(this.Text, this._titleFont);
                _titleBarSize.Height = _titleBarSize.Height < topBar.Height ? topBar.Height : _titleBarSize.Height;
                //draw all image
                g.DrawImage(bodybmp, new Rectangle(new Point(0, 0), Size));
                g.DrawImage(topBar, 0, 0, Size.Width, _titleBarSize.Height);
                g.DrawImage(bottomBar, 0, Size.Height - bottomBar.Height, Size.Width, bottomBar.Height);
                g.DrawImage(rightBar, Size.Width - rightBar.Width, 0, rightBar.Width, Size.Height);
                g.DrawImage(leftBar, 0, 0, leftBar.Width, Size.Height);
                DrawTitleBar(g);
            }

            BackgroundImage = bmp;
        }

        //keep code for regerence
        //private void DrawFormBackGroundPaint(Graphics g)
        //{
        //    g.DrawImage(topBar, 0, 0, Size.Width, _titleBarSize.Height + 3);
        //    g.DrawImage(rightBar, Size.Width - rightBar.Width, _titleBarSize.Height, rightBar.Width, Size.Height - _titleBarSize.Height);
        //    g.DrawImage(bottomBar, 0, Size.Height - bottomBar.Height, Size.Width, bottomBar.Height);
        //    g.DrawImage(leftBar, 0, _titleBarSize.Height, leftBar.Width, Size.Height - _titleBarSize.Height);
        //}

        //private void DrawFormBackGround2(Graphics g)
        //{
        //    #region DrawBackGround Image of Form
        //      g.DrawImage(bmp, new Rectangle(new Point(0, 0), this.Size));
        //    #endregion
        //}

        #endregion BackGroundDesgin Section

        #region Functions

        private void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();
        }

        private void DrawTitleBar(Graphics g)
        {
            if (!this.Text.Length.Equals(0))
            {
                //titleBarSize = e.Graphics.MeasureString(this.Text, this._titleFont);
                using (StringFormat sf = new StringFormat())
                {
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    sf.LineAlignment = StringAlignment.Center;

                    switch (TitleFontAlignment)
                    {
                        case HorizontalAlignment.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;

                        case HorizontalAlignment.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;

                        case HorizontalAlignment.Right:
                            sf.Alignment = StringAlignment.Far;
                            //sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                            break;
                    }
                    base.Padding = Padding;
                    Rectangle textRect = new Rectangle(Icon.Size.Width, 2, Size.Width - 30, Convert.ToInt32(Math.Truncate(_titleBarSize.Height)));
                    //base.TextAlign = TextAlign;
                    //e.Graphics.DrawString(this.Text, this._titleFont, new SolidBrush(this._titleForeColor),
                    //((this.ClientSize.Width - titleBarSize.Width) / 2), ((this.ClientSize.Height - titleBarSize.Height) / 2));
                    g.DrawString(this.Text, this._titleFont, new SolidBrush(this._titleForeColor),
                        textRect, sf);
                }
            }
        }

        #endregion Functions

        #region listing specific

        private DataGridViewCellStyle dataGridRowStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridColumnHeaderCellStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridCellStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewRowHeaderCellStyle = new DataGridViewCellStyle();

        public override DataGridView ListingDataGridView
        {
            get { return _dataGridView; }
            set
            {
                _dataGridView = value;

                SetDataGridViewProperties();

                AttachDataGridViewEvents();
                AttachDataGridViewEventsForContextMenu();
            }
        }

        public virtual void SetDataGridViewProperties()
        {
            SetDataGridViewProperties(_dataGridView);
        }

        public virtual void SetDataGridViewProperties(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.RowHeadersWidth = 54;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.MultiSelect = false;
            dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));
            //dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Removed EditProgrammatically since this will render multi select unusable
            if (FormType != FormTypes.MultipleSelect)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

            //dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;makes slow
            dataGridView.StandardTab = true; //required...
            ////Column Header Style
            dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridColumnHeaderCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridColumnHeaderCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(65)))), ((int)(((byte)(109)))));
            dataGridColumnHeaderCellStyle.Font = dataGridView.ColumnHeadersDefaultCellStyle.Font;
            dataGridColumnHeaderCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridColumnHeaderCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridColumnHeaderCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridColumnHeaderCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridColumnHeaderCellStyle;

            ////Cell Style
            dataGridCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));
            dataGridCellStyle.Font = dataGridView.DefaultCellStyle.Font;
            dataGridCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridCellStyle.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridCellStyle.NullValue = string.Empty;
            dataGridView.DefaultCellStyle = dataGridCellStyle;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridRowStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            //dataGridRowStyle.BackColor = System.Drawing.Color.LightGray;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridRowStyle;

            //Row Header Style
            dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewRowHeaderCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewRowHeaderCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(65)))), ((int)(((byte)(109)))));
            //dataGridViewRowHeaderCellStyle.Font = dataGridView.RowHeadersDefaultCellStyle.Font;
            //dataGridViewRowHeaderCellStyle.Font = new System.Drawing.Font("Shangrila Numeric", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dataGridViewRowHeaderCellStyle.Font = Bsoft.Design.FormDesginBase.DigitFont;
            dataGridViewRowHeaderCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewRowHeaderCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewRowHeaderCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewRowHeaderCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewRowHeaderCellStyle;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private ContextMenuStrip menuColumnHeader;

        private void AttachDataGridViewEventsForContextMenu()
        {
            //added by Dhiraj
            menuColumnHeader = new ContextMenuStrip();
            menuColumnHeader.ItemClicked += MenuItemClicked;
            setMenuforColumns(_dataGridView);
        }

        #region "For context menu on grid -By Dhiraj"

        private void MenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;

            if (menuItem == null)
                return;

            switch (menuItem.Text)
            {
                //case EXPORT_TO_EXCEL:
                //    ToExcel();
                //    break;

                //case EXPORT_TO_CSV:
                //    ToCsv();
                //    break;

                //case SEARCH:
                //    ShowSearch();
                //    break;

                default:
                    if (!menuItem.Checked || _dataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible) > 1)
                    {
                        DataGridViewColumn column = (DataGridViewColumn)menuItem.Tag;
                        column.Visible = !menuItem.Checked;
                        menuItem.Checked = column.Visible;
                    }
                    break;
            }
        }

        #endregion "For context menu on grid -By Dhiraj"

        private void setMenuforColumns(DataGridView dataGridView1)
        {
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                if (dc.Visible)
                {
                    dc.HeaderCell.ContextMenuStrip = menuColumnHeader;
                    // menuColumnHeader.Items.Clear();
                    // menuColumnHeader.Items.Add(new ToolStripSeparator());
                }
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem(GetColumnText(column));
                    if (ModifierKeys == Keys.Shift)
                        newItem.Text += string.Format(" - ({0} px)", column.Width);
                    newItem.Checked = column.Visible;
                    newItem.Visible = newItem.Text != "";
                    newItem.Tag = column;
                    menuColumnHeader.Items.Add(newItem);
                }
            }
        }

        private string GetColumnText(DataGridViewColumn column)
        {
            if (column.HeaderText == "" && column is DataGridViewButtonColumn)
                return ((DataGridViewButtonColumn)column).Text;

            return column.HeaderText;
        }

        #endregion listing specific
    }
}