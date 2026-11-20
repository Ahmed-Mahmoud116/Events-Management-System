
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.Entities
{
    internal class Person
    {
        protected string _name;
        protected int _id;
        protected string _email;
        public string Name
        {
            get { return _name; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }
        public int Id
            { get { return _id; } set { if (value <= 0) throw new ArgumentException("ID"); _id = value; } }
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be empty");
                    _email = value;
                }
            }
        
        }
        public Person(string name,string email,int id)
        {
            Name = name;
            Email = email;
            Id = id;

        }
    }
}
