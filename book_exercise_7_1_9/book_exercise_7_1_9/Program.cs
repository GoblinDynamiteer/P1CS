/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.9
 * Page 15
 * 
 * Exercise notes:
 * Change the following code so output is 0.5:
 * 
 * int a = 1;
 * int b = 2;
 * float c = a / b;
 * Console.WriteLine(c);
 * 
 * Note: There are two solutions, find both.
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

namespace book_exercise_7_1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            float c = a / b; // integer division

            /* Will output 0 */
            Console.WriteLine(c);

            /* Typecast a or b */
            c = (float)a / b;
            Console.WriteLine(c);

            /* Use Convert, still need to typecast result */
            c = (float)(Convert.ToDouble(a) / b);
            Console.WriteLine(c);

            Console.Read();
        }
    }
}
