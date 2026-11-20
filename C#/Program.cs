namespace Event_Management_System
{
    using Event_Management_System.Entities;
   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Organizer> organizers = new List<Organizer>
            {
                new Organizer("O1","o1@gmail.com",10),
                new Organizer("O2","o2@gmail.com",20),
                new Organizer("O3","o3@gmail.com",30),
                new Organizer("O4","o4@gmail.com",40),
                new Organizer("O5","o5@gmail.com",50),
                new Organizer("O6","o6@gmail.com",60),
                new Organizer("O7","o7@gmail.com",70)
            };
            List<Attendee> attendees = new List<Attendee>
            {
                new Attendee("a1","a1@gmail.com",10),
                new Attendee("a2","a2@gmail.com",20),
                new Attendee("a3","a3@gmail.com",30),
                new Attendee("a4","a4@gmail.com",40),
                new Attendee("a5","a5@gmail.com",50),
                new Attendee("a6","a6@gmail.com",60),
                new Attendee("a7","a7@gmail.com",70)
            };
            List<Venue> venues = new List<Venue>
            {
                new Venue("v1","l1",50,10),
                new Venue("v2","l2",30,20),
                new Venue("v3","l3",25,30),
                new Venue("v4","l4",35,40),
                new Venue("v5","l5",45,50),
                new Venue("v6","l6",60,60),
                new Venue("v7","l7",65,70)
            };
            List<Event> events = new List<Event> 
            { 
              new Event("e1",10,10,10,new DateOnly(2026,11,19)),
              new Event("e1",10,20,20,new DateOnly(2026,12,10)),
              new Event("e1",20,30,30,new DateOnly(2026,11,3)),
              new Event("e1",20,40,40,new DateOnly(2027,1,22)),
              new Event("e1",30,50,50,new DateOnly(2027,2,25)),
              new Event("e1",40,60,60,new DateOnly(2026,12,25)),
              new Event("e1",50,70,70,new DateOnly(2026,3,1)),
              new Event("e1",60,70,80,new DateOnly(2027,4,5))
            };
            List<Ticket> tickets = new List<Ticket>
            {
                new Ticket(10,20,80.5,10,new DateOnly(2026,11,19)),
                new Ticket(10,30,80.5,20,new DateOnly(2026,11,25)),
                new Ticket(20,40,90.5,30,new DateOnly(2026,12,11)),
                new Ticket(20,40,90.5,40,new DateOnly(2026,12,15)),
                new Ticket(30,50,100.5,50,new DateOnly(2026,1,20)),
                new Ticket(30,50,100.5,60,new DateOnly(2026,2,21)),
                new Ticket(40,20,65.5,70,new DateOnly(2026,11,19)),
                new Ticket(50,60,105.5,80,null)
            };
            var query1 = events.Where(x => x.OrganizerId == 10).Select(e => e.Id);
            var query2 = tickets.Where(e => e.EventId == 10).Select(a => a.AttendeeId);
            var query3 = tickets.GroupBy(e => e.EventId).Select(w => new
            {
                EventId = w.Key,
                TotalRevenue = w.Sum(t => t.Price)
            });
            var query4 = tickets.GroupBy(e => e.EventId).Select(g => new
            {
                EventId = g.Key,
                Attendees = g.Count()
            });
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            var query5 = events.Where(e => e.Date > today).OrderBy(e => e.Date).Select(e => new
            {
                e.Id,
                e.Title
            });
            var query6 = tickets.Where(t => t.CheckedIn == null).Select(a => a.AttendeeId);
            var query7 = tickets.GroupBy(e => e.EventId).Select(t => new
            {
                EventId = t.Key,
                TotalAttendees = t.Count()
            }).OrderByDescending(e => e.TotalAttendees).FirstOrDefault();
            var query8 = organizers.Join(
                events,
                o => o.Id,
                e => e.OrganizerId,
                (o, e) => new
                {
                    OrganizerName = o.Name,
                    e.Id,
                    e.Title,
                    e.OrganizerId,
                    e.VenueId

                }
                ).Join(
                venues,
                e => e.VenueId,
                v => v.Id,
                (e,v) => new
                {
                    e.Id,
                    v.Name,
                    e.VenueId,
                    e.Title,
                    e.OrganizerName,
                    e.OrganizerId,
                    v.Capacity

                });
            var query9 = tickets.GroupBy(a => a.AttendeeId).Select(g => new
            {
                AttendeeId = g.Key,
                AttendeesCount = g.Select(t => t.EventId).Distinct().Count()
            }).Where(g => g.AttendeesCount > 1);
            var FinalQuery = tickets.Join(
                events,
                t => t.EventId,
                e => e.Id,
                (t, e) => new
                {
                    t.AttendeeId,
                    t.EventId,
                    t.Id,
                    e.VenueId

                }).Join(
                   venues,
                   t => t.VenueId,
                   v => v.Id,
                   (t, v) => new
                   {
                       t.EventId,
                       v.Id,
                       v.Capacity
                   }).GroupBy(t => t.EventId).Select(g => new
                   {
                       EventId = g.Key,
                       TotalTickets = g.Count(),
                       Capacity = g.First().Capacity
                   }).Where(g => g.Capacity <= g.TotalTickets);
               
        }
    }
}
/*
1-Get all events organized by a specific organizer.
2-Get all attendees for a specific event.
3-Total ticket revenue per event.
4-Number of attendees per event.
5-Upcoming events sorted by date.
6-Attendees who didn’t check in.
7-Most attended events or top revenue-generating events.
8-Event with organizer and venue info.
9-Attendees attending multiple events
10-Events that are fully booked.*/