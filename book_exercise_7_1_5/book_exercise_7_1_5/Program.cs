/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.5
 * Page 14
 * 
 * Exercise notes:
 * Create a program:
 * input: two person names
 * output: a short story about the persons
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

namespace book_exercise_7_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameA, nameB;

            Console.Write("Enter a name: ");
            nameA = Console.ReadLine();

            Console.Write("Enter another name: ");
            nameB = Console.ReadLine();

            /* The story */
            Console.WriteLine("{0} and {1} are friends!" +
                "\n{1} likes lettuce!", nameA, nameB);

            Console.Read();
        }
    }
}
