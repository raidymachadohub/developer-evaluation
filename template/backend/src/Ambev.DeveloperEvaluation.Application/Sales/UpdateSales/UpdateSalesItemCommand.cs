namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSales;

public class UpdateSalesItemCommand
{
    public Guid Id { get; set; }
    
    public int Quantity { get; set; }
    
    public Guid SalesId { get; set; }
    
    public Guid ProductId { get; set; }

    public decimal Price { get; set; }
    
    public decimal Discount { get; set; }
}