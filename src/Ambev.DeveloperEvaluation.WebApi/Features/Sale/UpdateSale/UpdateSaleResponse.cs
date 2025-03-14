using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
/// API response model for UpdateSale operation
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated sale.
    /// </summary>
    /// <value>A GUID that uniquely identifies the Updated sale in the system.</value>
    public Guid Id { get; set; }
    /// <summary>
    /// Identifier for sale
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
    
}