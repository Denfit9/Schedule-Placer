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
    /// Interaction logic for HallsControl.xaml
    /// </summary>
    public partial class HallsControl : UserControl
    {
        public void askMessageConfirm(int hallID)
        {
            MessageBoxResult result = MessageBox.Show("Удалить данный зал?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DatabaseQueries.deleteHall(hallID);

                    MessageBox.Show("Удалено!", "Успешно");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        public HallsControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public HallsControl(int hallID, string hallName, string hallDescritption)
        {
            InitializeComponent();
            this.hallName.Content = hallName;
            this.hallID.Content = hallID;
            this.hallDescription.Text = hallDescritption;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askMessageConfirm(Convert.ToInt32(hallID.Content.ToString()));
            MainApp? parentWindow = Window.GetWindow(this) as MainApp;
            parentWindow?.ContentPanel.Children.Clear();
            MyCinema myCinema = new MyCinema();
            parentWindow?.ContentPanel.Children.Add(myCinema);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.editHallWindow addHallWindow = new Windows.editHallWindow(Convert.ToInt32(hallID.Content.ToString()), hallName.Content.ToString(), hallDescription.Text);
            addHallWindow.ShowDialog();
        }
    }
}
