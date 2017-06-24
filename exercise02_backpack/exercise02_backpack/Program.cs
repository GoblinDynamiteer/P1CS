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
        /* Make BackPack object public, to be accessable
         * in Menu class */
        public static BackPack backPack = new BackPack();
        static Menu menu = new Menu();

        

        static void Main(string[] args)
        {
            /* Endless loop*/
            while (true)
            {
                menu.ShowMainMenu();
                menu.Navigate();
            }
        }
    }

    public class Menu
    {
        /* Menu text */
        static string menuTitle = "Welcome to the backpack!";
        public static string menuIndent = "     "; // for text indentation
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

        /* Used with switch statement in 
         * method MenuAction() */
        private enum menuItemId
        {
            Add,
            Display,
            Clear,
            Quit
        }

        /* Keeps track of currently highlighted 
         * menu item */
        int currentSelection = 0;


        /* Generate main menu */
        public void ShowMainMenu()
        {
            /* Clear console text and print title */
            Console.Clear();
            Console.Write("\n{0}{1}\n{0}",
                menuIndent,
                menuTitle);

            /* Print a nice looking line under menu title */
            for (int i = 0; i < menuTitle.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");


            /* List menu items */
            for (int i = 0; i < menuItem.Length; i++)
            {
                /* Indicate current selection with "***"  */
                string displayText = (currentSelection == i) ?
                    String.Format(" *** [{0}] {1}  ***", 
                        i + 1, menuItem[i]) :
                    String.Format("{2}[{0}] {1}", 
                        i + 1, menuItem[i], menuIndent);

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
                case ConsoleKey.NumPad1:
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
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

        public void menuPressAnyKey(string message = "")
        {
            Console.WriteLine("\n{0}{1}", menuIndent, message);
            Console.WriteLine("{0}Press any key to continue!", 
                menuIndent);
            Console.ReadKey(true);
        }

        /* Menu item selection actions */
        public void MenuAction(int menuItem)
        {
            switch (menuItem)
            {
                case (int)menuItemId.Add:
                    Console.Clear();
                    Console.Write("\n{0}Enter item to add: ", 
                        menuIndent);
                    string addItem = Console.ReadLine();

                    if (addItem != "")
                    {
                        Program.backPack.AddItem(addItem);
                        menuPressAnyKey(
                            string.Format("Item [{0}] added!",
                                addItem));
                    }
                    
                    break;

                case (int)menuItemId.Display:
                    Console.Clear();
                    Program.backPack.DisplayItems();
                    menuPressAnyKey();
                    break;

                case (int)menuItemId.Clear:
                    Console.Clear();
                    Program.backPack.ClearItems();
                    menuPressAnyKey();
                    break;

                case (int)menuItemId.Quit:
                    Console.Clear();
                    menuPressAnyKey("Program will quit!");
                    Environment.Exit(0);
                    break;
            }
        }
    }


    /* Items for the backpack */
    public class Item
    {
        public string name { get; set; }
        public int count { get; set; }
    }

    public class BackPack
    {
        /* List of Item class objects */
        static List<Item> items = new List<Item>();


        /* Add an item to backpack. */
        public void AddItem(string itemName)
        {
            bool newItem = true;

            /* Check if item name already exists */
            for (int i = 0; i < items.Count; i++)
            {
                /* Item already in list, increase count
                 * by one and end function */
                if (items[i].name == itemName) {
                    items[i].count++;
                    newItem = false;
                }
            }

            /* Item was not found, add new item with count of 1 */
            if (newItem)
            {
                items.Add(new Item { name = itemName, count = 1 });
            }
            
        }


        public void DisplayItems()
        {
            /* Determine if item list is empty */
            bool listEmpty = !items.Any();
            int spacing = 35;

            if (listEmpty)
            {
                Console.WriteLine("\n{0}Backpack is empty!", 
                    Menu.menuIndent);
            }


            else
            {
                Console.WriteLine("\n{0}Items in backpack", 
                    Menu.menuIndent);
                DisplayItemsText("Name:", "Amount:\n", 
                    spacing);

                /* Sort item list by item name */
                items.Sort((x, y) => x.name.CompareTo(y.name));

                foreach (Item item in items)
                {
                    DisplayItemsText(
                        item.name, 
                        item.count.ToString(), 
                        spacing);
                }

                /* Print out total amount of items */
                Console.WriteLine();
                DisplayItemsText(
                    "Total:", 
                    CountItems().ToString(), 
                    spacing);
            }

        }

        /* Helper method for DisplayItems, 
        * right adjust string b in a column */
        private void DisplayItemsText(string a, string b, 
            int adjustment)
        {
            adjustment -= a.Length - b.Length;
            string bAdjusted = string.Format(
                "{0," + adjustment + "}", b);
            string display = string.Format("{0}{1}{2}",
                Menu.menuIndent, a, bAdjusted);
            Console.WriteLine(display);
        }


        /* Count total amount of items */
        private int CountItems()
        {
            int sum = 0;

            if (items.Any())
            {
                foreach (Item item in items)
                {
                    sum += item.count;
                }
            }
            
            return sum;
        }


        /* Clear item list */
        public void ClearItems()
        {
            Console.WriteLine("\n{0}Items cleared!", 
                Menu.menuIndent); 
            items.Clear();
        }
    }
}
