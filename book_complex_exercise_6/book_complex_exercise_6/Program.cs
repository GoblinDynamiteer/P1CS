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
using Game; // High Score

namespace book_complex_exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            HighScore hs = new HighScore(4, true);

            hs.Load();
            hs.Print();

            hs.Add("Johan", 928);

            hs.Save();

            while (true) ;

            hs.Add("JamesTKirk", 132);
            hs.Add("AgentMulder", 120);
            hs.Add("CaptainPicard", 40);
            hs.Add("BobbaFett", 180);
            hs.Add("NewName");

            /* Print list */
            hs.Print();

            hs.Add("RickDeckard", 403);
            hs.Add("DonaldDuck", 45);

            hs.Print();

            hs.Add("RickDeckard", 394);
            hs.Add("DonaldDuck", 47);

            hs.Print();

            hs.Save(); 

            Console.ReadLine();

        }
    }
}
