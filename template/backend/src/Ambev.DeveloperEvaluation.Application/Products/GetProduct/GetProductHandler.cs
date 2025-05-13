using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductHandler(IProductRepository productRepository,
                               IMapper mapper) : IRequestHandler<GetProductCommand, List<GetProductResponse>>
{
    public async Task<List<GetProductResponse>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
       var products = await productRepository.GetAllAsync(cancellationToken);
       
        var result = mapper.Map<List<GetProductResponse>>(products);
        
        return result;
    }
}