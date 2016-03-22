using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Lab5_KPZ.Views.XAMLs;
using Lab5_KPZ.Models;

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for MenuPage.xaml
	/// </summary>
	public partial class MenuPage : Page
	{

		public MenuPage()
		{
			InitializeComponent();
		}
		private void Quit_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/ExitPage.xaml", UriKind.Relative));
		}

		private void Settings_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/SettingsPage.xaml", UriKind.Relative));
		}

		private void NewGame_click(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/Difficulty.xaml", UriKind.Relative));
		}

		private void MenuPage_OnKeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}
		private void View_score(object sender, RoutedEventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/Score.xaml", UriKind.Relative));
		}
		private void CreateMap_click(object sender, RoutedEventArgs e)
		{
			if (GeneralObject.Editor == null)
				GeneralObject.Editor = new MapEditor();
			GeneralObject.Editor.Show();
		}
	}
}
