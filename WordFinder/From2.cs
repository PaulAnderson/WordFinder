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
        private List<Word> FoundWords;
        private Dictionary<String, Word> FoundWordsDict; //use for fast lookups to avoid duplicates
        private List<Direction> Directions;

        
        public Form2()
        {
            InitializeComponent();

            wordList = new WordList() { MinWordLength = minWordLength, MaxWordLength = maxWordLength };
            boardModel = new BoardLettersModel(gridSizeX, gridSizeY);
            boardController = new BoardController(boardModel, lettersGrid);

            lettersGrid.TextChanged += LettersGrid_TextChanged;
            //Set up directions
            Directions = Direction.get8Directions();

           }

        private void LettersGrid_TextChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }

        private void doFindIfReady()
        {
            if (checkBoard())
            {
                Application.DoEvents();
                doFind(); //no point waiting, we have all the letters
            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
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

            FoundWords = new List<Word>();
            FoundWordsDict = new Dictionary<String, Word>();
            findWords();

            populateResultsList();
        }
        private void populateResultsList()
        {
            lstResults.Items.Clear();

            WordScorer scorer = new WordScorer(boardModel);
            scorer.SetWordScores(FoundWords);

            //Get no of words and total possible score if all found words played
            int maxTotal = 0;
            for (int i = 0; i < FoundWords.Count; i++)
            {
                maxTotal += FoundWords[i].Score;
            }
            lblMaxPossibleScore.Text = maxTotal.ToString();
            lblWords.Text = FoundWords.Count.ToString();

            if (cbkSortbyScore.Checked)
            {
                FoundWords.Sort(new ScoredWordComparer());
                FoundWords.Reverse();
                lstResults.FormattingEnabled = true;
                foreach (Word word in FoundWords)
                {
                    lstResults.Items.Add(word.Text + "  (" + word.Score.ToString()+")");
                }

            }
            if (cbkSortbyScoreComplexity.Checked)
            {
                FoundWords.Sort(new ScoredComplexWordComparer());
                FoundWords.Reverse();
                lstResults.FormattingEnabled = true;
                foreach (Word word in FoundWords)
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
                    for(int i = FoundWords.Count - 1; i >= 0; i--)
                    {
                        if (FoundWords[i].Score< minScore)
                        {
                            FoundWords.RemoveAt(i);
                        }
                    }
                }

                FoundWords.Sort(new WordPathComparer());
                lstResults.FormattingEnabled = true;
                foreach (Word word in FoundWords)
                {
                    lstResults.Items.Add(word.Text + "  (" + word.Score.ToString() + ")");
                }
            }
            if (cbkSortbyLength.Checked)
            {
                FoundWords.Sort(new WordLengthComparer());
                FoundWords.Reverse();

                foreach (Word word in FoundWords)
                {
                    lstResults.Items.Add(word.Text);
                }
            }
            
        }
        private bool checkBoard()
        {
            
            return (boardModel.LetterCount > 1);
        }
        private void findWords()
        {
            for (int r = 0; r < gridSizeX; r++)
            {
                for (int c = 0; c < gridSizeY; c++)
                {
                    findWords(r, c, new History(), "");
                }
            }
            filterWords();
        }
        private void findWords(int r, int c, History hist, string prefix)
        {
            //Add to history trail and word

            hist.Push(r, c);
            prefix += boardModel.Letters[r, c];

            if (!wordList.Find(prefix, wholeWord: false))
            {
                //prefix not in dictionary, no point continuing this way
                hist.Pop();
                return;
            }

            //only return words passing through one of the mandatory tiles, if enabled.
            if (!boardModel.UsingMandatoryTiles || hist.Overlaps(boardModel.MandatoryLocations)) { 

                //check if the current path is a valid word
                if (prefix.Length >= minWordLength && wordList.Find(prefix, wholeWord:true))
                {
                    if (!FoundWordsDict.ContainsKey(prefix))
                    {
                        Word newWord = new Word(prefix, hist.Copy());
                        FoundWords.Add(newWord);
                        FoundWordsDict.Add(prefix, newWord);
                    }
                    else {
                        //found the same word a second time, check to see which one has a higher score, replace if new word has higher score
                        WordScorer scorer = new WordScorer(boardModel);
                        Word newWord = new Word(prefix, hist.Copy());
                        int newWordPathScore = scorer.getWordScore(newWord);
                        int oldWordPathScore = scorer.getWordScore(FoundWordsDict[prefix]);
                        if (newWordPathScore > oldWordPathScore)
                        {
                            FoundWordsDict[prefix].AlternatePaths.Add(FoundWordsDict[prefix].Path);  
                            FoundWordsDict[prefix].Path = newWord.Path;
                        } else {
                            FoundWordsDict[prefix].AlternatePaths.Add(newWord.Path);  
                        }
                    }
                }
            }

            //stop recursion if we are at max length
            if (hist.Count == maxWordLength)
            {
                hist.Pop();
                return;
            }

            //Explore alternate paths from this location
            for (int newRow = 0; newRow < gridSizeX; newRow++)
            {
                for (int newCol = 0; newCol < gridSizeY; newCol++)
                {
                    if (!(newRow == r && newCol == c) && !hist.Contains(newRow, newCol) && boardModel.Letters[newRow, newCol] != ' ')
                    {
                        if (boardModel.Letters[newRow, newCol] != '?')
                        {
                            findWords(newRow, newCol, hist, prefix);
                        }
                        else
                        {
                            for (char ch = 'A'; ch <='Z'; ch++)
                            {
                                boardModel.Letters[newRow, newCol] = ch;
                                findWords(newRow, newCol, hist, prefix);
                            }
                            boardModel.Letters[newRow, newCol] = '?';
                        }
                    }
                }
            }
            hist.Pop();
        }

        private void filterWords()
        {
            var prefix = txtStartWith.Text.ToUpper();
            var suffix = txtEndWith.Text.ToUpper();
            var infix =  txtContains.Text.ToUpper();

            for (var i = FoundWords.Count-1; i>=0; i--)
            {
                if ((prefix.Length > 0 &&
                    !FoundWords[i].Text.StartsWith(prefix))
                || (suffix.Length > 0 &&
                    !FoundWords[i].Text.EndsWith(suffix))
                || (infix.Length > 0 &&
                    !FoundWords[i].Text.Contains(infix))
                    )
                {
                    FoundWords.RemoveAt(i);
                }
            }
        }
        private Word SelectedWord;

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            boardController.ClearLetterColours();
            string word = (string)lstResults.SelectedItem;
            if (!string.IsNullOrEmpty(word))
            {
                word = word.Split(' ')[0];
            }
            foreach (Word foundWord in FoundWords)
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
    }


}
