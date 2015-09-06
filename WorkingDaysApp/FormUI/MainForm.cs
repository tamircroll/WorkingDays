﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using WorkingDaysApp.Logic;

namespace TimeWatchApp.FormUI
{
    public partial class MainForm : Form
    {
        private TimeWatch m_TimeWatch = TimeWatch.Instance;

        public MainForm()
        {
            m_TimeWatch.Changed += refreshView;
            InitializeComponent();
            setTimeToNow();
        }

        private void setTimeToNow()
        {
            setTime(TimeHandler.CurYear(), TimeHandler.CurMonth());
        }

        private void setTime(int i_Year, int i_Month)
        {
            m_TimeWatch.ChosenYearInt = i_Year;
            m_TimeWatch.ChosenMonthInt = i_Month;
        }

        private void refreshView()
        {
            chooseMonth.Text = m_TimeWatch.ChosenMonthInt.ToString();
            chooseYear.Text = m_TimeWatch.ChosenYearInt.ToString();
            setListViewTitle();
            setGrid();
            setSummary();
        }

        private void setSummary()
        {
            SummaryLabelLeft.Text = "";
            SummaryLabelRight.Text = "";
            bool left = true;
            List<string> summaryArr = new List<string>(getSummary());
            foreach (string s in summaryArr)
            {
                if (left) SummaryLabelLeft.Text += s + Environment.NewLine + Environment.NewLine;
                else SummaryLabelRight.Text += s + Environment.NewLine + Environment.NewLine;
                left = !left;
            }
        }

        private void setListViewTitle()
        {
            listViewTitle.Text = string.Format(
                "Year: {0}, Month: {1}",
                m_TimeWatch.ChosenYearInt, TimeHandler.GetMonthName(m_TimeWatch.ChosenMonthInt));
        }

        private void setYearsToggle()
        {
            List<string> years = FilesHandler.GetYears();

            chooseYear.Items.Clear();
            foreach (var hour in years)
            {
                chooseYear.Items.Add(hour);
            }
        }

        private void setMonthToggle()
        {
            chooseMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                chooseMonth.Items.Add(i);
            }
        }

        private void setGrid()
        {
            List<string> allDaysInMonth = FilesHandler.GetFileLines(m_TimeWatch.ChosenYearInt,
                m_TimeWatch.ChosenMonthInt);

            monthGridView.Rows.Clear();
            foreach (var dayInfo in allDaysInMonth)
            {
                var dayArr = dayInfo.Split('-');
                if (dayArr.Length < 6) continue;

                int currRowNum = monthGridView.Rows.Add();
                var newRow = monthGridView.Rows[currRowNum];

                for (int column = 0; column < dayArr.Length; column++)
                {
                    setGridRow(column, newRow, dayArr);
                }
            }
        }

        private void setGridRow(int i_Column, DataGridViewRow i_NewRow, IList<string> i_DayArr)
        {
            if (i_Column == (int) eColumn.TotalTime)
            {
                i_NewRow.Cells[i_Column].Value = TimeHandler.calcTime(
                    (string) i_NewRow.Cells[(int) eColumn.Arrival].Value,
                    (string) i_NewRow.Cells[(int) eColumn.Leaving].Value);
                i_NewRow.Cells[i_Column].Style.BackColor = ((string) i_NewRow.Cells[i_Column].Value).StartsWith("-")
                    ? Color.LightCoral
                    : DefaultBackColor;
            }
            else
            {
                i_NewRow.Cells[i_Column].Value = i_DayArr[i_Column].Replace(TimeWatch.sr_DashReplacer, TimeWatch.sr_RowSeparator.ToString());
            }
        }

        private void daysGridView_CellContentClick(object i_Sender, DataGridViewCellEventArgs i_E)
        {
            try
            {
                int row = i_E.RowIndex;
                String msg;

                if (row < 0 || i_E.ColumnIndex < 0) return;

                switch ((eColumn) i_E.ColumnIndex)
                {
                    case eColumn.Comment:
                        msg = (string) monthGridView.Rows[row].Cells[(int) eColumn.Comment].Value;
                        msg = new GetCommentForm(msg).ShowDialog();
                        if (msg != null) m_TimeWatch.setCellData(row, eColumn.Comment, msg);
                        return;
                    case eColumn.Arrival:
                    case eColumn.Leaving:
                        msg = (string)monthGridView.Rows[row].Cells[i_E.ColumnIndex].Value; 
                        string hours = TimeHandler.getHoursStr(msg);
                        string minutes = TimeHandler.getMinutesStr(msg);

                        msg = new GetTimeDataForm(hours, minutes).ShowDialog();
                        if (msg != null) m_TimeWatch.setCellData(row, (eColumn) i_E.ColumnIndex, msg);
                        return;
                    case eColumn.MonthDay:
                        return;
                    case eColumn.DayType:
                        string chosneDayType = (string) monthGridView.Rows[row].Cells[i_E.ColumnIndex].Value;
                        msg = new GetDayTypeWindowForm(chosneDayType).ShowDialog();
                        if (!string.IsNullOrEmpty(msg)) m_TimeWatch.setCellData(row, (eColumn)i_E.ColumnIndex, msg);
                        return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occurred:\n" + exception.Message, "Exception!!", MessageBoxButtons.OK);
            }
        }

        private string[] getSummary()
        {
            string[] summaryArr = m_TimeWatch.GetSummaryArr();

            summaryArr[(int) eSummaryFeilds.WorkingDays] = "Working Days: " +
                                                           summaryArr[(int) eSummaryFeilds.WorkingDays];
            summaryArr[(int) eSummaryFeilds.PersonalVecation] = "Personal Vacation Days: " +
                                                                summaryArr[(int) eSummaryFeilds.PersonalVecation];
            summaryArr[(int) eSummaryFeilds.SickDays] = "Sick Days: " + summaryArr[(int) eSummaryFeilds.SickDays];
            summaryArr[(int) eSummaryFeilds.Holidays] = "Holidays: " +
                                                        summaryArr[(int) eSummaryFeilds.Holidays];
            summaryArr[(int) eSummaryFeilds.WorkingHours] = "Working Hours: " +
                                                            summaryArr[(int) eSummaryFeilds.WorkingHours];

            return summaryArr;
        }

        private void Leaving_Click(object i_Sender, EventArgs i_)
        {
            setTimeToNow();
            m_TimeWatch.SetTime(TimeHandler.CurDay(), eColumn.Leaving, TimeHandler.getCurrClockTime());
        }

        private void Arrival_Click(object i_Sender, EventArgs i_)
        {
            setTimeToNow();
            m_TimeWatch.SetTime(TimeHandler.CurDay(), eColumn.Arrival, TimeHandler.getCurrClockTime());
        }

        private void chooseYear_DropDown(object i_Sender, EventArgs i_)
        {
            setYearsToggle();
        }

        private void chooseMonth_DropDown(object i_Sender, EventArgs i_)
        {
            setMonthToggle();
        }

        private void chooseYear_SelectedIndexChanged(object i_Sender, EventArgs i_)
        {
            ComboBox cb = i_Sender as ComboBox;
            if (cb != null)
            {
                String s = cb.Text;
                m_TimeWatch.ChosenYearInt = int.Parse(s);
            }
        }

        private void chooseMonth_SelectedIndexChanged(object i_Sender, EventArgs i_)
        {
            ComboBox cb = i_Sender as ComboBox;
            if (cb != null)
            {
                String s = cb.Text;
                m_TimeWatch.ChosenMonthInt = int.Parse(s);
            }
        }

        private void ChooseYear_KeyDown(object i_Sender, KeyEventArgs i_)
        {
            int year;
            ComboBox cb = i_Sender as ComboBox;
            if (i_.KeyCode == Keys.Enter)
            {
                string s = cb.Text;
                bool isNumber = int.TryParse(s, out year);
                if (isNumber && year >= 2015 && year < 3000)
                {
                    m_TimeWatch.ChosenYearInt = int.Parse(s);
                }
            }
        }

        private void ChooseMonth_KeyDown(object i_Sender, KeyEventArgs i_)
        {
            int month;
            ComboBox cb = i_Sender as ComboBox;
            if (i_.KeyCode == Keys.Enter)
            {
                string s = cb.Text;
                bool isNumber = int.TryParse(s, out month);
                if (isNumber && month >= 1 && month <= 12)
                {
                    m_TimeWatch.ChosenMonthInt = int.Parse(s);
                }
            }
        }
    }
}