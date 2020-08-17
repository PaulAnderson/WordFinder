using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class CardinalDirectionStrategy : WordFindDirectionStrategy
    {
        List<Direction> Directions;

        public CardinalDirectionStrategy()
        {
            Directions = Direction.get8Directions();
        }

        public override IEnumerable<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel boardModel, History history, object directionData)
        {
            var results = new List<WordFindDirectionStrategyResult>();
            foreach (Direction dir in Directions)
            {
                int newRow = r + dir.RowOffset;
                int newCol = c + dir.ColOffset;
                if (newRow >= 0 && newCol >= 0 && newRow < boardModel.GridSizeX && newCol < boardModel.GridSizeY && !history.Contains(newRow, newCol))
                {
                    results.Add(new WordFindDirectionStrategyResult() { Row = newRow, Column = newCol });
                }
            }
            return results;
        }

        public override IEnumerable<WordFindDirectionStrategyResult> GetStartingDirections(BoardLettersModel board)
        {
            for (int r = 0; r < board.GridSizeX; r++)
            {
                for (int c = 0; c < board.GridSizeY; c++)
                {
                    yield return new WordFindDirectionStrategyResult() { Row = r, Column = c };
                }
            }
        }
    }
}
