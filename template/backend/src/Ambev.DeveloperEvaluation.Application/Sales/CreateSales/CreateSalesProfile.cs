using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesProfile : Profile
{
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesCommand, Domain.Entities.Sales>();
        CreateMap<CreateSalesItemCommand, SalesItem>();
        
        CreateMap<Domain.Entities.Sales, CreateSalesResponse>();
    }
}