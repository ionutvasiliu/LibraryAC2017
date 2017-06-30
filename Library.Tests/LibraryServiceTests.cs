using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAC.Models;
using LibraryAC.Data.Entities;
using LibraryAC.Services;

namespace Library.Tests
{
    [TestClass]
    public class LibraryServiceTests
    {
        private IScoreService _scoreService;

        [TestInitialize]
        public void Init()
        {
            _scoreService = new ScoreService();
        }

        [TestMethod]
        public void ComputeUserScore_Called_UserScoreIsUpdated()
        {
            //Arrange
            var book = new Book()
            {
                Id = 1,
                Score = 1
            };

            var user = new ApplicationUser()
            {
                Score = 1
            };


            //Act
            int result = _scoreService.ComputeScore(book.Score, user.Score);


            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ComputeUserScore_NegativeBookScore_ReturnsUserScore()
        {
            //Arrange
            var book = new Book()
            {
                Id = 1,
                Score = -1
            };

            var user = new ApplicationUser()
            {
                Score = 1
            };

            //Act
            int result = _scoreService.ComputeScore(book.Score, user.Score);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ComputeUserScore_NegativeUserScore_ReturnsZero()
        {
            //Arrange
            var book = new Book()
            {
                Id = 1,
                Score = 1
            };

            var user = new ApplicationUser()
            {
                Score = -1
            };

            //Act
            int result = _scoreService.ComputeScore(book.Score, user.Score);

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
