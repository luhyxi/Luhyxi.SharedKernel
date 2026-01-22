namespace SharedKernel.Bases;

/// <summary>
/// Handles a domain event of a specific type.
/// </summary>
/// <typeparam name="TDomainEvent">The domain event type.</typeparam>
public interface IDomainEventHandler<in TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    /// <summary>
    /// Handles the provided domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event instance.</param>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
