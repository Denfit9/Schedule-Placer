using CinemaSchedule.MySQLServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace CinemaSchedule
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool validateUser(string name, string surname, string patronymic, string email, string password, string passwordRepeat, string cinemaName, ref string errorMsg)
        {
            int errorCount = 0;
            string rusOnlyPattern = @"^[а-яА-Я]+$";
            string rusAndNumsOnlyPattern = @"^[а-яА-Я0-9]+$";

            if (name.Length == 0 || name.Length < 2)
            {
                errorCount++;
                errorMsg += "Поле имени пустое или содержит слишком мало символов\n";
            }
            else if (!Regex.IsMatch(name, rusOnlyPattern))
            {
                errorCount++;
                errorMsg += "Поле имя должно содержать только русские символы\n";
            }

            if (surname.Length == 0 || surname.Length < 2)
            {
                errorCount++;
                errorMsg += "Поле фамилии пустое или содержит слишком мало символов\n";
            }
            else if (!Regex.IsMatch(surname, rusOnlyPattern))
            {
                errorCount++;
                errorMsg += "Поле фамилии должно содержать только русские символы\n";
            }

            if (patronymic.Length == 0 || patronymic.Length < 2)
            {
                errorCount++;
                errorMsg += "Поле отчества пустое или содержит слишком мало символов\n";
            }
            else if (!Regex.IsMatch(patronymic, rusOnlyPattern))
            {
                errorCount++;
                errorMsg += "Поле отчества должно содержать только русские символы\n";
            }

            if (password.Length < 6)
            {
                errorCount++;
                errorMsg += "Пароль слишком короткий\n";
            }

            if (passwordRepeat.Length < 6)
            {
                errorCount++;
                errorMsg += "Повторный пароль слишком короткий\n";
            }

            if (password != passwordRepeat)
            {
                errorCount++;
                errorMsg += "Пароли не совпадают\n";
            }

            if (email.Length < 5)
            {
                errorCount++;
                errorMsg += "Почта слишком короткая\n";
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@gmail\.com$"))
            {
                errorCount++;
                errorMsg += "Почта невалидна или не является почтой gmail\n";
            }
            else if(DatabaseQueries.checkEmailExistence(email))
            {
                errorCount++;
                errorMsg += "Почта уже занята\n";

            }
            if (cinemaName.Length == 0 || cinemaName.Length < 2)
            {
                errorCount++;
                errorMsg += "Поле названия кинотеатра пустое или содержит слишком мало символов\n";
            }
            else if (!Regex.IsMatch(cinemaName, rusAndNumsOnlyPattern))
            {
                errorCount++;
                errorMsg += "Поле названия кинотеатра должно содержать только русские символы\n";
            }

            if (errorCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (validateUser(name_text.Text.ToString(), surname_text.Text.ToString(), patronymic_text.Text.ToString(), email_text.Text.ToString(), password_text.Password, password_repeat_text.Password, cinema_name_text.Text.ToString(), ref errorMsg))
            {
                DatabaseQueries.createUser(name_text.Text.ToString(), surname_text.Text.ToString(), patronymic_text.Text.ToString(), email_text.Text.ToString(), password_text.Password, cinema_name_text.Text.ToString());
                MessageBox.Show("Регистрация успешна\nТеперь совершите вход на странице входа", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow login = new MainWindow();
                login.Show();
                this.Close();
            }
            else
            {
                showErrorMessage(errorMsg);
            }
        }
    }
}
