namespace Bowling.Core
{
    public sealed class Calculator
    {
        public int Calculate(string results)
        { 
            results = results.Replace(" ", string.Empty);

            var totalScore = 0;
            foreach (var score in results)
            {
                totalScore += int.Parse(score.ToString());
            }

            return totalScore;
        }
    }
}
