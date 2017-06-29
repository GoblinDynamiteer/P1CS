/* Programmering 1 C# Arbetsbok   
 * Complex Exercise 2
 * Page 34 
 *    
 * Exercise notes: 
 * Create a 2 player game with a GUI
 * 
 * Take turns increasing a number, the 
 * person that gets to 21+ loses.
 * 
 * The game shall have three buttons that
 * increases the number by 1,2 and 3 each.
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

namespace book_complex_exercise_2
{
    public partial class Form1 : Form
    {
        int value = 0;
        
        /* true for player 1, false for player 2 */
        bool playerTurn = true;

        /* Player score */
        int[] score = { 0, 0 };

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void btnIncrease1_Click(object sender, EventArgs e)
        {
            value += 1;
            CheckScore();
        }

        private void btnIncrease2_Click(object sender, EventArgs e)
        {
            value += 2;
            CheckScore();
        }

        private void btnIncrease3_Click(object sender, EventArgs e)
        {
            value += 3;
            CheckScore();
        }

        private void SetText()
        {
            textInfo.Text = string.Format(
                "Player {0}:", playerTurn ? 1 : 2);
            textCurrentNumber.Text = string.Format(
                "Current value: {0}", value > 21 ? 21 : value);
            textScore.Text = string.Format(
                "Score\nP1: {0}\nP2: {1}", score[0], score[1]);
        }

        private void CheckScore()
        {
            if (value >= 21)
            {
                SetText();
                MessageBox.Show(string.Format(
                    "Player {0} wins!", !playerTurn ? 1 : 2));
                score[!playerTurn ? 0 : 1]++;
                Reset();
            }

            else
            {
                playerTurn = !playerTurn;
                SetText();
            }

        }

        private void Reset()
        {
            playerTurn = true;
            value = 0;
            SetText();
        }
    }
}
