using Lab5_KPZ.Models.Classes;
using System.Windows.Controls;

namespace Lab5_KPZ.Models.Observer
{
	public class LuigiObserver:AObserver
	{
		public Label Life;
		public Label Points;
		public Label Coints;
		public LuigiObserver(Label life, Label points, Label coints)
		{
			Life = life;
			Points = points;
			Coints = coints;
		}
		public override void Update(object theChangesSubject)
		{
			Life.Content = (theChangesSubject as Luigi).LifeCount;
			Points.Content = (theChangesSubject as Luigi).Score;
			Coints.Content = (theChangesSubject as Luigi).CoinsQuantity;
		}
	}
}
