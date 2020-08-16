using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordFinder;

namespace WordFinder
{
    class BoardController
    {
        public Letters LetterGridControl { get; set; }
        public BoardLettersModel BoardModel { get; set; }
        private CustomTextBox[,] letterControls;

        public BoardController(BoardLettersModel boardModel, Letters letterGridControl)
        {
            BoardModel = boardModel;
            LetterGridControl = letterGridControl;

            letterControls = new CustomTextBox[boardModel.GridSizeX, boardModel.GridSizeY];

            //todo - if increase grid size beyond 4, add rows and columns to gridLayoutPanel

            //Set up textboxes and letter array
            for (int r = 0; r < boardModel.GridSizeX; r++)
            {
                for (int c = 0; c < boardModel.GridSizeY; c++)
                {
                    CustomTextBox newTextBox = new CustomTextBox();
                    letterControls[r, c] = newTextBox;
                    LetterGridControl.Add(newTextBox, c, r);
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.MaxLength = 1;
                    newTextBox.TextAlign = HorizontalAlignment.Center;
                    newTextBox.TextChanged += NewTextBox_TextChanged;
                    newTextBox.Enter += NewTextBox_Enter;
                    newTextBox.PreviewKeyDown += NewTextBox_PreviewKeyDown;
                    newTextBox.Changed += NewTextBox_Changed;
                }
            }
        }

        private void NewTextBox_Changed(object sender)
        {
            UpdateModel();
        }

        private void NewTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Left:
                    if (thisTextBox.Text.Length == 0)
                    {
                        LetterGridControl.AdvanceCursor(thisTextBox);
                    }
                    break;
                case Keys.Right:
                    LetterGridControl.AdvanceCursor(thisTextBox);
                    break;
            }
        }

        private void NewTextBox_Enter(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            thisTextBox.SelectAll();
        }

        private Boolean inChangeEvent = false;
        private void NewTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inChangeEvent) return;

            BoardModel.LastChangedTime = DateTime.Now;

            try
            {
                inChangeEvent = true;

                TextBox thisTextBox = (TextBox)sender;

                if (thisTextBox.Text.Length > 0)
                {
                    var textBoxChar = thisTextBox.Text.ToCharArray()[0];
                    if (Char.IsLetter(textBoxChar) || textBoxChar == '?')
                    {
                        thisTextBox.Text = thisTextBox.Text.ToUpper();
                        thisTextBox.BackColor = Color.LightGreen;
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        thisTextBox.BackColor = Color.White;
                    }
                }
                else
                {
                    thisTextBox.BackColor = Color.White;
                }
            }
            finally
            {
                inChangeEvent = false;
            }
            UpdateModel();
        }

        private void UpdateModel()
        {
            ReadLetters();
            LetterGridControl.OnChanged();
        }

        private void ReadLetters()
        {
            BoardModel.MandatoryLocations.Clear();

            for (int r = 0; r < BoardModel.GridSizeX; r++)
            {
                for (int c = 0; c < BoardModel.GridSizeX; c++)
                {
                    if (!string.IsNullOrWhiteSpace(letterControls[r, c].Text))
                    {
                        BoardModel.Letters[r, c] = letterControls[r, c].Text.ToCharArray()[0];
                    }
                    else
                    {
                        BoardModel.Letters[r, c] = ' ';
                    }
                    switch (letterControls[r, c].Modifier)
                    {
                        case CustomTextBox.ScoreModifier.DL:
                            BoardModel.LetterMultipliers[r, c] = 2;
                            BoardModel.WordMultipliers[r, c] = 1;
                            break;
                        case CustomTextBox.ScoreModifier.TL:
                            BoardModel.LetterMultipliers[r, c] = 3;
                            BoardModel.WordMultipliers[r, c] = 1;
                            break;
                        case CustomTextBox.ScoreModifier.DW:
                            BoardModel.LetterMultipliers[r, c] = 1;
                            BoardModel.WordMultipliers[r, c] = 2;
                            break;
                        case CustomTextBox.ScoreModifier.TW:
                            BoardModel.LetterMultipliers[r, c] = 1;
                            BoardModel.WordMultipliers[r, c] = 3;
                            break;
                        case CustomTextBox.ScoreModifier.MI:
                            BoardModel.LetterMultipliers[r, c] = 1;
                            BoardModel.WordMultipliers[r, c] = 1;
                            BoardModel.MandatoryLocations.Add(new HistoryItem(r, c));
                            break;
                        case CustomTextBox.ScoreModifier.None:
                            BoardModel.LetterMultipliers[r, c] = 1;
                            BoardModel.WordMultipliers[r, c] = 1;
                            break;
                    }
                }
            }
        }
        public void SetLetterModifiers(CustomTextBox.ScoreModifier modifier)
        {
            for (int r = 0; r < BoardModel.GridSizeX; r++)
            {
                for (int c = 0; c < BoardModel.GridSizeY; c++)
                {
                    letterControls[r, c].Modifier = modifier;
                }
            }
            ReadLetters();
        }

        public void ClearLetterColours()
        {
            for (int r = 0; r < BoardModel.GridSizeX; r++)
            {
                for (int c = 0; c < BoardModel.GridSizeY; c++)
                {
                    letterControls[r, c].BackColor = Color.White;
                }
            }
        }
        public void ShowPath(History path)
        {
            var linePath = new List<Point>();

            foreach (HistoryItem pathStop in path.GetList())
            {
                Control letterControl = letterControls[pathStop.row, pathStop.col];

                //Highlight control
                letterControl.BackColor = Color.Orange;

                //Add control location to a list of points to be painted as a line.
                Point topLeft = letterControl.Location;
                Point centre = new Point(topLeft.X + letterControl.Width / 2, topLeft.Y + letterControl.Height / 2);
                linePath.Add(centre);
            }

            letterControls[path.GetList()[0].row, path.GetList()[0].col].BackColor = Color.Red;

            LetterGridControl.LinePath = linePath;
            LetterGridControl.Refresh(); //cause repaint
        }

        internal void Clear()
        {
            inChangeEvent = true;

            for (int r = 0; r < BoardModel.GridSizeX; r++)
            {
                for (int c = 0; c < BoardModel.GridSizeY; c++)
                {
                    letterControls[r, c].Text = "";
                    letterControls[r, c].Modifier = CustomTextBox.ScoreModifier.None;
                }
            }

            ClearLinePath();
            letterControls[0, 0].Focus();
            ClearLetterColours();

            inChangeEvent = false;
        }

        public void ClearLinePath()
        {
            LetterGridControl.LinePath = new List<Point>();
            LetterGridControl.Refresh();
        }
    }
}
