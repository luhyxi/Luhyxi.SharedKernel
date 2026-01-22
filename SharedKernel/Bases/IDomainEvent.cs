namespace SharedKernel.Bases;

/// <summary>
/// Represents an event that occurred within the domain model.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the moment in time when the event occurred.
    /// </summary>
    DateTime OccurredOn { get; }
}
