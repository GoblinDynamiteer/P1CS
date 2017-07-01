
/* Error:
 * The type or namespace name 'system' could not be found
 * 
 * Solution:
 * Changed system -> System,  uppercase S   */
using System;

namespace Uppgift_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random slumpat = new Random();

            /* Error:
            * Random.Next() without passed parameters
            * randomizes any number up to max integer size
            * 
            * Solution:
            * Pass parameters to randomize between 1 and 20  */
            int speltal = slumpat.Next(1, 21);

            bool spela = true;

            /* Error:
            * Program doesn't enter while-loop
            * 
            * Solution:
            * Changed !spela -> spela, ! before a bool 
            * variable means NOT (inverses it) */
            while (spela)
            {
                /* 
                * Runtime error: 
                * "Input string was not in a correct format." 
                * if user enters non-integer
                * 
                * Solution: 
                * Use int.TryParse() instead of Convert.ToInt32(), 
                * TryParse returns a truth value
                * depending on if conversion to integer was 
                * successful, repeat user input until
                * conversion succeeds. 
                * 
                * "int tal" is passed as a reference to 
                * the method with the "out" keyword. Passing 
                * variables as a reference, instead of a copy, 
                * allows the method to change their 
                * values.
                */

                int tal;

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
                    Console.WriteLine("\tGrattis, du gissade rätt!");

                    /* Error:
                    * Program quit after first guess
                    * 
                    * Solution:
                    * Added curly braces to if-statement, as code block
                    * was include "spela = false;
                    */
                    spela = false;
                }
            }

            /* Added ReadLine to prevent console window from 
             * closing after winning the game */
            Console.ReadLine();
        }
    }
}
