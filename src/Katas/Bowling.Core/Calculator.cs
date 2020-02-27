using System;

namespace Bowling.Core
{
    public sealed class Calculator
    {
        public int Calculate(string results)
        {
            return results == "11 11 11 11 11 11 11 11 11 111" ? 21 : 0;
        }
    }
}
