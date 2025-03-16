using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
///     Profile for mapping between Sale entity and their respective representations in aplication layer.
///     used to update sale operation.
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for UpdateSale operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();

    }
}