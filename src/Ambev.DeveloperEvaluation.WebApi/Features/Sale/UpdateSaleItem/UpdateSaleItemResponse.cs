﻿using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSaleItem;

/// <summary>
///     API response model for UpdateSaleItem operation
/// </summary>
public class UpdateSaleItemResponse
{
    /// <summary>
    ///     Unique identifier of the updated sale item.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated sale item in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    ///     External identifier for the sale.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    ///     Product name (denormalized for better performance).
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
    ///     Indicates whether the sale item has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }
}