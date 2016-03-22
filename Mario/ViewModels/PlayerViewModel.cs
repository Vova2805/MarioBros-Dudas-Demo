using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.ViewModels
{
	class PlayerViewModel:ViewModelBase
	{
		private string _name;
		private int _level;
		private int _score;
		private int _coins;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
		public int Score
		{
			get { return _score; }
			set
			{
				_score = value;
				OnPropertyChanged("Score");
			}
		}
		public int Coins
		{
			get { return _coins; }
			set
			{
				_coins = value;
				OnPropertyChanged("Coins");
			}
		}
		public int Level
		{
			get { return _level; }
			set
			{
				_level = value;
				OnPropertyChanged("Level");
			}
		}
	}
}
