using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetListSale;

/// <summary>
/// Command for get sale list.
/// </summary>
/// <remarks>
/// This command is used to retrieve sale list.
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="GetListSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="GetListSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class GetListSaleCommand: IRequest<List<GetListSaleResult>>
{
    /// <summary>
    /// Optional sale number to filter results.
    /// </summary>
    public string? SaleNumber { get; set; }

    /// <summary>
    /// Optional flag to filter by canceled status.
    /// </summary>
    public bool? IsCanceled { get; set; }

    /// <summary>
    /// Optional branch to filter results by.
    /// </summary>
    public Branch? Branch { get; set; }

    /// <summary>
    /// Optional customer to filter results by.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Optional starting date to filter sales from.
    /// </summary>
    public DateTime? SaleDateFrom { get; set; }

    /// <summary>
    /// Optional end date to filter sales until.
    /// </summary>
    public DateTime? SaleDateTo { get; set; }
}