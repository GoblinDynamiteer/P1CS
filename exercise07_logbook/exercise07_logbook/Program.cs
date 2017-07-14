/* Examinerande uppgift - Loggboken
 * Programmering 1
 * 
 * Instructions:
 *  - Create a logbook based on pseudocode
 *    from exercise 3.
 *  - Study the pseudo code, what changes are
 *    needed? Update and write documentation.
 *  
 *  Needed:
 *   - A main meny, using switch-case
 *   - Prevent runtime errors
 *   - Print logbook contents
 *   - Save new log entries (Use lists/arrays)
 *   - Search log entries (Implement search algorithm)
 *   
 *  Extras:
 *   - Time/Date for log entries
 *   - Edit/delete log entries
 *   - Create one or several methods
 *  
 * Johan Kämpe
 * 2017-07-13
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */

using System;
using System.Collections.Generic;

namespace exercise07_logbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Logbook logbook = new Logbook();

            /* Add some sample entries */
            logbook.AddEntry("A day at the zoo!", "I went to the " +
                "zoo with my family today, we saw monkies and giraffes!!");
            logbook.AddEntry("Today's lunch", "I had pancakes with whipped " +
                "cream and strawberry jam today!");

            int userChoice = 0; // User meny choice
            while (userChoice != (int)Menu.MenuItem.Quit)
            {
                userChoice = Menu.DisplayMenu();

                switch (userChoice)
                {
                    case (int)Menu.MenuItem.Add:
                        Menu.DisplayTitle("Add log entry");
                        logbook.AddEntry();
                        break;

                    case (int)Menu.MenuItem.ListAll:
                        Menu.DisplayTitle("All logbook entries");
                        logbook.DisplayAllEntries();
                        break;

                    case (int)Menu.MenuItem.Search:
                        Menu.DisplayTitle("Search entries");
                        logbook.Search();
                        break;

                    default:
                        break;
                }
            }

            Menu.DisplayTitle();
            Menu.Wait("Thanks for using the logbook!\n" +
                "Press any key to quit...");
            Console.ReadKey(true);
        }

    }

    /* Class for logbooks */
    class Logbook
    {
        /* List for holding logbook entries */
        List<string[]> entries;

        /* Array for holding indexes for searches */
        int[] searchHits;

        string lastSearchString;
        int id = 0; // For setting entry id

        /* Enums used for search */
        enum SearchData
        {
            Empty = -1,
            MaxHits = 50
        }

        /* Enums used for entry string array indexes */
        enum EntryData
        {
            Title,      // 0
            Content,    // 1
            Date,       // 2
            ID          // 3
        }

        /* Error messages */
        string[] errorMsg = {
            "Error: Could not convert log " +
                "entry id to integer!",             // 0
            "Error: Entry ID not found!",           // 1
            "Error: Entry text cannot be blank!",   // 2
            "Error: Faulty ID input!"               // 3
        };

        /* Indexes for error messages */
        enum ErrorId
        {
            IDToIndexConvertFail,       // 0
            EntryIDNotFound,            // 1
            BlankEntry,                 // 2
            FaultyIntInput              // 3
        }
        
        /* Constructor */
        public Logbook()
        {
            /* List of string vectors, for holding logbook entries */
            entries = new List<string[]>();

            searchHits = new int[(int)SearchData.MaxHits];
            lastSearchString = "";
            ClearSearchHits();
        }

        /* Clear search hit list */
        void ClearSearchHits()
        {
            for (int i = 0; i < (int)SearchData.MaxHits; i++)
            {
                searchHits[i] = (int)SearchData.Empty;
            }
        }

        /* Search entries, returns hits */
        public void Search(string searchString)
        {
            ClearSearchHits();
            lastSearchString = searchString;
            int hits = 0;

            /* Linear search */
            foreach (string[] entry in entries)
            {
                /* Max hits found, break */
                if (hits == (int)SearchData.MaxHits)
                {
                    break;
                }

                if (entry[(int)EntryData.Content].Contains(searchString) ||
                    entry[(int)EntryData.Title].Contains(searchString) ||
                    entry[(int)EntryData.Date].Contains(searchString))
                {
                    /* Add entry index to search hits array */
                    searchHits[hits++] = int.Parse(entry[(int)EntryData.ID]);
                }
            }
            DisplaySearchHits(hits);
        }

        /* Search entries, manual input, returns hits */
        public void Search()
        {
            Console.Write("Enter search string: ");
            string search = Console.ReadLine();
            Search(search);
        }

        /* Display entries stored in searchHits array */
        public void DisplaySearchHits(int hits)
        {
            Menu.DisplayTitle(string.Format("Search: Found {0} hits for {1}", 
                hits, lastSearchString));
            Console.WriteLine("ID\tDATE\t\t\tTITLE");
            for (int i = 0; i < (int)SearchData.MaxHits; i++)
            {
                if (searchHits[i] == (int)SearchData.Empty)
                {
                    break;
                }

                DisplayTitle(int.Parse(entries[searchHits[i]][(int)EntryData.ID]));
            }

            Console.WriteLine();
            DisplayEntry();
        }

        /* Display all log entries */
        public void DisplayAllEntries()
        {
            Console.WriteLine("ID\tDATE\t\t\tTITLE");

            entries.ForEach(entry => DisplayTitle(int.Parse(entry[(int)EntryData.ID])));

            Console.WriteLine();
            DisplayEntry();
        }

        /* List title with id */
        void DisplayTitle(int id)
        {
            int index = FindEntryIndex(id);
            string entryId = entries[index][(int)EntryData.ID];
            string entryTitle = entries[index][(int)EntryData.Title];
            string entryDate = entries[index][(int)EntryData.Date];
            Console.WriteLine("[{0}]\t[{1}]\t[{2}] ", entryId, entryDate, entryTitle);
        }

        /* Add entry to logbook, with passed parameters */
        public int AddEntry(string title, string content)
        {
            /* Add logbook entry contents to string array */
            string[] stringEntry = new string[4];
            stringEntry[(int)EntryData.Title] = title;
            stringEntry[(int)EntryData.ID] = id++.ToString();
            stringEntry[(int)EntryData.Date] = DateTime.Now.ToString();
            stringEntry[(int)EntryData.Content] = content;

            /* Add string array to list */
            entries.Add(stringEntry);

            Console.WriteLine("Added new entry: ");
            DisplayTitle(id-1);

            return id - 1;
        }

        /* Add entry to logbook, manual input */
        public void AddEntry()
        {
            string title, content;
            Console.Write("Enter title for new entry: ");
            title = Console.ReadLine();

            /* Set title to "Untitled entry" if empty input */
            title = title == "" ? "Untitled entry" : title;

            Console.WriteLine("Enter text for new entry: ");
            content = Console.ReadLine();

            while (content == "")
            {
                Menu.Error(errorMsg[(int)ErrorId.BlankEntry], false);
                Console.WriteLine("Enter text for new entry: ");
                content = Console.ReadLine();
            }

            AddEntry(title, content);
        }

        /* Delete entry */
        public void DeleteEntry(int id)
        {
            entries.RemoveAt(id);
            Menu.Wait(String.Format("Entry with id {0} deleted!\n" +
                "Press any key to continue", id));
        }

        public void DisplayEntry()
        {
            Console.Write("Enter entry ID: ");
            string stringID = Console.ReadLine();

            if (!int.TryParse(stringID, out int id))
            {
                Menu.Error(errorMsg[(int)ErrorId.FaultyIntInput], true);
                return;
            }

            DisplayEntry(id);
        }

        /* Display a log entry, pass id as parameter */
        public void DisplayEntry(int id)
        {
            /* Search for list index */
            int index = FindEntryIndex(id);

            if (index == -1) // Error
            {
                Menu.Error(errorMsg[(int)ErrorId.EntryIDNotFound], true);
                return;
            }

            /* Text output */
            Menu.DisplayTitle(entries[index][(int)EntryData.Title], true, false);
            Menu.DisplayTitle(entries[index][(int)EntryData.Date], false, true, false);
            Console.WriteLine(entries[index][(int)EntryData.Content]);
            Menu.DisplayLine();
            Console.WriteLine("Options:\n(E)xport | Change (T)itle | Change (C)ontent | (D)elete\n" +
                "Press any other key to return to main menu. ");

            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.E:
                    Console.WriteLine("TEMP EXPORT");
                    break;

                case ConsoleKey.T:
                    EditTitle(id);
                    break;

                case ConsoleKey.C:
                    EditContent(id);
                    break;

                case ConsoleKey.D:
                    if (Menu.Confirm("Are you sure? Press (Y) " +
                        "to delete entry: ", 'Y'))
                    {
                        DeleteEntry(id);
                    }
                    break;

                default:
                    break;
            }

        }

        /* Edit entry Title */
        public void EditTitle(int id)
        {
            /* Search for list index */
            int index = FindEntryIndex(id);

            if (index == -1) // Error
            {
                Menu.Error(errorMsg[(int)ErrorId.EntryIDNotFound]);
                return;
            }

            Console.WriteLine("Enter new title: ");
            string newTitle = Console.ReadLine();

            UpdateEntry(index, newTitle);
        }

        /* Edit entry content (text) */
        public void EditContent(int id)
        {
            /* Search for list index */
            int index = FindEntryIndex(id);

            if (index == -1) // Error
            {
                Menu.Error(errorMsg[(int)ErrorId.EntryIDNotFound]);
                return;
            }

            Console.WriteLine("Enter new content: ");
            string newContent = Console.ReadLine();

            UpdateEntry(index, "", newContent);
        }

        /* Edit entry -- Only non blank parameters are updated */
        void UpdateEntry(int index, string title = "", string content = "")
        {
            /* Update entry content that needs updating */
            entries[index][(int)EntryData.Title] = title == "" ? 
                entries[index][(int)EntryData.Title] : title;
            entries[index][(int)EntryData.Content] = content == "" ? 
                entries[index][(int)EntryData.Content] : content;
        }
        
        /* Find entry list index from id */
        int FindEntryIndex(int id)
        {
            int retval = -1; // Return -1 if id not found
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i][(int)EntryData.ID] == id.ToString())
                {
                    retval = i;
                }
            }

            return retval;
        }
    }

    class Menu
    {
        /* Enums for menu selection */
        public enum MenuItem
        {
            Add,
            ListAll,
            Search,
            Quit
        }

        static int lineLen = 60;

        /* Display the main menu for the logbook */
        static public int DisplayMenu()
        {
            string[] menuItems =
            {
                "Add logbook entry",
                "List all logbook entries",
                "Search",
                "Quit"
            };

            DisplayTitle();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" [{0}] {1}", i + 1, menuItems[i]);
            }

            Menu.DisplayLine();
            Console.Write("Press key to select menu: ");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    return (int)MenuItem.Add;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    return (int)MenuItem.ListAll;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    return (int)MenuItem.Search;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    return (int)MenuItem.Quit;

                default:
                    return -1;
            }

        }

        /* Display any title text, centered */
        static public void DisplayTitle(string text = "The Logbook", 
            bool line1 = true, bool line2 = true, bool clearScreen = true)
        {
            int titleLen = text.Length;
            int paddingLen = lineLen / 2 - titleLen / 2;
            
            string padding = "";
            for (int i = 0; i < paddingLen; i++)
            {
                padding += " ";
            }

            if(clearScreen) Console.Clear();
            if(line1) DisplayLine();
            Console.WriteLine(padding + text.ToUpper());
            if(line2) DisplayLine();
        }

        /* Displays a line */
        static public void DisplayLine()
        {
            string line = "";
            for (int i = 0; i < lineLen; i++)
            {
                line += "-";
            }
            Console.WriteLine(line);
        }

        /* Ask user to press any key to continue */
        static public void Wait(string message = "Press any key to continue!")
        {
            Console.WriteLine(message);
            Console.ReadKey(true); // Halt until any key is pressed
        }

        /* Display confirmation prompt, ask user to press a specific key
         * to confirm. Returns true / false depending on user input */
        static public bool Confirm(string message, char confirmKey = 'y')
        {

            if (!Enum.TryParse<ConsoleKey>(confirmKey.ToString(), 
                out ConsoleKey key))
            {
                Error("Could not parse key!");
            }

            Console.WriteLine(message);
            return (Console.ReadKey(true).Key == key);
        }

        /* Display error message, with option to 
         * ask user to press any key to continue */
        static public void Error(string message, bool displayWait = false)
        {
            Console.WriteLine("Error: {0}", message);
            if (displayWait)
            {
                Wait();
            }
        }
    }

}
