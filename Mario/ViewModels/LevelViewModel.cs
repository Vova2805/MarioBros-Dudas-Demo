using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models;

namespace Lab5_KPZ.ViewModels
{
	class LevelViewModel:ViewModelBase
	{
		private Difficulty _difficulty;
		private int _Time;
		private string _Number;
        private ObservableCollection<Map> _Maps;
		public Difficulty difficulty
		{
			get { return _difficulty; }
			set
			{
				_difficulty = value;
				OnPropertyChanged("difficulty");
			}
		}
		public int Time
		{
			get { return _Time; }
			set
			{
				_Time = value;
				OnPropertyChanged("Time");
			}
		}
		public string Number
		{
			get { return _Number; }
			set
			{
				_Number = value;
				OnPropertyChanged("Number");
			}
		}
	}
}
