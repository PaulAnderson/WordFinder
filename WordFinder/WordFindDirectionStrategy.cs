using System.Collections.Generic;

namespace WordFinder
{
    abstract class WordFindDirectionStrategy
    {
        public abstract List<WordFindDirectionStrategyResult> GetNextDirections(int r, int c, BoardLettersModel board, History history);
    }
    class WordFindDirectionStrategyResult
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char? OverrideLetter { get; set; }

        public override string ToString() => $"Row:{Row}, Col: {Column}, OverrideLetter: {OverrideLetter}";
    }
}
