using System.Windows.Controls;

namespace Lab5_KPZ.Models.Observer
{
	public class TimeObserver : AObserver
	{
		public Label TimeLabel;
		public TimeObserver(Label time)
		{
			TimeLabel = time;
		}
		public override void Update(object theChangesSubject)
		{
			TimeLabel.Content = (theChangesSubject as Level).Time;
        }
	}
}
