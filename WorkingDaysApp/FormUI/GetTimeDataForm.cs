using System;
using System.Windows.Forms;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class GetTimeDataForm : Form
    {
        private const string emptyChoose = "";
        protected string data;
        private string hours, minutes ;

        public GetTimeDataForm()
        {
            InitializeComponent();
        }

        public GetTimeDataForm(string i_Hours, string i_Minutes)
        {
            InitializeComponent();
            hours = i_Hours;
            minutes = i_Minutes;
        }

        private void getDataBaseForm_Load(object sender, EventArgs e)
        {
            MinutesBox.Items.Add(emptyChoose);
            HoursBox.Items.Add(emptyChoose);
            setBoxesValues();
            setBoxesText();
        }

        private void setBoxesText()
        {
            HoursBox.Text = (hours != "")? hours : TimeHandler.getCurrClockTime().Split(':')[0];
            MinutesBox.Text = (minutes != "") ? minutes : TimeHandler.getCurrClockTime().Split(':')[1];
        }

        private void setBoxesValues()
        {
            for (int i = 0; i < 10; i++)
            {
                MinutesBox.Items.Add("0" + i);
                HoursBox.Items.Add("0" + i);
            }
            for (int i = 10; i < 60; i++)
            {
                MinutesBox.Items.Add(i);
                if (i < 24) HoursBox.Items.Add(i);
            }
        }

        private void setData()
        {
            if (HoursBox.Text == emptyChoose || MinutesBox.Text == emptyChoose)
            {
                data = "";
                return;
            }

            data = string.Format("{0}:{1}:00", HoursBox.Text, MinutesBox.Text);
        }

        public string ShowDialog()
        {
            base.ShowDialog();
            return data;
        }

        protected virtual void Accept_Click(object sender, EventArgs e)
        {
            setData();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            data = null;
            Close();
        }
    }
}
