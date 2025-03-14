using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetListSale;

/// <summary>
/// Represents the response returned after successfully retrieve sale list .
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the retrieved sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class GetListSaleItemResult
{
    /// <summary>
    ///     Unique sale item identifier.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    ///     External identifier for the sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    ///     Product name (denormalized for better performance).
    /// </summary>
    public Product Product { get;  set; }

    /// <summary>
    ///     Quantity of the product purchased.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    ///     Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    ///     Discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    ///     Total amount for the item after applying discount.
    /// </summary>
    public decimal Total { get; set; }
}