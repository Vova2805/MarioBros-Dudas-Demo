using Lab5_KPZ.Models.Flyweight;
using System;
using System.Collections.Generic;
using System.Drawing;
using Image = System.Windows.Controls.Image;
using Lab5_KPZ.Models.Observer;
using System.Windows.Controls;
using Lab5_KPZ.Models.Facade;

namespace Lab5_KPZ.Models.Classes
{
	[Serializable]
	public class Luigi: MovingObject, IMario
	{
		/// <summary>
		/// Using Singelton pattern
		/// </summary>
		private static Luigi _Luigi = null;
		[NonSerialized]
		private static readonly object locker = new object();

		private Luigi(PointF pos, PointF imageSize)
		{
			Position = pos;
			LifeCount = 3;
			Score = 0;
			BonusNumber = 0;
			ShootAbility = false;
			SwimAbility = false;
			FlyAbility = false;
			CoinsQuantity = 0;
			Image = @"../../Views/Source/Images/Luigi/luigi_game.png";
			ImageSize = imageSize;
			ImageController = new Image();
			ImageController.Source = UnitImagesFactory.GetImageSource(Image);
			Direction = true;
		}
		private Luigi(Image _ImageController)
		{
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(_ImageController.Width, _ImageController.Height);
			Image = _ImageController.Source.ToString();
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
			LifeCount = 3;
			BonusNumber = 0;
			Score = 0;
			ShootAbility = false;
			SwimAbility = false;
			FlyAbility = false;
			CoinsQuantity = 0;
			Direction = true;
		}
		public static Luigi GetLuigi(PointF pos,PointF imageSize)
		{
			lock (locker)
			{
				if (_Luigi == null)
				{
					_Luigi = new Luigi(pos, imageSize);
				}
			}
			return _Luigi;
		}
		public static Luigi GetLuigi(Image _ImageController)
		{
			lock (locker)
			{
				if (_Luigi == null)
				{
					_Luigi = new Luigi(_ImageController);
				}
			}
			return _Luigi;
		}
		public static Luigi GetLuigi()
		{
			lock (locker)
			{
				if (_Luigi == null)
				{
					_Luigi = new Luigi(new PointF(0, 0), new PointF(50, 50));
				}
			}
			return _Luigi;
		}
		//Observer pattern
		public void Attach(AObserver observer)
		{
			observers.Add(observer);
		}

		public void Detach(AObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in observers)
			{
				observer.Update(this);
			}
		}

		[NonSerialized]
		public List<AObserver> observers = new List<AObserver>();
	}
}
