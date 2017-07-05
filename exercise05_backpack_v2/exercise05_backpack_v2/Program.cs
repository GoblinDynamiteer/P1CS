/* Övning 5 - Vektorer 
 * Programmering 1
 * 
 * Exercise instructions:
 *  Modify exercise 2 "The backpack":
 *  
 *  - Add menu item: Search for item 
 *    (Use linear search)
 *  - Store items in an array (max five items)
 *  - Use a for-loop to print the contents of the
 *    backpack
 *  - Use a switch-statement for the menu
 *  - Handle incorrect input
 *
 * Johan Kämpe
 * 2017-07-04
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */

using System;

namespace exercise05_backpack_v2
{
    class Program
    {
        public static BackPack backPack = new BackPack();

        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();

            while (true)
            {
                mainMenu.ShowMainMenu();
                mainMenu.Navigate();
            }
        }
    }

    public class Menu
    {
        /* Menu text */
        static string menuTitle = "BACKPACK V2!";

        public static string menuIndent = "     "; // for text indentation
        static string [] menuHelp = {
            "Use the up and down arrow keys to navigate!",
            "Use the return key to select a menu item.",
            "Or press the menu item number to enter menu" };
        static string[] menuItem = {
            "Add an item to the backpack",
            "Display backpack contents",
            "Search for item",
            "Clear backpack contents",
            "Quit"
        };

        /* Text colors */
        public const ConsoleColor colorTitle = ConsoleColor.Cyan;
        public const ConsoleColor colorHighlighted = ConsoleColor.Green;
        public const ConsoleColor colorDefault = ConsoleColor.White;
        public const ConsoleColor colorHelp = ConsoleColor.DarkGray;
        public const ConsoleColor colorWarning = ConsoleColor.Red;

        /* Displays menu text, with options: 
         *  new line after text, indented, color */
        public static void DisplayText(string text, bool newLine = true, 
            bool indent = true, ConsoleColor color = colorDefault)
        {
            /* Set text color */
            Console.ForegroundColor = color;

            Console.Write("\n{0}{1}{2}",
                indent ? menuIndent : "",
                text,
                newLine ? "\n" : "");

            Console.ForegroundColor = colorDefault;
        }

        public static void DisplayTitle()
        {
            Console.Clear();

            DisplayText(menuTitle, false, true, colorTitle);

            string line = "";

            /* A nice looking line under menu title */
            for (int i = 0; i < menuTitle.Length; i++)
            {
                line += "-";
            }

            DisplayText(line);
        }

        /* Used with switch statement in 
         * method MenuAction() */
        private enum menuItemId
        {
            Add,
            Display,
            Search,
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
            DisplayTitle();

            /* List menu items */
            for (int i = 0; i < menuItem.Length; i++)
            {
                bool markItem = (currentSelection == i);
                /* Indicate current selection with "***"  */
                string displayText = string.Format("{0} {1}", 
                    i + 1, menuItem[i]);

                if (markItem)
                {
                    /* If current selected item, mark by "****"  */
                    DisplayText("**** " + displayText + " ****", 
                        false, false, colorHighlighted);

                    /* continue skips current loop iteration,
                     * goes to next cycle in loop*/
                    continue; 
                }

                DisplayText(displayText, false);

            }

            /* Display menu help on navigation */
            Console.WriteLine();
            foreach (string line in menuHelp)
            {
                DisplayText(line, false, true, colorHelp);
            }
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
                        menuItem.Length - 1 : currentSelection - 1;
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
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    /* KeyChar returns actual character 
                     * from pressed key. 
                     * Convert to int for MenuAction().
                     * int.Parse() requires string -- 
                     * concatenate char with "".
                     */
                    MenuAction(
                        int.Parse("" + keyPress.KeyChar) - 1);
                    break;

                /* Other */
                default:
                    break;
            }
        }

        /* Halt program and ask user to press any key to continue */
        public static void PressAnyKey(string message = "")
        {
            DisplayText(message);
            DisplayText("Press any key to continue!");
            Console.ReadKey(true);
        }

        /* Menu item selection actions */
        public void MenuAction(int menuItem)
        {
            switch (menuItem)
            {
                case (int)menuItemId.Add:
                    Program.backPack.AddItem();

                    break;

                case (int)menuItemId.Display:
                    Program.backPack.DisplayItems();
                    PressAnyKey();
                    break;

                case (int)menuItemId.Search:
                    Program.backPack.SearchItem("");
                    PressAnyKey();
                    break;

                case (int)menuItemId.Clear:
                    Program.backPack.ClearItems();
                    PressAnyKey();
                    break;

                case (int)menuItemId.Quit:
                    DisplayTitle();
                    PressAnyKey("Program will quit! :(");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public class BackPack
    {
        /* Max amount of items in backpack */
        const int maxItems = 5;

        /* Create an array of strings */
        static string[] items = new string[maxItems];
        
        /* Keep track of amount of items added */
        static int itemsAdded = 0;


        /* Add an item to backpack. */
        public void AddItem()
        {
            Menu.DisplayTitle();

            /* If backpack is full */
            if (itemsAdded == maxItems)
            {
                Menu.PressAnyKey("Backpack is full!");
                return; // Ends void method
            }

            Menu.DisplayText("Enter item to add: ", false);
            string item = Console.ReadLine();

            /* Prevent empty input */
            while (item == "")
            {
                Menu.DisplayTitle();
                Menu.DisplayText("Try Again (Don't enter empy items): ", false);
                item = Console.ReadLine();
            }

            /* ++var increases var by 1, then uses it's value */
            items[++itemsAdded - 1] = item;

        }

        public void SearchItem(string item)
        {
            Menu.DisplayTitle();
            Menu.DisplayText("Enter item to search for: ", false);

            /* Case insensitive */
            string searchString = Console.ReadLine().ToLower();

            /* Linear search */
            for (int i = 0; i < maxItems; i++)
            {
                /* String found */
                if (searchString == (items[i].ToLower()))
                {
                    Menu.DisplayText(
                        String.Format("Item found in backpack: {0}", 
                            items[i]));
                    return; // End search (and method)
                }

            }

            Menu.DisplayText("Item not found in backpack!");
        }


        public void DisplayItems()
        {
            Menu.DisplayTitle();

            /* Determine if backpack is empty */
            if (itemsAdded == 0)
            {
                Menu.DisplayText("Backpack is empty!",
                    true, true, Menu.colorWarning);
            }

            else
            {
                Menu.DisplayText("Items in backpack:");

                for (int i = 0; i < itemsAdded; i++)
                {
                    Menu.DisplayText(items[i], false);
                }
            }
        }


        /* Remove all items in backpack */
        public void ClearItems()
        {
            Menu.DisplayTitle();

            for (int i = 0; i < maxItems; i++)
            {
                items[i] = null;
            }

            Menu.DisplayText("Items Cleared!");
            itemsAdded = 0;
        }
    }
}

