namespace WordFinder
{
    abstract class StepValidationStrategy
    {
        public abstract bool Validate(BoardLettersModel boardModel, string prefix, int r, int c, object directionData);
        public abstract bool ValidateWordEnd(BoardLettersModel boardModel, string prefix, int r, int c, object directionData);

    }
}