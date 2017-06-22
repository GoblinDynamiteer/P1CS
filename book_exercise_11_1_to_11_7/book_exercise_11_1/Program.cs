/* Programmering 1 C# Arbetsbok  
 * Exercises 11.1 - 11.7  
 * Page 23
 *   
 * Exercise notes:  
 * Create methods:
 *  Hello() : parameter string, print out with
 *            another message.
 *  
 *  JoinStrings() : two string as parameters
 *                  join them and return string
 *  
 *  Add() : Return the sum of two int parameters
 *  
 *  CalcTax() : Return sum with a tax of 25%
 *              if input parameter is 100, return
 *              value is 125
 *              
 *  CalcTax() : Return sum with chosen tax
 *  
 *  ToPercentage() : Convert a fractional value to
 *                   percentage. eg. 0.74 to 74
 *                   
 *  IsMinor() : Return a bool, showing if a person
 *              is a minor. Input age.
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

namespace book_exercise_11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello("Cucumber!");
            string jt = JoinStrings("Hej! ",
                "Din gamle galosch!");
            Console.WriteLine(jt);
            Console.WriteLine("Tax: {0}", CalcTax(100));
            Console.WriteLine("Tax: {0}", CalcTax(100, 0.34));
            Console.WriteLine("Percentage: {0}", ToPercentage(0.33));

            int age = 16;
            string text = IsMinor(age) ? "minor" : "major";
            Console.WriteLine("A person of age {0} is a {1}", age, text);

            age = 23;
            text = IsMinor(age) ? "minor" : "major";
            Console.WriteLine("A person of age {0} is a {1}", age, text);

            Console.ReadLine();

        }

        static void Hello(string text)
        {
            Console.WriteLine("I got: {0}", text);
        }

        static string JoinStrings(string textA, string textB)
        {
            return textA + textB;
        }

        /* Default value in parameter tax */
        static double CalcTax(double value, double tax = 0.25)
        {
            return value * tax + value;
        }

        static int ToPercentage(double frac)
        {
            return (int)(100 * frac);
        }

        static bool IsMinor(int age)
        {
            return (age < 18);
        }
    }
}
