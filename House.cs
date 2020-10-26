using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class House
    {
        private string name_house;
        private room[] arr;
        private double sum_size;
        private Address add;
        private readonly int num;
        public static int counter = 2999;

        public string Name_house
        {
            get { return name_house; }
            set
            {
                name_house = value;
            }
        }

        internal room[] Arr
        {
            get => arr;
            set => arr = value;
        }
        public double Sum_size
        {
            get => sum_size;
            set => sum_size = value;
        }
        internal Address Add
        {
            get => add;
            set => add = value;
        }

        public int Num { get { return num; } }

        public House(string name_house, room[] arr, double sum_size, Address add)
        {
            Name_house = name_house;
            Arr = arr;
            Sum_size = sum_size;
            Add = add;
            counter++;
            num = counter;
        }

        public House(string name_house, Address add)
        {
            Name_house = name_house;
            Add = add;
            int z;
            string r;
            double size, sum = 0;
            char commo;
            Console.WriteLine("How many rooms do you want?");
            int numrooms = int.Parse(Console.ReadLine());
            room[] rooms = new room[numrooms];
            for (int i = 0; i < rooms.Length; i++)
            {
                Console.WriteLine("Do you want to give details for room {0}? for yes press 1 or for no press 0", i + 1);
                z = int.Parse(Console.ReadLine());
                if (z == 1)
                {
                    Console.WriteLine("Please write the type of the room, and size for room number {0}", i + 1);
                    r = Console.ReadLine();
                    size = double.Parse(Console.ReadLine());
                    Console.WriteLine("if the room is coomon insert t, else insert f");
                    commo = char.Parse(Console.ReadLine());
                    rooms[i] = new room(r, size, commo == 't' ? true : false);
                }
                else
                    rooms[i] = new room();
                sum += rooms[i].Size;
            }
            Arr = rooms;
            Sum_size = sum;
            counter++;
            num = counter;
        }

        public double average()
        {
            // return size/arr.length
            return Sum_size / Arr.Length;
        }

        public room biggestRoom()
        {
            room x = new room("", 0, true); // room x = getroom()[0];
            foreach (room item in Arr)
                if (item.Size > x.Size)
                    x = new room(item.Type, item.Size, item.If_common);
            //x = item;
            return x;
        }

        public room getARoom(string type)
        {
            foreach (room item in Arr)
                if (item.Type == type)
                    return item;
            return null;
        }


        public House compare(House h)
        {
            double size1 = 0, size2 = 0;
            foreach (room item1 in Arr)
                foreach (room item2 in h.Arr)
                {
                    if (item1.Type == item2.Type)
                    {
                        size1 += item1.Size;
                        size2 += item2.Size;
                    }
                }
            if (size1 > size2)
                return this;
            return h;

        }


        public void show()
        {
            Console.WriteLine("the name of the house is {0} and the size of all the room is {1} square meter.", Name_house, Sum_size);
            Console.Write("the address is: ");
            Add.show();
            Console.WriteLine("detalis of the rooms are: ");
            foreach (room item in Arr)
                item.show();
            Console.WriteLine();
            House.slogan();
            Console.WriteLine("The number of the house is {0} ", num);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return "The mame of house: " + Name_house + ", the size of the house:" + Sum_size + " ,and the address: " + Add.ToString();
        }

        static public void slogan()
        {
            Console.WriteLine("I love my house");
        }
    }
}

