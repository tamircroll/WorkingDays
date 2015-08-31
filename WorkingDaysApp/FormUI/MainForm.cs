using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class MainForm : Form
    {
        private readonly WorkingDays r_WorkingDaysDays;

        public MainForm(WorkingDays i_WorkingDays)
        {
            r_WorkingDaysDays = i_WorkingDays;
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            r_WorkingDaysDays.arrivalEvent += setDaysGrid;
            r_WorkingDaysDays.showYearsEvent += setYearsToggle;
            r_WorkingDaysDays.showMonthsEvent += setYearsToggle;
//            r_WorkingDaysDays.SetYears();
        }

        private void setYearsToggle(List<string> years)
        {
            chooseYear.Items.Clear();
            foreach (var hour in years)
            {
                chooseYear.Items.Add(hour);
            }
        }

        private void setDaysGrid(List<string> hours)
        {
            foreach (var hour in hours)
            {
                daysGridView.Rows.Add(hour,hour);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Arrival_Click(object sender, EventArgs e)
        {
            r_WorkingDaysDays.SetYears();
        }

        private void daysGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chooseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_WorkingDaysDays.SetYears();
        }

        private void chooseYear_DropDown(object sender, EventArgs e)
        {
            r_WorkingDaysDays.SetYears();
        }
    }
}
