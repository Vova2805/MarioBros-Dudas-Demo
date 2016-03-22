using Lab5_KPZ.Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.Models
{
	[Serializable]
	[DataContract]
	public class Player
	{
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int Level { get; set; }
		[DataMember]
		public int Score { get; set; }
		[DataMember]
		public int Coins { get; set; }

		public Player(string name)
		{
			Name = name;
			Level = 0;
			Score = 0;
			Coins = 0;
		}
		//Observer pattern
		public void Attach(AObserver observer)
		{
			observers.Add(observer);
		}

		public void Detach(AObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in observers)
			{
				observer.Update(this);
			}
		}
		[NonSerialized]
		[DataMember]
		private List<AObserver> observers = new List<AObserver>();
	}
}
