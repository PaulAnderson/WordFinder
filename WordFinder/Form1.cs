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

    public partial class Form1 : Form
    {
        const int gridSize = 4;
        private char[,] letters;
        private TextBox[,] letterControls;

        public Form1()
        {
            InitializeComponent();

            letters = new char[gridSize, gridSize];
            letterControls = new TextBox[gridSize, gridSize];

            //todo - if increase grid size beyond 4, add rows and columns to gridLayoutPanel

            for(int r=0; r< gridSize;r++)
            {
                for (int c = 0; r < gridSize; r++)
                {
                    TextBox newTextBox = new TextBox();
                    letterControls[r, c] = newTextBox;
                    letters[r, c] = ' ';
                    lettersGrid.Controls.Add(newTextBox, c, r);
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.MaxLength = 1;
                }
            }
        }
        private void readLetters()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; r < gridSize; r++)
                {
                    if (!string.IsNullOrWhiteSpace(letterControls[r, c].Text))
                    { 
                        letters[r, c] = letterControls[r, c].Text.ToCharArray()[0];
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
