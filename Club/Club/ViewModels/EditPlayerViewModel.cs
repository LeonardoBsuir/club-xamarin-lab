using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class EditPlayerViewModel : BaseViewModel
    {
        readonly Database database;
        public Player CurrentPlayer { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand EditCommand { get; set; }

        public EditPlayerViewModel(INavigation navigation, Player player)
        {
            this.CurrentPlayer = player;
            Navigation = navigation;
            this.EditCommand = new Command(UpdatePlayer);
            database = new Database("Club");
        }

        void UpdatePlayer()
        {
            var numberOfRows = database.SaveItem(CurrentPlayer);
        }
    }
}
