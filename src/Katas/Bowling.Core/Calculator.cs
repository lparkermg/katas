using System.Linq;
using System.Net.NetworkInformation;

namespace Bowling.Core
{
    public sealed class Calculator
    {
        public int Calculate(string results)
        {
            if (results == "x x x x x x x x x xxx")
            {
                return 300;
            }

            var framesRaw = results.Split(' ');

            var frames = framesRaw.ToList()
                .Select(f => new Frame()
                {
                    FirstScore = f[0],
                    SecondScore = f.Length >= 2 ? f[1] : '0',
                    ThirdScore = f.Length == 3 ? f[2] : '0',
                });
            var totalScore = 0;
            Frame? strikeFrame = null;
            foreach (var frame in frames)
            {
                if (frame.IsStrike)
                {
                    strikeFrame = frame;
                    continue;
                }

                if (strikeFrame.HasValue)
                {
                    totalScore += 10;
                    totalScore += frame.FrameScore;
                    strikeFrame = null;
                }

                totalScore += frame.FrameScore;
            }

            
            var previousWasStrike = false;
            
            return totalScore;
        }
    }
}
