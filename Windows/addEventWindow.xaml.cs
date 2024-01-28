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
    /// Interaction logic for addEventWindow.xaml
    /// </summary>
    public partial class addEventWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public int getMovieID(string input)
        {
            int number = 0;
            int startIndex = input.IndexOf(':') + 1;
            int endIndex = input.IndexOf(';'); 
            int length = endIndex - startIndex; 
            string numberString = input.Substring(startIndex, length).Trim(); 
            if (int.TryParse(numberString, out number))
            {
                return number;
            }
            else
            {
                return number;
            }
        }
        private bool eventValidation(int hours, int minutes, int seconds, int duration, ref string errorMsg)
        {
            int errorCount = 0;
            if(hours > 24)
            {
                errorCount++;
                errorMsg += "Часы не могут быть больше 24!\n";
            }
            if (minutes >= 60)
            {
                errorCount++;
                errorMsg += "Минуты не могут быть больше 59!\n";
            }
            if (seconds >= 60)
            {
                errorCount++;
                errorMsg += "Секунды не могут быть больше 59!\n";
            }
            if((hours*3600 + minutes*60 + seconds) >= 86400)
            {
                errorCount++;
                errorMsg += "Событие должно начинаться в пределах 24 часов\n";
            }
            if ((hours * 3600 + minutes * 60 + seconds + duration) >= 86400)
            {
                errorCount++;
                errorMsg += "Событие должно заканчиваться в пределах 24 часов\n";
            }
            if ((hours * 3600 + minutes * 60 + seconds) == 0)
            {
                errorCount++;
                errorMsg += "Событие должно начинаться хотя бы в одну секунду\n";
            }
            if (duration == 0)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать длительность события\n";
            }
            if (typeComboBox.SelectedIndex < 0)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать тип события";
            }
            if (typeComboBox.SelectedIndex == 0 && movieComboBox.SelectedIndex < 0)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать фильм для данного типа события";
            }

            if (errorCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void inputsFixer()
        {
            if (String.IsNullOrEmpty(eventHours.Text))
            {
                eventHours.Text = "0";
            }
            if (String.IsNullOrEmpty(eventMinutes.Text))
            {
                eventMinutes.Text = "0";
            }
            if (String.IsNullOrEmpty(eventSeconds.Text))
            {
                eventSeconds.Text = "0";
            }
            if (String.IsNullOrEmpty(movieHours.Text))
            {
                movieHours.Text = "0";
            }
            if (String.IsNullOrEmpty(movieMinutes.Text))
            {
                movieMinutes.Text = "0";
            }
            if (String.IsNullOrEmpty(movieSeconds.Text))
            {
                movieSeconds.Text = "0";
            }
        }
        private void addEventHandler(int hours, int minutes, int seconds, int duration)
        {
            string errorMsg = "";
            int errorCount = 0;
            if (typeComboBox.SelectedIndex < 0)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать тип события";
            }
            if(typeComboBox.SelectedIndex==0 && movieComboBox.SelectedIndex < 0)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать фильм для данного типа события";
            }
            if(errorCount > 0)
            {
                showErrorMessage(errorMsg);
            }
            else
            {

            }
        }
        private void addEvent(int? movieID, DateTime? beginning, string eventName, int hours, int minutes, int seconds, int duration,int hallID, int cinemaID, string eventType)
        {
            DateTime beginning2 = Convert.ToDateTime(beginning.Value);
            string errorMsg = "";
            if(eventValidation(hours, minutes, seconds, duration, ref errorMsg))
            {
                int errorCounter = 0;
                List<Event> events = DatabaseQueries.populateEvents(App.userID, date, hallID);
                foreach(Event ev in events)
                {
                    if(ev.startingDate <= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).AddSeconds(duration))
                    {
                        errorCounter++;
                        errorMsg += "Новое событие накладывается на уже существующее\n";
                        break;
                    }
                    else if(ev.startingDate <= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds))
                    {
                        errorCounter++;
                        errorMsg += "Новое событие накладывается на уже существующее\n";
                        break;
                    }
                    else if(ev.startingDate <= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds) && ev.startingDate >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).AddSeconds(duration))
                    {
                        errorCounter++;
                        errorMsg += "Новое событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).AddSeconds(duration) && ev.startingDate <= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).AddSeconds(duration))
                    {
                        errorCounter++;
                        errorMsg += "Новое событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate >= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds) && ev.startingDate.AddSeconds(ev.duration) <= beginning2.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds).AddSeconds(duration))
                    {
                        errorCounter++;
                        errorMsg += "Новое событие накладывается на уже существующее\n";
                        break;
                    }
                }
                if(errorCounter > 0)
                {
                    showErrorMessage(errorMsg);
                }
                else
                {
                    DatabaseQueries.createEvent(movieID, beginning, eventName, hours, minutes, seconds, duration, hallID, cinemaID, eventType);
                    MessageBox.Show("Событие успешно добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                    foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                    {
                        parentWindow = window as MainApp;
                    }
                    parentWindow?.ContentPanel.Children.Clear();
                    Schedule schedule = new Schedule(hallID, beginning2);
                    parentWindow?.ContentPanel.Children.Add(schedule);
                }
            }
            else
            {
                showErrorMessage(errorMsg);
            }
        }
        public addEventWindow(DateTime? date, int hallID)
        {
            InitializeComponent();
            this.date = date;
            List<String> types = DatabaseQueries.populateTypes();
            foreach (String type in types)
            {
                typeComboBox.Items.Add(type);
            }
            List<Movie> movies = DatabaseQueries.populateMoviesForEvent(App.userID, date);
            foreach (Movie movie in movies)
            {
                movieComboBox.Items.Add("ID: " + movie.movieID + "; Название: " + movie.movieName);
            }

            this.hallID = hallID;
        }
        private DateTime? date;
        private int hallID = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (typeComboBox.SelectedValue.ToString() == "Фильм")
            {
                if(movieComboBox.SelectedIndex < 0) 
                {
                    showErrorMessage("Необходимо выбрать фильм");
                }
                else
                {
                    inputsFixer();
                    addEvent(getMovieID(movieComboBox.SelectedValue.ToString()), date, DatabaseQueries.getMovieName(getMovieID(movieComboBox.SelectedValue.ToString())), Convert.ToInt32(movieHours.Text), Convert.ToInt32(movieMinutes.Text), Convert.ToInt32(movieSeconds.Text), DatabaseQueries.getMovieDuration(getMovieID(movieComboBox.SelectedValue.ToString())), hallID, DatabaseQueries.getCinemaID(App.userID), typeComboBox.SelectedValue.ToString());
                }
            }
            else
            {
                if(string.IsNullOrEmpty(eventName.Text))
                {
                    showErrorMessage("Необходимо указать название события!");
                }
                else
                {
                    inputsFixer();
                    int errorCounter = 0;
                    string errorMsg = "";
                    if(Convert.ToInt32(eventHours.Text) > 8) 
                    {
                        errorCounter++;
                        errorMsg += "Часы события не должны превышать 7 часов\n";
                    }
                    if (Convert.ToInt32(eventMinutes.Text) >= 60)
                    {
                        errorCounter++;
                        errorMsg += "Минуты события не могут превышать 59\n";
                    }
                    if (Convert.ToInt32(eventSeconds.Text) >= 60)
                    {
                        errorCounter++;
                        errorMsg += "Секунды события не могут превышать 59\n";
                    }
                    if(errorCounter == 0)
                    {
                        addEvent(null, date, eventName.Text, Convert.ToInt32(movieHours.Text), Convert.ToInt32(movieMinutes.Text), Convert.ToInt32(movieSeconds.Text), Convert.ToInt32(eventHours.Text) * 3600 + Convert.ToInt32(eventMinutes.Text) * 60 + Convert.ToInt32(eventSeconds.Text), hallID, DatabaseQueries.getCinemaID(App.userID), typeComboBox.SelectedValue.ToString());
                    }
                    else
                    {
                        showErrorMessage(errorMsg);
                    }
                    
                } 
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

        private void eventDuration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void eventDuration_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste) { e.Handled = true; }
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(typeComboBox.SelectedValue.ToString() == "Фильм")
            {
                movieComboBox.Visibility = Visibility.Visible;
                movieLabel.Visibility = Visibility.Visible;
                eventDurationLabel.Visibility = Visibility.Hidden;
                eventHours.Visibility = Visibility.Hidden;
                eventMinutes.Visibility = Visibility.Hidden;
                eventSeconds.Visibility = Visibility.Hidden;
                hoursLabel.Visibility = Visibility.Hidden;
                minutesLabel.Visibility = Visibility.Hidden;
                secondsLabel.Visibility = Visibility.Hidden;
                eventName.Visibility = Visibility.Hidden;
                eventNameLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                movieComboBox.Visibility = Visibility.Hidden;
                movieLabel.Visibility = Visibility.Hidden;
                eventDurationLabel.Visibility = Visibility.Visible;
                eventHours.Visibility= Visibility.Visible;
                eventMinutes.Visibility = Visibility.Visible;
                eventSeconds.Visibility = Visibility.Visible;
                hoursLabel.Visibility = Visibility.Visible;
                minutesLabel.Visibility = Visibility.Visible;
                secondsLabel.Visibility = Visibility.Visible;
                eventNameLabel.Visibility= Visibility.Visible;
                eventName.Visibility= Visibility.Visible;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
