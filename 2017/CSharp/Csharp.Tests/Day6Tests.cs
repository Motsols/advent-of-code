using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CSharp;

namespace Csharp.Tests
{
    public class Day6Tests
    {
        [Fact]
        public void Part1()
        {
            var day = new Day6();

            //Assert.Equal(5, day.Part1("0	2	7	0"));
            Assert.Equal(14029, day.Part1(input));
        }

        [Fact]
        public void Part2()
        {
            var day = new Day6();

            //Assert.Equal(10, day.Part2(@"0
            //                            3
            //                            0
            //                            1
            //                            -3"));
            //Assert.Equal(26948068, day.Part2(input));
        }

        public const string input = @"10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6";
    }
}
