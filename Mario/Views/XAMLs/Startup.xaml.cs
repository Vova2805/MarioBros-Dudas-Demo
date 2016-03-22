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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for Startup.xaml
	/// </summary>
	public partial class Startup : Page
	{
		public Startup()
		{
			InitializeComponent();
			GeneralObject.IsStartup = true;
		}

		private void Image_animation_completed(object sender, EventArgs e)
		{
			MediaPlayer MyPlayer = new MediaPlayer();
			MyPlayer.Open(new Uri(@"../../Views/Source/Sounds/clap.wav", UriKind.Relative));
			MyPlayer.Play();
		}

		private void GoToMenu(object sender, EventArgs e)
		{
			GeneralObject.GameFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			GeneralObject.IsStartup = false;
		}

		private void Startup_OnKeyDown(object sender, KeyEventArgs e)
		{
			DoubleAnimation dbAnimation = new DoubleAnimation(600,0,TimeSpan.FromSeconds(1));
			DoubleAnimation dbAnimation1 = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
			dbAnimation1.Completed += GoToMenu;
			flagImage.BeginAnimation(WidthProperty,dbAnimation);
			TextBl.BeginAnimation(OpacityProperty,dbAnimation1);
			e.Handled = true;
		}
	}
}
