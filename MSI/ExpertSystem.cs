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
        public void WriteResult(Diseases? disease, double? intensification, bool solved)
        {
            if (!solved || (disease is null && !(intensification is null)))
            {
                Console.WriteLine("Według naszej wiedzy medycznej jesteś zdrowy lub masz nieznaną chorobę. :)");
                return;
            }

            if (intensification is null)
            {
                throw new ArgumentNullException(nameof(intensification));
            }

            Console.WriteLine();
            Console.WriteLine("Diagnoza:");

            switch (disease)
            {
                case Diseases.COVID:
                    if (intensification < 0.8)
                    {
                        Console.WriteLine("Masz słabe objawy COVID'a.");
                        Console.WriteLine("Nie wychodź z domu, unikaj kontaktu z domownikami, dużo odpoczywaj. W przypadku gwałtownego pogorszenia" +
                            "  stanu zdrowia niezwłocznie zadzwoń do stacji sanitarno-epidemiologicznej.");
                    }
                    else
                    {
                        Console.WriteLine("Masz silne objawy COVID'a.");
                        Console.WriteLine("Niezwłocznie zadzwoń do stacji sanitarno-epidemiologicznej lub na numer alaromowy, jesli " +
                            " jeśli Twój stan gwałtonie się pogarsza.");
                    }
                    break;
                case Diseases.Gruzlica:
                    if (intensification < 0.5)
                    {
                        Console.WriteLine("Masz słabe objawy gruźlicy. Skontaktuj się z lekarzem pierwszego kontaktu i unikaj kontaktu z innymi osobami");
                    }
                    else
                    {
                        Console.WriteLine("Masz silne objawy gruźlicy. Niezwłocznie skontaktuj się z lekarzem pierwszego kontaktu i wykonaj badania." +
                            "Unikaj kontaktu z innymi osobami.");

                    }
                    break;
                case Diseases.ZapaleniePluc:
                    if (intensification < 0.6)
                    {
                        Console.WriteLine("Masz słabe objawy zapalenia płuc.");
                        Console.WriteLine("Skontaktuj się z lekarzem pierwszego kontaktu, który zadecyduje, czy będziesz mógł leczyć się w domu, " +
                            "czy zostaniesz skierowany do szpitala.");
                    }
                    else
                    {
                        Console.WriteLine("Masz silne objawy zapalenia płuc.");
                        Console.WriteLine("Skontaktuj się z lekarzem pierwszego kontaktu, który zadecyduje, czy będziesz mógł leczyć się w domu, " +
                            "czy zostaniesz skierowany do szpitala. Jeśli masz zbyt duże problemy z oddychaniem, zadzwoń na numer alarmowy");
                    }
                    break;
                case Diseases.Przeziebienie:
                    if (intensification < 0.7)
                    {
                        Console.WriteLine("Masz słabe objawy przeziębienia.");
                        Console.WriteLine("Nie wychodź z domu, unikaj kontaktu z innymi ludźmi i pij dużo płynów. Suplementuj witaminę C, a " +
                            "jeśli Twoje objawy się nasilają, zażyj paracetamolu.");
                    }
                    else
                    {
                        Console.WriteLine("Masz silne objawy przeziębienia.");
                        Console.WriteLine("Nie wychodź z domu, unikaj kontaktu z innymi ludźmi i pij dużo płynów. Zażywaj ibuprofenum, a " +
                            "jeśli Twoje objawy się nasilają, skontaktuj się z lekarzem pierwszego kontaktu.");
                    }
                    break;
                case Diseases.Grypa:
                    if (intensification < 0.6)
                    {
                        Console.WriteLine("Masz słabe objawy grypy.");
                        Console.WriteLine("Nie wychodź z domu, unikaj kontaktu z innymi ludźmi i dużo odpoczywaj. Jeśli Twoje " +
                            "objawy nasilają się, skontaktuj się z lekarzem pierwszego kontaktu.");
                    }
                    else
                    {
                        Console.WriteLine("Masz silne objawy grypy.");
                        Console.WriteLine("Nie wychodź z domu, unikaj kontaktu z innymi ludźmi. Skontaktuj się z lekarzem pierwszego " +
                            "kontaktu w celu wypisania antybiotyku.");
                    }
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
