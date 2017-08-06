using System;

namespace PlanerAkademia {
    public class Event {
        #region PublicMembers

        public string Name { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        //needed to convert to sql DateTime

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public string Description { get; set; }

        //string for sql query

        public string InsertedDateTime { get; set; }

        #endregion

        #region PrivateMethods
        private string CheckIfTimeIsLow(int timeValue, string stringToChange) {
            if (timeValue < 10) {
                stringToChange += "0";
            }

            return stringToChange;
        }

        private void ConvertToTimeString() {
            Time = "";

            Time = CheckIfTimeIsLow(Hours, Time);
            Time += Hours.ToString();

            Time += ":";

            Time = CheckIfTimeIsLow(Minutes, Time);
            Time += Minutes.ToString();

            Time += ":";

            Time = CheckIfTimeIsLow(Seconds, Time);
            Time += Seconds.ToString();
        }

        private void ConvertToInsertedDateTime() {

            InsertedDateTime = "";

            //Add Date
            InsertedDateTime += Date;

            InsertedDateTime += " ";

            //Add Time
            InsertedDateTime += Time;
        }

        #endregion

        #region Constructor

        public Event(string Name, string Date, int Hours, int Minutes, int Seconds, string Description) {
            this.Name = Name;

            this.Date = Date;

            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;

            this.Description = Description;

            ConvertToTimeString();
            ConvertToInsertedDateTime();
        }

        #endregion
    }
}
