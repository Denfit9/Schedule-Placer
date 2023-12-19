using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.MySQLServices
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "CinemaSchedule";
            string username = "root";
            string password = "Deniskarachun9";




            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}
