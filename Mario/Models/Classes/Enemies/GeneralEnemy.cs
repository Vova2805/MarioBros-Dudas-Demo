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
	public class GeneralEnemy:Enemy
	{
		public GeneralEnemy(PointF position, PointF size, string image) : base(position, size, image)
		{}

		public GeneralEnemy(Image _ImageController) : base(_ImageController)
		{}

		public override void Moving()
		{
			throw new NotImplementedException();
		}

		public override Enemy CreateNew()
		{
			throw new NotImplementedException();
		}
	}
}
