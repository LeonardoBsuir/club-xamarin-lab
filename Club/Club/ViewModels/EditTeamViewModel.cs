using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class EditTeamViewModel : BaseViewModel
    {
        readonly Database database;
        public Team CurrentTeam { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand EditCommand { get; set; }

        public EditTeamViewModel(INavigation navigation, Team team)
        {
            this.CurrentTeam = team;
            Navigation = navigation;
            this.EditCommand = new Command(UpdateTeam);
            database = new Database("Club");
        }

        void UpdateTeam()
        {
            var numberOfRows = database.SaveItem(CurrentTeam);
        }
    }
}
