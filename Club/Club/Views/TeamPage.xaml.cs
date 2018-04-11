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
            
            BindingContext = new TeamViewModel(Navigation, item);
            TeamViewModel.Map = MyMap;
        }
    }
}