using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models;
using System.Windows.Input;
using WpfApplication.ViewModel;

namespace Lab5_KPZ.ViewModels
{
	public class DataViewModel:ViewModelBase
	{
		public ObservableCollection<RegisteredPlayer> Players { get; set; }
	}
}
