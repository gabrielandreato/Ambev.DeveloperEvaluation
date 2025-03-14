using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale;



public class SaleController: BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    /// <summary>
    /// Update a sale
    /// </summary>
    /// <param name="id">Unique identifier sale</param>
    /// <param name="request">The sale update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale details</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSale([FromRoute] Guid id,[FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var command = _mapper.Map<UpdateSaleCommand>(request);
        
        command.Id = id;
        
        var response = await _mediator.Send(command, cancellationToken);
        
        return Ok(new ApiResponseWithData<UpdateSaleResponse>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data = _mapper.Map<UpdateSaleResponse>(response)
        });
    }

    /// <summary>
    /// Update a sale
    /// </summary>
    /// <param name="id">Unique identifier sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A sale from requested id</returns>
    // [HttpGet("{id}")]
    // [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status204NoContent)]
    // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    // public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    // {
    //     var validator = new GetSaleRequestValidator();
    //     var validationResult = await validator.ValidateAsync(request, cancellationToken);
    //
    //     if (!validationResult.IsValid)
    //         return BadRequest(validationResult.Errors);
    //     
    //     var command = _mapper.Map<GetSaleCommand>(request);
    //
    //     command.Id = id;
    //     
    //     var response = await _mediator.Send(command, cancellationToken);
    //     
    //     return Ok(new ApiResponseWithData<GetSaleResponse>
    //     {
    //         Success = true,
    //         Message = "Sale retrieved successfully",
    //         Data = _mapper.Map<GetSaleResponse>(response)
    //     });
    // }
}