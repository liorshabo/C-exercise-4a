using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Address
    {
        private string name_city;
        private string name_street;
        private int house_number;

        public string Name_city
        {
            get => name_city;
            set => name_city = value;
        }
        public string Name_street
        {
            get => name_street;
            set => name_street = value;
        }
        public int House_number
        {
            get => house_number;
            set => house_number = value;
        }


        public Address(string name_city, string name_street, int house_number)
        {
            this.name_city = name_city;
            this.name_street = name_street;
            this.house_number = house_number;
        }

        public Address()
        {
            Name_city = "natanya";
            Name_street = "shmooel";
            House_number = 25;
        }

        public bool sameAddress(Address y)
        {
            if ((y.name_city == this.name_city) && (y.name_street == this.name_street) && (y.house_number == this.house_number))
                return true;
            else
                return false;
        }


        public void show()

        {
            Console.WriteLine("name of the city - {0} ,name of the street - {1} ,house number - {2}", name_city, name_street, house_number);
        }

        public override string ToString()
        {
            return Name_city + " " + Name_street + " " + House_number;
        }
    }
}
