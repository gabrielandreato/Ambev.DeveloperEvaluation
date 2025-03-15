namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteItemSale;

/// <summary>
/// Represents a request to delete a sale in the system.
/// </summary>
public class DeleteSaleItemRequest
{
    /// <summary>
    /// Unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }
}