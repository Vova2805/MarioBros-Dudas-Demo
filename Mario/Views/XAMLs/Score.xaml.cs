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
using Lab5_KPZ.Base;
using Lab5_KPZ.Models;
using Lab5_KPZ.ViewModels;
using AutoMapper;

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for Score.xaml
	/// </summary>
	public partial class Score : Page
	{
		public Score()
		{
			InitializeComponent();
			DataContext = GeneralObject._DataViewModel;
		}

		private void Go_click(object sender, RoutedEventArgs e)
		{
			if(GeneralObject.OutGame)
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			else GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/GameMenu.xaml", UriKind.Relative));
		}
	}
}
