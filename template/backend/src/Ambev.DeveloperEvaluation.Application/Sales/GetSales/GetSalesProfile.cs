using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<Domain.Entities.Sales, GetSalesResponse>();
        CreateMap<Domain.Entities.SalesItem, GetSalesItemResponse>();
    }
}