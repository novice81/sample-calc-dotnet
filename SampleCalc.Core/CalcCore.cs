using System;

namespace SampleCalc.Core
{
    public class CalcCore
    {
        public string Plus(string lh, string rh)
        {
            return (int.Parse(lh) + int.Parse(rh)).ToString();
        }
    }
}
