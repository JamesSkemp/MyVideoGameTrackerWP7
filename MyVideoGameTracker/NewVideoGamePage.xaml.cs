using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MyVideoGameTracker.Model;

namespace MyVideoGameTracker
{
	public partial class NewVideoGamePage : PhoneApplicationPage
	{
		public NewVideoGamePage()
		{
			InitializeComponent();
			titleTextBox.Focus();
		}

		private void saveEntry(object sender, EventArgs e)
		{
			if (titleTextBox.Text.Length > 0)
			{
				VideoGame newGame = new VideoGame
				{
					Title = titleTextBox.Text,
					Console = consoleTextBox.Text,
					Notes = notesTextBox.Text,
					Own = (ownCheckBox.IsChecked.HasValue ? ownCheckBox.IsChecked.Value : false),
					PurchaseDate = purchaseDatePicker.Value,
					PurchasePrice = purchasePriceTextBox.Text,
					PurchasePlace = purchasePlaceTextBox.Text,
					SellDate = sellDatePicker.Value,
					SellPrice = sellPriceTextBox.Text,
					SellPlace = sellPlaceTextBox.Text,
					AddOn = addOnCheckBox.IsChecked.HasValue ? addOnCheckBox.IsChecked.Value : false,
					Electronic = electronicCheckBox.IsChecked.HasValue ? electronicCheckBox.IsChecked.Value : false,
					Used = usedCheckBox.IsChecked.HasValue ? usedCheckBox.IsChecked.Value : false,
					Beat = beatCheckBox.IsChecked.HasValue ? beatCheckBox.IsChecked.Value : false
				};

				App.ViewModel.AddVideoGame(newGame);

				if (NavigationService.CanGoBack)
				{
					NavigationService.GoBack();
				}
			}
		}

		private void cancelEntry(object sender, EventArgs e)
		{
			if (NavigationService.CanGoBack)
			{
				NavigationService.GoBack();
			}
		}
	}
}