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
            setTimeToNow();
            initForm();
        }

        private void setTimeToNow()
        {
            chosenYearInt = TimeHandler.CurYear();
            chosenMonthInt = TimeHandler.CurMonth();
        }

        private void initForm()
        {
            setForm();
            chooseMonth.Text = chosenMonthInt.ToString();
            chooseYear.Text = chosenYearInt.ToString();
            setListViewTitle();
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
            setForm();
        }

        private void setChoosenMonth(int i_Month)
        {
            chosenMonthInt = i_Month;
            setForm();
        }

        private void setForm()
        {
            setListViewTitle();
            setGrid();
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
            setTimeToNow();
            r_WorkingDays.SetCurrentTime(eColumn.Leaving);
            setForm();
        }

        private void Arrival_Click(object i_Sender, EventArgs e)
        {
            setTimeToNow();
            r_WorkingDays.SetCurrentTime(eColumn.Arrival);
            setForm();
        }

        private void daysGridView_CellContentClick(object i_Sender, EventArgs e)
        {
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
