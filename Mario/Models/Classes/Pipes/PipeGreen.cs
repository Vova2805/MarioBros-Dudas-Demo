using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models.Abstract_classes;

namespace Lab5_KPZ.Models.Classes
{
	[Serializable]
	public class PipeGreen:Pipe
	{
		public PipeGreen(PointF position, int height, int width,Map MapIn = null) 
			: base(position, height, width, @"../../Views/Source/Images/Items/Blocks/pipe_head.png", MapIn)
		{}
	}
}
