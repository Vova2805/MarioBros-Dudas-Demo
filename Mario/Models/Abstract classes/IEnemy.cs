using System;
using System.Drawing;
using System.Windows.Controls;
using Lab5_KPZ.Models.Flyweight;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Abstract_classes
{
	[Serializable]
	public abstract  class Enemy:MapUnit
	{
		 public bool CurrentDirection { get; set; }
		 public int LifeCount { get; private set; }


		public abstract void Moving();
		public abstract Enemy CreateNew();
		
		protected Enemy(PointF position,PointF size, string image)
		{
			Random r = new Random();
			int k = r.Next(0, 100);
			CurrentDirection = k % 2 == 0 ? true : false;
			
			Position = UnitImagesFactory.GetPosition(position.X, position.Y);
			ImageSize = UnitImagesFactory.GetSize(size.X, size.Y);
			Image = image;
        }
		public Enemy(Image _ImageController)
		{
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(_ImageController.Height, _ImageController.Width);
			Image = _ImageController.Source.ToString();
			Random r = new Random();
			int k = r.Next(0, 100);
			CurrentDirection = k % 2 == 0 ? true : false;
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
		}
	}
}
