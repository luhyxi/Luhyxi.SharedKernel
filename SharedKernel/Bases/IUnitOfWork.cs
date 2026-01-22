namespace SharedKernel.Bases;

/// <summary>
/// Represents a unit of work that coordinates persistence and transactional boundaries.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Persists changes to the underlying data store.
    /// </summary>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists entities and dispatches any related side effects (e.g., domain events), depending on the implementation.
    /// </summary>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
