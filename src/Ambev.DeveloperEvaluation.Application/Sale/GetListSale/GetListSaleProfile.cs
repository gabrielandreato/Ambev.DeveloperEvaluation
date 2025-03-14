using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetListSale;

/// <summary>
/// Profile for mapping between Sale entity and GetListSaleResponse
/// </summary>
public class GetListSaleProfile: Profile
{
    public GetListSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetListSaleResult>();
        CreateMap<Domain.Entities.SaleItem, GetListSaleItemResult>();
        
    }
    
}