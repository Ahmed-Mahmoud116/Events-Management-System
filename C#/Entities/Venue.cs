
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.Entities
{
    internal class Venue
    {
        private int _id;
        private string _name;
        private string _location;
        private int _capacity;
        public int Id { get { return _id; } set { if (value <= 0) throw new ArgumentException("ID"); _id = value; } }
            public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Location cannot be empty");
                _location = value;
            }

        }
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value < 0) throw new ArgumentException("Capacity cannot be negative");
                _capacity = value;
            }
        }
        public Venue(string name,string location, int capacity,int id)
        {
            Name = name;
            Location = location;
            Capacity = capacity;
            Id = id;

        }
    } 
}
