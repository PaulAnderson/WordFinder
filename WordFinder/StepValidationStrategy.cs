namespace WordFinder
{
    abstract class StepValidationStrategy
    {
        public abstract bool Validate(BoardLettersModel boardModel, string prefix, int r, int c, object directionData);
    }
}