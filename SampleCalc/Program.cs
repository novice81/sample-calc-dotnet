using System;
using SampleCalc.Core;

namespace SampleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintUsage();
                return;
            }

            Console.WriteLine(CalcCore.Plus(args[0], args[1]));
        }

        static void PrintUsage()
        {
            Console.WriteLine("Sample Calculator v0.01");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Add two numbers.                               ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("$ dotnet run --project SampleCalc [num1] [num2]");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("EXAMPLE                                        ");
            Console.WriteLine("$ dotnet run --project SampleCalc 10 20        ");
            Console.WriteLine("30                                             ");
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
