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
	public partial class PlayerPage : ContentPage
	{
		public PlayerPage (Player item)
		{
			InitializeComponent ();
            BindingContext = new PlayerViewModel(Navigation, item);
        }
	}
}