/* Övning 4 - Undantagshantering och felsökning 
 * Programmering 1
 * 
 * Exercise instructions:
 *  -   Debug the program, correct faulty code
 *  -   Write pseudo code for the program
 *  -   Add runtime exception handling
 *  -   Comment the code, explain your changes and
 *      why the original code was wrong
 *  
 * Extra:
 *  -   Allow the user to replay the game
 *  -   Count guesses
 *  -   High Score list, that saves number of guesses
 *      between sessions
 *
 * 
 * Notes:
 *  - I'm using my highscore class library that was made
 *    for the Programmering 1 C# Arbetsbok exercise 6 on
 *    page 37.
 *    
 *    I copied the class library code into this file, as
 *    the hand in for this exercise doesn't allow multiple
 *    files.
 *    
 *    I save the highscore data to a file called highscore.dat
 *    to have score be saved between play sessions.
 *    As I understand, the file is saved to the same directory
 *    as the executable.
 *    
 *    Link to highscore class library exercise solution:
 *    https://github.com/GoblinDynamiteer/P1CS/tree/master/book_complex_exercise_6
 * 
 * Johan Kämpe
 * 2017-07-01
 * https://github.com/GoblinDynamiteer/  
 * https://www.linkedin.com/in/johankampe/  
 *   
 */


/* Error:
 * The type or namespace name 'system' could not be found
 * 
 * Solution:
 * Changed system -> System,  uppercase S   */
using System;

using Game; // Highscore class library
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Uppgift_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random slumpat = new Random();

            /* New highscore with 10 max items and sorted by
             * lowest first */
            HighScore highscore = new HighScore(10, false);

            /* Load highscore file, if available */
            highscore.Load();

            /* Error:
            * Random.Next() without passed parameters
            * randomizes any number up to max integer size
            * 
            * Solution:
            * Pass parameters to randomize between 1 and 20  */
            int speltal = slumpat.Next(1, 21);

            int guessCount = 0; // Count guesses
            bool spela = true;
            
            /* Error:
            * Program doesn't enter while-loop
            * 
            * Solution:
            * Changed !spela -> spela, ! before a bool 
            * variable means NOT (inverts) */
            while (spela)
            {
                int tal;
                guessCount++;

                /* 
                * Runtime error: 
                * "Input string was not in a correct format." 
                * if user enters non-integer
                * 
                * Solution: 
                * Use int.TryParse() instead of Convert.ToInt32(), 
                * TryParse returns a truth value
                * depending on conversion success - 
                * repeat user input until
                * conversion succeeds. 
                * 
                * "int tal" is passed as a reference to 
                * the method with the "out" keyword. Passing 
                * variables as a reference, instead of a copy, 
                * allows the method to change their 
                * values.
                */
                do
                {
                    Console.Write(
                        "\n\tGissa på ett tal mellan 1 och 20: ");
                } while (!int.TryParse( //while conversion is NOT successful
                    Console.ReadLine(), out tal));


                if (tal < speltal)
                {
                    Console.WriteLine("\tDet inmatade talet " 
                        + tal + " är för litet, försök igen.");
                }

                if (tal > speltal)
                {
                    /* Error:
                     * Syntax error, ',' expected 
                     * 
                     * Solution:
                     * Added + for string concatenation
                     */
                    Console.WriteLine("\tDet inmatade talet " 
                        + tal  + " är för stort, försök igen.");
                }

                /* Error:
                 * Cannot implicitly convert type 'int' to 'bool'
                 * 
                 * Solution:
                 * Changed = -> == (assignment operator to relational operator)
                 */
                if (tal == speltal)
                {
                    Console.WriteLine(
                        "\n\tGrattis, du gissade rätt! ({0} antal försök)", 
                            guessCount);

                    Console.Write("\tAnge ditt namn för highscore: ");
                    highscore.Add(Console.ReadLine(), guessCount);

                    highscore.Print();

                    Console.WriteLine("\n\tTryck på \"J\" för att spela igen!");
                    if (char.ToLower(Console.ReadKey(true).KeyChar) != 'j')
                    {
                        /* Error:
                        * Program quit after first guess
                        * 
                        * Solution:
                        * Added curly braces to if-statement, as code block
                        * was intended to include "spela = false;
                        */
                        spela = false;
                    }

                    /* Randomize new number and reset count */
                    speltal = slumpat.Next(1, 21);
                    guessCount = 0;
                }
            }

            /* Save highscores to file */
            highscore.Save();

        }
    }
}

namespace Game
{
    /* [Serializable] To be able to use 
     * BinaryFormatter.Serialize, saves/loads HSItem list
     * to binary data file */
    [Serializable]
    /* High Score item class */
    class HSItem : IComparable // IComparable - For sorting
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        /* Constructor */
        public HSItem(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        /* For list sorting */
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            HSItem otherItem = obj as HSItem;
            if (otherItem != null)
                return this.points.CompareTo(otherItem.points);
            else
                throw new ArgumentException("Object is not Points!");
        }

    }

    class HighScore
    {
        int maxItems;
        bool descendingSort; // Ascending or descending sort
        string filename = "highscore.dat";
        List<HSItem> highScoreList;

        /* Constructor */
        public HighScore(int maxItems = 10, bool descendingSort = true)
        {
            this.maxItems = maxItems;
            this.descendingSort = descendingSort;
            this.highScoreList = new List<HSItem>();
        }

        /* Add name and score to list */
        public void Add(string name, int points = 0)
        {
            if (name == "") // If no name is entered
            {
                name = "NO NAME";
            }

            highScoreList.Add(new HSItem(name, points));
            Sort();
        }

        /* Print list, modified for this guessing game */
        public void Print()
        {
            Console.WriteLine(
                "\n\t******** HIGHSCORE ********");
            int place = 1;

            foreach (HSItem score in highScoreList)
            {
                Console.WriteLine(
                    "\t{0}. {1} {2} Gissningar",
                        place++, score.Name, score.Points);
            }
        }

        /* Sort list and remove item if needed */
        private void Sort()
        {
            highScoreList.Sort();

            /* Ascending / descending */
            if (descendingSort)
            {
                /* Reverse sorted list, if largest value
                 * shall be on top */
                highScoreList.Reverse();
            }

            /* Remove if over max items */
            while (highScoreList.Count > maxItems)
            {
                highScoreList.RemoveAt(highScoreList.Count - 1);
            }
        }

        /* Save high scores to file */
        public void Save()
        {
            FileStream datafile = new FileStream(
                this.filename, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(datafile, highScoreList);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to save: " + e.Message);
            }
            finally
            {
                datafile.Close();
            }
        }

        /* Load high scores from file */
        public bool Load()
        {
            FileStream datafile = null;
            bool success = true;

            try
            {
                datafile = new FileStream(
                    this.filename, FileMode.Open);
            }

            /* If datafile does not exist. */
            catch (FileNotFoundException e)
            {
                /* Commented to prevent display of error message
                 * when no file is found */
                // Console.WriteLine("No file: " + e.Message);
                success = false;
            }

            if (success)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    /* Note: Overwrites list if it contains contents */
                    highScoreList = (List<HSItem>)formatter.Deserialize(datafile);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to load: " + e.Message);
                    success = false;
                }

                datafile.Close();
            }
            
            return success;

        }
    }
}

