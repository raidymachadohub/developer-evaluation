using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

public class UpdateSalesHandler(ISalesRepository salesRepository,
                                 IMapper mapper) : IRequestHandler<UpdateSalesCommand, UpdateSalesResponse>
{
    public async Task<UpdateSalesResponse> Handle(UpdateSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newSales = mapper.Map<Domain.Entities.Sales>(request);
        var createdSales = await salesRepository.UpdateAsync(newSales, cancellationToken);
        
        var result = mapper.Map<UpdateSalesResponse>(createdSales);
        return result;
    }
}