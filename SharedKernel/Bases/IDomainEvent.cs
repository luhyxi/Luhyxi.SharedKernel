namespace SharedKernel.Bases;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}