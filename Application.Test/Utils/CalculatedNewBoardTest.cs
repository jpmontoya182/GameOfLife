using Application.Common.Interfaces;
using Application.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Utils
{
    public class CalculatedNewBoardTest
    {
        private CalculatedNewBoard _calculatedNewBoard;

        [SetUp]
        public void Setup()
        {
            _calculatedNewBoard = new CalculatedNewBoard();         
        }

        [Test]
        public void CalculatedValidPositions_CalculateFirstPosition_OK() 
        {
            // Arrange
            _calculatedNewBoard.totalLenghtY = 4;
            _calculatedNewBoard.totalLenghtX = 3;
            // Act
            var result = _calculatedNewBoard.CalculatedValidPositions(0, 0);

            // Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
