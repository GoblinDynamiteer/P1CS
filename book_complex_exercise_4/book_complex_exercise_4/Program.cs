/* Programmering 1 C# Arbetsbok   
 * Complex Exercise 4
 * Page 35
 *    
 * Exercise notes: 
 * Create a method that takes an int as
 * parameter. It shall print all prime
 * numbers between 1 and that integer.
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
using UserInput; // Own class lib

namespace book_complex_exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPrimes(User.InputInt("Enter a number: "));
            User.PressAnyKey("Press any key to quit.");
        }

        /* Check and print numbers */
        static void PrintPrimes(int numbers)
        {
            for (int i = 1; i <= numbers; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        /* Check if a number is a prime number */
        static bool IsPrime(int number)
        {
            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
