using Bowling.Core;
using NUnit.Framework;

namespace Bowling.Tests
{
    public class BowlingTests
    {
        private readonly Calculator _scoringCalculator = new Calculator();

        [Test]
        public void BowlingCalculator_WhenGivenASetOfZeroScores_ShouldReturnZero()
        {
            var score = _scoringCalculator.Calculate("00 00 00 00 00 00 00 00 00 000");
            Assert.AreEqual(0, score);
        }
    }
}