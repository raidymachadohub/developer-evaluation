using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

public class DeleteSalesHandler(ISalesRepository salesRepository) : IRequestHandler<DeleteSalesCommand, DeleteSalesResponse>
{
    public async Task<DeleteSalesResponse> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var success = await salesRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

        return new DeleteSalesResponse { Success = true };
    }
}