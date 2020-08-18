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
    public class BoardLettersModelTests
    {
        [Fact]
        void PlaceWord_WhenCalled_PlacesWord()
        {
            //arrange
            var board = new BoardLettersModel(4,4);

            //act
            board.PlaceWord(0, 0, "TEST", new Direction(0, 1));

            //assert
            Assert.Equal('T', board.Letters[0, 0]);
            Assert.Equal('E', board.Letters[0, 1]);
            Assert.Equal('S', board.Letters[0, 2]);
            Assert.Equal('T', board.Letters[0, 3]);
        }

        [Fact]
        void PlaceWord_WhenCalledWithLocation_PlacesWordInCorrectLocation()
        {
            //arrange
            var board = new BoardLettersModel(10, 10);

            //act
            board.PlaceWord(3, 5, "HELLO", new Direction(0, 1));

            //assert
            Assert.Equal('H', board.Letters[3, 5]);
            Assert.Equal('E', board.Letters[3, 6]);
            Assert.Equal('L', board.Letters[3, 7]);
            Assert.Equal('L', board.Letters[3, 8]);
            Assert.Equal('O', board.Letters[3, 9]);

        }

        [Fact]
        void PlaceWord_WhenCalledWithDirection_PlacesWordInCorectDirection()
        {
            //arrange
            var board = new BoardLettersModel(4, 4);

            //act
            board.PlaceWord(0, 0, "TEST", new Direction(1, 0));

            //assert
            Assert.Equal('T', board.Letters[0, 0]);
            Assert.Equal('E', board.Letters[1, 0]);
            Assert.Equal('S', board.Letters[2, 0]);
            Assert.Equal('T', board.Letters[3, 0]);
        }

        [Fact]
        void PlaceWord_WhenWordTooLong_Truncates()
        {
            //arrange
            var board = new BoardLettersModel(4, 4);

            //act
            board.PlaceWord(0, 0, "LONGWORD", new Direction(0, 1));

            //assert
            Assert.Equal('L', board.Letters[0, 0]);
            Assert.Equal('O', board.Letters[0, 1]);
            Assert.Equal('N', board.Letters[0, 2]);
            Assert.Equal('G', board.Letters[0, 3]);
        }
    }
}
