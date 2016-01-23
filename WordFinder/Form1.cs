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
#if DEBUG 
        const string DICTFILE_OSPD = "..\\..\\ospd.txt";
        const string DICTFILE_ENABLE = "..\\..\\enable1.txt";
        const string DICTFILE_UKACD = ".\\..\\UK%20Advanced%20Cryptics%20Dictionary.txt";
#else
        const string DICTFILE_OSPD = "ospd.txt";
        const string DICTFILE_ENABLE = "enable1.txt";
        const string DICTFILE_UKACD = "UK%20Advanced%20Cryptics%20Dictionary.txt";
#endif 
        const int minWordLength = 2;
        const int maxWordLength = 15;
        const int gridSize = 4;

        private char[,] letters;
        private int[,] letterMultipliers;
        private int[,] wordMultipliers;
        private CustomTextBox[,] letterControls;

        private Dictionary<string, Words> dictionaries;
        private Words dictWords;

        private List<Word> FoundWords;
        private Dictionary<String, Word> FoundWordsDict; //use for fast lookups to avoid duplicates
        private List<Direction> Directions;
        private bool usingMandatoryTiles = false;
        private List<HistoryItem> mandatoryLocations;
        private DateTime boardLastChangedTime ;
        public Form1()
        {
            InitializeComponent();

            letters = new char[gridSize, gridSize];
            letterMultipliers = new int[gridSize, gridSize];
            wordMultipliers = new int[gridSize, gridSize];
            letterControls = new CustomTextBox[gridSize, gridSize];

            //todo - if increase grid size beyond 4, add rows and columns to gridLayoutPanel

            //Set up textboxes and letter array
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    CustomTextBox newTextBox = new CustomTextBox();
                    letterControls[r, c] = newTextBox;
                    letters[r, c] = ' ';
                    lettersGrid.Controls.Add(newTextBox, c, r);
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.MaxLength = 1;
                    newTextBox.TextAlign = HorizontalAlignment.Center;
                    newTextBox.TextChanged += NewTextBox_TextChanged;
                    newTextBox.Enter += NewTextBox_Enter;
                    newTextBox.PreviewKeyDown += NewTextBox_PreviewKeyDown;
                    newTextBox.Changed += NewTextBox_Changed;
                }
            }

            //Set up directions
            Directions = Direction.get8Directions();

           }

        private void NewTextBox_Changed(object sender)
        {
            doFindIfReady();
            
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
                        lettersGrid.SelectNextControl(thisTextBox, false, true, false, true);
                    }
                    break;
                case Keys.Right:
                    lettersGrid.SelectNextControl(thisTextBox, true, true, false, true);
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

            boardLastChangedTime = DateTime.Now;

            try
            {
                inChangeEvent = true;

                TextBox thisTextBox = (TextBox)sender;

                if (thisTextBox.Text.Length > 0)
                {
                    if (Char.IsLetter(thisTextBox.Text.ToCharArray()[0]))
                    {
                        thisTextBox.Text = thisTextBox.Text.ToUpper();
                        thisTextBox.BackColor = Color.LightGreen;
                        SendKeys.Send("{TAB}");
                    } else
                    {
                        thisTextBox.BackColor = Color.White;
                    }
                } else
                {
                    thisTextBox.BackColor = Color.White;
                }
            }
            finally
            {
                inChangeEvent = false;
            }
            doFindIfReady();
        }
        private void doFindIfReady()
        {
            readLetters();
            if (checkBoard())
            {
                Application.DoEvents();
                doFind(); //no point waiting, we have all the letters
            }
        }
        private void readLetters()
        {
            usingMandatoryTiles = false;
            mandatoryLocations = new List<HistoryItem>();

            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (!string.IsNullOrWhiteSpace(letterControls[r,c].Text))
                    {
                        letters[r, c] = letterControls[r,c].Text.ToCharArray()[0];
                    } else {
                        letters[r, c] = ' ';
                    }
                    switch (letterControls[r,c].Modifier)
                    {
                        case CustomTextBox.ScoreModifier.DL:
                            letterMultipliers[r, c] = 2;
                            wordMultipliers[r, c] = 1;
                            break;
                        case CustomTextBox.ScoreModifier.TL:
                            letterMultipliers[r, c] = 3;
                            wordMultipliers[r, c] = 1;
                            break;
                        case CustomTextBox.ScoreModifier.DW:
                            letterMultipliers[r, c] = 1;
                            wordMultipliers[r, c] = 2;
                            break;
                        case CustomTextBox.ScoreModifier.TW:
                            letterMultipliers[r, c] = 1;
                            wordMultipliers[r, c] = 3;
                            break;
                        case CustomTextBox.ScoreModifier.MI:
                            letterMultipliers[r, c] = 1;
                            wordMultipliers[r, c] = 1;
                            usingMandatoryTiles = true;
                            mandatoryLocations.Add(new HistoryItem(r, c));
                            break;
                        case CustomTextBox.ScoreModifier.None:
                            letterMultipliers[r, c] = 1;
                            wordMultipliers[r, c] = 1;
                            break;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadSelectedDictionary();
        }

        private void LoadDictionary(string fileName)
        {
            if (dictionaries== null)
            {
                dictionaries=new Dictionary<string, Words> ();
            }
            if (dictionaries.ContainsKey(fileName))
            {
                //swap out the dictionary for the pre-loaded one if available
                dictWords = dictionaries[fileName];
            } else
            {
                //not already loaded, load it now and store for later.
                dictWords = new Words();
                dictionaries.Add(fileName,dictWords);

                //Read words from file
                FileStream fs = File.Open(Path.Combine(Application.StartupPath , fileName), FileMode.Open);
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    bool inWordSection = false;
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.Equals("aa", StringComparison.InvariantCultureIgnoreCase)) inWordSection = true; //look for first word, ignore headers etc
                        if (inWordSection) { 
                            if (line.Length >= minWordLength && line.Length <= maxWordLength)
                            {
                                dictWords.AddWord(line);
                            }
                        }
                    }
                }
                finally
                {
                    fs.Close();
                }
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            readLetters();

            if (!checkBoard())
            {
                MessageBox.Show("Board not complete. You must enter a letter in every square to proceed.");
                return;
            }
            doFind();
        }

        private void doFind()
        {
            ClearLinePath();

            FoundWords = new List<Word>();
            FoundWordsDict = new Dictionary<String, Word>();
            findWords();

            populateResultsList();
        }
        private void populateResultsList()
        {
            readLetters(); //re-read letters to take into account any changed bonuses

            lstResults.Items.Clear();

            //Sort words longest to shortest. Todo: Take into account letter values and allow setting of board bonuses.
            WordScorer scorer = new WordScorer(letters, letterMultipliers, wordMultipliers);
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
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (!Char.IsLetter(letters[r, c]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void findWords()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    findWords(r, c, new History(), "");
                }
            }
        }
        private void findWords(int r, int c, History hist, string prefix)
        {
            //Add to history trail and word

            hist.Push(r, c);
            if (letters[r, c] == 'Q')
            {
                prefix += "QU";
            }
            else
            {
                prefix += letters[r, c];
            }

            //Debug.Print(prefix);

            if (!dictWords.isWordPrefixInList(prefix))
            {
                //prefix not in dictionary, no point continuing this way
                hist.Pop();
                return;
            }

            //only return words passing through one of the mandatory tiles, if enabled.
            if (!usingMandatoryTiles || hist.Overlaps(mandatoryLocations)) { 

                //check if the current path is a valid word
                if (prefix.Length >= minWordLength && dictWords.isWordInList(prefix))
                {
                    if (!FoundWordsDict.ContainsKey(prefix))
                    {
                        Word newWord = new Word(prefix, hist.Copy());
                        FoundWords.Add(newWord);
                        FoundWordsDict.Add(prefix, newWord);
                    }
                    else {
                        //found the same word a second time, check to see which one has a higher score, replace if new word has higher score
                        WordScorer scorer = new WordScorer(letters, letterMultipliers, wordMultipliers);
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
            foreach (Direction dir in Directions)
            {
                int newRow = r + dir.RowOffset;
                int newCol = c + dir.ColOffset;
                if (newRow >= 0 && newCol >= 0 && newRow < gridSize && newCol < gridSize && !hist.Contains(newRow, newCol))
                {
                    findWords(newRow, newCol, hist, prefix);
                }
            }
            hist.Pop();
        }
        private Word SelectedWord;

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ClearLetterColours();
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
                    ShowPath(foundWord.Path);

                    //word stats
                    lblCurrentWordLetters.Text = foundWord.Text.Length.ToString();
                    lblCurrentWordDirChanges.Text = foundWord.Path.DirectionChanges().ToString();
                    lblCurrentWordCrossovers.Text = foundWord.Path.CrossOvers().ToString();
                    
                }
            }
            //Set timer length based on word length
            timerAutoAdvance.Interval = 500 + (word.Length * 150); //300ms to find the word, then 100ms for each letter
        }
        private void ClearLetterColours()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    letterControls[r, c].BackColor = Color.White;
                }
            }
        }
        private List<Point> linePath;
        private void ShowPath(History path)
        {
            ClearLinePath();
            foreach (HistoryItem pathStop in path.GetList())
            {
                Control letterControl = letterControls[ pathStop.row, pathStop.col];

                //Highlight control
                letterControl.BackColor = Color.Orange;

                //Add control location to a list of points to be painted as a line.
                Point topLeft = letterControl.Location;
                Point centre = new Point(topLeft.X + letterControl.Width / 2, topLeft.Y + letterControl.Height / 2);
                linePath.Add(centre);
            }

            letterControls[path.GetList()[0].row, path.GetList()[0].col].BackColor = Color.Red;

            lettersGrid.Refresh(); //cause repaint
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (boardLastChangedTime.AddMinutes(2)>DateTime.Now)
            {
                if (MessageBox.Show(this,"You changed the board less than 2 minutes ago. Are you sure you want to clear it?","Clear board?",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2 )==DialogResult.No)
                {
                    return;
                }
            }

            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    letterControls[r, c].Text = "";
                    letterControls[r, c].Modifier = CustomTextBox.ScoreModifier.None; 
                }
            }
            lstResults.Items.Clear();
            ClearLinePath();
            letterControls[0, 0].Focus();
        }
        private void ClearLinePath()
        {
            linePath = new List<Point>();
            lettersGrid.Refresh();
        }
        private void lettersGrid_Paint(object sender, PaintEventArgs e)
        {
            if (linePath != null && linePath.Count > 1)
            {
                for (int i = 0; i < linePath.Count - 1; i++)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 3), linePath[i], linePath[i + 1]);
                }
            }
        }
        
        private void cbkSortbyScore_CheckedChanged(object sender, EventArgs e)
        {
            doFindIfReady();
        }


        private void SetLetterModifiers(CustomTextBox.ScoreModifier modifier)
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    letterControls[r, c].Modifier = modifier;
                }
            }
            doFindIfReady();
        }
        private void lblDL_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.DL);
        }

        private void lblTL_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.TL);
        }

        private void lblDW_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.DW);
        }

        private void lblTW_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.TW);
        }

        private void lblMI_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.MI);
        }

        private void lblNoSpecial_Click(object sender, EventArgs e)
        {
            SetLetterModifiers(CustomTextBox.ScoreModifier.None);
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

        private void btnAutoRunGo_Click(object sender, EventArgs e)
        {
            timerAutoAdvance.Enabled = true;
        }

        private void btnAutoRunStop_Click(object sender, EventArgs e)
        {
            timerAutoAdvance.Enabled = false;
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
            loadSelectedDictionary();
        }
        private void chkDictEnable_CheckedChanged(object sender, EventArgs e)
        {
            loadSelectedDictionary();
        }
        private void chkDictUKACD_CheckedChanged(object sender, EventArgs e)
        {
            loadSelectedDictionary();
        }
        private void loadSelectedDictionary()
        {
            if (chkDictOSPD.Checked)
            {
                LoadDictionary(DICTFILE_OSPD);
                doFindIfReady();
            }
            else if(chkDictEnable.Checked)
            {
                LoadDictionary(DICTFILE_ENABLE);
                doFindIfReady();
            }
            else if (chkDictUKACD.Checked)
            {
                LoadDictionary(DICTFILE_UKACD);
                doFindIfReady();
            }
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
            if (chkShuffle.Checked) Shuffle<Word>(FoundWords);
            string fileText = GetMonkeyFile(FoundWords);
            File.WriteAllText("C:\\words.py", fileText);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int score = 0;
            List<Word> randomWords = GetRandomPercent(FoundWords, 25);
            string fileText = GetMonkeyFile(randomWords);
            File.WriteAllText("C:\\words.py", fileText);
            for (int i = 0;i< randomWords.Count;i++)
            {
                score += randomWords[i].Score;
            }
            button1.Text = String.Format("25% of words ({0})", score);
            //MessageBox.Show(String.Format("File saved as c:\\words.py. Total score = {0}", score));
        }
        private List<Word> GetRandomPercent(List<Word> allWords,int percentToInclude)
        {
            Dictionary<int, int> seenIndexes = new Dictionary<int, int>();
            Random r = new Random();
            List<Word> newList = new List<Word>();
            int wordsRequired = allWords.Count * percentToInclude / 100;

            while (newList.Count<wordsRequired)
            {
                int randIdx = r.Next(0, allWords.Count - 1);
                if (!seenIndexes.ContainsKey(randIdx))
                {
                    seenIndexes.Add(randIdx,0);
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
                sb.AppendLine(string.Format(@"time.sleep({0})", (.5+(word.Path.GetList().Count/2.5))/10));
            }

            return sb.ToString();
        }
        
      
    }


}
