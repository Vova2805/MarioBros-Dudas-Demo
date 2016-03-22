using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_KPZ.Models.Abstract_classes;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Classes.Blocks
{
	[Serializable]
	class GeneralWithImageRef:Block
	{
		public GeneralWithImageRef(PointF position, string imageSource, double heigth, double width, string blockType) : base(position, imageSource, heigth, width, blockType)
		{ }

		public GeneralWithImageRef(Image _ImageController, string blockType) : base(_ImageController, blockType)
		{}
	}
}
