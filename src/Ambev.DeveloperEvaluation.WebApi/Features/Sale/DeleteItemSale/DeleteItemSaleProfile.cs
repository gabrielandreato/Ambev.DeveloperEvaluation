using Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItem.DeleteSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteItemSale;

/// <summary>
/// Profile for mapping between SaleItem entity and DeleteSaleItemResponse
/// </summary>
public class DeleteSaleItemProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSaleItem operation
    /// </summary>
    public DeleteSaleItemProfile()
    {
        CreateMap<DeleteSaleItemRequest, DeleteSaleItemCommand>();
        
        CreateMap<DeleteSaleItemResult, DeleteSaleItemResponse>();
    }
}