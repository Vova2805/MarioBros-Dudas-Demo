using System.Collections.Generic;
using System.Windows.Input;

namespace Lab5_KPZ.Models.Mediator1
{
	public class MovingManager
	{
		private readonly Mediator _mediator;
		public List<Key> InputCommands = new List<Key>();
		public MovingManager(Mediator mediator)
		{
			_mediator = mediator;
		}
		public void AddNew(Key new_command)
		{
			InputCommands.Add(new_command);
			_mediator.Changed();
		}
		public void Remove(Key command)
		{
			InputCommands.Remove(command);
			_mediator.Changed();
		}
	}
}
