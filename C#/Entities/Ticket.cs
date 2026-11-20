
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.Entities
{
    internal class Ticket
    {
        private int _id;
        private int _eventId;
        private int _attendeeId;
        private double _price;
        private DateOnly? _checkedIn;
        public int Id { get { return _id; } set { if (value <= 0) throw new ArgumentException("ID"); _id = value; } }   
        public int EventId 
        { 
            get { return _eventId; }
            set { if (value <= 0) throw new ArgumentOutOfRangeException("ID cannot be negative or zero"); 
            _eventId = value;
            }
        }
        public int AttendeeId { get {return _attendeeId; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("ID cannot be negative or zero");
                _attendeeId = value;
            }
        
        
        }
        public double Price { get { return _price; }
        set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negaive");
                _price = value;
            }
        
        }
        public DateOnly? CheckedIn { get { return _checkedIn; } set { _checkedIn = value; } }
        public Ticket(int eventId,int attendeeId,double price,int id,DateOnly? date)
        {
            EventId = eventId;
            AttendeeId = attendeeId;
            Price = price;
            _checkedIn = date;
            Id = id;
        }
    }
}
