namespace Gladiator.Core.Aggregates.BaseAggregate
{
    public abstract class Base
    {
        public virtual ulong Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
