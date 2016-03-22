using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Observer;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for HeaderControl.xaml
	/// </summary>
	public partial class HeaderControl : UserControl
	{
		public static TimeObserver timeObserver;
		public static List<Border> borders;
		public HeaderControl()
		{
			InitializeComponent();
			timeObserver = new TimeObserver(LevelTime);
			DataContext = GeneralObject._gameViewModel;
			borders = new List<Border>();
			borders.Add(border1);
			borders.Add(border2);
			borders.Add(border3);
		}
	}
}
