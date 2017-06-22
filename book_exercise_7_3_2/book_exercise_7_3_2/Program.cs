/* Programmering 1 C# Arbetsbok
 * Exercise 7.3.2
 * Page 16
 * 
 * Exercise notes:
 * Create a program: Check the weather (part 2):
 * 
 * Add feature to program: Check the weather (part 1):
 * IF USER INPUT == "n"
 *      OUTPUT "Let's stay inside and read a book!"
 *      
 * Note: Input shall be case insensitive
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

namespace book_exercise_7_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char answer;
            Console.WriteLine("Is it nice weather today? (y/n)");

            answer = Console.ReadKey(true).KeyChar;

            /* Char.ToLower() converts char to lowercase */
            if (Char.ToLower(answer) == 'y')
            {
                Console.WriteLine("Let's go on a picnic!");
                Console.ReadLine();
            }

            else if (Char.ToLower(answer) == 'n')
            {
                Console.WriteLine("Let's stay inside and read a book!");
                Console.ReadLine();
            }
            
        }
    }
}
