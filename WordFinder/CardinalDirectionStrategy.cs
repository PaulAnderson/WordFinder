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

        public override List<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel boardModel, History history)
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
    }
}
