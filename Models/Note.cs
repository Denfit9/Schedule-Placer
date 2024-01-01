using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Models
{
    public class Note
    {
        public int noteID { get; set; }
        public string noteName { get; set; }

        public Note(int noteID, string noteName)
        {
            this.noteID = noteID;
            this.noteName = noteName;
        }
    }
}
