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

            int digitsSumLength = digitLength + 1;
            var digitsSum = new byte[digitsSumLength];
            var digitsCarry = new byte[digitsSumLength];

            for (var i = 0; i < digitsSumLength; ++i)
            {
                int reverseIndex = digitsSumLength - 1 - i;
                var carry = GetSafeNumber(digitsCarry, reverseIndex + 1);

                var sum = Plus(GetSafeNumber(digitsLh, digitLength - 1 - i), 
                        GetSafeNumber(digitsRh, digitLength - 1 - i));

                digitsSum[reverseIndex] = (byte)(sum.Number + carry);
                digitsCarry[reverseIndex] = sum.Carry;
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
