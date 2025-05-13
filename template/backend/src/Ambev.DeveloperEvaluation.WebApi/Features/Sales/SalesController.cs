using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetByIdSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
///  Controller for managing sales.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController(IMediator mediator,
                             IMapper mapper) : BaseController
{
    /// <summary>
    /// Creates a new sale.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSales([FromBody] CreateSalesRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateSalesCommand>(request);
        var response = await mediator.Send(command, cancellationToken);
        
        // Implementation here
        return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data =  response
        });
    }
    
    /// <summary>
    /// Retrieves a list of sales.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<List<GetSalesResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSales(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetSalesCommand(), cancellationToken);
        
        return Ok(new ApiResponseWithData<List<GetSalesResponse>>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = response
        });
    }
    
    /// <summary>
    /// Retrieves a sale by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetByIdSalesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetByIdSalesRequest{ Id = id };
        
        var command = mapper.Map<GetByIdSalesCommand>(request);
        
        var response = await mediator.Send(command, cancellationToken);
        
        return Ok(new ApiResponseWithData<GetByIdSalesResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data =  response
        });
    }
    
    /// <summary>
    /// Deletes a sale by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesCommand(id);
        
        var command = mapper.Map<DeleteSalesCommand>(request);
        
        await mediator.Send(command, cancellationToken);
        
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }
    
    /// <summary>
    /// Updates an existing sale.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSalesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSales([FromBody] UpdateSalesRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<UpdateSalesCommand>(request);
        var response = await mediator.Send(command, cancellationToken);
        
        return Ok(new ApiResponseWithData<UpdateSalesResponse>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data =  response
        });
    }
}