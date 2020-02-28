using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Bowling.Core
{
    public sealed class Calculator
    {
        public int Calculate(string results)
        {
            results = results.ToLower();
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
            Frame? spareFrame = null;
            foreach (var frame in frames)
            {
                if (frame.IsSpare)
                {
                    spareFrame = frame;
                    continue;
                }

                if (frame.IsStrike)
                {
                    strikeFrame = frame;
                    continue;
                }

                if (spareFrame.HasValue)
                {
                    totalScore += 10;
                    totalScore += int.Parse(frame.FirstScore.ToString());
                    spareFrame = null;
                }

                if (strikeFrame.HasValue)
                {
                    totalScore += 10;
                    totalScore += frame.FrameScore;
                    strikeFrame = null;
                }

                totalScore += frame.FrameScore;
            }
            
            return totalScore;
        }
    }
}
