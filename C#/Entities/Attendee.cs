using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.Entities
{
    internal class Attendee : Person
    {
        public Attendee(string name,string email,int id) : base(name, email,id) { }
       
    }
}
