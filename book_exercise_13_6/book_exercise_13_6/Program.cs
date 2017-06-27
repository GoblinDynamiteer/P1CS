/* Programmering 1 C# Arbetsbok 
 * Exercise 13.6
 * Page 28
 *  
 * Exercise notes: 
 * Change exercise 7.3.4 to not have a set 
 * amount of cities. 
 * 
 * The user shall be able to
 *  - Add cities / temperature
 *  - Show temeperature for all cities
 *  - Show averege temperature
 *  - Show coldest / warmest cities
 *  
 * The program shall handle incorrect inputs
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


namespace book_exercise_13_6
{
    class Program
    {
        static void Main(string[] args)
        {
            CityTemperatures ct = new CityTemperatures();
            bool quit = false;

            do
            {
                Menu.ShowMenu();

                switch (User.InputChar("\n Enter menu choice."))
                {
                    case '1':
                        Console.Clear();
                        string name = 
                            User.InputString("Enter City name: ");
                        float temp = 
                            User.InputFloat("Enter temperature:");
                        ct.AddCity(name, temp);
                        break;

                    case '2':
                        Console.Clear();
                        ct.ListCities();
                        User.PressAnyKey("Press any key to continue.");
                        break;

                    case '3':
                        quit = true;
                        break;

                    default:
                        break;

                }

            } while (!quit);

        }
    }

    class Menu
    {
        static string [] menuItems = {
            "Add city", "Show temperatures", "Quit" };

        public static void ShowMenu()
        {
            int itemNumber = 1;

            Console.Clear();

            foreach (string item in menuItems)
            {
                Console.Write("[{0}] ", itemNumber++);
                Console.WriteLine(item);
            }
        }
    }
}

