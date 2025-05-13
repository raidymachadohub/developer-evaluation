using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;

public class GetByIdSalesCommand : IRequest<GetByIdSalesResponse>
{
    public Guid Id { get; set; }
}