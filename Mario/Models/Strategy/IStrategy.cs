using Lab5_KPZ.Models.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Lab5_KPZ.Models
{
	public interface IStrategy
	{
		bool Move(MapUnit Unit,bool direction, DispatcherTimer timer);
	}
}
