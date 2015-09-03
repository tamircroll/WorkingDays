namespace WorkingDaysApp.FormUI
{
    partial class GetDayTypeWindowForm
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
            this.DayTypeBox = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DayTypeBox
            // 
            this.DayTypeBox.BackColor = System.Drawing.SystemColors.Window;
            this.DayTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DayTypeBox.FormattingEnabled = true;
            this.DayTypeBox.Location = new System.Drawing.Point(141, 80);
            this.DayTypeBox.Name = "DayTypeBox";
            this.DayTypeBox.Size = new System.Drawing.Size(122, 33);
            this.DayTypeBox.TabIndex = 8;
            // 
            // Cancel
            // 
            this.Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Cancel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(237, 185);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(141, 49);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.OK.Location = new System.Drawing.Point(28, 185);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(141, 49);
            this.OK.TabIndex = 5;
            this.OK.Text = "Accept";
            this.OK.UseVisualStyleBackColor = false;
            // 
            // GetDayTypeWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 297);
            this.Controls.Add(this.DayTypeBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "GetDayTypeWindowForm";
            this.Text = "GetDayTypeWindowForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DayTypeBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
    }
}