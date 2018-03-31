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
	public partial class TeamsPage : ContentPage
	{
        private TeamsViewModel viewModel;
        public TeamsPage ()
		{
            InitializeComponent();
            viewModel = new TeamsViewModel(Navigation);
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel != null)
                await viewModel.OnAppearing();
        }

        private void TeamsList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var team = e.Item as Team;
            viewModel?.ShowOrHidePoducts(team);
        }
    }
}