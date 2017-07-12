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
 * 2017-07-12
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
            logbook.AddEntry("Jag är en Apa", "Titel 1");
            logbook.AddEntry("Jag är en Banan", "Titel 2");
            logbook.AddEntry("Jag är en Gris", "Titel 3");
            logbook.AddEntry("Jag är ett Äpple!!", "Titel 4");
            int hittade = logbook.Search("Jag är e");
            Console.WriteLine("Hittade {0} poster: ", hittade);
            logbook.DisplaySearchHits();
            Console.ReadLine();
        }
    }

    /* Class for logbooks */
    class Logbook
    {
        List<string[]> entries;
        int[] searchHits;
        int id = 0;

        enum Searchdata
        {
            Empty = -1,
            MaxHits = 50
        }

        /* Entry string indexes */
        enum Entry
        {
            Title,
            Content,
            Date,
            ID
        }

        /* Error messages */
        string[] errorMsg = {
            "Error: Could not convert log entry id to integer!",
            "Error: Entry ID not found!",
            "Error: Entry text cannot be blank!"
        };

        /* Indexes for error messages */
        enum ErrorId
        {
            IDToIndexConvertFail,
            EntryIDNotFound,
            BlankEntry
        }
        
        /* Constructor */
        public Logbook()
        {
            /* List of string vectors, for holding logbook entries */
            entries = new List<string[]>();

            searchHits = new int[(int)Searchdata.MaxHits];
            ClearSearchHits();
        }

        /* Clear search hit list */
        void ClearSearchHits()
        {
            for (int i = 0; i < (int)Searchdata.MaxHits; i++)
            {
                searchHits[i] = (int)Searchdata.Empty;
            }
        }

        /* Search entries, returns hits */
        public int Search(string searchString)
        {
            ClearSearchHits();
            int hits = 0;

            /* Linear search */
            foreach (string[] entry in entries)
            {
                /* Max hits found, break */
                if (hits == (int)Searchdata.MaxHits)
                {
                    break;
                }

                if (entry[(int)Entry.Content].Contains(searchString) ||
                    entry[(int)Entry.Title].Contains(searchString))
                {
                    /* Add entry index to search hits array */
                    searchHits[hits++] = int.Parse(entry[(int)Entry.ID]);
                }
            }

            return hits;
        }

        /* Display entries stored in searchHits array */
        public void DisplaySearchHits()
        {
            for (int i = 0; i < (int)Searchdata.MaxHits; i++)
            {
                if (searchHits[i] == (int)Searchdata.Empty)
                {
                    break;
                }

                Console.WriteLine(
                    entries[searchHits[i]][(int)Entry.Title]);
            }
        }

        /* Add entry to logbook */
        public int AddEntry(string content, string title = "Untitled")
        {
            if (content == "") // Error
            {
                Console.WriteLine(errorMsg[(int)ErrorId.BlankEntry]);
            }

            /* Add logbook entry contents to string array */
            string[] stringEntry = new string[4];
            stringEntry[(int)Entry.Title] = title;
            stringEntry[(int)Entry.ID] = id++.ToString();
            stringEntry[(int)Entry.Date] = DateTime.Now.ToString();
            stringEntry[(int)Entry.Content] = content;

            /* Add string array to list */
            entries.Add(stringEntry);

            return id - 1;
        }

        /* Display a log entry, pass id as parameter */
        public void DisplayEntry(int id)
        {
            /* Search for list index */
            int index = findEntryIndex(id);

            if (index == -1) // Error
            {
                Console.WriteLine(errorMsg[(int)ErrorId.EntryIDNotFound]);
                return;
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine(entries[index][(int)Entry.Title]);
            Console.WriteLine(entries[index][(int)Entry.Date]);
            Console.WriteLine("-------------------------------");
            Console.WriteLine(entries[index][(int)Entry.Content]);
        }

        /* Edit entry Title */
        public void EditTitle(int id)
        {
            /* Search for list index */
            int index = findEntryIndex(id);

            if (index == -1) // Error
            {
                Console.WriteLine(errorMsg[(int)ErrorId.EntryIDNotFound]);
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
            int index = findEntryIndex(id);

            if (index == -1) // Error
            {
                Console.WriteLine(errorMsg[(int)ErrorId.EntryIDNotFound]);
                return;
            }

            Console.WriteLine("Enter new content: ");
            string newContent = Console.ReadLine();

            UpdateEntry(index, "", newContent);
        }

        /* FIXA DATUM !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */
        public void EditDate(int id)
        {
            /* Search for list index */
            int index = findEntryIndex(id);

            if (index == -1) // Error
            {
                Console.WriteLine(errorMsg[(int)ErrorId.EntryIDNotFound]);
                return;
            }

            Console.WriteLine("Enter new date: ");
            string newDate = Console.ReadLine();

            UpdateEntry(index, "", "", newDate);
        }

        /* Edit entry -- Only non blank parameters are updated */
        void UpdateEntry(int index, string title = "", string content = "", string date = "")
        {
            /* Update entry content that needs updating */
            entries[index][(int)Entry.Title] = title == "" ? 
                entries[index][(int)Entry.Title] : title;
            entries[index][(int)Entry.Content] = content == "" ? 
                entries[index][(int)Entry.Content] : content;
            entries[index][(int)Entry.Date] = date == "" ? 
                entries[index][(int)Entry.Date] : date;
        }

        /* Find entry list index from id */
        int findEntryIndex(int id)
        {
            int retval = -1; // Return -1 if id not found
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i][(int)Entry.ID] == id.ToString())
                {
                    /* Parsing error -- display error message */
                    if(!int.TryParse(entries[i][(int)Entry.ID], out retval))
                    {
                        Console.WriteLine(
                            errorMsg[(int)ErrorId.IDToIndexConvertFail]);
                    }

                    break;
                }
            }

            return retval;
        }
    }
}
