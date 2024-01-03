using CinemaSchedule.MySQLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        public void askMessageConfirm(int eventID)
        {
            MessageBoxResult result = MessageBox.Show("Удалить данное событие?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DatabaseQueries.deleteEvent(eventID);

                    MessageBox.Show("Удалено!", "Успешно");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        public EventControl()
        {
            InitializeComponent();
        }

        public EventControl(int eventID, DateTime dateBegin, string eventName, int duration, int hallID, string type)
        {
            InitializeComponent();
            this.eventName.Content = eventName.ToString();
            this.eventID.Content = eventID.ToString();
            this.beginsAtText.Content = dateBegin.ToString("dd-MM-yyyy HH:mm:ss");
            this.eventDuration.Content = duration.ToString();
            this.eventHall.Content = DatabaseQueries.getHallName(hallID).ToString();
            this.endsAtText.Content = dateBegin.AddSeconds(duration).ToString("dd-MM-yyyy HH:mm:ss");
            this.eventType.Content = type;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askMessageConfirm(Convert.ToInt32(eventID.Content));
            MainApp? parentWindow = Window.GetWindow(this) as MainApp;
            parentWindow?.ContentPanel.Children.Clear();
            Schedule schedule = new Schedule();
            parentWindow?.ContentPanel.Children.Add(schedule);
        }
    }
}
