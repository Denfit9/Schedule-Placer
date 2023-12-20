using MySqlConnector;
using System.Data.Common;
using System.Xml.Linq;

namespace CinemaSchedule.MySQLServices
{
    public static class DatabaseQueries
    {
        public static bool checkUserExistence(string email, string password)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT EXISTS(SELECT * FROM user WHERE email = '" + email + "' and password ='" + password + "');";
            cmd.CommandText = checkEmail;
            object exists = cmd.ExecuteScalar();
            conn.Close();

            if (Convert.ToInt32(exists) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkEmailExistence(string email)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT EXISTS(SELECT * FROM user WHERE email = '" + email + "');";
            cmd.CommandText = checkEmail;
            object exists = cmd.ExecuteScalar();
            conn.Close();

            if (Convert.ToInt32(exists) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int getUserID(string email)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT userID FROM user WHERE email = '" + email + "';";
            cmd.CommandText = checkEmail;
            int userID = (int)cmd.ExecuteScalar();
            conn.Close();

            return userID;
        }

        public static void createUser(string name, string surname, string patronymic, string email, string password, string cinemaName)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createUser = "INSERT User(name, surname, patronymic, email, password) VALUES ('" + name + "','" + surname + "','" + patronymic + "','" + email + "','" + password + "');";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createUser;
            int execute = cmd.ExecuteNonQuery();
            string createCinema = "INSERT Cinema(cinema_name, cinema_description, userID) VALUES ('" + cinemaName + "','Описание кинотеатра'," + getUserID(email) + ");";
            cmd.CommandText = createCinema;
            execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string getNSP(int userID)
        {
            string NSP = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readUser = "SELECT name, surname, patronymic FROM User WHERE userID = " + userID + ";";
            cmd.CommandText = readUser;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NSP = reader.GetString(1) + " " + reader.GetString(0) + " " +reader.GetString(2);
                    }
                }
            }

            return NSP;
        }
        public static string getCinemaName(int userID)
        {
            string cinemaName = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readUser = "SELECT cinema_name FROM Cinema WHERE userID = " + userID + ";";
            cmd.CommandText = readUser;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cinemaName = reader.GetString(0);
                    }
                }
            }

            return cinemaName;
        }
        public static int getCinemaID(int userID)
        {
            int cinemaName = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readUser = "SELECT cinemaID FROM Cinema WHERE userID = " + userID + ";";
            cmd.CommandText = readUser;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cinemaName = reader.GetInt32(0);
                    }
                }
            }
            conn.Close();
            return cinemaName;
        }
        public static void updateCinemaDescription(int userID, string description)
        {
            int cinemaID = getCinemaID(userID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createUser = "UPDATE Cinema SET cinema_description = '" + description + "' WHERE cinemaID = " + cinemaID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createUser;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static string getCinemaDescription(int userID)
        {
            string cinemaName = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readUser = "SELECT cinema_description FROM Cinema WHERE userID = " + userID + ";";
            cmd.CommandText = readUser;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cinemaName = reader.GetString(0);
                    }
                }
            }
            conn.Close();
            return cinemaName;
        }
    }
}
