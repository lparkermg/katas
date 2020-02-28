using Bowling.Core;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private readonly Calculator _scoringCalculator = new Calculator();
        [TestCase("00 00 00 00 00 00 00 00 00 00", 0)]
        [TestCase("11 11 11 11 11 11 11 11 11 11", 20)]
        [TestCase("12 12 12 12 12 12 12 12 12 12", 30)]
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
            var score = _scoringCalculator.Calculate("12 x 81 42 x 23 17 32 21 12");
            Assert.AreEqual(76, score);
        }

        [Test]
        public void BowlingCalculator_GivenUpperCaseStikes_ShouldReturnTheCorrectResult()
        {
            var score = _scoringCalculator.Calculate("12 X 81 42 X 23 17 32 21 12");
            Assert.AreEqual(76, score);
        }

        [Test]
        public void BowlingCalculator_GivenIncompleteGame_ShouldReturnTheCurrentScore()
        {
            var score = _scoringCalculator.Calculate("11 12");
            Assert.AreEqual(5, score);
        }

        [Test]
        public void BowlingCalculator_GivenASpare_ShouldReturnTheCorrectResult()
        {
            var score = _scoringCalculator.Calculate("12 X 81 4/ 52 15 24 32 11 43");
            Assert.AreEqual(79, score);
        }
    }
}