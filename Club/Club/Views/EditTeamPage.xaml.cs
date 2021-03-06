﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Club
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTeamPage : ContentPage
	{
		public EditTeamPage (Team item)
		{
			InitializeComponent ();
            BindingContext = new EditTeamViewModel(Navigation, item);
        }
	}
}