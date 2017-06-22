/* Programmering 1 C# Arbetsbok
 * Exercise 7.5.2
 * Page 19
 * 
 * Exercise notes:
 * Create a program:
 * USER INPUT: A number (x) between 1-100
 * OUTPUT: all numbers x to 101, on same line
 * 
 * Note: if user enters a number not between
 * 1-100, exit program
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

namespace book_exercise_7_5_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a number " +
                "between 1 and 100: ");
            int num = int.Parse(Console.ReadLine());

            /* Use flag to skip ReadLine() if incorrect
             * input */
            bool correctInput = (num <= 101 && num >= 0) ?
                true : false;

            if (correctInput)
            {
                while (num <= 101)
                {
                    Console.Write("{0} ", num++);
                }
                Console.ReadLine();
            }
                
        }
    }
}
