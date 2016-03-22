using Lab5_KPZ.Models.Facade;
using Lab5_KPZ.Models.Flyweight;

namespace Lab5_KPZ.Models.Decorator
{
	public class ObjectDecorator:MovingObject
	{
		protected MovingObject DecoratedObject { get; set; }
		public ObjectDecorator(MovingObject decoratedObject)
		{
			DecoratedObject = decoratedObject;
        }
		public override void Run(Speed speed, bool direction)
		{
			base.Run(speed, direction);
		}
		public override void JumpUp(double height, bool direction)
		{
			base.JumpUp(height, direction);
		}
		public override void Shoot(MapUnit Unit, bool direction)
		{
			base.Shoot(Unit, direction);
		}
		public override void Die()
		{
			base.Die();
		}
		public override void Seat(MapUnit Unit, bool direction)
		{
			base.Seat(Unit, direction);
		}
	}
}
