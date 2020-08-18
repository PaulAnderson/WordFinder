using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordFinder;
using Xunit;


namespace WordFinderTests
{
    
    public class RightDownSubsitionDirectionStrategyTests
    {
        string testDictionaryFile =
                @"AA
                TEST
                HELLO
                ";
        [Theory]
        [MemberData(nameof(WordFoundUsingSubstituteLettersData))]
        public void WordFoundUsingSubstituteLetters(int StartRow,int StartColumn, bool horizonal, string boardWord, string subLetters, string expectedWord, bool expectedToFind)
        {
            //arrange
            var MockFileService = new Mock<FileService>();
            MockFileService.Setup(f => f.OpenFileStream(It.IsAny<string>())).Returns((() => TestFormatters.StringToStream(testDictionaryFile)));

            var wordList = new WordList(MockFileService.Object) { };
            wordList.LoadDictionary(DictionaryEdition.ENABLE);

            var boardModel = new BoardLettersModel(16, 16);
            boardModel.PlaceWord(0, 0, boardWord, horizonal ? new Direction(0, 1) : new Direction(1,0));

            var substituionLetters = new BoardLettersModel(1, 7);
            substituionLetters.PlaceWord(0,0, subLetters, new Direction(0,1));

            var wordFinder = new WordFinder.WordFinder(boardModel, wordList, new RightDownSubstituteDirectionStrategy(substituionLetters));

            //act
            List<Word> words = wordFinder.FindWords();

            //assert
            var word = words.Find(w => w.Text == expectedWord);

            if (expectedToFind)
            {
                Assert.NotNull(word);
            } else {
                Assert.Null(word);
            }
        }
        public static IEnumerable<Object[]> WordFoundUsingSubstituteLettersData =>
         new List<object[]>
        {
            new object[] { 0, 0, true, "T  T","ABC","TEST", false },
            new object[] { 0, 0, true, "T  T","ES","TEST", true },
            new object[] { 0, 0, false, "T  T","ES","TEST", true },
            new object[] { 3, 1, true, "T  T","ES","TEST", true },
            new object[] { 0, 0, true, "T","EST","TEST", true },
            new object[] { 0, 0, true, "TE T","EST","TEST", true },
            new object[] { 0, 0, true, "TE T","ABC?","TEST", true },
            new object[] { 0, 0, true, "HELLO A T ST WORD","QZOUEFA","TEST", true },

        };
    }
}
