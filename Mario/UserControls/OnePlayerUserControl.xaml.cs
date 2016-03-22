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
	/// Interaction logic for OnePlayerUserControl.xaml
	/// </summary>
	public partial class OnePlayerUserControl : UserControl
	{
		public OnePlayerUserControl()
		{
			InitializeComponent();
		}

		private void Start_click(object sender, RoutedEventArgs e)
		{
			GeneralObject._gameModel.FirstPlayer = new Player("Player");
			GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
		}

		//private void One_player_click(object sender, RoutedEventArgs e)
		//{
		//	switch (GeneralObject._gameViewModel._first)
		//	{
		//		case "R":
		//			{
		//				if (RegistrationUserControl.password_field.Password.Equals(RegistrationUserControl.password_field.Password) && !RegistrationUserControl.password_field.Password.Equals(""))
		//				{
		//					GeneralObject._DataViewModel.Players.Add(new RegisteredPlayer(RegistrationUserControl.login_field.Text, RegistrationUserControl.password_field.Password));
		//					RegistrationUserControl.Grid.Visibility = Visibility.Collapsed;
							

		//					GeneralObject._gameModel.FirstPlayer = new RegisteredPlayer(RegistrationUserControl.login_field.Text,RegistrationUserControl.password_field.Password);


		//					GeneralObject.CurrentFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
		//				}
		//				else
		//				{
		//					MessageBox.Show("Passwords aren't matched");
		//				}
		//			}
		//			break;
		//		case "S":
		//			{

		//				var player = GeneralObject._DataViewModel.Players.Where(p => p.Name.Equals(SignInUserControl.LoginField.Text) && p.password.Equals(SignInUserControl.PassworField.Password))
		//	   .FirstOrDefault();
		//				if (player == null)
		//				{
		//					MessageBox.Show("There is no player with such parameter. Check your data and try again.");
		//				}
		//				else
		//				{
		//					GeneralObject._gameModel.FirstPlayer = new RegisteredPlayer(SignInUserControl.LoginField.Text, SignInUserControl.PassworField.Password);
		//					GeneralObject.CurrentFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/NewGame.xaml", UriKind.Relative));
		//				}
		//			}
		//			break;
		//		default:
		//			MessageBox.Show("Error in oneplayer user control!");
		//			break;
		//	}
		//}
	}
}
