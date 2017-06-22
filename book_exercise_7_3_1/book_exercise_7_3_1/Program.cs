/* Programmering 1 C# Arbetsbok
 * Exercise 7.3.1
 * Page 16
 * 
 * Exercise notes:
 * Create a program: Check the weather (part 1):
 * 
 * OUTPUT "Is it nice weather today?"
 * IF USER INPUT == "y"
 *      OUTPUT "Let's go on a picnic!"
 * ELSE nothing
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

namespace book_exercise_7_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char answer;
            Console.WriteLine("Is it nice weather today? (y)");

            /* Get keypress char, bool indicates if 
             * pressed key skall be displayed in console window*/
            answer = Console.ReadKey(true).KeyChar;

            /* If user pressed the y-key */
            if (answer == 'y')
            {
                Console.WriteLine("Let's go on a picnic!");
                Console.ReadLine();
            }

        }
    }
}
