using System.ComponentModel;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
///     Represents a request to update a sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    ///     Identifier for sale
    /// </summary>
    public string SaleNumber { get; set; }

    /// <summary>
    ///     Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    ///     Customer name
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    ///     Branch name
    /// </summary>
    public Branch Branch { get; set; }

    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    [DefaultValue(false)]
    public bool IsCancelled { get; set; }
}