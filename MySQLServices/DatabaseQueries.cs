﻿using CinemaSchedule.Models;
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

        public static void updateCinemaName(int cinemaID, string name)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createHall = "Update Cinema SET cinema_name = '" + name + "' WHERE cinemaID = " + cinemaID + ";";
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

        public static void createMovie(string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres, int duration)
        {
            int cinemaID = getCinemaID(App.userID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createMovie = "INSERT Movie(movie_name, movie_description, since, up_to, cinemaID, movie_duration) VALUES ('" + movieName + "','" + movieDescription + "','" + fromDate.Value.ToString("yyyy-MM-dd") + "','" + toDate.Value.ToString("yyyy-MM-dd") + "'," + cinemaID + ", " + duration  + ");";
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
        public static void updateMovie(int movieID, string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres, int duration)
        {
            deleteCountries(movieID);
            deleteGenres(movieID);
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string updateMovie = "Update Movie SET movie_name = '" + movieName + "', movie_description = '" + movieDescription + "', since = '" + fromDate.Value.ToString("yyyy-MM-dd") + "', up_to = '" + toDate.Value.ToString("yyyy-MM-dd") + "', movie_duration= " + duration +  " WHERE movieID = " + movieID + ";";
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

        public static int getMovieDuration(int movieID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT movie_duration FROM Movie WHERE movieID = '" + movieID + "';";
            cmd.CommandText = checkEmail;
            int userID = (int)cmd.ExecuteScalar();
            conn.Close();

            return userID;
        }

        public static int getEventDuration(int eventID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkEmail = "SELECT duration FROM Event WHERE eventID = '" + eventID + "';";
            cmd.CommandText = checkEmail;
            int userID = (int)cmd.ExecuteScalar();
            conn.Close();

            return userID;
        }

        public static void updateEvent(int eventID, DateTime fromDate)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            DateTime? fromDateNew = fromDate;
            string updateMovie = "Update Event SET time = '" + fromDateNew.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE eventID = " + eventID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = updateMovie;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }
            public static string getMovieName(int movieID)
        {
            string movieName = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string checkName = "SELECT movie_name FROM Movie WHERE movieID = '" + movieID + "';";
            cmd.CommandText = checkName;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movieName = reader.GetString(0);
                    }
                }
            }
            conn.Close();

            return movieName;
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
                        movies.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), populateGenres(reader.GetInt32(0)), populateCountries(reader.GetInt32(0)), reader.GetInt32(6)));
                    }
                }
            }
            conn.Close();
            return movies;
        }

        public static List<Movie> populateMoviesForEvent(int userID, DateTime? date)
        {
            int cinemaID = getCinemaID(userID);
            List<Movie> movies = new List<Movie>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM Movie WHERE cinemaID = " + cinemaID + " and since <= '" + date.Value.ToString("yyyy-MM-dd")  +"' and up_to >= '" + date.Value.ToString("yyyy-MM-dd") + "' ORDER BY movieID DESC;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), populateGenres(reader.GetInt32(0)), populateCountries(reader.GetInt32(0)), reader.GetInt32(6)));
                    }
                }
            }
            conn.Close();
            return movies;
        }
        public static void createEvent(int? movieID, DateTime? beginning, string eventName, int hours, int minutes, int seconds, int duration, int hallID, int cinemaID, string eventType)
        {
            string movieIDString = "";
            if (movieID == null)
            {
                movieIDString = "NULL";
            }
            else
            {
                movieIDString = movieID.ToString();
            }
            DateTime dateTime = Convert.ToDateTime(beginning);
            int typeID = 0;
            if (eventType == "Фильм")
            {
                typeID = 1;
            }
            else if (eventType == "Перерыв")
            {
                typeID = 2;
            }
            else if(eventType == "Мероприятие")
            {
                typeID = 3;
            }
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createNote = "INSERT Event(time, name, duration, hallID, movieID, cinemaID, typeID) VALUES ('" + dateTime.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + eventName + "', " + duration + ", " + hallID + ", " + movieIDString + ", " + getCinemaID(App.userID) + ", " + typeID + ");";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createNote;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void createEventSeconds(int? movieID, DateTime? beginning, string eventName, int seconds, int duration, int hallID, int cinemaID, string eventType)
        {
            string movieIDString = "";
            if (movieID == null)
            {
                movieIDString = "NULL";
            }
            else
            {
                movieIDString = movieID.ToString();
            }
            DateTime dateTime = Convert.ToDateTime(beginning);
            int typeID = 0;
            if (eventType == "Фильм")
            {
                typeID = 1;
            }
            else if (eventType == "Перерыв")
            {
                typeID = 2;
            }
            else if (eventType == "Мероприятие")
            {
                typeID = 3;
            }
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string createNote = "INSERT Event(time, name, duration, hallID, movieID, cinemaID, typeID) VALUES ('" + dateTime.AddSeconds(seconds).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + eventName + "', " + duration + ", " + hallID + ", " + movieIDString + ", " + getCinemaID(App.userID) + ", " + typeID + ");";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = createNote;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteEvent(int eventID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string deleteMovie = "DELETE from Event where eventID=" + eventID + ";";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = deleteMovie;
            int execute = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string getEventType(int eventID)
        {
            string eventType = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT type_name FROM Type JOIN event on event.TypeID = Type.TypeID WHERE eventID = " + eventID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventType=reader.GetString(0);
                    }
                }
            }
            conn.Close();
            return eventType;
        }

        public static string getHallName(int hallID)
        {
            string hallName = "";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT hall_name FROM Hall WHERE hallID = " + hallID + ";";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        hallName = reader.GetString(0);
                    }
                }
            }
            conn.Close();
            return hallName;
        }

        public static List<Event> populateEvents(int userID, DateTime? date, int hallID)
        {
            int cinemaID = getCinemaID(userID);
            List<Event> events = new List<Event>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM EVENT WHERE cinemaID = " + cinemaID + " and time >= '" + date.Value.ToString("yyyy-MM-dd 00:00:00") + "' and time <='" + date.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00") + "' and hallID = " + hallID  + " ;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(5))
                        {
                            events.Add(new Event(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), null, reader.GetInt32(6), getEventType(reader.GetInt32(0))));
                        }
                        else
                        {
                            events.Add(new Event(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), getEventType(reader.GetInt32(0))));
                        }
                    }
                }
            }
            conn.Close();
            return events;
        }

        public static List<Event> populateEventsList(int userID, DateTime? date, int hallID)
        {
            int cinemaID = getCinemaID(userID);
            List<Event> events = new List<Event>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT * FROM EVENT WHERE cinemaID = " + cinemaID + " and time >= '" + date.Value.ToString("yyyy-MM-dd") + "' and time <= '" + date.Value.AddDays(1).ToString("yyyy-MM-dd") + "' and hallID = " + hallID + " ORDER BY time ;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        events.Add(new Event(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), 0, reader.GetInt32(6), getEventType(reader.GetInt32(0))));
                    }
                }
            }
            conn.Close();
            return events;
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

        public static List<String> populateTypes()
        {
            List<String> types = new List<String>();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string readAccounts = "SELECT type_name from type;";
            cmd.CommandText = readAccounts;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        types.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return types;
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
