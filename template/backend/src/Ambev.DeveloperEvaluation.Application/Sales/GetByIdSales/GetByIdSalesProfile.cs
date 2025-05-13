using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;

public class GetByIdSalesProfile : Profile
{
    public GetByIdSalesProfile()
    {
        CreateMap<Domain.Entities.Sales, GetByIdSalesResponse>();
        CreateMap<Domain.Entities.SalesItem, GetByIdSalesItemResponse>();
    }
}