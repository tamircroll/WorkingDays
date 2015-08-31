using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
            chosenYearInt = TimeHandler.CurYear();
            chosenMonthInt = TimeHandler.CurMonth();
            initForm();
        }

        private void initForm()
        {
            r_WorkingDays.ArrivalEvent += setMonthGrid;
            r_WorkingDays.ShowYearsEvent += setYearsToggle;
            r_WorkingDays.ShowMonthsEvent += setMonthToggle;
            setMonthGrid();
            chooseMonth.Text = chosenMonthInt.ToString();
            setListViewTitle();
        }

        private void setListViewTitle()
        {
            listViewTitle.Text = string.Format("Year: {0}, Month: {1}", chosenYearInt, chosenMonthInt);
        }

        private void setYearsToggle(List<string> years)
        {
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
        }

        private void setChoosenMonth(int i_Month)
        {
            chosenMonthInt = i_Month;
            setMonthGrid();
        }

        private void setMonthGrid()
        {
            setListViewTitle();
            List<string> monthData = r_WorkingDays.getFileLines(chosenYearInt, chosenMonthInt);
            monthGridView.Rows.Clear();
            foreach (var dayData in monthData)
            {
                var day = dayData.Split('-');
                if (day.Length < 4) break;

                int rowNum = monthGridView.Rows.Add();
                var newRow = monthGridView.Rows[rowNum];

                for (int i = 1; i < day.Length; i++)
                {
                    newRow.Cells[i].Value = day[i];
                }
            }
        }

        private void MainForm_Load(object i_Sender, EventArgs e)
        {

        }

        private void Arrival_Click(object i_Sender, EventArgs e)
        {
            r_WorkingDays.SetYears();
        }

        private void daysGridView_CellContentClick(object i_Sender, EventArgs e)
        {
        }


        private void chooseYear_DropDown(object i_Sender, EventArgs e)
        {
            r_WorkingDays.SetYears();
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
