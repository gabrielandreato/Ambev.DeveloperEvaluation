﻿using Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
///     Profile for mapping between Sale entity and their respective representations in aplication layer.
///     Used to delete sale operation.
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for DeleteSale operation
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
    }
}