using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}