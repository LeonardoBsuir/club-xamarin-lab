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
        public ObservableCollection<Team> Records { get; set; }

        public TeamsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.NewTeamBtnClicked = new Command(async () => await GoToNewTeamPage());
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
        }

        public override async Task OnAppearing()
        {
            ShowAllRecords();
        }
    }
}
