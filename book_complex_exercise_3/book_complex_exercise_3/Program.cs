/* Programmering 1 C# Arbetsbok   
 * Complex Exercise 3
 * Page 35
 *    
 * Exercise notes: 
 * Create a reaction game:
 * 
 * Randomize a duration in seconds
 * between 3 and 10.
 * 
 * Print "Get Ready!" wait duration ->
 * Print "Now!" and wait for user to
 * press any key. 
 * 
 * Display reaction time in milliseconds.
 * 
 * If the user presses any key before "Now!
 * display a "cheating message".
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
using System.Threading; // Sleep
using System.Diagnostics; // Stopwatch

namespace book_complex_exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch counter = new Stopwatch();
            Random rand = new Random();
            bool cheat;

            do
            {
                /* Reset and start timer */
                counter.Restart();

                cheat = false;

                Console.Clear();
                Console.WriteLine("Counting down from random " +
                    "value: 3-10 seconds");

                /* Random seconds converted to milliseconds */
                int countdown = rand.Next(3, 11) * 1000;

                Console.Write("Get Ready");

                /* Countdown! */
                while (counter.ElapsedMilliseconds < countdown)
                {
                    if (PressedKey())
                    {
                        Console.WriteLine("Too soon!!");
                        cheat = true;
                        break;
                    }

                    /* Print a "." each second(ish) 
                     * for added suspension */
                    if (counter.ElapsedMilliseconds % 1000 == 0)
                    {
                        Console.Write(".");
                        Thread.Sleep(1); // Prevent several dots
                    }
                }

                /* If user didn't press a key before "NOW!" */
                if (!cheat)
                {
                    counter.Restart();
                    Console.WriteLine("\nNOW!");

                    /* Wait until user pressed a key */
                    while (!PressedKey());

                    Console.WriteLine("Reaction time: {0} ms",
                        counter.ElapsedMilliseconds);
                }
                
                Console.WriteLine("Play again?");

            } while (Console.ReadLine().ToLower() == "y");

        }

        static bool PressedKey()
        {
            bool retval = false;

            /* KeyAvailable checks if a key is pressed down */
            if (Console.KeyAvailable)
            {
                /* Catch key input */
                Console.ReadKey(true);
                retval = true;
            }

            return retval;
        }

    }
}
