﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetListSale;

/// <summary>
///     API response model for GetSale operation
/// </summary>
public class GetListSaleResponse
{
    /// <summary>
    ///     Unique sale identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     The unique sale number
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
    ///     List of sale items.
    /// </summary>
    public List<GetListSaleItemResponse> Items { get; set; } = new();
}