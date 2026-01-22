namespace SharedKernel.ValueObjects;

/// <summary>
/// Represents an error with a stable code and human-readable description.
/// </summary>
/// <param name="Code">A stable, machine-friendly error code.</param>
/// <param name="Description">A human-friendly error description.</param>
public sealed record Error(string Code, string Description)
{
    /// <summary>
    /// Represents the absence of an error.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Represents an error used when a null value is provided where a value is required.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    /// <summary>
    /// Converts an <see cref="Error"/> into a failure <see cref="Result"/>.
    /// </summary>
    public static implicit operator Result(Error error) => Result.Failure(error);

    /// <summary>
    /// Creates a failure <see cref="Result"/> for this error.
    /// </summary>
    public Result ToResult() => Result.Failure(this);
}