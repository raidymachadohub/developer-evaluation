namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesItemResponse
{
    public Guid Id { get; set; }
    
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }
    
    public Guid ProductId { get; set; }
}