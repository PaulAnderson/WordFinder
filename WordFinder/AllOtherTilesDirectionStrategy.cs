using System.Collections.Generic;

namespace WordFinder
{
    class AllOtherTilesDirectionStrategy : WordFindDirectionStrategy
    {
        public override List<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel boardModel, History history)
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
    }
}
