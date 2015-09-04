using System;
using System.Drawing;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Leaving = new System.Windows.Forms.Button();
            this.Arrival = new System.Windows.Forms.Button();
            this.listViewTitle = new System.Windows.Forms.Label();
            this.chooseDateGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseMonth = new System.Windows.Forms.ComboBox();
            this.chooseYearTitle = new System.Windows.Forms.Label();
            this.chooseYear = new System.Windows.Forms.ComboBox();
            this.monthGridView = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekDayCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Comment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SummaryTitle = new System.Windows.Forms.Label();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.chooseDateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Leaving
            // 
            this.Leaving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Leaving.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Leaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Leaving.Location = new System.Drawing.Point(359, 123);
            this.Leaving.Name = "Leaving";
            this.Leaving.Size = new System.Drawing.Size(251, 85);
            this.Leaving.TabIndex = 1;
            this.Leaving.Text = "Leaving";
            this.Leaving.UseVisualStyleBackColor = false;
            this.Leaving.Click += new System.EventHandler(this.Leaving_Click);
            // 
            // Arrival
            // 
            this.Arrival.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Arrival.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Arrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Arrival.Location = new System.Drawing.Point(40, 123);
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
            this.listViewTitle.Location = new System.Drawing.Point(806, 77);
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
            this.chooseDateGroupBox.Location = new System.Drawing.Point(131, 268);
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
            this.chooseYear.DropDown += new System.EventHandler(this.chooseYear_DropDown);
            this.chooseYear.SelectedIndexChanged += new System.EventHandler(this.chooseYear_SelectedIndexChanged);
            // 
            // monthGridView
            // 
            this.monthGridView.AllowUserToAddRows = false;
            this.monthGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.monthGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.monthGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.monthGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.weekDayCol,
            this.StartTime,
            this.EndTime,
            this.TotalTime,
            this.dayType,
            this.Comment});
            this.monthGridView.EnableHeadersVisualStyles = false;
            this.monthGridView.GridColor = System.Drawing.Color.DimGray;
            this.monthGridView.Location = new System.Drawing.Point(811, 123);
            this.monthGridView.Name = "monthGridView";
            this.monthGridView.RowHeadersVisible = false;
            this.monthGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.monthGridView.Size = new System.Drawing.Size(936, 612);
            this.monthGridView.TabIndex = 5;
            this.monthGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.daysGridView_CellContentClick);
            // 
            // Day
            // 
            this.Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Day.FillWeight = 2F;
            this.Day.Frozen = true;
            this.Day.HeaderText = "Day";
            this.Day.MinimumWidth = 40;
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            this.Day.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Day.ToolTipText = "Day in month";
            this.Day.Width = 40;
            // 
            // weekDayCol
            // 
            this.weekDayCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.weekDayCol.FillWeight = 2F;
            this.weekDayCol.Frozen = true;
            this.weekDayCol.HeaderText = "Week Day";
            this.weekDayCol.MinimumWidth = 80;
            this.weekDayCol.Name = "weekDayCol";
            this.weekDayCol.ReadOnly = true;
            this.weekDayCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.weekDayCol.ToolTipText = "Week Day";
            this.weekDayCol.Width = 80;
            // 
            // StartTime
            // 
            this.StartTime.FillWeight = 2F;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.MinimumWidth = 80;
            this.StartTime.Name = "StartTime";
            this.StartTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // EndTime
            // 
            this.EndTime.FillWeight = 2F;
            this.EndTime.HeaderText = "End Time";
            this.EndTime.MinimumWidth = 80;
            this.EndTime.Name = "EndTime";
            this.EndTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TotalTime
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalTime.FillWeight = 2F;
            this.TotalTime.HeaderText = "Total Time";
            this.TotalTime.MinimumWidth = 80;
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.ReadOnly = true;
            this.TotalTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dayType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dayType.DefaultCellStyle = dataGridViewCellStyle2;
            this.dayType.FillWeight = 1F;
            this.dayType.HeaderText = "dayType";
            this.dayType.MinimumWidth = 80;
            this.dayType.Name = "dayType";
            this.dayType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dayType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Comment.DefaultCellStyle = dataGridViewCellStyle3;
            this.Comment.FillWeight = 10F;
            this.Comment.HeaderText = "Comment";
            this.Comment.MinimumWidth = 300;
            this.Comment.Name = "Comment";
            this.Comment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SummaryTitle
            // 
            this.SummaryTitle.AutoSize = true;
            this.SummaryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SummaryTitle.Location = new System.Drawing.Point(806, 762);
            this.SummaryTitle.Name = "SummaryTitle";
            this.SummaryTitle.Size = new System.Drawing.Size(114, 29);
            this.SummaryTitle.TabIndex = 7;
            this.SummaryTitle.Text = "Summary";
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SummaryLabel.Location = new System.Drawing.Point(806, 810);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(0, 29);
            this.SummaryLabel.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1846, 935);
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.SummaryTitle);
            this.Controls.Add(this.monthGridView);
            this.Controls.Add(this.chooseDateGroupBox);
            this.Controls.Add(this.listViewTitle);
            this.Controls.Add(this.Leaving);
            this.Controls.Add(this.Arrival);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetCommentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label SummaryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekDayCol;
        private System.Windows.Forms.DataGridViewButtonColumn StartTime;
        private System.Windows.Forms.DataGridViewButtonColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTime;
        private System.Windows.Forms.DataGridViewButtonColumn dayType;
        private System.Windows.Forms.DataGridViewButtonColumn Comment;
        private System.Windows.Forms.Label SummaryLabel;

    }
}