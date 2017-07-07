/* Övning 6 - Lista och metod  
 * Programmering 1
 * 
 * Instruktioner:
 *  Modifera existerande kod:
 *  Skriv klart metoden "RullaTärning" 
 *  så att programmet fungerar.
 *  
 * Extra:
 *  Skapa metoder:
 *  - Beräkna medelvärde av tärningsslag
 *  - Rensa listan med tärningsslag
 *  - Sortera listan med tärningsslag
 *  - Sök i listan med tärningsslag
 *  
 * Johan Kämpe
 * 2017-07-07
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        /* För switch-satsen i menyn.
         * Att använda enum för case-villkoren 
         * kan göra koden mer läsbar */
        enum Meny
        {
            Rulla = 1,
            Kolla,
            Medelvärde,
            Rensa,
            Sortera,
            Sök,
            Avsluta
        }

        static int RullaTärning(Random slumpObjekt)
        {   
            /* Ge slumpat värde mellan 1-7 i retur.
             * Metoden Next tar parametrar för min- 
             * och max-värde för slumpat tal 
             * (maxvärdet ej inräknat) */
            return slumpObjekt.Next(1, 7);
        }

        static int SökTärningVärde(int värde, List<int> lista)
        {
            /* ' => ' kallas lambda-operator, används här med metoden
             * FindAll för att hitta alla tärningar med det sökta värdet, 
             * Count används sedan för att ge antalet hittade värden
             * i retur.*/
            return lista.FindAll(tärning => tärning == värde).Count;
        }

        static void Main()
        {
            Random slump = new Random();
            List<int> tärningar = new List<int>();

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true;
            while (kör)
            {
                Console.WriteLine(
                    "\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Visa medelvärde\n" +
                    "\t[4] Rensa tärningslistan\n" +
                    "\t[5] Sortera tärningslistan\n" +
                    "\t[6] Sök i tärningslistan\n" +
                    "\t[7] Avsluta");
                Console.Write("\tVälj: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);

                switch (val)
                {
                    case (int)Meny.Rulla:
                        Console.Write("\n\tHur många tärningar vill du rulla: ");
                        bool inmatning = int.TryParse(Console.ReadLine(), out int antal);

                        if (inmatning)
                        {
                            for (int i = 0; i < antal; i++)
                            {
                                tärningar.Add(RullaTärning(slump));
                            }
                        }
                        break;

                    case (int)Meny.Kolla:
                        int newLine = 0;
                        Console.WriteLine("\n\tRullade tärningar: ");
                        foreach (int tärning in tärningar)
                        {
                            /* Visa resultat i 5 kolumner */
                            Console.Write("\t" + tärning);
                            if (newLine++ == 4)
                            {
                                newLine = 0;
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine();
                        break;

                    case (int)Meny.Medelvärde:
                        /* Summera alla tärningsslag */
                        int summa = 0;
                        tärningar.ForEach(tärning => summa += tärning);

                        /* Dela med 1 om tärningar.Count är 0
                         * Förhindrar "delning med 0"-fel */
                        Console.WriteLine("\n\tMedelvärde: {0}", ((float)summa / 
                            (tärningar.Count > 0 ? tärningar.Count : 1)));
                        break;

                    case (int)Meny.Rensa:
                        tärningar.Clear();
                        Console.WriteLine("\n\tListan rensad!");
                        break;

                    case (int)Meny.Sortera:
                        tärningar.Sort();
                        Console.WriteLine("\n\tListan sorterad!");
                        break;


                    case (int)Meny.Sök:
                        Console.Write("\n\tAnge värde att söka efter: ");
                        if (int.TryParse(Console.ReadLine(), out int värde))
                        {
                            Console.WriteLine("\tHittade {0} st tärningar med " +
                                "värde {1} i listan!", 
                                    SökTärningVärde(värde, tärningar), värde);
                        }
                        break;

                    case (int)Meny.Avsluta:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;

                    default:
                        Console.WriteLine("\n\tVälj {0}-{1} från menyn.",
                            (int)Meny.Rulla, (int)Meny.Avsluta);
                        break;
                }
            }
        }
    }
}
