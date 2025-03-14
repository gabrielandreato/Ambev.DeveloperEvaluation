namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Represents the response returned after successfully retrieve a sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the retrieved sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class DeleteSaleResult
{
    /// <summary>
    /// Unique sale identifier.
    /// </summary>
    public Guid Id { get; set; }
    
}