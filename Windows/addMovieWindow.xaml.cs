﻿using CinemaSchedule.MySQLServices;
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
using System.Windows.Shapes;

namespace CinemaSchedule.Windows
{
    /// <summary>
    /// Interaction logic for addMovieWindow.xaml
    /// </summary>
    public partial class addMovieWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool movieValidation(string name, string description, DateTime? fromDate, DateTime? toDate, ref string errorMsg)
        {
            int errorCount = 0;
            if(string.IsNullOrEmpty(name))
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
            if (australiaCheckBox.IsChecked==true)
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
        private void addMovie(string movieName, string movieDescription, DateTime? fromDate, DateTime? toDate)
        {
            string errorMsg = "";
            if (movieValidation(movieName, movieDescription, fromDate, toDate, ref errorMsg) == false)
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                List<String> countriesReceived = GetCountries();
                List<String> genresReceived = GetGenres();
                DatabaseQueries.createMovie(movieName, movieDescription, fromDate, toDate, countriesReceived, genresReceived);
                MessageBox.Show("Фильм успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
        }
        public addMovieWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addMovie(movieName.Text, movieDescription.Text, startingCalendar.SelectedDate, endingCalendar.SelectedDate);
        }
    }
}
