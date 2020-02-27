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

        [Test]
        public void BowlingCalculator_GivenConsecutiveStrikes_ShouldReturn300()
        {
            var score = _scoringCalculator.Calculate("x x x x x x x x x xxx");
            Assert.AreEqual(300, score);
        }

        [Test]
        public void BowlingCalculator_GivenAMixOfStrikesAndNumberScores_ShouldReturnTheCorrectResult()
        {
            var score = _scoringCalculator.Calculate("12 x 81 42 x 23 17 32 21 123");
            Assert.AreEqual(79, score);
        }

        [Test]
        public void BowlingCalculator_GivenUpperCaseStikes_ShouldReturnTheCorrectResult()
        {
            var score = _scoringCalculator.Calculate("12 X 81 42 X 23 17 32 21 123");
            Assert.AreEqual(79, score);
        }
    }
}