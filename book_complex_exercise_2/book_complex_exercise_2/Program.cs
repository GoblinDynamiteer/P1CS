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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_complex_exercise_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
