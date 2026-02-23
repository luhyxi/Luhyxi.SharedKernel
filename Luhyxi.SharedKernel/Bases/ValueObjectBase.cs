namespace Luhyxi.SharedKernel.Bases;

/// <summary>
/// Base type for immutable value objects, providing structural equality and ordering based on component values.
/// </summary>
[Serializable]
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Yield returns the value inside the ValueObject
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<object?> GetAtomicValues();


    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (ReferenceEquals(this, obj)) return true;

        if (obj.GetType() != GetType()) return false;

        return Equals((ValueObject)obj);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
    }

    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b)
    {
        return !(a == b);
    }

}
