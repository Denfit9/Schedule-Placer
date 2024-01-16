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
    /// Interaction logic for editCinemaName.xaml
    /// </summary>
    public partial class editCinemaNameWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public editCinemaNameWindow()
        {
            InitializeComponent();
            cinemaName.Text = DatabaseQueries.getCinemaName(App.userID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(cinemaName.Text))
            {
                showErrorMessage("Необходимо ввести название!");
            }
            else
            {
                DatabaseQueries.updateCinemaName(DatabaseQueries.getCinemaID(App.userID), cinemaName.Text);
                this.DialogResult = true;
                MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                {
                    parentWindow = window as MainApp;
                }
                parentWindow?.ContentPanel.Children.Clear();
                MyCinema cinema = new MyCinema();
                parentWindow?.ContentPanel.Children.Add(cinema);
            }
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
