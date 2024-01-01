using CinemaSchedule.Models;
using CinemaSchedule.UserControls;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CinemaSchedule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int userID = -1;

        public static List<User> users = new();

    }

}
