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
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : UserControl
    {
        public void refreshNotes(int userID)
        {
            notesList.Items.Clear();
            List<Note> notes = DatabaseQueries.populateNotes(userID);
            foreach (Note note in notes)
            {
                notesList.Items.Add(new NotesControl(note.noteID, note.noteName));
            }
        }
        public Notes()
        {
            InitializeComponent();
            refreshNotes(App.userID); 
        }

        private void addHallButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.addNoteWindow addNoteWindow = new Windows.addNoteWindow();
            addNoteWindow.ShowDialog();
            refreshNotes(App.userID);
        }
    }
}
