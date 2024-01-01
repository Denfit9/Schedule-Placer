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
using System.Windows.Shapes;

namespace CinemaSchedule
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public MainApp()
        {
            InitializeComponent();
            
            NSP.Content = DatabaseQueries.getNSP(App.userID);
            //cinemaNameLabel.Content = "Кинотеатр  " + DatabaseQueries.getCinemaName(App.userID);
           // description.Text = DatabaseQueries.getCinemaDescription(App.userID);
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(description.Text.Length > 0)
            {
                DatabaseQueries.updateCinemaDescription(App.userID, description.Text.ToString());
                MessageBox.Show("Описание обновлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                description.Text = DatabaseQueries.getCinemaDescription(App.userID);
            }
            else
            {
                showErrorMessage("Описание пустое");
            }

        }
        */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выход совершён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentPanel.Children.Clear();
            UserControls.MyCinema myCinema = new UserControls.MyCinema();
            ContentPanel.Children.Add(myCinema);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentPanel.Children.Clear();
            UserControls.Notes notes = new UserControls.Notes();
            ContentPanel.Children.Add(notes);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ContentPanel.Children.Clear();
            UserControls.Movies movies = new UserControls.Movies();
            ContentPanel.Children.Add(movies);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ContentPanel.Children.Clear();
            UserControls.Schedule schedule = new UserControls.Schedule();
            ContentPanel.Children.Add(schedule);
        }
    }
}
