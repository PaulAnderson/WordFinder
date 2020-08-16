﻿using System;
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

        private Dictionary<String, Word> foundWordsDict; //use for fast lookups to avoid duplicates
        private List<Word> foundWords;

        public WordFinder(BoardLettersModel boardModel, WordList wordList)
        {
            this.boardModel = boardModel;
            this.wordList = wordList;

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
            prefix += boardModel.Letters[r, c];

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

            //Explore alternate paths from this location
            for (int newRow = 0; newRow < boardModel.GridSizeX; newRow++)
            {
                for (int newCol = 0; newCol < boardModel.GridSizeY; newCol++)
                {
                    if (!(newRow == r && newCol == c) && !hist.Contains(newRow, newCol) && boardModel.Letters[newRow, newCol] != ' ')
                    {
                        if (boardModel.Letters[newRow, newCol] != '?')
                        {
                            FindWords(newRow, newCol, hist, prefix);
                        }
                        else
                        {
                            for (char ch = 'A'; ch <= 'Z'; ch++)
                            {
                                boardModel.Letters[newRow, newCol] = ch;
                                FindWords(newRow, newCol, hist, prefix);
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
            for (var i = foundWords.Count - 1; i >= 0; i--)
            {
                if ((prefix?.Length > 0 &&
                    !foundWords[i].Text.StartsWith(prefix))
                || (suffix?.Length > 0 &&
                    !foundWords[i].Text.EndsWith(suffix))
                || (infix?.Length > 0 &&
                    !foundWords[i].Text.Contains(infix))
                    )
                {
                    foundWords.RemoveAt(i);
                }
            }
        }
    }
}