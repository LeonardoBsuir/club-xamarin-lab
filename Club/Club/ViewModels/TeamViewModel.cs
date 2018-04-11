using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;

namespace Club
{
    class TeamViewModel : BaseViewModel
    {
        public static Map Map { get; set; }

        public Team CurrentTeam { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand WheatherBtnClicked { get; set; }

        private Geocoder geoCoder;

        public TeamViewModel(INavigation navigation, Team team)
        {
            this.CurrentTeam = team;
            Navigation = navigation;
            this.WheatherBtnClicked = new Command(async (e) =>
            {
                var item = (e as Team);
                await Navigation.PushAsync(new WeatherPage(item));
            });
            getMapAsync();
        }

        async System.Threading.Tasks.Task getMapAsync()
        {
            geoCoder = new Geocoder();
            double latitude = 53.895072;
            double longitude = 27.560766;
            var address = CurrentTeam.City;
            var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
            var position = approximateLocations.FirstOrDefault();
            if (position.Latitude != 0 || position.Latitude != 0)
            {
                latitude = position.Latitude;
                longitude = position.Longitude;
            }
            Map.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                    new Position(latitude, longitude), Distance.FromMiles(5)));
        }
    }
}
