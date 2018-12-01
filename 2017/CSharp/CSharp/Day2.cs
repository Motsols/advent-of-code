
using System;
using System.Linq;

namespace CSharp
{
    public class Day2
    {
        public int Part1(string input)
        {
            var checksum = 0;
            var lines = input.Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim());

            foreach (var line in lines)
            {
                var numbers = line.Split('\t').Select(n => int.Parse(n));
                checksum += numbers.Max() - numbers.Min();
            }

            return checksum;
        }
        
        public int Part2(string input)
        {
            var checksum = 0;
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var numbers in lines.Select(l => l.Split('\t').Select(n => int.Parse(n)).Select(s => s)))
            {
                foreach (var dividend in numbers)
                {
                    foreach (var divisor in numbers)
                    {
                        if (dividend != divisor && dividend / (decimal)divisor % 1 == 0)
                        {
                            checksum += dividend / divisor;
                        }
                    }
                }
            }

            return checksum;
        }
    }
}
