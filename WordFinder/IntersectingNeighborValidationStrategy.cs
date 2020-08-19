using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class IntersectingNeighborValidationStrategy : StepValidationStrategy
    {
        WordList wordList;
        public IntersectingNeighborValidationStrategy(WordList wordList)
        {
            this.wordList = wordList;
        }
        public override bool Validate(BoardLettersModel boardModel, string prefix, int r, int c, object directionData)
        {
            //Get Intersecting word
            var data = (RightDownSubstituteDirectionStrategy.DirectionData) directionData;
            Direction wordDirection = data.WordDirection;
            Direction intersectDirection = new Direction(wordDirection.ColOffset, wordDirection.RowOffset);
            var word = boardModel.ReadWord(r, c, intersectDirection);

            //return true if no intersection with another word.
            if (word.Length <= 1) return true;

            //Validate intersecting word
            return wordList.Find(word, wholeWord: true);
        }

        public override bool ValidateWordEnd(BoardLettersModel boardModel, string prefix, int r, int c, object directionData)
        {
            //next letter must be whitespace or end of board
            //must intersect or neighbor tiles on board somewhere

            //Validate last letter
            var validateResult = Validate(boardModel, prefix, r, c, directionData);
            if (!validateResult) return false;

            //Get direction data
            var data = (RightDownSubstituteDirectionStrategy.DirectionData)directionData;
            Direction wordDirection = data.WordDirection;

            //Walk back through word and get intersecting words
            int intersects = GetIntersects(boardModel,prefix,r,c,wordDirection);

            //Get next letter after wrod end if any
            r += wordDirection.RowOffset;
            c += wordDirection.ColOffset;
            var wordEndOk = true;
            if (r < boardModel.GridSizeX && c < boardModel.GridSizeY && !char.IsWhiteSpace(boardModel.Letters[r, c]))
            {
                wordEndOk = false;
            }

            return (intersects > 0 && wordEndOk);
        }

        private int GetIntersects(BoardLettersModel boardModel, string prefix, int r, int c, Direction wordDirection)
        {
            Direction intersectDirection = new Direction(wordDirection.ColOffset, wordDirection.RowOffset);

            var intersects = 0;
            for (var i = 0; i < prefix.Length; i++)
            {
                var word = boardModel.ReadWord(r, c, intersectDirection);
                if (word.Length > 1)
                {
                    intersects++;
                }
                r -= wordDirection.RowOffset;
                c -= wordDirection.ColOffset;
            }
            return intersects;
        }
    }
}
