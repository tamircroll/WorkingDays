using System;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;

namespace TimeWatchApp.FormUI
{
    public partial class GetDayTypeWindowForm : Form
    {
        protected string m_Data;
        private readonly string m_CurrDayType;

        public GetDayTypeWindowForm(string i_CurrDayType)
        {
            InitializeComponent();
            m_CurrDayType = i_CurrDayType;
        }

        public new string ShowDialog()
        {
            base.ShowDialog();
            return m_Data;
        }

        private void setDayTypeBoxValues()
        {
            Array values = Enum.GetValues(typeof (eDayType));
            foreach (eDayType val in values)
            {
                DayTypeBox.Items.Add(DayTypeFactory.Get(val));
            }
        }

        private void GetDayTypeWindowForm_Load(object i_Sender, EventArgs i_)
        {
            setDayTypeBoxValues();
            DayTypeBox.Text = m_CurrDayType;
        }

        private void OK_Click(object i_Sender, EventArgs i_)
        {
            m_Data = DayTypeBox.Text;
            Close();
        }

        private void Cancel_Click(object i_Sender, EventArgs i_)
        {
            m_Data = null;
            Close();
        }
    }
}
