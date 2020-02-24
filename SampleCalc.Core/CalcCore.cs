using System;
using System.Text;
using System.Diagnostics;

namespace SampleCalc.Core
{
    public class CalcCore
    {
        public struct Digit
        {
            public byte Number { get; set; }
            public byte Carry { get; set; }
        }

        public static string Plus(string lh, string rh)
        {
            var digitsLh = ConvertToBytes(lh);
            var digitsRh = ConvertToBytes(rh);

            var digitsSum = Plus(digitsLh, digitsRh);
            
            return ConvertToString(digitsSum);
        }

        public static byte[] Plus(byte[] digitsLh, byte[] digitsRh)
        {
            var digitLength = Math.Max(digitsLh.Length, digitsRh.Length);

            int digitsSumLength = digitLength + 1;
            var digitsSum = new byte[digitsSumLength];
            var digitsCarry = new byte[digitsSumLength];

            for (var i = 0; i < digitsSumLength; ++i)
            {
                int reverseIndex = digitsSumLength - 1 - i;
                var carry = GetSafeNumber(digitsCarry, reverseIndex + 1);

                var sum = Plus(GetSafeNumber(digitsLh, digitsLh.Length - 1 - i), 
                        GetSafeNumber(digitsRh, digitsRh.Length - 1 - i));

                digitsSum[reverseIndex] = (byte)(sum.Number + carry);
                Debug.Assert(digitsSum[reverseIndex] < 10, $"Sum[{reverseIndex}] is {digitsSum[reverseIndex]}");

                digitsCarry[reverseIndex] = sum.Carry;
            }

            return digitsSum;
        }

        public static byte GetSafeNumber(byte[] array, int index)
        {
            return (byte)((index >= array.Length || index < 0) ? 0 : array[index]);
        }

        public static Digit Plus(byte digitLh, byte digitRh)
        {
            Debug.Assert(digitLh < 10, $"Wrong lh : {digitLh}");
            Debug.Assert(digitRh < 10, $"Wrong rh : {digitRh}");

            var sum = digitLh + digitRh;

            return new Digit 
            { 
                Number = (byte)(sum >= 10 ? sum - 10 : sum),
                Carry = (byte)(sum >= 10 ? 1 : 0),
            };
        }

        public static byte[] ConvertToBytes(string number)
        {
            var digits = new byte[number.Length];

            for (var i = 0; i < number.Length; ++i)
            {
                digits[i] = (byte)Char.GetNumericValue(number, i);
            }

            return digits;
        }

        public static string ConvertToString(byte[] number)
        {
            var stringBuilder = new StringBuilder();

            var firstZeroTrimmed = false;

            for (int i = 0; i < number.Length; ++i)
            {
                if (number[i] != 0)
                {
                    firstZeroTrimmed = true;
                }

                if (firstZeroTrimmed == false)
                {
                    continue;
                }

                stringBuilder.Append(number[i]);
            }

            if (stringBuilder.Length == 0)
            {
                stringBuilder.Append("0");
            }

            return stringBuilder.ToString();
        }
    }
}
