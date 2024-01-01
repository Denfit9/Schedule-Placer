using CinemaSchedule.MySQLServices;
using CinemaSchedule.UserControls;
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
    /// Interaction logic for editHallWindow.xaml
    /// </summary>
    public partial class editHallWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool editHallValidation(string hallName, string hallDescription)
        {
            if (string.IsNullOrWhiteSpace(hallName) || string.IsNullOrWhiteSpace(hallDescription))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void editHall(int hallID, string hallName, string hallDescription)
        {
            DatabaseQueries.updateHall(hallID ,hallName, hallDescription);
            MessageBox.Show("Зал изменён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public editHallWindow(int hallID, string hallName, string hallDescription)
        {
            InitializeComponent();
            this.hallID = hallID;
            this.hallName.Text = hallName;
            this.hallDescription.Text = hallDescription;
        }
        private int hallID = 0; 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (editHallValidation(hallName.Text, hallDescription.Text))
            {
                editHall(hallID, hallName.Text, hallDescription.Text);
                MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                foreach(Window window in Application.Current.Windows.OfType<MainApp>())
                {
                    parentWindow = window as MainApp;
                }
                parentWindow?.ContentPanel.Children.Clear();
                MyCinema myCinema = new MyCinema();
                parentWindow?.ContentPanel.Children.Add(myCinema);
                this.DialogResult = true;
            }
            else
            {
                showErrorMessage("Не удалось изменить зал с такими данными");
            }
        }
    }
}
