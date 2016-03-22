using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models.Abstract_classes;
using Lab5_KPZ.Models.Classes.Bonus;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Classes
{
	[Serializable]
	public class Bonus_block:Block
	{
		public Abstract_classes.Bonus InsideBonus;


		public Bonus_block(PointF position, string imageSource, double heigth, double width, string blockType,
			Abstract_classes.Bonus inside) : base(position, imageSource, heigth, width, blockType)
		{
			InsideBonus = inside; 
		}

		public Bonus_block(Image _ImageController, string blockType,Abstract_classes.Bonus inside) : base(_ImageController, blockType)
		{
			InsideBonus = inside;
		}
	}
}
