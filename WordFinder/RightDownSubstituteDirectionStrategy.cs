using System;
using System.Collections.Generic;
using System.Linq;
namespace WordFinder
{
    class RightDownSubstituteDirectionStrategy : WordFindDirectionStrategy
    {
        
        List<Direction> Directions;
        List<Char> Substitutions;

        public RightDownSubstituteDirectionStrategy(BoardLettersModel SubstitutionLetterBoard)
        {
            Directions = new List<Direction>();
            Directions.Add(new Direction(1, 0));   //E
            Directions.Add(new Direction(0, 1));   //S

            Substitutions = SubstitutionLetterBoard.GetAllLetters().ToList();
        }

        public override IEnumerable<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel boardModel, History history, object directionData)
        {
            //continue the word in the same direction
            var dirData = (DirectionData)directionData;
            Direction dir = dirData.WordDirection;
            int newRow = r + dir.RowOffset;
            int newCol = c + dir.ColOffset;

            //check we are still on the board
            if (newRow < 0 || newCol < 0 || newRow >= boardModel.GridSizeX || newCol >= boardModel.GridSizeY)
            {
                yield break;
            }

            //Substitute letters if the board has a blank space
            if (!Char.IsWhiteSpace(boardModel.Letters[r,c]))
            {
                //Use the letter on the board
                yield return new WordFindDirectionStrategyResult() { Row = newRow, Column = newCol, DirectionData = directionData };
            }
            else
            {
                //Nothing on the board. Substitute in all available letters
                foreach (var subLetter in dirData.SubstitutionLetters)
                {
                    //Create a new dirData with the current substitution letter removed from the candidates
                    var newDirectionData = new DirectionData()
                    {
                        WordDirection = dirData.WordDirection,
                        SubstitutionLetters = dirData.SubstitutionLetters.ToList(),
                    };
                    newDirectionData.SubstitutionLetters.Remove(subLetter);

                    yield return new WordFindDirectionStrategyResult()
                        { Row = newRow, Column = newCol, OverrideLetter = subLetter, DirectionData = directionData };

                }
            }
        }

        public override IEnumerable<WordFindDirectionStrategyResult> GetStartingDirections(BoardLettersModel board)
        {
            //Start words going Right and Down from each position on the board
            for (int r = 0; r < board.GridSizeX; r++)
            {
                for (int c = 0; c < board.GridSizeY; c++)
                {
                    foreach (var direction in Directions)
                    {
                        yield return new WordFindDirectionStrategyResult()
                        { Row = r, Column = c, DirectionData = new DirectionData()
                        {
                            WordDirection = direction,
                            SubstitutionLetters = Substitutions, //Each new starting point can use all the letters
                        }
                        };
                    }
                }
            }
        }

        public class DirectionData
        {
            public Direction WordDirection { get; set; }
            public List<char> SubstitutionLetters { get; set; }
        }
    }
}
