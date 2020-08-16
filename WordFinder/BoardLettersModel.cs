using System;
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
        public BoardLettersModel(int xSize, int ySize) : this()
        {
            GridSizeX = xSize;
            GridSizeY = ySize;
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

    }
}
