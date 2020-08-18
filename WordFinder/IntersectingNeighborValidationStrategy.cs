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

    }
}
