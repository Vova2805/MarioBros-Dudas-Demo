using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Flyweight;
using Lab5_KPZ.Models.Strategy;
using System.Linq;
using Lab5_KPZ.Base;
using System.Drawing;

namespace Lab5_KPZ
{
	/// <summary>
	/// Interaction logic for NewGame.xaml
	/// </summary>
	public partial class NewGame : Page
	{
		public static Canvas gameCanvas;
		public static System.Windows.Controls.Image background;
		public static Frame gameFrame;
		public static StackPanel MainStackPanel;
		public static ScrollViewer Scroll;
		public static bool onExit = false;
		public static DispatcherTimer MyTimer = new DispatcherTimer(DispatcherPriority.Background,Dispatcher.CurrentDispatcher);
		bool Direction = false;
		public NewGame()
		{
			try
			{
				InitializeComponent();
				System.Windows.Controls.Image Background = new System.Windows.Controls.Image();
				Background.Name = "Background";
				Background.Stretch = System.Windows.Media.Stretch.Fill;
				Background.HorizontalAlignment = HorizontalAlignment.Left;
				Background.VerticalAlignment = VerticalAlignment.Stretch;
				Background.Width = 1000;
				gameFrame = GameFrame;
				MainStackPanel = StackPanel;
				gameCanvas = Mario_canvas;
				Scroll = GameScroll;

				background = Background;
				Mario_canvas.Children.Clear();
				Map.FillingBackground(StackPanel, gameCanvas, Background);
				if (GeneralObject._gameModel.CurrentLevel == null || GeneralObject._gameModel.CurrentLevel.Time == 0)
					GeneralObject._gameModel.CurrentLevel = Level.Load(GeneralObject.Path);
				GeneralObject._gameModel.SaveRestore = "Save";
				GeneralObject._gameModel.CurrentLevel.difficulty = GeneralObject._gameModel.difficultyModel;
				GeneralObject._gameModel.CurrentLevel.Load(gameCanvas, background, MainStackPanel);
				GeneralObject._gameModel.CurrentLevel._Mario.Start(new FallStrategy());
				if (GeneralObject._gameViewModel._quantity.Equals("Two"))
					GeneralObject._gameModel.CurrentLevel._Luigi.Start(new FallStrategy());
				GeneralObject.GameFrame = GameFrame;
				GeneralObject.OutGame = false;
				GeneralObject.MarioStartPosition = (PointF)Mapping.Clone(GeneralObject._gameModel.CurrentLevel._Mario.Position);
				GeneralObject.LuigiStartPosition = (PointF)Mapping.Clone(GeneralObject._gameModel.CurrentLevel._Luigi.Position);

				//Initialize background
				MyTimer.Interval = TimeSpan.FromMilliseconds(500);
				MyTimer.Tick += dispatcherTimer_Tick;
				MyTimer.Start();
			}
            catch(Exception exc)
			{
				MessageBox.Show("Error during uploading new level. Check path and try again!");
			}
		}
		
		public void MarioAnimation(System.Windows.Controls.Image hero)
		{
			var StartY =Canvas.GetTop(hero);
			var EndY = 620- hero.Height;
			var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromSeconds(5));
			hero.BeginAnimation(Canvas.TopProperty, AnimationY);
		}

		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}
		private void EnemiesMovements()
		{
			for(int i = 0;i< GeneralObject._gameModel.CurrentLevel._Maps[GeneralObject._gameModel.CurrentLevel.currentMap].Enemies.Count;i++)
			{
				var enemy = GeneralObject._gameModel.CurrentLevel._Maps[GeneralObject._gameModel.CurrentLevel.currentMap].Enemies[i];
                IStrategy MyStrategy = new FallStrategy();
				var temp = MapUnit.CheckOut(Canvas.GetLeft(enemy.ImageController), Canvas.GetTop(enemy.ImageController) + enemy.ImageController.Height + 30,
					GeneralObject._gameModel.CurrentLevel, MyStrategy);
                if (temp == null )
				{
					MyStrategy = new FallStrategy();
				}else
				{
					if(Canvas.GetTop(enemy.ImageController) + enemy.ImageController.Height < temp.Position.Y)
						MyStrategy = new FallStrategy();
					else
						MyStrategy = new MoveStrategy();
				}
				if((Canvas.GetTop(enemy.ImageController)+enemy.ImageController.Height+20)>=(StackPanel.Height))
				{
					NewGame.gameCanvas.Children.Remove(enemy.ImageController);
					GeneralObject._gameModel.CurrentLevel._Maps[GeneralObject._gameModel.CurrentLevel.currentMap].Enemies.Remove(enemy);
                }else
				MyStrategy.Move(enemy,(enemy as Enemy).CurrentDirection,null);
			}
		}
		public bool decrease = false;
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (GeneralObject._gameModel.CurrentLevel.Time > 0)
			{
				if(decrease)
				{
					GeneralObject._gameModel.CurrentLevel.Time--;
					GeneralObject._gameModel.CurrentLevel.Notify();
				}
				decrease = !decrease;
				EnemiesMovements();
			}
			else
			{
				if(!onExit)
				MessageBox.Show("End of game");
				onExit = false;
				GameModel.SaveResults();
                GeneralObject.MainFrame.Navigate("");
				GeneralObject.GameFrame = GeneralObject.MainFrame;
				GeneralObject.MainFrame.NavigationService.Navigate(new System.Uri(@"../../Views/XAMLs/MenuPage.xaml", UriKind.Relative));
				GeneralObject.GameMenuVisible = false;
				GeneralObject.OutGame = true;
				MyTimer.Stop();
			}
		}
		private void Page_KeyUp(object sender, KeyEventArgs e)
		{
			
			e.Handled = true;
		}
		
		private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			GameFrame.Margin = new Thickness(GameScroll.HorizontalOffset + 600,0,0,0);
		}
	}
}
