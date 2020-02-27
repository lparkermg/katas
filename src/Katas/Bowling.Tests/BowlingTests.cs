using Bowling.Core;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private readonly Calculator _scoringCalculator = new Calculator();
        
        [TestCase("00 00 00 00 00 00 00 00 00 000", 0)]
        [TestCase("11 11 11 11 11 11 11 11 11 111", 21)]
        [TestCase("12 12 12 12 12 12 12 12 12 121", 31)]
        public void BowlingCalculator_Given10FramesWithCorrectNumbers_ShouldReturnExpectedResult(string frames, int expectedScore)
        {
            var score = _scoringCalculator.Calculate(frames);
            Assert.AreEqual(expectedScore, score);
        }
    }
}