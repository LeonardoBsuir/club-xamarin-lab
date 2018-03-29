
using Xamarin.Forms;

namespace Club
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
		}

    }
}
