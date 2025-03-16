using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSaleItem;

/// <summary>
///     Profile for mapping between domain entities and their respective representation in Application Layer
///     Used to create item sale operation.
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for CreateSaleItem operation
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, SaleItem>()
            .ConstructUsing(cmd => new SaleItem(
                cmd.SaleId,
                cmd.Product,
                cmd.Quantity,
                cmd.UnitPrice,
                cmd.IsCancelled));

        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}