using MySql.Data.MySqlClient;
using System;

namespace PlanerAkademia
{
    public static class DataBase
    {

        #region PrivateMembers

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

        public static bool LogIn(string login, string password)
        {
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Login, Password FROM Users WHERE `Login` = '" + 
                    login + "' AND `Password` = '" + password + "'";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) return true;
                return false;
            }
            catch
            {
                Console.WriteLine("To też nie dziala chuju.");
                return false;
            }
        }

        public static bool Register(string login, string password)
        {
            try 
            {
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
            catch
            {
                Console.WriteLine("Nie dziala chuju.");
                return false;
            }
        }

        public static void AddEvent(string name, DateTime dateTime, string description)
        {
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO `Events` (`ID`, `Name`, `DateTime`, `Description`) VALUES " +
                "(NULL, '" + name + "', '" + dateTime + "', '" + description + "')";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("This shit doesn't work either.");
            }
        }

        public static void ShowEvents()
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion
    }
}