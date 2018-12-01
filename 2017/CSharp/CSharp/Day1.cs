using System;

namespace CSharp
{
    public class Day1
    {
        public int Part1(string input)
        {
            var total = 0;
            var latest = Convert.ToInt16(Char.GetNumericValue(input[input.Length - 1]));
            foreach (char c in input)
            {
                var current = Convert.ToInt16(Char.GetNumericValue(c));

                if (current == latest)
                {
                    total = total + current;
                }

                latest = current;
            }

            return total;
        }

        public int Part2(string input)
        {
            var steps = input.Length / 2;
            var total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var current = Convert.ToInt16(Char.GetNumericValue(input[i]));
                var other = Convert.ToInt16(Char.GetNumericValue(input[(i + steps) % input.Length]));

                if (current == other)
                {
                    total = total + current;
                }
            }

            return total;
        }
    }
}
