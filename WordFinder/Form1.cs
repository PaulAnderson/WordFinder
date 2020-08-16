using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFinder
{

    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();

            wordList = new WordList() { MinWordLength = minWordLength, MaxWordLength = maxWordLength };
            boardModel = new BoardLettersModel(gridSizeX, gridSizeY);
            boardController = new BoardController(boardModel, lettersGrid);
            wordFinder = new WordFinder(boardModel, wordList, new CardinalDirectionStrategy());

            lettersGrid.TextChanged += LettersGrid_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSelectedDictionary();
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
 
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!checkBoard())
            {
                MessageBox.Show("Board not complete. You must enter a letter in every square to proceed.");
                return;
            }
            doFind();
        }
        private bool checkBoard()
        {
            return (boardModel.LetterCount > 15);
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
            if (boardModel.LastChangedTime.AddMinutes(2) > DateTime.Now)
            {
                if (MessageBox.Show(this, "You changed the board less than 2 minutes ago. Are you sure you want to clear it?", "Clear board?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
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
            else if (chkDictEnable.Checked)
            {
                edition = DictionaryEdition.ENABLE;
            }
            else if (chkDictUKACD.Checked)
            {
                edition = DictionaryEdition.UKACD;
            }
            else
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

      
        private void btnDoConsole_Click(object sender, EventArgs e)
        {
            if (foundWords == null)
            {
                lblStatus.Text = "Search for words first.";
                return;
            }

            if (chkShuffle.Checked) Shuffle<Word>(foundWords);
            string fileText = GetMonkeyFile(foundWords);
            File.WriteAllText("C:\\words.py", fileText);
            Clipboard.SetText(fileText);
            lblStatus.Text = "File saved as C:\\words.py, and copied to clipboard.";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (foundWords == null)
            {
                lblStatus.Text = "Search for words first.";
                return ;
            }

            try
                {
                string percentOrAmount = txtMonkeyRandomAmount.Text.Trim();
                int score = 0;
                List<Word> randomWords;
                if (txtMonkeyRandomAmount.Text.EndsWith("%", StringComparison.InvariantCultureIgnoreCase))
                {
                    randomWords = GetRandomPercent(foundWords, int.Parse(percentOrAmount.Substring(0, percentOrAmount.Length - 1)));
                }
                else
                {
                    randomWords = GetRandomWords(foundWords, int.Parse(percentOrAmount));
                }
                string fileText = GetMonkeyFile(randomWords);
                File.WriteAllText("C:\\words.py", fileText);
                for (int i = 0; i < randomWords.Count; i++)
                {
                    score += randomWords[i].Score;
                }
                Clipboard.SetText(fileText);

                lblStatus.Text = String.Format("File saved as C:\\words.py, and copied to clipboard. {0} words ({1} points)", randomWords.Count, score);
            } catch (FormatException)
            {
                lblStatus.Text = "Enter a number or a percentage of words to include.";
            }
        }
        private List<Word> GetRandomPercent(List<Word> allWords,int percentToInclude)
        {
            return GetRandomWords(allWords, allWords.Count * percentToInclude / 100);
        }
        private List<Word> GetRandomWords(List<Word> allWords, int NoOfWordsToInclude)
        {
            if (NoOfWordsToInclude > allWords.Count) NoOfWordsToInclude = allWords.Count;
            Dictionary<int, int> seenIndexes = new Dictionary<int, int>();
            Random r = new Random();
            List<Word> newList = new List<Word>();
            int wordsRequired = NoOfWordsToInclude;

            while (newList.Count < wordsRequired)
            {
                int randIdx = r.Next(0, allWords.Count); //minValue inclusive, maxValue exclusive
                if (!seenIndexes.ContainsKey(randIdx))
                {
                    seenIndexes.Add(randIdx, 0);
                    newList.Add(allWords[randIdx]);
                }
            }
            return newList;
        }
        private static Random rng = new Random();

        public static void Shuffle<T>(  List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private String GetMonkeyFile(List<Word> wordsToInclude)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"#import time");
            sb.AppendLine(@"#from com.android.monkeyrunner import MonkeyRunner, MonkeyDevice");
            sb.AppendLine(@"#device = MonkeyRunner.waitForConnection()");

            foreach (Word word in wordsToInclude)
            {
                sb.AppendLine(string.Format(@"""{0}"" ", word.Text));

                foreach (HistoryItem histItem in word.Path.GetList())
                {
                    int x = 0;
                    int y = 0;
                    switch (histItem.col)
                    {
                        case 0:
                            x = 110;
                            break;
                        case 1:
                            x = 290;
                            break;
                        case 2:
                            x = 450;
                            break;
                        case 3:
                            x = 600;
                            break;
                    }
                    switch (histItem.row)
                    {
                        case 0:
                            y = 450;
                            break;
                        case 1:
                            y = 600;
                            break;
                        case 2:
                            y = 750;
                            break;
                        case 3:
                            y = 940;
                            break;
                    }

                    sb.AppendLine(string.Format(@"device.touch({0}, {1}, ""downAndUp"")", x, y));

                }

                sb.AppendLine(string.Format(@"device.touch({0}, {1}, ""downAndUp"")", 600, 280));
                sb.AppendLine(string.Format(@"time.sleep({0:F2})", (.4+(word.Path.GetList().Count/2.5))/10));
            }

            return sb.ToString();
        }

    

        private void lstResults_Enter_1(object sender, EventArgs e)
        {
            lblStatus.Text = "Press Space bar to scroll current word to top.";

        }
    }


}
