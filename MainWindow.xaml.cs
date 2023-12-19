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
            //User user1 = new User(1, "anon", "anonymous", "anon@gmail.com", "12345");
            //App.users.Add(user1);

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

                }
            }

            /*User usr = App.users.FirstOrDefault(us => us.email == email_text.Text && us.password == password_text.Password.ToString());
            if (usr != null)
            {
                email_text.Text = usr.userID.ToString();
                password_text.Password = "";
            }
            else
            {
                showErrorMessage("Пользователя не существует");
            }*/
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Signin.Content = new RegistrationUser();
        }
    }
}