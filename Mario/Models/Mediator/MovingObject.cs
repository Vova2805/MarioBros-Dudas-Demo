using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Flyweight;
using Lab5_KPZ.Models.Strategy;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Lab5_KPZ.Models.Facade
{
	[Serializable]
	public abstract class MovingObject:MapUnit
	{
		public int LifeCount { get; set; }
		public int CoinsQuantity { get; set; }
		public int Score { get; set; }
		protected int BonusNumber { get; set; }
		protected bool ShootAbility { get; set; }
		protected bool SwimAbility { get; set; }
		protected bool FlyAbility { get; set; }
		public bool Direction { get; set; }
		[NonSerialized]
		public DispatcherTimer timer;
		[NonSerialized]
		public IStrategy Strategy = new FallStrategy();
		public enum Speed
		{
			ordinary,
			fast
		}
		public bool isFalling = false;
		virtual public void Run(Speed speed, bool direction)
		{
			var StartX = Canvas.GetLeft(ImageController);
			var EndX = StartX + 30*(direction ? 1 : -1);
			
			
			double step = EndX;
			if (direction) step = EndX + ImageController.Width;
			var temp = CheckOut(step, Canvas.GetTop(ImageController) + GeneralObject.cellSize.Y / 2, GeneralObject._gameModel.CurrentLevel, new MoveStrategy());
			if (temp != null)
			{
				if (temp is Block)
				{
					switch((temp as Block).BlockType)
					{
						case "Gate": {
								GeneralObject._gameViewModel.isWon = "Yes";
								GeneralObject.GameFrame.Navigate(new Uri(@"../../Views/XAMLs/EndOfGame.xaml", UriKind.Relative));
								GameModel.SaveResults();
							} break;
					}
				}else if(temp is Enemy)
				{
					if((Canvas.GetLeft(temp.ImageController)+temp.ImageController.Width)>Canvas.GetLeft(ImageController)||
						(Canvas.GetLeft(temp.ImageController)< Canvas.GetLeft(ImageController)+ImageController.Width))
                        {
						this.Die();
					    }
				}
				else if(temp is Bonus)
				{
					if (this is Mario)
					{
						GeneralObject._gameModel.CurrentLevel._Mario.Score += 1000;
						GeneralObject._gameModel.CurrentLevel._Mario.Notify();
						GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/mario_bravo.wav", PlayingType.original);
					}
					else if(this is Luigi)
					{
						GeneralObject._gameModel.CurrentLevel._Luigi.Score += 1000;
						GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
						GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/luigi_bravo.wav", PlayingType.original);
					}
					GeneralObject._gameModel.CurrentLevel._Maps[0].Bonuses.Remove(temp);
					NewGame.gameCanvas.Children.Remove(temp.ImageController);
				}else if (temp is Coin)
				{
					GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/coin.wav", PlayingType.original);
					if (this is Mario)
					{
						GeneralObject._gameModel.CurrentLevel._Mario.Score += (temp as Coin).capacity;
						GeneralObject._gameModel.CurrentLevel._Mario.CoinsQuantity++;
						GeneralObject._gameModel.CurrentLevel._Mario.Notify();
					}
					else
					{
						GeneralObject._gameModel.CurrentLevel._Luigi.Score += (temp as Coin).capacity;
						GeneralObject._gameModel.CurrentLevel._Luigi.CoinsQuantity++;
						GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
					}
					GeneralObject._gameModel.CurrentLevel._Maps[0].Coins.Remove(temp);
					NewGame.gameCanvas.Children.Remove(temp.ImageController);
				}
			}
			var AnimationX = new DoubleAnimation(StartX, EndX, TimeSpan.FromSeconds(1));
			ImageController.BeginAnimation(Canvas.LeftProperty, AnimationX);
			if (!isFalling)
			{
				Fall();
			}
			if(this is Mario)
			{
				int scroll;
				if (Canvas.GetLeft(GeneralObject._gameModel.CurrentLevel._Mario.ImageController) - NewGame.Scroll.HorizontalOffset > 600)
				{
					Strategy = new FallStrategy();
					DispatcherTimer timer1 = new DispatcherTimer();
					timer1.Interval = TimeSpan.FromMilliseconds(500);
					timer1.Tick += (sender, e) => 
					{
						NewGame.Scroll.ScrollToHorizontalOffset(NewGame.Scroll.HorizontalOffset+5);
						if (Canvas.GetLeft(GeneralObject._gameModel.CurrentLevel._Mario.ImageController) - NewGame.Scroll.HorizontalOffset < 300)
							timer1.Stop();
					};
					timer1.Start();
				}
					
			}
			
		}
		virtual public void JumpUp(double height,bool direction)
		{
			isFalling = true;
			if (MapUnit.CheckOut(Canvas.GetLeft(ImageController), 
				Canvas.GetTop(ImageController)+ImageController.Height+1, GeneralObject._gameModel.CurrentLevel, new FallStrategy())!=null)
			{
				var StartY = Canvas.GetTop(ImageController);
				var EndY = StartY - height;
				GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(),playingCommand.play, @"../../Views/Source/Sounds/jump.wav",PlayingType.original);
				var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromSeconds(1));
				AnimationY.Completed +=
				(sender1, e1) =>
				{
					Fall();
                };
				ImageController.BeginAnimation(Canvas.TopProperty, AnimationY);
			}
		}
		public void Fall()
		{
			Strategy = new FallStrategy();
			dispatcherTimer_Tick(null, null);
			if (timer == null)
			{
				timer = new DispatcherTimer();
				timer.Interval = TimeSpan.FromMilliseconds(10);
				timer.Tick += dispatcherTimer_Tick;
			}
			timer.Start();
		}
		public void Start(IStrategy strategy)
		{
			Strategy = strategy;
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(500);
			timer.Tick += dispatcherTimer_Tick;
			timer.Start();
		}
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (Strategy.Move(this, Direction, timer))
			{
			timer.Stop();
			isFalling = false;
			}
				
		}
		virtual public void Seat(MapUnit Unit, bool direction)
		{
			if (this is Mario)
				ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Mario/MarioSleept.png");
			if (this is Luigi)
				ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Luigi/Luigi.png");
		}
		virtual public void Shoot(MapUnit Unit, bool direction)
		{
			int direct = direction ? 1 : -1;
			var StartX = Canvas.GetLeft(Unit.ImageController);
			var EndX = StartX+300;
			var StartY = Canvas.GetTop(Unit.ImageController) - Unit.ImageController.DesiredSize.Height/2;
			var EndY =  Canvas.GetTop(Unit.ImageController);
			var AnimationX = new DoubleAnimation(StartX, EndX, TimeSpan.FromSeconds(20));
			var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromSeconds(2));
			AnimationY.Completed += (object sender, EventArgs e) =>
			{
				var Animation1 = new DoubleAnimation(EndY, EndY+ Unit.ImageController.DesiredSize.Height, TimeSpan.FromSeconds(4));
			};
		}
		virtual public void Die()
		{
			if (this is Mario)
			{
				ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Mario/MarioSleept.png");
				GeneralObject._gameModel.CurrentLevel._Mario.timer.Stop();
			}else
			if (this is Luigi)
			{
				ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Luigi/Luigi.png");
				GeneralObject._gameModel.CurrentLevel._Luigi.timer.Stop();
			}
			var StartY = Canvas.GetTop(ImageController);
			var EndY = StartY - 150;
			var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromSeconds(3));
			AnimationY.Completed += (sender,e) => {
				if (this is Mario)
				{
					if (--GeneralObject._gameModel.CurrentLevel._Mario.LifeCount > 0)
					{
						GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/mario_mamamia.wav", PlayingType.original);
						var StartY1 = Canvas.GetTop(ImageController);
						var EndY1 = GeneralObject.MarioStartPosition.Y;
						var StartX1 = Canvas.GetLeft(ImageController);
						var EndX1 = GeneralObject.MarioStartPosition.X;
						var AnimationY1 = new DoubleAnimation(StartY1, EndY1, TimeSpan.FromMilliseconds(1));
						var AnimationX1 = new DoubleAnimation(StartX1, EndX1, TimeSpan.FromMilliseconds(1));
						ImageController.BeginAnimation(Canvas.TopProperty, AnimationY1);
						ImageController.BeginAnimation(Canvas.TopProperty, AnimationX1);

						ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Mario/NormRight.png");
						Position = UnitImagesFactory.GetPosition(GeneralObject.MarioStartPosition.X, GeneralObject.MarioStartPosition.Y);
						GeneralObject._gameModel.CurrentLevel._Mario.Start(new FallStrategy());
					}
					else
					{
						ImageController.Visibility = System.Windows.Visibility.Hidden;
					}
					if (GeneralObject._gameModel.CurrentLevel._Mario.LifeCount >= 0)
						GeneralObject._gameModel.CurrentLevel._Mario.Notify();
				}
				else
			if (this is Luigi)
				{
					if (--GeneralObject._gameModel.CurrentLevel._Luigi.LifeCount > 0)
					{
						GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/luigi_mamamia.wav", PlayingType.original);
						var StartY1 = Canvas.GetTop(ImageController);
						var EndY1 = GeneralObject.LuigiStartPosition.Y;
                        var StartX1 = Canvas.GetLeft(ImageController);
						var EndX1 = GeneralObject.LuigiStartPosition.X;
                        var AnimationY1 = new DoubleAnimation(StartY1, EndY1, TimeSpan.FromMilliseconds(1));
						var AnimationX1 = new DoubleAnimation(StartX1, EndX1, TimeSpan.FromMilliseconds(1));
						ImageController.BeginAnimation(Canvas.TopProperty, AnimationY1);
						ImageController.BeginAnimation(Canvas.TopProperty, AnimationX1);
						ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Luigi/luigi_game.png");
						Position = UnitImagesFactory.GetPosition(GeneralObject.LuigiStartPosition.X, GeneralObject.LuigiStartPosition.Y);
						GeneralObject._gameModel.CurrentLevel._Luigi.Start(new FallStrategy());
					}
					else
					{
						ImageController.Visibility = System.Windows.Visibility.Hidden;
					}
					if (GeneralObject._gameModel.CurrentLevel._Luigi.LifeCount >= 0)
						GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
				}
				if (GeneralObject._gameModel.CurrentLevel._Mario.LifeCount == 0 && GeneralObject._gameModel.CurrentLevel._Luigi.LifeCount == 0)
				{
					GeneralObject._gameModel.isWon = "No";
					GeneralObject.GameFrame.Navigate(new System.Uri(@"../../Views/XAMLs/EndOfGame.xaml", UriKind.Relative));
					GameModel.SaveResults();
				}
			};
			ImageController.BeginAnimation(Canvas.TopProperty, AnimationY);
			
		}
	}
}
