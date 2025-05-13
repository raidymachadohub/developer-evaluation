namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesItemCommand
{
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }
    
    public Guid ProductId { get; set; }

    public decimal Price { get; set; }
    
    public decimal Discount { get; set; }
}