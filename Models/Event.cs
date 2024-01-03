using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Models
{
    public class Event
    {
        public int eventId { get; set; }
        public DateTime startingDate { get; set; }
        public string eventName { get; set; }
        public int duration { get; set; }
        public int hallID { get; set; }
        public int? movieID { get; set; }
        public int cinemaID { get; set; }
        public string eventType { get; set; }

        public Event(int eventId, DateTime startingDate, string eventName, int duration, int hallID, int? movieID, int cinemaID, string eventType)
        {
            this.eventId = eventId;
            this.startingDate = startingDate;
            this.eventName = eventName;
            this.duration = duration;
            this.hallID = hallID;
            this.movieID = movieID;
            this.cinemaID = cinemaID;
            this.eventType = eventType;
        }
    }
}
