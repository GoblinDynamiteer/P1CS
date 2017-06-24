﻿/* Övning 2 - Ryggsäcken
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
        /* Menu text */
        static string menuTitle = "Welcome to the backpack!";
        static string menuIndent = "     ";
        static string menuHelp = string.Format("{0}{1}\n{0}{2}\n{0}{3}",
            menuIndent,
            "Use the up and down arrow keys to navigate!",
            "Use the return key to select a menu item.",
            "Or press the menu item number to enter menu");
        static string[] menuItem = {
            "Add an item to the backpack",
            "Display backpack contents",
            "Clear backpack contents",
            "Quit"
        };

        /* Keeps track of current selected menu item */
        int currentSelection = 0;

        /* Display main menu, highlight current menu item */
        public void ShowMainMenu()
        {
            Console.Clear(); // Clear console window
            Console.Write("\n{0}{1}\n{0}",
                menuIndent,
                menuTitle);

            /* Write a nice looking line under menu title */
            for (int i = 0; i < menuTitle.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");


            /* List menu items */
            for (int i = 0; i < menuItem.Length; i++)
            {
                /* Idicate current selection with "***"  */
                string displayText = (currentSelection == i) ?
                    String.Format(" *** [{0}] {1}  ***", i + 1, menuItem[i]) :
                    String.Format("{2}[{0}] {1}", i + 1, menuItem[i], menuIndent);

                Console.WriteLine(displayText);
            }

            /* Display menu help on navigation */
            Console.WriteLine("\n" + menuHelp);
        }

        /* Navigate the main menu */
        public void Navigate()
        {
            /* Wait for keypress, get pressed key */
            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                /* Navigate up in menu 
                 * (or roll over to last item) */
                case ConsoleKey.UpArrow:
                    currentSelection =
                        (currentSelection - 1 < 0) ?
                        3 : currentSelection - 1;
                    break;

                /* Navigate down in menu 
                 * (or roll over to item 1) */
                case ConsoleKey.DownArrow:
                    currentSelection =
                        (currentSelection + 1 < menuItem.Length) ?
                        currentSelection + 1 : 0;
                    break;

                /* Select current selected menu item 
                 * with enter key */
                case ConsoleKey.Enter:
                    MenuAction(currentSelection);
                    break;

                /* Number keys, goes directly into menu */
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                    /* KeyChar returns actual character 
                     * from pressed key. 
                     * Convert to int for MenuAction().
                     * int.Parse() requires string -- 
                     * concatenate char with "".
                     */
                    MenuAction(
                    int.Parse("" + keyPress.KeyChar) - 1);
                    break;

                default:
                    break;
            }
        }

        /* Menu item selection actions */
        public void MenuAction(int menuItem)
        {
            switch (menuItem)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("<ADD ITEM PLACEHOLDER>");
                    Console.ReadKey(true);
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("<DISPLAY ITEM PLACEHOLDER>");
                    Console.ReadKey(true);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("<CLEAR ITEM PLACEHOLDER>");
                    Console.ReadKey(true);
                    break;

                case 3: // Quit program
                    Environment.Exit(0);
                    break;
            }
        }
    }

}
