using System;
using System.Windows.Controls;
using Lab5_KPZ.Models.Flyweight;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Lab5_KPZ.Models.Strategy
{
	class JumpStrategy : IStrategy
	{
		public bool Move(MapUnit Unit, bool direction, DispatcherTimer timer)
		{
			var StartY = Canvas.GetTop(Unit.ImageController);
			var EndY = StartY - 50;
			var StartX = Canvas.GetLeft(Unit.ImageController);
			var EndX = StartY + 100 *(direction?1:-1);
			var AnimationY = new DoubleAnimation(StartY, EndY, TimeSpan.FromMilliseconds(1));
			var AnimationX = new DoubleAnimation(StartX, EndX, TimeSpan.FromMilliseconds(1));
			AnimationY.AutoReverse = true;
			Unit.ImageController.BeginAnimation(Canvas.TopProperty, AnimationY);
			Unit.ImageController.BeginAnimation(Canvas.LeftProperty, AnimationX);
			return true;
		}
	}
}
