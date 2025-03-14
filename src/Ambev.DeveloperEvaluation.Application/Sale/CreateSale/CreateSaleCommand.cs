using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including Sale number, sale date, customer, branch, status canceled, sale items. 
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand: IRequest<CreateSaleResult>
{
    /// <summary>
    /// The unique identifier of the created sale
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
    

    /// <summary>
    /// List of items included in the sale.
    /// </summary>
    public List<CreateSaleItemCommand> Items { get; set; } = new();
}