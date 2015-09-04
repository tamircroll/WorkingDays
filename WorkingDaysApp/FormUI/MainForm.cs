using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkingDaysApp.Enums;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class MainForm : Form
    {

        private WorkingDays workingDays = WorkingDays.Instance;

        public MainForm()
        {
            workingDays.Changed += refreshView;
            InitializeComponent();
            setTimeToNow();
        }


        private void setTimeToNow()
        {
            setTime(TimeHandler.CurYear(), TimeHandler.CurMonth());
        }

        private void setTime(int year, int Month)
        {
            workingDays.ChosenYearInt = year;
            workingDays.ChosenMonthInt = Month;
        }

        private void refreshView()
        {
            chooseMonth.Text = workingDays.ChosenMonthInt.ToString();
            chooseYear.Text = workingDays.ChosenYearInt.ToString();
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
                workingDays.ChosenYearInt, TimeHandler.GetMonthName(workingDays.ChosenMonthInt));
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

        private void setChoosenYear(int i_Year)
        {
            workingDays.ChosenYearInt = i_Year;
        }

        private void setChoosenMonth(int i_Month)
        {
            workingDays.ChosenMonthInt = i_Month;
        }

        private void setGrid()
        {
            List<string> allDaysInMonth = FilesHandler.GetFileLines(workingDays.ChosenYearInt,
                workingDays.ChosenMonthInt);

            monthGridView.Rows.Clear();
            foreach (var dayInfo in allDaysInMonth)
            {
                var dayArr = dayInfo.Split('-');
                if (dayArr.Length < 6) continue;

                int currRowNum = monthGridView.Rows.Add();
                var newRow = monthGridView.Rows[currRowNum];

                for (int i = 0; i < dayArr.Length; i++)
                {
                    setGridRow(i, newRow, dayArr);
                }
            }
        }

        private static void setGridRow(int i, DataGridViewRow newRow, string[] dayArr)
        {
            if (i == (int) eColumn.TotalHours)
            {
                newRow.Cells[i].Value = TimeHandler.calcTime(
                    (string) newRow.Cells[(int) eColumn.Arrival].Value,
                    (string) newRow.Cells[(int) eColumn.Leaving].Value);
            }
            else
            {
                newRow.Cells[i].Value = dayArr[i];
            }
        }


        private void daysGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                String msg;

                if (row < 0 || e.ColumnIndex < 0) return;

                switch ((eColumn) e.ColumnIndex)
                {
                    case eColumn.Comment:
                        msg = (string) monthGridView.Rows[row].Cells[(int) eColumn.Comment].Value;
                        msg = new GetCommentForm(msg).ShowDialog();
                        if (msg != null) workingDays.setCellData(row, eColumn.Comment, msg);
                        return;
                    case eColumn.Arrival:
                    case eColumn.Leaving:
                        msg = (string)monthGridView.Rows[row].Cells[e.ColumnIndex].Value;  //TODO: Fix - not working so far
                        string hours = TimeHandler.getHoursStr(msg);
                        string minutes = TimeHandler.getMinutesStr(msg);

                        msg = new GetTimeDataForm(hours, minutes).ShowDialog();
                        if (msg != null) workingDays.setCellData(row, (eColumn) e.ColumnIndex, msg);
                        return;
                    case eColumn.MonthDay:
                        return;
                    case eColumn.DayType:
                        string chosneDayType = (string) monthGridView.Rows[row].Cells[(int) eColumn.DayType].Value; //TODO: replace this (int) eColumn.DayType with e.ColumnIndex
                        msg = new GetDayTypeWindowForm(chosneDayType).ShowDialog();
                        if (msg != null) workingDays.setCellData(row, eColumn.DayType, msg);
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
            string[] summaryArr = workingDays.GetSummaryArr();

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

        private void Leaving_Click(object sender, EventArgs e)
        {
            setTimeToNow();
            workingDays.SetTime(TimeHandler.CurDay(), eColumn.Leaving, TimeHandler.getCurrClockTime());
        }

        private void Arrival_Click(object i_Sender, EventArgs e)
        {
            setTimeToNow();
            workingDays.SetTime(TimeHandler.CurDay(), eColumn.Arrival, TimeHandler.getCurrClockTime());
        }

        private void chooseYear_DropDown(object i_Sender, EventArgs e)
        {
            setYearsToggle();
        }

        private void chooseMonth_DropDown(object i_Sender, EventArgs e)
        {
            setMonthToggle();
        }

        private void chooseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            String s = cb.Text;
            setChoosenYear(int.Parse(s));
        }

        private void chooseMonth_SelectedIndexChanged(object i_Sender, EventArgs e)
        {
            ComboBox cb = i_Sender as ComboBox;
            String s = cb.Text;
            setChoosenMonth(int.Parse(s));
        }
    }
}
