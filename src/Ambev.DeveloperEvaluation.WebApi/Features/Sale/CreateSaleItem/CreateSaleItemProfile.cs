using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSaleItem;
/// <summary>
/// Profile for mapping between Sale item entity and CreateSaleResponse
/// </summary>
public class CreateSaleItemProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}