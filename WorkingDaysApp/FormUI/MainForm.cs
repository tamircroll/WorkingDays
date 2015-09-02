using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkingDaysApp.Enums;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class MainForm : Form
    {
        private readonly WorkingDays r_WorkingDays;
        private int chosenYearInt, chosenMonthInt;

        public MainForm(WorkingDays i_WorkingDays)
        {
            r_WorkingDays = i_WorkingDays;
            InitializeComponent();
            setTime();
        }

        private void setTime()
        {
            setTime(TimeHandler.CurYear(), TimeHandler.CurMonth());
        }

        private void setTime(int year, int Month)
        {
            chosenYearInt = year;
            chosenMonthInt = Month;
            refreshView();
        }

        private void refreshView()
        {
            chooseMonth.Text = chosenMonthInt.ToString();
            chooseYear.Text = chosenYearInt.ToString();
            setListViewTitle();
            setGrid();
        }

        private void setListViewTitle()
        {
            listViewTitle.Text = string.Format("Year: {0}, Month: {1}", chosenYearInt, chosenMonthInt);
        }

        private void setYearsToggle()
        {
            List<string> years = r_WorkingDays.GetYears();

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
            chosenYearInt = i_Year;
            refreshView();
        }

        private void setChoosenMonth(int i_Month)
        {
            chosenMonthInt = i_Month;
            refreshView();
        }
        
        private void setGrid()
        {
            List<string> allDaysInMonth = FilesHandler.GetFileLines(chosenYearInt, chosenMonthInt);
            
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
        
        private void Leaving_Click(object sender, EventArgs e)
        {
            setTime();
            r_WorkingDays.SetTime(TimeHandler.CurYear(), TimeHandler.CurMonth(), TimeHandler.CurDay(),eColumn.Leaving, TimeHandler.getCurrClockTime());
            refreshView();
        }

        private void Arrival_Click(object i_Sender, EventArgs e)
        {
            setTime();
            r_WorkingDays.SetTime(TimeHandler.CurYear(), TimeHandler.CurMonth(), TimeHandler.CurDay(), eColumn.Arrival, TimeHandler.getCurrClockTime());
            refreshView();
        }

        private void daysGridView_CellContentClick(object i_Sender, EventArgs e)
        {
            var a = e as DataGridViewCellEventArgs;
            switch (a.ColumnIndex)
            {
                case (int)eColumn.Day:
                    return;
                case (int)eColumn.Arrival:
                    return;
                case (int)eColumn.Leaving:
                    return;
                case (int)eColumn.DayType:
                    return;
                case (int)eColumn.Comment:
                    return;
            }
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
