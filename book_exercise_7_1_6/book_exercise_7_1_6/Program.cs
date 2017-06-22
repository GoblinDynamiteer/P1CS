/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.6
 * Page 14
 * 
 * Exercise notes:
 * Create a program:
 * input: one floating point value, eg. 11,534 
 * output: rounded value, two digit precision
 * 
 * note: use Math.Round()
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

namespace book_exercise_7_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double value;

            Console.Write("Enter a floating point value: ");
            value = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("The value {0} is rounded " +
                "to value {1}",
                value, Math.Round(value, 2) );

            Console.Read();

        }
    }
}
