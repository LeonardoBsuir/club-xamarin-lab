using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Club
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TeamPage : ContentPage
	{
        public TeamPage(Team item)
		{
			InitializeComponent ();
            MyMap.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                    new Position(37, 33), Distance.FromMiles(1)));
            BindingContext = new TeamViewModel(Navigation, item);
        }
    }
}