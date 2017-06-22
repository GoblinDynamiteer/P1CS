/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.2
 * Page 13
 * 
 * Exercise notes:
 * Create a program:
 * input: two integers
 * output: sum of integers
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

namespace book_exercise_7_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberA, numberB;

            Console.Write("Input an integer number:");

            /* Convert.ToInt32 converts string to 
             * 32-bit integer. 
             * Program crashes if non-integer input */
            numberA = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input an integer number:");
            numberB = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sum: {0}+{1}={2}", 
                numberA, numberB, numberA+numberB);

            /* Read next key-press, used to halt program */
            Console.Read();
        }
    }
}
