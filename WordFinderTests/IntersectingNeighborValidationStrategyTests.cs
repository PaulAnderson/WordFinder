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
    public class IntersectingNeighborValidationStrategyTests
    {
        string testDictionaryFile =
                @"AA
                TEST
                HELLO
                ";

        [Theory]
        [MemberData(nameof(IntersectionWordFoundData))]
        public void IntersectionWordFound(int StartRow1, int StartColumn1, string boardWord1, int StartRow2, int StartColumn2, string boardWord2, int r, int c, Direction direction, bool expectedResult)
        {
            //arrange
            var MockFileService = new Mock<FileService>();
            MockFileService.Setup(f => f.OpenFileStream(It.IsAny<string>())).Returns((() => TestFormatters.StringToStream(testDictionaryFile)));

            var wordList = new WordList(MockFileService.Object) { };
            wordList.LoadDictionary(DictionaryEdition.ENABLE);

            var validationStrategy = new IntersectingNeighborValidationStrategy(wordList);

            var boardModel = new BoardLettersModel(16, 16);
            boardModel.PlaceWord(StartRow1, StartColumn1, boardWord1, new Direction(0, 1));
            boardModel.PlaceWord(StartRow2, StartColumn2, boardWord2, new Direction(1, 0));

            var directionData = new RightDownSubstituteDirectionStrategy.DirectionData()
            {
                WordDirection = direction
            };

            //act
            var result = validationStrategy.Validate(boardModel, "TEST", r, c, directionData);

            //assert
            Assert.Equal(expectedResult, result);
        }
        public static IEnumerable<Object[]> IntersectionWordFoundData =>
         new List<object[]>
        {
            new object[] {10,0,"HELLO",9,1,"TEST",10,1,new Direction(0,1), true},
            new object[] {10,0,"HELLO",9,1,"TEST",10,1,new Direction(1,0), true},
            new object[] {10,0,"HELLO",1,10,"NO INTERSECT",10,1,new Direction(0,1), true},
            new object[] {10,0,"HELLO",6,2,"TEST",10,2,new Direction(0,1), false},

        };
    }
}
