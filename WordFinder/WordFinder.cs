using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class WordFinder
    {
        public BoardLettersModel boardModel { get; set; }

        public WordList wordList { get; set; }

        public string prefix { get; set; }
        public string suffix { get; set; }
        public string infix  { get; set; }

        public int MinWordLength { get; set; } = 2;
        public int MaxWordLength { get; set; } = 15;
        public bool IsQincludeU { get; set; }

        public WordFindDirectionStrategy directionStrategy { get; set; }

        private Dictionary<String, Word> foundWordsDict; //use for fast lookups to avoid duplicates
        private List<Word> foundWords;

        public WordFinder(BoardLettersModel boardModel, WordList wordList, WordFindDirectionStrategy directionStrategy)
        {
            this.boardModel = boardModel;
            this.wordList = wordList;
            this.directionStrategy = directionStrategy;

            foundWords = new List<Word>();
            foundWordsDict = new Dictionary<String, Word>();
        }

        public List<Word> FindWords()
        {
            foundWords.Clear();
            foundWordsDict.Clear();

            for (int r = 0; r < boardModel.GridSizeX; r++)
            {
                for (int c = 0; c < boardModel.GridSizeY; c++)
                {
                    FindWords(r, c, new History(), "");
                }
            }
            filterWords();
            return foundWords;
        }

        public void FindWords(int r, int c, History hist, string prefix)
        {
            //Add to history trail and word

            hist.Push(r, c);

            var letter = boardModel.Letters[r, c];
            prefix += letter;

            if (IsQincludeU && letter == 'Q')
            {
                prefix += 'U';
            }

            if (!wordList.Find(prefix, wholeWord: false))
            {
                //prefix not in dictionary, no point continuing this way
                hist.Pop();
                return;
            }

            //only return words passing through one of the mandatory tiles, if enabled.
            if (!boardModel.UsingMandatoryTiles || hist.Overlaps(boardModel.MandatoryLocations))
            {

                //check if the current path is a valid word
                if (prefix.Length >= MinWordLength && wordList.Find(prefix, wholeWord: true))
                {
                    if (!foundWordsDict.ContainsKey(prefix))
                    {
                        Word newWord = new Word(prefix, hist.Copy());
                        foundWords.Add(newWord);
                        foundWordsDict.Add(prefix, newWord);
                    }
                    else
                    {
                        //found the same word a second time, check to see which one has a higher score, replace if new word has higher score
                        WordScorer scorer = new WordScorer(boardModel);
                        Word newWord = new Word(prefix, hist.Copy());
                        int newWordPathScore = scorer.getWordScore(newWord);
                        int oldWordPathScore = scorer.getWordScore(foundWordsDict[prefix]);
                        if (newWordPathScore > oldWordPathScore)
                        {
                            foundWordsDict[prefix].AlternatePaths.Add(foundWordsDict[prefix].Path);
                            foundWordsDict[prefix].Path = newWord.Path;
                        }
                        else
                        {
                            foundWordsDict[prefix].AlternatePaths.Add(newWord.Path);
                        }
                    }
                }
            }

            //stop recursion if we are at max length
            if (hist.Count == MaxWordLength)
            {
                hist.Pop();
                return;
            }

            foreach (var direction in directionStrategy.GetNextDirections(r,c,boardModel,hist))
            {
                char preOverRideLetter = boardModel.Letters[direction.Row, direction.Column];

                var nextLetter = boardModel.Letters[direction.Row, direction.Column];
                if (direction.OverrideLetter.HasValue)
                {
                    nextLetter = direction.OverrideLetter.Value;
                    boardModel.Letters[direction.Row, direction.Column] = nextLetter;
                }

                if (nextLetter != '?')
                {
                    FindWords(direction.Row, direction.Column, hist, prefix);
                }
                else
                {
                    for (char ch = 'A'; ch <= 'Z'; ch++)
                    {
                        boardModel.Letters[direction.Row, direction.Column] = ch;
                        FindWords(direction.Row, direction.Column, hist, prefix);
                    }
                    boardModel.Letters[direction.Row, direction.Column] = '?';
                }
                preOverRideLetter = boardModel.Letters[direction.Row, direction.Column];
            }

            hist.Pop();
        }

        private void filterWords()
        {
            for (var i = foundWords.Count - 1; i >= 0; i--)
            {
                if ((prefix?.Length > 0 &&
                    !foundWords[i].Text.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                || (suffix?.Length > 0 &&
                    !foundWords[i].Text.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase))
                || (infix?.Length > 0 &&
                    !foundWords[i].Text.Contains(infix.ToUpperInvariant()))
                    )
                {
                    foundWords.RemoveAt(i);
                }
            }
        }
    }
}
