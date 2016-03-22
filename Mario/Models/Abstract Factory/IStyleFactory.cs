using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5_KPZ.Models.Abstract_Factory
{
	public interface IStyleFactory
	{
		string GetButtonStyle();
		string GetBackground();
		string GetMusic();
		string GetTextBoxStyle();
	}
}
