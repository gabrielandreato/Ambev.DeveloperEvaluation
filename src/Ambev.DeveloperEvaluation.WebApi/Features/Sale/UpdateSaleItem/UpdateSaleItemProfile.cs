using Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSaleItem;

/// <summary>
///     Profile for mapping between SaleItem entity and their respective representations in aplication layer.
///     Used to update sale item operation
/// </summary>
public class UpdateSaleItemProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for UpdateSaleItem operation
    /// </summary>
    public UpdateSaleItemProfile()
    {
        CreateMap<UpdateSaleItemResult, UpdateSaleItemResponse>();
        CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
    }
}