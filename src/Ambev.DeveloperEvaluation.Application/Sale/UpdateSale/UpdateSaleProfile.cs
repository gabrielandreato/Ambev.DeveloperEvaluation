using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

/// <summary>
///     Profile for mapping between domain entities and their respective representation in Application Layer
///     Used to update sale operation.
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for UpdateSale operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Domain.Entities.Sale>();
        CreateMap<Domain.Entities.Sale, UpdateSaleResult>();

        CreateMap<Domain.Entities.Sale, Domain.Entities.Sale>();
    }
}