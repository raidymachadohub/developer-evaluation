namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesResponse
{
    public Guid Id { get; set; }
    
    public long Number { get; set; }
    
    public DateTime SalesAt { get; set; }

    public string Client { get; set; } = string.Empty;
    
    public Guid BranchId { get; set; }
    
    public ICollection<GetSalesItemResponse> SalesItems { get; set; } = new List<GetSalesItemResponse>();
    
    public decimal TotalSales { get; set; }

    public bool Canceled { get; set; }
}