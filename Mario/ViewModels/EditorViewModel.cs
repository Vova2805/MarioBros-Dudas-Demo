using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.ViewModel;

namespace Lab5_KPZ.ViewModels
{
	public class EditorViewModel:ViewModelBase
	{
		private string _ControlType;

		public string ControlType
		{
			get { return _ControlType; }
			set
			{
				_ControlType = value;
				OnPropertyChanged("ControlType");
			}
		}
		public ICommand SetControlType { get; set; }

		EditorViewModel()
		{
			SetControlType = new Command(ControlVisibilityFunction);
		}
		public void ControlVisibilityFunction(object arg)
		{
			ControlType = arg.ToString();
		}
	}
}
