using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CSharp;

namespace Csharp.Tests
{
    public class Day3Tests
    {
        [Fact]
        public void Part1Tests()
        {
            var day = new Day3();

            Assert.Equal(0, day.Part1(1));
            Assert.Equal(3, day.Part1(12));
            Assert.Equal(2, day.Part1(23));
            Assert.Equal(31, day.Part1(1024));
            Assert.Equal(419, day.Part1(289326));
        }

        [Fact]
        public void Part2Tests()
        {
            var day = new Day3();

            //Assert.Equal(1, day.Part2(2));
            //Assert.Equal(2, day.Part2(3));
            //Assert.Equal(4, day.Part2(4));
            //Assert.Equal(5, day.Part2(5));
            Assert.Equal(295229, day.Part2(289326));
        }
    }
}
