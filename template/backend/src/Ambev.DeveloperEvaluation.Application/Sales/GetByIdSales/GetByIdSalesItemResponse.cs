namespace Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;

public class GetByIdSalesItemResponse
{
    public Guid Id { get; set; }
    
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }
    
    public Guid ProductId { get; set; }
}