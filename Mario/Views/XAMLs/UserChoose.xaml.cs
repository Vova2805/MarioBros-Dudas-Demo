using Lab5_KPZ.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for UserChoose.xaml
	/// </summary>
	public partial class UserChoose : Page
	{
		public UserChoose()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			GeneralObject.GameFrame = GeneralObject.MainFrame;
			Two_Click(null,null);
            GeneralObject._gameViewModel._quantity = "One";
		}

		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			//e.Handled = true;
		}

		private void Two_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GeneralObject._gameViewModel.FirstPlayerSubmited = "false";
			GeneralObject._gameViewModel.SecondPlayerSubmited = "false";
		}
		
	}
}
