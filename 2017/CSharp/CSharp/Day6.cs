using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    public class Day6
    {
        public int Part1(string input)
        {
            var banks = input.Split('\t', StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l.Trim())).ToArray();
            var currentPos = 0;
            var cycle = 0;
            var history = new List<string>();

            history.Add(AsString(banks));

            while (history.Count() == history.GroupBy(x => x).Count())
            {
                var toSharePos = HighestNumberBank(banks);
                var total = banks[toSharePos];
                banks[toSharePos] = 0;

                var toShare = Math.Floor((decimal)total / banks.Length);
                var extra = total % banks.Length;

                currentPos = toSharePos;
                for (int i = 0; i < banks.Length; i++)
                {
                    currentPos++;
                    if (currentPos == banks.Length)
                        currentPos = 0;

                    banks[currentPos] += (int)toShare;

                    if (extra > 0)
                    {
                        banks[currentPos]++;
                        extra--;
                    }
                }
                history.Add(AsString(banks));

                cycle++;
            }

            return cycle;
        }

        public int HighestNumberBank(int[] banks)
        {
            var highestNumber = banks.Max();
            var position = 0;
            for (int i = 0; i < banks.Length; i++)
            {
                if (banks[i] == highestNumber)
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        public string AsString(int[] banks)
        {
            var stringNumbers = new List<string>();
            foreach (var number in banks)
            {
                stringNumbers.Add(number.ToString());
            }

            return string.Join(", ", stringNumbers);
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
            } while (currentPos >= 0 && currentPos < numbers.Length);

            return jumps;
        }
    }
}
