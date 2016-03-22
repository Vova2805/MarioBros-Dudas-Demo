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

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for Second.xaml
	/// </summary>
	public partial class Second : UserControl
	{
		public Second()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
		}

		private void Second_submit_click(object sender, RoutedEventArgs e)
		{
			switch (GeneralObject._gameViewModel._second)
			{
				case "R":
					{
						var player = GeneralObject._DataModel.Players.Where(p => p.Name.Equals(RegistrationUserControl.login_field.Text) && p.password.Equals(RegistrationUserControl.password_field.Password))
				 .FirstOrDefault();
						if (player != null)
						{
							MessageBox.Show("There is olready registered player with such data. Try another data!");
						}
						else
						if (RegistrationUserControl.password_field.Password.Equals(RegistrationUserControl.password_field.Password) && !RegistrationUserControl.password_field.Password.Equals(""))
						{
							GeneralObject._gameModel.SecondPlayer = new RegisteredPlayer(RegistrationUserControl.login_field.Text, RegistrationUserControl.password_field.Password);

							GeneralObject._DataViewModel.Players.Add(GeneralObject._gameModel.SecondPlayer as RegisteredPlayer);

							RegistrationUserControl.Grid.Visibility = Visibility.Collapsed;
							GeneralObject._gameViewModel.SecondPlayerSubmited = "true";//Congratulation


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
							GeneralObject._gameViewModel.SecondPlayerSubmited = "true";//Congratulation
							GeneralObject._gameModel.SecondPlayer = player;

							GeneralObject._DataViewModel.Players.Add(GeneralObject._gameModel.SecondPlayer as RegisteredPlayer);
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
					MessageBox.Show("Error in second user control!");
					break;
			}
			GeneralObject._gameViewModel.SecondPlayer = GeneralObject._gameModel.SecondPlayer;
		}

		private void Second_start_playing(object sender, RoutedEventArgs e)
		{
			GeneralObject._gameViewModel.SecondPlayerSubmited = "true";//Congratulation
			GeneralObject._gameViewModel.SecondPlayer = new Player("Player2");
			GeneralObject._gameModel.SecondPlayer = GeneralObject._gameViewModel.SecondPlayer;

			if(GeneralObject._gameViewModel.FirstPlayerSubmited.Equals("true"))
			{
				GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
			}
		}
	}
}
