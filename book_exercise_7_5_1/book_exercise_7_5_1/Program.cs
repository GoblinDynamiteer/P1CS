/* Programmering 1 C# Arbetsbok
 * Exercise 7.5.1
 * Page 19
 * 
 * Exercise notes:
 * Create a program: 
 * Print out all numbers between 1-20
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

namespace book_exercise_7_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
