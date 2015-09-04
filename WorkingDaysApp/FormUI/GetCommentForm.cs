using System;
using System.Windows.Forms;

namespace WorkingDaysApp.FormUI
{
    public partial class GetCommentForm : Form
    {
        protected string m_Data;

        public GetCommentForm(string currComment)
        {
            InitializeComponent();
            commentText.Text = currComment;
        }

        public new string ShowDialog()
        {
            base.ShowDialog();
            return m_Data;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            m_Data = commentText.Text;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            m_Data = null;
            Close();
        }
    }
}
