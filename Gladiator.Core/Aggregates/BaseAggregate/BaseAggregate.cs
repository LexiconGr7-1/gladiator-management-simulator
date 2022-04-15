namespace Gladiator.Core.Aggregates.BaseAggregate
{
    public abstract class BaseAggregate
    {
        public virtual long Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
