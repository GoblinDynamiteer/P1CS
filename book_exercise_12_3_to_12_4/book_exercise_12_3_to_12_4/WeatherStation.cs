/* Programmering 1 C# Arbetsbok 
 * Exercise 12.3 & 12.4 
 * Page 25
 *  
 * Exercise notes: 
 * Create a weather station with menu:
 * [A]dd temperature
 * [P]rint temperatures
 * [R]emove temperature
 * [Q]uit
 * 
 * When removing, enter list index
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

namespace book_exercise_12_3_to_12_4
{
    class WeatherStation
    {
        List<float> temperatures = new List<float>();

        public void AddTemperature(float temp)
        {
            temperatures.Add(temp);
        }

        public void removeTemperature(int index)
        {

            if (index + 1 > temperatures.Count 
                || index < 0)
            {
                Console.WriteLine("Index out of range!" + 
                    "\nPress any key to continue!");
                Console.ReadKey();
                return;
            }

            /* Removes element at index */
            temperatures.RemoveAt(index);
            Console.WriteLine("Removed element at index {0}!", 
                index);
        }

        public void ListTemperatures()
        {
            int index = 0;
            Console.Clear();
            Console.WriteLine("Recoreded temperaturs: ");
            foreach(float temp in temperatures)
            {
                Console.WriteLine("[{0}]: {1}", index++, temp);
            }

            Console.WriteLine("\nPress any key to continue!");
            Console.ReadKey();
        }
    }
}
