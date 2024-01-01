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
    /// Interaction logic for addNoteWindow.xaml
    /// </summary>
    public partial class addNoteWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool addNoteValidation(string noteName)
        {
            if (string.IsNullOrWhiteSpace(noteName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void addNote(string noteName)
        {
            DatabaseQueries.createNote(noteName, App.userID);
            MessageBox.Show("Заметка добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public addNoteWindow()
        {
            InitializeComponent();
        }

        public string NoteName
        {
            get { return noteNameTextBox.Text; }
            set { noteNameTextBox.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (addNoteValidation(NoteName))
            {
                addNote(NoteName);
                this.DialogResult = true;
            }
            else
            {
                showErrorMessage("Не удалось создать заметку с такими данными");
            }
        }
    }
}
