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

namespace CinemaSchedule.Windows
{
    /// <summary>
    /// Interaction logic for addHallWindow.xaml
    /// </summary>
    public partial class addHallWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool addHallValidation(string hallName, string hallDescription)
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

        public void addHall(string hallName, string hallDescription)
        {
            DatabaseQueries.createHall(hallName, hallDescription, App.userID);
            MessageBox.Show("Зал добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public addHallWindow()
        {
            InitializeComponent();
        }
      
        public string HallName
        {
            get { return hallName.Text; }
            set { hallName.Text = value;}
        }
        public string HallDescription
        {
            get { return hallDescription.Text; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(addHallValidation(HallName, HallDescription)) 
            {
                addHall(HallName, HallDescription);
                this.DialogResult = true;
            }
            else
            {
                showErrorMessage("Не удалось создать зал с такими данными");
            }
        }
    }
}
