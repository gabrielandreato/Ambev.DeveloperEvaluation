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
    public SaleItem(Guid saleId, Product product, int quantity, decimal unitPrice)
    {
        SaleId = saleId;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = CalculateDiscount(quantity, unitPrice);
        IsGreaterThan20(quantity);
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
    public decimal Discount { get; }

    /// <summary>
    ///     Total amount for the item after applying discount.
    /// </summary>
    public decimal Total => Quantity * UnitPrice - Discount;

    /// <summary>
    ///     Calculates the discount based on the quantity.
    /// </summary>
    private decimal CalculateDiscount(int quantity, decimal unitPrice)
    {
        if (quantity < 4) return 0m;
        if (quantity < 10) return unitPrice * 0.1m * quantity;
        return unitPrice * 0.2m * quantity;
    }

    private void IsGreaterThan20(int quantity)
    {
        if (quantity > 20) throw new InvalidOperationException("Quantity must be greater than 20");
    }
}