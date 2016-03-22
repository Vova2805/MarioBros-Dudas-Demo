using System;
using System.Drawing;
using System.Windows.Controls;
using Lab5_KPZ.Models.Flyweight;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Abstract_classes
{
	[Serializable]
	public abstract class Block:MapUnit
	{
		public string BlockType { get; set; }
		
		public Block(PointF position, string imageSource, double heigth, double width, string blockType)
		{
			BlockType = blockType;
			Position = UnitImagesFactory.GetPosition(position.X, position.Y);
			ImageSize = UnitImagesFactory.GetSize(width, heigth);
			Image = imageSource;
        }
		public Block(Image _ImageController,string blockType)
		{
			BlockType = blockType;
			Position = UnitImagesFactory.GetPosition(Canvas.GetLeft(_ImageController), Canvas.GetTop(_ImageController));
			ImageSize = UnitImagesFactory.GetSize(_ImageController.Width, _ImageController.Height);
			Image = _ImageController.Source.ToString();
			ImageController = _ImageController;
			ImageController.Source = UnitImagesFactory.GetImageSource(_ImageController.Source.ToString());
		}
	}
}
