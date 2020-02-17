using System;
using System.Text;

namespace SampleCalc.Core
{
    public class CalcCore
    {
        public string Plus(string lh, string rh)
        {
            var digitsLh = lh.ToCharArray();
            var digitsRh = rh.ToCharArray();

            var digitLength = Math.Max(digitsLh.Length, digitsRh.Length);
            var digitsSum = new char[digitLength];

            for (var i = 0; i < digitLength; ++i)
            {
                digitsSum[digitLength - i - 1] = (
                        Convert.ToInt16(Char.GetNumericValue(digitsLh[digitLength - i - 1]))
                        + Convert.ToInt16(Char.GetNumericValue(digitsRh[digitLength - i - 1])))
                        .ToString().ToCharArray()[0];
            }
            
            return new string(digitsSum);
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
