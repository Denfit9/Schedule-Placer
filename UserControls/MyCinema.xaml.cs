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
        public MyCinema()
        {
            InitializeComponent();
            cinemaNameLabel.Content = "Кинотеатр  " + DatabaseQueries.getCinemaName(App.userID);
        }
    }
}
