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
 * 2017-07-17
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace exercise07_logbook
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create a new logbook object, pass argument 
             * 'true' to create sample entries */
            Logbook logbook = new Logbook();

            /* User menu choice enum variable, to navigate main menu */
            Menu.MenuItem userChoice = Menu.MenuItem.Default;

            /* Run main menu until user choses to quit the program */
            while (userChoice != Menu.MenuItem.Quit)
            {
                /* Get user menu choice from method */
                userChoice = Menu.DisplayMenu();

                switch (userChoice)
                {
                    case Menu.MenuItem.Add: // Add logbook entry
                        Menu.DisplayTitle("Add log entry");
                        logbook.AddEntry();
                        break;

                    case Menu.MenuItem.ListAll: // List all entries
                        logbook.DisplayAllTitles();
                        break;

                    case Menu.MenuItem.Search: // Searc entries
                        Menu.DisplayTitle("Search entries");
                        logbook.Search();
                        break;

                    case Menu.MenuItem.Sort: // Sort entries
                        Menu.DisplayTitle("Sort entries");
                        logbook.Sort();
                        break;

                    default:
                        break;
                }
            }

            /* Save logbook data to file before quitting */
            logbook.Save();

            Menu.DisplayTitle();
            Menu.Wait("Thanks for using the logbook!\n" +
                "Press any key to quit...");
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
        string dataFileName;
        int id; // For setting entry id

        /* Enums used for search */
        enum SearchData
        {
            Empty = -1,
            MaxHits = 50
        }

        /* Text for sort menu */
        string[] sortMenu = {
            "Entry ID, Ascending",
            "Entry ID, Descending",
            "Entry Title, Ascending",
            "Entry Title, Descending",
            "Entry Date, Ascending",
            "Entry Date Descending"
        };

        /* Text for display entry menu */
        string[] displayEntryMenu = {
            "Export to text file",
            "Change title",
            "Change content",
            "Delete entry"
        };

        /* For chosing sorting mode */
        public enum SortBy
        {
            IDAscending,
            IDDescending,
            TitleAscending,
            TitleDescending,
            DateAscending,
            DateDescending
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
            "Could not convert log " +
                "entry id to integer!",         // 0
            "Entry ID not found!",              // 1
            "Entry text cannot be blank!",      // 2
            "Faulty ID input!",                 // 3
            "Could not export entry to file!",  // 4
            "Failed to save data!",             // 5
            "Failed to load data!",             // 6
            "Incorrect sort value!",            // 7
            "No entries found!"                 // 8
        };

        /* Indexes for error messages */
        enum ErrorId
        {
            IndexConvert,   // 0
            IDNotFound,     // 1
            BlankEntry,     // 2
            IntInput,       // 3
            Export,         // 4
            DataSave,       // 5
            DataLoad,       // 6
            Sort,           // 7
            EmptyLog        // 8
        }
        
        /* Constructor */
        public Logbook(bool addSamples = false)
        {
            /* List of string vectors, for holding logbook entries */
            entries = new List<string[]>();

            searchHits = new int[(int)SearchData.MaxHits];
            lastSearchString = "";
            dataFileName = "data.dat";
            ClearSearchHits();
            id = 0;

            /* Load saved logbook, if exists */
            if (Load())
            {
                /* If load is successful, determine id for next new entry */
                foreach (string[] item in entries)
                {
                    int check = int.Parse(item[(int)EntryData.ID]);
                    if (check > id)
                    {
                        id = check;
                    }
                }

                id++;
            }

            /* Add prewritten samples */
            if (addSamples)
            {
                AddSamples();
            }
        }

        /* Get number of logbook entries */
        public int Count()
        {
            return entries.Count;
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

                /* If either title, date or content contains search-string text */
                if (entry[(int)EntryData.Content].Contains(searchString) ||
                    entry[(int)EntryData.Title].Contains(searchString) ||
                    entry[(int)EntryData.Date].Contains(searchString))
                {
                    /* Add entry ID to search hits array */
                    searchHits[hits++] = int.Parse(entry[(int)EntryData.ID]);
                }
            }
            DisplaySearchHits(hits);
        }

        /* Search entries, manual input, returns hits */
        public void Search()
        {
            Console.Write("Enter search string (Case sensitive): ");
            Search(Console.ReadLine());
        }

        /* Display entries stored in searchHits array */
        public void DisplaySearchHits(int hits)
        {
            if (hits == 0) // No search hits found
            {
                Menu.DisplayTitle(string.Format(
                    "Search: Found no hits for {0}", lastSearchString));
                Menu.Wait("Found no entries!\nPress any key to continue!");
                return; // End method
            }

            Menu.DisplayTitle(string.Format("Search: Found {0} hits for {1}", 
                hits, lastSearchString));
            Console.WriteLine("ID\tDATE\t\t\tTITLE");

            for (int i = 0; i < (int)SearchData.MaxHits; i++)
            {
                /* Break if element is considered empty,
                 * all searchhits has been listed */
                if (searchHits[i] == (int)SearchData.Empty)
                {
                    break;
                }

                DisplayTitle(searchHits[i]);
            }

            Console.WriteLine(); // For new line
            DisplayEntry();      // Will ask user to enter entry ID
        }

        /* Display all log entries */
        public void DisplayAllTitles()
        {
            Menu.DisplayTitle(string.Format("All entries ({0})", 
                Count()));

            if (entries.Count == 0)
            {
                Menu.Error(errorMsg[(int)ErrorId.EmptyLog], true);
                return;
            }

            Console.WriteLine("ID\tDATE\t\t\tTITLE");

            entries.ForEach(entry => DisplayTitle(int.Parse(entry[(int)EntryData.ID])));

            Console.WriteLine(); // For new line
            DisplayEntry();      // Will ask user to enter entry ID
        }

        /* Display entry title with id and creation date */
        void DisplayTitle(int id)
        {
            int index = FindEntryIndex(id);
            string entryId =    entries[index][(int)EntryData.ID];
            string entryTitle = entries[index][(int)EntryData.Title];
            string entryDate =  entries[index][(int)EntryData.Date];
            Console.WriteLine("[{0}]\t[{1}]\t[{2}] ", entryId, entryDate, entryTitle);
        }

        /* Add entry to logbook */
        public int AddEntry(string title, string content)
        {
            /* Add logbook entry contents to string array */
            string[] stringEntry = new string[4];
            stringEntry[(int)EntryData.Title]   = title;
            stringEntry[(int)EntryData.ID]      = id++.ToString(); // Increase ID for next entry
            stringEntry[(int)EntryData.Date]    = DateTime.Now.ToString();
            stringEntry[(int)EntryData.Content] = content;

            /* Add string array to list */
            entries.Add(stringEntry);

            Console.WriteLine("Added new entry: ");
            DisplayTitle(id-1);

            return id - 1; // Return ID of created entry
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

            /* Display error while user enters blank text */
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
            int index = FindEntryIndex(id);
            entries.RemoveAt(index);
            Menu.Wait(String.Format("Entry with id {0} deleted!\n" +
                "Press any key to continue", id));
        }

        /* Display entry, manual ID input  */
        public void DisplayEntry()
        {
            Console.WriteLine("Enter ID to display entry." +
                "\nInput blank to return to the main menu.");
            Console.Write("Enter ID: ");
            string stringID = Console.ReadLine();

            if (stringID == "") // Return to main menu
            {
                return; // End method
            }

            /* Parsing error of input, display error */
            if (!int.TryParse(stringID, out int id)) 
            {
                Menu.Error(errorMsg[(int)ErrorId.IntInput], true);
                return; // End method
            }

            DisplayEntry(id); // Display entry with parsed ID
        }

        /* Display a log entry, pass ID as parameter */
        public void DisplayEntry(int id)
        {
            /* Search for list index */
            int index = FindEntryIndex(id);

            if (index == -1) // Error
            {
                Menu.Error(errorMsg[(int)ErrorId.IDNotFound], true);
                return; // End method
            }

            /* Text output */
            Menu.DisplayTitle(entries[index][(int)EntryData.Title], true, false);
            Menu.DisplayTitle(entries[index][(int)EntryData.Date], false, true, false);
            Console.WriteLine(entries[index][(int)EntryData.Content]);
            Menu.DisplayLine();

            /* User options for current entry */
            Console.WriteLine("Options:");
            for (int i = 0; i < displayEntryMenu.Length; i++)
            {
                Console.WriteLine(" [{0}] {1}", i + 1, displayEntryMenu[i]);
            }

            Menu.DisplayLine();
            Console.WriteLine("Enter Option number\n" +
                "or press any other key to return to main menu.");

            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.D1: // Export
                case ConsoleKey.NumPad1:
                    Menu.DisplayLine();
                    Console.Write("Enter filename: ");
                    ExportEntry(id, Console.ReadLine());
                    break;

                case ConsoleKey.D2: // Edit title
                case ConsoleKey.NumPad2:
                    EditTitle(id);
                    break;

                case ConsoleKey.D3: // Edit content
                case ConsoleKey.NumPad3:
                    EditContent(id);
                    break;

                case ConsoleKey.D4: // Delete entry
                case ConsoleKey.NumPad4:
                    Menu.DisplayLine();
                    if (Menu.Confirm("Are you sure? Press (Y) " +
                        "to delete entry: ", ConsoleKey.Y))
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
                Menu.Error(errorMsg[(int)ErrorId.IDNotFound]);
                return; // End method
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
                Menu.Error(errorMsg[(int)ErrorId.IDNotFound]);
                return; // End method
            }

            Console.WriteLine("Enter new content: ");
            string newContent = Console.ReadLine();

            UpdateEntry(index, "", newContent);
        }

        /* Export log entry to text file */
        public void ExportEntry(int id, string filename)
        {
            /* Search for list index */
            int index = FindEntryIndex(id);

            if (index == -1) // Error
            {
                Menu.Error(errorMsg[(int)ErrorId.IDNotFound], true);
                return; // Quit method if error
            }

            try // Write entry to text file
            {
                StreamWriter file = new StreamWriter(filename + ".txt");
                file.WriteLine(entries[index][(int)EntryData.Title]);
                file.WriteLine(entries[index][(int)EntryData.Date]);
                file.WriteLine(entries[index][(int)EntryData.Content]);
                file.Close();
            }
            catch (Exception)
            {
                Menu.Error(errorMsg[(int)ErrorId.Export], true);
                return; // End method
            }

            Console.WriteLine("File exported to {0}.txt!", filename);
            Menu.Wait();
        }

        /* Save logbook from datafile */
        public bool Save()
        {
            FileStream datafile = null;
            bool success = true;

            try
            {
                datafile = new FileStream(
                    dataFileName, FileMode.Create);
            }

            /* Eg. If write protected */
            catch (Exception)
            {
                success = false;
            }

            /* If datafile can be written, write logbook data to file */
            if (success)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(datafile, entries);
                }

                catch (Exception)
                {
                    Menu.Error(errorMsg[(int)ErrorId.DataSave]);
                }

                finally
                {
                    datafile.Close(); // Close data file
                }
            }

            return success;
        }

        /* Loads logbook from datafile */
        public bool Load()
        {
            FileStream datafile = null;
            bool success = true;

            try
            {
                datafile = new FileStream(
                    dataFileName, FileMode.Open);
            }

            /* If datafile does not exist, or write protected */
            catch (Exception)
            {
                success = false;
            }

            if (success)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    /* Note: Overwrites list if it contains contents */
                    entries = (List<string[]>)formatter.Deserialize(datafile);
                }
                catch (Exception)
                {
                    Menu.Error(errorMsg[(int)ErrorId.DataLoad]);
                    success = false;
                }

                datafile.Close(); // Close data file
            }

            return success;
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

        /* Sort entries with insertion sort, user choses sorting method */
        public void Sort()
        {
            Menu.DisplayTitle("Sort Entries");
            Console.WriteLine("Sort by:");
            for (int i = 0; i < sortMenu.Length; i++)
            {
                Console.WriteLine(" [{0}] {1}", i+1, sortMenu[i]);
            }
            Menu.DisplayLine();
            Console.WriteLine("Enter menu item to sort entries,\n" +
                "or press any other key to return to main menu.");

            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Sort(SortBy.IDAscending);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Sort(SortBy.IDDescending);
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Sort(SortBy.TitleAscending);
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Sort(SortBy.TitleDescending);
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Sort(SortBy.DateAscending);
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Sort(SortBy.DateDescending);
                    break;

                default:
                    return; // End method
            }

            /* Ask user to display all entries after sort */
            if (Menu.Confirm("Entries sorted!\n" +
                "Press (Y) to display all entries"))
            {
                DisplayAllTitles();
            }

        }

        /* Sort entries with insertion sort */
        public void Sort(SortBy sort = SortBy.DateAscending)
        {
            int sortIndex;  // Title/Date/ID index for char array in logbook list
            bool ascending; // Sort direction

            switch (sort) // Switch on SortBy enum
            {
                case SortBy.IDAscending:
                    sortIndex = (int)EntryData.ID;
                    ascending = true;
                    break;

                case SortBy.IDDescending:
                    sortIndex = (int)EntryData.ID;
                    ascending = false;
                    break;

                case SortBy.TitleAscending:
                    sortIndex = (int)EntryData.Title;
                    ascending = true;
                    break;

                case SortBy.TitleDescending:
                    sortIndex = (int)EntryData.Title;
                    ascending = false;
                    break;

                case SortBy.DateAscending:
                    sortIndex = (int)EntryData.Date;
                    ascending = true;
                    break;

                case SortBy.DateDescending:
                    sortIndex = (int)EntryData.Date;
                    ascending = false;
                    break;

                default: // Errror
                    Menu.Error(errorMsg[(int)ErrorId.Sort], true);
                    return; // End Method, skip sorting
            }
            
            /* Insertion Sort */
            int ix, jx;

            for (ix = 0; ix < entries.Count; ix++)
            {
                jx = ix; // Indexes

                if (ascending) // Ascending sort
                {
                    while (jx != 0 &&
                        string.Compare(entries[jx - 1][sortIndex], entries[jx][sortIndex]) > 0)
                    {
                        SortSwap(jx, jx - 1); // Swap list elements
                        jx--;
                    }
                }

                else // Descending sort
                {
                    while (jx != 0 &&
                        string.Compare(entries[jx - 1][sortIndex], entries[jx][sortIndex]) < 0)
                    {
                        SortSwap(jx, jx - 1); // Swap list elements
                        jx--;
                    }
                }

            }
        }

        /* Helper method for sort, swaps two elements in entry list */
        void SortSwap(int i1, int i2)
        {
            string[] temp = entries[i1];
            entries[i1] = entries[i2];
            entries[i2] = temp;
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
                    break;
                }
            }

            return retval;
        }

        /* Write sample entries */
        public void AddSamples()
        {
            AddEntry("A day at the zoo!", "I went to the " +
                "zoo with my family today, we saw monkies and giraffes!!");
            AddEntry("Today's lunch", "I had pancakes with whipped " +
                "cream and strawberry jam today!");
            AddEntry("New TV-Show", "Wow this new show on TV is really good! " +
                "Can't wait until the next episode is released!");
            AddEntry("Weather Report", "It's raining and is super cold today! >;(");
            AddEntry("C# Coding", "I'm learning C#, fun fun!");
            AddEntry("C# Classes and Objects", "Today im learning about classes and " +
                "objects in C#. Its an object-oriented coded language!");
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
            Sort,
            Quit,
            Default
        }

        static int lineLen = 60;

        /* Display the main menu for the logbook */
        static public MenuItem DisplayMenu()
        {
            string[] menuItems =
            {
                "Add logbook entry",
                "List all logbook entries",
                "Search",
                "Sort",
                "Quit"
            };

            DisplayTitle();

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" [{0}] {1}", i + 1, menuItems[i]);
            }

            Menu.DisplayLine();
            Console.Write("Press key to select menu item: ");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    return MenuItem.Add;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    return MenuItem.ListAll;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    return MenuItem.Search;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    return MenuItem.Sort;

                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    return MenuItem.Quit;

                default:
                    return MenuItem.Default;
            }

        }

        /* Display any title text, centered */
        static public void DisplayTitle(string text = "The Logbook", 
            bool line1 = true, bool line2 = true, bool clearScreen = true)
        {
            int titleLen = text.Length;

            /* Determing left padding of title text, for center alignment.
             * IF text is longer than line-lenght, set padding to zero */
            int paddingLen = titleLen < lineLen ? lineLen / 2 - titleLen / 2 : 0;
            
            string padding = "";

            for (int i = 0; i < paddingLen; i++)
            {
                padding += " "; // Increase padding
            }

            /* Settings from parameters */
            if(clearScreen) Console.Clear();
            if(line1) DisplayLine();
            /* Padding + text = centered text, uppercased */
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
        static public bool Confirm(string message, ConsoleKey key = ConsoleKey.Y)
        {
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
