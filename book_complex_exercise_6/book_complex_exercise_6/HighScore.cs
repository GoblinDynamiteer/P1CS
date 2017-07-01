/* Programmering 1 C# Arbetsbok   
 * Complex Exercise 6
 * Page 37
 *    
 * Exercise notes: 
 * Create a class that handles High Score for a game
 * 
 * Class HSItem:
 *  Properties: string name, int score
 *  Constructor with name and points
 *  
 * Class HighScore
 *  Constructor with max items in high score list
 *  Public methods:
 *   Add() - Add new High Score in list, sort and 
 *           remove last if more than max items
 *   Print() - Test method, prints High Scores to
 *             Console window.
 *  Private methods:
 *   Sort() - Sort the high score list
 *  
 * Build a program to test your high score list!
 * 
 * Extras:
 *  Sort by highest / lowest, in some games lower
 *  is better (racing games etc). Make the constructor
 *  take option for sorting.
 *  
 *  File saving / loading to keep high score between
 *  sessions!
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

namespace Game
{
    /* High Score item class */
    class HSItem : IComparable
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

        /* Constructor */
        public HSItem(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }

    class HighScore
    {
        int maxItems;
        bool descendingSort; // Ascending or descending sort
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
            highScoreList.Add(new HSItem(name, points));
            Sort();
        }

        /* Print list, for testing */
        public void Print()
        {
            Console.WriteLine(
                "******** HIGHSCORE ********");
            int place = 1;

            foreach (HSItem score in highScoreList)
            {
                Console.WriteLine(
                    "{0}. {1} {2}p", place++, score.Name, score.Points);
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
    }
}
