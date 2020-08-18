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
        [Fact]
        public void WordFoundUsingSubstituteLetters()
        {
            //arrange
            var testFile = 
                @"AA
                TEST
                HELLO
                ";

            var MockFileService = new Mock<FileService>();
            MockFileService.Setup(f => f.OpenFileStream(It.IsAny<string>())).Returns((() => TestFormatters.StringToStream(testFile)));

            var wordList = new WordList(MockFileService.Object) { };
            wordList.LoadDictionary(DictionaryEdition.ENABLE);

            var boardModel = new BoardLettersModel(5, 5);
            boardModel.Letters[0, 0] = 'T';
            boardModel.Letters[0, 3] = 'T';

            var substituionLetters = new BoardLettersModel(1, 7);
            substituionLetters.Letters[0, 0] = 'E';
            substituionLetters.Letters[0, 1] = 'S';

            var wordFinder = new WordFinder.WordFinder(boardModel, wordList, new RightDownSubstituteDirectionStrategy(substituionLetters));

            //act
            List<Word> words = wordFinder.FindWords();

            //assert
            var word = words.Find(w => w.Text == "TEST");

            Assert.NotNull(word);
        }

    }
}
