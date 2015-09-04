using System;
using System.Windows.Forms;

namespace TimeWatchApp.FormUI
{
    public partial class GetCommentForm : Form
    {
        protected string m_Data;

        public GetCommentForm(string i_CurrComment)
        {
            InitializeComponent();
            commentText.Text = i_CurrComment;
        }

        public new string ShowDialog()
        {
            base.ShowDialog();
            return m_Data;
        }

        private void OK_Click(object i_Sender, EventArgs i_)
        {
            m_Data = commentText.Text;
            Close();
        }

        private void Cancel_Click(object i_Sender, EventArgs i_)
        {
            m_Data = null;
            Close();
        }

        private void GetCommentForm_Load(object i_Sender, EventArgs i_)
        {
            ActiveControl = commentText;
        }

        private void GetCommentForm_KeyDown(object i_Sender, KeyEventArgs i_)
        {
            if (i_.KeyCode == Keys.Enter)
            {
                m_Data = commentText.Text;
                Close();
            }
        }
    }
}
