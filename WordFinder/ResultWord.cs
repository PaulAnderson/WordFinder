using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; set; }
    public History Path { get; set; }
    public int Score { get; set; } //populated when using score comparitor
    public Word(string Text, History Path)
    {
        this.Text = Text;
        this.Path = Path;
    }

}
class WordLengthComparer : IComparer<Word>
{
    public int Compare(Word x, Word y)
    {
        return x.Text.Length.CompareTo(y.Text.Length);
    }
}
class ScoredWordComparer : IComparer<Word>
{
    //Scoring:
    //5 Letters: +3
    //6 Letters: +6
    //7 Letters: +10
    //8 Letters: +15
    //9 Letters?
    // 2 points letters: L N
    // 3 points letters: H M C Y
    // 4 points letters: B F V W P
    // 5 points letters: K
    // 8 points letters: J X
    // 10 points letters: Q Z

    private char[,] letters;
    private int[,] letterMultipliers;
    private int[,] wordMultipliers;

    public ScoredWordComparer(char[,] letters, int[,] letterMultipliers, int[,] wordMultipliers)
    {
        this.letters = letters;
        this.letterMultipliers = letterMultipliers;
        this.wordMultipliers = wordMultipliers;
    }
    private int getWordScore(Word word)
    {
        int letterTotal = 0;
        int wordMultiplier = 1;

        foreach (HistoryItem item in word.Path.GetList())
        {
            char letter;
            int letterValue = 1;
            int letterMultiplier = 1;

            //get letter for location
            letter = letters[item.row, item.col];

            //get letter value
            switch (letter)
            {
                case 'L':
                case 'N':
                    letterValue = 2;
                    break;
                case 'H':
                case 'M':
                case 'C':
                case 'Y':
                    letterValue = 3;
                    break;
                case 'B':
                case 'F':
                case 'V':
                case 'W':
                case 'P': //'B F V W P'
                    letterValue = 4;
                    break;
                case 'K':
                    letterValue = 5;
                    break;
                case 'J':
                case 'X':
                    letterValue = 8;
                    break;
                case 'Q':
                case 'Z':
                    letterValue = 8;
                    break;
                default:
                    letterValue = 1;
                    break;
            }

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
        }
        switch (word.Text.Length)
        {
            case 5:
                letterTotal += 3;
                break;
            case 6:
                letterTotal += 6;
                break;
            case 7:
                letterTotal += 10;
                break;
            case 8:
                letterTotal += 15;
                break;

        }
        return letterTotal * wordMultiplier;
    }
    public int Compare(Word x, Word y)
    {
        x.Score = getWordScore(x);
        y.Score = getWordScore(y);
        return x.Score.CompareTo(y.Score);
    }
}

