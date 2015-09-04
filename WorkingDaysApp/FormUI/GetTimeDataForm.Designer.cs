namespace TimeWatchApp.FormUI
{
    partial class GetTimeDataForm
    {
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
        protected void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.HoursBox = new System.Windows.Forms.ComboBox();
            this.MinutesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.OK.Location = new System.Drawing.Point(64, 194);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(141, 49);
            this.OK.TabIndex = 0;
            this.OK.Text = "Accept";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Cancel
            // 
            this.Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Cancel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(273, 194);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(141, 49);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // HoursBox
            // 
            this.HoursBox.BackColor = System.Drawing.SystemColors.Window;
            this.HoursBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HoursBox.FormattingEnabled = true;
            this.HoursBox.Location = new System.Drawing.Point(131, 72);
            this.HoursBox.Name = "HoursBox";
            this.HoursBox.Size = new System.Drawing.Size(96, 33);
            this.HoursBox.TabIndex = 2;
            // 
            // MinutesBox
            // 
            this.MinutesBox.BackColor = System.Drawing.SystemColors.Window;
            this.MinutesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MinutesBox.FormattingEnabled = true;
            this.MinutesBox.Location = new System.Drawing.Point(257, 72);
            this.MinutesBox.Name = "MinutesBox";
            this.MinutesBox.Size = new System.Drawing.Size(96, 33);
            this.MinutesBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(233, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = ":";
            // 
            // GetTimeDataForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(479, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinutesBox);
            this.Controls.Add(this.HoursBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "GetTimeDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Time";
            this.Load += new System.EventHandler(this.getDataBaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox HoursBox;
        private System.Windows.Forms.ComboBox MinutesBox;
        private System.Windows.Forms.Label label1;
    }
}