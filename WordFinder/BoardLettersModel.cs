﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class BoardLettersModel
    {
        public int GridSizeX { get; set; } = 4;
        public int GridSizeY { get; set; } = 4;

        public DateTime LastChangedTime;

        public bool UsingMandatoryTiles => (MandatoryLocations?.Count ?? 0) > 0;
        public List<HistoryItem> MandatoryLocations { get; set; } = new List<HistoryItem>();
        public int LetterCount => CountLetters();
        public char[,] Letters;

        public int[,] LetterMultipliers;
        public int[,] WordMultipliers;

        public BoardLettersModel()
        {
            Initialize();
        }
        public BoardLettersModel(int xSize, int ySize) 
        {
            GridSizeX = xSize;
            GridSizeY = ySize;
            Initialize();
        }

        public void Initialize()
        {
            Letters = new char[GridSizeX, GridSizeY];
            LetterMultipliers = new int[GridSizeX, GridSizeY];
            WordMultipliers = new int[GridSizeX, GridSizeY];

            for (int r = 0; r < GridSizeX; r++)
            {
                for (int c = 0; c < GridSizeY; c++)
                {
                    Letters[r, c] = ' ';
                }
            }
        }

        private int CountLetters()
        {
            var foundLetters = 0;
            for (int r = 0; r < GridSizeX; r++)
            {
                for (int c = 0; c < GridSizeY; c++)
                {
                    if (Char.IsLetter(Letters[r, c]))
                    {
                        foundLetters++;
                    }
                }
            }
            return foundLetters;
        }


        internal IEnumerable<char> GetAllLetters()
        {
            for (int r = 0; r < GridSizeX; r++)
            {
                for (int c = 0; c < GridSizeY; c++)
                {
                    if (!Char.IsWhiteSpace(Letters[r, c]))
                    {
                        yield return Letters[r, c];
                    }
                }
            }
        }

        internal void PlaceWord(int startRow, int startColumn, string word, Direction direction)
        {
            int r = startRow;
            int c = startColumn;

            for (var i = 0; i < word.Length; i++)
            {
                if (r >= GridSizeX || c >= GridSizeY || r < 0 || c < 0) break;

                Letters[r, c] = char.Parse(word.Substring(i, 1));

                r += direction.RowOffset;
                c += direction.ColOffset;
            }
        }

        public string ReadWord(int startRow, int startColumn, Direction direction)
        {
            int r, c;
            (r, c) = FindStartOfWord(startRow, startColumn, direction);

            string s = "";
            while(true)
            {
                if (r >= GridSizeX || c >= GridSizeY || r < 0 || c < 0) break;
                if (char.IsWhiteSpace(Letters[r, c])) break;

                s += Letters[r, c];

                r += direction.RowOffset;
                c += direction.ColOffset;
            }

            return s;
        }

        (int, int) FindStartOfWord(int startRow, int startColumn, Direction direction)
        {
            int r = startRow;
            int c = startColumn;

            while (true)
            {
                if (r >= GridSizeX || c >= GridSizeY || r < 0 || c < 0) break;
                if (char.IsWhiteSpace(Letters[r, c])) break;

                r -= direction.RowOffset;
                c -= direction.ColOffset;
            }

            r += direction.RowOffset;
            c += direction.ColOffset;

            return (r, c);
         }

        internal void SetAllLettersMandatory()
        {
            MandatoryLocations.Clear();
            for (int r = 0; r < GridSizeX; r++)
            {
                for (int c = 0; c < GridSizeY; c++)
                {
                    if (!Char.IsWhiteSpace(Letters[r, c]))
                    {
                        MandatoryLocations.Add(new HistoryItem(r, c));
                    }
                }
            }
        }
    }
}
