/* Programmering 1 C# Arbetsbok 
 * Exercise 11.9
 * Page 24
 *  
 * Exercise notes: 
 * Redesign the code in example 11.15.
 * Build an internal method for the class
 * MyTemperature.cs. The method shall be
 * private. Name the method CTF();
 * 
 * Also, built another method FTC(),
 * that converts degrees in fahrenheit
 * to celsius.
 * 
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

namespace book_exercise_11_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 32;
            float tempFloat = 32.4f;

            Console.WriteLine("{0} C = {1} F",
                temp, MyTemperature.CelsiusToFahrenheit(temp));

            Console.WriteLine("{0} C = {1} F",
                tempFloat, MyTemperature.CelsiusToFahrenheit(tempFloat));

            temp = 84;
            tempFloat = 98.1f;

            Console.WriteLine("{0} F = {1} C",
                temp, MyTemperature.FahrenheitToCelcius(temp));

            Console.WriteLine("{0} F = {1} C",
                tempFloat, MyTemperature.FahrenheitToCelcius(tempFloat));

            Console.ReadLine();
        }
    }
}
