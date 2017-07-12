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
            List<int> heltalLista = new List<int>();

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

            for (int i = 0; i < 30; i++)
            {
                heltalLista.Add(i+30);
            }

            for (int i = 0; i < heltalLista.Count; i++)
            {
                Console.WriteLine(heltalLista[i]);
            }

            Console.WriteLine();

            Console.WriteLine(heltalLista.ElementAt(4));

            Console.WriteLine();

            List<int> nyLista = heltalLista.GetRange(10, 10);
            for (int i = 0; i < nyLista.Count; i++)
            {
                Console.WriteLine(nyLista[i]);
            }

            Console.ReadLine();
        }

    }
}
