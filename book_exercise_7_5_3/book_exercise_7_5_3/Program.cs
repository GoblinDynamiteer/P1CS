/* Programmering 1 C# Arbetsbok
 * Exercise 7.5.3
 * Page 19
 * 
 * Exercise notes:
 * Create a program: Heads or tails
 * USER INPUT: Number of coin flips
 * OUTPUT: Result of each coin flip
 * 
 * Note: Investigate how to randomize in C#
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

namespace book_exercise_7_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Random class */
            Random coinFlip = new Random();

            Console.Write("Enter amount of coin flips: ");

            int flips = int.Parse(Console.ReadLine());
            int counter = 1;

            while (flips-- != 0)
            {
                /* Next(0,2) returns random number between 
                 * 0 and 2 (0 or 1) */
                string result = (coinFlip.Next(0, 2) == 1 ) ?
                    "Heads!" : "Tails";

                Console.WriteLine("Flip #{0}: {1}", 
                    counter++.ToString("000"),
                    result);
            }

            Console.ReadLine();
        }
    }
}
