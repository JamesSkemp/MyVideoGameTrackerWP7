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
	public partial class EditVideoGamePage : PhoneApplicationPage
	{
		public EditVideoGamePage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			string gameId = "";
			if (NavigationContext.QueryString.TryGetValue("id", out gameId))
			{
				int id = int.Parse(gameId);
				this.DataContext = App.ViewModel.AllVideoGames.Single(g => g.Id == id);
			}
			else
			{
				if (NavigationService.CanGoBack)
				{
					NavigationService.GoBack();
				}
			}
		}

		private void saveEntry(object sender, EventArgs e)
		{
			if (titleTextBox.Text.Length > 0)
			{
				App.ViewModel.SaveChanges();
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

		private void deleteEntry(object sender, EventArgs e)
		{
			App.ViewModel.DeleteVideoGame((VideoGame)this.DataContext);
			if (NavigationService.CanGoBack)
			{
				NavigationService.GoBack();
			}
		}
	}
}