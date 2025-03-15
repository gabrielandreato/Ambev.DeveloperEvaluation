using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
///     Profile for mapping between domain entities and their respective representation in Application Layer
///     Used to get sale operation.
/// </summary>
public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>();
        CreateMap<SaleItem, GetSaleItemResult>();

    }
}