using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
/// <summary>
/// Profile for mapping between Sale entity and UpdateSaleResponse
/// </summary>
public class UpdateSaleProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        
    }
}