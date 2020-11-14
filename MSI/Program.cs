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



            Console.WriteLine("Jaki masz katar?");
            string katar = Console.ReadLine();
            prolog.CreateFact("katar", new[]{ new AtomTerm(katar)});




            prolog.Consult(@"msi.pl");

            var solution = prolog.GetFirstSolution("sprawdzchorobe(X).");

           //var v = prolog.GetVariable("X");

            
            //Console.WriteLine(v);
        }
    }
}
