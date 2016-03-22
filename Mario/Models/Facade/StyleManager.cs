using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lab5_KPZ.Models.Facad
{
	class StyleManager
	{
		public void Clear()
		{
			Application.Current.Resources.MergedDictionaries.Clear();
		}
		public void ChangeBackground(string source)
		{
			if(source!=null)
			WindowBackground.background.Source = new BitmapImage(new Uri(source, UriKind.Relative));
		}
		public void ChangeButtonStyle(string source)
		{
			if (source != null)
				Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
			{
				Source = new Uri(source, UriKind.RelativeOrAbsolute)
			});
		}
		public void ChangeTextBoxStyle(string source)
		{
			if (source != null)
				Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
			{
				Source = new Uri(source, UriKind.RelativeOrAbsolute)
			});
		}
	}
}
