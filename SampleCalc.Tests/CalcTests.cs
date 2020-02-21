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
            for (int lh = 0; lh < 10; ++lh)
            {
                for (int rh = 0; rh < 10; ++rh)
                {
                    if (lh + rh >= 10)
                    {
                        continue;
                    }

                    // Test only that sum is still single digit
                    CalcCore.Plus(lh.ToString(), rh.ToString())
                            .Should().HaveLength(1).And.Be((lh + rh).ToString());
                }
            }
        }

        [Fact]
        public void Test_Plus_SingleDigit_Over_Carry()
        {
            CalcCore.Plus(CalcCore.ConvertToBytes("1"), CalcCore.ConvertToBytes("9"))
                    .Should().HaveCount(2).And.Equal(1, 0);
        }

        [Fact]
        public void Test_Plus_DoubleDigit_Over_Carry()
        {
            CalcCore.Plus("11", "99").Should().HaveLength(3).And.Be("110");
        }

        [Fact]
        public void Test_GetSafeNumber()
        {
            var array = new byte[3]{ 1, 2, 3 };

            CalcCore.GetSafeNumber(array, 0).Should().Be(1);
            CalcCore.GetSafeNumber(array, 1).Should().Be(2);
            CalcCore.GetSafeNumber(array, 2).Should().Be(3);

            CalcCore.GetSafeNumber(array, 3).Should().Be(0);
            CalcCore.GetSafeNumber(array, -1).Should().Be(0);
        }

        [Fact]
        public void Test_Convert_String_To_Bytes()
        {
            CalcCore.ConvertToBytes("123")
                    .Should().HaveCount(3).And.Equal(1, 2, 3);
        }

        [Fact]
        public void Test_Convert_Bytes_To_String()
        {
            CalcCore.ConvertToString(new byte[]{1, 2, 3})
                    .Should().HaveLength(3).And.Be("123");
        }

    }
}
