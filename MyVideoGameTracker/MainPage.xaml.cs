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
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			this.DataContext = App.ViewModel;

			if (System.Diagnostics.Debugger.IsAttached)
			{
				mainPageAd.ApplicationId = "test_client";
				mainPageAd.AdUnitId = "TextAd";
			}
			else
			{
				mainPageAd.ApplicationId = "<TODO guid>";
				mainPageAd.AdUnitId = "<TODO id>";
			}
		}

		private void addVideoGame(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/NewVideoGamePage.xaml", UriKind.Relative));
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			App.ViewModel.SaveChanges();
		}

		private void listBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var listBox = sender as ListBox;
			if (listBox == null || listBox.SelectedIndex == -1)
			{
				return;
			}
			NavigationService.Navigate(new Uri("/EditVideoGamePage.xaml?id=" + ((VideoGame)listBox.SelectedItem).Id, UriKind.Relative));
			listBox.SelectedIndex = -1;
		}

		private void longListSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var listBox = sender as LongListSelector;
			if (listBox == null || listBox.SelectedItem == null)
			{
				return;
			}
			NavigationService.Navigate(new Uri("/EditVideoGamePage.xaml?id=" + ((VideoGame)listBox.SelectedItem).Id, UriKind.Relative));
			listBox.SelectedItem = null;
		}

		private void helpAndAbout(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
		}
	}
}