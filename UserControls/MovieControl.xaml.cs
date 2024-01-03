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
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl : UserControl
    {
        public void askMessageConfirm(int movieID)
        {
            MessageBoxResult result = MessageBox.Show("Удалить данный фильм?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DatabaseQueries.deleteMovie(movieID);

                    MessageBox.Show("Удалено!", "Успешно");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        public MovieControl()
        {
            InitializeComponent();
        }

        public MovieControl(int movieID, string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres, int duration)
        {
            InitializeComponent();
            this.movieID.Content = movieID;
            this.movieName.Text = movieName;
            this.movieDescription.Text = movieDescription;
            this.startingDateText.Text = fromDate.Value.ToString("dd-MM-yyyy");
            this.endingDateText.Text = toDate.Value.ToString("dd-MM-yyyy");
            string countriesString = "";
            foreach (String country in countries)
            {
                countriesString += " " + country + ",";
            }
            if(countriesString.Length > 0)
            {
                countriesString= countriesString.Remove(countriesString.Length - 1, 1);
            }
            string genresString = "";
            foreach (String genre in genres)
            {
                genresString += " " + genre + ",";
            }
            if (genresString.Length > 0)
            {
                genresString = genresString.Remove(genresString.Length - 1, 1);
            }
            this.movieCountries.Text = countriesString;
            this.movieGenres.Text = genresString;
            int hours = duration / 3600;
            int minutes = (duration -(3600*hours))/60;
            int seconds = (duration - (3600 * hours) - (minutes*60));
            this.DurationText.Text = Convert.ToString(hours) + " час. " + Convert.ToString(minutes) + " мин. " + Convert.ToString(seconds) + " сек.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askMessageConfirm(Convert.ToInt32(movieID.Content));
            MainApp? parentWindow = Window.GetWindow(this) as MainApp;
            parentWindow?.ContentPanel.Children.Clear();
            Movies movies = new Movies();
            parentWindow?.ContentPanel.Children.Add(movies);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.editMovieWindow editMovieWindow = new Windows.editMovieWindow(Convert.ToInt32(movieID.Content.ToString()), movieName.Text, movieDescription.Text, Convert.ToDateTime(startingDateText.Text), Convert.ToDateTime(endingDateText.Text), DatabaseQueries.populateCountries(Convert.ToInt32(movieID.Content.ToString())), DatabaseQueries.populateGenres(Convert.ToInt32(movieID.Content.ToString())), DatabaseQueries.getMovieDuration(Convert.ToInt32(movieID.Content.ToString())));
            editMovieWindow.ShowDialog();
        }
    }
}
