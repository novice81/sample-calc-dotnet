using System;
using System.Text;

namespace SampleCalc.Core
{
    public class CalcCore
    {
        public struct Digit
        {
            public byte Number { get; set; }
            public byte Carry { get; set; }
        }

        public string Plus(string lh, string rh)
        {
            var digitsLh = ConvertToBytes(lh);
            var digitsRh = ConvertToBytes(rh);

            var digitsSum = Plus(digitsLh, digitsRh);
            
            return ConvertToString(digitsSum);
        }

        public byte[] Plus(byte[] digitsLh, byte[] digitsRh)
        {
            var digitLength = Math.Max(digitsLh.Length, digitsRh.Length);
            var digitsSum = new byte[digitLength];
            var digitsCarry = new byte[digitLength + 1];

            for (var i = 0; i < digitLength; ++i)
            {
                var sum = Plus(digitsLh[digitLength - i - 1], digitsRh[digitLength - i - 1]);
                digitsSum[digitLength - i - 1] = (byte)sum.Number;
                digitsCarry[digitLength - i] = sum.Carry;
            }

            return digitsSum;
        }

        public byte GetSafeNumber(byte[] array, int index)
        {
            return (byte)((index >= array.Length || index < 0) ? 0 : array[index]);
        }

        public Digit Plus(byte digitLh, byte digitRh)
        {
            var sum = digitLh + digitRh;

            return new Digit 
            { 
                Number = (byte)(sum >= 10 ? sum - 10 : sum),
                Carry = (byte)(sum >= 10 ? 1 : 0),
            };
        }

        public byte[] ConvertToBytes(string number)
        {
            var digits = new byte[number.Length];

            for (var i = 0; i < number.Length; ++i)
            {
                digits[i] = (byte)Char.GetNumericValue(number, i);
            }

            return digits;
        }

        public string ConvertToString(byte[] number)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < number.Length; ++i)
            {
                stringBuilder.Append(number[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
