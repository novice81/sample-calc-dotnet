using System;
using System.Text;

namespace SampleCalc.Core
{
    public class CalcCore
    {
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

            for (var i = 0; i < digitLength; ++i)
            {
                digitsSum[digitLength - i - 1] = 
                        (byte)Plus(digitsLh[digitLength - i - 1], digitsRh[digitLength - i - 1]);
            }

            return digitsSum;
        }

        public byte Plus(byte digitLh, byte digitRh)
        {
            return digitLg + digitRh;
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
