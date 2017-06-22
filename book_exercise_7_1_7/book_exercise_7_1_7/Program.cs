/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.7
 * Page 14
 * 
 * Exercise notes:
 * Create a program:
 * output: Char output with different 
 *         UNICODE table values 
 * 
 * note: Use code from example 7.15:
 *       char myChar = (char)97;
 *       Console.WriteLine(myChar);
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

namespace book_exercise_7_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            char unicodeCharacter;
            byte count = 1;

            /* Output UNICODE characters 1 to 500 */
            for (int i = 1; i <= 500; i++)
            {
                unicodeCharacter = (char)i;
                Console.WriteLine("Code {0}: {1}", 
                    i.ToString("000"), // Leading zeroes, 3 digits
                    unicodeCharacter);

                /* Halt every 10 line, 
                 * press key to continue */
                if (count++ == 10) {
                    Console.WriteLine(
                        "Press any key to continue!");
                    Console.ReadLine();
                    count = 1;
                }

            }

            Console.Read();
        }
    }
}
