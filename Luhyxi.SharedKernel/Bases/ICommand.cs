namespace Luhyxi.SharedKernel.Bases;

/// <summary>
/// Marker interface for a command (an intent to change system state) with no typed response.
/// </summary>
public interface ICommand : IBaseCommand
{
}

/// <summary>
/// Marker interface for a command (an intent to change system state) that produces a typed response.
/// </summary>
/// <typeparam name="TResponse">The response type produced by handling the command.</typeparam>
public interface ICommand<TResponse> : IBaseCommand
{
}

/// <summary>
/// Common marker interface for all command types.
/// </summary>
public interface IBaseCommand
{
}
