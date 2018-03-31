using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class TeamsViewModel : BaseViewModel
    {
        readonly Database database;
        public INavigation Navigation { get; set; }
        public ICommand NewTeamBtnClicked { get; set; }
        public ICommand ViewTeamBtnClicked { get; set; }
        public ICommand EditTeamBtnClicked { get; set; }
        public ICommand RemoveTeamBtnClicked { get; set; }
        public ObservableCollection<Team> Records { get; set; }

        private Team _oldTeam;

        public TeamsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewTeamBtnClicked = new Command(async () => await GoToNewTeamPage());
            this.ViewTeamBtnClicked = new Command(async (e) =>
            {
                var item = (e as Team);
                _oldTeam = null;
                item.IsVisible = false;
                await Navigation.PushAsync(new TeamPage(item));

            });
            this.EditTeamBtnClicked = new Command(async (e) =>
            {
                var item = (e as Team);
                _oldTeam = null;
                item.IsVisible = false;
                await Navigation.PushAsync(new EditTeamPage(item));

            });
            this.RemoveTeamBtnClicked = new Command((e) =>
           {
               var item = (e as Team);
               database.DeleteItem<Team>(item.ID);
               Records.Remove(item);
               _oldTeam = null;
           });
            database = new Database("Club");
            database.CreateTable<Team>();
            Records = new ObservableCollection<Team>();
            ShowAllRecords();
        }

        public async Task GoToNewTeamPage()
        {
            await Navigation.PushAsync(new NewTeamPage());
        }

        void ShowAllRecords()
        {
            Records.Clear();
            var Teams = database.GetItems<Team>();
            foreach (var team in Teams)
            {
                Records.Add(team);
            }
            _oldTeam = null;
        }

        public override async Task OnAppearing()
        {
            ShowAllRecords();
        }

        public void ShowOrHidePoducts(Team team)
        {
            if (_oldTeam == team)
            {
                // click twice on the same item will hide it
                team.IsVisible = !team.IsVisible;
                UpdateProducts(team);
            }
            else
            {
                if (_oldTeam != null)
                {
                    // hide previous selected item
                    _oldTeam.IsVisible = false;
                    UpdateProducts(_oldTeam);
                }
                // show selected item
                team.IsVisible = true;
                UpdateProducts(team);
            }

            _oldTeam = team;
        }

        private void UpdateProducts(Team team)
        {
            var index = Records.IndexOf(team);
            Records.Remove(team);
            Records.Insert(index, team);
        }
    }
}
