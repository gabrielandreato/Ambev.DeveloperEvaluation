using Ambev.DeveloperEvaluation.Application.SaleItem.DeleteSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem;

/// <summary>
/// Profile for mapping between SaleItem entity and DeleteSaleItemResponse
/// </summary>
public class DeleteSaleItemProfile: Profile
{
    public DeleteSaleItemProfile()
    {
        CreateMap<Domain.Entities.SaleItem, DeleteSaleItemResult>();
    }
}