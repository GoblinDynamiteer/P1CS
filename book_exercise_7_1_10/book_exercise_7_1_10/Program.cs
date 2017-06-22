/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.10
 * Page 15
 * 
 * Exercise notes:
 * Experiment with modulus division
 * 
 * What value does the code output ?
 *  int a = 8 % 3;
 *  Console.WriteLine(a);
 * 
 * Johan Kämpe
 * https://github.com/GoblinDynamiteer/
 * https://www.linkedin.com/in/johankampe/
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_exercise_7_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Modulus division gives the 
             * remainder of the division.
             *
             * In this case 8 / 3 = 2 
             * (integer division)
             * 
             * remainder is 8 - 3*2 = 2
             * 
             * Result of modulus division 
             * x % y
             * can never be larger than x
             */

            int a = 8 % 3;
            Console.WriteLine(a);

            /* Output 1-10 modulus 
             * divided by 1-10 (if smaller) */
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= x; y++)
                {
                    Console.WriteLine("{0} % {1} = {2}",
                        x,
                        y,
                        x % y);
                }
            }

            Console.Read();
        }
    }
}
