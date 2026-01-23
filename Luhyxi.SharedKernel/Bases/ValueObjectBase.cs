namespace Luhyxi.SharedKernel.Bases;

/// <summary>
/// Base type for immutable value objects, providing structural equality and ordering based on component values.
/// </summary>
[Serializable]
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
    private readonly Lazy<int> _cachedHashCode;

    /// <summary>
    /// Initializes a new value object instance and prepares cached hash code computation.
    /// </summary>
    protected ValueObject()
    {
        _cachedHashCode = new Lazy<int>(() =>
            GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                }));
    }

    /// <summary>
    /// Returns the ordered set of components that define equality for this value object.
    /// </summary>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Determines whether this value object is equal to another object.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    /// <summary>
    /// Returns a hash code based on the equality components.
    /// </summary>
    public override int GetHashCode()
    {
        return _cachedHashCode.Value;
    }

    /// <summary>
    /// Compares this value object with another object of the same unproxied type using equality components.
    /// </summary>
    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;

        var thisType = GetUnproxiedType(this);
        var otherType = GetUnproxiedType(obj);

        if (thisType != otherType)
            return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);

        var other = (ValueObject)obj;

        var components = GetEqualityComponents().ToArray();
        var otherComponents = other.GetEqualityComponents().ToArray();

        return components.Select((t, i) => CompareComponents(t, otherComponents[i]))
            .FirstOrDefault(comparison => comparison != 0);
    }

    private static int CompareComponents(object? object1, object? object2)
    {
        if (object1 is null && object2 is null)
            return 0;

        if (object1 is null)
            return -1;

        if (object2 is null)
            return 1;

        if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
            return comparable1.CompareTo(comparable2);

        return object1.Equals(object2) ? 0 : -1;
    }

    /// <summary>
    /// Compares this value object with another value object instance.
    /// </summary>
    public int CompareTo(ValueObject? other)
    {
        return CompareTo(other as object);
    }

    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    public static bool operator !=(ValueObject a, ValueObject b)
    {
        return !(a == b);
    }

    /// <summary>
    /// Returns the runtime type of an object without unproxying (extension point for ORMs/proxies if needed).
    /// </summary>
    /// <param name="obj">The object whose type should be returned.</param>
    internal static Type GetUnproxiedType(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return obj.GetType();
    }
}