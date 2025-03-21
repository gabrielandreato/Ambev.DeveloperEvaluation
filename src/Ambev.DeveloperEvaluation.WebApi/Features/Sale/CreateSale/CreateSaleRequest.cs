﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
///     Represents a request to create a new sale item in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    ///     The unique identifier of the created sale
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
    ///     List of items included in the sale.
    /// </summary>
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}