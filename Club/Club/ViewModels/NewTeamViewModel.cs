using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Club
{
    class NewTeamViewModel : BaseViewModel
    {
        readonly Database database;
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public string Coach { get; set; }
        public string Cost { get; set; }
        public ICommand AddCommand { get; set; }
        public INavigation Navigation { get; set; }

        public NewTeamViewModel(INavigation navigation)
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
                var record = new Team
                {
                    Name = Name,
                    City = City,
                    Country = Country,
                    Coach = Coach,
                    Stadium = Stadium,
                    Cost = cost

                };
                var numberOfRows = database.SaveItem(record);
                ClearForm();
            }
        }

        void ClearForm()
        {
            Name = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Coach = string.Empty;
            Stadium = string.Empty;
            Cost = string.Empty;
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(City));
            RaisePropertyChanged(nameof(Country));
            RaisePropertyChanged(nameof(Coach));
            RaisePropertyChanged(nameof(Stadium));
            RaisePropertyChanged(nameof(Cost));
        }
    }
}
