using System;
using System.Windows.Controls;
using Lab5_KPZ.Models.Flyweight;
using System.Windows.Media.Animation;
using System.Drawing;
using System.Windows.Threading;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Facade;
using System.Windows.Media;

namespace Lab5_KPZ.Models.Strategy
{
	class FallStrategy : IStrategy
	{
		public bool Move(MapUnit Unit, bool direction, DispatcherTimer timer)
		{
			var StartY = Canvas.GetTop(Unit.ImageController);
			MapUnit temp = MapUnit.CheckOut(Canvas.GetLeft(Unit.ImageController) + GeneralObject.cellSize.X/2, StartY + Unit.ImageController.Height + 30, GeneralObject._gameModel.CurrentLevel,new FallStrategy());
				if (temp==null)
				{
					if (StartY < GeneralObject._gameModel.CurrentLevel._Maps[GeneralObject._gameModel.CurrentLevel.currentMap].Heigth)
					{
						var EndY = StartY + 30;
						var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromMilliseconds(500));
						
						AnimationY.Completed += (sender, e) => {
							if ((Canvas.GetTop(Unit.ImageController) + Unit.ImageController.Height) >= (NewGame.MainStackPanel.Height))
								if (Unit is Mario || Unit is Luigi)
								{
									(Unit as MovingObject).timer.Stop();
									(Unit as MovingObject).Die();
								}
						};
					Unit.ImageController.BeginAnimation(Canvas.TopProperty, AnimationY);
				}
					
				}
				else
				{
				PointF Position = temp.Position;
				if (Canvas.GetTop(Unit.ImageController) + Unit.ImageController.Height < Position.Y)
				{
					var EndY = Position.Y - Unit.ImageController.Height;
					var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromMilliseconds(200));
					Unit.ImageController.BeginAnimation(Canvas.TopProperty, AnimationY);
				}
				if (Unit is Mario || Unit is Luigi)
				{
					if (temp is Coin)
					{
						GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/coin.wav", PlayingType.original);
						if (Unit is Mario)
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
						return false;
					}else
						if(temp is Enemy)
					{
						if (Unit is Mario)
						{
							GeneralObject._gameModel.CurrentLevel._Mario.Score += 100;
							GeneralObject._gameModel.CurrentLevel._Mario.Notify();
							GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/mario_gotcha.wav", PlayingType.original);
						}
						else
						{
							GeneralObject._gameModel.CurrentLevel._Luigi.Score += 100;
							GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
							GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/luigi_gotcha.wav", PlayingType.original);
						}
						GeneralObject._gameModel.CurrentLevel._Maps[0].Enemies.Remove(temp);
						NewGame.gameCanvas.Children.Remove(temp.ImageController);
						return false;
					}
					else if(temp is Bonus)
					{
						if (Unit is Mario)
						{
							GeneralObject._gameModel.CurrentLevel._Mario.Score += 1000;
							GeneralObject._gameModel.CurrentLevel._Mario.Notify();
							GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/mario_bravo.wav", PlayingType.original);
						}
						else
						{
							GeneralObject._gameModel.CurrentLevel._Luigi.Score += 1000;
							GeneralObject._gameModel.CurrentLevel._Luigi.Notify();
							GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(), playingCommand.play, @"../../Views/Source/Sounds/luigi_bravo.wav", PlayingType.original);
						}
						GeneralObject._gameModel.CurrentLevel._Maps[0].Bonuses.Remove(temp);
						NewGame.gameCanvas.Children.Remove(temp.ImageController);
						return false;
					}
					else
					{
						if (timer != null)
							timer.Stop();
					}
						
				}
				return true;
				}
				
			return false;
		}
	}
}
