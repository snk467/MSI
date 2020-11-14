using System;
using Prolog;
using static Prolog.PrologEngine;

namespace MSI
{
    class Program
    {
        static void Main()
        {
            var prolog = new PrologEngine(false);
            prolog.BasicIO = new DosIO();

            prolog.CreateFact("test", new BaseTerm[] { new DecimalTerm(1.0) });

            prolog.

            //prolog.Consult(@"..\..\..\choroby.pl");

            var solution = prolog.GetFirstSolution("test(1.0).");

            Console.WriteLine(solution.Solved);
        }
    }
}
