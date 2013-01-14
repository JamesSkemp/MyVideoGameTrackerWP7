using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MyVideoGameTracker.Model;
using System.Collections.Generic;

namespace MyVideoGameTracker.ViewModel
{
	public class AppViewModel : INotifyPropertyChanged
	{
		private AppDataContext db;

		public AppViewModel()
		{
			db = new AppDataContext();
		}

		private ObservableCollection<VideoGame> _allVideoGames;
		public ObservableCollection<VideoGame> AllVideoGames
		{
			get { return _allVideoGames; }
			set
			{
				_allVideoGames = value;
				NotifyPropertyChanged("AllVideoGames");
			}
		}

		private ObservableCollection<VideoGame> _videoGamesByTitle;
		public ObservableCollection<VideoGame> VideoGamesByTitle
		{
			get { return _videoGamesByTitle; }
			set
			{
				_videoGamesByTitle = value;
				NotifyPropertyChanged("VideoGamesByTitle");
			}
		}

		private IEnumerable<Group<VideoGame>> _videoGamesGroupedByConsole;
		public IEnumerable<Group<VideoGame>> VideoGamesGroupedByConsole
		{
			get { return _videoGamesGroupedByConsole; }
			set
			{
				_videoGamesGroupedByConsole = value;
				NotifyPropertyChanged("VideoGamesGroupedByConsole");
			}
		}

		/*private IEnumerable<string> _consoles;
		public IEnumerable<string> Consoles
		{
			get { return _consoles; }
			set
			{
				_consoles = value;
				NotifyPropertyChanged("Consoles");
			}
		}*/

		public void LoadData()
		{
			var videoGames = db.VideoGames.Select(v => v);
			AllVideoGames = new ObservableCollection<VideoGame>(videoGames.OrderByDescending(g => g.Id));
			VideoGamesByTitle = new ObservableCollection<VideoGame>(videoGames.OrderBy(v => v.Title).ThenBy(v => v.Console));
			//var gamesGroupedByConsole = videoGames.GroupBy(g => g.Console).OrderBy(g => g.Key).Select(g => new Group<VideoGame>(g.Key, g));
			UpdateCollections();

			//Consoles = AllVideoGames.Select(g => g.Console).Distinct().OrderBy(c => c);
		}

		public void AddVideoGame(VideoGame newGame)
		{
			db.VideoGames.InsertOnSubmit(newGame);
			db.SubmitChanges();

			AllVideoGames.Insert(0, newGame);
			VideoGamesByTitle = new ObservableCollection<VideoGame>(AllVideoGames.OrderBy(v => v.Title).ThenBy(v => v.Console));
			UpdateCollections();
		}

		public void DeleteVideoGame(VideoGame game)
		{
			db.VideoGames.DeleteOnSubmit(game);
			db.SubmitChanges();

			AllVideoGames.Remove(game);
			VideoGamesByTitle.Remove(game);
			UpdateCollections();
		}

		public void SaveChanges()
		{
			db.SubmitChanges();
		}

		public void UpdateCollections()
		{
			VideoGamesGroupedByConsole = db.VideoGames.OrderBy(g => g.Console).ThenBy(g => g.Title).GroupBy(g => g.Console).OrderBy(g => g.Key).Select(g => new Group<VideoGame>(g.Key, g));
		}

		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
