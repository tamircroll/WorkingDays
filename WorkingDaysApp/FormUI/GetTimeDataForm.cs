using System;
using System.Windows.Forms;
using TimeWatchApp.Logic;
using WorkingDaysApp.Logic;

namespace TimeWatchApp.FormUI
{
    public partial class GetTimeDataForm : Form
    {
        private const string k_EmptyChoose = "";
        protected string m_Data;
        private string m_Hours, m_Minutes ;

        public GetTimeDataForm()
        {
            InitializeComponent();
        }

        public GetTimeDataForm(string i_Hours, string i_Minutes)
        {
            InitializeComponent();
            m_Hours = i_Hours;
            m_Minutes = i_Minutes;
        }

        private void getDataBaseForm_Load(object i_Sender, EventArgs i_)
        {
            MinutesBox.Items.Add(k_EmptyChoose);
            HoursBox.Items.Add(k_EmptyChoose);
            setBoxesValues();
            setBoxesText();
        }

        private void setBoxesText()
        {
            HoursBox.Text = (m_Hours != "")? m_Hours : TimeHandler.getCurrClockTime().Split(':')[0];
            MinutesBox.Text = (m_Minutes != "") ? m_Minutes : TimeHandler.getCurrClockTime().Split(':')[1];
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
            if (HoursBox.Text == k_EmptyChoose || MinutesBox.Text == k_EmptyChoose)
            {
                m_Data = "";
                return;
            }

            m_Data = string.Format("{0}:{1}:00", HoursBox.Text, MinutesBox.Text);
        }

        public string ShowDialog()
        {
            base.ShowDialog();
            return m_Data;
        }

        protected virtual void Accept_Click(object i_Sender, EventArgs i_)
        {
            setData();
            Close();
        }

        private void Cancel_Click(object i_Sender, EventArgs i_)
        {
            m_Data = null;
            Close();
        }
    }
}
