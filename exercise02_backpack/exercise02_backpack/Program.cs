/* Övning 2 - Ryggsäcken
 * Programmering 1
 * 
 * Exercise instructions:
 *  Create a "backpack" in in wich the user
 *  can add an item to it by entering a 
 *  string value.
 *  
 *  The program shall display a menu:
 *  (Translated to English)
 *  
 *  Welcome to the backpack!
 *  [1] Add an item
 *  [2] Display backpack contents
 *  [3] Clear backpack contents
 *  [4] Quit
 *  Choose:
 * 
 *  -   Items added with menu item 1 
 *      shall be saved
 *  -   Added items shall be displayed 
 *      with menu item 2
 *  -   Added items shall be cleares 
 *      with menu item 3
 *  
 * Extra:
 *  -   Handle incorrect user input
 *  -   Save items to an array or list
 *  -   Use classes and methods to build 
 *      the program
 *
 * Johan Kämpe
 * 2017-06-24
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise02_backpack
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while (true)
            {
                menu.ShowMainMenu();
                menu.Navigate();
            }
        }
    }

    class Menu
    {
        static string menuTitle = "Welcome to the backpack!";
        static string[] menuItem = {
            "Add an item",
            "Display backpack contents",
            "Clear backpack contents",
            "Quit"
        };

        int currentSelection = 0;
        int currentMenu = 0;

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine(menuTitle);

            for (int i = 0; i < menuItem.Length; i++)
            {
                string displayText = (currentSelection == i) ?
                    String.Format("*{0}* {1}", i + 1, menuItem[i]) :
                    String.Format("[{0}] {1}", i + 1, menuItem[i]);

                Console.WriteLine(displayText, i+1,
                    menuItem[i]);
            }
        }

        public void Navigate()
        {
            switch ( Console.ReadKey(true).Key )
            {
                case ConsoleKey.UpArrow:
                    currentSelection = 
                        (currentSelection - 1 < 0) ?
                        3 : currentSelection - 1;
                    break;

                case ConsoleKey.DownArrow:
                    currentSelection = 
                        (currentSelection + 1 < menuItem.Length) ?
                        currentSelection + 1 : 0;
                    break;

                default:
                    break;
            }
        }
    }

}
