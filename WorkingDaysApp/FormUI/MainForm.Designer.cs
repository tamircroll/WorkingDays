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
            this.components = new System.ComponentModel.Container();
            this.Leaving = new System.Windows.Forms.Button();
            this.Arrival = new System.Windows.Forms.Button();
            this.ListViewTitle = new System.Windows.Forms.Label();
            this.chooseDateGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chooseYearTitle = new System.Windows.Forms.Label();
            this.chooseYear = new System.Windows.Forms.ComboBox();
            this.daysGridView = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Hours = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Comment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ShowMonthButton = new System.Windows.Forms.Button();
            this.chooseDateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Leaving
            // 
            this.Leaving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Leaving.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.Arrival.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Arrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Arrival.Location = new System.Drawing.Point(33, 75);
            this.Arrival.Name = "Arrival";
            this.Arrival.Size = new System.Drawing.Size(251, 85);
            this.Arrival.TabIndex = 0;
            this.Arrival.Text = "Arrival";
            this.toolTip1.SetToolTip(this.Arrival, "Press this button to add this set now as today start time");
            this.Arrival.UseVisualStyleBackColor = false;
            this.Arrival.Click += new System.EventHandler(this.Arrival_Click);
            // 
            // ListViewTitle
            // 
            this.ListViewTitle.AutoSize = true;
            this.ListViewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ListViewTitle.Location = new System.Drawing.Point(720, 33);
            this.ListViewTitle.Name = "ListViewTitle";
            this.ListViewTitle.Size = new System.Drawing.Size(91, 29);
            this.ListViewTitle.TabIndex = 3;
            this.ListViewTitle.Text = "Month: ";
            // 
            // chooseDateGroupBox
            // 
            this.chooseDateGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseDateGroupBox.Controls.Add(this.ShowMonthButton);
            this.chooseDateGroupBox.Controls.Add(this.label2);
            this.chooseDateGroupBox.Controls.Add(this.comboBox1);
            this.chooseDateGroupBox.Controls.Add(this.chooseYearTitle);
            this.chooseDateGroupBox.Controls.Add(this.chooseYear);
            this.chooseDateGroupBox.Location = new System.Drawing.Point(91, 215);
            this.chooseDateGroupBox.Name = "chooseDateGroupBox";
            this.chooseDateGroupBox.Size = new System.Drawing.Size(410, 259);
            this.chooseDateGroupBox.TabIndex = 4;
            this.chooseDateGroupBox.TabStop = false;
            this.chooseDateGroupBox.Text = "Choose date";
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
            // chooseYear
            // 
            this.chooseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseYear.FormattingEnabled = true;
            this.chooseYear.Location = new System.Drawing.Point(123, 39);
            this.chooseYear.Name = "chooseYear";
            this.chooseYear.Size = new System.Drawing.Size(267, 33);
            this.chooseYear.TabIndex = 5;
            this.chooseYear.Text = "2015";
            this.chooseYear.SelectedIndexChanged += new System.EventHandler(this.chooseYear_SelectedIndexChanged);
            this.chooseYear.DropDown += new System.EventHandler(this.chooseYear_DropDown);
            // 
            // daysGridView
            // 
            this.daysGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.daysGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.daysGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Hours,
            this.Comment});
            this.daysGridView.EnableHeadersVisualStyles = false;
            this.daysGridView.GridColor = System.Drawing.Color.DimGray;
            this.daysGridView.Location = new System.Drawing.Point(675, 75);
            this.daysGridView.Name = "daysGridView";
            this.daysGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.daysGridView.Size = new System.Drawing.Size(545, 633);
            this.daysGridView.TabIndex = 5;
            this.daysGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.daysGridView_CellContentClick);
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Day.Width = 150;
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            this.Hours.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Hours.Width = 150;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Comment.Width = 200;
            // 
            // ShowMonthButton
            // 
            this.ShowMonthButton.BackColor = System.Drawing.Color.Bisque;
            this.ShowMonthButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowMonthButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ShowMonthButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ShowMonthButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ShowMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ShowMonthButton.Location = new System.Drawing.Point(21, 172);
            this.ShowMonthButton.Name = "ShowMonthButton";
            this.ShowMonthButton.Size = new System.Drawing.Size(369, 57);
            this.ShowMonthButton.TabIndex = 9;
            this.ShowMonthButton.Text = "Show";
            this.ShowMonthButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1251, 745);
            this.Controls.Add(this.daysGridView);
            this.Controls.Add(this.chooseDateGroupBox);
            this.Controls.Add(this.ListViewTitle);
            this.Controls.Add(this.Leaving);
            this.Controls.Add(this.Arrival);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.chooseDateGroupBox.ResumeLayout(false);
            this.chooseDateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Leaving;
        private System.Windows.Forms.Button Arrival;
        private System.Windows.Forms.Label ListViewTitle;
        private System.Windows.Forms.GroupBox chooseDateGroupBox;
        private System.Windows.Forms.ComboBox chooseYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseYearTitle;
        private System.Windows.Forms.DataGridView daysGridView;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewButtonColumn Day;
        private System.Windows.Forms.DataGridViewButtonColumn Hours;
        private System.Windows.Forms.DataGridViewButtonColumn Comment;
        private System.Windows.Forms.Button ShowMonthButton;

    }
}