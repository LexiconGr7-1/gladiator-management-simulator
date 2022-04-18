namespace Gladiator.Core.Aggregates.BaseAggregate
{
    public abstract class BaseWithName : Base
    {
        public virtual string Name { get; set; }
    }
}
