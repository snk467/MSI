using Prolog;
using System;
using System.Collections.Generic;
using System.Text;
using static Prolog.PrologEngine;

namespace MSI
{
    public enum Diseases { COVID, Gruzlica, ZapaleniePluc, Przeziebienie, Grypa}

    public class ExpertSystem
    {
        private PrologEngine prolog;

        public ExpertSystem(PrologEngine prolog)
        {
            this.prolog = prolog;
        }

        public void AskQuestions()
        {
            Console.WriteLine("Katar:");
            WriteDefaultAnswers();
            prolog.CreateFact("katar", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Kaszel:");
            WriteDefaultAnswers();
            prolog.CreateFact("kaszel", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Gorączka:");
            Console.WriteLine("[0]: poniżej 37 stopni");
            Console.WriteLine("[1]: [37,38)");
            Console.WriteLine("[2]: [38,39)");
            Console.WriteLine("[3]: [39,40)");
            Console.WriteLine("[4]: 40 stopni lub więcej");
            prolog.CreateFact("goraczka", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Dreszcze:");
            WriteDefaultAnswers2();
            prolog.CreateFact("dreszcze", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Ból głowy:");
            WriteDefaultAnswers();
            prolog.CreateFact("bol_glowy", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Ból mięśni:");
            WriteDefaultAnswers();
            prolog.CreateFact("bol_miesni", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Pocenie się:");
            WriteDefaultAnswers2();
            prolog.CreateFact("pocenie", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Brak apetytu:");
            WriteDefaultAnswers();
            prolog.CreateFact("brak_apetytu", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Wymioty:");
            WriteDefaultAnswers();
            prolog.CreateFact("wymioty", new[] { new DecimalTerm(ReadAnswer()) });

            Console.WriteLine("Zaburzenia węchu:");
            WriteDefaultAnswers2();
            prolog.CreateFact("zaburzenia_wechu", new[] { new DecimalTerm(ReadAnswer()) });
        }
        public void WriteResult(Diseases? disease, double? intensification, bool diseaseFound)
        {
            if (!diseaseFound)
            {
                Console.WriteLine("Według naszej wiedzy medycznej jesteś zdrowy lub masz nieznaną chorobę. :)");
                return;
            }

            if (diseaseFound && (disease is null || intensification is null))
            {
                if (disease is null)
                {
                    throw new ArgumentNullException(nameof(disease));
                }
                else
                {
                    throw new ArgumentNullException(nameof(intensification));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Diagnoza:");

            //TODO: Dodać tutaj uwzględnie nasilenia choroby
            //TODO: Dodać porady medyczne
            switch (disease)
            {
                case Diseases.COVID:
                    Console.WriteLine("Masz covid.");
                    break;
                case Diseases.Gruzlica:
                    Console.WriteLine("Masz gruźlicę.");
                    break;
                case Diseases.ZapaleniePluc:
                    Console.WriteLine("Masz zapalenie płuc.");
                    break;
                case Diseases.Przeziebienie:
                    Console.WriteLine("Masz przeziębienie.");
                    break;
                case Diseases.Grypa:
                    Console.WriteLine("Masz grypę.");
                    break;
            }

        }

        #region Helpers
        private static double ReadAnswer()
        {
            string selectOption = "Wybierz opcję: ";
            Console.Write(selectOption);
            string value;
            bool success = true;
            int result;
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
        private void WriteDefaultAnswers()
        {
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słaby");
            Console.WriteLine("[2]: średni");
            Console.WriteLine("[3]: silny");
            Console.WriteLine("[4]: bardzo silny");
        }

        private void WriteDefaultAnswers2()
        {
            Console.WriteLine("[0]: objaw nie występuje");
            Console.WriteLine("[1]: słabe");
            Console.WriteLine("[2]: średnie");
            Console.WriteLine("[3]: silne");
            Console.WriteLine("[4]: bardzo silne");
        }
        #endregion
    }
}
