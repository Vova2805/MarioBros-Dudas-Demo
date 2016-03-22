using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.Models.Abstract_Factory
{
	class NightStyleFactory : IStyleFactory
	{
		public string GetButtonStyle()
		{
			return "../../Styles/NightStyle/NightButtonStyle.xaml";
		}

		public string GetBackground()
		{
			return "../Source/Images/Background/07.png";
		}

		public string GetMusic()
		{
			return "../../Views/Source/Sounds/mb.wav";
		}

		public string GetTextBoxStyle()
		{
			return "../../Styles/NightStyle/NightTextBoxStyle.xaml";
		}
	}
}
