using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab5_KPZ.Models;
using Lab5_KPZ.ViewModels;
using AutoMapper;

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for First.xaml
	/// </summary>
	public partial class First : UserControl
	{
		public First()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
		}

		private void First_submit_click(object sender, RoutedEventArgs e)
		{
			switch (GeneralObject._gameViewModel._first)
			{
				case "R":
					{
						var player = GeneralObject._DataModel.Players.Where(p => p.Name.Equals(RegistrationUserControl.login_field.Text) && p.password.Equals(RegistrationUserControl.password_field.Password))
				 .FirstOrDefault();
						if(player!=null)
						{
							MessageBox.Show("There is olready registered player with such data. Try another data!");
						}
						else
						if (RegistrationUserControl.password_field.Password.Equals(RegistrationUserControl.password_field.Password) && !RegistrationUserControl.password_field.Password.Equals(""))
						{
							GeneralObject._gameModel.FirstPlayer = new RegisteredPlayer(RegistrationUserControl.login_field.Text, RegistrationUserControl.password_field.Password);
							
							GeneralObject._DataViewModel.Players.Add(GeneralObject._gameModel.FirstPlayer as RegisteredPlayer);

							RegistrationUserControl.Grid.Visibility = Visibility.Collapsed;
							GeneralObject._gameViewModel.FirstPlayerSubmited = "true";//Congratulation


							if (GeneralObject._gameViewModel._quantity.Equals("One"))
							{
								GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
							}
							else
							{
								if (TwoPlayerUserControl.OneIsCompleted)
								{
									GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
								}
								else
								{
									TwoPlayerUserControl.OneIsCompleted = true;
								}
							}
						}
						else
						{
							MessageBox.Show("Passwords aren't matched");
						}
					}
					break;
				case "S":
					{
						
						   var player = GeneralObject._DataModel.Players.Where(p => p.Name.Equals(SignInUserControl.LoginField.Text) && p.password.Equals(SignInUserControl.PassworField.Password))
				  .FirstOrDefault();
						if (player == null)
						{
							MessageBox.Show("There is no player with such parameter. Check your data and try again.");
						}
						else
						{
							GeneralObject._gameViewModel.FirstPlayerSubmited = "true";//Congratulation
							GeneralObject._gameModel.FirstPlayer = player;

							if (GeneralObject._gameViewModel._quantity.Equals("One"))
							{
								GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
							}
							else
							{
								if (TwoPlayerUserControl.OneIsCompleted)
								{
									GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
								}
								else
								{
									TwoPlayerUserControl.OneIsCompleted = true;
								}
							}
						}
					}
					break;
				default:
					MessageBox.Show("Error in first user control!");
					break;
			}
			GeneralObject._gameViewModel.FirstPlayer = GeneralObject._gameModel.FirstPlayer;
		}

		private void First_start_playing(object sender, RoutedEventArgs e)
		{
			if (!GeneralObject._gameViewModel._quantity.Equals("One"))
				GeneralObject._gameViewModel.FirstPlayerSubmited = "true";//Congratulation
			else
			{
				GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
			}
			GeneralObject._gameViewModel.FirstPlayer = new Player("Player1");
			GeneralObject._gameModel.FirstPlayer = GeneralObject._gameViewModel.FirstPlayer;
		}
	}
}
