using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Models
{
    public class User
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User(int userID, string name, string surname, string email, string password)
        {
            this.userID = userID;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
        }
    }
}
