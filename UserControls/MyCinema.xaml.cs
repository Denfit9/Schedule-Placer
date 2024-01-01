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

namespace CinemaSchedule.UserControls
{
    /// <summary>
    /// Interaction logic for MyCinema.xaml
    /// </summary>
    public partial class MyCinema : UserControl
    {
        public void refreshHalls(int userID)
        {
            hallsList.Items.Clear();
            List<Hall> halls = DatabaseQueries.populateHalls(userID);
            foreach (Hall hall in halls)
            {
                hallsList.Items.Add(new HallsControl(hall.hallID, hall.hallName, hall.hallDescription));
            }
        }
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool descriptionValidation(string message)
        {
            if (message == null || message.Length == 0) { return false; }
            else { return true; }
        }

        public void updateDescription(string message, int userID)
        {
            DatabaseQueries.updateCinemaDescription(userID, message);
        }
        public MyCinema()
        {
            InitializeComponent();
            refreshHalls(App.userID);
            cinemaNameLabel.Content = "Кинотеатр  " + DatabaseQueries.getCinemaName(App.userID);
            descriptionLabel.Text = DatabaseQueries.getCinemaDescription(App.userID);    
        }

        private void editDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            saveDescriptionButton.Visibility = Visibility.Visible;
            declineDescriptionButton.Visibility = Visibility.Visible;
            editDescriptionButton.Visibility = Visibility.Hidden;
            descriptionTextBox.Visibility = Visibility.Visible;
            descriptionLabel.Visibility = Visibility.Hidden;
            descriptionTextBox.Text = DatabaseQueries.getCinemaDescription(App.userID);
        }

        private void saveDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            if(descriptionValidation(descriptionTextBox.Text))
            {
                saveDescriptionButton.Visibility = Visibility.Hidden;
                declineDescriptionButton.Visibility = Visibility.Hidden;
                updateDescription(descriptionTextBox.Text, App.userID);
                descriptionTextBox.Visibility = Visibility.Hidden;
                descriptionLabel.Visibility = Visibility.Visible;
                editDescriptionButton.Visibility = Visibility.Visible;
                MessageBox.Show("Описание обновлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                descriptionLabel.Text = DatabaseQueries.getCinemaDescription(App.userID);
            }
            else
            {
                showErrorMessage("Описание некорректно!");
            }
            
        }
        public ListView HallsList
        {
            get { return hallsList; }
        }
        private void declineDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            saveDescriptionButton.Visibility = Visibility.Hidden;
            declineDescriptionButton.Visibility = Visibility.Hidden;
            editDescriptionButton.Visibility = Visibility.Visible;
            descriptionTextBox.Visibility = Visibility.Hidden;
            descriptionLabel.Visibility = Visibility.Visible;
        }

        private void addHallButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.addHallWindow addHallWindow = new Windows.addHallWindow();
            addHallWindow.ShowDialog();
            refreshHalls(App.userID);
        }
    }
}
