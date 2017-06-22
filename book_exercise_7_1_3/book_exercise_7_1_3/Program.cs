/* Programmering 1 C# Arbetsbok
 * Exercise 7.1.3
 * Page 13
 * 
 * Exercise notes:
 * Create a program:
 * input: three integers
 * output: sum and average value of integers
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

namespace book_exercise_7_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_NUMBERS = 3;
            int[] numbers = new int[MAX_NUMBERS];
            int sum = 0;

            /* Input numbers into int array */
            for (int i = 0; i < MAX_NUMBERS; i++)
            {
                Console.Write("Enter number {0}:", i+1);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
                sum += numbers[i];
            }

            /* List entered numbers */
            Console.Write("Numbers: ");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            /* Display sum and average value of numbers */
            Console.WriteLine("\nSum: {0}\nAverage: {1:N2}", 
                sum, (double)sum / MAX_NUMBERS);

            Console.Read();
        }
    }
}
