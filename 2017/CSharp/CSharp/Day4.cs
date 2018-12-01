using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CSharp
{
    public class Day4
    {
        public int Part1(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim())
                .Select(l => l.Split(" ").Length - l.Split(" ").GroupBy(w => w).Count() == 0 ? 1 : 0).Sum();
        }

        public int Part2(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().Split(" ").Length - line.Trim().Split(" ").Select(word => string.Join("", word.OrderBy(w => w))).GroupBy(g => g).Count() == 0 ? 1 : 0).Sum();
        }
    }
}
