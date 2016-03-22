using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab5_KPZ.Models.Flyweight
{
	//Flyweight Factory
	class UnitImagesFactory
	{
		private static Dictionary<string, ImageSource> Images = new Dictionary<string, ImageSource>();
		private static Dictionary<float, List<PointF>> imagesSize = new Dictionary<float, List<PointF>>();
		private static Dictionary<float, List<PointF>> imagePosition = new Dictionary<float, List<PointF>>();

		public static ImageSource GetImageSource(string path)
		{
			if (!Images.ContainsKey(path))
			{
				ImageSource temp = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
				Images.Add(path, temp);
			}
			return Images[path];
		}

		public static PointF GetSize(double width, double height)
		{
			if (!imagesSize.ContainsKey((float)width))
				imagesSize.Add((float)width, new List<PointF>());
			if (!imagesSize[(float)width].Contains(new PointF((float)width, (float)height)))
			{
				imagesSize[(float)width].Add(new PointF((float)width, (float)height));
			}
			return imagesSize[(float)width].Where(p => p.Y == height).First();
		}
		public static PointF GetPosition(double x, double y)
		{
			if (!imagePosition.ContainsKey((float)x))
				imagePosition.Add((float)x, new List<PointF>());
			if (!imagePosition[(float)x].Contains(new PointF((float)x, (float)y)))
			{
				imagePosition[(float)x].Add(new PointF((float)x, (float)y));
			}
			return imagePosition[(float)x].Where(p => p.Y == y).First();
		}
	}
}
