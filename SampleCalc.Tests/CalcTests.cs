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

            for (int lh = 0; lh < 10; ++lh)
            {
                for (int rh = 0; rh < 10; ++rh)
                {
                    if (lh + rh > 10)
                    {
                        continue;
                    }

                    // Test only that sum is still single digit
                    calc.Plus(lh.ToString(), rh.ToString()).Should().Be((lh + rh).ToString());
                }
            }
        }

        [Fact]
        public void Test_Plus_SingleDigit_Over_Carry()
        {
            var calc = new CalcCore();

            calc.Plus("11", "19").Should().HaveLength(2).And.Be("30");
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
