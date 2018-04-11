
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Club
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {
        private PlayersViewModel viewModel;
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

        private void PlayersList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var player = e.Item as Player;
            viewModel?.ShowOrHidePoducts(player);
        }
    }
}
