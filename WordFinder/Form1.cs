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
        const int minWordLength = 5;
        const int maxWordLength = 8;
        const int gridSize = 4;
        const string dictionaryFile = "ospd.txt";
        private char[,] letters;
        private TextBox[,] letterControls;
        private Words dictWords;
        private List<Word> FoundWords;
        private Dictionary<String,bool> FoundWordsDict; //use for fast lookups to avoid duplicates
        private List<Direction> Directions;

        public Form1()
        {
            InitializeComponent();

            letters = new char[gridSize, gridSize];
            letterControls = new TextBox[gridSize, gridSize];

            //todo - if increase grid size beyond 4, add rows and columns to gridLayoutPanel

            //Set up textboxes and letter array
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    TextBox newTextBox = new TextBox();
                    letterControls[r, c] = newTextBox;
                    letters[r, c] = ' ';
                    lettersGrid.Controls.Add(newTextBox, c, r);
                    newTextBox.Dock = DockStyle.Fill;
                    newTextBox.MaxLength = 1;
                    newTextBox.TextAlign = HorizontalAlignment.Center;
                    newTextBox.TextChanged += NewTextBox_TextChanged;
                    newTextBox.Enter += NewTextBox_Enter;

                }
            }

            //Set up directions
            Directions = new List<Direction>();
            Directions.Add(new Direction(0, -1));  //N
            Directions.Add(new Direction(1, -1));  //NE
            Directions.Add(new Direction(1, 0));   //E
            Directions.Add(new Direction(1, 1));   //SE
            Directions.Add(new Direction(0, 1));   //S
            Directions.Add(new Direction(-1, 1));  //SW
            Directions.Add(new Direction(-1,0));   //W
            Directions.Add(new Direction(-1, -1)); //NW

            dictWords = new Words();

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
            readLetters();
            if (checkBoard()) {
                Application.DoEvents();
                doFind(); //no point waiting, we have all the letters
            }
        }

        private void readLetters()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (!string.IsNullOrWhiteSpace(letterControls[c, r].Text))
                    {
                        letters[r, c] = letterControls[c, r].Text.ToCharArray()[0];
                    } else {
                        letters[r, c] = ' ';
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            FileStream fs = File.Open(Application.StartupPath + "\\..\\..\\ospd.txt", FileMode.Open);
            try
            {
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length >= minWordLength && line.Length <= maxWordLength)
                    {
                        dictWords.AddWord(line);
                    }
                }
            }
            finally
            {
                fs.Close();
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
            FoundWordsDict = new Dictionary<String, bool>(); 
            findWords();

            lstResults.Items.Clear();

            //Sort words longest to shortest. Todo: Take into account letter values and allow setting of board bonuses.
            FoundWords.Sort();
            FoundWords.Reverse();

            foreach (Word word in FoundWords)
            {
                lstResults.Items.Add(word.Text);
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

            //check if the current path is a valid word
            if (prefix.Length >= minWordLength && dictWords.isWordInList(prefix))
            {
                if (!FoundWordsDict.ContainsKey(prefix))
                {
                    FoundWords.Add(new Word(prefix, hist.Copy()));
                    FoundWordsDict.Add(prefix, true);
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
                if (newRow>=0 && newCol>=0 && newRow < gridSize && newCol < gridSize && !hist.Contains(newRow,newCol))
                {
                    findWords(newRow, newCol, hist, prefix);
                }
            }
            hist.Pop();
        }
 
        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLetterColours();
            string word = (string)lstResults.SelectedItem;
            foreach (Word foundWord  in FoundWords)
            {
                if (word.Equals(foundWord.Text))
                {
                    ShowPath(foundWord.Path);
                }
            }
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
                Control letterControl = letterControls[pathStop.col, pathStop.row];

                //Highlight control
                letterControl.BackColor = Color.Orange;

                //Add control location to a list of points to be painted as a line.
                Point topLeft = letterControl.Location;
                Point centre = new Point(topLeft.X + letterControl.Width / 2, topLeft.Y + letterControl.Height / 2);
                linePath.Add(centre);
            }
            
            letterControls[path.GetList()[0].col, path.GetList()[0].row].BackColor = Color.Red;

            lettersGrid.Refresh(); //cause repaint
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    letterControls[r, c].Text = "";
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
            if (linePath!=null && linePath.Count>1)
            {
                for(int i=0;i<linePath.Count-1;i++)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black,3), linePath[i],linePath[i+1]);
                }
            }
        }
    }

    class HistoryItem
    {
        public int row { get; set; }
        public int col { get; set; }
        public HistoryItem(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class History
    {
        private List<HistoryItem> histList;
        public History()
        {
            histList = new List<HistoryItem>();
        }
        public void Push(int row, int col)
        {
            histList.Add(new HistoryItem(row, col));
        }
        public HistoryItem Pop()
        {
            if (histList != null && histList.Count>0)
            {
                int lastIndex = histList.Count - 1;
                HistoryItem item = histList[lastIndex];
                histList.RemoveAt(lastIndex);
           
            return item;
            }
            return null;
        }
        public bool Contains(int row, int col)
        {
            foreach (HistoryItem item in histList)
            {
                if (item.row == row && item.col == col)
                {
                    return true;
                }
            }
            return false;
        }
        public int Count {
            get
            {
                return histList.Count();
            }
        }
        public List<HistoryItem> GetList()
        {
            return histList;
        }
        public History Copy()
        {
            History newHist = new History();
            foreach (HistoryItem item in GetList())
            {
                newHist.Push(item.row, item.col);
            }
            return newHist;
        }
    }

    class Direction {
        public int RowOffset { get; set; }
        public int ColOffset { get; set; }
        public Direction(int rowOffset, int colOffset)
        {
            this.RowOffset = rowOffset;
            this.ColOffset = colOffset;
        }
    }
    class Word : IComparable 
    {
        public string Text { get; set; }
        public History Path { get; set; }
        public Word(string Text,History Path)
        {
            this.Text = Text;
            this.Path = Path;
        }

        public int CompareTo(object obj)
        {
            return Text.Length.CompareTo(((Word)obj).Text.Length);
        }
    }
}
