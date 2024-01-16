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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaSchedule.UserControls
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {

        private void refreshEvents(DateTime date, int hallID)
        {
            List <Event> events= DatabaseQueries.populateEventsList(App.userID, date, hallID);
            eventsList.Items.Clear();
            foreach (Event ev in events)
            {
                eventsList.Items.Add(new EventControl(ev.eventId, ev.startingDate, ev.eventName, ev.duration, ev.hallID, ev.eventType));
            }
        }
        public int getHallID(string input)
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
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public Schedule()
        {
            InitializeComponent();
            List<Hall> halls = DatabaseQueries.populateHalls(App.userID);
            foreach (Hall hall in halls)
            {
                hallsComboBox.Items.Add("ID: " + hall.hallID + "; Имя: " + hall.hallName);
            }
        }

        private void showEventsButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            string errorMsg = "";
            if(hallsComboBox.SelectedIndex == -1)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать зал!\n";
            }
            if(dateCalendar.SelectedDate == null)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать дату!\n";
            }
            if(errorCount > 0)
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                refreshEvents(Convert.ToDateTime(dateCalendar.SelectedDate), getHallID(hallsComboBox.SelectedValue.ToString()));
            }
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            string errorMsg = "";
            if (hallsComboBox.SelectedIndex == -1)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать зал!\n";
            }
            if (dateCalendar.SelectedDate == null)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать дату!\n";
            }
            if (errorCount > 0)
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                Windows.addEventWindow addEventWindow = new Windows.addEventWindow(dateCalendar.SelectedDate, getHallID(hallsComboBox.SelectedValue.ToString()));
                addEventWindow.ShowDialog();
            }
        }

        private void addEventsAutoButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            string errorMsg = "";
            if (hallsComboBox.SelectedIndex == -1)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать зал!\n";
            }
            if (dateCalendar.SelectedDate == null)
            {
                errorCount++;
                errorMsg += "Необходимо выбрать дату!\n";
            }
            if (errorCount > 0)
            {
                showErrorMessage(errorMsg);
            }
            else
            {
                List<Movie> movies = DatabaseQueries.populateMoviesForEvent(App.userID, dateCalendar.SelectedDate);
                if (movies.Count == 0)
                {
                    showErrorMessage("Фильмов для этой даты нет.\nСоставить расписание для этой даты невозможно!");
                }
                else
                {
                    Windows.addEventsAutoWindow addEventWindow = new Windows.addEventsAutoWindow(dateCalendar.SelectedDate, getHallID(hallsComboBox.SelectedValue.ToString()), movies);
                    addEventWindow.ShowDialog();
                }
            }
        }
    }
}
