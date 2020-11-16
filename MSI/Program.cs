using System;
using System.Globalization;
using Prolog;
using static Prolog.PrologEngine;

namespace MSI
{
    class Program
    {
        static void Main()
        {
            var prolog = new PrologEngine(false);
            var expertSystem = new ExpertSystem(prolog);

            expertSystem.AskQuestions();

            prolog.Consult(@"msi.pl");

            var solution = prolog.GetFirstSolution(query: "sprawdzchorobe(Choroba, Nasilenie).");

            double? intensificationValue;
            try
            {
                BaseTerm intensification = prolog.GetVariable("Nasilenie");
                intensificationValue = double.Parse(intensification.ToString(), CultureInfo.InvariantCulture);
            }
            catch
            {
                intensificationValue = null;
            }

            Diseases? diseaseValue;
            try
            {
                var choroba = prolog.GetVariable("Choroba");
                string disease = prolog.GetVariable("Choroba").ToString();
                diseaseValue = (Diseases)Enum.Parse(typeof(Diseases), disease, true);
            }
            catch
            {
                diseaseValue = null;
            }

            try
            {
                expertSystem.WriteResult(diseaseValue, intensificationValue, solution.Solved);
            }
            catch(Exception e)
            {
                Console.WriteLine("Podczas działania programu wystąpił błąd: ");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
