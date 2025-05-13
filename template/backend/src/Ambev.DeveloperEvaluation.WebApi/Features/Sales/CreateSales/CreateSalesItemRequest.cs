namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSalesItemRequest
{
    public int Quantity { get; set; }
    
    public Guid ProductId { get; set; }
}