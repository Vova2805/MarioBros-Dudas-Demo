using Lab5_KPZ.Models.Classes;
using System.Windows.Controls;

namespace Lab5_KPZ.Models.Observer
{
	public class MarioObserver:AObserver
	{
		public Label Life;
		public Label Points;
		public Label Coints;
		public MarioObserver(Label life, Label points, Label coints)
		{
			Life = life;
			Points = points;
			Coints = coints;
		}
		public override void Update(object theChangesSubject)
		{
			Life.Content = (theChangesSubject as Mario).LifeCount.ToString();
			Points.Content = (theChangesSubject as Mario).Score.ToString();
			Coints.Content = (theChangesSubject as Mario).CoinsQuantity.ToString();
		}
	}
}
