namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSalesRequest
{
    public long Number { get; set; }
    
    public DateTime SalesAt { get; set; }
    
    public Guid BranchId { get; set; }

    public string Client { get; set; }
    
    public ICollection<CreateSalesItemRequest> SalesItems { get; set; } = new List<CreateSalesItemRequest>();

    public bool Canceled { get; set; } = false;
}