using Lab5_KPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for WindowBackground.xaml
	/// </summary>
	public partial class WindowBackground : Window
	{
		public static bool FirstTime = true;
		public static Image background;
		public WindowBackground()
		{
			InitializeComponent();
			GeneralObject.GameFrame = MyFrame;
			GeneralObject.MainFrame = MyFrame;
			background = BackgroundImage;
		}
		private void WindowBackground_OnKeyDown(object sender, KeyEventArgs e)
		{
			//MessageBox.Show(e.Key.ToString());
			if(e.Key.Equals(Key.Escape) && GeneralObject.OutGame)
			{
				GeneralObject.MainFrame.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
			}
			if (!GeneralObject.OutGame)
			{
				GeneralObject.Mediator.moving_manager.AddNew(e.Key);
			}
		}
		private void MainWindow_KeyUp(object sender, KeyEventArgs e)
		{
		}
	}
}
