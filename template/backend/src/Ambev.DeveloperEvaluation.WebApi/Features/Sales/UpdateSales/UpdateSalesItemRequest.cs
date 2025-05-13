namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSalesItemRequest
{
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }
    
    public Guid ProductId { get; set; }  
}