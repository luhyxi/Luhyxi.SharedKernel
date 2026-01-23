using System.ComponentModel;

namespace Luhyxi.SharedKernel.Bases;

/// <summary>
/// Represents pagination parameters for requesting a single page of results.
/// </summary>
/// <param name="PageSize">Number of items to return in a single page of results.</param>
/// <param name="PageIndex">The index of the page of results to return.</param>
public record PaginationRequest(
    [property: Description("Number of items to return in a single page of results")]
    [property: DefaultValue(10)]
    int PageSize = 10,

    [property: Description("The index of the page of results to return")]
    [property: DefaultValue(0)]
    int PageIndex = 0
);
