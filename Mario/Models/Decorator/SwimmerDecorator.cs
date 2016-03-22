using Lab5_KPZ.Models.Facade;
using Lab5_KPZ.Models.Flyweight;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Lab5_KPZ.Models.Decorator
{
	public class SwimmerDecorator:ObjectDecorator
	{
		public SwimmerDecorator(MovingObject decoratedObject):base(decoratedObject)
		{
			ImageController.Source = UnitImagesFactory.GetImageSource(@"../../Views/Source/Images/Mario/MarioSwimmer.png");
		}
		public override void Run(Speed speed, bool direction)
		{
			//Swim
			int direct = direction ? 1 : -1;
			var StartX = Canvas.GetLeft(ImageController);
			var EndX = StartX + 50 * direct;
			var AnimationX = new DoubleAnimation(StartX, EndX, TimeSpan.FromSeconds(1));
			ImageController.BeginAnimation(Canvas.LeftProperty, AnimationX);
		}
		public override void JumpUp(double height, bool direction)
		{
			base.JumpUp(height+30, direction);
			GeneralObject.MainFacade.PlayStopSound(new MediaPlayer(),playingCommand.play,"../../Views/Source/Sounds/clap.wav",PlayingType.original);
		}
	}
}
