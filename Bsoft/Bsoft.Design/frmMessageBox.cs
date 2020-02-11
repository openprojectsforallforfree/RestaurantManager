using Bsoft.Languages;
using System;
using System.Windows.Forms;

namespace Bsoft.Forms
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmMessageBox : Bsoft.Design.EntryFromDesignBase
    {
        private DialogResult btnPressed = DialogResult.None;
        private MessageBoxButtons MsgButtons = MessageBoxButtons.OK;
        private string mMessage = "";

        private delegate void myDelegate();

        public frmMessageBox()
        {
            InitializeComponent();
            Text = Bsoft.Languages.Language.LanguageString.AttentionPlease;
            btnCancel.Text = Language.LanguageString.CancelGoBack;
            btnOk.Text = Language.LanguageString.Ok;
            btnNo.Text = Language.LanguageString.No;
            btnYes.Text = Language.LanguageString.Yes;
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            ChangeFormSize();
        }

        private void ChangeFormSize()
        {
            //form size
            //this.Width = (lblMessage.Left * 2) + lblMessage.Width;
            int textwith = label1.Width + 32;

            if (textwith > this.MinimumSize.Width)
            {
                Width = textwith;
            }
            else
            {
                Width = MinimumSize.Width;
            }

            //  this.Height = lblMessage.Height + (this.MinimumSize.Height - lblMessage.MinimumSize.Height);
            flowLayoutPanel1.Left = (this.Width - flowLayoutPanel1.Width) / 2;
            //button location

            //this.BackgroundImageLayout = ImageLayout.Tile;
            //this.BackgroundImage = Utility.ChangeImageSize(Properties.Resources.MessageBoxScreen, this.Size);
            //close button location
            //btnClose.Left = lblMessage.Left + lblMessage.Width;
            //btnClose.Left = this.Width - (btnClose.Width * 3);
        }

        #region Dialogresults

        public string Title { get { return this.Text; } set { this.Text = value; } }

        public DialogResult Show(string Message, string Title, Form OwnerForm, MessageBoxButtons MsgButtons)
        {
            this.Title = Title;
            this.Owner = OwnerForm;
            return Show(Message, MsgButtons);
        }

        public DialogResult Show(string Message, string Title, MessageBoxButtons MsgButtons)
        {
            this.Title = Title;
            return Show(Message, MsgButtons);
        }

        /// <summary>
        /// Displays the Message Box and sets the owner form too.
        /// </summary>
        /// <param name="pMessage">The message to be displayed</param>
        /// <param name="pMsgButtons">The Buttons to be displayed</param>
        /// <returns>Returns the Dialog Result </returns>
        public DialogResult Show(Form OwnerForm, string Message, MessageBoxButtons MsgButtons)
        {
            try
            {
                this.Owner = OwnerForm;
            }
            catch { }
            return Show(Message, MsgButtons);
        }

        /// <summary>
        /// Displays the Message Box
        /// </summary>
        /// <param name="pMessage">The message to be displayed</param>
        /// <param name="pMsgButtons">The Buttons to be displayed</param>
        /// <returns>Returns the Dialog Result </returns>
        public DialogResult Show(string pMessage, MessageBoxButtons pMsgButtons)
        {
            MsgButtons = pMsgButtons;
            mMessage = pMessage;
            //this.Owner = null;
            try
            {
                if (lblMessage.InvokeRequired)
                    lblMessage.BeginInvoke(new myDelegate(ThreadProcShowDialogBox));
                else
                    ThreadProcShowDialogBox();
            }
            catch
            {
                //ThreadProcShowDialogBox();
            }

            return btnPressed;
        }

        private void ThreadProcShowDialogBox()
        {
            lblMessage.Text = mMessage;

            label1.Text = mMessage;

            btnOk.Visible = btnCancel.Visible = btnNo.Visible = btnYes.Visible = false;
            switch (MsgButtons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    break;

                case MessageBoxButtons.OK:
                    btnOk.Visible = true;
                    btnOk.Select();
                    btnOk.Focus();
                    flowLayoutPanel1.Width = btnOk.Width + btnOk.Margin.All * 2;
                    break;

                case MessageBoxButtons.OKCancel:
                    btnOk.Visible = true;
                    btnCancel.Visible = true;
                    btnOk.Select();
                    btnOk.Focus();
                    flowLayoutPanel1.Width = btnOk.Width + btnOk.Margin.All * 4 + btnCancel.Width;
                    break;

                case MessageBoxButtons.RetryCancel:
                    break;

                case MessageBoxButtons.YesNo:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnYes.Select();
                    btnYes.Focus();
                    flowLayoutPanel1.Width = btnYes.Width + btnYes.Margin.All * 4 + btnNo.Width;

                    break;

                case MessageBoxButtons.YesNoCancel:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnCancel.Visible = true;
                    btnYes.Select();
                    btnYes.Focus();
                    flowLayoutPanel1.Width = btnYes.Width + btnYes.Margin.All * 6 + btnNo.Width + btnCancel.Width;
                    break;

                default:
                    break;
            }
            ChangeFormSize();

            this.ShowDialog();
        }

        #endregion Dialogresults

        #region buttonclicks

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReturnResult(DialogResult.OK);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ReturnResult(DialogResult.No);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ReturnResult(DialogResult.Yes);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ReturnResult(DialogResult.Ignore);
        }

        private void ReturnResult(DialogResult pResult)
        {
            btnPressed = pResult;
            this.Close();
        }

        #endregion buttonclicks

        //private void frmMessageBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 1)
        //    {
        //        MessageBox.Show(this.Name + ": Control Name : " + this.ActiveControl.Name, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }

    public static class MessageBoxMy
    {
        #region Member variables.

        private static frmMessageBox msgBox = new frmMessageBox();

        #endregion Member variables.

        #region Constructors & Finalizers.

        #endregion Constructors & Finalizers.

        #region Nested Enums, Structs, and Classes.

        #endregion Nested Enums, Structs, and Classes.

        #region Properties

        #endregion Properties

        #region Methods

        public static DialogResult Show(Form owner, string message, MessageBoxButtons msgButtons)
        {
            return msgBox.Show(owner, message, msgButtons);
        }

        public static DialogResult Show(string message, MessageBoxButtons msgButtons)
        {
            return msgBox.Show(message, msgButtons);
        }

        public static DialogResult Show(string message)
        {
            return msgBox.Show(message, MessageBoxButtons.OK);
        }

        public static DialogResult Show(Form owner, string message, string title, MessageBoxButtons msgButtons)
        {
            return msgBox.Show(message, title, owner, msgButtons);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons msgButtons)
        {
            return msgBox.Show(message, title, msgButtons);
        }

        public static DialogResult Show(string message, string title)
        {
            return msgBox.Show(message, title, MessageBoxButtons.OK);
        }

        public static DialogResult ShowMessage(string message)
        {
            return Show(message, "Message");
        }

        public static DialogResult ShowAlert(string message)
        {
            return Show(message, "Alert");
        }

        public static DialogResult ShowError(string message)
        {
            return Show(message, "Error");
        }

        #endregion Methods
    }
}