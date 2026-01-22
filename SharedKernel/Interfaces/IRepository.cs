using SharedKernel.Bases;

namespace SharedKernel.Interfaces;

/// <summary>
/// Base repository contract for aggregates, exposing the associated <see cref="IUnitOfWork"/>.
/// </summary>
/// <typeparam name="T">The aggregate root type.</typeparam>
public interface IRepository<T> where T : IAggregateRoot
{
    /// <summary>
    /// Gets the unit of work used to persist changes made through the repository.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}