namespace Common.Domain;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot() {}
    
    protected AggregateRoot(long id) : base(id) {}
}