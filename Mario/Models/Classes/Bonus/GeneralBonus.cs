using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = System.Windows.Controls.Image;

namespace Lab5_KPZ.Models.Classes.Bonus
{
	[Serializable]
	class GeneralBonus:Abstract_classes.Bonus
	{
		public GeneralBonus(PointF position, string image, string type, PointF size) : base(position, image, type, size)
		{}

		public GeneralBonus(Image _ImageController, string bonusType) : base(_ImageController, bonusType)
		{}

		public override void SetAbility(IMario hero)
		{
			throw new NotImplementedException();
		}

		public override int GetBonus()
		{
			throw new NotImplementedException();
		}
	}
}
