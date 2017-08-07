using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia {
    public class ShowEventViewModel : BaseViewModel {

        #region PublicMembers

        public List<Event> Events { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to Log out
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        /// <summary>
        /// Command to Go to Page of Event Adding
        /// </summary>
        public ICommand AddEventCommand { get; set; }

        #endregion

        #region Constructor

        public ShowEventViewModel() {
            //Commands
            LogOutCommand = new RelayCommand(async () => await LogOutAsync());
            AddEventCommand = new RelayCommand(async () => await AddEventAsync());

            //ListView
            //change to EventList later
            Events = DataBase.ShowEvents();

            //Get events from DB to this list?
            //Yes
            //DB <3 

            //Events.Add(new Event("Check", 2000, 1, 1, 10, 37, 0, "Casual Check"));
            //Events.Add(new Event("You Give Love", 2000, 1, 25, 6, 11, 5, "Jon Bovi"));
            //Events.Add(new Event("A Bad Name", 2000, 12, 1, 21, 3, 7, "So bad"));

        }

        #endregion

        #region Functions


        public async Task AddEventAsync() {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.AddEvents;

            await Task.Delay(1);
        }

        public async Task LogOutAsync() {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.SignIn;

            await Task.Delay(1);
        }

        #endregion
    }
}
