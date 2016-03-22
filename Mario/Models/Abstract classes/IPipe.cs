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
	public abstract class Pipe:MapUnit
	{
		 public Map MapInside { get; private set; }
		public Pipe(PointF position, int height, int width, string image, Map mapIn=null)
		{
			MapInside = mapIn;
			Position = UnitImagesFactory.GetPosition(position.X, position.Y);
			ImageSize = UnitImagesFactory.GetSize(width, height);
			Image = image;
        }
		public Pipe(Image _ImageController,double height,double width, Map mapIn = null)
		{
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(width, height);
			Image = ImageController.Source.ToString();
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
		}
	}
}
