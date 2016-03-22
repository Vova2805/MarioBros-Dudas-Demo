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
	public abstract class Bonus:MapUnit
		{
		public string BonusType { get; set; }

		public Bonus(PointF position, string image,string type,PointF size)
		{
			BonusType = type;
			Position = UnitImagesFactory.GetPosition(position.X, position.Y);
			ImageSize = UnitImagesFactory.GetSize(size.X, size.Y);
			Image = image;
        }
		public Bonus(Image _ImageController, string bonusType)
		{
			BonusType = bonusType;
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(_ImageController.Height, _ImageController.Width);
			Image = _ImageController.Source.ToString();
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
		}

		public abstract void SetAbility(IMario hero);
		public abstract int GetBonus();
		}
}
