using System;
using Xunit;
using FluentAssertions;
using SampleCalc.Core;

namespace SampleCalc.Tests
{
    public class CalcTests
    {
        [Fact]
        public void TestPlus_SingleDigit()
        {
            var calc = new CalcCore();

            calc.Plus("1", "1").Should().Be("2");
        }
    }
}
