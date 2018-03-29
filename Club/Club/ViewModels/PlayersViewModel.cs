using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class PlayersViewModel : BaseViewModel
    {
        readonly Database database;
        public INavigation Navigation { get; set; }
        public ICommand NewPlayerBtnClicked { get; set; }
        public ObservableCollection<Player> Records { get; set; }

        public PlayersViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewPlayerBtnClicked = new Command(async () => await GoToNewPlayerPage());
            database = new Database("Club");
            database.CreateTable<Player>();
            Records = new ObservableCollection<Player>();
            ShowAllRecords();
        }

        public async Task GoToNewPlayerPage()
        {
            await Navigation.PushAsync(new NewPlayerPage());
        }

        void ShowAllRecords()
        {
            Records.Clear();
            var players = database.GetItems<Player>();
            foreach (var person in players)
            {
                Records.Add(person);
            }
        }

        public override async Task OnAppearing()
        {
            ShowAllRecords();
        }
    }
}
