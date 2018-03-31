using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class TeamViewModel : BaseViewModel
    {
        public Team CurrentTeam { get; set; }
        public INavigation Navigation { get; set; }

        public TeamViewModel(INavigation navigation, Team team)
        {
            this.CurrentTeam = team;
            Navigation = navigation;
        }

    }
}
