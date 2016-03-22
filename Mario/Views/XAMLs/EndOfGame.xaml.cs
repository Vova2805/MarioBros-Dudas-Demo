using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Facade;
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

namespace Lab5_KPZ.Views.XAMLs
{
	/// <summary>
	/// Interaction logic for EndOfGame.xaml
	/// </summary>
	public partial class EndOfGame : Page
	{
		public EndOfGame()
		{
			InitializeComponent();
			DataContext = GeneralObject._gameViewModel;
			DoubleAnimation dbAnimation = new DoubleAnimation(0, 200, TimeSpan.FromSeconds(1));
			Won.BeginAnimation(WidthProperty, dbAnimation);
			GameOver.BeginAnimation(HeightProperty, dbAnimation);
			if(GeneralObject._gameViewModel.isWon.Equals("Yes"))
			{
				GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/win_stage.wav", PlayingType.original);
				Won.BeginAnimation(WidthProperty, dbAnimation);
				Won.BeginAnimation(HeightProperty, dbAnimation);
			}
			else
			{
				GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/chooseagame.wav", PlayingType.original);
				GameOver.BeginAnimation(WidthProperty, dbAnimation);
				GameOver.BeginAnimation(HeightProperty, dbAnimation);
			}
		}

		private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if(GeneralObject._gameModel.isWon.Equals("No"))
               {
				GeneralObject.GameFrame.NavigationService.Navigate("");
				GeneralObject.MainFrame.Navigate("");
				GeneralObject.GameFrame = GeneralObject.MainFrame;
				GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
				GeneralObject.GameMenuVisible = false;
				GeneralObject.OutGame = true;
				GeneralObject.Path = string.Format("Level{0}.dat",1);
				NewGame.MyTimer.Stop();
			  }
			else
			{
				GeneralObject.Path = string.Format("Level{0}.dat", GeneralObject._gameModel.CurrentLevel.Number+1);
				GeneralObject._gameModel.CurrentLevel = Level.Load(GeneralObject.Path);
				if(GeneralObject._gameModel.CurrentLevel!=null)
				{
					GeneralObject._gameModel.CurrentLevel.Load(NewGame.gameCanvas, NewGame.background, NewGame.MainStackPanel);
				}
			}
            
		}
	}
}
