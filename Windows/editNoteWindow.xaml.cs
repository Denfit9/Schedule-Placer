using CinemaSchedule.Models;
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
    /// Interaction logic for editNoteWindow.xaml
    /// </summary>
    public partial class editNoteWindow : Window
    {
        public void showErrorMessage(string errorContent)
        {
            MessageBox.Show(errorContent, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool editNoteValidation(string noteName)
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

        public void editNote(int noteID, string noteName)
        {
            DatabaseQueries.updateNote(noteID, noteName);
            MessageBox.Show("Заметка изменена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public editNoteWindow(int hallID, string noteName)
        {
            InitializeComponent();
            this.noteID = hallID;
            this.noteNameTextBox.Text = noteName;
        }
        private int noteID = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (editNoteValidation(noteNameTextBox.Text))
            {
                editNote(noteID, noteNameTextBox.Text);
                MainApp? parentWindow = Window.GetWindow(this) as MainApp;
                foreach (Window window in Application.Current.Windows.OfType<MainApp>())
                {
                    parentWindow = window as MainApp;
                }
                parentWindow?.ContentPanel.Children.Clear();
                Notes notes = new Notes();
                parentWindow?.ContentPanel.Children.Add(notes);
                this.DialogResult = true;
            }
            else
            {
                showErrorMessage("Не удалось изменить заметку с такими данными");
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
