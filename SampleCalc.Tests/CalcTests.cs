using System;
using Xunit;
using FluentAssertions;
using SampleCalc.Core;

namespace SampleCalc.Tests
{
    public class CalcTests
    {
        [Fact]
        public void TestPlus()
        {
            var calc = new CalcCore();

            calc.Plus("123", "123").Should().Be("246");
        }
    }
}
