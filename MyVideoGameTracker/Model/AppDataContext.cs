using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MyVideoGameTracker.Model
{
	public class AppDataContext : DataContext
	{
		public AppDataContext()
			: base("Data Source=isostore:/AppData.sdf")
		{
		}

		public Table<VideoGame> VideoGames;
	}

	[Table]
	public class VideoGame : INotifyPropertyChanged, INotifyPropertyChanging
	{
		// Define ID: private field, public property, and database column.
		private int _id;

		[Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
		public int Id
		{
			get { return _id; }
			set
			{
				if (_id != value)
				{
					NotifyPropertyChanging("Id");
					_id = value;
					NotifyPropertyChanged("Id");
				}
			}
		}

		private string _title;
		[Column]
		public string Title
		{
			get { return _title; }
			set
			{
				if (_title != value)
				{
					NotifyPropertyChanging("Title");
					_title = value;
					NotifyPropertyChanged("Title");
				}
			}
		}

		private string _console;
		[Column]
		public string Console
		{
			get { return _console; }
			set
			{
				if (_console != value)
				{
					NotifyPropertyChanging("Console");
					_console = value;
					NotifyPropertyChanged("Console");
				}
			}
		}

		private DateTime? _purchaseDate;
		[Column]
		public DateTime? PurchaseDate
		{
			get { return _purchaseDate; }
			set
			{
				if (_purchaseDate != value)
				{
					NotifyPropertyChanging("PurchaseDate");
					_purchaseDate = value;
					NotifyPropertyChanged("PurchaseDate");
				}
			}
		}

		private string _purchasePrice;
		[Column]
		public string PurchasePrice
		{
			get { return _purchasePrice; }
			set
			{
				if (_purchasePrice != value)
				{
					NotifyPropertyChanging("PurchasePrice");
					_purchasePrice = value;
					NotifyPropertyChanged("PurchasePrice");
				}
			}
		}

		private string _purchasePlace;
		[Column]
		public string PurchasePlace
		{
			get { return _purchasePlace; }
			set
			{
				if (_purchasePlace != value)
				{
					NotifyPropertyChanging("PurchasePlace");
					_purchasePlace = value;
					NotifyPropertyChanged("PurchasePlace");
				}
			}
		}

		private DateTime? _sellDate;
		[Column]
		public DateTime? SellDate
		{
			get { return _sellDate; }
			set
			{
				if (_sellDate != value)
				{
					NotifyPropertyChanging("SellDate");
					_sellDate = value;
					NotifyPropertyChanged("SellDate");
				}
			}
		}

		private string _sellPrice;
		[Column]
		public string SellPrice
		{
			get { return _sellPrice; }
			set
			{
				if (_sellPrice != value)
				{
					NotifyPropertyChanging("SellPrice");
					_sellPrice = value;
					NotifyPropertyChanged("SellPrice");
				}
			}
		}

		private string _sellPlace;
		[Column]
		public string SellPlace
		{
			get { return _sellPlace; }
			set
			{
				if (_sellPlace != value)
				{
					NotifyPropertyChanging("SellPlace");
					_sellPlace = value;
					NotifyPropertyChanged("SellPlace");
				}
			}
		}

		private bool _own;
		[Column]
		public bool Own
		{
			get { return _own; }
			set
			{
				if (_own != value)
				{
					NotifyPropertyChanging("Own");
					_own = value;
					NotifyPropertyChanged("Own");
				}
			}
		}

		private string _notes;
		[Column]
		public string Notes
		{
			get { return _notes; }
			set
			{
				if (_notes != value)
				{
					NotifyPropertyChanging("Notes");
					_notes = value;
					NotifyPropertyChanged("Notes");
				}
			}
		}

		private bool _addOn;
		[Column]
		public bool AddOn
		{
			get { return _addOn; }
			set
			{
				if (_addOn != value)
				{
					NotifyPropertyChanging("AddOn");
					_addOn = value;
					NotifyPropertyChanged("AddOn");
				}
			}
		}

		private bool _electronic;
		[Column]
		public bool Electronic
		{
			get { return _electronic; }
			set
			{
				if (_electronic != value)
				{
					NotifyPropertyChanging("Electronic");
					_electronic = value;
					NotifyPropertyChanged("Electronic");
				}
			}
		}

		private bool _used;
		[Column]
		public bool Used
		{
			get { return _used; }
			set
			{
				if (_used != value)
				{
					NotifyPropertyChanging("Used");
					_used = value;
					NotifyPropertyChanged("Used");
				}
			}
		}

		private bool _beat;
		[Column]
		public bool Beat
		{
			get { return _beat; }
			set
			{
				if (_beat != value)
				{
					NotifyPropertyChanging("Beat");
					_beat = value;
					NotifyPropertyChanged("Beat");
				}
			}
		}

		#pragma warning disable 0169
		// Version column aids update performance.
		[Column(IsVersion = true)]
		private Binary _version;
		#pragma warning restore 0169

		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;

		// Used to notify that a property changed
		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region INotifyPropertyChanging Members
		public event PropertyChangingEventHandler PropertyChanging;

		// Used to notify that a property is about to change
		private void NotifyPropertyChanging(string propertyName)
		{
			if (PropertyChanging != null)
			{
				PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		#endregion
	}
}