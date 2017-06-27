/* Programmering 1 C# Arbetsbok 
 * Exercise 12.1 & 12.2 
 * Page 25
 *  
 * Exercise notes: 
 * Create a string vector with 5 elements.
 * The user shall input 5 names to the vector.
 * Print out the entered names.
 * Use for-loops.
 * 
 * The user shall be able to change a name
 * by entering vector index.
 * 
 * Exit the program if the user enters q / Q
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

namespace book_exercise_12_1_to_12_2
{
    class Program
    {
        static void PrintNames(string[] names)
        {
            Console.WriteLine("Names in list:");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i, names[i]);
            }
        }

        static void Main(string[] args)
        {
            string[] names = new string[5];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Enter name for index {0}: ", i);
                names[i] = Console.ReadLine();
            }

            PrintNames(names);

            string userInput = "";
            int index = 0;

            do
            {
                Console.Write("Enter index to change: ");
                userInput = Console.ReadLine();

                if ((int.TryParse(userInput, out index)) && 
                    index < names.Length && index >= 0)
                {
                    Console.Write("Enter new name for index " +
                        "(q to quit) {0}: ", index);
                    names[index] = Console.ReadLine();

                    PrintNames(names);
                }

            } while (userInput.ToLower() != "q");

        }
    }
}
