using CinemaSchedule.Models;
using CinemaSchedule.MySQLServices;
using CinemaSchedule.UserControls;
using Microsoft.Extensions.Logging;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaSchedule.Windows
{
    /// <summary>
    /// Interaction logic for MoveEventWindow.xaml
    /// </summary>
    public partial class MoveEventWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public MoveEventWindow()
        {
            InitializeComponent();
        }
        private bool eventValidation(int hours, int minutes, int seconds, int duration, ref string errorMsg)
        {
            int errorCount = 0;
            if (hours > 24)
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
            if ((hours * 3600 + minutes * 60 + seconds) >= 86400)
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
            if (errorCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public MoveEventWindow(int eventID, int hallID, DateTime date, DateTime dateExact)
        {
            InitializeComponent();
            hoursEvent.Text = dateExact.ToString("HH");
            minutesEvent.Text = dateExact.ToString("mm");
            secondsEvent.Text = dateExact.ToString("ss");
            List<Event> events = DatabaseQueries.populateEventsList(App.userID, date, hallID);
            eventsP = events;
            eventId = eventID;
            beginning2 = date;
            hallIDP = hallID;
        }
        private int eventId = 0;
        private List<Event> eventsP;
        private DateTime beginning2;
        private int hallIDP = 0;
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int hoursInt = 0;
            int minutesInt = 0;
            int secondsInt = 0;
            string errorMsg = "";
            if (hoursEvent.Text.Length == 0)
            {
                hoursInt = 0;
            }
            else
            {
                hoursInt = Convert.ToInt32(hoursEvent.Text);
            }
            if (minutesEvent.Text.Length == 0)
            {
                minutesInt = 0;
            }
            else
            {
                minutesInt = Convert.ToInt32(minutesEvent.Text);
            }
            if (secondsEvent.Text.Length == 0)
            {
                secondsInt = 0;
            }
            else
            {
                secondsInt = Convert.ToInt32(secondsEvent.Text);
            }
            if(!eventValidation(hoursInt, minutesInt, secondsInt, DatabaseQueries.getEventDuration(eventId), ref errorMsg)) 
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                int errorCounter = 0;
                errorMsg = "";
                int counter = 0;
                bool remove = false;
                foreach (Event ev in eventsP){
                    if(ev.eventId == eventId)
                    {
                        remove = true;
                        break;
                    }
                    counter++;
                }
                if (counter >=0 && remove == true)
                {
                    eventsP.RemoveAt(counter);
                }
                foreach (Event ev in eventsP)
                {
                    if (ev.startingDate <= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt).AddSeconds(DatabaseQueries.getEventDuration(eventId)))
                    {
                        errorCounter++;
                        errorMsg += "Событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate <= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt))
                    {
                        errorCounter++;
                        errorMsg += "Событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate <= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt) && ev.startingDate >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt).AddSeconds(DatabaseQueries.getEventDuration(eventId)))
                    {
                        errorCounter++;
                        errorMsg += "Событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt) && ev.startingDate.AddSeconds(ev.duration) >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt).AddSeconds(DatabaseQueries.getEventDuration(eventId)) && ev.startingDate <= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt).AddSeconds(DatabaseQueries.getEventDuration(eventId)))
                    {
                        errorCounter++;
                        errorMsg += "Событие накладывается на уже существующее\n";
                        break;
                    }
                    else if (ev.startingDate >= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt) && ev.startingDate.AddSeconds(ev.duration) <= beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt).AddSeconds(DatabaseQueries.getEventDuration(eventId)))
                    {
                        errorCounter++;
                        errorMsg += "Событие накладывается на уже существующее\n";
                        break;
                    }
                }
                if (errorCounter > 0)
                {
                    showErrorMessage(errorMsg);
                }
                else
                {
                    DatabaseQueries.updateEvent(eventId, beginning2.AddHours(hoursInt).AddMinutes(minutesInt).AddSeconds(secondsInt));
                    MessageBox.Show("Событие успешно обновлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                    foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                    {
                        parentWindow = window as MainApp;
                    }
                    parentWindow?.ContentPanel.Children.Clear();
                    Schedule schedule = new Schedule(hallIDP, beginning2);
                    parentWindow?.ContentPanel.Children.Add(schedule);
                }
            }
        }
    }
}
