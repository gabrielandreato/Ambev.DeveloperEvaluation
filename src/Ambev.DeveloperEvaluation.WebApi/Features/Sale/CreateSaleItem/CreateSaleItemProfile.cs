using Ambev.DeveloperEvaluation.Application.Sale.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSaleItem;

/// <summary>
///     Profile for mapping between SaleItem entity and their respective representations in aplication layer.
///     Used to create sale item operation
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for CreateSaleItem operation
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}