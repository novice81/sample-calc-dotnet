using System;
using Xunit;
using FluentAssertions;
using SampleCalc.Core;

namespace SampleCalc.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Test_Plus_SingleDigit()
        {
            var calc = new CalcCore();

            calc.Plus("1", "1").Should().Be("2");
        }

        [Fact]
        public void Test_Convert_String_To_Bytes()
        {
            var calc = new CalcCore();

            calc.ConvertToBytes("123").Should().HaveCount(3).And.Equal(1, 2, 3);
        }

        [Fact]
        public void Test_Convert_Bytes_To_String()
        {
            var calc = new CalcCore();

            calc.ConvertToString(new byte[]{1, 2, 3}).Should().HaveLength(3).And.Be("123");
        }

    }
}
