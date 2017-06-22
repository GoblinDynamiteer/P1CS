/* Programmering 1 C# Arbetsbok
 * Exercise 7.4.2
 * Page 16
 * 
 * Exercise notes:
 * Create a program: Bank Simulator:
 * 
 * Menu:
 * [D]eposit
 * [W]ithdraw
 * [C]heck account balance
 * [E]xit
 * 
 * Note: Use a switch statement, you should
 * proably also use loops
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

namespace book_exercise_7_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char menuChoice;
            BankAccount myAccount = new BankAccount();

            /* Run main menu until user exits */
            do
            {
                ShowMenu();
                menuChoice = GetKeyPress(false);

                switch (menuChoice)
                {
                    case 'd': // Deposit
                        Console.Write(
                            "Enter amount to deposit: ");
                        myAccount.Deposit(
                            Convert.ToDouble(Console.ReadLine())
                            );
                        /* "Press any key to return to main menu" */
                        GetKeyPress(true);
                        break;

                    case 'w': // Withdraw
                        Console.Write(
                            "Enter amount to Withraw: ");
                        myAccount.Withdraw(
                            Convert.ToDouble(Console.ReadLine())
                            );
                        GetKeyPress(true);
                        break;

                    case 'c': // Check account balance
                        myAccount.CheckBalance();
                        GetKeyPress(true);
                        break;

                    default:
                        break;
                }

            } while (menuChoice != 'e');

        }

        /* Gets user keypress, and displays 
         * message if bool is true */
        static char GetKeyPress(bool returnToMenu)
        {
            if (returnToMenu)
            {
                Console.WriteLine("Press any key to " +
                    "return to main menu");
            }
            char key = Console.ReadKey(true).KeyChar;
            return char.ToLower(key);
        }

        /* Show main menu */
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(
                    "[D]eposit\n" +
                    "[W]ithdraw\n" +
                    "[C]heck account balance\n" +
                    "[E]xit" );
        }
    }

    /* Bank account, deposit, withdraw 
     * and show balance */
    class BankAccount
    {
        static double balance = 0;

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Deposited {0}!",
                amount);
        }

        public void Withdraw(double amount)
        {
            if ((balance - amount) < 0)
            {
                Console.WriteLine("Not enough money!\n" +
                    "Withdrawing all available funds!");
                balance = 0;
            }
            else
            {
                Console.WriteLine("Withdrew {0}", amount);
                balance -= amount;
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine("You have {0} monies!", 
                balance);
        }
    }
}
