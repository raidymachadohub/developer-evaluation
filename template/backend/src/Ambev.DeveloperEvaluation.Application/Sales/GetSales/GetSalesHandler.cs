using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesHandler(ISalesRepository salesRepository,
                               IMapper mapper) : IRequestHandler<GetSalesCommand, List<GetSalesResponse>>
{
    public async Task<List<GetSalesResponse>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
       var sales = await salesRepository.GetAllAsync(["SalesItems"], cancellationToken);
        var result = mapper.Map<List<GetSalesResponse>>(sales);
        
        return result;
    }
}