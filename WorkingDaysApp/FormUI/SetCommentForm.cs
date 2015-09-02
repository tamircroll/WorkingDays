using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkingDaysApp.FormUI
{
    public partial class SetCommentForm : Form
    {
        private int row, column;

        public SetCommentForm(int row, int column)
        {
            this.row = row;
            this.column = column;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
