using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Models
{
    public class Movie
    {
        public int movieID { get; set; }
        public string movieName { get; set; }
        public string movieDescription { get; set; }
        public DateTime? startingDate { get; set; }
        public DateTime? endingDate { get; set; }
        public List<String> movieGenres { get; set; }
        public List<String> movieCountries { get; set; }

        public Movie(int movieID, string movieName, string movieDescription, DateTime? startingDate, DateTime? endingDate, List<string> movieGenres, List<string> movieCountries) 
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.movieDescription = movieDescription;
            this.startingDate = startingDate;
            this.endingDate = endingDate;
            this.movieGenres = movieGenres;
            this.movieCountries = movieCountries;
        }
    }
}
