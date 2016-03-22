using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Lab5_KPZ.Models.Flyweight;
using System.Windows.Threading;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Classes;

namespace Lab5_KPZ.Models.Strategy
{
	class MoveStrategy : IStrategy
	{
		public bool Move(MapUnit Unit, bool direction, DispatcherTimer timer)
		{
			var StartX = Canvas.GetLeft(Unit.ImageController);
			var EndX = StartX + 30 * (direction?1:-1);
			double step = EndX;
			if (direction) step = EndX + Unit.ImageController.Width;
			var temp = MapUnit.CheckOut(step, Canvas.GetTop(Unit.ImageController)+GeneralObject.cellSize.Y/2, GeneralObject._gameModel.CurrentLevel,new MoveStrategy());
            if (temp != null)
			{
				if(temp is Block)
				{
					direction = !direction;
					if (Unit is Enemy)
					{
						(Unit as Enemy).CurrentDirection = direction;
					}
					double delta = (Math.Abs(Canvas.GetLeft(temp.ImageController) - StartX) - (!direction ? 0 : 1) * temp.ImageController.Width) * (!direction ? 1 : -1);
					EndX = StartX + delta;
					var AnimationX1 = new DoubleAnimation(StartX, EndX, TimeSpan.FromMilliseconds(10));
					Unit.ImageController.BeginAnimation(Canvas.LeftProperty, AnimationX1);
					EndX = StartX + 30 * (direction ? 1 : -1);
				}else if((temp is Mario || temp is Luigi )&& Unit is Enemy)
				{
					if (temp is Mario) GeneralObject._gameModel.CurrentLevel._Mario.Die();
					else GeneralObject._gameModel.CurrentLevel._Luigi.Die();
				}
			}
			var AnimationX = new DoubleAnimation(StartX, EndX, TimeSpan.FromSeconds(1));
			Unit.ImageController.BeginAnimation(Canvas.LeftProperty, AnimationX);
			return false;
		}
	}
}
