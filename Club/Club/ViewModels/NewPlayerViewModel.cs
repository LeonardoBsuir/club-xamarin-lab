using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{

    
    class NewPlayerViewModel : BaseViewModel
    {
        readonly Database database;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Cost { get; set; }
        public ICommand AddCommand { get; set; }
        public INavigation Navigation { get; set; }

        public NewPlayerViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            AddCommand = new Command(Add);
            database = new Database("Club");
        }

        void Add()
        {
            int cost;
            if (int.TryParse(Cost, out cost))
            {
                var record = new Player
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Position = Position,
                    PhoneNumber = PhoneNumber,
                    Cost = cost

                };
                var numberOfRows = database.SaveItem(record);
                ClearForm();
            }
        }

        void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Position = string.Empty;
            PhoneNumber = string.Empty;
            Cost = string.Empty;
            RaisePropertyChanged(nameof(FirstName));
            RaisePropertyChanged(nameof(LastName));
            RaisePropertyChanged(nameof(PhoneNumber));
            RaisePropertyChanged(nameof(Position));
            RaisePropertyChanged(nameof(Cost));
        }

    }
}
