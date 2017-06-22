/* Programmering 1 C# Arbetsbok 
 * Exercise 7.5.5 
 * Page 20
 *  
 * Exercise notes: 
 * Create a program: Yatzy  
 * OUTPUT: Six dice rolls
 * 
 * Note: Investigate how to randomize in C# 
 * 
 * Note: I made a version that tosses six dice
 * until YATZEE (all dice same value)
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

namespace book_exercise_7_5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create array of five dice */
            Dice[] dice = new Dice[5];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Dice();
            }

            bool YATZEEEE = false;
            int counter = 0; // Toss counter

            /* Throw all dice until YATZEE */
            do
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    dice[i].Roll();
                }

                /* Set value of first dice, all other dice
                 * need to have same value to get YATZEE! */
                int checkValue = dice[0].GetValue();

                for (int i = 1; i < dice.Length; i++)
                {
                    YATZEEEE = true;
                    if (checkValue != dice[i].GetValue())
                    {
                        YATZEEEE = false;
                        break; // Break loop if not YATZEE
                    }
                }

                counter++; // Count throws

            } while (!YATZEEEE);

            Console.WriteLine("YATZEE! on {0} attempts!", counter);

            for (int i = 0; i < dice.Length; i++)
            {
                Console.WriteLine("Dice {0}: {1}", i+1, dice[i].GetValue());
            }

            Console.ReadLine();
        }
    }

    class Dice
    {
        int value;
        static Random rand = new Random();

        public int GetValue()
        {
            return value;
        }

        public void PrintValue()
        {
            Console.WriteLine("Value: {0}", 
                value);
        }

        /* Roll dice: Set random value 1-6 */
        public void Roll()
        {
            value = rand.Next(1, 7);
        }
    }
}
