namespace Luhyxi.SharedKernel.ValueObjects;

/// <summary>
/// Represents the outcome of an operation that can succeed or fail, carrying an <see cref="Error"/> on failure.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new <see cref="Result"/> instance.
    /// </summary>
    /// <param name="isSuccess">Whether the operation succeeded.</param>
    /// <param name="error">The associated error (must be <see cref="Error.None"/> for success).</param>
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the result represents success.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result represents failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with the result (or <see cref="Error.None"/> for success).
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <param name="error">The error describing the failure.</param>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Creates a successful typed result with the specified value.
    /// </summary>
    protected static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Creates a failure typed result with the specified error.
    /// </summary>
    protected static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

/// <summary>
/// Represents the outcome of an operation that can succeed or fail, carrying a value on success.
/// </summary>
/// <typeparam name="TValue">The value type.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new <see cref="Result{TValue}"/> instance.
    /// </summary>
    /// <param name="value">The value (only valid when successful).</param>
    /// <param name="isSuccess">Whether the operation succeeded.</param>
    /// <param name="error">The associated error.</param>
    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the value for a successful result; throws if accessed on a failure result.
    /// </summary>
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed");

    /// <summary>
    /// Converts a value into a successful result, or into a failure result when the value is null.
    /// </summary>
    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}