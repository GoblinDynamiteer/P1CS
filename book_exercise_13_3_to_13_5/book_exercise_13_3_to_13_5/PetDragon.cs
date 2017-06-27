using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_exercise_13_3_to_13_5
{
    class PetDragon
    {
        /* Gold in your dragon's hoard */
        private UInt64 treasure = 0;
        static Random rand = new Random();
        
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /* Constructor with default values */
        public PetDragon(string name = "Draco", 
            int age = 130, string color = "Green")
        {
            this.age = age;
            this.color = color;
            this.name = name;
        }


        /* Method for collecting treasure 
         * to the dragon's hoard */
        public void CollectTreasure()
        {
            int found = rand.Next(0, (int)UInt16.MaxValue);
            this.treasure += (ulong)found;
            Console.WriteLine("{0} flew on treasure hunt and " +
                "gathered {1} gold pieces.\nFor a total of {2}.", 
                    this.name, found, this.treasure);
        }

        /* Display info about your dragon */
        public void DisplayInfo()
        {
            Console.WriteLine("Name: {0}.", 
                this.name);
            Console.WriteLine("Spieces: {0} Dragon.", 
                this.color);
            Console.WriteLine("Age: {0} years.", 
                this.age);
            Console.WriteLine("Treasure: {0} gold pieces.", 
                this.treasure);

        }
    }
}
