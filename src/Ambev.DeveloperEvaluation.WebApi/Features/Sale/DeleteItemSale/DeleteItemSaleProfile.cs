using Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteItemSale;

/// <summary>
///     Profile for mapping between SaleItem entity and their respective representations in aplication layer.
///     Used to delete item operation.
/// </summary>
public class DeleteSaleItemProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for DeleteSaleItem operation
    /// </summary>
    public DeleteSaleItemProfile()
    {
        CreateMap<DeleteSaleItemRequest, DeleteSaleItemCommand>();

    }
}