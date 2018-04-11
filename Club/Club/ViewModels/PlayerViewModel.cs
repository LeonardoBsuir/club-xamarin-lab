using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class PlayerViewModel : BaseViewModel
    {
        public Player CurrentPlayer { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand PhoneBtnClicked { get; set; }

        public PlayerViewModel(INavigation navigation, Player player)
        {
            this.CurrentPlayer = player;
            Navigation = navigation;
            this.PhoneBtnClicked = new Command((e) =>
            {
                var item = (e as Player);
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                string number = item.PhoneNumber;
                if (phoneDialer.CanMakePhoneCall && !String.IsNullOrEmpty(number))
                    phoneDialer.MakePhoneCall(item.PhoneNumber);
            });
        }
    }
}
