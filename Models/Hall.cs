using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Models
{
    public  class Hall
    {
        public int hallID { get; set; }
        public string hallName { get; set; }
        public string hallDescription { get; set; }

        public Hall(int hallID, string hallName, string hallDescription)
        {
            this.hallID = hallID;
            this.hallName = hallName;
            this.hallDescription = hallDescription;
        }
    }
}
