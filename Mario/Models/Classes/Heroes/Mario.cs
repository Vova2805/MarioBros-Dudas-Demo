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
	public class Mario: MovingObject, IMario
	{
		/// <summary>
		/// Using Singelton pattern
		/// </summary>
		private static Mario _Mario = null;
		[NonSerialized]private static readonly object locker = new object();

		private Mario(PointF pos, PointF imageSize)
		{
			Position = pos;
			LifeCount = 3;
			BonusNumber = 0;
			Score = 0;
			ShootAbility = false;
			SwimAbility = false;
			FlyAbility = false;
			CoinsQuantity = 0;
			Image =@"../../Views/Source/Images/Mario/NormRight.png";
			ImageSize = imageSize;
			ImageController = new Image();
			ImageController.Source = UnitImagesFactory.GetImageSource(Image);
			Direction = true;
		}
		private Mario(Image _ImageController)
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
		public static Mario GetMario(PointF pos, PointF imageSize)
		{
			lock (locker)
			{ 
			if (_Mario == null)
			{
				_Mario = new Mario(pos, imageSize);
			}
			}
			return _Mario;
		}
		public static Mario GetMario(Image _ImageController)
		{
			lock (locker)
			{
				if (_Mario == null)
				{
					_Mario = new Mario(_ImageController);
				}
            }
			return _Mario;
		}
		public static Mario GetMario()
		{
			lock (locker)
			{
				if (_Mario == null)
				{
					_Mario = new Mario(new PointF(0, 0), new PointF(50, 50));
				}
			}
			return _Mario;
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
			foreach(var observer in observers)
			{
				observer.Update(this);
			}
		}
		[NonSerialized]
		public List<AObserver> observers = new List<AObserver>();
	}
}
