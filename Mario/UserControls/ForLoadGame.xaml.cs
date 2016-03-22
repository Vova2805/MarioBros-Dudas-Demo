using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Mediator1;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for ForLoadGame.xaml
	/// </summary>
	public partial class ForLoadGame : UserControl
	{
		public ForLoadGame()
		{
			InitializeComponent();
		}

		private void submit_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var player = GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(LoginField.Text) && p.password.Equals(PassworField.Password)).FirstOrDefault();
			if (player == null)
			{
				MessageBox.Show("There is no player with such parameter. Check your data and try again.");
			}
			else
			{
				GeneralObject._gameModel.FirstPlayer = player as RegisteredPlayer;
				GeneralObject._gameViewModel.FirstPlayer = player as RegisteredPlayer;
				GeneralObject._gameViewModel.SaveRestore = "Restore";
				GeneralObject.MainFrame.NavigationService.Navigate(new Uri(@"../../Views/XAMLs/SaveRestoreGame.xaml", UriKind.Relative));
				Mediator.MenuForPlayer =  GeneralObject._gameModel.FirstPlayer.Name;
            }
		}
	}
}
