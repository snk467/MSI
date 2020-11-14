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

            #region anamnesis
            Console.WriteLine("Katar:");
            DefaultAnswers();
            prolog.CreateFact("katar", new[]{ new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Kaszel:");
            DefaultAnswers();
            prolog.CreateFact("kaszel", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Gorączka:");
            Console.WriteLine("[0]: poniżej 37 stopni");
            Console.WriteLine("[1]: [37,38)");
            Console.WriteLine("[2]: [38,39)");
            Console.WriteLine("[3]: [39,40)");
            Console.WriteLine("[4]: 40 stopni lub więcej");
            prolog.CreateFact("goraczka", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Dreszcze:");
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słabe");
            Console.WriteLine("[2]: średnie");
            Console.WriteLine("[3]: silne");
            Console.WriteLine("[4]: bardzo silne");
            prolog.CreateFact("dreszcze", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Ból głowy:");
            DefaultAnswers();
            prolog.CreateFact("bol_glowy", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Ból mięśni:");
            DefaultAnswers();
            prolog.CreateFact("bol_miesni", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Pocenie się:");
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słabe");
            Console.WriteLine("[2]: średnie");
            Console.WriteLine("[3]: silne");
            Console.WriteLine("[4]: bardzo silne");
            prolog.CreateFact("pocenie", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Brak apetytu:");
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słaby");
            Console.WriteLine("[2]: średni");
            Console.WriteLine("[3]: silny");
            Console.WriteLine("[4]: bardzo silny");
            prolog.CreateFact("brak_apetytu", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Wymioty:");
            DefaultAnswers();
            prolog.CreateFact("wymioty", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Zaburzenia węchu:");
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słabe");
            Console.WriteLine("[2]: średnie");
            Console.WriteLine("[3]: silne");
            Console.WriteLine("[4]: bardzo silne");
            prolog.CreateFact("zaburzenia_wechu", new[] { new DecimalTerm(ReadAnswer()) });
            #endregion

            prolog.Consult(@"msi.pl");

            var solution = prolog.GetFirstSolution("sprawdzchorobe(Choroba, Nasilenie).");

            var disease = prolog.GetVariable("Choroba");

            var intensification = prolog.GetVariable("Nasilenie");

            string diseaseName = disease.ToString();
            double intensificationValue;
            if (intensification.IsNumber)
            {
                double.TryParse(intensification.ToString(), out intensificationValue);
            }




        }

        private static void DefaultAnswers()
        {
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słaby");
            Console.WriteLine("[2]: średni");
            Console.WriteLine("[3]: silny");
            Console.WriteLine("[4]: bardzo silny");
        }

        private static double ReadAnswer()
        {
            string selectOption = "Wybierz opcję: ";
            Console.Write(selectOption);
            string value;
            bool success = true;
            int result = -1;
            do
            {
                if (!success)
                {
                    Console.WriteLine("Nie poprawna wartość!");
                    Console.Write(selectOption);
                }
                value = Console.ReadLine();
                success = int.TryParse(value, out result);

                if (success && !(result >= 0 && result <= 4))
                {
                    success = false;
                }

            } while (!success);

            Console.WriteLine();
            return result / 4.0;
        }
    }
}
