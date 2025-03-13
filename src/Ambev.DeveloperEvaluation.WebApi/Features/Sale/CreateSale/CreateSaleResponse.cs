using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleResponse
{
    /// <summary>
    /// The unique identifier of the created sale
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
    public List<CreateSaleItemResponse> Items { get; set; } = new();
}