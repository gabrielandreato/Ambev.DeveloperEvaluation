using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;

/// <summary>
///     Profile for mapping between domain entities and their respective representation in Application Layer
///     Used to update item sale operation.
/// </summary>
public class UpdateSaleItemProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for UpdateSaleItem operation
    /// </summary>
    public UpdateSaleItemProfile()
    {
        CreateMap<UpdateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, UpdateSaleItemResult>();
    }
}