using System.Collections.Generic;

namespace WordFinder
{
    class AllOtherTilesDirectionStrategy : WordFindDirectionStrategy
    {
        public override IEnumerable<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel boardModel, History history, object directionData)
        {
            var results = new List<WordFindDirectionStrategyResult>();

            for (int newRow = 0; newRow < boardModel.GridSizeX; newRow++)
            {
                for (int newCol = 0; newCol < boardModel.GridSizeY; newCol++)
                {
                    if (!history.Contains(newRow, newCol) && boardModel.Letters[newRow, newCol] != ' ')
                    {
                        results.Add(new WordFindDirectionStrategyResult() { Row = newRow, Column = newCol });
                    }
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
