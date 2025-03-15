using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetListSale;

/// <summary>
///     Profile for mapping between domain entities and their respective representation in Application Layer
///     Used to get list sale operation.
/// </summary>
public class GetListSaleProfile : Profile
{
    public GetListSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetListSaleResult>();
        CreateMap<SaleItem, GetListSaleItemResult>();

    }
}