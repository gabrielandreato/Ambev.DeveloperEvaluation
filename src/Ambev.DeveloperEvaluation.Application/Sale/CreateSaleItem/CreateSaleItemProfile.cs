using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSaleItem;

/// <summary>
/// Profile for mapping between Sale item entity and CreateSaleItemResponse
/// </summary>
public class CreateSaleItemProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItem operation
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, Domain.Entities.SaleItem>();
        CreateMap<Domain.Entities.SaleItem, CreateSaleItemResult>();
    }
}