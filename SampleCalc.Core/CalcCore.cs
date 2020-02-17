using System;

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
    }
}
