namespace Ambev.DeveloperEvaluation.Application.SaleItem.DeleteSaleItem;

/// <summary>
/// Represents the response returned after successfully delete a sale item.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the deleted sale item,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class DeleteSaleItemResult
{
    /// <summary>
    /// Unique sale item identifier.
    /// </summary>
    public Guid Id { get; set; }
    
}