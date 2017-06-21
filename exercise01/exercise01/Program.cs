/* Övning 1 - Utskrift och inmatning 
 * Programmering 1
 * 
 * Johan Kämpe
 * 2017-06-21
 * 
 * Exercise instructions:
 *  -   Ask for user input: first and last name
 *  -   Greet the user by name
 *  -   Ask for user input: age
 *  -   Calculate amount of days the user 
 *      has been alive, display result.
 *      
 * Extra:
 *  -   Handle incorrect user input, 
 *      eg. string input to int variable.
 *  -   Calculate amount of total birthdays,
 *      ask user for birth date
 *  -   Display detailed data about the users
 *      age; months, days, hours -- using DateTime
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName;
            int age;
            bool inputCorrect = false;

            /* Ask user for first and last name, 
             * save to variables */
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();

            /* Greet user by name and ask for age */
            Console.WriteLine("Hello {0} {1}!, how old are you? ",
                firstName,
                lastName);

            do
            {
                Console.Write("Enter age:");

                /* int.TryParse() converts string to integer
                 * returns true/false depending on conversion success  */
                inputCorrect = int.TryParse(Console.ReadLine(), out age);

                /* If conversion was unsuccessful 
                 * (user didnt enter a number) */
                if (!inputCorrect)
                {
                    Console.WriteLine("Faulty age input!");
                }

            } while (!inputCorrect);

            /* Calculate age in days and display result */
            Console.WriteLine("You are {0} days old!", age * 365);

            Console.ReadLine();
        }

    }
}
