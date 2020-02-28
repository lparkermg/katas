using System.Xml.Schema;

namespace Bowling.Core
{
    public struct Frame
    {
        public char FirstScore { get; set; }
        public char SecondScore { get; set; }
        public char ThirdScore { get; set; }

        public bool IsStrike => FirstScore == 'x';
        public bool IsSpare => SecondScore == '/';

        public int FrameScore
        {
            get
            {
                if (IsStrike)
                {
                    return 0;
                }

                var score = 0;

                score += ScoreFromChar(FirstScore);
                score += ScoreFromChar(SecondScore);
                score += ScoreFromChar(ThirdScore);

                return score;
            }
        }

        private int ScoreFromChar(char scoreChar)
        {
            if (scoreChar == '/' || scoreChar == '-')
            {
                return 0;
            }

            var score = int.Parse(scoreChar.ToString());

            return score;
        }
    }
}