namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
}