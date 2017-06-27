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
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(7,7, true);
            int x, y;

            game.NewField();

            do
            {
                game.DrawField();

                Console.Write("\nNEW SHOT\nEnter X:");
                int.TryParse(Console.ReadLine(), out x);

                Console.Write("\nNEW SHOT\nEnter Y:");
                int.TryParse(Console.ReadLine(), out y);

            } while (!game.AddHit(x, y));

            game.DrawField();
            Console.WriteLine("You hit the target in {0} attempts!!", 
                game.GetAttempts());

            Console.ReadLine();
        }
    }
}
