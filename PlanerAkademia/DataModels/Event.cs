namespace PlanerAkademia
{
    public class Event
    {
        #region PublicMembers

        public string Name { get; set; }

        public string Date { get; set; }

        #endregion

        #region Constructor

        public Event(string Name, string Date)
        {
            this.Name = Name;
            this.Date = Date;
        }

        #endregion
    }
}
