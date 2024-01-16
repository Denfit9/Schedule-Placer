using CinemaSchedule.Models;
using CinemaSchedule.MySQLServices;
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
    /// Interaction logic for addEventsAutoWindow.xaml
    /// </summary>
    public partial class addEventsAutoWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public addEventsAutoWindow(DateTime? date, int hallID, List<Movie> movies)
        {
            InitializeComponent();
            this.date = date;
            this.hallID = hallID;
            this.movies = movies;
        }
        private DateTime? date { get; set; }
        private int hallID { get; set; }
        private List<Movie> movies { get; set; }

        private void addMovie(int movieID, DateTime? beginning, string eventName, int seconds, int duration, int hallID, int cinemaID)
        {
            DatabaseQueries.createEventSeconds(movieID, beginning, eventName, seconds, duration, hallID, cinemaID, "Фильм");
        }

        private void addBreak(DateTime? beginning, string eventName, int seconds, int duration, int hallID, int cinemaID)
        {
            DatabaseQueries.createEventSeconds(null, beginning, eventName, seconds, duration, hallID, cinemaID, "Перерыв");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int hoursBeginInt = 0;
            int minutesBeginInt = 0;
            int hoursEndInt= 0;
            int minutesEndInt = 0;
            int secondsBeginInt = 0;
            int secondsEndInt = 0;
            int secondsBreakInt = 0;
            if (hoursBegin.Text.Length == 0)
            {
                hoursBeginInt = 0;
            }
            else
            {
                hoursBeginInt = Convert.ToInt32(hoursBegin.Text);
            }
            if (minutesBegin.Text.Length == 0)
            {
                minutesBeginInt = 0;
            }
            else
            {
                minutesBeginInt = Convert.ToInt32(minutesBegin.Text);
            }
            if (hoursEnd.Text.Length == 0)
            {
                hoursEndInt = 0;
            }
            else
            {
                hoursEndInt = Convert.ToInt32(hoursEnd.Text);
            }
            if (minutesEnd.Text.Length == 0)
            {
                minutesEndInt = 0;
            }
            else
            {
                minutesEndInt = Convert.ToInt32(minutesEnd.Text);
            }
            if(secondsBreak.Text.Length == 0)
            {
                secondsBreakInt = 0;
            }
            else
            {
                secondsBreakInt = Convert.ToInt32(secondsBreak.Text);
            }
            if(hoursBeginInt >= 25 || hoursEndInt >=25)
            {
                showErrorMessage("Часы не должны превышать 24");
            }
            else if (minutesBeginInt >= 61 || minutesEndInt >= 61)
            {
                showErrorMessage("Минуты не должны превышать 60");
            }
            else if ((hoursBeginInt*3600 + minutesEndInt * 60) >= 72000)
            {
                showErrorMessage("Время открытия не должно превышать 20 часов");
            }
            else if ((hoursEndInt * 3600 + minutesEndInt * 60) >= 86400)
            {
                showErrorMessage("Время закрытия не должно превышать 24 часов");
            }
            else if((hoursBeginInt * 3600 + minutesBeginInt * 60) >= (hoursEndInt * 3600 + minutesEndInt * 60))
            {
                showErrorMessage("Время открытия должно быть меньше времени закрытия");
            }
            else
            {
                List<Event> events = DatabaseQueries.populateEventsList(App.userID, date, hallID);
                foreach(Event ev in events)
                {
                    DatabaseQueries.deleteEvent(ev.eventId);
                }
                secondsBeginInt = hoursBeginInt * 3600 + minutesEndInt * 60;
                secondsEndInt = hoursEndInt * 3600 + minutesEndInt * 60;
                int minimumMovieDuration = 100000;
                foreach(Movie mov in movies)
                {
                    if(mov.duration < minimumMovieDuration)
                    {
                        minimumMovieDuration = mov.duration;
                    }
                }
                int turn = 1;
                bool simulating = true;
                while(simulating)
                {
                    if (turn % 2 == 0)
                    {
                        if (secondsEndInt - secondsBeginInt < 1201)
                        {
                            simulating = false;
                        }
                        else
                        {
                            if (secondsBreakInt == 0)
                            {

                            }
                            else
                            {
                                addBreak(date.Value, "Перерыв", secondsBeginInt, secondsBreakInt, hallID, DatabaseQueries.getCinemaID(App.userID));
                                secondsBeginInt += secondsBreakInt;
                            }
                            turn++;
                        }
                    }
                    else
                    {
                        if(secondsEndInt -  secondsBeginInt < minimumMovieDuration)
                        {
                            simulating = false;
                        }
                        else
                        {
                            Random random = new Random();
                            int r = random.Next(movies.Count);
                            if(secondsEndInt <= secondsBeginInt + movies[r].duration)
                            {
                                foreach(Movie movie in movies)
                                {
                                    if(movie.duration == minimumMovieDuration)
                                    {
                                        addMovie(movie.movieID, date.Value, movie.movieName, secondsBeginInt, movie.duration, hallID, DatabaseQueries.getCinemaID(App.userID));
                                        secondsBeginInt += movie.duration;
                                        turn++;
                                    }
                                }
                            }
                            else
                            {
                                addMovie(movies[r].movieID, date.Value, movies[r].movieName, secondsBeginInt, movies[r].duration, hallID, DatabaseQueries.getCinemaID(App.userID));
                                secondsBeginInt += movies[r].duration;
                                turn++;
                            }
                        }
                    }

                }
                MessageBox.Show("События успешно добавлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                {
                    parentWindow = window as MainApp;
                }
                parentWindow?.ContentPanel.Children.Clear();
                Schedule schedule = new Schedule();
                parentWindow?.ContentPanel.Children.Add(schedule);
            }
        }

        private void hoursBegin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void hoursBegin_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void minutesBegin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void minutesBegin_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void hoursEnd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void hoursEnd_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void minutesEnd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void minutesEnd_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
