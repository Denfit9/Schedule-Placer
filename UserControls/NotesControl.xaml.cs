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
    /// Interaction logic for NotesControl.xaml
    /// </summary>
    public partial class NotesControl : UserControl
    {
        public void askMessageConfirm(int noteID)
        {
            MessageBoxResult result = MessageBox.Show("Удалить данную заметку?", "Вы уверены?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DatabaseQueries.deleteNote(noteID);

                    MessageBox.Show("Удалено!", "Успешно");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        public NotesControl()
        {
            InitializeComponent();
        }
        public NotesControl(int noteID, string noteName)
        {
            InitializeComponent();
            this.noteDescription.Text = noteName;
            this.noteID.Content = noteID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askMessageConfirm(Convert.ToInt32(noteID.Content.ToString()));
            MainApp? parentWindow = Window.GetWindow(this) as MainApp;
            parentWindow?.ContentPanel.Children.Clear();
            Notes notes = new Notes();
            parentWindow?.ContentPanel.Children.Add(notes);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Windows.editNoteWindow editNoteWindow = new Windows.editNoteWindow(Convert.ToInt32(noteID.Content.ToString()), noteDescription.Text);
            editNoteWindow.ShowDialog();
        }
    }
}
