using Lab5_KPZ.Base;
using Lab5_KPZ.Models;
using Lab5_KPZ.UserControls;
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

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for SettingsPage.xaml
	/// </summary>
	public partial class SettingsPage : Page
	{
		public SettingsPage()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
		}

		private void SettingsPage_OnKeyDown(object sender, KeyEventArgs e)
		{
			//MessageBox.Show("SetPage " + e.Key);
			//e.Handled = true;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (GeneralObject.OutGame)
				GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			else GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/GameMenu.xaml", UriKind.Relative));
		}

		private void Reset_Click(object sender, RoutedEventArgs e)
		{
			GeneralObject._gameModel.FirstSettings.commands = (Dictionary<string,Key>)Mapping.Clone(GeneralObject.OriginalSettings.FirstUser.commands);
			GeneralObject._gameModel.SecondSettings.commands = (Dictionary<string, Key>)Mapping.Clone(GeneralObject.OriginalSettings.SecondUser.commands);
			SettingsTwo.Style.SelectedIndex = GeneralObject.OriginalSettings.Style;
			SettingsTwo.PlayList.SelectedIndex = GeneralObject.OriginalSettings.Sound;
			SettingsTwo.ClrPcker_Background.SelectedColor = Color.FromRgb(GeneralObject.OriginalSettings.BorderColor.R, GeneralObject.OriginalSettings.BorderColor.G, (GeneralObject.OriginalSettings.BorderColor.B));
			SettingsTwo.SizeComboBox.SelectedIndex = GeneralObject.OriginalSettings.ScreenSize;
			SettingsForTwo.Assignment();
        }
	}
}
