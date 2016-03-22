using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Flyweight;
using Lab5_KPZ.Models.Strategy;

namespace Lab5_KPZ.Models
{
	/// <summary>
	/// We are going serialize this objects
	/// </summary>
	[Serializable]
	public class Map
	{
		public double Wigth { get;  set; }
		public double Heigth { get;  set; }
		public List<MapUnit> Coins { get; set; }
		public List<MapUnit> Blocks { get; set; }
		public List<MapUnit> Bonuses { get; set; }
		public List<MapUnit> Pipes { get; set; }
		public List<MapUnit> Enemies { get; set; }
		public string BackgrounImageSource { get; set; }
		public string SoundSource { get; set; }
		public Map(double heigth,double width,string image)
		{
			Heigth = heigth;
			Wigth = width;
			BackgrounImageSource = image;
			Coins = new List<MapUnit>();
			Blocks = new List<MapUnit>();
			Pipes = new List<MapUnit>();
			Enemies = new List<MapUnit>();
			Bonuses = new List<MapUnit>();
		}
		public static void FillingBackground(StackPanel StackPanel,Canvas Mario_canvas, Image Background)
		{
			StackPanel.Children.Clear();
			StackPanel.Children.Add(Background);
			int image_number = (int)Math.Ceiling(Mario_canvas.Width / Background.Width);
			for (int i = 1; i < image_number; i++)
			{
				var image = new Image();
				image.Source = Background.Source;
				image.VerticalAlignment = Background.VerticalAlignment;
				image.HorizontalAlignment = Background.HorizontalAlignment;
				image.Width = Background.Width;
				image.Stretch = Background.Stretch;
				StackPanel.Children.Add(image);
			}
		}

		public bool FillMap(Canvas gameCanvas,Image background,StackPanel panel,Mario _Mario,Luigi _Luigi,Difficulty difficulty)
		{
			gameCanvas.Width = Wigth;
			background.Source = UnitImagesFactory.GetImageSource(BackgrounImageSource);
			GeneralObject.MainFacade.PlayStopSound(GeneralObject._backgroundPlayer,Facade.playingCommand.play, SoundSource,Facade.PlayingType.loop);
			FillingBackground(panel, gameCanvas, background);
            foreach (Coin coin in Coins)
			{
				coin.ImageController = new Image();
				coin.ImageController.Source = UnitImagesFactory.GetImageSource(coin.Image);
				coin.ImageController.Width = coin.ImageSize.X;
				coin.ImageController.Height = coin.ImageSize.Y;
				coin.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(coin.ImageController, coin.Position.Y);
				Canvas.SetLeft(coin.ImageController, coin.Position.X);
				gameCanvas.Children.Add(coin.ImageController);
			}
			foreach (Block block in Blocks)
			{
				block.ImageController = new Image();
				block.ImageController.Source = UnitImagesFactory.GetImageSource(block.Image);
				block.ImageController.Width = block.ImageSize.X;
				block.ImageController.Height = block.ImageSize.Y;
				block.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(block.ImageController, block.Position.Y);
				Canvas.SetLeft(block.ImageController, block.Position.X);
				gameCanvas.Children.Add(block.ImageController);
				
			}
			foreach (Pipe pipe in Pipes)
			{
				pipe.ImageController = new Image();
				pipe.ImageController.Source = UnitImagesFactory.GetImageSource(pipe.Image);
				pipe.ImageController.Width = pipe.ImageSize.X;
				pipe.ImageController.Height = pipe.ImageSize.Y;
				pipe.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(pipe.ImageController, pipe.Position.Y);
				Canvas.SetLeft(pipe.ImageController, pipe.Position.X);
				gameCanvas.Children.Add(pipe.ImageController);
				
			}
			foreach (Bonus bonus in Bonuses)
			{
				bonus.ImageController = new Image();
				bonus.ImageController.Source = UnitImagesFactory.GetImageSource(bonus.Image);
				bonus.ImageController.Width = bonus.ImageSize.X;
				bonus.ImageController.Height = bonus.ImageSize.Y;
				bonus.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(bonus.ImageController, bonus.Position.Y);
				Canvas.SetLeft(bonus.ImageController, bonus.Position.X);
				gameCanvas.Children.Add(bonus.ImageController);

			}
			List<MapUnit> enemy_additional = new List<MapUnit>();
			foreach (Enemy enemy in Enemies)
			{
				int quantity = 0;
				if (difficulty.Equals(Difficulty.Middle)) quantity = 1;
				if (difficulty.Equals(Difficulty.Hard)) quantity = 2;
				enemy.ImageController = new Image();
				enemy.ImageController.Source = UnitImagesFactory.GetImageSource(enemy.Image);
				enemy.ImageController.Width = enemy.ImageSize.X;
				enemy.ImageController.Height = enemy.ImageSize.Y;
				enemy.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(enemy.ImageController, enemy.Position.Y);
				Canvas.SetLeft(enemy.ImageController, enemy.Position.X);
				gameCanvas.Children.Add(enemy.ImageController);
				for(int i = 0;i<quantity;i++)
				{
					var new_enemy = enemy.Clone();
					var temp =  MapUnit.CheckOut(new_enemy.Position.X+GeneralObject.cellSize.X,new_enemy.Position.Y,GeneralObject._gameModel.CurrentLevel,null);
					if(temp == null)
					{
						new_enemy.Position = UnitImagesFactory.GetPosition(new_enemy.Position.X+GeneralObject.cellSize.X,new_enemy.Position.Y);
					}
					else
					{
						temp = MapUnit.CheckOut(new_enemy.Position.X, new_enemy.Position.Y + GeneralObject.cellSize.Y, GeneralObject._gameModel.CurrentLevel, null);
						if (temp == null)
						{
							new_enemy.Position = UnitImagesFactory.GetPosition(new_enemy.Position.X, new_enemy.Position.Y + GeneralObject.cellSize.Y);
						}
						else
						{
							temp = MapUnit.CheckOut(new_enemy.Position.X, new_enemy.Position.Y - GeneralObject.cellSize.Y, GeneralObject._gameModel.CurrentLevel, null);
							if (temp == null)
							{
								new_enemy.Position = UnitImagesFactory.GetPosition(new_enemy.Position.X, new_enemy.Position.Y - GeneralObject.cellSize.Y);
							}
							else
							{
								temp = MapUnit.CheckOut(new_enemy.Position.X-GeneralObject.cellSize.X, new_enemy.Position.Y, GeneralObject._gameModel.CurrentLevel, null);
								if (temp == null)
								{
									new_enemy.Position = UnitImagesFactory.GetPosition(new_enemy.Position.X - GeneralObject.cellSize.X, new_enemy.Position.Y);
								}
							}
						}
					}
					if(!new_enemy.Position.Equals(enemy.Position))
					{
						new_enemy.ImageController.Width = new_enemy.ImageSize.X;
						new_enemy.ImageController.Height = new_enemy.ImageSize.Y;
						new_enemy.ImageController.Stretch = Stretch.Fill;
						Canvas.SetTop(new_enemy.ImageController, new_enemy.Position.Y);
						Canvas.SetLeft(new_enemy.ImageController, new_enemy.Position.X);
						enemy_additional.Add(new_enemy);
                        gameCanvas.Children.Add(new_enemy.ImageController);
					}
				}
				
			}
			foreach(var enemy in enemy_additional)
			{
				Enemies.Add(enemy);
			}
			if (_Mario != null)
			{
				_Mario.ImageController = new Image();
				_Mario.ImageController.Source = UnitImagesFactory.GetImageSource(_Mario.Image);
				_Mario.ImageController.Width = _Mario.ImageSize.X;
				_Mario.ImageController.Height = _Mario.ImageSize.Y;
				_Mario.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(_Mario.ImageController, _Mario.Position.Y);
				Canvas.SetLeft(_Mario.ImageController, _Mario.Position.X);
				Panel.SetZIndex(_Mario.ImageController, 5);
				gameCanvas.Children.Add(_Mario.ImageController);
			}
			if (_Luigi != null && (GeneralObject._gameViewModel._quantity.Equals("Two") || GeneralObject.OnMap))
			{
				_Luigi.ImageController = new Image();
				_Luigi.ImageController.Source = UnitImagesFactory.GetImageSource(_Luigi.Image);
				_Luigi.ImageController.Width = _Luigi.ImageSize.X;
				_Luigi.ImageController.Height = _Luigi.ImageSize.Y;
				_Luigi.ImageController.Stretch = Stretch.Fill;
				Canvas.SetTop(_Luigi.ImageController, _Luigi.Position.Y);
				Canvas.SetLeft(_Luigi.ImageController, _Luigi.Position.X);
				Panel.SetZIndex(_Luigi.ImageController, 5);
				gameCanvas.Children.Add(_Luigi.ImageController);
			}
			return true;
		}
	}
}
