/* Programmering 1 C# Arbetsbok   
 * Complex Exercise 1
 * Page 33 
 *    
 * Exercise notes: 
 * Create a guessing game with a GUI
 * 
 * Generate a random number (1-100)
 * Have user enter guesses in a textbox
 * 
 * Display text telling if number is 
 * higher or lower than guess
 *     
 *     
 * Johan Kämpe   
 * https://github.com/GoblinDynamiteer/   
 * https://www.linkedin.com/in/johankampe/   
 *    
 */ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_complex_exercise_1
{
    public partial class GuessNumber : Form
    {
        GuessingGame Game = new GuessingGame();

        public GuessNumber()
        {
            InitializeComponent();

            Game.GenerateNewNumber();
            TextBoxGuess.Text = "0";
            TextBoxGuess.Focus();
            TextBoxGuess.SelectAll();
            textBox1.Select(0, 0);
        }

        private void TextBoxGuess_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonGuess_Click(object sender, EventArgs e)
        {
            int userGuess;

            if (int.TryParse(TextBoxGuess.Text, out userGuess))
            {
                /* Check can 0: num is lower, 1: num is higher, 
                 * 2: guess is correct! */
                int guessCheck = Game.CheckGuess(userGuess);
                if (guessCheck == 2)
                {
                    /* Pop a message box and reset game */
                    MessageBox.Show("Correct! " +
                        "New random number generated");
                    Game.GenerateNewNumber();
                    TextBoxGuess.Clear(); // Clear guess textbox
                }

                else
                {
                    string text = (guessCheck == 0) ? 
                        "lower!" : "higher";

                    textBox1.Text = string.Format(
                        "You guessed {0}\r\nThe number is {1}", 
                            userGuess, 
                            text);
                }

                /* Select guess textbox and 
                 * focus text cursor */
                TextBoxGuess.Focus();
                TextBoxGuess.SelectAll();
            }
            
        }

    }

    public class GuessingGame
    {
        static Random random = new Random();
        int number;

        public void GenerateNewNumber()
        {
            number = random.Next(1, 101);
        }

        /* Return 2 if guess is correct
         * Return 1 if guess is too high
         * return 0 if guess is too low */
        public int CheckGuess(int guess)
        {
            int retVal = 2;
            if (guess != number)
            {
                retVal = (guess > number) ? 0 : 1;
            }
            return retVal;
        }
    }
}
