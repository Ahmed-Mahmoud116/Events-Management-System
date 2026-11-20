
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.Entities
{
    internal class Event
    {
        private int _id;
        private string _title;
        private int _organizerId;
        private int _venueId;
        private DateOnly _date;
        public int Id
        {
            get { return _id; }
            set { if (value <= 0) throw new ArgumentException("ID"); _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Title cannot be empty");
                _title = value;
            }
        }
        public DateOnly Date
        {
            get { return _date; }
            set
            {

               _date = value;
            }
        }
        public int OrganizerId
        { get { return _organizerId; }
            set
            {

                if (value <= 0) throw new ArgumentException("ID cannot be negative or zero");
                _organizerId = value;
            }
        }
        public int VenueId
        {  get { return _venueId; }
            set
            {

               
                if (value <= 0) throw new ArgumentException("ID cannot be negative or zero");
                _venueId = value;
            }
        }
        public Event(string title,int organizerId,int venueId,int id,DateOnly date)
        {
            Title = title;
            OrganizerId = organizerId;
            VenueId = venueId;
            Id = id;
            _date = date;
        }
    }
}
