/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.4
 * Page 13
 * 
 * Exercise notes:
 * Create a program:
 * input: one floating point value, eg. 11,534
 * output: value rounded to nearest integer
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

namespace book_exercise_7_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double value;

            Console.Write("Enter a floating point value: ");
            value = Convert.ToDouble(Console.ReadLine());

            /* MidpointRounding.AwayFromZero round up from 0.5 */
            Console.WriteLine("The value {0} is rounded " +
                "to integer value {1}", 
                value, Math.Round(value, MidpointRounding.AwayFromZero));

            Console.Read();
        }
    }
}
