namespace RestoSys.Reports.Hotel
{
    partial class Hotel_Invoice_holder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // myWebBrowser
            // 
            this.myWebBrowser.Location = new System.Drawing.Point(32, 12);
            this.myWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.myWebBrowser.Name = "myWebBrowser";
            this.myWebBrowser.Size = new System.Drawing.Size(185, 154);
            this.myWebBrowser.TabIndex = 1;
            // 
            // Hotel_Invoice_holder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 0);
            this.ControlBox = false;
            this.Controls.Add(this.myWebBrowser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hotel_Invoice_holder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hotel_Invoice_holder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser myWebBrowser;
    }
}