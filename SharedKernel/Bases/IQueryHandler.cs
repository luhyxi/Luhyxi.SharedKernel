using SharedKernel.ValueObjects;

namespace SharedKernel.Bases;

/// <summary>
/// Handles a query and returns an untyped <see cref="Result"/> indicating success or failure.
/// </summary>
/// <typeparam name="TQuery">The query type.</typeparam>
public interface IQueryHandler<in TQuery> where TQuery : IQuery
{
    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<Result> Handle(TQuery query, CancellationToken cancellationToken = default);
}

/// <summary>
/// Handles a query and returns a typed <see cref="Result{TResponse}"/>.
/// </summary>
/// <typeparam name="TQuery">The query type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
}
