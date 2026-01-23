using Luhyxi.SharedKernel.ValueObjects;

namespace Luhyxi.SharedKernel.Bases;

/// <summary>
/// Handles a command and returns an untyped <see cref="Result"/> indicating success or failure.
/// </summary>
/// <typeparam name="TCommand">The command type.</typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);
}

/// <summary>
/// Handles a command and returns a typed <see cref="Result{TResponse}"/>.
/// </summary>
/// <typeparam name="TCommand">The command type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">A token used to cancel the operation.</param>
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken = default);
}
