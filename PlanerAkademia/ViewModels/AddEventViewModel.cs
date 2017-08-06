using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia
{
    public class AddEventViewModel : BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Date of the event
        /// </summary>
        private DateTime date
        {
            get
            {
                if (mDate.Year < 1970) return new DateTime(1970, 1, 1);
                else return mDate;
            }
            set
            {
                
            }
        }

        /// <summary>
        /// Hour of the event
        /// </summary>
        private int hour
        {
            get
            {
                if (mHour < 0) return 0;
                else if (mHour > 23) return 23;
                else return mHour;
            }
            set
            {

            }
        }

        /// <summary>
        /// Minute of the event
        /// </summary>
        private int minute
        {
            get
            {
                if (mMinute < 0) return 0;
                else if (mMinute > 59) return 59;
                else return mMinute;
            }
            set
            {

            }
        }

        /// <summary>
        /// Second of the event
        /// </summary>
        private int second
        {
            get
            {
                if (mSecond < 0) return 0;
                else if (mSecond > 59) return 59;
                else return mSecond;
            }
            set
            {

            }
        }

        /// <summary>
        /// Day of the event
        /// </summary>
        private int day
        {
            get
            {
                return date.Day;
            }
            set
            {

            }
        }

        /// <summary>
        /// Month of the event
        /// </summary>
        private int month
        {
            get
            {
                return date.Month;
            }
            set
            {

            }
        }

        /// <summary>
        /// Year of the event
        /// </summary>
        private int year
        {
            get
            {
                return date.Year;
            }
            set
            {

            }
        }

        #endregion

        #region PublicMembers

        /// <summary>
        /// Name of the event
        /// </summary>
        public string name { get; set; }

        public int mHour { get; set; }

        public int mMinute { get; set; }

        public int mSecond { get; set; }

        public DateTime mDate { get; //{
                                     // return new DateTime(year, month, day, hour, minute, second);
                                     //}
            set; }
        
        /// <summary>
        /// Full Date of the event
        /// </summary>
        public DateTime dateTime
        {
            get
            {
                return new DateTime(year, month, day, hour, minute, second);
            }
        }

        /// <summary>
        /// Description of the event
        /// </summary>
        public string description { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to accept the event and send it to database
        /// </summary>
        public ICommand AcceptCommand { get; set; }

        /// <summary>
        /// Command to cancel the event and delete all informations
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public AddEventViewModel()
        {
            AcceptCommand = new RelayCommand(async () => await AcceptAsync());
            CancelCommand = new RelayCommand(async () => await CancelAsync());
        }

        #endregion

        #region Fuctions

        /// <summary>
        /// Function that execute, when the cancell button is pressed
        /// </summary>
        public async Task CancelAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;

            await Task.Delay(1);
        }

        /// <summary>
        /// Function that execute, when the accept button is pressed
        /// </summary>
        public async Task AcceptAsync()
        {
            DataBase.AddEvent(name, dateTime, description);
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;

            await Task.Delay(1);
        }

        #endregion
    }
}
