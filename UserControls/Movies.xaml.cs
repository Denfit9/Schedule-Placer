using CinemaSchedule.Models;
using CinemaSchedule.MySQLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaSchedule.UserControls
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : UserControl
    {
        public void refreshMovies(int userID)
        {
            moviesList.Items.Clear();
            List<Movie> movies = DatabaseQueries.populateMovies(userID);
            foreach (Movie movie in movies)
            {
                moviesList.Items.Add(new MovieControl(movie.movieID, movie.movieName, movie.movieDescription, movie.startingDate, movie.endingDate, movie.movieCountries, movie.movieGenres, movie.duration));
            }
        }

        public void searchMovies(int userID, string searchTarget)
        {
            moviesList.Items.Clear();
            List<Movie> movies = DatabaseQueries.populateMovies(userID);
            var moviesSelected = from movie in movies
                                 where (movie.movieName.StartsWith(searchTarget))
                                 select movie;
            foreach (Movie movie in moviesSelected)
            {
                moviesList.Items.Add(new MovieControl(movie.movieID, movie.movieName, movie.movieDescription, movie.startingDate, movie.endingDate, movie.movieCountries, movie.movieGenres, movie.duration));
            }
        }
        public Movies()
        {
            InitializeComponent();
            refreshMovies(App.userID);
        }

        private void addMovieButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.addMovieWindow addMovieWindow = new Windows.addMovieWindow();
            addMovieWindow.ShowDialog();
            refreshMovies(App.userID);
        }

        private void searchMovieButton_Click(object sender, RoutedEventArgs e)
        {
            if(searchTargetTextBox.Text.Length > 0)
            {
                searchMovies(App.userID, searchTargetTextBox.Text);
            }
            else
            {
                refreshMovies(App.userID);
            }
        }
    }
}
