using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Facade;
using Lab5_KPZ.Models.Flyweight;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Lab5_KPZ.Models.Mediator1
{
	public class Mediator
	{
		public MovingManager moving_manager;
		public static string MenuForPlayer = "";
		public Mediator()
		{
			moving_manager = new MovingManager(this);
		}
		public void Changed()
		{
			
			if (moving_manager.InputCommands.Count>0)
			{
				//foreach(Key command in moving_manager.InputCommands)
				while (moving_manager.InputCommands.Count>0)
				{
					Key command = moving_manager.InputCommands.First();
                    MovingObject Unit = null;
					bool isMario = true;
					string key = "";
					if (GeneralObject._gameModel.FirstSettings.commands.ContainsValue(command))
					{
						Unit = GeneralObject._gameModel.CurrentLevel._Mario;
						isMario = true;
						key = GeneralObject._gameModel.FirstSettings.commands.Where(c => c.Value.Equals(command)).Select(s => s.Key).First();
					}
					else if (GeneralObject._gameModel.SecondSettings.commands.ContainsValue(command))
					{
						Unit = GeneralObject._gameModel.CurrentLevel._Luigi;
						isMario = false;
						key = GeneralObject._gameModel.SecondSettings.commands.Where(c => c.Value.Equals(command)).Select(s => s.Key).First();
					}
					if (Unit != null && !key.Equals(""))
					{
						bool direction;
						if (isMario) direction = (Unit as Mario).Direction;
						else direction = (Unit as Luigi).Direction;
						if(Unit is Mario && GeneralObject._gameModel.CurrentLevel._Mario.LifeCount>0)
							Step(Unit, key, direction);
						if (Unit is Luigi && GeneralObject._gameViewModel._quantity.Equals("Two") &&
							GeneralObject._gameModel.CurrentLevel._Luigi.LifeCount > 0)
							Step(Unit, key, direction);

					}
					moving_manager.InputCommands.Remove(command);
                }
			}
		}
		void Step(MovingObject Unit,string key,bool direction)
		{
			if (Unit is Mario)
			{
				MenuForPlayer = GeneralObject._gameModel.FirstPlayer.Name;
			}
			if (Unit is Luigi)
			{
				MenuForPlayer = GeneralObject._gameModel.SecondPlayer.Name;
			}
			switch (key)
			{
				case "Menu_Display":
					{
						NewGame.gameFrame.Navigate(new Uri(@"../../Views/XAMLs/GameMenu.xaml", UriKind.Relative));
					}
					break;
				case "Move_Forward":
					{
						Unit.Run(MovingObject.Speed.ordinary, true);
						direction = true;
					}
					break;
				case "Move_Backward":
					{
						Unit.Run(MovingObject.Speed.ordinary, false);
						direction = false;
					}
					break;
				case "Jump":
					{
						Unit.JumpUp(200, direction);
					}
					break;
				case "Duck":
					{
						Unit.Seat(Unit, direction);
					}
					break;
				case "Fire":
					{
						Unit.Shoot(Unit, direction);
					}
					break;
				case "Sprint":
					{
						Unit.Run(MovingObject.Speed.fast, direction);
					}
					break;
				case "Save_Game":
					{
						GeneralObject._gameViewModel.SaveRestore = "Save";
                        NewGame.gameFrame.Navigate(new Uri(@"../../Views/XAMLs/SaveRestoreGame.xaml", UriKind.Relative));
					}
					break;
			}
		}
	}
}
