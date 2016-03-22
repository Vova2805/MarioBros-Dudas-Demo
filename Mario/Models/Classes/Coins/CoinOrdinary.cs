using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models.Abstract_classes;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Classes
{
	[Serializable]
	public class CoinOrdinary:Coin
	{
		public CoinOrdinary(int capacity, PointF position, string image, PointF imageSize) : base(capacity, position, image, imageSize)
		{
		}

		public CoinOrdinary(Image _ImageController, int capacity) : base(_ImageController, capacity)
		{
		}
	}
}
