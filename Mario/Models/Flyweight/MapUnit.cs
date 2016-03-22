using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Strategy;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Flyweight
{
	[Serializable]
	public abstract class MapUnit
	{
		public string Image { get; protected set; }
		//Flyweights
		//{
		public PointF Position { get; set; }
		[NonSerialized] public Image ImageController;
		public PointF ImageSize { get; protected set; }
		//}
		public MapUnit Clone()
		{
			//deep copy
			var Copy = (MapUnit)MemberwiseClone();
			Copy.Image = Image;
            Copy.Position = new PointF(Position.X, Position.Y);
			Copy.ImageSize = new PointF(ImageSize.X, ImageSize.Y);
			Copy.ImageController = new Image();
			Copy.ImageController.Source = new BitmapImage(new Uri(this.Image, UriKind.RelativeOrAbsolute));
			Copy.ImageController.Height = Copy.ImageSize.X;
			Copy.ImageController.Width = Copy.ImageSize.Y;
			Copy.ImageController.Stretch = this.ImageController.Stretch;
			Canvas.SetLeft(Copy.ImageController, Copy.Position.X);
			Canvas.SetTop(Copy.ImageController, Copy.Position.Y);
			return Copy;
		}
		public static MapUnit CheckIn(double x, double y, Level LevelModel)//when x and y are equal unit.ImageController.X and Y
		{//For MapEditor
			//Using Iterator
			var iterator = new UnitIterator(LevelModel, 0);
			while (iterator.HasNext())
			{
				var unit = iterator.NextUnit();
				if (unit != null)
				{
					if ((unit.Position.X == x && unit.Position.Y == y))
						return unit;
				}
			}
			return null;
		}

		public static MapUnit CheckOut(double x, double y, Level LevelModel,IStrategy strategy)//Around the object
		{
			double x_right = (Math.Ceiling(x / GeneralObject.cellSize.X) * GeneralObject.cellSize.X);
			double y_bottom = (Math.Ceiling(y / GeneralObject.cellSize.Y) * GeneralObject.cellSize.Y);
			double x_left = (Math.Floor(x / GeneralObject.cellSize.X) * GeneralObject.cellSize.X);
			double y_top = (Math.Floor(y / GeneralObject.cellSize.Y) * GeneralObject.cellSize.Y);
			//Using Iterator
			var iterator = new UnitIterator(LevelModel, 0);
			while (iterator.HasNext())
			{
				var unit = iterator.NextUnit();
				if (unit != null)
				{
					//Real position on map
					if(!(unit is Block) && unit.ImageController!=null)
					unit.Position = new PointF((float)Canvas.GetLeft(unit.ImageController), (float)Canvas.GetTop(unit.ImageController));
					if(strategy is FallStrategy)
					{
						if (
						   ((unit.Position.X + GeneralObject.cellSize.X) > x &&
						   (unit.Position.X) <= x
						   && ((unit.Position.Y) <= y)
						   && ((unit.Position.Y + GeneralObject.cellSize.Y) > y)
						   )
						   )
						{
							return unit;
						}
					}else
					if(strategy is MoveStrategy)
					{
						if(
						((unit.Position.Y + GeneralObject.cellSize.Y ) > y &&
						(unit.Position.Y) <= y
						&& ((unit.Position.X) <= x)
						&& ((unit.Position.X + GeneralObject.cellSize.X) > x)
						)
						)
					{
						return unit;
						}
						
					}
					else
					{
						return CheckOut(x, y, LevelModel, new FallStrategy()) ?? (CheckOut(x, y, LevelModel, new MoveStrategy()) ?? null);
					}
				}
			}
			return null;
		}
	}
}
