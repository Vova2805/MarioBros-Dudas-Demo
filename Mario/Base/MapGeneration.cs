using System.Collections.Generic;
using System.Drawing;
using Lab5_KPZ.Models;
using Lab5_KPZ.Models.Classes;
using Lab5_KPZ.Models.Classes.Blocks;
using Lab5_KPZ.Models.Flyweight;

namespace Lab5_KPZ.Base
{
	class MapGeneration
	{
		public static void SerializeMap()
		{
			int width = 5000;
			var map1 = new Map(650,width,@"../../Views/Source/Images/Background/01.png");
			List<MapUnit> temp = new List<MapUnit>();
			for (int i = 0; i * 100 < width; i++)
			{
				temp.Add(new GeneralWithImageRef(new PointF(i * 100, 570), @"../../Views/Source/Images/Blocks/ground_grass_block.png", 70, 200,"Gound"));
			}
			temp.Add(new GeneralWithImageRef(new PointF(100, 100), @"../../Views/Source/Images/Blocks/brick.png", 50, 50,"Brick"));
			map1.Blocks = temp;
			map1.Coins = new List<MapUnit>()
			{
				new CoinOrdinary(40,new PointF(100,200),@"../../Views/Source/Images/Items/Coins/Coin_1.png",new  PointF(30,30)),
				new CoinOrdinary(60,new PointF(300,300),@"../../Views/Source/Images/Items/Coins/Coin_1.png",new  PointF(30,30)),
				new CoinOrdinary(50,new PointF(200,200),@"../../Views/Source/Images/Items/Coins/Coin_1.png",new  PointF(30,30))
			};
			map1.Enemies = new List<MapUnit>()
			{
				new GeneralEnemy(new PointF(400,150),new PointF(50,50),@"../../Views/Source/Images/Enemies/Koopa/Koopa_Red_Right_1.png"),
				new GeneralEnemy(new PointF(300,350),new PointF(50,50),@"../../Views/Source/Images/Enemies/Goomba/Goomba_Normal_1.png")
			};
			map1.Pipes = new List<MapUnit>()
			{
				new PipeGreen(new PointF(400,150),200,100),
				new PipeGreen(new PointF(500,150),300,100)
			};
			//Using Singleton

			var level = new Level(Difficulty.Easy, new List<Map>()
				{
					map1
				}, 200, "Test level",1);
			level._Mario = Mario.GetMario(new PointF(10, 300), new PointF(50, 50));
			level._Luigi = Luigi.GetLuigi(new PointF(100, 300), new PointF(50, 50));
			Serializer.Serialize("Levels.dat", level);
		}
	}
}
