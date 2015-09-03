using System;
using System.Windows.Forms;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class GetTimeDataForm : Form
    {
        private const string emptyChoose = "";
        protected string data = null;

        public GetTimeDataForm()
        {
            InitializeComponent();
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
            HoursBox.Text = TimeHandler.getCurrClockTime().Split(':')[0];
            MinutesBox.Text = TimeHandler.getCurrClockTime().Split(':')[1];
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

        private void HoursBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setData();
        }

        private void MinutesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setData();

        }
    }
}
