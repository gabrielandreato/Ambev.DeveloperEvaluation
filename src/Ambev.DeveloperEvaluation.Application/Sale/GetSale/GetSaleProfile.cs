using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
/// Profile for mapping between Sale entity and GetSaleResponse
/// </summary>
public class GetSaleProfile: Profile
{
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>();
        CreateMap<Domain.Entities.SaleItem, GetSaleItemResult>();
        
    }
    
}