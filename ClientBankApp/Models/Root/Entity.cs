namespace ClientBankApp.Models.Root
{
	public abstract class Entity
	{
		public virtual Guid Id { get; }

		public bool IsTransient()
			=> Id == default;
		protected Entity() { }
		protected Entity(Guid id) => Id = id;
		public sealed override bool Equals(object? obj)
		{
			if (obj is not Entity entity)
				return false;

			if (ReferenceEquals(this, entity))
				return true;
			if (GetType() != entity.GetType())
				return false;
			if (entity.IsTransient() || IsTransient())
				return false;
			else
				return Id.Equals(entity.Id);
		}

		public static bool operator ==(Entity? a, Entity? b)
			=> a is null && b is null || a is not null && b is not null && a.Equals(b);

		public static bool operator !=(Entity? a, Entity? b)
			=> !(a == b);

		public sealed override int GetHashCode()
			=> (GetType().ToString() + Id).GetHashCode();
	}
}
