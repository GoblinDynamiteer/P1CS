/* Programmering 1 C# Arbetsbok 
 * Exercise 12.5
 * Page 26
 *  
 * Exercise notes: 
 * Create a guessing game
 * Randomize a coordinate in a 4x4
 * playing field, use a 2d-vector.
 * 
 * The user shall enter x- and y-coordinates
 * to "shoot" at the target. Each shot shall
 * create a bullet hole ( * )
 * 
 * When the user hits the correct coordinate,
 * print out number of shots and quit the program
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

namespace book_exercise_12_5
{
    class Game
    {
        private int xMax;
        private int yMax;
        bool showTarget;
        private int attempts = 0;
        private const char bulletHole  = '*';
        private const char emptySpace = ' ';

        /* Target to hit */
        static int[] target = { 0, 0 };

        static char[,] field;
        private static Random rand = new Random();

        /* Constructor to create custom size field */
        public Game(int x = 4, int y = 4, bool cheat = false)
        {
            this.yMax = y;
            this.xMax = x;
            this.showTarget = cheat;

            field = new char[xMax, yMax];
        }

        private static void RandomizeTarget(int x, int y)
        {
            target[0] = rand.Next(0, x);
            target[1] = rand.Next(0, y);
        }

        public void NewField()
        {
            /* Create new random target */
            RandomizeTarget(xMax, yMax);

            /* Fill target with empty spaces */
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    field[x, y] = emptySpace;
                }

            }

        }

        public bool AddHit(int x, int y)
        {
            bool hit = false;
            /* Add bullet hole to 2D-array */
            field[x-1, y-1] = bulletHole;

            if (x - 1 == target[0] && y - 1 == target[1])
            {
                hit = true;
                field[x - 1, y - 1] = 'X';
            }

            this.attempts++;

            return hit;
        }

        public int GetAttempts()
        {
            return this.attempts;
        }


        /* 
         * Draws with hits
         * 
         *  |1|2|3|4|
         * 1|*         
         * 2|
         * 3|  *
         * 4|
         * 
         */
        public void DrawField()
        {
            Console.Clear();
            Console.WriteLine("Shooting game!");

            if (showTarget)
            {
                /* Print target coordinates */
                Console.WriteLine("Target at: {0} {1}",
                    target[0], target[1]);

                /* Set 'R' on target coordinate */
                field[target[0], target[1]] = 'R';
            }
            

            Console.Write(" |");

            for (int i = 0; i < xMax; i++)
            {
                Console.Write("{0}|", i+1);
            }

            Console.WriteLine();

            for (int y = 0; y < yMax; y++)
            {

                for (int x = 0; x < xMax; x++)
                {
                    if (x == 0)
                    {
                        Console.Write("{0}|", y+1);
                    }
                    Console.Write("{0} ", field[x, y]);
                }

                Console.WriteLine();
            }

        }

    }
}
