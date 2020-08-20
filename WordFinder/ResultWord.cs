using System;
using System.Collections.Generic;
using WordFinder;

class Word
{
    public string Text { get; set; }
    public History Path { get; set; }
    public List<History> AlternatePaths { get; set; }
    public int Score { get; set; } //populated when using score comparitor
    public Word(string Text, History Path)
    {
        this.Text = Text;
        this.Path = Path;
        this.AlternatePaths = new List<History>();
    }
    public override string ToString()
    {
        return Text + ": " + Path.ToString();
        //return base.ToString();
    }
}
class WordScorer
{
    //Scoring:
    //5 Letters: +3
    //6 Letters: +6
    //7 Letters: +10
    //8 Letters: +15
    //9 Letters: +20 (ie SUPERPORT)
    //9+Letters: +25 (ie SUPERPOWER,SUPERPOWERS)

    // 2 points letters: L N
    // 3 points letters: H M C Y
    // 4 points letters: B F V W P
    // 5 points letters: K
    // 8 points letters: J X
    // 10 points letters: Q Z

    private char[,] letters;
    private int[,] letterMultipliers;
    private int[,] wordMultipliers;

    public WordScorer(BoardLettersModel boardModel)
    {
        this.letters = boardModel.Letters;
        this.letterMultipliers = boardModel.LetterMultipliers;
        this.wordMultipliers = boardModel.WordMultipliers;
    }
    public WordScorer(char[,] letters, int[,] letterMultipliers, int[,] wordMultipliers)
    {
        this.letters = letters;
        this.letterMultipliers = letterMultipliers;
        this.wordMultipliers = wordMultipliers;
    }
    public int getWordScore(Word word)
    {
        int letterTotal = 0;
        int wordMultiplier = 1;
        int wordPosition = 0;

        foreach (HistoryItem item in word.Path.GetList())
        {
            char letter;
            int letterValue = 1;
            int letterMultiplier = 1;

            //get letter for location
            letter = letters[item.row, item.col];

            if (char.IsWhiteSpace(letter))
            {
                if (wordPosition < word.Text.Length - 1) { 
                    letter = word.Text.Substring(wordPosition, 1).ToCharArray()[0];
                }
            }

            //get letter value
            letterValue = getLetterValue(letter);

            //Get letter multiplier if any
            if (letterMultipliers[item.row, item.col] > 1)
            {
                letterMultiplier = letterMultipliers[item.row, item.col];
            }
            else
            {
                letterMultiplier = 1;
            }

            //Get word multiplier if any - combine with any other word multipliers
            if (wordMultipliers[item.row, item.col] > 1)
            {
                wordMultiplier *= wordMultipliers[item.row, item.col];
            }
            letterTotal += (letterValue * letterMultiplier);

            wordPosition++;
        }

        return letterTotal * wordMultiplier + getLengthBonus(word.Text.Length); //Word Length bonus applied after multipliers
    }
    private int getLetterValue(char letter)
    {
        int letterValue = 1;
        switch (letter)
        {
            case 'L':
            case 'N':
            case 'D':
            case 'U':
                letterValue = 2;
                break;
            case 'H':
            case 'Y':
            case 'G':
                letterValue = 3;
                break;
            case 'B':
            case 'C':
            case 'F':
            case 'M':
            case 'W':
            case 'P':
                letterValue = 4;
                break;
            case 'K':
            case 'V':
                letterValue = 5;
                break;
            case 'X':
                letterValue = 8;
                break;
            case 'J':
            case 'Q':
            case 'Z':
                letterValue = 10;
                break;
            default:
                letterValue = 1;
                break;
        }
        return letterValue;
    }
    private int getLengthBonus(int WordLength)
    {
        switch (WordLength)
        {
            case 5:
                return 3;
            case 6:
                return 6;
            case 7:
                return 10;
            case 8:
                return 15;
            case 9:
                return 20;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
                return 25;
        }
        return 0;
    }
    public void SetWordScores(List<Word> words)
    {
        foreach (Word word in words)
        {
            word.Score = getWordScore(word);
        }
    }
}
class WordLengthComparer : IComparer<Word>
{
    public int Compare(Word x, Word y)
    {
        int result = x.Text.Length.CompareTo(y.Text.Length);
        if (result==0)
        {
            //if words are the same length, sort alphabetically
            result = string.Compare(y.Text, x.Text, StringComparison.InvariantCultureIgnoreCase);
        }
        return result;
    }
}
/// <summary>
/// Compares word based  on word score. Must use wordscored on words first.
/// </summary>
class ScoredWordComparer : IComparer<Word>
{
    public int Compare(Word x, Word y)
    {
        int result =  x.Score.CompareTo(y.Score);
        if (result == 0)
        {
            //if words are the same score, sort by length
            result = y.Text.Length.CompareTo(x.Text.Length);
            if (result == 0)
            {
                //words have same score and are the same length, sort alphabetically
                result = string.Compare(y.Text, x.Text, StringComparison.InvariantCultureIgnoreCase);
            }
        }
            return result;
    }
}
/// <summary>
/// Compares word based  on word score,divided by word complexity (no of letters, no of changes of direction) Must use wordscored on words first.
/// </summary>
class ScoredComplexWordComparer : IComparer<Word>
{
    private int GetAdjustedScore(Word x)
    {
        int newScore = x.Score * 10;
        int dirChanges = x.Path.DirectionChanges();
        int crossOvers = x.Path.CrossOvers();
        if (dirChanges > 0) newScore -= (dirChanges*10);
        if (crossOvers > 0) newScore -= (crossOvers*40);
        return newScore;
    }
    public int Compare(Word x, Word y)
    {
        int xScore = GetAdjustedScore(x);
        int yScore = GetAdjustedScore(y);
        int result = (xScore.CompareTo(yScore));
        return result;
    }
}
/// <summary>
/// Compares words based on path taken (compares path historyItems), so words starting on the same tile are grouped together
/// </summary>
class WordPathComparer : IComparer<Word>
{
    public int Compare(Word x, Word y)
    {
        return x.Path.CompareTo(y.Path);
    }
}
