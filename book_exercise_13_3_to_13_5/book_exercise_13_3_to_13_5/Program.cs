/* Programmering 1 C# Arbetsbok 
 * Exercise 13.3 to 13.5 
 * Page 28
 *  
 * Exercise notes: 
 * Create a class of your favorite animal
 * 
 * (Part 1)
 * Create class members, variables and methods.
 * E.g. for a dog: 
 *      Variables: age, name, breed
 *      Methods: Bark(), Fetch()
 *   
 * (Part 2)
 * Make the variables private, set them with
 * get/set.
 * 
 * (Part 3)
 * Make a constructor for your animal class.
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

namespace book_exercise_13_3_to_13_5
{
    class Program
    {
        static void Main(string[] args)
        {
            PetDragon myDragon = new PetDragon("Fanny", 1304, "Red");

            myDragon.DisplayInfo();

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                myDragon.CollectTreasure();
            }

            Console.WriteLine();
            myDragon.DisplayInfo();

            Console.ReadLine();
        }
    }
}
