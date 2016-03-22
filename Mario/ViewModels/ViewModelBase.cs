using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.ViewModels
{
		/// <summary>
		/// Provides common functionality for ViewModel classes
		/// </summary>
		public abstract class ViewModelBase : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;

			protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
			{
				if (PropertyChanged != null)
				{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
}
