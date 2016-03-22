using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Observer;
using System.Windows.Controls;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for LuigiControl.xaml
	/// </summary>
	public partial class LuigiControl : UserControl
	{
		public static LuigiObserver luigiObserver;
		public LuigiControl()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			luigiObserver = new LuigiObserver(LuigiLife,LuigiPoints,LuigiCoins);
			DataContext = GeneralObject._gameViewModel;
		}
	}
}
