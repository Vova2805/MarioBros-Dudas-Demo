using Lab5_KPZ.Models;
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

namespace Lab5_KPZ.UserControls
{
	/// <summary>
	/// Interaction logic for ControlSettings.xaml
	/// </summary>
	public partial class ControlSettings : UserControl
	{
		public TextBox text_box = null;
		public ControlSettings()
		{
			InitializeComponent();
		}

		private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
			text_box = sender as TextBox;
			text_box.Background = Brushes.Red;
		}

		private void UserControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (text_box != null)
			{
				//text_box.Text = e.Key.ToString();
				if (SettingsForTwo.SecondClicked)
					GeneralObject._gameModel.SecondSettings.commands[text_box.Name] = e.Key;
				else
					GeneralObject._gameModel.FirstSettings.commands[text_box.Name] = e.Key;
				SettingsForTwo.Assignment();
			}
		}
		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if(textBox != null)
				textBox.Background = Brushes.White;
		}
	}
}
