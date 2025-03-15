namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Represents the response returned after successfully delete a sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the deleted sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class DeleteSaleResult
{
    /// <summary>
    /// Unique sale identifier.
    /// </summary>
    public Guid Id { get; set; }
    
}