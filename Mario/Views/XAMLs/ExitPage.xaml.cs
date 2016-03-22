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

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for ExitPage.xaml
	/// </summary>
	public partial class ExitPage : Page
	{
		public ExitPage()
		{
			InitializeComponent();
		}

		private void Yes_mouse_enter(object sender, MouseEventArgs e)
		{
			Mario_exit.Source = new BitmapImage(new Uri(@"../../Views/Source/Images/Mario/MarioCry.png", UriKind.Relative));
		}
		private void No_mouse_enter(object sender, MouseEventArgs e)
		{
			Mario_exit.Source = new BitmapImage(new Uri(@"../../Views/Source/Images/Mario/MarioHappy.png", UriKind.Relative));
		}

		private void Yes_click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown(0);
		}
		private void No_click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
		}

		private void ExitPage_OnKeyDown(object sender, KeyEventArgs e)
		{
			MessageBox.Show("Ex Page " + e.Key);
			e.Handled = true;
		}

		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}
	}
}
