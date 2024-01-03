﻿using CinemaSchedule.MySQLServices;
using CinemaSchedule.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaSchedule.Windows
{
    /// <summary>
    /// Interaction logic for editMovieWindow.xaml
    /// </summary>
    public partial class editMovieWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool movieValidation(string name, string description, DateTime? fromDate, DateTime? toDate, ref string errorMsg, int hours, int minutes, int seconds)
        {
            int errorCount = 0;
            if (string.IsNullOrEmpty(name))
            {
                errorCount++;
                errorMsg += "Некорректное название\n";
            }
            if (string.IsNullOrEmpty(description))
            {
                errorCount++;
                errorMsg += "Некорректное описание\n";
            }

            if (fromDate == null)
            {
                errorCount++;
                errorMsg += "Некорректная дата начала проката\n";
            }

            if (toDate == null)
            {
                errorCount++;
                errorMsg += "Некорректная дата окончания проката\n";
            }

            if (fromDate >= toDate)
            {
                errorCount++;
                errorMsg += "Некорректные даты проката (возможно дата окончания проката меньше даты начала)\n";
            }
            if (hours >= 5)
            {
                errorCount++;
                errorMsg += "Фильм не может быть длиннее пяти часов\n";
            }
            if (minutes > 60)
            {
                errorCount++;
                errorMsg += "Минуты должны быть меньше 60\n";
            }
            if (seconds > 60)
            {
                errorCount++;
                errorMsg += "Секунды должны быть меньше 60\n";
            }
            if ((hours * 3600 + minutes * 60 + seconds) <= 1800)
            {
                errorCount++;
                errorMsg += "Фильм должен быть длиннее 30 минут\n";
            }

            if (errorCount != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private List<String> GetCountries()
        {
            List<String> countries = new List<String>();
            if (australiaCheckBox.IsChecked == true)
            {
                countries.Add("Австралия");
            }
            if (belarusCheckBox.IsChecked == true)
            {
                countries.Add("Беларусь");
            }
            if (belgiumCheckBox.IsChecked == true)
            {
                countries.Add("Бельгия");
            }
            if (britainCheckBox.IsChecked == true)
            {
                countries.Add("Великобритания");
            }
            if (germanyCheckBox.IsChecked == true)
            {
                countries.Add("Германия");
            }
            if (greeceCheckBox.IsChecked == true)
            {
                countries.Add("Греция");
            }
            if (russiaCheckBox.IsChecked == true)
            {
                countries.Add("Россия");
            }
            if (usaCheckBox.IsChecked == true)
            {
                countries.Add("США");
            }
            return countries;
        }
        private List<String> GetGenres()
        {
            List<String> genres = new List<String>();
            if (actionCheckBox.IsChecked == true)
            {
                genres.Add("Боевик");
            }
            if (biographyCheckBox.IsChecked == true)
            {
                genres.Add("Биография");
            }
            if (warCheckBox.IsChecked == true)
            {
                genres.Add("Военный");
            }
            if (kidsCheckBox.IsChecked == true)
            {
                genres.Add("Детский");
            }
            if (dramaCheckBox.IsChecked == true)
            {
                genres.Add("Драма");
            }
            if (documentalCheckBox.IsChecked == true)
            {
                genres.Add("Документальный");
            }
            if (detectiveCheckBox.IsChecked == true)
            {
                genres.Add("Детектив");
            }
            if (criminalCheckBox.IsChecked == true)
            {
                genres.Add("Криминал");
            }
            if (comedyCheckBox.IsChecked == true)
            {
                genres.Add("Комедия");
            }
            if (cartoonCheckBox.IsChecked == true)
            {
                genres.Add("Мультик");
            }
            if (melodramaCheckBox.IsChecked == true)
            {
                genres.Add("Мелодрама");
            }
            if (horrorCheckBox.IsChecked == true)
            {
                genres.Add("Ужастик");
            }
            return genres;
        }
        private void editMovie(int movieID,string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, int hours, int minutes, int seconds)
        {
            string errorMsg = "";
            if (movieValidation(movieName, movieDescription, fromDate, toDate, ref errorMsg, hours, minutes, seconds) == false)
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                int secondsFull = hours * 3600 + minutes * 60 + seconds;
                List<String> countriesReceived = GetCountries();
                List<String> genresReceived = GetGenres();
                DatabaseQueries.updateMovie(movieID, movieName, movieDescription, fromDate, toDate, countriesReceived, genresReceived, secondsFull);
                MessageBox.Show("Фильм успешно изменён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }
        public editMovieWindow(int movieID, string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate, List<String> countries, List<String> genres, int duration)
        {
            InitializeComponent();
            int hours = duration / 3600;
            int minutes = (duration - (3600 * hours)) / 60;
            int seconds = (duration - (3600 * hours) - (minutes * 60));
            this.movieID = movieID;
            this.movieName.Text = movieName;
            this.movieDescription.Text = movieDescription;
            this.startingCalendar.SelectedDate = fromDate;
            this.endingCalendar.SelectedDate = toDate;
            this.movieHours.Text = Convert.ToString(hours);
            this.movieMinutes.Text = Convert.ToString(minutes);
            this.movieSeconds.Text = Convert.ToString(seconds);
            foreach (String country in countries)
            {
                if (country=="Австралия")
                {
                    australiaCheckBox.IsChecked=true;
                }
                if (country == "Беларусь")
                {
                    belarusCheckBox.IsChecked = true;
                }
                if (country == "Бельгия")
                {
                    belgiumCheckBox.IsChecked = true;
                }
                if (country == "Великобритания")
                {
                    britainCheckBox.IsChecked = true;
                }
                if (country == "Германия")
                {
                    germanyCheckBox.IsChecked = true;
                }
                if (country == "Греция")
                {
                    greeceCheckBox.IsChecked = true;
                }
                if (country == "Россия")
                {
                    russiaCheckBox.IsChecked = true;
                }
                if (country == "США")
                {
                    usaCheckBox.IsChecked = true;
                }
            }
            foreach(String genre in genres)
            {
                if (genre == "Боевик")
                {
                    actionCheckBox.IsChecked = true;
                }
                if (genre == "Биография")
                {
                    biographyCheckBox.IsChecked = true;
                }
                if (genre == "Военный")
                {
                    warCheckBox.IsChecked = true;
                }
                if (genre == "Детский")
                {
                    kidsCheckBox.IsChecked = true;
                }
                if (genre == "Драма")
                {
                    dramaCheckBox.IsChecked = true;
                }
                if (genre == "Документальный")
                {
                    documentalCheckBox.IsChecked = true;
                }
                if (genre == "Детектив")
                {
                    detectiveCheckBox.IsChecked = true;
                }
                if (genre == "Криминал")
                {
                    criminalCheckBox.IsChecked = true;
                }
                if (genre == "Комедия")
                {
                    comedyCheckBox.IsChecked = true;
                }
                if (genre == "Мультик")
                {
                    cartoonCheckBox.IsChecked = true;
                }
                if (genre == "Мелодрама")
                {
                    melodramaCheckBox.IsChecked = true;
                }
                if (genre == "Ужастик")
                {
                    horrorCheckBox.IsChecked = true;
                }
            }
        }
        private int movieID = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DatabaseQueries.checkMovieBusiness(movieID))
            {
                showErrorMessage("Данный фильм сейчас стоит в расписании!\nИзменить его нельзя!");
            }
            else
            {
                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                if (movieHours.Text.Length == 0)
                {
                    hours = 0;
                }
                else
                {
                    hours = Convert.ToInt32(movieHours.Text);
                }
                if (movieMinutes.Text.Length == 0)
                {
                    minutes = 0;
                }
                else
                {
                    minutes = Convert.ToInt32(movieMinutes.Text);
                }
                if (movieSeconds.Text.Length == 0)
                {
                    seconds = 0;
                }
                else
                {
                    seconds = Convert.ToInt32(movieSeconds.Text);
                }
                editMovie(movieID, movieName.Text, movieDescription.Text, startingCalendar.SelectedDate, endingCalendar.SelectedDate, hours, minutes, seconds);
                MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                {
                    parentWindow = window as MainApp;
                }
                parentWindow?.ContentPanel.Children.Clear();
                Movies movies = new Movies();
                parentWindow?.ContentPanel.Children.Add(movies);
            }
        }
        private void movieHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void movieHours_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void movieMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void movieMinutes_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void movieSeconds_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void movieSeconds_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
    }
}
