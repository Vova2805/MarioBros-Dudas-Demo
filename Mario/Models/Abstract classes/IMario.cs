using Lab5_KPZ.Models.Observer;

namespace Lab5_KPZ.Models
{
	public interface IMario
	{
		//For Observer pattern
		void Attach(AObserver observer);
		void Detach(AObserver observer);
		void Notify();
	}
}
