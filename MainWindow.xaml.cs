using CinemaSchedule.Models;
using CinemaSchedule.MySQLServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaSchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            int errorCount = 0;

            if(email_text.Text.Length == 0)
            {
                error += "Поле почты пусто\n";
                errorCount++;
            }
            if(password_text.Password.Length == 0)
            {
                error += "Поле пароля пусто\n";
                errorCount++;
            }



            if (errorCount != 0)
            {
                showErrorMessage(error);
            }
            else
            {
                if (!DatabaseQueries.checkUserExistence(email_text.Text.ToString(), password_text.Password))
                {
                    showErrorMessage("Пользователь с такими данными не найден!\nВозможно вы где-то ошиблись.");
                    password_text.Clear();
                }
                else
                {
                    MessageBox.Show("Вход успешен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.userID = DatabaseQueries.getUserID(email_text.Text.ToString());
                    MainApp main = new MainApp();
                    main.Show();
                    this.Close();
                }
            }

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}