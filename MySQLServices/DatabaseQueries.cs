using CinemaSchedule.Models;
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
        public static bool checkMovieBusiness(int movieID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT EXISTS(SELECT * FROM event WHERE movieID = '" + movieID + "');";
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

        public static void createHall(string name, string description, int userID)
        {
            int cinemaID = getCinemaID(userID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createHall = "INSERT Hall(hall_name, hall_description, cinemaID) VALUES ('" + name + "','" + description + "'," + cinemaID + ");";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createHall;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void updateHall(int hallID, string name, string description)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createHall = "Update Hall SET hall_name = '" + name + "', hall_description = '" + description + "' WHERE hallID = " + hallID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createHall;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteHall(int hallID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string deleteHall = "DELETE from Hall where hallID=" + hallID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = deleteHall;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Hall> populateHalls(int userID)
        {
            List<Hall> halls = new List<Hall>();
            int cinemaID = getCinemaID(userID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM Hall WHERE cinemaID = " + cinemaID + " ORDER BY hallID DESC;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        halls.Add(new Hall(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
            }
            conn.Close();
            return halls;
        }

        public static void createNote(string name, int userID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createNote = "INSERT Note(note_name, userID) VALUES ('" + name + "'," + userID + ");";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createNote;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteNote(int noteID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string deleteHall = "DELETE from Note where noteID=" + noteID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = deleteHall;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void updateNote(int noteID, string noteName)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createHall = "Update Note SET note_name = '" + noteName + "' WHERE noteID = " + noteID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createHall;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Note> populateNotes(int userID)
        {
            List<Note> notes = new List<Note>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM Note WHERE userID = " + userID + " ORDER BY noteID DESC;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        notes.Add(new Note(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            conn.Close();
            return notes;
        }

        public static void createMovie(string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres)
        {
            int cinemaID = getCinemaID(App.userID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createMovie = "INSERT Movie(movie_name, movie_description, since, up_to, cinemaID) VALUES ('" + movieName + "','" + movieDescription + "','" + fromDate.Value.ToString("yyyy-MM-dd") + "','" + toDate.Value.ToString("yyyy-MM-dd") + "'," + cinemaID + ");";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createMovie;
            int execute = cmd.ExecuteNonQuery();
            string getMovieID = "SELECT movieID FROM Movie WHERE movie_name = '" + movieName +"' and movie_description='" + movieDescription + "' and since='" + fromDate.Value.ToString("yyyy-MM-dd") + "' and up_to ='" + toDate.Value.ToString("yyyy-MM-dd") + "' and cinemaID=" + cinemaID + ";";
            cmd.CommandText = getMovieID;
            int movieID = 0;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movieID = reader.GetInt32(0);
                    }
                }
            }
            foreach(String country in countries)
            {
                string createCountry = "INSERT CountryConn(movieID, countryID) VALUES (" + movieID + "," + getCountryID(country) + ");";
                cmd.CommandText = createCountry;
                execute = cmd.ExecuteNonQuery();
            }
            foreach (String genre in genres)
            {
                string createGenre = "INSERT GenreConn(movieID, genreID) VALUES (" + movieID + "," + getGenreID(genre) + ");";
                cmd.CommandText = createGenre;
                execute = cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        public static void updateMovie(int movieID, string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres)
        {
            deleteCountries(movieID);
            deleteGenres(movieID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string updateMovie = "Update Movie SET movie_name = '" + movieName + "', movie_description = '" + movieDescription + "', since = '" + fromDate.Value.ToString("yyyy-MM-dd") + "', up_to = '" + toDate.Value.ToString("yyyy-MM-dd") + "' WHERE movieID = " + movieID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = updateMovie;
            int execute = cmd.ExecuteNonQuery();
            foreach (String country in countries)
            {
                string createCountry = "INSERT CountryConn(movieID, countryID) VALUES (" + movieID + "," + getCountryID(country) + ");";
                cmd.CommandText = createCountry;
                execute = cmd.ExecuteNonQuery();
            }
            foreach (String genre in genres)
            {
                string createGenre = "INSERT GenreConn(movieID, genreID) VALUES (" + movieID + "," + getGenreID(genre) + ");";
                cmd.CommandText = createGenre;
                execute = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void deleteMovie(int movieID)
        {
            deleteCountries(movieID);
            deleteGenres(movieID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string deleteMovie = "DELETE from Movie where movieID=" + movieID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = deleteMovie;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Movie> populateMovies(int userID)
        {
            int cinemaID = getCinemaID(userID);
            List<Movie> movies = new List<Movie>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM Movie WHERE cinemaID = " + userID + " ORDER BY movieID DESC;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), populateGenres(reader.GetInt32(0)), populateCountries(reader.GetInt32(0))));
                    }
                }
            }
            conn.Close();
            return movies;
        }

        public static List<String> populateCountries(int movieID)
        {
            List<String> countries = new List<String>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT movieID, country_name FROM countryConn JOIN country on countryConn.countryID = Country.countryID WHERE movieID =" + movieID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(reader.GetString(1));
                    }
                }
            }
            conn.Close();
            return countries;
        }
        public static void deleteCountries(int movieID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<String> countriesIDS = getCountriesID(movieID);
            foreach (String countriesID in countriesIDS)
            {
                string deleteCountry = "DELETE from CountryConn where genreConnID=" + Convert.ToInt32(countriesID) + ";";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = deleteCountry;
                int execute = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void deleteGenres(int movieID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            List<String> genresIDS = getGenresID(movieID);
            foreach (String genreID in genresIDS)
            {
                string deleteGenre = "DELETE from GenreConn where genreConnID=" + Convert.ToInt32(genreID) + ";";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = deleteGenre;
                int execute = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static List<String> getCountriesID(int movieID)
        {
            List<String> countries = new List<String>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT genreConnID FROM countryConn JOIN country on countryConn.countryID = Country.countryID WHERE movieID =" + movieID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                }
            }
            conn.Close();
            return countries;
        }

        public static List<String> getGenresID(int movieID)
        {
            List<String> countries = new List<String>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT genreConnID FROM genreConn JOIN genre on genreConn.genreID = Genre.genreID WHERE movieID =" + movieID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                }
            }
            conn.Close();
            return countries;
        }

        public static List<String> populateGenres(int movieID)
        {
            List<String> genres = new List<String>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT movieID, genre_name FROM genreConn JOIN genre on genreConn.genreID = Genre.genreID WHERE movieID =" + movieID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        genres.Add(reader.GetString(1));
                    }
                }
            }
            conn.Close();
            return genres;
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

        public static int getGenreID(string genreName)
        {
            int genreID = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readGenre = "SELECT genreID FROM Genre WHERE genre_name = '" + genreName + "';";
            cmd.CommandText = readGenre;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        genreID = reader.GetInt32(0);
                    }
                }
            }
            return genreID;
        }

        public static int getCountryID(string countryName)
        {
            int countryID = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readCountry = "SELECT countryID FROM Country WHERE country_name = '" + countryName + "';";
            cmd.CommandText = readCountry;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countryID = reader.GetInt32(0);
                    }
                }
            }
            return countryID;
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
