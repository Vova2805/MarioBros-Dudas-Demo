using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Memento;

namespace Lab5_KPZ.ViewModels
{
	class RegisteredPlayerViewModel:ViewModelBase
	{
		
		
		private string _password;
		private Dictionary<DateTime, GameMemento> _PreviousGames;
		public string password {
			get { return _password; }
			set
			{
				_password = value;
				OnPropertyChanged("password");
			}
		}
		public Dictionary<DateTime, GameMemento> PreviousGames {
			get { return _PreviousGames; }
			set
			{
				_PreviousGames = value;
				OnPropertyChanged("PreviousGames");
			}
		}
	}
}
