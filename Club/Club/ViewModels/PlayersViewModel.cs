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
        public ICommand ViewPlayerBtnClicked { get; set; }
        public ICommand EditPlayerBtnClicked { get; set; }
        public ICommand RemovePlayerBtnClicked { get; set; }
        public ObservableCollection<Player> Records { get; set; }

        private Player _oldPlayer;

        public PlayersViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewPlayerBtnClicked = new Command(async () => await GoToNewPlayerPage());
            this.ViewPlayerBtnClicked = new Command(async (e) =>
            {
                var item = (e as Player);
                _oldPlayer = null;
                item.IsVisible = false;
                await Navigation.PushAsync(new PlayerPage(item));

            });
            this.EditPlayerBtnClicked = new Command(async (e) =>
            {
                var item = (e as Player);
                _oldPlayer = null;
                item.IsVisible = false;
                await Navigation.PushAsync(new EditPlayerPage(item));

            });
            this.RemovePlayerBtnClicked = new Command((e) =>
            {
                var item = (e as Player);
                database.DeleteItem<Player>(item.ID);
                Records.Remove(item);
                _oldPlayer = null;
            });
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
            var Players = database.GetItems<Player>();
            foreach (var player in Players)
            {
                Records.Add(player);
            }
            _oldPlayer = null;
        }

        public override async Task OnAppearing()
        {
            ShowAllRecords();
        }

        public void ShowOrHidePoducts(Player player)
        {
            if (_oldPlayer == player)
            {
                // click twice on the same item will hide it
                player.IsVisible = !player.IsVisible;
                UpdateProducts(player);
            }
            else
            {
                if (_oldPlayer != null)
                {
                    // hide previous selected item
                    _oldPlayer.IsVisible = false;
                    UpdateProducts(_oldPlayer);
                }
                // show selected item
                player.IsVisible = true;
                UpdateProducts(player);
            }

            _oldPlayer = player;
        }

        private void UpdateProducts(Player player)
        {
            var index = Records.IndexOf(player);
            Records.Remove(player);
            Records.Insert(index, player);
        }
    }
}
