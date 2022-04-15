namespace Gladiator.Core.Aggregates.BaseAggregate
{
    public abstract class BaseAggregateWithName : BaseAggregate
    {
        public virtual string Name { get; set; }
    }
}
