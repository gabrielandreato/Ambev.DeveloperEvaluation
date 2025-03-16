using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetListSale;

/// <summary>
///     Represents the response returned after successfully retrieve a sale.
/// </summary>
/// <remarks>
///     This response contains the unique identifier of the retrieved sale,
///     which can be used for subsequent operations or reference.
/// </remarks>
public class GetListSaleResult
{
    /// <summary>
    ///     Unique sale identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     The unique sale number
    /// </summary>
    public string SaleNumber { get; set; }

    /// <summary>
    ///     Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    ///     Customer name
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    ///     Branch name
    /// </summary>
    public Branch Branch { get; set; }


    /// <summary>
    ///     List of sale items.
    /// </summary>
    public List<GetListSaleItemResult> Items { get; set; } = new();
}