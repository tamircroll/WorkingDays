﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;
using WorkingDaysApp.Logic;
using WorkingDaysApp.Logic.TimeData;

namespace TimeWatchApp.FormUI
{
    public partial class MainForm : Form
    {
        private readonly TimeWatch m_TimeWatch = TimeWatch.Instance;

        public MainForm()
        {
            m_TimeWatch.Changed += refreshView;
            InitializeComponent();
            setTimeToNow();
            refreshView();
        }

        private void setTimeToNow()
        {
            setTime(TimeHandler.CurYear(), TimeHandler.CurMonth());
        }

        private void setTime(int i_Year, int i_Month)
        {
            m_TimeWatch.UpdateCurrMonth(i_Year, i_Month);
        }

        private void refreshView()
        {
            chooseMonth.Text = m_TimeWatch.Month.ToString();
            chooseYear.Text = m_TimeWatch.Year.ToString();
            setListViewTitle();
            setGrid();
            setSummary();
        }

        private void setSummary()
        {
            SummaryLabelLeft.Text = "";
            SummaryLabelRight.Text = "";
            bool left = true;
            List<string> summaryArr = getSummary();
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
                m_TimeWatch.Year, TimeHandler.GetMonthName(m_TimeWatch.Month));
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
            monthGridView.Rows.Clear();
            foreach (DayData day in m_TimeWatch.AllDays)
            {
                string[] rowArr = day.ToString().Split('-');
                if (rowArr.Length < 6) continue;

                int currRowNum = monthGridView.Rows.Add();
                var newRow = monthGridView.Rows[currRowNum];

                for (int column = 0; column < rowArr.Length; column++)
                {
                    setCell(column, newRow, rowArr);
                }
            }

            SetGridHeight();
        }

        private void setCell(int i_Column, DataGridViewRow i_NewRow, IList<string> i_DayArr)
        {
            i_NewRow.Cells[i_Column].Value = i_DayArr[i_Column].Replace(TimeWatch.sr_DashReplacer,
                TimeWatch.sr_RowSeparator.ToString());
            if (i_Column == (int) eColumn.DayType)
            {
                i_NewRow.Cells[i_Column].Style.BackColor = setDayTypeCellColor((string) i_NewRow.Cells[i_Column].Value);
            }
            else if (i_Column == (int) eColumn.TotalTime)
            {
                i_NewRow.Cells[i_Column].Style.BackColor = setTotalTimeCellColor((string) i_NewRow.Cells[i_Column].Value);
            }
        }

        private Color setDayTypeCellColor(string i_RowData)
        {
            if (DayTypeFactory.Get(eDayType.Holiday) == i_RowData)
            {
                return Color.Chartreuse;
            }
            if (DayTypeFactory.Get(eDayType.HalfWorkDay) == i_RowData)
            {
                return Color.Yellow;
            }
            if (DayTypeFactory.Get(eDayType.PersonalVacation) == i_RowData)
            {
                return Color.Cyan;
            }
            if (DayTypeFactory.Get(eDayType.SickDay) == i_RowData)
            {
                return Color.Coral;
            }

            return Color.White;
        }

        private static Color setTotalTimeCellColor(string i_Value)
        {
            return i_Value.StartsWith("-") ? Color.LightCoral : DefaultBackColor;
        }

        private void SetGridHeight()
        {
            int totalRowHeight = monthGridView.ColumnHeadersHeight;

            foreach (DataGridViewRow row in monthGridView.Rows)
                totalRowHeight += row.Height;

            monthGridView.Height = totalRowHeight + 2;
        }

        private void daysGridView_CellContentClick(object i_Sender, DataGridViewCellEventArgs i_E)
        {
            int day = i_E.RowIndex;
            string msg;

            if (day < 0 || i_E.ColumnIndex < 0) return;

            switch ((eColumn) i_E.ColumnIndex)
            {
                case eColumn.Comment:
                    msg = (string) monthGridView.Rows[day].Cells[(int) eColumn.Comment].Value;
                    msg = new GetCommentForm(msg).ShowDialog();
                    if (msg != null)
                        m_TimeWatch.AllDays[day].Comment = msg;
                    return;
                case eColumn.Arrival:
                case eColumn.Leaving:
                    ArrivalOrLeavingPressed(i_E, day);
                    return;
                case eColumn.DayType:
                    string chosneDayType = (string) monthGridView.Rows[day].Cells[i_E.ColumnIndex].Value;
                    msg = new GetDayTypeWindowForm(chosneDayType).ShowDialog();
                    if (!string.IsNullOrEmpty(msg))
                        m_TimeWatch.AllDays[day].DayType = DayTypeFactory.Get(msg);
                    return;
            }
        }

        private void ArrivalOrLeavingPressed(DataGridViewCellEventArgs i_E, int i_Day)
        {
            string msg = (string) monthGridView.Rows[i_Day].Cells[i_E.ColumnIndex].Value;
            string hours = TimeHandler.getHoursStr(msg);
            string minutes = TimeHandler.getMinutesStr(msg);

            msg = new GetTimeDataForm(hours, minutes).ShowDialog();
            if (msg == null) return;

            if ((eColumn) i_E.ColumnIndex == eColumn.Arrival)
                m_TimeWatch.AllDays[i_Day].ArrivalTime = new TimeData(msg);
            else if ((eColumn) i_E.ColumnIndex == eColumn.Leaving)
                m_TimeWatch.AllDays[i_Day].LeavingTime = new TimeData(msg);
        }

        private List<string> getSummary()
        {
            List<string> summaryArr = new List<string>
            {
                "Working Days: " + m_TimeWatch.CurrSummary.AllWorkingDays(),
                "Personal Vacation Days: " + m_TimeWatch.CurrSummary.TotalVacationsDay(),
                "Sick Days: " + m_TimeWatch.CurrSummary.TotalSickDays(),
                "Holidays: " + m_TimeWatch.CurrSummary.TotalHolidays(),
                "Working Hours: " + m_TimeWatch.CurrSummary.TotalHoursStr(),
                "Avergae Hours A day: " + m_TimeWatch.CurrSummary.AverageHours(),
                "Extra Hours: " + m_TimeWatch.CurrSummary.ExtraHours()
            };

            return summaryArr;
        }

        private void Leaving_Click(object i_Sender, EventArgs i_)
        {
            setTimeToNow();
            m_TimeWatch.AllDays[TimeHandler.CurDay() - 1].LeavingTime = new TimeData(TimeHandler.getCurrClockTime());
        }

        private void Arrival_Click(object i_Sender, EventArgs i_)
        {
            setTimeToNow();
            m_TimeWatch.AllDays[TimeHandler.CurDay() - 1].ArrivalTime = new TimeData(TimeHandler.getCurrClockTime());
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
                m_TimeWatch.ChangeCurrYear(int.Parse(s));
            }
        }

        private void chooseMonth_SelectedIndexChanged(object i_Sender, EventArgs i_)
        {
            ComboBox cb = i_Sender as ComboBox;
            if (cb != null)
            {
                String s = cb.Text;
                m_TimeWatch.ChangeCurrMonth(int.Parse(s));
            }
        }

        private void ChooseYear_KeyDown(object i_Sender, KeyEventArgs i_)
        {
            ComboBox cb = i_Sender as ComboBox;
            if (i_.KeyCode == Keys.Enter && cb != null)
            {
                string s = cb.Text;
                int year;
                bool isNumber = int.TryParse(s, out year);
                if (isNumber && year >= 2015 && year < 3000)
                {
                    m_TimeWatch.ChangeCurrYear(int.Parse(s));
                }
            }
        }

        private void ChooseMonth_KeyDown(object i_Sender, KeyEventArgs i_)
        {
            ComboBox cb = i_Sender as ComboBox;
            if (i_.KeyCode == Keys.Enter && cb != null)
            {
                int month;
                string s = cb.Text;
                bool isNumber = int.TryParse(s, out month);
                if (isNumber && month >= 1 && month <= 12)
                {
                    m_TimeWatch.ChangeCurrMonth(int.Parse(s));
                }
            }
        }
    }
}