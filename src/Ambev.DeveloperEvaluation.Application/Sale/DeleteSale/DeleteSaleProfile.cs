using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Profile for mapping between Sale entity and DeleteSaleResponse
/// </summary>
public class DeleteSaleProfile: Profile
{
    public DeleteSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, DeleteSaleResult>();
    }
}