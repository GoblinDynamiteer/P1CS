using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] heltal = new int[4] { 1, 2, 3, 4 };

            for (int i = 0; i < heltal.Length + 10 ; i++)
            {
                try
                {
                    Console.WriteLine(heltal[i]);
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("index " + i + " är utanför array!");
                }

            }

            heltal[7] = 2;

            Console.ReadLine();
        }

    }
}
