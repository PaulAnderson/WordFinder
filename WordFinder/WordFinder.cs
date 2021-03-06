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
        public bool IsQincludeU { get; set; }
        public bool WordMustEndWithSpace { get; set; }
        public bool WordMustHaveSubstitutions { get; set; }

        public WordFindDirectionStrategy directionStrategy { get; set; }
        public StepValidationStrategy stepValidationStrategy { get; set; }
        private Dictionary<String, Word> foundWordsDict; //use for fast lookups to avoid duplicates
        private List<Word> foundWords;

        public WordFinder(BoardLettersModel boardModel, WordList wordList, WordFindDirectionStrategy directionStrategy, StepValidationStrategy stepValidationStrategy = null)
        {
            this.boardModel = boardModel;
            this.wordList = wordList;
            this.directionStrategy = directionStrategy;
            this.stepValidationStrategy = stepValidationStrategy;

            foundWords = new List<Word>();
            foundWordsDict = new Dictionary<String, Word>();
        }

        public List<Word> FindWords()
        {
            //TODO make it work with words that end touching existing words but not continuing them
            foundWords.Clear();
            foundWordsDict.Clear();
            boardModel.BoardLetters = (char[,])boardModel.Letters.Clone();

            foreach (var startingPoint in directionStrategy.GetStartingDirections(boardModel))
            {
                bool substitionsMade = false;
                bool lettersWithoutSubstitions = false;

                char preOverRideLetter = boardModel.Letters[startingPoint.Row, startingPoint.Column];

                var nextLetter = boardModel.Letters[startingPoint.Row, startingPoint.Column];
                if (startingPoint.OverrideLetter.HasValue)
                {
                    nextLetter = startingPoint.OverrideLetter.Value;
                    boardModel.Letters[startingPoint.Row, startingPoint.Column] = nextLetter;
                    substitionsMade = true;
                } else
                {
                    lettersWithoutSubstitions = true;
                }

                if (nextLetter != '?')
                {
                    FindWords(startingPoint.Row, startingPoint.Column, new History(), "", startingPoint.DirectionData, substitionsMade, lettersWithoutSubstitions);
                }
                else
                {
                    for (char ch = 'A'; ch <= 'Z'; ch++)
                    {
                        boardModel.Letters[startingPoint.Row, startingPoint.Column] = ch;
                        FindWords(startingPoint.Row, startingPoint.Column, new History(), "", startingPoint.DirectionData, substitionsMade, lettersWithoutSubstitions);
                    }
                    boardModel.Letters[startingPoint.Row, startingPoint.Column] = '?';
                }
                boardModel.Letters[startingPoint.Row, startingPoint.Column] = preOverRideLetter;

            }

            filterWords();

            boardModel.BoardLetters = null;
            return foundWords;
        }

        public void FindWords(int r, int c, History hist, string prefix, object directionData, bool substitionsMade, bool lettersWithoutSubstitions)
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
                //Check words in whitespace or edge of the board if that setting is used
                bool wordEndOk=true;
                if (WordMustEndWithSpace)
                {
                    var nextDirs = directionStrategy.GetNextDirections(r, c, boardModel, hist, directionData);
                    if (nextDirs.Count()>0)
                    {
                        var next = nextDirs.First(d => true);
                        wordEndOk = char.IsWhiteSpace(boardModel.Letters[next.Row, next.Column]);
                    }
                }
                if (WordMustHaveSubstitutions && !substitionsMade)
                {
                    wordEndOk = false;
                }

                if (stepValidationStrategy !=null && !stepValidationStrategy.ValidateWordEnd(boardModel,prefix,r,c,directionData, substitionsMade, lettersWithoutSubstitions))
                {
                    wordEndOk = false;
                }

                //check if the current path is a valid word
                if (wordEndOk && prefix.Length >= MinWordLength && wordList.Find(prefix, wholeWord: true))
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
                        WordScorer scorer = new WordScorer(boardModel) { includeIntersectionWordScores = true, UseLengthBonus = false };
                        Word newWord = new Word(prefix, hist.Copy());
                        int newWordPathScore = scorer.getWordScore(newWord,false,true); //TODO need to track which letters have been added for wordfinding so the intersects and bonuses are scored properly
                        int oldWordPathScore = scorer.getWordScore(foundWordsDict[prefix],false,true);
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

            if (stepValidationStrategy != null && !stepValidationStrategy.Validate(boardModel, prefix, r, c, directionData))
            {
                //failed validation after adding this letter
                hist.Pop();
                return;
            }

            foreach (var direction in directionStrategy.GetNextDirections(r,c,boardModel,hist,directionData))
            {
                char preOverRideLetter = boardModel.Letters[direction.Row, direction.Column];

                var nextLetter = boardModel.Letters[direction.Row, direction.Column];
                if (direction.OverrideLetter.HasValue)
                {
                    nextLetter = direction.OverrideLetter.Value;
                    boardModel.Letters[direction.Row, direction.Column] = nextLetter;
                    substitionsMade = true;
                } else
                {
                    lettersWithoutSubstitions = true;
                }

                if (nextLetter != '?')
                {
                    FindWords(direction.Row, direction.Column, hist, prefix, direction.DirectionData, substitionsMade, lettersWithoutSubstitions);
                }
                else
                {
                    for (char ch = 'A'; ch <= 'Z'; ch++)
                    {
                        boardModel.Letters[direction.Row, direction.Column] = ch;
                        FindWords(direction.Row, direction.Column, hist, prefix, direction.DirectionData, substitionsMade, lettersWithoutSubstitions);
                    }
                    boardModel.Letters[direction.Row, direction.Column] = '?';
                }
                boardModel.Letters[direction.Row, direction.Column] = preOverRideLetter;
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
