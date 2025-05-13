namespace Ambev.DeveloperEvaluation.Application.Sales.GetByIdSales;

public class GetByIdSalesResponse
{
    public Guid Id { get; set; }
    
    public long Number { get; set; }
    
    public DateTime SalesAt { get; set; }

    public string Client { get; set; } = string.Empty;
    
    public Guid BranchId { get; set; }
    
    public ICollection<GetByIdSalesItemResponse> SalesItems { get; set; } = new List<GetByIdSalesItemResponse>();
    
    public decimal TotalSales { get; set; }

    public bool Canceled { get; set; }
}