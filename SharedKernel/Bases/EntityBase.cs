using SharedKernel.Enums;

namespace SharedKernel.Bases;

public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; set; } = default!;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public EntityStatus Status { get; set; } = EntityStatus.Inactive;
    public DateTime UpdatedDate { get; set; }
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}