namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSalesRequest
{
    public long Number { get; set; }
    public DateTime SalesAt { get; set; }

    public Guid Client { get; set; } = Guid.Empty;
    
    public Guid BranchId { get; set; }
    
    public ICollection<UpdateSalesItemRequest> SalesItems { get; set; } = new List<UpdateSalesItemRequest>();
    
    public decimal TotalSales { get; set; }

    public bool Canceled { get; set; }
}