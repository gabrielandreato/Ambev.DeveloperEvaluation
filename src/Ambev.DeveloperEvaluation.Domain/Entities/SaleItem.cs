using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
///     Represents an individual item in a sale transaction.
/// </summary>
public class SaleItem : BaseEntity
{
    
    /// <summary>
    ///     Creates a new sale item instance with automatic discount application.
    /// </summary>
    public SaleItem(Guid saleId, Product product, int quantity, decimal unitPrice, bool isCancelled = false)
    {
        SaleId = saleId;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        CalculateDiscount();
        IsCancelled = isCancelled;
        IsGreaterThan20();
    }

    /// <summary>
    ///     External identifier for the sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    ///     Product associated with the sale item.
    /// </summary>
    public Product Product { get; set; }

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
    public decimal Discount { get; private set; }
    
    /// <summary>
    ///     Indicates whether the sale item has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    ///     Total amount for the item after applying discount.
    /// </summary>
    public decimal Total => Quantity * UnitPrice - Discount;

    /// <summary>
    ///     Calculates the discount based on the quantity.
    /// </summary>
    public void CalculateDiscount()
    {
        Discount = Quantity switch
        {
            < 4 => 0m,
            < 10 => UnitPrice * 0.1m * Quantity,
            _ => UnitPrice * 0.2m * Quantity
        };
    }

    public void IsGreaterThan20()
    {
        if (Quantity > 20) throw new InvalidOperationException("Quantity must be greater than 20");
    }
    
}