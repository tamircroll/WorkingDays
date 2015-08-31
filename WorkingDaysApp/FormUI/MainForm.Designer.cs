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
            this.listViewTitle = new System.Windows.Forms.Label();
            this.chooseDateGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseMonth = new System.Windows.Forms.ComboBox();
            this.chooseYearTitle = new System.Windows.Forms.Label();
            this.chooseYear = new System.Windows.Forms.ComboBox();
            this.monthGridView = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dayType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chooseDateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthGridView)).BeginInit();
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
            // listViewTitle
            // 
            this.listViewTitle.AutoSize = true;
            this.listViewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listViewTitle.Location = new System.Drawing.Point(606, 29);
            this.listViewTitle.Name = "listViewTitle";
            this.listViewTitle.Size = new System.Drawing.Size(91, 29);
            this.listViewTitle.TabIndex = 3;
            this.listViewTitle.Text = "Month: ";
            // 
            // chooseDateGroupBox
            // 
            this.chooseDateGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chooseDateGroupBox.Controls.Add(this.label2);
            this.chooseDateGroupBox.Controls.Add(this.chooseMonth);
            this.chooseDateGroupBox.Controls.Add(this.chooseYearTitle);
            this.chooseDateGroupBox.Controls.Add(this.chooseYear);
            this.chooseDateGroupBox.Location = new System.Drawing.Point(91, 215);
            this.chooseDateGroupBox.Name = "chooseDateGroupBox";
            this.chooseDateGroupBox.Size = new System.Drawing.Size(410, 173);
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
            // chooseMonth
            // 
            this.chooseMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseMonth.FormattingEnabled = true;
            this.chooseMonth.Location = new System.Drawing.Point(123, 104);
            this.chooseMonth.Name = "chooseMonth";
            this.chooseMonth.Size = new System.Drawing.Size(267, 33);
            this.chooseMonth.TabIndex = 7;
            this.chooseMonth.DropDown += new System.EventHandler(this.chooseMonth_DropDown);
            this.chooseMonth.SelectedIndexChanged += new System.EventHandler(this.chooseMonth_SelectedIndexChanged);
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
            this.chooseYear.DropDown += new System.EventHandler(this.chooseYear_DropDown);
            this.chooseYear.SelectedIndexChanged += new System.EventHandler(this.chooseYear_SelectedIndexChanged);
            // 
            // monthGridView
            // 
            this.monthGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.monthGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.monthGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayType,
            this.Day,
            this.StartTime,
            this.EndTime,
            this.TotalTime,
            this.Comment});
            this.monthGridView.EnableHeadersVisualStyles = false;
            this.monthGridView.GridColor = System.Drawing.Color.DimGray;
            this.monthGridView.Location = new System.Drawing.Point(611, 75);
            this.monthGridView.Name = "monthGridView";
            this.monthGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.monthGridView.Size = new System.Drawing.Size(859, 542);
            this.monthGridView.TabIndex = 5;
            this.monthGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.daysGridView_CellContentClick);
            // 
            // dayType
            // 
            this.dayType.HeaderText = "dayType";
            this.dayType.Items.AddRange(new object[] {
            "Work Day",
            "holiday"});
            this.dayType.MinimumWidth = 110;
            this.dayType.Name = "dayType";
            // 
            // Day
            // 
            this.Day.FillWeight = 141.1765F;
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.MinimumWidth = 80;
            this.StartTime.Name = "StartTime";
            this.StartTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.MinimumWidth = 80;
            this.EndTime.Name = "EndTime";
            this.EndTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TotalTime
            // 
            this.TotalTime.HeaderText = "Total Time";
            this.TotalTime.Name = "TotalTime";
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.FillWeight = 58.82353F;
            this.Comment.HeaderText = "Comment";
            this.Comment.MinimumWidth = 250;
            this.Comment.Name = "Comment";
            this.Comment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1482, 723);
            this.Controls.Add(this.monthGridView);
            this.Controls.Add(this.chooseDateGroupBox);
            this.Controls.Add(this.listViewTitle);
            this.Controls.Add(this.Leaving);
            this.Controls.Add(this.Arrival);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.chooseDateGroupBox.ResumeLayout(false);
            this.chooseDateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Leaving;
        private System.Windows.Forms.Button Arrival;
        private System.Windows.Forms.Label listViewTitle;
        private System.Windows.Forms.GroupBox chooseDateGroupBox;
        private System.Windows.Forms.ComboBox chooseYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chooseMonth;
        private System.Windows.Forms.Label chooseYearTitle;
        private System.Windows.Forms.DataGridView monthGridView;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dayType;
        private System.Windows.Forms.DataGridViewButtonColumn Day;
        private System.Windows.Forms.DataGridViewButtonColumn StartTime;
        private System.Windows.Forms.DataGridViewButtonColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTime;
        private System.Windows.Forms.DataGridViewButtonColumn Comment;

    }
}