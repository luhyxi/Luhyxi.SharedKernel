namespace SharedKernel.Bases;

/// <summary>
/// Marker interface for a query (an intent to read system state) with no typed response.
/// </summary>
public interface IQuery : IBaseQuery
{
}

/// <summary>
/// Marker interface for a query (an intent to read system state) that produces a typed response.
/// </summary>
/// <typeparam name="TResponse">The response type produced by handling the query.</typeparam>
public interface IQuery<TResponse> : IBaseQuery
{
}

/// <summary>
/// Common marker interface for all query types.
/// </summary>
public interface IBaseQuery
{
}
