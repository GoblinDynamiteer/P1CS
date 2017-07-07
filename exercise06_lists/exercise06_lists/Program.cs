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
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        enum Menu
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
            /* Ge slumpat värde mellan 1-7 i retur */
            return slumpObjekt.Next(1, 7);
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
                    case (int)Menu.Rulla:
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

                    case (int)Menu.Kolla:
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

                    case (int)Menu.Medelvärde:
                        Console.Write("\n\tMedelvärde: ");

                        /* Summera alla tärningsslag */
                        int summa = 0;
                        tärningar.ForEach(tärning => summa += tärning);

                        /* Dela med 1 om tärningar.Count är 0
                         * Förhindrar "delning med 0"-fel */
                        Console.WriteLine(((float)summa / 
                            (tärningar.Count > 0 ? tärningar.Count : 1)));
                        break;

                    case (int)Menu.Avsluta:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;

                    default:
                        Console.WriteLine("\n\tVälj 1-3 från menyn.");
                        break;
                }
            }
        }
    }
}
