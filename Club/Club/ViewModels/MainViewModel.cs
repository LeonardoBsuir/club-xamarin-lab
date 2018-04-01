using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand PlayersBtnClicked { get; set; }
        public ICommand TeamsBtnClicked { get; set; }
        public ICommand PhoneBtnClicked { get; set; }
        public ICommand WheatherBtnClicked { get; set; }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.PlayersBtnClicked = new Command(async () => await GoToPlayersPage());
            this.TeamsBtnClicked = new Command(async () => await GoToTeamsPage());
            this.PhoneBtnClicked = new Command(PhoneCall);
            this.WheatherBtnClicked = new Command(async () => await GoToWeatherPage());
        }

        public async Task GoToPlayersPage()
        {
            await Navigation.PushAsync(new PlayersPage());
        }

        public async Task GoToTeamsPage()
        {
            await Navigation.PushAsync(new TeamsPage());
        }

        public async Task GoToWeatherPage()
        {
            await Navigation.PushAsync(new WeatherPage());
        }

        void PhoneCall()
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+375296893625");
        }
    }
}
