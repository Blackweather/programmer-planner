using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia
{
    public class ShowEventViewModel : BaseViewModel
    {

        #region PublicMembers

        public List<Event> Events { get; set; }

        public string Name { get; set; }

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

        public ShowEventViewModel()
        {
            //Commands
            LogOutCommand = new RelayCommand(async () => LogOutAsync());
            AddEventCommand = new RelayCommand(async () => AddEventAsync());

            //ListView
            Events = new List<Event>();

            Events.Add(new Event("Check", "01.01.2000"));
            Events.Add(new Event("You Give Love", "25.01.2000"));
            Events.Add(new Event("A Bad Name", "01.12.2000"));

        }

        #endregion

        #region Functions


        public async Task AddEventAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.AddEvents;

            await Task.Delay(1);
        }

        public async Task LogOutAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.SignIn;

            await Task.Delay(1);
        }

        #endregion
    }
}
