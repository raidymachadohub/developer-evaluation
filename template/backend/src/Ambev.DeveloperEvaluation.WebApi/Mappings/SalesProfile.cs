using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetByIdSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class SalesProfile : Profile
{
    public SalesProfile()
    {
        CreateMap<CreateSalesRequest, CreateSalesCommand>();
        CreateMap<CreateSalesItemRequest, CreateSalesItemCommand>();
        
        
        CreateMap<UpdateSalesRequest, UpdateSalesCommand>();
        CreateMap<UpdateSalesItemRequest, UpdateSalesItemCommand>();
        
        CreateMap<GetByIdSalesRequest, GetByIdSalesCommand>();
        CreateMap<GetSalesRequest, GetSalesCommand>();
        CreateMap<DeleteSalesRequest, DeleteSalesCommand>();
    }
}