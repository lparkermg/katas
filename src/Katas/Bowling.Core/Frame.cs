using System.Xml.Schema;

namespace Bowling.Core
{
    public struct Frame
    {
        public char FirstScore { get; set; }
        public char SecondScore { get; set; }
        public char ThirdScore { get; set; }

        public bool IsStrike => FirstScore == 'x';

        public int FrameScore
        {
            get
            {
                if (IsStrike)
                {
                    return 0;
                }

                var score = 0;

                score += int.Parse(FirstScore.ToString());
                score += int.Parse(SecondScore.ToString());
                score += int.Parse(ThirdScore.ToString());

                return score;
            }
        }
    }
}