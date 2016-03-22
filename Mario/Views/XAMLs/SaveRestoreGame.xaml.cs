using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Mediator1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for SaveRestoreGame.xaml
	/// </summary>
	public partial class SaveRestoreGame : Page
	{
		public static StackPanel main;
		public Player currentPlayer { get; set; }
        public SaveRestoreGame()
		{
			InitializeComponent();
			if(Mediator.MenuForPlayer.Equals(GeneralObject._gameModel.FirstPlayer.Name))
			currentPlayer = GeneralObject._gameViewModel.FirstPlayer;
			else if (GeneralObject._gameModel.SecondPlayer!=null)
				if(Mediator.MenuForPlayer.Equals(GeneralObject._gameModel.SecondPlayer.Name))
				currentPlayer = GeneralObject._gameViewModel.SecondPlayer;
			DataContext = GeneralObject._gameViewModel;
			if(currentPlayer is RegisteredPlayer)
			{
				PreviousGame.ItemsSource = (currentPlayer as RegisteredPlayer).PreviousGames;
				if (GeneralObject._gameViewModel.SaveRestore.Equals("Save"))
				{
					var animation = new DoubleAnimation();
					animation.From = 0;
					animation.To = 1;
					animation.Duration = new Duration(TimeSpan.FromSeconds(2));
					animation.AutoReverse = true;
					SaveRestore.BeginAnimation(OpacityProperty, animation);
					GameMenu.Save();
				}
			}
			else
			{
				GeneralObject.GameFrame.NavigationService.Navigate("");
				System.Windows.MessageBox.Show(string.Format("Unfortunately you,{0} ,can not save this game, because you are not registerd yet. Register first", GeneralObject._gameModel.FirstPlayer.Name));
				GeneralObject.MainWindow.Focus();
			}
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			if(GeneralObject.OutGame)
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/Difficulty.xaml", UriKind.Relative));
			else
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/GameMenu.xaml", UriKind.Relative));
		}
		private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			System.Windows.Controls.DataGrid dataGrid = PreviousGame;
			DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
			System.Windows.Controls.DataGridCell RowAndColumn = (System.Windows.Controls.DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
			string myDate = ((TextBlock)RowAndColumn.Content).Text;
			if(GeneralObject.OutGame)
			{
				GeneralObject._gameModel.CurrentLevel = (currentPlayer as RegisteredPlayer).PreviousGames[myDate]._state;
				Close_Click(null,null);
				GeneralObject._gameViewModel.uploadedSuccessfull = "true";
				GeneralObject._gameViewModel.uploadGame = "No";
			}
			else
			(GeneralObject._gameModel.FirstPlayer as RegisteredPlayer).LoadGame(myDate);
		}
	}
}
