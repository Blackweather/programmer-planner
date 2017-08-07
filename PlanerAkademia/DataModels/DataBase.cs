using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace PlanerAkademia {
    public static class DataBase {

        #region PrivateMembers

        /// <summary>
        /// Gets the user id when logged in
        /// </summary>
        private static int UserID { get; set; }

        /// <summary>
        /// MySqlConnection variable
        /// </summary>
        private static MySqlConnection connection;

        /// <summary>
        /// String with informations needed to connect
        /// </summary>
        private static string connect = "Server=188.40.51.83; Port=3306; Database=snooking_AkademiaPlaner; Uid=snooking_Planer; password=LoveYouTomeczek;";

        #endregion

        #region PublicFunctions

        public static bool LogIn(string login, string password) {
            try {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Login, Password FROM Users WHERE `Login` = '" +
                    login + "' AND `Password` = '" + password + "'";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    UserID = 5;
                    return true;
                }
                return false;
            }
            catch {
                Console.WriteLine("To też nie dziala chuju.");
                return false;
            }
        }

        public static bool Register(string login, string password) {
            try {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Login, Password FROM Users WHERE `Login` = '" +
                    login + "'";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) return false;

                command.CommandText = "INSERT INTO `Users` (`ID`, `Login`, `Password`) VALUES " +
                "(NULL, '" + login + "', '" + password + "')";
                reader.Close();
                reader = command.ExecuteReader();
                return true;
            }
            catch {
                Console.WriteLine("Nie dziala chuju.");
                return false;
            }
        }

        //change dateTime to converted dateTime String (as converted in Event.cs class)
        public static void AddEvent(Event eventt) {
            try {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO `Events` (`ID`, `Name`, `DateAndTime`, `Description`) VALUES " +
                "(NULL, '" + eventt.Name + "', '" + eventt.InsertedDateTime + "', '" + eventt.Description + "')";
                connection.Open();
                Console.WriteLine(command.CommandText);
                MySqlDataReader reader = command.ExecuteReader();
                //maybe not working because connection/datareader not closed in each database access
            }
            catch {
                Console.WriteLine("This shit doesn't work either.");
            }
        }

        public static List<Event> ShowEvents() {
            try {
                List<Event> events = new List<Event>();
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "SELECT * FROM `Events`";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Event eve = new Event();
                    eve.Name = (string)reader["Name"];
                    int col = reader.GetOrdinal("DateAndTime");
                    var info = reader.GetMySqlDateTime(col);
                    eve.InsertedDateTime = info.ToString();
                    eve.InsertedDateTimeToVariables();
                    eve.Description = (string)reader["Description"];
                    events.Add(eve);
                }
                return events;
            }
            catch {
                Console.WriteLine("Cannot show your fucking Events");
                return null;
            }
        }

        #endregion
    }
}