/* Programmering 1 C# Arbetsbok
 * Exercise 7.3.4 (& 7.3.5)
 * Page 16 (& 17)
 * 
 * Exercise notes:
 * Create a program: Where is it coldest? (part 1 (& 2)):
 * USER INPUT Temperature for two (three) cities: 
 *            "Östersund" and "Åmål" (and "Arboga")
 * OUTPUT Which city has the coldest temperature
 * 
 * Note: I didn't follow the exercise instructions.
 * I used an object arran and loops to determine coldest
 * city. Instead of using if/else if/else blocks.
 * 
 * I wanted to practice with classes and objects.
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

namespace book_exercise_7_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Add a string to array to add a city */
            string[] cityNames = {
                "Östersund",
                "Åmål",
                "Arboga",
                "Linköping",
                "Motala"
            };
            
            /* Declare an assign an array of cities */
            City [] cities = new City[cityNames.Length];
            for (int i = 0; i < cities.Length; i++)
            {
                cities[i] = new City();
                cities[i].Name = cityNames[i];
            }

            /* User input for city temperature */
            for (int i = 0; i < cities.Length; i++)
            {
                cities[i].SetTemperature();
            }

            int coldestIndex = 0; // Array index for coldest city
            double checkTemperature = cities[0].GetTemperature();

            /* Find array item with coldest temperature */
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i].GetTemperature() < checkTemperature)
                {
                    coldestIndex = i;
                    checkTemperature = cities[i].GetTemperature();
                }
            }

            /* Output coldest city */
            Console.WriteLine("{0} has the coldest weather!",
                cities[coldestIndex].Name);
            Console.ReadKey();
        }
    }

    class City
    {
        double Temperature;
        public string Name { get; set; }

        public void SetTemperature()
        {
            Console.Write("Enter temperature for {0}: ", Name);
            Temperature = Convert.ToDouble(Console.ReadLine());
        }

        public double GetTemperature()
        {
            return Temperature;
        }
    }
}
