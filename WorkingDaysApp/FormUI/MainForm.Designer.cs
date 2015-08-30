namespace WorkingDaysApp.FormUI
{
    partial class MainForm
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
            this.DaysListView = new System.Windows.Forms.ListView();
            this.Leaving = new System.Windows.Forms.Button();
            this.Arrival = new System.Windows.Forms.Button();
            this.ListViewTitle = new System.Windows.Forms.Label();
            this.chooseDateGroupBox = new System.Windows.Forms.GroupBox();
            this.chooseYear = new System.Windows.Forms.ComboBox();
            this.chooseYearTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chooseDateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DaysListView
            // 
            this.DaysListView.Location = new System.Drawing.Point(797, 75);
            this.DaysListView.Name = "DaysListView";
            this.DaysListView.Size = new System.Drawing.Size(426, 658);
            this.DaysListView.TabIndex = 2;
            this.DaysListView.UseCompatibleStateImageBehavior = false;
            // 
            // Leaving
            // 
            this.Leaving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Leaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Leaving.Location = new System.Drawing.Point(319, 75);
            this.Leaving.Name = "Leaving";
            this.Leaving.Size = new System.Drawing.Size(251, 85);
            this.Leaving.TabIndex = 1;
            this.Leaving.Text = "Leaving";
            this.Leaving.UseVisualStyleBackColor = false;
            // 
            // Arrival
            // 
            this.Arrival.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Arrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Arrival.Location = new System.Drawing.Point(33, 75);
            this.Arrival.Name = "Arrival";
            this.Arrival.Size = new System.Drawing.Size(251, 85);
            this.Arrival.TabIndex = 0;
            this.Arrival.Text = "Arrival";
            this.Arrival.UseVisualStyleBackColor = false;
            this.Arrival.Click += new System.EventHandler(this.Arrival_Click);
            // 
            // ListViewTitle
            // 
            this.ListViewTitle.AutoSize = true;
            this.ListViewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ListViewTitle.Location = new System.Drawing.Point(792, 29);
            this.ListViewTitle.Name = "ListViewTitle";
            this.ListViewTitle.Size = new System.Drawing.Size(91, 29);
            this.ListViewTitle.TabIndex = 3;
            this.ListViewTitle.Text = "Month: ";
            // 
            // chooseDateGroupBox
            // 
            this.chooseDateGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseDateGroupBox.Controls.Add(this.label2);
            this.chooseDateGroupBox.Controls.Add(this.comboBox1);
            this.chooseDateGroupBox.Controls.Add(this.chooseYearTitle);
            this.chooseDateGroupBox.Controls.Add(this.chooseYear);
            this.chooseDateGroupBox.Location = new System.Drawing.Point(91, 239);
            this.chooseDateGroupBox.Name = "chooseDateGroupBox";
            this.chooseDateGroupBox.Size = new System.Drawing.Size(410, 178);
            this.chooseDateGroupBox.TabIndex = 4;
            this.chooseDateGroupBox.TabStop = false;
            this.chooseDateGroupBox.Text = "Choose date";
            // 
            // chooseYear
            // 
            this.chooseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseYear.FormattingEnabled = true;
            this.chooseYear.Location = new System.Drawing.Point(123, 39);
            this.chooseYear.Name = "chooseYear";
            this.chooseYear.Size = new System.Drawing.Size(267, 33);
            this.chooseYear.TabIndex = 5;
            // 
            // chooseYearTitle
            // 
            this.chooseYearTitle.AutoSize = true;
            this.chooseYearTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseYearTitle.Location = new System.Drawing.Point(16, 39);
            this.chooseYearTitle.Name = "chooseYearTitle";
            this.chooseYearTitle.Size = new System.Drawing.Size(76, 29);
            this.chooseYearTitle.TabIndex = 6;
            this.chooseYearTitle.Text = "Year: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Month: ";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 33);
            this.comboBox1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1251, 745);
            this.Controls.Add(this.chooseDateGroupBox);
            this.Controls.Add(this.ListViewTitle);
            this.Controls.Add(this.Leaving);
            this.Controls.Add(this.Arrival);
            this.Controls.Add(this.DaysListView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.chooseDateGroupBox.ResumeLayout(false);
            this.chooseDateGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DaysListView;
        private System.Windows.Forms.Button Leaving;
        private System.Windows.Forms.Button Arrival;
        private System.Windows.Forms.Label ListViewTitle;
        private System.Windows.Forms.GroupBox chooseDateGroupBox;
        private System.Windows.Forms.ComboBox chooseYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseYearTitle;

    }
}