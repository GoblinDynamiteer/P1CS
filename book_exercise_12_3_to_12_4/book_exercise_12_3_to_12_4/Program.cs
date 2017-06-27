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
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation Station = new WeatherStation();

            char userInput = 's';

            do
            {
                ShowMenu();
                userInput = Console.ReadKey().KeyChar;

                switch (char.ToLower(userInput))
                {
                    case 'a':
                        Console.Write("\nEnter temperature: ");
                        float temp;
                        if (float.TryParse(Console.ReadLine(), out temp))
                            Station.AddTemperature(temp);
                        break;

                    case 'r':
                        Console.Write("\nEnter index to remove: ");
                        int index;
                        if (int.TryParse(Console.ReadLine(),out index))
                            Station.removeTemperature(index);
                        break;

                    case 'p':
                        Station.ListTemperatures();
                        break;

                    default:
                        break;
                }

            } while (Char.ToLower(userInput) != 'q');
            
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.Write("WeatherStation!\n" +
                "\n[A]dd temperature" +
                "\n[P]rint temperatures" +
                "\n[R]emove temperature" +
                "\n[Q]uit"+
                "\n\nEnter Choice: ");
        }
    }
}
