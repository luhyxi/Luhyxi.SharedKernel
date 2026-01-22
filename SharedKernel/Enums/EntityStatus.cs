namespace SharedKernel.Enums;

/// <summary>
/// Represents the lifecycle status of an entity.
/// </summary>
public enum EntityStatus
{
    /// <summary>
    /// The entity is active and should be considered in normal operations.
    /// </summary>
    Active = 1,

    /// <summary>
    /// The entity is inactive and may be ignored in normal operations.
    /// </summary>
    Inactive = 2,

    /// <summary>
    /// The entity is logically deleted (soft delete).
    /// </summary>
    Deleted = 3,
}
