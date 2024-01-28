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
            string hours = "";
            string minutes = "";
            string seconds = "";
            if(duration / 3600 > 0)
            {
                if(duration / 3600 == 1)
                {
                    hours = Convert.ToString(duration / 3600) + " чаc ";
                }
                else if(duration / 3600 <= 4) 
                {
                    hours = Convert.ToString(duration / 3600) + " часа ";
                }
                else
                {
                    hours = Convert.ToString(duration / 3600) + " часов ";
                }
                
            }
            if ((duration - (duration / 3600) * 3600) / 60 > 0)
            {
                if (((duration - (duration / 3600) * 3600) / 60) % 10 == 4)
                {
                    minutes = Convert.ToString((duration - (duration / 3600) * 3600) / 60) + " минута ";
                }
                else if (((duration - (duration / 3600) * 3600) / 60) % 10 <= 4 && ((duration - (duration / 3600) * 3600) / 60) % 10 !=0)
                {
                    minutes = Convert.ToString((duration - (duration / 3600) * 3600) / 60) + " минуты ";
                }
                else
                {
                    minutes = Convert.ToString((duration - (duration / 3600) * 3600) / 60) + " минут ";
                }
                
            }
            if ( duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60 > 0)
            {
                if((duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60) % 10 == 1)
                {
                    seconds = Convert.ToString((duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60)) + " секунда ";
                }
                else if((duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60) % 10 <= 4 && (duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60) != 0)
                {
                    seconds = Convert.ToString((duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60)) + " секунды ";
                }
                else
                {
                    seconds = Convert.ToString((duration - ((duration / 3600) * 3600) - ((duration - (duration / 3600) * 3600) / 60) * 60)) + " секунд ";
                }
                
            }
            this.eventName.Content = eventName.ToString();
            this.eventID.Content = eventID.ToString();
            this.beginsAtText.Content = dateBegin.ToString("dd-MM-yyyy HH:mm:ss");
            this.eventDuration.Content = hours + minutes + seconds;
            this.eventHall.Content = DatabaseQueries.getHallName(hallID).ToString();
            hallIDP = hallID;
            date =Convert.ToDateTime(dateBegin.ToString("dd-MM-yyyy"));
            this.endsAtText.Content = dateBegin.AddSeconds(duration).ToString("dd-MM-yyyy HH:mm:ss");
            this.eventType.Content = type;
        }
        private int hallIDP = 0;
        private DateTime date;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askMessageConfirm(Convert.ToInt32(eventID.Content));
            MainApp? parentWindow = Window.GetWindow(this) as MainApp;
            parentWindow?.ContentPanel.Children.Clear();
            Schedule schedule = new Schedule(hallIDP, date);
            parentWindow?.ContentPanel.Children.Add(schedule);
        }
    }
}
