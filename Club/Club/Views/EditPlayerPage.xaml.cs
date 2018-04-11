using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Club
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPlayerPage : ContentPage
	{
        public EditPlayerPage(Player item)
        {
            InitializeComponent();
            BindingContext = new EditPlayerViewModel(Navigation, item);
        }
	}
}