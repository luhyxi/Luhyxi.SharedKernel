using SharedKernel.Enums;

namespace SharedKernel.Bases;

/// <summary>
/// Base type for domain entities, providing identity, lifecycle metadata, and domain event tracking.
/// </summary>
/// <typeparam name="TId">The entity identifier value type.</typeparam>
public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public TId Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the creation timestamp of this entity.
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the current status of this entity.
    /// </summary>
    public EntityStatus Status { get; set; } = EntityStatus.Inactive;

    /// <summary>
    /// Gets or sets the last update timestamp of this entity.
    /// </summary>
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// Gets the domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    /// <summary>
    /// Removes all currently tracked domain events from this entity.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>
    /// Adds a domain event to this entity's event collection.
    /// </summary>
    /// <param name="domainEvent">The domain event to add.</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}