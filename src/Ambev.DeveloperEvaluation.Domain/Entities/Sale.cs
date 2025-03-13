using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction in the system.
/// </summary>
public class Sale: BaseEntity
{
    /// <summary>
    /// Protected constructor to prevent invalid instances.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.Now;
    }
    
    /// <summary>
    /// Unique sale number.
    /// </summary>
    public string SaleNumber { get; set; }

    /// <summary>
    /// Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }
    

    /// <summary>
    /// Customer name 
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Branch name 
    /// </summary>
    public Branch Branch { get; set; }
    

    /// <summary>
    /// Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// List of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void CancelSale()
    {
        IsCancelled = true;
    }
    
    /// <summary>
    /// Adds an item to the sale and calculates discounts based on quantity.
    /// </summary>
    public void AddItem(Guid productId, Product product, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");

        if (quantity < 4)
            AddSaleItem(productId, product, quantity, unitPrice, 0m);
        else if (quantity < 10)
            AddSaleItem(productId, product, quantity, unitPrice, unitPrice * 0.1m);
        else
            AddSaleItem(productId, product, quantity, unitPrice, unitPrice * 0.2m);
    }

    private void AddSaleItem(Guid productId, Product product, int quantity, decimal unitPrice, decimal discount)
    {
        var saleItem = new SaleItem(this.Id, product, quantity, unitPrice, discount);
        Items.Add(saleItem);
    }
}
