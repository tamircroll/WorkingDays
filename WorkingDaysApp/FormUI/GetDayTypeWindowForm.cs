using System;
using System.Windows.Forms;
using WorkingDaysApp.Enums;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp.FormUI
{
    public partial class GetDayTypeWindowForm : Form
    {
        protected string m_Data;

        public GetDayTypeWindowForm(string currDayType)
        {
            InitializeComponent();
            DayTypeBox.Text = currDayType;
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

        private void GetDayTypeWindowForm_Load(object sender, EventArgs e)
        {
            setDayTypeBoxValues();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            m_Data = DayTypeBox.Text;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            m_Data = null;
            Close();
        }
    }
}
