using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Lab5_KPZ.Models;

namespace Lab5_KPZ.Convertors
{
	class AwardConvertor:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			
			string award =((Awards) value).ToString();
			if (int.Parse(value.ToString()) > 5)
				if (int.Parse(value.ToString()) < 20)
				award = "Level10";
				else award = "Level20";
			var uri = new Uri(string.Format(@"../../Views/Source/Images/Awards/{0}.png", award),UriKind.Relative);
			return new BitmapImage(uri);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
