using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.Models.Abstract_Factory
{
	class OrdinaryStyleFactory : IStyleFactory
	{
		public string GetButtonStyle()
		{
			return "../../Styles/OrdinaryStyle/OrdinaryButtonStyle.xaml";
		}

		public string GetBackground()
		{
			return "../Source/Images/Background/bgblock.png";
		}

		public string GetMusic()
		{
			return "../../Views/Source/Sounds/01-main-theme-overworld.wav";
		}

		public string GetTextBoxStyle()
		{
			return "../../Styles/OrdinaryStyle/OriginaryTextBoxStyle.xaml";
		}
	}
}
