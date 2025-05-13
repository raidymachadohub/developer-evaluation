using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

public class UpdateSalesProfile : Profile
{
    public UpdateSalesProfile()
    {
        CreateMap<UpdateSalesCommand, Domain.Entities.Sales>();
        CreateMap<UpdateSalesItemCommand, SalesItem>();
        
        CreateMap<Domain.Entities.Sales, UpdateSalesResponse>();
    }
}