using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WordFinder
{

    public partial class Form2 : Form
    {
        const int minWordLength = 2;
        const int maxWordLength = 15;

        const int gridSizeX = 4;
        const int gridSizeY = 4;

        private WordList wordList;
        private BoardLettersModel boardModel;
        private BoardController boardController;
        private WordFinder wordFinder;
        private List<Word> foundWords;
        private Word SelectedWord;

        public Form2()
        {
            InitializeComponent();

            wordList = new WordList() { MinWordLength = minWordLength, MaxWordLength = maxWordLength };
            boardModel = new BoardLettersModel(gridSizeX, gridSizeY);
            boardController = new BoardController(boardModel, lettersGrid);
            wordFinder = new WordFinder(boardModel, wordList);

            lettersGrid.TextChanged += LettersGrid_TextChanged;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
        }

        private void LettersGrid_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void doFindIfReady()
        {
            wordFinder.prefix = txtStartWith.Text;
            wordFinder.suffix = txtEndWith.Text;
            wordFinder.infix = txtContains.Text;

            if (checkBoard())
            {
                Application.DoEvents();
                doFind();
            }
        }
      
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!checkBoard())
            {
                MessageBox.Show("Board not complete. You must enter a letter in every square to proceed.");
                return;
            }
            doFind();
        }

        private void doFind()
        {
            boardController.ClearLinePath();
            foundWords = wordFinder.FindWords();
            populateResultsList();
        }

        private void populateResultsList()
        {
            lstResults.Items.Clear();

            WordScorer scorer = new WordScorer(boardModel);
            scorer.SetWordScores(foundWords);

            //Get no of words and total possible score if all found words played
            int maxTotal = 0;
            for (int i = 0; i < foundWords.Count; i++)
            {
                maxTotal += foundWords[i].Score;
            }
            lblMaxPossibleScore.Text = maxTotal.ToString();
            lblWords.Text = foundWords.Count.ToString();

            if (cbkSortbyScore.Checked)
            {
                foundWords.Sort(new ScoredWordComparer());
                foundWords.Reverse();
                lstResults.FormattingEnabled = true;
                foreach (Word word in foundWords)
                {
                    lstResults.Items.Add(word.Text + "  (" + word.Score.ToString()+")");
                }

            }
            if (cbkSortbyScoreComplexity.Checked)
            {
                foundWords.Sort(new ScoredComplexWordComparer());
                foundWords.Reverse();
                lstResults.FormattingEnabled = true;
                foreach (Word word in foundWords)
                {
                    lstResults.Items.Add(word.Text + "  (" + word.Score.ToString() + ")");
                }

            }
            if (cbkSortbyPath.Checked)
            {
                //For path sort, we remove low-scoring words
                int minScore=0;
                if (Int32.TryParse(txtMinScore.Text, out minScore))
                {
                    //Got the min. score, now remove too-low words
                    for(int i = foundWords.Count - 1; i >= 0; i--)
                    {
                        if (foundWords[i].Score< minScore)
                        {
                            foundWords.RemoveAt(i);
                        }
                    }
                }

                foundWords.Sort(new WordPathComparer());
                lstResults.FormattingEnabled = true;
                foreach (Word word in foundWords)
                {
                    lstResults.Items.Add(word.Text + "  (" + word.Score.ToString() + ")");
                }
            }
            if (cbkSortbyLength.Checked)
            {
                foundWords.Sort(new WordLengthComparer());
                foundWords.Reverse();

                foreach (Word word in foundWords)
                {
                    lstResults.Items.Add(word.Text);
                }
            }
            
        }
        private bool checkBoard()
        {
            
            return (boardModel.LetterCount > 1);
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            boardController.ClearLetterColours();
            string word = (string)lstResults.SelectedItem;
            if (!string.IsNullOrEmpty(word))
            {
                word = word.Split(' ')[0];
            }
            foreach (Word foundWord in foundWords)
            {
                if (word.Equals(foundWord.Text))
                {
                    SelectedWord = foundWord;
                    boardController.ShowPath(foundWord.Path);

                    //word stats
                    lblCurrentWordLetters.Text = foundWord.Text.Length.ToString();
                    lblCurrentWordDirChanges.Text = foundWord.Path.DirectionChanges().ToString();
                    lblCurrentWordCrossovers.Text = foundWord.Path.CrossOvers().ToString();
                    
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (boardModel.LastChangedTime.AddMinutes(2)>DateTime.Now)
            {
                if (MessageBox.Show(this,"You changed the board less than 2 minutes ago. Are you sure you want to clear it?","Clear board?",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2 )==DialogResult.No)
                {
                    return;
                }
            }
            txtStartWith.Text = "";
            txtEndWith.Text = "";
            txtContains.Text = "";
            lstResults.Items.Clear();
            boardController.Clear();
        }
        
        private void cbkSortbyScore_CheckedChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void lblDL_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.DL);
        }

        private void lblTL_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.TL);
        }

        private void lblDW_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.DW);
        }

        private void lblTW_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.TW);
        }

        private void lblMI_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.MI);
        }

        private void lblNoSpecial_Click(object sender, EventArgs e)
        {
            boardController.SetLetterModifiers(CustomTextBox.ScoreModifier.None);
        }

        private void timerAutoAdvance_Tick(object sender, EventArgs e)
        {
            try
            {
                lstResults.SelectedIndex += 1;
            } catch (Exception)
            {
                //do nothing
            }
        }

        private void cbkSortbyScore_CheckedChanged_1(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void cbkSortbyPath_CheckedChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void cbkSortbyLength_CheckedChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void txtMinScore_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }
        private void txtStartWith_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }
        private void txtEndWith_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }
        private void txtContains_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }
        private void chkDictOSPD_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
        }
        private void chkDictEnable_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
        }
        private void chkDictUKACD_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
        }
        private void LoadSelectedDictionary()
        {
            DictionaryEdition edition;
 
            if (chkDictOSPD.Checked)
            {
                edition = DictionaryEdition.OSPD;
            }
            else if(chkDictEnable.Checked)
            {
                edition = DictionaryEdition.ENABLE;
            }
            else if (chkDictUKACD.Checked)
            {
                edition = DictionaryEdition.UKACD;
            } else
            {
                throw new Exception("Unknown word list");
            }

            wordList.LoadDictionary(edition);

            doFindIfReady();

        }

        private void lstResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==' ')
            {
                lstResults.TopIndex = lstResults.SelectedIndex;
            }
        }
         

        private void lstResults_Enter_1(object sender, EventArgs e)
        {
            lblStatus.Text = "Press Space bar to scroll current word to top.";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
