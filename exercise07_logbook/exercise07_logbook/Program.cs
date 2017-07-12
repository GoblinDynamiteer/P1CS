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
            logbook.AddEntry("TestInlägg_1", "Text till inlägget, jättebra!!!!!!");
            logbook.AddEntry("Testinlägg2", "Text här också! OMG!");
            logbook.AddEntry("Testinlägg3", "Text här också! OMG!");
            logbook.AddEntry("Testinlägg43", "Text här också! OMG!");
            logbook.DisplayEntry(2);

            Console.ReadLine();
        }
    }

    class Logbook
    {
        List<string[]> entries;
        int id = 0;

        string[] errorMsg = {
            "Error: Could not convert log entry id to integer!",
            "Error: Entry ID not found!"
        };

        enum entry
        {
            title,
            content,
            date,
            id
        }

        enum errorId
        {
            findEntryIndex,
            DisplayEntry
        }
        
        /* Constructor */
        public Logbook()
        {
            entries = new List<string[]>();
        }

        public bool AddEntry(string title, string text)
        {
            string[] entry = {
                title,
                text,
                DateTime.Now.ToString(),
                id++.ToString()
            };

            entries.Add(entry);
            return true;
        }

        /* Display a log entry, pass id as parameter */
        public void DisplayEntry(int id)
        {
            /* Search for list index */
            int index = findEntryIndex(id);

            if (index == -1) // Error
            {
                Console.WriteLine(errorMsg[(int)errorId.DisplayEntry]);
                return;
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine(entries[index][(int)entry.title]);
            Console.WriteLine(entries[index][(int)entry.date]);
            Console.WriteLine("-------------------------------");
            Console.WriteLine(entries[index][(int)entry.content]);
        }

        /* Find entry list index from id */
        int findEntryIndex(int id)
        {
            int retval = -1;
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i][(int)entry.id] == id.ToString())
                {
                    if(!int.TryParse(entries[i][(int)entry.id], out retval))
                    {
                        Console.WriteLine(errorMsg[(int)errorId.findEntryIndex]);
                    }

                    break;
                }
            }

            return retval;
        }
    }
}
