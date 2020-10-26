using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class room
    {
        private string type;
        private double size;
        private bool if_common;

        public string Type
        {
            get => type;
            set => type = value;
        }
        public double Size
        {
            get => size;
            set => size = value;
        }
        public bool If_common
        {
            get => if_common;
            set => if_common = value;
        }

        public room(string type, double size, bool if_common)
        {
            //this.settype(type); // // Another option
            this.Type = type;
            this.Size = size;
            this.If_common = if_common;
        }

        public room() : this("salon", 13.4, false) { }

        public int compare(room x)
        {
            if (x.size == this.size)
                return 0;
            if (this.size > x.size)
                return 1;
            return -1;
        }

        public void show()
        {
            Console.Write("the type of the room is {0} and the size of the room is {1} square meter, ", Type, Size);
            if (this.If_common)
                Console.Write("The room is Common.\n");
            else
                Console.Write("The room is not common.\n");
        }

        public override string ToString()
        {
            return Type + " " + Size + " " + If_common;
        }

    }
}
