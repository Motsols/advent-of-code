using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    public class Day5
    {
        public int Part1(string input)
        {
            var numbers = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l.Trim())).ToArray();
            var currentPos = 0;
            var jumps = 0;

            do
            {
                var previousPos = currentPos;
                currentPos += numbers[currentPos];
                numbers[previousPos]++;
                jumps++;
            } while (currentPos < numbers.Length);

            return jumps;
        }

        public int Part2(string input)
        {
            var numbers = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l.Trim())).ToArray();
            var currentPos = 0;
            var jumps = 0;
            
            do
            {
                var previousPos = currentPos;
                currentPos += numbers[currentPos];
                if (numbers[previousPos] > 2)
                    numbers[previousPos]--;
                else
                    numbers[previousPos]++;
                jumps++;
            } while (currentPos < numbers.Length);

            return jumps;
        }
    }
}
