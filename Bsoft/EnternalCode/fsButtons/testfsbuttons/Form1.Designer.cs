namespace testfsbuttons
{
    partial class Form1
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
            this.fsButton1 = new bsoftcontrols.fsButton();
            this.SuspendLayout();
            // 
            // fsButton1
            // 
            this.fsButton1.ButtonTheme = bsoftcontrols.fsButton.Themes.Office2003;
            this.fsButton1.FlatAppearance.BorderSize = 0;
            this.fsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fsButton1.Location = new System.Drawing.Point(151, 43);
            this.fsButton1.Name = "fsButton1";
            this.fsButton1.Size = new System.Drawing.Size(58, 118);
            this.fsButton1.TabIndex = 0;
            this.fsButton1.Text = "&fsButton1";
            this.fsButton1.UseVisualStyleBackColor = true;
            this.fsButton1.Click += new System.EventHandler(this.fsButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fsButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private bsoftcontrols.fsButton fsButton1;
    }
}

