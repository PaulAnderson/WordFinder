using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFinder
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            var frm = new Form1();
            frm.Show();
        }

        private void LettersButton_Click(object sender, EventArgs e)
        {
            var frm = new Form2();
            frm.Show();
        }
    }
}
