using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.ViewModels
{
	class LuigiViewModel:ViewModelBase
	{
		private int _LifeCount;
		private int _CoinsQuantity;
		private int _Score;
		public int LifeCount
		{
			get { return _LifeCount; }
			set
			{
				_LifeCount = value;
				OnPropertyChanged("LifeCount");
			}
		}
		public int CoinsQuantity
		{
			get { return _CoinsQuantity; }
			set
			{
				_CoinsQuantity = value;
				OnPropertyChanged("CoinsQuantity");
			}
		}
		public int Score
		{
			get { return _Score; }
			set
			{
				_Score = value;
				OnPropertyChanged("Score");
			}
		}
	}
}
