using System.Linq;
using Xunit;
using CSharp;

namespace Csharp.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1()
        {
            var day = new Day10();
            int[] input = { 147, 37, 249, 1, 31, 2, 226, 0, 161, 71, 254, 243, 183, 255, 30, 70 };
            var sequence = Enumerable.Range(0, 256).ToArray();
            var testInput = new[] { 3, 4, 1, 5 };
            var testSequence = new[] { 0, 1, 2, 3, 4 };
            Assert.Equal(12, day.Solve(testSequence, testInput));
            Assert.Equal(37230, day.Solve(sequence, input));
        }

        [Fact]
        public void Part2()
        {
            var day = new Day10();
            //Assert.Equal(1, day.Solve(Input, true));
        }
    }
}
