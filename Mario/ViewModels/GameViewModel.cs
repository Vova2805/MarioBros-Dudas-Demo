using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab5_KPZ.Models;
using Lab5_KPZ.UserControls;
using WpfApplication.ViewModel;

namespace Lab5_KPZ.ViewModels
{
	public class GameViewModel:ViewModelBase
	{
		private Player _FirstPlayer;
		private Player _SecondPlayer;
		private Level _CurrentLevel;
		private UserSettings _FirstSettings;
		private UserSettings _SecondSettings;
		private string _SaveRestore;
		private string _uploadGame;
		private string _uploadedSuccessfull;
		private Dictionary<string, Size> _screenSizes;
		private string _isWon;
		public string isWon
		{
			get { return _isWon; }
			set
			{
				_isWon = value;
				OnPropertyChanged("isWon");
			}
		}
		public Dictionary<string, Size> screenSizes
		{
			get { return _screenSizes; }
			set
			{
				_screenSizes = value;
				OnPropertyChanged("screenSizes");
			}
		}
		public string uploadedSuccessfull
		{
			get { return _uploadedSuccessfull; }
			set
			{
				_uploadedSuccessfull = value;
				OnPropertyChanged("uploadedSuccessfull");
			}
		}
		public string uploadGame
		{
			get { return _uploadGame; }
			set
			{
				_uploadGame = value;
				OnPropertyChanged("uploadGame");
			}
		}
		public string SaveRestore
		{
			get { return _SaveRestore; }
			set
			{
				_SaveRestore = value;
				OnPropertyChanged("SaveRestore");
			}
		}
		public ICommand Set { get; set; }
	
		public void function(object arg)
		{
			SaveRestore = arg.ToString();
		}
		public UserSettings FirstSettings
		{
			get { return _FirstSettings; }
			set
			{
				_FirstSettings = value;
				OnPropertyChanged("FirstSettings");
			}
		}
		public UserSettings SecondSettings
		{
			get { return _SecondSettings; }
			set
			{
				_SecondSettings = value;
				OnPropertyChanged("SecondSettings");
			}
		}
		public Player FirstPlayer
		{
			get { return _FirstPlayer; }
			set
			{
				_FirstPlayer = value;
				OnPropertyChanged("FirstPlayer");
			}
		}
		public Player SecondPlayer
		{
			get { return _SecondPlayer; }
			set
			{
				_SecondPlayer = value;
				OnPropertyChanged("SecondPlayer");
			}
		}
		public Level CurrentLevel
		{
			get { return _CurrentLevel; }
			set
			{
				_CurrentLevel = value;
				OnPropertyChanged("CurrentLevel");
			}
		}
		private string Quantity; // One or Two

		public string _quantity
		{
			get { return Quantity; }
			set
			{
				Quantity = value;
				OnPropertyChanged("_quantity");
			}
		}
		private string FirstChoose;

		public string _first
		{
			get { return FirstChoose; }
			set
			{
				FirstChoose = value;
				OnPropertyChanged("_first");
			}
		}
		private string SecondChoose;

		public string _second
		{
			get { return SecondChoose; }
			set
			{
				SecondChoose = value;
				OnPropertyChanged("_second");
			}
		}
		private string _FirstPlayerSubmited;

		public string FirstPlayerSubmited
		{
			get { return _FirstPlayerSubmited; }
			set
			{
				_FirstPlayerSubmited = value;
				OnPropertyChanged("FirstPlayerSubmited");
			}
		}
		private string _SecondPlayerSubmited;

		public string SecondPlayerSubmited
		{
			get { return _SecondPlayerSubmited; }
			set
			{
				_SecondPlayerSubmited = value;
				OnPropertyChanged("SecondPlayerSubmited");
			}
		}
		public ICommand StartPlay { get; set; }
		public void Start(object arg)
		{
			if (TwoPlayerUserControl.OneIsCompleted)
			{
				if (GeneralObject.OutGame)
					GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
			}
			else
			{
				TwoPlayerUserControl.OneIsCompleted = true;
			}
		}


		public ICommand SetQuantity { get; set; }
		public ICommand SetChoose1 { get; set; }
		public ICommand SetChoose2 { get; set; }
		public ICommand SetUpload { get; set; }

		public GameViewModel()
		{
			SetQuantity = new Command(ControlVisibilityFunction);
			SetChoose1 = new Command(ControlVisibilityFunction1);
			SetChoose2 = new Command(ControlVisibilityFunction2);
			StartPlay = new Command(Start);
			Set = new Command(function);
			SetUpload = new Command(SetUploadFunction);
		}
		public void SetUploadFunction(object arg)
		{
			uploadGame = arg.ToString();
		}
		public void ControlVisibilityFunction(object arg)
		{
			_quantity = arg.ToString();
		}
		public void ControlVisibilityFunction1(object arg)
		{
			_first = arg.ToString();
		}
		public void ControlVisibilityFunction2(object arg)
		{
			_second = arg.ToString();
		}
	}
}
