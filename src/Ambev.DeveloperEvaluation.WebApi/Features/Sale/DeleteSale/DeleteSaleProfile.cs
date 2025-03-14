using Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Profile for mapping between Sale entity and DeleteSaleResponse
/// </summary>
public class DeleteSaleProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSale operation
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
        
        CreateMap<DeleteSaleResult, DeleteSaleResponse>();
    }
}