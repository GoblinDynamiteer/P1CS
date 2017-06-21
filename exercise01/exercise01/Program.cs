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
            double daysInLeapYear = 365.25;
            bool inputCorrect = false;
            DateTime birthDay;

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
                Console.Write("Enter age: ");

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

            /* Calculate age in days and display result, does not
             * account for leap years, and does not count days after
             * birthday */
            Console.WriteLine("You are {0} days old!", age * daysInLeapYear);

            /* Ask user for birth date */
            Console.WriteLine("When were you born?");

            do
            {
                Console.Write("Enter date as YYYY-MM-DD: ");
                /* DateTime.TryParse() converts string to DateTime
                 * returns true/false depending on conversion success  */
                inputCorrect = DateTime.TryParse(
                    Console.ReadLine(), 
                    out birthDay);

                /* If conversion was unsuccessful 
                 * (user didnt enter correct date format) */
                if (!inputCorrect)
                {
                    Console.WriteLine("Faulty date input!");
                }

            } while (!inputCorrect);
            
            /* Calculate time interval since birth,
             * DateTime.Now returns current local computer date and time */
            TimeSpan timeSinceBirth = DateTime.Now - birthDay;

            /* {X:N0} formats number to use 0 digits after decimal point
             * No rounding is occured */
            Console.WriteLine("** Data about your age ** " +
                "\nTotal birthdays: {0:N0}" +
                "\nYour age in months: {1:N0}" +
                "\nYour age in days: {2:N0}" +
                "\nYour age in hours: {3:N0}",
                timeSinceBirth.TotalDays / daysInLeapYear,
                timeSinceBirth.TotalDays / daysInLeapYear * 12,
                timeSinceBirth.TotalDays,
                timeSinceBirth.TotalDays * 24);

            Console.ReadLine();
        }

    }
}
