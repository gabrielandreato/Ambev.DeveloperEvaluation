using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

/// <summary>
///     Profile for mapping between Sale entity and their respective representations in aplication layer.
///     Used to get sale operation.
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleCommand>();

        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}