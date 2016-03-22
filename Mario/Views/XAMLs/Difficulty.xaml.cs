using Lab5_KPZ.Models;
using Microsoft.Win32;
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

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for Difficulty.xaml
	/// </summary>
	public partial class Difficulty : Page
	{
		public Difficulty()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			Change(Easy);
		}

		private void Next_click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/UserChoose.xaml", UriKind.Relative));
		}

		private void Back_click(object sender, RoutedEventArgs e)
		{
			if (GeneralObject.OutGame)
				GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			else GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/GameMenu.xaml", UriKind.Relative));
		}

		void Change(Label instale_label)
		{
			Easy.Foreground = Brushes.White;
			Middle.Foreground = Brushes.White;
			Hard.Foreground = Brushes.White;
			instale_label.Foreground = Brushes.Red;
		}
		private void Easy_click(object sender, MouseButtonEventArgs e)
		{
			GeneralObject._gameModel.difficultyModel = Models.Difficulty.Easy;
			Change(Easy);
		}

		private void Middle_click(object sender, MouseButtonEventArgs e)
		{
			GeneralObject._gameModel.difficultyModel = Models.Difficulty.Middle;
			Change(Middle);
		}

		private void Hard_click(object sender, MouseButtonEventArgs e)
		{
			GeneralObject._gameModel.difficultyModel = Models.Difficulty.Hard;
			Change(Hard);
		}

		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void From_file_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFDl = new OpenFileDialog();
			openFDl.DefaultExt = ".dat";
			openFDl.Filter = "DAT documents (.dat)|*.dat";
			Nullable<bool> result = openFDl.ShowDialog();
			if (result == true)
			{
				try
				{
					GeneralObject._gameModel.CurrentLevel = Level.Load(openFDl.FileName);//upload game
					if (GeneralObject._gameModel.CurrentLevel == null) throw new Exception();
					GeneralObject._gameViewModel.uploadedSuccessfull = "true";
					GeneralObject._gameViewModel.uploadGame = "No";
				}
				catch (Exception e1)
				{
					MessageBox.Show("Error! Invalid file content!");
				}

			}
		}
	}
}
