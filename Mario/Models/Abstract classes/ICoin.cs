using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models.Flyweight;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Abstract_classes
{
	[Serializable]
	public abstract class Coin:MapUnit
	{
		 public int capacity { get; private set; }

		protected Coin(int capacity, PointF position, string image, PointF imageSize)
		{
			this.capacity = capacity;
			ImageController = new Image();
			ImageController.Source = UnitImagesFactory.GetImageSource(image);
			Position = UnitImagesFactory.GetPosition(position.X, position.Y);
			ImageSize = UnitImagesFactory.GetSize(imageSize.X, imageSize.Y);
			Image = image;
        }
		public Coin(Image _ImageController,int capacity)
		{
			this.capacity = capacity;
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(_ImageController.Height, _ImageController.Width);
			Image = _ImageController.Source.ToString();
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
		}
	}
}
