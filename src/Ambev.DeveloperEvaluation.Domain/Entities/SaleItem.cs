using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
///     Represents an individual item in a sale transaction.
/// </summary>
public class SaleItem: BaseEntity
{
    /// <summary>
    ///     Protected constructor to prevent invalid instances.
    /// </summary>
    public SaleItem()
    {
        
    }

    /// <summary>
    ///     Creates a new sale item instance.
    /// </summary>
    public SaleItem(Guid saleId, Guid productId, string productName, int quantity, decimal unitPrice, decimal discount)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
    }
    /// <summary>
    ///     External identifier for the sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    ///     External identifier for the product.
    /// </summary>
    public Guid ProductId { get;  set; }

    /// <summary>
    ///     Product name (denormalized for better performance).
    /// </summary>
    public string ProductName { get;  set; }

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
    public decimal Total => Quantity * UnitPrice - Discount;
}