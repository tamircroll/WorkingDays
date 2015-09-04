using System;
using System.Windows.Forms;

namespace TimeWatchApp.FormUI
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

        private void GetCommentForm_Load(object sender, EventArgs e)
        {
            ActiveControl = commentText;
        }

        private void GetCommentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_Data = commentText.Text;
                Close();
            }
        }
    }
}
