using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;

public class GetByIdSalesHandler(ISalesRepository salesRepository,
                               IMapper mapper) : IRequestHandler<GetByIdSalesCommand, GetByIdSalesResponse>
{
    public async Task<GetByIdSalesResponse> Handle(GetByIdSalesCommand request, CancellationToken cancellationToken)
    {
       var sales = await salesRepository.GetByIdAsync(request.Id, ["SalesItems"], cancellationToken);
        var result = mapper.Map<GetByIdSalesResponse>(sales);
        
        return result;
    }
}