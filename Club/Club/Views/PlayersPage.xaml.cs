
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Club
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {
        private BaseViewModel viewModel;
        public PlayersPage()
        {
            InitializeComponent();
            viewModel = new PlayersViewModel(Navigation);
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel != null)
                await viewModel.OnAppearing();
        }
    }
}
