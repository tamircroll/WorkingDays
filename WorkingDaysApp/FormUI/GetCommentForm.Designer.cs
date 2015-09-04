namespace WorkingDaysApp.FormUI
{
    partial class GetCommentForm
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
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.commentText = new System.Windows.Forms.TextBox();
            this.commentHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Cancel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(258, 101);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(141, 49);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.OK.Location = new System.Drawing.Point(44, 101);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(141, 49);
            this.OK.TabIndex = 9;
            this.OK.Text = "Accept";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // commentText
            // 
            this.commentText.AcceptsReturn = true;
            this.commentText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.commentText.Location = new System.Drawing.Point(12, 48);
            this.commentText.Name = "commentText";
            this.commentText.Size = new System.Drawing.Size(428, 27);
            this.commentText.TabIndex = 11;
            // 
            // commentHeader
            // 
            this.commentHeader.AutoSize = true;
            this.commentHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.commentHeader.Location = new System.Drawing.Point(151, 9);
            this.commentHeader.Name = "commentHeader";
            this.commentHeader.Size = new System.Drawing.Size(144, 25);
            this.commentHeader.TabIndex = 12;
            this.commentHeader.Text = "Add Comment:";
            // 
            // GetCommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 192);
            this.Controls.Add(this.commentHeader);
            this.Controls.Add(this.commentText);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "GetCommentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetCommentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox commentText;
        private System.Windows.Forms.Label commentHeader;
    }
}