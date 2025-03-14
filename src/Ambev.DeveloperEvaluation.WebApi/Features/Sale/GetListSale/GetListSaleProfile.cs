using Ambev.DeveloperEvaluation.Application.Sale.GetListSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetListSale;

/// <summary>
/// Profile for mapping between Sale entity and GetListSaleResponse
/// </summary>
public class GetListSaleProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for GetListSale operation
    /// </summary>
    public GetListSaleProfile()
    {
        CreateMap<GetListSaleRequest, GetListSaleCommand>();
        
        CreateMap<GetListSaleResult, GetListSaleResponse>();
        CreateMap<GetListSaleItemResult, GetListSaleItemResponse>();
    }
}