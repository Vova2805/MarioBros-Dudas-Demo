using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Classes;

namespace Lab5_KPZ.ViewModels
{
	class MapViewModel:ViewModelBase
	{
		public Mario Mario;
		public Luigi Luigi;

		public Mario _Mario
		{
			get { return Mario; }
			set
			{
				Mario = value;
				OnPropertyChanged("_Mario");
			}
		}
		public Luigi _Luigi
		{
			get { return Luigi; }
			set
			{
				Luigi = value;
				OnPropertyChanged("_Luigi");
			}
		}
	}
}
