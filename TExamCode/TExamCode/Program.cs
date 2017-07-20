using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TExamCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cSharpVersions = new int[6] { 2002, 2005, 2007, 2010, 2012, 2015 };

            for (int i = 0; i < cSharpVersions.Length; i++)
            {
                Console.WriteLine(cSharpVersions[i]);
            }

            Console.WriteLine();

            foreach (int version in cSharpVersions)
            {
                Console.WriteLine(version);
            }

            Console.WriteLine();

            Console.WriteLine(ProvMetod(9999));
            Console.WriteLine(ProvMetod(1));
            Console.WriteLine(ProvMetod(0));
            Console.WriteLine(ProvMetod(-22));

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("//code");
            }

            int j = 0;
            for (;;)
            {
                Console.WriteLine("//code");
                if (j++ == 10)
                    break;

            }

            int x = 12;
            for (int y = 30; ; x++)
            {
                if (y + x++ > 600)
                {
                    Console.WriteLine("Hej!");
                    break;
                }
            }

            string namn;
            namn = "Johan";
            string efternamn = "Svensson";

            Console.Write(namn + " ");
            Console.WriteLine(efternamn);


            bool potDone = false, stoveOn = false;
            int waterDegrees;

            if (!stoveOn)
            {
                stoveOn = true;
            }

            int bits = 0b0001;
            int bits2 = 0b0100;

            Console.WriteLine(bits);
            Console.WriteLine(bits<<1);
            Console.WriteLine(bits | bits2);


            Console.ReadLine();
        }

        public static int ProvMetod(int a)
        {
            if (a <= 1)
                return a;
            else
                return ProvMetod(a - 1);
        }
    }


}
