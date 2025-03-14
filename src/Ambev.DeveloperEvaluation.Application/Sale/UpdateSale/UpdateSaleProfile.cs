using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

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
        CreateMap<UpdateSaleCommand, Domain.Entities.Sale>();
        CreateMap<Domain.Entities.Sale, UpdateSaleResult>();
        
        CreateMap<Domain.Entities.Sale, Domain.Entities.Sale>();
    }
}