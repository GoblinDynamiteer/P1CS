/* Programmering 1 C# Arbetsbok 
 * Exercise 7.5.5 
 * Page 20
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
    class MyTemperature
    {
        public static bool IsBoiling(int temp)
        {
            return (temp > 100);
        }

        public static bool IsBoiling(float temp)
        {
            return (temp > 100);
        }

        public static int CelsiusToFahrenheit(int c)
        {
            float f = CTF((float)c);
            return (int)Math.Round(f);
        }

        public static float CelsiusToFahrenheit(float c)
        {
            return CTF(c);
        }

        public static float FahrenheitToCelcius(float f)
        {
            return FTC(f);
        }

        public static int FahrenheitToCelcius(int f)
        {
            float c = FTC((float)f);
            return (int)Math.Round(c);
        }

        /* Only visible inside class MyTemperature */
        private static float CTF(float c)
        {
            return c * 9 / 5 + 32;
        }

        private static float FTC(float f)
        {
            return (f - 32) * 5 / 9;
        }

    }
}
