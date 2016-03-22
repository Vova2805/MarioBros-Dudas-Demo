using Lab5_KPZ.Base;
using System;

namespace Lab5_KPZ.Models.Memento
{
	[Serializable]
	public class GameMemento
	{
		public Level _state { get; set; }
		public GameMemento(Level state)
		{
			_state = (Level)Mapping.Clone(state);
		}
		public Level GetState()
		{
			return _state;
		}
	}
}
