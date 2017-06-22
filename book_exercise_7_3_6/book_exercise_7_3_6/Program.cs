/* Programmering 1 C# Arbetsbok
 * Exercise 7.3.6
 * Page 17
 * 
 * Exercise notes:
 * Inspect the following code:
 *  int var = 10;
 *  if (var = 10)
 *      Console.WriteLine("it is 10!");
 *      
 * Why doesn't it compile?
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

namespace book_exercise_7_3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int var = 10;

            /* Faulty line, uses assignment operator
             * instead of relational operator*/
            //if (var = 10) 

            /* Corrected */
            if (var == 10)
                Console.WriteLine("it is 10!");

            Console.ReadLine();
        }
    }
}
