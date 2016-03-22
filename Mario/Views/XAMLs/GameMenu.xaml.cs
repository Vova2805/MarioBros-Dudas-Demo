using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Mediator1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for GameMenu.xaml
	/// </summary>
	public partial class GameMenu : Page
	{
		public GameMenu()
		{
			InitializeComponent();
			GeneralObject.GameMenuVisible = true;
			DataContext = GeneralObject._gameViewModel;
			forPlayer.Content = "Menu for ";
			forPlayer.Content += Mediator.MenuForPlayer;
		}

		private void Go_to_main_menu(object sender, RoutedEventArgs e)
		{
			GeneralObject.MainFrame.Navigate("");
			GeneralObject.GameFrame = GeneralObject.MainFrame;
			GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			GeneralObject.GameMenuVisible = false;
			GeneralObject.OutGame = true;
			NewGame.onExit = true;
			GeneralObject._gameModel.CurrentLevel.Time = 0;
			GeneralObject._gameModel.CurrentLevel.Notify();
		}

		private void Score(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/Score.xaml", UriKind.Relative));
		}

		private void Settings_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/SettingsPage.xaml", UriKind.Relative));
		}

		private void Saved(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/SaveRestoreGame.xaml", UriKind.Relative));
		}
		private void Resume_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate("");
			GeneralObject.GameMenuVisible = false;
		}

		private void Menu_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		public static void Save()
		{
			if (Mediator.MenuForPlayer.Equals(GeneralObject._gameModel.FirstPlayer.Name))
			{
				if (GeneralObject._gameModel.FirstPlayer is RegisteredPlayer)
				{
					(GeneralObject._gameModel.FirstPlayer as RegisteredPlayer).InsertGame();
				}
				else
				{
					MessageBox.Show(string.Format("Unfortunately you,{0} ,can not save this game, because you are not registerd yet. Register first", GeneralObject._gameModel.FirstPlayer.Name));
				}
			}
			if (GeneralObject._gameModel.SecondPlayer != null)
				if (Mediator.MenuForPlayer.Equals(GeneralObject._gameModel.SecondPlayer.Name))
				{
					if (GeneralObject._gameModel.SecondPlayer is RegisteredPlayer)
					{
						(GeneralObject._gameModel.SecondPlayer as RegisteredPlayer).InsertGame();
					}
					else
					{
						MessageBox.Show(string.Format("Unfortunately you,{0} ,can not save this game, because you are not registerd yet. Register first", GeneralObject._gameModel.SecondPlayer.Name));
					}
				}
		}
		private void Save_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new Uri(@"../../Views/XAMLs/SaveRestoreGame.xaml", UriKind.Relative));
		}
	}
}
